using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDesignPatterns
{
   public class Orcamento
    {
       public double Valor { get; private set; }

        public void setValor(double valor)
        {
            Valor = valor;
        }
    }
}
