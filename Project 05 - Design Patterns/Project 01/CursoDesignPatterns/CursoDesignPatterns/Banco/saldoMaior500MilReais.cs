using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursoDesignPatterns.Banco
{
    public class SaldoMaior500MilReais : Filtro
    {
        public SaldoMaior500MilReais(Filtro filtro) :base (filtro)
        {
        }
        public SaldoMaior500MilReais() : base() { }

        public override IList<Conta> Filtra(IList<Conta> contas)
        {
            return contas.Where(c => c.Saldo > 500000).ToList().Concat(CalculaDoOutroFiltro(contas).ToList()).ToList(); 
        }
    }
}
