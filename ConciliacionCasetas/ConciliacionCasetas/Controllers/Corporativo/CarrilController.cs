using AutoMapper;
using Data;
using Data.SearchModels.Catalogos;
using Domain;
using Domain.Catalogos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoMaestro.ViewModels;
using ProyectoMaestro.ViewModels.Catalogos;
using System.Security.Claims;

namespace ProyectoMaestro.Controllers.Catalogos
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CarrilController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<CarrilController> _logger;

        public CarrilController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<CarrilController> logger)
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

                var carril = await _repository.ObtenerCarrilAsync(id);

                var carrilViewModel = _mapper.Map<CarrilViewModel>(carril);
                return Ok(carrilViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener carril: {0}", ex);
            }
            return BadRequest("Fallo al obtener carril");
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerLista([FromQuery] CarrilSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();


                var carril = await _repository.ObtenerCarriles(sm);

                var carrilViewModel = _mapper.Map<List<CarrilViewModel>>(carril);

                return Ok(carrilViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Carril: {0}", ex);
                return BadRequest("Falla al obtener Carril");
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] CarrilViewModel model)
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

                    var carril = new Carril
                    {
                        Nombre = model.Nombre,
                        AliasIave = model.AliasIave,
                        Descripcion = model.Descripcion,
                        FechaAlta = model.FechaAlta,
                        CasetaId = model.CasetaId,
                        BActivo = true
                    };

                    _repository.Add(carril);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<CarrilViewModel>(carril));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Carril: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Carril: {ex.Message}");


                }
            }

            return BadRequest();
        }

        [HttpPost("clonarCarril")]
        public async Task<IActionResult> CarrilDuplicadoPorId([FromBody]int id)
        {
            try
            {
                var carril = await _repository.ObtenerCarrilAsync(id);

                var duplicarCarril = new Carril
                {
                    Nombre = carril.Nombre,
                    AliasIave = carril.AliasIave,
                    Descripcion = carril.Descripcion,
                    FechaAlta = carril.FechaAlta,
                    CasetaId = carril.CasetaId,
                    BActivo = true
                };

                _repository.Add(duplicarCarril);

                foreach (Peaje item in carril.Peajes)
                {
                    var duplicarPeajes = new Peaje
                    {
                        Carril = duplicarCarril,
                        Monto = item.Monto,
                        TipoEje = item.TipoEje,
                        FechaAlta = item.FechaAlta,
                        BActivo = true
                    };

                    _repository.Add(duplicarPeajes);

                    var historico = new HistoricoPeaje
                    {
                        Peaje = duplicarPeajes,
                        Monto = duplicarPeajes.Monto,
                        FechaAlta = duplicarPeajes.FechaAlta,
                        FechaInicio= DateTime.Now,
                        BActivo = true
                    };
                    _repository.Add(historico);

                }
                if (await _repository.SaveAllAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener carril: {0}", ex);
            }
            return BadRequest("Fallo al obtener carril");
        }

        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] CarrilViewModel model)
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

                    var carril = await _repository.ObtenerCarrilAsync(model.Id);

                    carril.Nombre = model.Nombre;
                    carril.Descripcion = model.Descripcion;
                    carril.AliasIave = model.AliasIave;
                    carril.BActivo = model.BActivo; 


                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<CarrilViewModel>(carril));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Carril: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Carril: {ex.Message}");
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

                    var carril = await _repository.ObtenerCarrilAsync(id);

                    carril.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al eliminar el Carril: {0}", ex);
                    ModelState.AddModelError("", $"Falla al eliminar el Carril: {ex.Message}");
                }
            }
            return BadRequest("Falla al eliminar el Carril.");
        }
    }
}
