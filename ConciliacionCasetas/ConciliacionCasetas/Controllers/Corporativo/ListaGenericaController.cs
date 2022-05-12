using AutoMapper;
using Data;
using Data.SearchModels;
using Domain.Catalogos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoMaestro.ViewModels;
using System.Security.Claims;

namespace ProyectoMaestro.Controllers.Catalogos
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ListaGenericaController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<ListaGenericaController> _logger;

        public ListaGenericaController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<ListaGenericaController> logger)
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


                var listaGenerica = await _repository.ObtenerListaGenericaAsync(id);
                var listaGenericaModeloVista = _mapper.Map<ListaGenericaViewModel>(listaGenerica);
                return Ok(listaGenericaModeloVista);
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get listas genericas: {0}", ex);
                return BadRequest("Failed to get listas genericas");
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerLista([FromQuery] ListaGenericaSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var listaGenericas = await _repository.ObtenerListasGenericas(sm);
                var listaGenericasModeloVista = _mapper.Map<List<ListaGenericaViewModel>>(listaGenericas);
                return Ok(listaGenericasModeloVista);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falló en obtener listas genericas : {0}", ex);
                return BadRequest("Falló en obtener listas genericas ");
            }
        }


        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] ListaGenericaViewModel model)
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


                    var listaGenericaTipo = await _repository.ObtenerListaGenericaTipoAsync(model.ListaGenericaTipoId);
                    var listaGenerica = new ListaGenerica
                    {
                        ListaGenericaTipo = listaGenericaTipo,
                        ValorString = model.ValorString,
                        ValorEntero = model.ValorEntero,
                        ValorFlotante = model.ValorFlotante,
                        NombreListaGenerica = model.NombreListaGenerica,
                        DescripcionListaGenerica = model.DescripcionListaGenerica,
                        Estatus = model.Estatus,
                        BActivo = true
                    };
                    _repository.Add(listaGenerica);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<ListaGenericaViewModel>(listaGenerica));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to post lista generica: {0}", ex);
                    ModelState.AddModelError("", $"Failed to post lista generica: {ex.Message}");
                }
            }

            return BadRequest();
        }

        [HttpPut("")]
        public async Task<IActionResult> Actualizar([FromBody] ListaGenericaViewModel model)
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

                    var listaGenerica = await _repository.ObtenerListaGenericaAsync(model.Id);
                    var listaGenericaTipo = await _repository.ObtenerListaGenericaTipoAsync(model.ListaGenericaTipoId);

                    listaGenerica.ListaGenericaTipo = listaGenericaTipo;
                    listaGenerica.ValorString = model.ValorString;
                    listaGenerica.ValorEntero = model.ValorEntero;
                    listaGenerica.ValorFlotante = model.ValorFlotante;
                    listaGenerica.NombreListaGenerica = model.NombreListaGenerica;
                    listaGenerica.DescripcionListaGenerica = model.DescripcionListaGenerica;
                    listaGenerica.Estatus = model.Estatus;
                    listaGenerica.BActivo = model.BActivo;


                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<ListaGenericaViewModel>(listaGenerica));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to update lista generica: {0}", ex);
                    ModelState.AddModelError("", $"Failed to update lista generica: {ex.Message}");
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

                    var listaGenerica = await _repository.ObtenerListaGenericaAsync(id);
                    listaGenerica.BActivo = false;

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Failed to delete lista generica: {0}", ex);
                    ModelState.AddModelError("", $"Failed to Save: {ex.Message}");
                }
            }
            return BadRequest("Failed to delete lista generica.");
        }
    }
}

