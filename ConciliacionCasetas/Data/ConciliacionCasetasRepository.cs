using Data.SearchModels;
using Data.SearchModels.Catalogos;
using Data.SearchModels.Trafico;
using Data.TableModels;
using Data.TableModels.Catalogos;
using Domain;
using Domain.Catalogos;
using Domain.Trafico;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ConciliacionCasetasRepository : IConciliacionCasetasRepository
    {
        private ConciliacionCasetasContext _context;

        #region Generics Definition

        public ConciliacionCasetasRepository(ConciliacionCasetasContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        #endregion Generics Definition

        #region Caseta

        public async Task<List<CasetaTableModel>> ObtenerCasetasTabla(CasetaSearchModel mb)
        {
            return await _context.Caseta
                
                .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
                .Where(s => s.Descripcion.ToUpper().Contains(mb.Descripcion.ToUpper()) || string.IsNullOrEmpty(mb.Descripcion))
                .Where(s => (s.FechaAlta.Date >= mb.FechaInicio.Date) || (mb.FechaInicio.Date == new DateTime()))
                .Where(s => (s.FechaAlta.Date <= mb.FechaFin.Date) || (mb.FechaFin.Date == new DateTime()))
                .Where(s => s.BActivo == true)
                .Select(x => new CasetaTableModel
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
            

                })
                .ToListAsync();
        }

        public async Task<List<Caseta>> ObtenerCasetas(CasetaSearchModel sm)
        {
            return await _context.Caseta
                .Include(x => x.MetodoPago)
                .Where(s => s.Nombre.ToUpper().Contains(sm.Nombre.ToUpper()) || string.IsNullOrEmpty(sm.Nombre))
                .Where(s => s.Descripcion.ToUpper().Contains(sm.Descripcion.ToUpper()) || string.IsNullOrEmpty(sm.Descripcion))
                .Where(s => s.BActivo == true)
                .Where(s => s.MetodoPago.Id == sm.MetodoPagoId || sm.MetodoPagoId == 0)

                .Where(s => s.BCasetaActiva == true)
                .ToListAsync();
        }

        public async Task<Caseta> ObtenerCasetaAsync(int Id)
        {
            return await _context.Caseta
                .Include(x => x.Geocerca)
                .Include(x => x.MetodoPago)
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }

        #endregion

        #region CampoTicketCaseta
        public async Task<List<CampoTicketCaseta>> ObtenerCamposTicketCaseta(CampoTicketCasetaSearchModel sm)
        {
            return await _context.CampoTicketCaseta
                .Include(x => x.Caseta)
                .Include(x => x.TipoDato)
                .Where(s => s.Nombre.ToUpper().Contains(sm.Nombre.ToUpper()) || string.IsNullOrEmpty(sm.Nombre))
                .Where(s => s.Descripcion.ToUpper().Contains(sm.Descripcion.ToUpper()) || string.IsNullOrEmpty(sm.Descripcion))
                .Where(s => s.Caseta.Id == sm.CasetaId || sm.CasetaId == 0)
                .Where(s => s.TipoDato.Id == sm.TipoDatoId || sm.TipoDatoId == 0)
                .Where(s => s.BActivo == true)
                .ToListAsync();
        }

        public async Task<List<CampoTicketCaseta>> ObtenerCamposTicketCasetaTabla(CampoTicketCasetaSearchModel sm)
        {
            return await _context.CampoTicketCaseta
                .Where(s => s.Nombre.ToUpper().Contains(sm.Nombre.ToUpper()) || string.IsNullOrEmpty(sm.Nombre))
                .Where(s => s.Descripcion.ToUpper().Contains(sm.Descripcion.ToUpper()) || string.IsNullOrEmpty(sm.Descripcion))
                .Where(s => s.Caseta.Id == sm.CasetaId || sm.CasetaId == 0)
                .Where(s => s.TipoDato.Id == sm.TipoDatoId || sm.TipoDatoId == 0)
                .Where(s => s.BActivo == true)
                .ToListAsync();
        }

            public async Task<CampoTicketCaseta> ObtenerCampoTicketCasetaAsync(int Id)
        {
            return await _context.CampoTicketCaseta
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }

        #endregion

        public class RespuestaBd
        {
            #region Atributo
            public int IntError { get; set; }
            public int IntIdRespuesta { get; set; }
            public string Mensaje { get; set; }
            public Boolean BValido { get; set; }
            public string StrJsonRespuesta { get; set; }
            #endregion

            #region GetSet
            #endregion

            #region constructor
            public RespuestaBd() { }
            #endregion
        }

        #region Carril

        //public async Task<List<CasetaTableModel>> ObtenerCasetasTabla(CasetaSearchModel mb)
        //{
        //    return await _context.Caseta
        //        .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
        //        .Where(s => (s.FechaAlta.Date >= mb.FechaInicio.Date) || (mb.FechaInicio.Date == new DateTime()))
        //        .Where(s => (s.FechaAlta.Date <= mb.FechaFin.Date) || (mb.FechaFin.Date == new DateTime()))
        //        .Where(s => s.BActivo == true)
        //        .Select(x => new CasetaTableModel
        //        {
        //            Id = x.Id,
        //            Nombre = x.Nombre,


        //        })
        //        .ToListAsync();
        //}

        public async Task<List<Carril>> ObtenerCarriles(CarrilSearchModel sm)
        {
            return await _context.Carril
                .Include(x => x.Peajes).ThenInclude(x => x.TipoEje)
                .Include(x => x.Peajes)
                .Where(s => s.CasetaId == sm.CasetaId || sm.CasetaId == 0)
                .Where(s => s.Nombre.ToUpper().Contains(sm.Nombre.ToUpper()) || string.IsNullOrEmpty(sm.Nombre))
                .Where(s => s.AliasIave.ToUpper().Contains(sm.AliasIave.ToUpper()) || string.IsNullOrEmpty(sm.AliasIave))
                .Where(s => s.BActivo == true)
                .ToListAsync();
        }

        public async Task<Carril> ObtenerCarrilAsync(int Id)
        {
            return await _context.Carril
                .Include(x => x.Peajes).ThenInclude(x => x.TipoEje)
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }

        #endregion

        #region Peaje
        public async Task<List<Peaje>> ObtenerPeajes(PeajeSearchModel sm)
        {
            return await _context.Peaje
                .Where(s => (s.FechaAlta.Date >= sm.FechaInicio.Date) || (sm.FechaInicio.Date == new DateTime()))
                .Where(s => (s.FechaAlta.Date <= sm.FechaFin.Date) || (sm.FechaFin.Date == new DateTime()))
                .Where(s => s.BActivo == true)
                .ToListAsync();
        }

        public async Task<Peaje> ObtenerPeajeAsync(int Id)
        {
            return await _context.Peaje
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }
        #endregion Peaje

        #region HistoricoPeaje
        public async Task<List<HistoricoPeaje>> ObtenerHistoricosPeaje(HistoricoPeajeSearchModel sm)
        {
            return await _context.HistoricoPeaje
                .Where(s => s.Peaje.Id == sm.PeajeId || sm.PeajeId == 0)
                .Where(s => (s.FechaAlta.Date >= sm.FechaInicio.Date) || (sm.FechaInicio.Date == new DateTime()))
                .Where(s => (s.FechaAlta.Date <= sm.FechaFin.Date) || (sm.FechaFin.Date == new DateTime()))
                .Where(s => s.BActivo == true)
                .OrderByDescending(s => s.Id)
                .ToListAsync();
        }

        public async Task<HistoricoPeaje> ObtenerHistoricoPeajeAsync(int Id)
        {
            return await _context.HistoricoPeaje
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }
        #endregion HistoricoPeaje

        #region Geocerca
        public async Task<List<Geocerca>> ObtenerGeocercas(GeocercaSearchModel mb)
        {
            return await _context.Geocerca
                  .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
                  .Where(s => s.BActivo == true)
                   .ToListAsync();
        }

        public async Task<List<Geocerca>> ObtenerGeocercasSinAzureDireccion()
        {
            return await _context.Geocerca
                   .Where(s => s.BDireccionAzure != true)
                   .Where(s => s.BActivo == true)
                   .Take(30)
                   .ToListAsync();
        }

        public async Task<Geocerca> ObtenerGeocercaAsync(int Id)
        {
            return await _context.Geocerca
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }
        public async Task<List<GeocercaTableModel>> ObtenerGeocercaTabla(GeocercaSearchModel sm)
        {
            return await _context.Geocerca
                  .Where(s => s.Nombre.ToUpper().Contains(sm.Nombre.ToUpper()) || string.IsNullOrEmpty(sm.Nombre))
                  .Where(s => s.BActivo == true)
                  .Take(sm.NumeroElementos)
                  .Select(s => new GeocercaTableModel
                  {
                      Id = s.Id,
                      Nombre = s.Nombre,
                      Descripcion = s.Descripcion,

                  })
                  .ToListAsync();
        }
        #endregion Geocerca

        #region ListaGenerica

        public async Task<List<ListaGenerica>> ObtenerListasGenericas(ListaGenericaSearchModel mb)
        {
            return await _context.ListaGenerica
                    .Include(x => x.ListaGenericaTipo)
                   .Where(s => s.ListaGenericaTipo.Id == mb.ListaGenericaTipoId || mb.ListaGenericaTipoId == 0)
                   .Where(s => s.BActivo == mb.BActivo)
                   .OrderBy(s => s.NombreListaGenerica)
                   .ToListAsync();
        }

        public async Task<ListaGenerica> ObtenerListaGenericaAsync(int Id)
        {
            return await _context.ListaGenerica
            .Where(s => s.Id == Id)
            .FirstOrDefaultAsync();

        }

        #endregion ListaGenerica

        #region ListaGenericaTipo

        public async Task<List<ListaGenericaTipo>> ObtenerListaGenericaTipoTabla(ListaGenericaTipoSearchModel mb)
        {
            return await _context.ListaGenericaTipo
                .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
                .Where(s => s.BActivo == true)

                .ToListAsync();
        }


        public async Task<List<ListaGenericaTipo>> ObtenerListasGenericasTipo(ListaGenericaTipoSearchModel mb)
        {
            return await _context.ListaGenericaTipo
                .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
                .Where(s => s.Descripcion.ToUpper().Contains(mb.Descripcion.ToUpper()) || string.IsNullOrEmpty(mb.Descripcion))
                .Where(s => s.BActivo == true)
                .ToListAsync();
        }

        public async Task<ListaGenericaTipo> ObtenerListaGenericaTipoAsync(int Id)
        {
            return await _context.ListaGenericaTipo
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }


        #endregion ListaGenericaTipo

        #region ConciliacionCaseta

        //public async Task<List<ArchivoIaveTableModel>> ObtenerArchivosIaveTabla(ArchivoIaveSearchModel mb)
        //{
        //    return await _context.ArchivoIave

        //        .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
        //        .Where(s => s.Descripcion.ToUpper().Contains(mb.Descripcion.ToUpper()) || string.IsNullOrEmpty(mb.Descripcion))
        //        .Where(s => (s.FechaAlta.Date >= mb.FechaInicio.Date) || (mb.FechaInicio.Date == new DateTime()))
        //        .Where(s => (s.FechaAlta.Date <= mb.FechaFin.Date) || (mb.FechaFin.Date == new DateTime()))
        //        .Where(s => s.BActivo == true)
        //        .Select(x => new ArchivoIaveTableModel
        //        {
        //            Id = x.Id,
        //            Nombre = x.Nombre,
        //        })
        //        .ToListAsync();
        //}

        public async Task<List<ConciliacionCaseta>> ObtenerConciliacionCasetas(ConciliacionCasetaSearchModel sm)
        {
            return await _context.ConciliacionCaseta
                .Include(s => s.Empresa)                
                .Where(s => s.ClaveRed == sm.ClaveRed || sm.ClaveRed == 0)
                .Where(s => s.Empresa.Id == sm.EmpresaId || sm.EmpresaId == 0)
                .Where(s => (s.FechaInicio.Date >= sm.FechaInicio.Date) || (sm.FechaInicio.Date == new DateTime()))
                .Where(s => (s.FechaFin.Date <= sm.FechaFin.Date) || (sm.FechaFin.Date == new DateTime()))
                .Where(s => s.BActivo == true)

                .ToListAsync();
        }

        public async Task<ConciliacionCaseta> ObtenerConciliacionCasetaAsync(int Id)
        {
            return await _context.ConciliacionCaseta
                .Include(s => s.Empresa)
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region ConciliacionCasetaArchivo

        //public async Task<List<ArchivoIaveTableModel>> ObtenerArchivosIaveTabla(ArchivoIaveSearchModel mb)
        //{
        //    return await _context.ArchivoIave

        //        .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
        //        .Where(s => s.Descripcion.ToUpper().Contains(mb.Descripcion.ToUpper()) || string.IsNullOrEmpty(mb.Descripcion))
        //        .Where(s => (s.FechaAlta.Date >= mb.FechaInicio.Date) || (mb.FechaInicio.Date == new DateTime()))
        //        .Where(s => (s.FechaAlta.Date <= mb.FechaFin.Date) || (mb.FechaFin.Date == new DateTime()))
        //        .Where(s => s.BActivo == true)
        //        .Select(x => new ArchivoIaveTableModel
        //        {
        //            Id = x.Id,
        //            Nombre = x.Nombre,
        //        })
        //        .ToListAsync();
        //}

        public async Task<List<ConciliacionCasetaArchivo>> ObtenerConciliacionCasetaArchivos(ConciliacionCasetaArchivoSearchModel sm)
        {
            return await _context.ConciliacionCasetaArchivo

                //.Where(s => (s.FechaAlta.Date <= sm.FechaAlta.Date) || (sm.FechaAlta.Date == new DateTime()))
                //.Where(s => (s.FechaInicio.Date >= sm.FechaInicio.Date) || (sm.FechaInicio.Date == new DateTime()))
                //.Where(s => (s.FechaFin.Date <= sm.FechaFin.Date) || (sm.FechaFin.Date == new DateTime()))
                .Where(s => s.BActivo == true)

                .ToListAsync();
        }

        public async Task<ConciliacionCasetaArchivo> ObtenerConciliacionCasetaArchivoAsync(int Id)
        {
            return await _context.ConciliacionCasetaArchivo
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region ConciliacionCasetaArchivoEvento

        //public async Task<List<ArchivoIaveTableModel>> ObtenerArchivosIaveTabla(ArchivoIaveSearchModel mb)
        //{
        //    return await _context.ArchivoIave

        //        .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
        //        .Where(s => s.Descripcion.ToUpper().Contains(mb.Descripcion.ToUpper()) || string.IsNullOrEmpty(mb.Descripcion))
        //        .Where(s => (s.FechaAlta.Date >= mb.FechaInicio.Date) || (mb.FechaInicio.Date == new DateTime()))
        //        .Where(s => (s.FechaAlta.Date <= mb.FechaFin.Date) || (mb.FechaFin.Date == new DateTime()))
        //        .Where(s => s.BActivo == true)
        //        .Select(x => new ArchivoIaveTableModel
        //        {
        //            Id = x.Id,
        //            Nombre = x.Nombre,
        //        })
        //        .ToListAsync();
        //}

        public async Task<List<ConciliacionCasetaArchivoEvento>> ObtenerConciliacionCasetaArchivoEventos(ConciliacionCasetaArchivoEventoSearchModel sm)
        {
            return await _context.ConciliacionCasetaArchivoEvento
                //.Where(s => s.Nombre.ToUpper().Contains(sm.Nombre.ToUpper()) || string.IsNullOrEmpty(sm.Nombre))
                .Where(s => s.Descripcion.ToUpper().Contains(sm.Descripcion.ToUpper()) || string.IsNullOrEmpty(sm.Descripcion))
                .Where(s => s.ClaveEmpresa.ToUpper().Contains(sm.ClaveEmpresa.ToUpper()) || string.IsNullOrEmpty(sm.ClaveEmpresa))
                .Where(s => s.BActivo == true)

                .ToListAsync();
        }

        public async Task<ConciliacionCasetaArchivoEvento> ObtenerConciliacionCasetaArchivoEventoAsync(int Id)
        {
            return await _context.ConciliacionCasetaArchivoEvento
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }
        #endregion

        #region Empresa

        //public async Task<List<ArchivoIaveTableModel>> ObtenerArchivosIaveTabla(ArchivoIaveSearchModel mb)
        //{
        //    return await _context.ArchivoIave

        //        .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
        //        .Where(s => s.Descripcion.ToUpper().Contains(mb.Descripcion.ToUpper()) || string.IsNullOrEmpty(mb.Descripcion))
        //        .Where(s => (s.FechaAlta.Date >= mb.FechaInicio.Date) || (mb.FechaInicio.Date == new DateTime()))
        //        .Where(s => (s.FechaAlta.Date <= mb.FechaFin.Date) || (mb.FechaFin.Date == new DateTime()))
        //        .Where(s => s.BActivo == true)
        //        .Select(x => new ArchivoIaveTableModel
        //        {
        //            Id = x.Id,
        //            Nombre = x.Nombre,
        //        })
        //        .ToListAsync();
        //}

        //public async Task<List<ConciliacionCasetaArchivoEvento>> ObtenerConciliacionCasetaArchivoEventos(ConciliacionCasetaArchivoEventoSearchModel sm)
        //{
        //    return await _context.ConciliacionCasetaArchivoEvento
        //        .Where(s => s.Nombre.ToUpper().Contains(sm.Nombre.ToUpper()) || string.IsNullOrEmpty(sm.Nombre))
        //        .Where(s => s.Descripcion.ToUpper().Contains(sm.Descripcion.ToUpper()) || string.IsNullOrEmpty(sm.Descripcion))
        //        .Where(s => s.ClaveEmpresa.ToUpper().Contains(sm.ClaveEmpresa.ToUpper()) || string.IsNullOrEmpty(sm.ClaveEmpresa))
        //        .Where(s => s.BActivo == true)

        //        .ToListAsync();
        //}

        //public async Task<ConciliacionCasetaArchivoEvento> ObtenerConciliacionCasetaArchivoEventoAsync(int Id)
        //{
        //    return await _context.ConciliacionCasetaArchivoEvento
        //        .Where(s => s.Id == Id)
        //        .FirstOrDefaultAsync();
        //}
        #endregion
    }
}

