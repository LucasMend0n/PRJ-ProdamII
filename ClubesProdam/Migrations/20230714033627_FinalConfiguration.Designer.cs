﻿// <auto-generated />
using ClubesProdam.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClubesProdam.Migrations
{
    [DbContext(typeof(ClubeDbContext))]
    [Migration("20230714033627_FinalConfiguration")]
    partial class FinalConfiguration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClubesProdam.model.Estabelecimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("cep");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasColumnName("cnpj");

                    b.Property<string>("NomeEmpresa")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<string>("TipoEstabelecimento")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("tipo_estabelecimento");

                    b.HasKey("Id");

                    b.ToTable("tb_estabelecimentos", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
