namespace ClubesProdam.model
{
    public class Funcionario : Base
    {
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public int Idade {get; set;}
        public int EstabelecimentoID { get; set; }
        public Estabelecimento Estabelecimento { get; set; }
    }
}