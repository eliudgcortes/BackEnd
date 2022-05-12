﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ConciliacionCasetasContext))]
    [Migration("20220502171930_ConciliacionCasetasFase1.2")]
    partial class ConciliacionCasetasFase12
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Caseta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CasetaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AliasIave")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ArchivoTicketAtras")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ArchivoTicketFrente")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit");

                    b.Property<bool>("BCasetaActiva")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GeocercaId")
                        .HasColumnType("int");

                    b.Property<int?>("MetodoPagoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Url")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("GeocercaId");

                    b.HasIndex("MetodoPagoId");

                    b.ToTable("Caseta", "corporativo");
                });

            modelBuilder.Entity("Domain.Catalogos.CampoTicketCaseta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CampoTicketCasetaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit");

                    b.Property<int>("CasetaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int?>("TipoDatoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CasetaId");

                    b.HasIndex("TipoDatoId");

                    b.ToTable("CampoTicketCaseta", "corporativo");
                });

            modelBuilder.Entity("Domain.Catalogos.Carril", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CarrilId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AliasIave")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit");

                    b.Property<int>("CasetaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CasetaId");

                    b.ToTable("Carril", "corporativo");
                });

            modelBuilder.Entity("Domain.Catalogos.Geocerca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GeocercaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit");

                    b.Property<bool?>("BDireccionAzure")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<string>("GeocercaIdExterno")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Geometry>("Poligono")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<string>("PoligonoComputado")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[Poligono].ToString()");

                    b.Property<Point>("Punto")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<string>("PuntoComputado")
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[Punto].ToString()");

                    b.Property<int?>("TipoGeocercaId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoGeocercaId");

                    b.ToTable("Geocerca", "corporativo");
                });

            modelBuilder.Entity("Domain.Catalogos.HistoricoPeaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("HistoricoPeajeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(20,4)");

                    b.Property<int>("PeajeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PeajeId");

                    b.ToTable("HistoricoPeaje", "corporativo");
                });

            modelBuilder.Entity("Domain.Catalogos.ListaGenerica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ListaGenericaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit");

                    b.Property<string>("DescripcionListaGenerica")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("desListaGenerica");

                    b.Property<int>("Estatus")
                        .HasColumnType("int");

                    b.Property<int>("ListaGenericaTipoId")
                        .HasColumnType("int");

                    b.Property<string>("NombreListaGenerica")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("cveListaGenerica");

                    b.Property<int>("ValorEntero")
                        .HasColumnType("int");

                    b.Property<float>("ValorFlotante")
                        .HasColumnType("real");

                    b.Property<string>("ValorString")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("ListaGenericaTipoId");

                    b.ToTable("ListaGenerica ", "torreservicio");
                });

            modelBuilder.Entity("Domain.Catalogos.ListaGenericaTipo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ListaGenericaTipoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("desListaGenericaTipo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("cveListaGenericaTipo");

                    b.HasKey("Id");

                    b.ToTable("ListaGenericaTipo", "torreservicio");
                });

            modelBuilder.Entity("Domain.Catalogos.Peaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PeajeId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit");

                    b.Property<int>("CarrilId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(20,4)");

                    b.Property<int?>("TipoEjeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrilId");

                    b.HasIndex("TipoEjeId");

                    b.ToTable("Peaje", "corporativo");
                });

            modelBuilder.Entity("Domain.Trafico.ConciliacionCaseta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ConciliacionCasetaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit");

                    b.Property<int>("ClaveRed")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("UsuarioAlta")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioEdita")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioElimina")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("ConciliacionCaseta", "trafico");
                });

            modelBuilder.Entity("Domain.Trafico.ConciliacionCasetaArchivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ConciliacionCasetaArchivoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit");

                    b.Property<int>("ConciliacionCasetaId")
                        .HasColumnType("int");

                    b.Property<string>("EstatusArchivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaAlta")
                        .HasMaxLength(250)
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEdita")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaElimina")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioAlta")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioEdita")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("UsuarioElimina")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("ConciliacionCasetaId");

                    b.ToTable("ConciliacionCasetaArchivo", "trafico");
                });

            modelBuilder.Entity("Domain.Trafico.ConciliacionCasetaArchivoEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ConciliacionCasetaArchivoEventoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BActivo")
                        .HasMaxLength(250)
                        .HasColumnType("bit");

                    b.Property<int>("Clase")
                        .HasColumnType("int");

                    b.Property<string>("ClaveEmpresa")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("ClaveFideicomiso")
                        .HasColumnType("int");

                    b.Property<int>("ClaveRed")
                        .HasMaxLength(250)
                        .HasColumnType("int");

                    b.Property<int?>("ConciliacionCasetaArchivoId")
                        .HasColumnType("int");

                    b.Property<int>("ConciliacionCasetaId")
                        .HasColumnType("int");

                    b.Property<string>("ControlInternoProveedor1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControlInternoProveedor2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControlInternoProveedor3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ControlInternoProveedor4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstatusCruce")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCargoBanco")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaCruce")
                        .HasMaxLength(250)
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("HoraCruce")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ImporteAl100")
                        .HasMaxLength(250)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ImporteFacturado")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCarril")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NombreCaseta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroCargaBanco")
                        .HasColumnType("int");

                    b.Property<string>("NumeroEconomico")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("NumeroPeriodo")
                        .HasColumnType("int");

                    b.Property<int>("NumeroPlaza")
                        .HasColumnType("int");

                    b.Property<string>("TarjetaIDMX")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TipoPeriodo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ConciliacionCasetaArchivoId");

                    b.HasIndex("ConciliacionCasetaId");

                    b.ToTable("ConciliacionCasetaArchivoEvento", "trafico");
                });

            modelBuilder.Entity("Domain.Trafico.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EmpresaId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("BActivo")
                        .HasColumnType("bit")
                        .HasColumnName("bActivo");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("desEmpresa");

                    b.Property<int>("EmpresaSipId")
                        .HasColumnType("int")
                        .HasColumnName("IdEmpresaSip");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("Logo");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("cveEmpresa");

                    b.HasKey("Id");

                    b.ToTable("Empresa ", "corporativo");
                });

            modelBuilder.Entity("Domain.Caseta", b =>
                {
                    b.HasOne("Domain.Catalogos.Geocerca", "Geocerca")
                        .WithMany("Casetas")
                        .HasForeignKey("GeocercaId");

                    b.HasOne("Domain.Catalogos.ListaGenerica", "MetodoPago")
                        .WithMany()
                        .HasForeignKey("MetodoPagoId");

                    b.Navigation("Geocerca");

                    b.Navigation("MetodoPago");
                });

            modelBuilder.Entity("Domain.Catalogos.CampoTicketCaseta", b =>
                {
                    b.HasOne("Domain.Caseta", "Caseta")
                        .WithMany()
                        .HasForeignKey("CasetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Catalogos.ListaGenerica", "TipoDato")
                        .WithMany()
                        .HasForeignKey("TipoDatoId");

                    b.Navigation("Caseta");

                    b.Navigation("TipoDato");
                });

            modelBuilder.Entity("Domain.Catalogos.Carril", b =>
                {
                    b.HasOne("Domain.Caseta", "Caseta")
                        .WithMany("Carriles")
                        .HasForeignKey("CasetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caseta");
                });

            modelBuilder.Entity("Domain.Catalogos.Geocerca", b =>
                {
                    b.HasOne("Domain.Catalogos.ListaGenerica", "TipoGeocerca")
                        .WithMany()
                        .HasForeignKey("TipoGeocercaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoGeocerca");
                });

            modelBuilder.Entity("Domain.Catalogos.HistoricoPeaje", b =>
                {
                    b.HasOne("Domain.Catalogos.Peaje", "Peaje")
                        .WithMany("HistoricosPeaje")
                        .HasForeignKey("PeajeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peaje");
                });

            modelBuilder.Entity("Domain.Catalogos.ListaGenerica", b =>
                {
                    b.HasOne("Domain.Catalogos.ListaGenericaTipo", "ListaGenericaTipo")
                        .WithMany("ListaGenericas")
                        .HasForeignKey("ListaGenericaTipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ListaGenericaTipo");
                });

            modelBuilder.Entity("Domain.Catalogos.Peaje", b =>
                {
                    b.HasOne("Domain.Catalogos.Carril", "Carril")
                        .WithMany("Peajes")
                        .HasForeignKey("CarrilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Catalogos.ListaGenerica", "TipoEje")
                        .WithMany()
                        .HasForeignKey("TipoEjeId");

                    b.Navigation("Carril");

                    b.Navigation("TipoEje");
                });

            modelBuilder.Entity("Domain.Trafico.ConciliacionCaseta", b =>
                {
                    b.HasOne("Domain.Trafico.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Domain.Trafico.ConciliacionCasetaArchivo", b =>
                {
                    b.HasOne("Domain.Trafico.ConciliacionCaseta", "ConciliacionCaseta")
                        .WithMany("Archivos")
                        .HasForeignKey("ConciliacionCasetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConciliacionCaseta");
                });

            modelBuilder.Entity("Domain.Trafico.ConciliacionCasetaArchivoEvento", b =>
                {
                    b.HasOne("Domain.Trafico.ConciliacionCasetaArchivo", null)
                        .WithMany("Eventos")
                        .HasForeignKey("ConciliacionCasetaArchivoId");

                    b.HasOne("Domain.Trafico.ConciliacionCaseta", "ConciliacionCaseta")
                        .WithMany()
                        .HasForeignKey("ConciliacionCasetaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConciliacionCaseta");
                });

            modelBuilder.Entity("Domain.Caseta", b =>
                {
                    b.Navigation("Carriles");
                });

            modelBuilder.Entity("Domain.Catalogos.Carril", b =>
                {
                    b.Navigation("Peajes");
                });

            modelBuilder.Entity("Domain.Catalogos.Geocerca", b =>
                {
                    b.Navigation("Casetas");
                });

            modelBuilder.Entity("Domain.Catalogos.ListaGenericaTipo", b =>
                {
                    b.Navigation("ListaGenericas");
                });

            modelBuilder.Entity("Domain.Catalogos.Peaje", b =>
                {
                    b.Navigation("HistoricosPeaje");
                });

            modelBuilder.Entity("Domain.Trafico.ConciliacionCaseta", b =>
                {
                    b.Navigation("Archivos");
                });

            modelBuilder.Entity("Domain.Trafico.ConciliacionCasetaArchivo", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
