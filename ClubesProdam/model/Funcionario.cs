namespace ClubesProdam.model
{
    public class Funcionario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public int Idade {get; set;}
        public int EstabelecimentoID { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
    }
}