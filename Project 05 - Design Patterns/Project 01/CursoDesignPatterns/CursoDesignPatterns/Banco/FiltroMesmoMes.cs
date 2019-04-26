using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CursoDesignPatterns.Banco
{
    public class FiltroMesmoMes : Filtro
    {
        public FiltroMesmoMes(Filtro filtro) : base(filtro)
        {
        }
        public FiltroMesmoMes() : base() { }

        public override IList<Conta> Filtra(IList<Conta> contas)
        {
            return contas.Where(c => c.DataAbertura.Month == DateTime.Now.Month).ToList().Concat(CalculaDoOutroFiltro(contas).ToList()).ToList();
        }
    }
}
