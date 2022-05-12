using System.Security.Claims;
using AutoMapper;
using Data;
using Data.SearchModels.Catalogos;
using Domain.Catalogos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoMaestro.ViewModels.Catalogos;

namespace ProyectoMaestro.Controllers.Catalogos
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PeajeController : Controller
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<PeajeController> _logger;

        public PeajeController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<PeajeController> logger)
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

                var peaje = await _repository.ObtenerPeajeAsync(id);

                var peajeViewModel = _mapper.Map<PeajeViewModel>(peaje);
                return Ok(peajeViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Peaje: {0}", ex);
            }
            return BadRequest("Fallo al obtener peaje");
        }


        [HttpGet("")]
        public async Task<IActionResult> ObtenerPeaje([FromQuery] PeajeSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var peaje = await _repository.ObtenerPeajes(sm);

                var peajeViewModel = _mapper.Map<List<PeajeViewModel>>(peaje);

                return Ok(peajeViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Peaje: {0}", ex);
                return BadRequest("Falla al obtener Peaje");
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] PeajeViewModel model)
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

                    var peaje = new Peaje
                    {
                        TipoEjeId = model.TipoEjeId,
                        CarrilId = model.CarrilId,
                        Monto = model.Monto,
                        BActivo = true
                    };

                    _repository.Add(peaje);

                    var historicoPeaje = new HistoricoPeaje
                    {
                        Peaje = peaje,
                        Monto = model.Monto,
                        FechaAlta = DateTime.Now,
                        FechaInicio = DateTime.Now
                    };

                    _repository.Add(historicoPeaje);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<PeajeViewModel>(peaje));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Peaje: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Peaje: {ex.Message}");
                }
            }
            return BadRequest();
        }


        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] PeajeViewModel model)
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

                    var peaje = await _repository.ObtenerPeajeAsync(model.Id);
                    

                    peaje.CarrilId = model.CarrilId;
                    peaje.TipoEjeId = model.TipoEjeId;
                    peaje.Monto = model.Monto;

                    var historicoPeaje = new HistoricoPeaje
                    {
                        Peaje = peaje,
                        Monto = model.Monto,
                        FechaAlta = DateTime.Now,
                        FechaInicio = DateTime.Now
                    };

                    _repository.Add(historicoPeaje);

                    var sm = new HistoricoPeajeSearchModel();
                    sm.PeajeId = peaje.Id;

                    var historicos = await _repository.ObtenerHistoricosPeaje(sm);

                    if (historicos.Count > 0)
                    {
                        var historicoAnterior = historicos.First();
                        historicoAnterior.FechaFin = historicoPeaje.FechaInicio;

                    }

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<PeajeViewModel>(peaje));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Peaje: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Peaje: {ex.Message}");
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

                    var peaje = await _repository.ObtenerPeajeAsync(id);
                    peaje.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al eliminar el peaje: {0}", ex);
                    ModelState.AddModelError("", $"Falla al eliminar peaje: {ex.Message}");
                }
            }
            return BadRequest("Falla al eliminar peaje.");
        }
    }
}
