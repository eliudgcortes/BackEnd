using AutoMapper;
using ConciliacionCasetas.ViewModels.Trafico;
using Data;
using Data.SearchModels.Trafico;
using Domain.Trafico;
using Microsoft.AspNetCore.Mvc;

namespace ConciliacionCasetas.Controllers.Trafico
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class ConciliacionCasetaArchivoController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<ConciliacionCasetaArchivoController> _logger;

        public ConciliacionCasetaArchivoController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<ConciliacionCasetaArchivoController> logger)
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

                var conciliacionCasetaArchivo = await _repository.ObtenerConciliacionCasetaArchivoAsync(id);
                var ConciliacionCasetaArchivoViewModel = _mapper.Map<ConciliacionCasetaArchivoViewModel>(conciliacionCasetaArchivo);

                return Ok(ConciliacionCasetaArchivoViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Archivo: {0}", ex);
            }
            return BadRequest("Fallo al obtener Archivo");
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerLista([FromQuery] ConciliacionCasetaArchivoSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var conciliacionCasetaArchivo = await _repository.ObtenerConciliacionCasetaArchivos(sm);
                var ConciliacionCasetaArchivoViewModel = _mapper.Map<List<ConciliacionCasetaArchivoViewModel>>(conciliacionCasetaArchivo);

                return Ok(ConciliacionCasetaArchivoViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Archivo: {0}", ex);
                return BadRequest("Fallo al obtener Archivo");
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
        //        _logger.LogError("Falla al obtener Archivo Iave: {0}", ex);
        //        return BadRequest("Fallo al obtener Archivo Iave");
        //    }
        //}

        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] ConciliacionCasetaArchivoViewModel model)
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

                    var conciliacionCaseta = await _repository.ObtenerConciliacionCasetaAsync(model.ConciliacionCasetaId);
                    var conciliacionCasetaArchivo = new ConciliacionCasetaArchivo
                    {
                        ConciliacionCaseta = conciliacionCaseta,
                        ExcelArchivo = model.ExcelArchivo,
                        EstatusArchivo = model.EstatusArchivo,
                        FechaAlta = DateTime.Now,
                        FechaInicio = DateTime.Now,
                        FechaFin = DateTime.Now,
                        Extension = model.Extension,
                        Url = model.Url,
                        BActivo = true,
                    };

                    _repository.Add(conciliacionCasetaArchivo);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<ConciliacionCasetaArchivoViewModel>(conciliacionCasetaArchivo));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Archivo: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Archivo: {ex.Message}");
                }
            }
            return BadRequest();
        }

        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] ConciliacionCasetaArchivoViewModel model)
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

                    var conciliacionCasetaArchivo = await _repository.ObtenerConciliacionCasetaArchivoAsync(model.Id);

                    //conciliacionCasetaArchivo.Nombre = model.Nombre;
                    //conciliacionCasetaArchivo.Descripcion = model.Descripcion;
                    conciliacionCasetaArchivo.BActivo = model.BActivo;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<ConciliacionCasetaArchivoViewModel>(conciliacionCasetaArchivo));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Archivo: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Archivo: {ex.Message}");
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

                    var conciliacionCasetaArchivo = await _repository.ObtenerConciliacionCasetaArchivoAsync(id);
                    conciliacionCasetaArchivo.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al eliminar el Archivo: {0}", ex);
                    ModelState.AddModelError("", $"Falla al eliminar el Archivo: {ex.Message}");
                }
            }
            return BadRequest("Fallo al eliminar Archivo.");
        }
    }
}
