using AutoMapper;
using Data;
using Data.SearchModels.Catalogos;
using Domain.Catalogos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoMaestro.ViewModels;
using System.Security.Claims;

namespace ProyectoMaestro.Controllers.Catalogos
{
    [Route("api/ListaGenericaTipo")]
    [Authorize]
    [ApiController]
    public class ListaGenericaTipoController : ControllerBase
    {
        private readonly IConciliacionCasetasRepository _repository;
        private readonly IMapper _mapper;
        private ILogger<ListaGenericaTipoController> _logger;

        public ListaGenericaTipoController(IMapper mapper, IConciliacionCasetasRepository repository, ILogger<ListaGenericaTipoController> logger)
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

                var listaGenericaTipo = await _repository.ObtenerListaGenericaTipoAsync(id);

                var listaGenericaTipoViewModel = _mapper.Map<ListaGenericaTipoViewModel>(listaGenericaTipo);
                return Ok(listaGenericaTipoViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falla al obtener cliente: {0}", ex);
            }
            return BadRequest("Fallo al obtener cliente");
        }

        [HttpGet("")]
        public async Task<IActionResult> ObtenerListaGenericaTipo([FromQuery] ListaGenericaTipoSearchModel sm)
        {
            try
            {
                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();


                var listaGenericasTipo = await _repository.ObtenerListasGenericasTipo(sm);
                var listaGenericasTipoModeloVista = _mapper.Map<List<ListaGenericaTipoViewModel>>(listaGenericasTipo);

                return Ok(listaGenericasTipoModeloVista);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falló en obtener listas genericas tipo: {0}", ex);
                return BadRequest("Falló en obtener listas genericas tipo");
            }
        }


        [HttpGet("tabla")]
        public async Task<IActionResult> ObtenerListaTabla([FromQuery] ListaGenericaTipoSearchModel sm)
        {
            try
            {

                //var claimsIdentity = User.Identity as ClaimsIdentity;
                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
                //var usuarioSesion = await _repository.ObtenerUsuario360NoTracking(claimid.Value);
                //if (usuarioSesion == null)
                //    return Unauthorized();

                var ListaGenericaTipo = await _repository.ObtenerListaGenericaTipoTabla(sm);
                return Ok(ListaGenericaTipo);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falló en obtener lista generica tipo: {0}", ex);
            }
            return BadRequest("Falló en obtener lista generica tipo");
        }



        [HttpPost("")]
        public async Task<IActionResult> Insertar([FromBody] ListaGenericaTipoViewModel model)
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

                    var listaGenericaTipo = new ListaGenericaTipo
                    {
                        Nombre = model.Nombre,
                        Descripcion = model.Descripcion,
                        BActivo = true
                    };
                    _repository.Add(listaGenericaTipo);

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<ListaGenericaTipoViewModel>(listaGenericaTipo));
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
        public async Task<IActionResult> Actualizar([FromBody] ListaGenericaTipoViewModel model)
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

                    var listaGenericaTipo = await _repository.ObtenerListaGenericaTipoAsync(model.Id);

                    listaGenericaTipo.Nombre = model.Nombre;
                    listaGenericaTipo.Descripcion = model.Descripcion;
                   

                    if (await _repository.SaveAllAsync())
                    {
                        return Ok(_mapper.Map<ListaGenericaTipoViewModel>(listaGenericaTipo));
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

                    var listaGenericaTipo = await _repository.ObtenerListaGenericaTipoAsync(id);
                    listaGenericaTipo.BActivo = false;

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
