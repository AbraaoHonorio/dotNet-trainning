using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursoDesignPatterns.Banco
{
    public class SaldoMenor100Reais : Filtro
    {
        public SaldoMenor100Reais(Filtro filtro) :base (filtro)
        {
        }
        public SaldoMenor100Reais() : base() { }

        public override IList<Conta> Filtra(IList<Conta> contas)
        {

            return contas.Where(c => c.Saldo < 100).ToList().Concat(CalculaDoOutroFiltro(contas).ToList()).ToList();

        }
    }
}
