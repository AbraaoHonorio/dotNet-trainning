namespace CursoDesignPatterns.ChainOfResponsibility
{
    public class CalculadorDeDescontos
    {
        public double Calcula(Orcamento orcamento)
        {
            IDesconto desconto1 = new SemDesconto();
            IDesconto desconto2 = new DescontoPorMaisDeQuinhentosReais(desconto1);
            IDesconto desconto3 = new DescontoPorCincoItens(desconto2);

            return desconto3.CalculaDesconto(orcamento);
        }
    }
}