using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDesignPatterns.ChainOfResponsibility
{
    public class SemDesconto : IDesconto
    {
        public IDesconto Proximo { get ; set; }

        public double CalculaDesconto(Orcamento orcamento)
        {
            return 0;
        }
    }
}
