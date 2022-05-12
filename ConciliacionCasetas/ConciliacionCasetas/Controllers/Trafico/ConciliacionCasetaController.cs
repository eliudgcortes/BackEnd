using AutoMapper;
using ConciliacionCasetas.ViewModels.Trafico;
using Data;
using Data.SearchModels.Trafico;
using Domain.Trafico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ConciliacionCasetas.Controllers.Trafico
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class ConciliacionCasetaController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<ConciliacionCasetaController> _logger;

        public ConciliacionCasetaController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<ConciliacionCasetaController> logger)
        {
            _repository = repository;
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }



        //[HttpGet("prueba")]
        //public async Task<IActionResult> Prueba()
        //{
        //    try
        //    {
        //        string jsonString = @"{  
        //    'FirstName':'Olivia',  
        //    'LastName':'Mason'  
        //}";
        //        return Ok(JObject.Parse(jsonString));
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Falla al obtener Conciliacion Caseta: {0}", ex);
        //    }
        //    return BadRequest("Fallo al obtener Conciliacion Caseta");
        //}

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

                var conciliacionCaseta = await _repository.ObtenerConciliacionCasetaAsync(id);
                var ConciliacionCasetaViewModel = _mapper.Map<ConciliacionCasetaViewModel>(conciliacionCaseta);

                return Ok(ConciliacionCasetaViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Conciliacion Caseta: {0}", ex);
            }
            return BadRequest("Fallo al obtener Conciliacion Caseta");
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerLista([FromQuery] ConciliacionCasetaSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var conciliacionCaseta = await _repository.ObtenerConciliacionCasetas(sm);
                var ConciliacionCasetaViewModel = _mapper.Map<List<ConciliacionCasetaViewModel>>(conciliacionCaseta);

                return Ok(ConciliacionCasetaViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener Conciliacion Caseta: {0}", ex);
                return BadRequest("Fallo al obtener Conciliacion Caseta");
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
        public async Task<IActionResult> Insertar([FromBody] ConciliacionCasetaViewModel model)
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

                    var conciliacionCaseta = new ConciliacionCaseta
                    {
                        ClaveRed = model.ClaveRed,
                        EmpresaId = model.EmpresaId,
                        FechaInicio = model.FechaInicio,
                        FechaFin = model.FechaFin,
                        BActivo = true,
                    };

                    _repository.Add(conciliacionCaseta);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<ConciliacionCasetaViewModel>(conciliacionCaseta));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al grabar Conciliacion Caseta: {0}", ex);
                    ModelState.AddModelError("", $"Falla al grabar Conciliacion Caseta: {ex.Message}");
                }
            }
            return BadRequest();
        }

        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] ConciliacionCasetaViewModel model)
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

                    var conciliacionCaseta = await _repository.ObtenerConciliacionCasetaAsync(model.Id);

                    conciliacionCaseta.ClaveRed = model.ClaveRed;
                    conciliacionCaseta.EmpresaId = model.EmpresaId;
                    conciliacionCaseta.FechaInicio = model.FechaInicio;
                    conciliacionCaseta.FechaFin = model.FechaFin;
                    conciliacionCaseta.BActivo = model.BActivo;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<ConciliacionCasetaViewModel>(conciliacionCaseta));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al actualizar Conciliacion Caseta: {0}", ex);
                    ModelState.AddModelError("", $"Falla al actualizar Conciliacion Caseta: {ex.Message}");
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

                    var conciliacionCaseta = await _repository.ObtenerConciliacionCasetaAsync(id);
                    conciliacionCaseta.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Falla al eliminar la Conciliacion Caseta: {0}", ex);
                    ModelState.AddModelError("", $"Falla al eliminar la Conciliacion Caseta: {ex.Message}");
                }
            }
            return BadRequest("Fallo al eliminar la Conciliacion Caseta.");
        }
    }
}
