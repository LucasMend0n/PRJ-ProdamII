
using ClubesProdam.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubesProdam.Map
{
    public class FuncionarioMap : BaseMap<Funcionario>
    {
        public FuncionarioMap() : base("tb_funcionarios")
        {
            
        }
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Nome).HasColumnName("nome").HasColumnType("varchar(100)");
            builder.Property(e => e.Idade).HasColumnName("idade");
            builder.Property(e => e.Salario).HasColumnName("salario").HasColumnType("decimal(7,2)");

            builder.Property(e => e.EstabelecimentoID).HasColumnName("id_estabelecimento"); 
            builder.HasOne(e => e.Estabelecimento).WithMany(e => e.Funcionarios).HasForeignKey(e => e.EstabelecimentoID);  
        }
    }
    
}