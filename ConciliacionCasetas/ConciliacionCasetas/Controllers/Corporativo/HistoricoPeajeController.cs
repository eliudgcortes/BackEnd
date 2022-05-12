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
    [Route("api/HistoricoPeaje")]
    [Authorize]
    [ApiController]
    public class HistoricoPeajeController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<ListaGenericaTipoController> _logger;

        public HistoricoPeajeController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<ListaGenericaTipoController> logger)
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

                var historicoPeaje = await _repository.ObtenerHistoricoPeajeAsync(id);

                var historicoPeajeViewModel = _mapper.Map<HistoricoPeajeViewModel>(historicoPeaje);
                return Ok(historicoPeajeViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener cliente: {0}", ex);
            }
            return BadRequest("Fallo al obtener cliente");
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerHistoricoPeaje([FromQuery] HistoricoPeajeSearchModel sm)
        {
            try
            {

                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var listaGenericasTipo = await _repository.ObtenerHistoricosPeaje(sm);

                var historicoPeajeViewModel = _mapper.Map<List<HistoricoPeajeViewModel>>(listaGenericasTipo);

                return Ok(historicoPeajeViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falló en obtener listas genericas tipo: {0}", ex);
                return BadRequest("Falló en obtener listas genericas tipo");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] HistoricoPeajeViewModel model)
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


                    var historicoPeaje = new HistoricoPeaje
                    {
                        Monto = model.Monto,
                        FechaAlta = DateTime.Now,

                        BActivo = true
                    };
                    _repository.Add(historicoPeaje);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<HistoricoPeajeViewModel>(historicoPeaje));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falló en intertar lista generica tipo: {0}", ex);
                    ModelState.AddModelError("", $"Falló en intertar lista generica tipo: {ex.Message}");
                }
            }

            return BadRequest();
        }

        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] HistoricoPeajeViewModel model)
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

                    var historicoPeaje = await _repository.ObtenerHistoricoPeajeAsync(model.Id);

                    historicoPeaje.Monto = model.Monto;


                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<HistoricoPeajeViewModel>(historicoPeaje));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falló en actualizar lista generica tipo: {0}", ex);
                    ModelState.AddModelError("", $"Falló en actualizar lista generica tipo: {ex.Message}");
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

                    var historicoPeaje = await _repository.ObtenerHistoricoPeajeAsync(id);
                    historicoPeaje.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falló en borrar tipo de lista generica tipo: {0}", ex);
                    ModelState.AddModelError("", $"Falló en borrar: {ex.Message}");
                }
            }
            return BadRequest("Falló en borrar tipo de lista generica tipo.");
        }

    }
}
