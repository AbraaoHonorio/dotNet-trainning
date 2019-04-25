namespace CursoDesignPatterns.ChainOfResponsibility
{
    public class DescontoPorCincoItens : IDesconto
    {
        public IDesconto Proximo { get; private set; }

        public DescontoPorCincoItens(IDesconto proximo)
        {
            Proximo = proximo;
        }
        public double CalculaDesconto(Orcamento orcamento)
        {
            if (orcamento.Itens.Count >= 5 && orcamento.valorTotalCompras() <= 500)
            {
                return orcamento.Valor * 0.1;
            }

            return Proximo.CalculaDesconto(orcamento);
        }

    }
}