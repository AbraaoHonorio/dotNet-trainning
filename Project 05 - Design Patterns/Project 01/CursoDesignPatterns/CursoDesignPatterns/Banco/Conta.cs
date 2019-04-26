using System;
using System.Collections.Generic;

namespace CursoDesignPatterns.Banco
{
    public class Conta 
    {
        public double Saldo { get; set; }
        public DateTime DataAbertura { get; set; }
        public bool fraude { get; set; }

        public Conta(double saldo)
        {
            Saldo = saldo;
        }
    }
}