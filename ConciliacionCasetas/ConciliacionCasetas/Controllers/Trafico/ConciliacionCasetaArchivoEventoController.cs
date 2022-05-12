using AutoMapper;
using ConciliacionCasetas.ViewModels.Trafico;
using Data;
using Data.SearchModels.Trafico;
using Domain.Trafico;
using Microsoft.AspNetCore.Mvc;

namespace ConciliacionCasetas.Controllers.Trafico
{
    //[Authorize]
    [Route("ConciliacionCasetaArchivoEvento")]
    [ApiController]
    public class ConciliacionCasetaArchivoEventoController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<ConciliacionCasetaArchivoEventoController> _logger;

        public ConciliacionCasetaArchivoEventoController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<ConciliacionCasetaArchivoEventoController> logger)
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

                var conciliacionCasetaArchivoEvento = await _repository.ObtenerConciliacionCasetaArchivoEventoAsync(id);
                var ConciliacionCasetaArchivoEventoViewModel = _mapper.Map<ConciliacionCasetaArchivoEventoViewModel>(conciliacionCasetaArchivoEvento);

                return Ok(ConciliacionCasetaArchivoEventoViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Evento: {0}", ex);
            }
            return BadRequest("Fallo al obtener Evento");
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerLista([FromQuery] ConciliacionCasetaArchivoEventoSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var conciliacionCasetaArchivoEvento = await _repository.ObtenerConciliacionCasetaArchivoEventos(sm);
                var ConciliacionCasetaArchivoEventoViewModel = _mapper.Map<List<ConciliacionCasetaArchivoEventoViewModel>>(conciliacionCasetaArchivoEvento);

                return Ok(ConciliacionCasetaArchivoEventoViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Evento: {0}", ex);
                return BadRequest("Fallo al obtener Evento");
            }
        }

        //[HttpGet("tabla")]
        //public async Task<IActionResult> ObtenerListaTabla([FromQuery] ArchivoIaveSearchModel sm)
        //{
        //    try
        //    {
        //        //var claimsIdentity = User.Identity as ClaimsIdentity;
        //        //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
        //        //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
        //        //if (usuarioSesion == null)
        //        //    return Unauthorized();

        //        var archivosIave = await _repository.ObtenerArchivosIaveTabla(sm);

        //        return Ok(archivosIave);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Falla al obtener Evento Iave: {0}", ex);
        //        return BadRequest("Fallo al obtener Evento Iave");
        //    }
        //}

        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] List<ConciliacionCasetaArchivoEventoViewModel> model)
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

                    foreach (var item in model)
                    {
                        var conciliacionCasetaArchivoEvento = new ConciliacionCasetaArchivoEvento
                        {
                            ClaveRed = item.ClaveRed,
                            ClaveFideicomiso = item.ClaveFideicomiso,
                            NumeroPeriodo = item.NumeroPeriodo,
                            TipoPeriodo = item.TipoPeriodo,
                            ClaveEmpresa = item.ClaveEmpresa,
                            TarjetaIDMX = item.TarjetaIDMX,
                            NumeroEconomico = item.NumeroEconomico,
                            FechaCruce = DateTime.Now,
                            HoraCruce = DateTime.Now,
                            Clase = item.Clase,
                            NombreCaseta = item.NombreCaseta,
                            NombreCarril = item.NombreCarril,
                            ImporteAl100 = item.ImporteAl100,
                            ImporteFacturado = item.ImporteFacturado,
                            NumeroPlaza = item.NumeroPlaza,
                            ControlInternoProveedor1 = item.ControlInternoProveedor1,
                            ControlInternoProveedor2 = item.ControlInternoProveedor2,
                            ControlInternoProveedor3 = item.ControlInternoProveedor3,
                            ControlInternoProveedor4 = item.ControlInternoProveedor4,
                            NumeroCargaBanco = item.NumeroCargaBanco,
                            FechaCargoBanco = DateTime.Now,
                            BActivo = true,
                        };
                        _repository.Add(conciliacionCasetaArchivoEvento);
                    }

                    //if (await _repository.SaveAllAsync())
                    //{
                    //    return Ok(_mapper.Map<ConciliacionCasetaArchivoEventoViewModel>(conciliacionCasetaArchivoEvento));
                    //}
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Evento: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Evento: {ex.Message}");
                }
            }
            return BadRequest();
        }

        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] ConciliacionCasetaArchivoEventoViewModel model)
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

                    //var conciliacionCasetaArchivoEvento = await _repository.ObtenerConciliacionCasetaArchivoEventoAsync(model.Id);

                    //conciliacionCasetaArchivoEvento.FechaCruce = model.FechaCruce;
                    ////conciliacionCasetaArchivoEvento.EstatusCruce = model.EstatusCruce;
                    //conciliacionCasetaArchivoEvento.NumeroEconomico = model.NumeroEconomico;
                    //conciliacionCasetaArchivoEvento.BActivo = model.BActivo;

                    //if (await _repository.SaveAllAsync())
                    //{
                    //    return Ok(_mapper.Map<ConciliacionCasetaArchivoEventoViewModel>(conciliacionCasetaArchivoEvento));
                    //}
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Evento: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Evento: {ex.Message}");
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

                    var conciliacionCasetaArchivoEvento = await _repository.ObtenerConciliacionCasetaArchivoEventoAsync(id);
                    conciliacionCasetaArchivoEvento.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al eliminar el Evento: {0}", ex);
                    ModelState.AddModelError("", $"Falla al eliminar el Evento: {ex.Message}");
                }
            }
            return BadRequest("Fallo al eliminar Evento.");
        }
    }
}
