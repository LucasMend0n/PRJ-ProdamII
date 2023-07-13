namespace ClubesProdam.model
{
    public class Estabelecimento
    {
        public int ID { get; set; }
        public string NomeEmpresa { get; set; }
        public string CEP { get; set; }
        public string CNPJ { get; set; }
        public string TipoEstabelecimento { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        
    }
}