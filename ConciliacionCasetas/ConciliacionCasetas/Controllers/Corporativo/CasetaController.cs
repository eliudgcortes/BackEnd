
using AutoMapper;
using Data;
using Data.SearchModels.Catalogos;
using Domain;
using Domain.Catalogos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoMaestro.ViewModels;
using System.Security.Claims;

namespace ProyectoMaestro.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CasetaController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<CasetaController> _logger;

        public CasetaController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<CasetaController> logger)
        {
            _repository = repository;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var caseta = await _repository.ObtenerCasetaAsync(id);
                var CasetaViewModel = _mapper.Map<CasetaViewModel>(caseta);

                return Ok(CasetaViewModel);


            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener caseta: {0}", ex);
            }
            return BadRequest("Fallo al obtener caseta");
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerLista([FromQuery] CasetaSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var caseta = await _repository.ObtenerCasetas(sm);
                var casetaViewModel = _mapper.Map<List<CasetaViewModel>>(caseta);

                return Ok(casetaViewModel);
          
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Caseta: {0}", ex);
                return BadRequest("Falla al obtener Caseta");
            }
        }

        [HttpGet("tabla")]
        public async Task<IActionResult> ObtenerListaTabla([FromQuery] CasetaSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var casetas = await _repository.ObtenerCasetasTabla(sm);

                return Ok(casetas);

            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener casetas: {0}", ex);
                return BadRequest("Falla al obtener casetas");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] CasetaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var claimsIdentity = User.Identity as ClaimsIdentity;
                    //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                    //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                    //if (usuarioSesion == null)
                    //    return Unauthorized();


                    var MetodoPago = await _repository.ObtenerListaGenericaAsync(model.MetodoPagoId);
                    var caseta = new Caseta
                    {
                        MetodoPago = MetodoPago,
                        Nombre = model.Nombre,
                        AliasIave = model.AliasIave,
                        Descripcion = model.Descripcion,
                        FechaAlta = DateTime.Now,
                        BActivo = true,
                        GeocercaId = model.GeocercaId,
                        ArchivoTicketAtras = model.ArchivoTicketAtras,
                        ArchivoTicketFrente = model.ArchivoTicketFrente,
                        Url = model.Url,
                        BCasetaActiva = true
                    };

                    _repository.Add(caseta);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<CasetaViewModel>(caseta));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Caseta: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Caseta: {ex.Message}");
                }
            }
            return BadRequest();
        }

        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] CasetaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    //var claimsIdentity = User.Identity as ClaimsIdentity;
                    //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                    //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                    //if (usuarioSesion == null)
                    //    return Unauthorized();

                    var caseta = await _repository.ObtenerCasetaAsync(model.Id);
                    var MetodoPago = await _repository.ObtenerListaGenericaAsync(model.MetodoPagoId);

                    caseta.MetodoPagoId = MetodoPago.Id;
                    caseta.Nombre = model.Nombre;
                    caseta.Descripcion = model.Descripcion;
                    caseta.AliasIave = model.AliasIave;
                    caseta.GeocercaId = model.GeocercaId;
                    caseta.Url = model.Url;
                    caseta.ArchivoTicketAtras = model.ArchivoTicketAtras;
                    caseta.ArchivoTicketFrente = model.ArchivoTicketFrente;


                    if (model.MetodoPagoId == 76)
                    {
                        var metodoPago = await _repository.ObtenerListaGenericaAsync(model.MetodoPagoId);

                        var camposTicketCasetaSearchModel = new CampoTicketCasetaSearchModel();
                        camposTicketCasetaSearchModel.CasetaId = model.Id;
                        var camposTicketCaseta = await _repository.ObtenerCamposTicketCaseta(camposTicketCasetaSearchModel);

                        if (metodoPago != null)
                        {
                            camposTicketCasetaSearchModel.BActivo = false;
                            //metodoPago.BActivo = false;
                        }

                        foreach (CampoTicketCaseta item in camposTicketCaseta)
                        {
                            item.BActivo = false;
                        }
                    }



                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<CasetaViewModel>(caseta));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Caseta: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Caseta: {ex.Message}");
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //var claimsIdentity = User.Identity as ClaimsIdentity;
                    //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                    //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                    //if (usuarioSesion == null)
                    //    return Unauthorized();


                    var caseta = await _repository.ObtenerCasetaAsync(id);

                    caseta.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al eliminar el caseta: {0}", ex);
                    ModelState.AddModelError("", $"Falla al eliminar el caseta: {ex.Message}");
                }
            }
            return BadRequest("Falla al eliminar la caseta.");
        }
    }
}
