using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDesignPatterns.ChainOfResponsibility
{
    public interface IDesconto
    {
        double CalculaDesconto(Orcamento orcamento);
        IDesconto Proximo { get; }
        
    }
}
