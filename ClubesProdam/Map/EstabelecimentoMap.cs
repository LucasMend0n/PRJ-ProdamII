
using ClubesProdam.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubesProdam.Map
{
    public class EstabelecimentoMap : BaseMap<Estabelecimento>
    {
        public EstabelecimentoMap() : base("tb_estabelecimentos")
        {

        }
        public override void Configure(EntityTypeBuilder<Estabelecimento> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.NomeEmpresa).HasColumnName("nome").HasColumnType("varchar(100)").IsRequired(); 
            builder.Property(e => e.CNPJ).HasColumnName("cnpj").HasColumnType("varchar(15)").IsRequired(); 
            builder.Property(e => e.CEP).HasColumnName("cep").HasColumnType("varchar(10)").IsRequired(); 
            builder.Property(e => e.TipoEstabelecimento).HasColumnName("tipo_estabelecimento").HasColumnType("varchar(100)").IsRequired(); 
        }
    }
}