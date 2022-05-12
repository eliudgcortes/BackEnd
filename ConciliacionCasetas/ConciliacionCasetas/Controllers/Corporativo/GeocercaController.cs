using AutoMapper;
using Data;
using Data.SearchModels.Catalogos;
using Domain.Catalogos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoMaestro.ViewModels.Catalogos;
using System.Security.Claims;

namespace ProyectoMaestro.Controllers.Catalogos
{
    [Authorize]
    [Route("api/Geocerca")]
    [ApiController]
    public class GeocercaController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<GeocercaController> _logger;

        public GeocercaController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<GeocercaController> logger)
        {
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

                var Geocerca = await _repository.ObtenerGeocercaAsync(id);
                var GeocercaModeloVista = _mapper.Map<GeocercaViewModel>(Geocerca);
                return Ok(GeocercaModeloVista);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get Geocerca: {0}", ex);
                return BadRequest("Failed to get Geocerca");
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerLista([FromQuery] GeocercaSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var Geocerca = await _repository.ObtenerGeocercas(sm);
                var GeocercaModeloVista = _mapper.Map<List<GeocercaViewModel>>(Geocerca);


                return Ok(GeocercaModeloVista);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falló en obtener Geocerca: {0}", ex);
                return BadRequest("Falló en obtener Geocerca ");
            }
        }

        [HttpGet("sinAzureDireccion")]
        public async Task<IActionResult> ObtenerListaSinAzureDireccion()
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var geocercas = await _repository.ObtenerGeocercasSinAzureDireccion();
                return Ok(_mapper.Map<List<GeocercaViewModel>>(geocercas));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get geocercas: {0}", ex);
                return BadRequest("Failed to get geocercas");
            }
        }

        [HttpGet("tabla")]
        public async Task<IActionResult> ObtenerTabla([FromQuery] GeocercaSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();


                var Geocercas = await _repository.ObtenerGeocercaTabla(sm);
                return Ok(Geocercas);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falló en obtener Geocerca: {0}", ex);
                return BadRequest("Falló en obtener Geocerca");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] GeocercaViewModel model)
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


                    var Geocerca = new Geocerca
                    {
                        Nombre = model.Nombre,
                        Descripcion = model.Descripcion,
                        BActivo = true
                    };
                    _repository.Add(Geocerca);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<GeocercaViewModel>(Geocerca));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to post  Geocerca: {0}", ex);
                    ModelState.AddModelError("", $"Failed to post  Geocerca: {ex.Message}");
                }
            }

            return BadRequest();
        }


        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] GeocercaViewModel model)
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


                    var Geocerca = await _repository.ObtenerGeocercaAsync(model.Id);
            
                    Geocerca.Nombre = model.Nombre;
                    Geocerca.Descripcion = model.Descripcion;
                   
                    //Geocerca.TipoGeocerca = model.TipoGeocerca;
                    Geocerca.BActivo = model.BActivo;


                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<GeocercaViewModel>(Geocerca));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to update  Geocerca: {0}", ex);
                    ModelState.AddModelError("", $"Failed to update  Geocerca: {ex.Message}");
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


                    var Geocerca = await _repository.ObtenerGeocercaAsync(id);
                    Geocerca.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to delete  Geocercaa: {0}", ex);
                    ModelState.AddModelError("", $"Failed to Save: {ex.Message}");
                }
            }
            return BadRequest("Failed to delete Geocerca.");
        }

        [HttpPut("direccion-geocercas")]
        public async Task<IActionResult> Actualizar([FromBody] GeocercaViewModel[] model)
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

                    foreach (var x in model)
                    {
                        var geocerca = await _repository.ObtenerGeocercaAsync(x.Id);
                        geocerca.Descripcion = x.Descripcion;
                        geocerca.BDireccionAzure = true;
                    }

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to update geocercas: {0}", ex);
                    ModelState.AddModelError("", $"Failed to update geocercas: {ex.Message}");
                }
            }

            return BadRequest();
        }
    }
}




