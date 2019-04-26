using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDesignPatterns.Observer.Modelos
{
    public class ItemDaNota
    {
        public String Nome { get; set; }
        public Double Valor { get; set; }

        public ItemDaNota(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
        }
    }
}
