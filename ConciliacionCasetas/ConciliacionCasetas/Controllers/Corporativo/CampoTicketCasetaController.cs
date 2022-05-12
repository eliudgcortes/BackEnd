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
    [Route("api/[controller]")]
    [ApiController]
    public class CampoTicketCasetaController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<CampoTicketCasetaController> _logger;

        public CampoTicketCasetaController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<CampoTicketCasetaController> logger)
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

                var campoTicketCaseta = await _repository.ObtenerListaGenericaTipoAsync(id);
                var campoTicketCasetaViewModel = _mapper.Map<CampoTicketCasetaViewModel>(campoTicketCaseta);
                return Ok(campoTicketCasetaViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener campo ticket caseta: {0}", ex);
            }
            return BadRequest("Fallo al obtener campo ticket caseta");
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerCampoTicketCaseta([FromQuery] CampoTicketCasetaSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var campoTicketCaseta = await _repository.ObtenerCamposTicketCaseta(sm);
                var campoTicketCasetaViewModel = _mapper.Map<List<CampoTicketCasetaViewModel>>(campoTicketCaseta);

                return Ok(campoTicketCasetaViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falló en obtener campo ticket caseta: {0}", ex);
                return BadRequest("Falló en obtener campo ticket caseta");
            }
        }

        [HttpGet("tabla")]
        public async Task<IActionResult> ObtenerCamposTicketCasetaTabla([FromQuery] CampoTicketCasetaSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var camposTicketCasetas = await _repository.ObtenerCamposTicketCasetaTabla(sm);

                return Ok(camposTicketCasetas);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener casetas: {0}", ex);
                return BadRequest("Falla al obtener casetas");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] CampoTicketCasetaViewModel model)
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

                    var TipoDato = await _repository.ObtenerListaGenericaAsync(model.TipoDatoId);
                    var campoTicketCaseta = new CampoTicketCaseta
                    {
                        TipoDato = TipoDato,
                        Nombre = model.Nombre,
                        Descripcion = model.Descripcion,
                        CasetaId = model.CasetaId,
                        FechaAlta = DateTime.Now,
                        BActivo = true
                    };
                    _repository.Add(campoTicketCaseta);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<CampoTicketCasetaViewModel>(campoTicketCaseta));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falló en intertar campo ticket caseta: {0}", ex);
                    ModelState.AddModelError("", $"Falló en intertar campo ticket caseta: {ex.Message}");
                }
            }

            return BadRequest();
        }

        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] CampoTicketCasetaViewModel model)
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

                    var TipoDato = await _repository.ObtenerListaGenericaAsync(model.TipoDatoId);
                    var campoTicketCaseta = await _repository.ObtenerCampoTicketCasetaAsync(model.Id);

                    campoTicketCaseta.TipoDatoId = TipoDato.Id;
                    campoTicketCaseta.Nombre = model.Nombre;
                    campoTicketCaseta.Descripcion = model.Descripcion;


                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<CampoTicketCasetaViewModel>(campoTicketCaseta));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falló en actualizar campo ticket caseta: {0}", ex);
                    ModelState.AddModelError("", $"Falló en actualizar campo ticket caseta: {ex.Message}");
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

                    var campoTicketCaseta = await _repository.ObtenerCampoTicketCasetaAsync(id);
                    campoTicketCaseta.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falló en borrar campo ticket caseta: {0}", ex);
                    ModelState.AddModelError("", $"Falló en borrar: {ex.Message}");
                }
            }
            return BadRequest("Falló en borrar campo ticket caseta.");
        }
    }

}

