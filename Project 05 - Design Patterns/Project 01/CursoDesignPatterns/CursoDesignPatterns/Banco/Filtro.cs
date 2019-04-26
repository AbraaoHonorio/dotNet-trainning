using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDesignPatterns.Banco
{
    public abstract class Filtro
    {
        public Filtro OutroFiltro { get; set; }

        public Filtro(Filtro outroFiltro)
        {
            OutroFiltro = outroFiltro;
        }

        public Filtro()
        {
            OutroFiltro = null;
        }

        public abstract IList<Conta> Filtra(IList<Conta> contas);

        protected IList<Conta> CalculaDoOutroFiltro(IList<Conta> contas)
        {
            if (OutroFiltro == null)
                return new List<Conta>();

            return OutroFiltro.Filtra(contas);
        }
    }
}
