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
    [Migration("20230714033327_resetMigrations")]
    partial class resetMigrations
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

            modelBuilder.Entity("ClubesProdam.model.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstabelecimentoID")
                        .HasColumnType("int")
                        .HasColumnName("id_estabelecimento");

                    b.Property<int>("Idade")
                        .HasColumnType("int")
                        .HasColumnName("idade");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(7,2)")
                        .HasColumnName("salario");

                    b.HasKey("Id");

                    b.HasIndex("EstabelecimentoID");

                    b.ToTable("tb_funcionarios", (string)null);
                });

            modelBuilder.Entity("ClubesProdam.model.Funcionario", b =>
                {
                    b.HasOne("ClubesProdam.model.Estabelecimento", "Estabelecimento")
                        .WithMany("Funcionarios")
                        .HasForeignKey("EstabelecimentoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estabelecimento");
                });

            modelBuilder.Entity("ClubesProdam.model.Estabelecimento", b =>
                {
                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
