using AutoMapper;
using Data;
using Data.ViewModels;
using Domain.Catalogos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TorreServicioApi.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class SamsaraGeocercaController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<SamsaraGeocercaController> _logger;

        public SamsaraGeocercaController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<SamsaraGeocercaController> logger)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpGet("")]
        public async Task<IActionResult> ObtenerLista()
        {

            try
            {

                bool nextPage = true;
                var urlOriginal = "";
                var url = "";

                urlOriginal = "https://api.samsara.com/addresses";
                url = "https://api.samsara.com/addresses";


                while (nextPage == true)
                {
                    using (var client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "samsara_api_0OwOqgj4pip3pSlJmcUUrHo5H2E29T");
                        var responseTask = client.GetAsync(url);
                        responseTask.Wait();

                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var readTask = result.Content.ReadAsAsync<ResultSamsaraGeocercaApi>();
                            readTask.Wait();

                            var resultado = readTask.Result;

                            var gf = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);

                            nextPage = resultado.Pagination.hasNextPage;
                            url = urlOriginal + "?after=" + resultado.Pagination.endCursor;

                            foreach (var m in resultado.Data)
                            {
                                if(m.Name.ToUpper().Contains("CASETA"))
                                {
                                    bool aborta = false;
                                    double longitudem = m.Longitude;
                                    double latitudem = m.Latitude;

                                    if (m.Longitude > 180 || m.Longitude < -180 || m.Latitude > 90 || m.Latitude < -90)
                                    {
                                        latitudem = m.Longitude;
                                        longitudem = m.Latitude;
                                    }

                                    if (longitudem > 180 || longitudem < -180 || latitudem > 90 || latitudem < -90)
                                    {
                                        aborta = true;
                                        break;
                                    }

                                    if (aborta == false)
                                    {
                                        var punto = gf.CreatePoint(new NetTopologySuite.Geometries.Coordinate(longitudem, latitudem));

                                        List<NetTopologySuite.Geometries.Coordinate> coordenadas = new List<NetTopologySuite.Geometries.Coordinate>();

                                        if (m.Geofence.Polygon != null)
                                        {
                                            aborta = false;

                                            foreach (var x in m.Geofence.Polygon.Vertices)
                                            {
                                                double longitude = x.Longitude;
                                                double latitude = x.Latitude;

                                                if (x.Longitude > 180 || x.Longitude < -180 || x.Latitude > 90 || x.Latitude < -90)
                                                {
                                                    latitude = x.Longitude;
                                                    longitude = x.Latitude;
                                                }

                                                if (longitude > 180 || longitude < -180 || latitude > 90 || latitude < -90)
                                                {
                                                    aborta = true;
                                                    break;
                                                }

                                                coordenadas.Add(new NetTopologySuite.Geometries.Coordinate(longitude, latitude));
                                            }

                                            if (aborta == false)
                                            {
                                                var firstCoord = coordenadas[0];
                                                var lastCoord = coordenadas.LastOrDefault();

                                                if (firstCoord.CompareTo(lastCoord) != 0)
                                                {
                                                    coordenadas[coordenadas.Count - 1].X = firstCoord.X;
                                                    coordenadas[coordenadas.Count - 1].Y = firstCoord.Y;
                                                }

                                                if (lastCoord != null && coordenadas.Count > 3)
                                                {
                                                    var poligono = gf.CreatePolygon(coordenadas.ToArray());

                                                    if (!poligono.Shell.IsCCW)
                                                        poligono = (Polygon)poligono.Reverse();

                                                    var geocerca = new Geocerca
                                                    {
                                                        Nombre = m.Name,
                                                        Descripcion = m.FormattedAddress,
                                                        Poligono = poligono,
                                                        Punto = punto,
                                                        TipoGeocercaId = 86,
                                                        BActivo = true,
                                                        FechaAlta = DateTime.Now,
                                                        GeocercaIdExterno = m.Id
                                                    };


                                                    _repository.Add(geocerca);
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }


                if (await _repository.SaveAllAsync())
                {
                    return Ok();
                }

                return BadRequest("No grabó las geocercas");
            }
            catch (Exception ex)
            {
                _logger.LogError("Falló al traer geocercas samsara: {0}", ex);
                return BadRequest("Falló al traer geocercas samsara");
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public static float ToSingle(double value)
        {
            return (float)value;
        }


    }
}


