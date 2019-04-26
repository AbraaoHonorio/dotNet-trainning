using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDesignPatterns.TemplateMethod
{
    public class ICPP : TemplateDeImpostoCondicional
    {
        public override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.07;
        }

        public override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05;
        }

        public override bool UsaMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor >= 500;
        }
    }
}
