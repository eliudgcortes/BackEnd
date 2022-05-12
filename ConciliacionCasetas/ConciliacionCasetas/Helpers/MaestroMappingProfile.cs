using AutoMapper;
using ConciliacionCasetas.ViewModels.Trafico;
using Domain;
using Domain.Catalogos;
using Domain.Trafico;
using NetTopologySuite.Geometries;
using ProyectoMaestro.ViewModels;
using ProyectoMaestro.ViewModels.Catalogos;

namespace ProyectoMaestro.Helpers
{
    public class MaestroMappingProfile : Profile
    {
        public MaestroMappingProfile()
        {
            #region Caseta
            CreateMap<Caseta, CasetaViewModel>()
                .ForMember(m => m.MetodoPagoId, opt => opt.MapFrom(t => t.MetodoPago.Id))
                .ForMember(m => m.NombreMetodoPago, opt => opt.MapFrom(t => t.MetodoPago.NombreListaGenerica))
                .ForMember(m => m.GeocercaId, opt => opt.MapFrom(t => t.Geocerca.Id))
                .ForMember(m => m.NombreGeocerca, opt => opt.MapFrom(t => t.Geocerca.Nombre))
           .ReverseMap();
            #endregion

            #region CampoTicketCaseta
            CreateMap<CampoTicketCaseta, CampoTicketCasetaViewModel>()
                .ForMember(m => m.TipoDatoId, opt => opt.MapFrom(t => t.TipoDato.Id))
                .ForMember(m => m.CasetaId, opt => opt.MapFrom(t => t.Caseta.Id))
                .ForMember(m => m.NombreTipoDato, opt => opt.MapFrom(t => t.TipoDato.NombreListaGenerica))
           .ReverseMap();
            #endregion

            #region ListaGenerica
            CreateMap<ListaGenerica, ListaGenericaViewModel>()
           .ReverseMap();
            #endregion

            #region ListaGenericaTipo
            CreateMap<ListaGenericaTipo, ListaGenericaTipoViewModel>()
           .ReverseMap();
            #endregion

            #region Carril
            CreateMap<Carril, CarrilViewModel>()
               .ForMember(m => m.Peajes, opt => opt.MapFrom(t => t.Peajes))
           .ReverseMap();
            #endregion

            #region Peaje
            CreateMap<Peaje, PeajeViewModel>()
                .ForMember(m => m.NombreCarril, opt => opt.MapFrom(t => t.Carril.Nombre))
                .ForMember(m => m.NombreTipoEje, opt => opt.MapFrom(t => t.TipoEje.NombreListaGenerica))
           .ReverseMap();
            #endregion

            #region Geocerca
            CreateMap<Geocerca, GeocercaViewModel>()
                 .ForMember(m => m.Punto, opt => opt.MapFrom(t => new PuntoViewModel { Latitud = (double)t.Punto.Y, Longitud = (double)t.Punto.X }))
                 .ForMember(m => m.Poligono, opt => opt.MapFrom(t => MapPoligono(t.Poligono)))
            .ReverseMap();
            #endregion

            #region ConciliacionCaseta
            CreateMap<ConciliacionCaseta, ConciliacionCasetaViewModel>()
           //.ForMember(m => m.MetodoPagoId, opt => opt.MapFrom(t => t.MetodoPago.Id))
           .ForMember(m => m.EmpresaId, opt => opt.MapFrom(t => t.Empresa.Id))
           .ReverseMap();
            #endregion

            #region ConciliacionCasetaArchivo
            CreateMap<ConciliacionCasetaArchivo, ConciliacionCasetaArchivoViewModel>()
                .ForMember(m => m.ConciliacionCasetaId, opt => opt.MapFrom(t => t.ConciliacionCaseta.Id))
           .ReverseMap();
            #endregion

            #region ConciliacionCasetaArchivoEvento
            CreateMap<ConciliacionCasetaArchivoEvento, ConciliacionCasetaArchivoEventoViewModel>()
           //.ForMember(m => m.MetodoPagoId, opt => opt.MapFrom(t => t.MetodoPago.Id))
           .ReverseMap();
            #endregion

            #region Empresa
           // CreateMap<Empresa, EmpresaViewModel>()
           ////.ForMember(m => m.MetodoPagoId, opt => opt.MapFrom(t => t.MetodoPago.Id))
           //.ReverseMap();
            #endregion
        }
        public static PoligonoViewModel MapPoligono(Geometry geocerca)
        {
            PoligonoViewModel poligono = new PoligonoViewModel();
            List<PuntoViewModel> vertices = new List<PuntoViewModel>();

            poligono.Tipo = geocerca.GeometryType;
            foreach (var punto in geocerca.Coordinates)
            {
                PuntoViewModel cordenadas = new PuntoViewModel
                {
                    Latitud = punto.Y,
                    Longitud = punto.X
                };
                vertices.Add(cordenadas);
            }
            poligono.Puntos = new List<PuntoViewModel>();
            poligono.Puntos.AddRange(vertices);
            return poligono;
        }
    }
}
