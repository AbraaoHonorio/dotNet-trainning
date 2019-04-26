using System;

namespace CursoDesignPatterns.ChainOfResponsibility
{
    public class Item
    {
        public String Nome { get; private set; }
        public double Valor { get; private set; }

        public Item(String nome, double valor)
        {
            Nome = nome;
            Valor = valor;
        }

    }
}