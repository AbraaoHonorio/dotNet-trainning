using System.Linq;

namespace CursoDesignPatterns.TemplateMethod
{
    public class IKCV : TemplateDeImpostoCondicional
    {
        public override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }

        public override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.10;
        }

        public override bool UsaMaximaTaxacao(Orcamento orcamento)
        {
            return (orcamento.Valor > 500 && TemItemMaior100Reais(orcamento));
              
        }

        private bool TemItemMaior100Reais(TemplateMethod.Orcamento orcamento)
        {
            return orcamento.Itens.Select(i => i.Valor > 100).First();
        }
    }
}
