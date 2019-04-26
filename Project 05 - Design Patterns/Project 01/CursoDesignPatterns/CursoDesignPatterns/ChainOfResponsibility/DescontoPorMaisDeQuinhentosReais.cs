using System.Linq;

namespace CursoDesignPatterns.ChainOfResponsibility
{
    public class DescontoPorMaisDeQuinhentosReais : IDesconto
    {
        public IDesconto Proximo { get; private set; }

        public DescontoPorMaisDeQuinhentosReais(IDesconto proximo)
        {
            Proximo = proximo;
        }

        public double CalculaDesconto(Orcamento orcamento)
        {
          
            if (orcamento.valorTotalCompras() > 500)
            {
                return orcamento.Valor * 0.07;
            }

            return Proximo.CalculaDesconto(orcamento);
        }
    }
}
