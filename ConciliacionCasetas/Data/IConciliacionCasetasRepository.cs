using Data.SearchModels;
using Data.SearchModels.Catalogos;
using Data.SearchModels.Trafico;
using Data.TableModels;
using Data.TableModels.Catalogos;
using Domain;
using Domain.Catalogos;
using Domain.Trafico;

namespace Data
{
    public interface IConciliacionCasetasRepository
     {
        #region Generic Functions

        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAllAsync();

        #endregion Generic Functions

        public class RespuestaBd
        {
            #region Atributo
            public int IntError { get; set; }
            public int IntIdRespuesta { get; set; }
            public string StrMensajeError { get; set; }
            public Boolean BValido { get; set; }
            public string StrJsonRespuesta { get; set; }
            #endregion
            #region GetSet
            #endregion
            #region constructor
            public RespuestaBd() { }
            #endregion
        }

        #region Caseta
        Task<List<Caseta>> ObtenerCasetas(CasetaSearchModel mb);
        Task<List<CasetaTableModel>> ObtenerCasetasTabla(CasetaSearchModel mb);
        Task<Caseta> ObtenerCasetaAsync(int Id);

        #endregion

        #region CampoTicketCaseta
        Task<List<CampoTicketCaseta>> ObtenerCamposTicketCaseta(CampoTicketCasetaSearchModel sm);
        Task<List<CampoTicketCaseta>> ObtenerCamposTicketCasetaTabla(CampoTicketCasetaSearchModel sm);
        Task<CampoTicketCaseta> ObtenerCampoTicketCasetaAsync(int Id);
        #endregion

        #region Carril
        Task<List<Carril>> ObtenerCarriles(CarrilSearchModel sm);
        Task<Carril> ObtenerCarrilAsync(int Id);
        #endregion

        #region ListaGenericaTipo

        Task<List<ListaGenericaTipo>> ObtenerListasGenericasTipo(ListaGenericaTipoSearchModel mb);
        Task<List<ListaGenericaTipo>> ObtenerListaGenericaTipoTabla(ListaGenericaTipoSearchModel mb);
        Task<ListaGenericaTipo> ObtenerListaGenericaTipoAsync(int Id);
        #endregion

        #region ListaGenerica
        Task<List<ListaGenerica>> ObtenerListasGenericas(ListaGenericaSearchModel mb);
        Task<ListaGenerica> ObtenerListaGenericaAsync(int Id);
        #endregion ListaGenerica

        #region Geocerca
        Task<List<Geocerca>> ObtenerGeocercas(GeocercaSearchModel mb);
        Task<List<Geocerca>> ObtenerGeocercasSinAzureDireccion();
        Task<Geocerca> ObtenerGeocercaAsync(int Id);
        Task<List<GeocercaTableModel>> ObtenerGeocercaTabla(GeocercaSearchModel sm);
        #endregion Geocerca

        #region Peaje
        Task<List<Peaje>> ObtenerPeajes(PeajeSearchModel sm);
        Task<Peaje> ObtenerPeajeAsync(int Id);
        #endregion  Peaje

        #region HistoricoPeaje
        Task<List<HistoricoPeaje>> ObtenerHistoricosPeaje(HistoricoPeajeSearchModel sm);
        Task<HistoricoPeaje> ObtenerHistoricoPeajeAsync(int Id);

        #endregion  HistoricoPeaje

        #region ConciliacionCaseta
        Task<List<ConciliacionCaseta>> ObtenerConciliacionCasetas(ConciliacionCasetaSearchModel mb);
        Task<ConciliacionCaseta> ObtenerConciliacionCasetaAsync(int Id);

        #endregion

        #region ConciliacionCasetaArchivo
        Task<List<ConciliacionCasetaArchivo>> ObtenerConciliacionCasetaArchivos(ConciliacionCasetaArchivoSearchModel mb);
        //Task<List<ArchivoIaveTableModel>> ObtenerArchivosIaveTabla(ArchivoIaveSearchModel mb);
        Task<ConciliacionCasetaArchivo> ObtenerConciliacionCasetaArchivoAsync(int Id);

        #endregion

        #region ConciliacionCasetaArchivoEvento
        Task<List<ConciliacionCasetaArchivoEvento>> ObtenerConciliacionCasetaArchivoEventos(ConciliacionCasetaArchivoEventoSearchModel mb);
        //Task<List<EventoIaveTableModel>> ObtenerEventosIaveTabla(EventoIaveSearchModel mb);
        Task<ConciliacionCasetaArchivoEvento> ObtenerConciliacionCasetaArchivoEventoAsync(int Id);

        #endregion

        #region Empresa
        //Task<List<ConciliacionCasetaArchivoEvento>> ObtenerConciliacionCasetaArchivoEventos(ConciliacionCasetaArchivoEventoSearchModel mb);
        ////Task<List<EventoIaveTableModel>> ObtenerEventosIaveTabla(EventoIaveSearchModel mb);
        //Task<ConciliacionCasetaArchivoEvento> ObtenerConciliacionCasetaArchivoEventoAsync(int Id);

        #endregion
    }

}
