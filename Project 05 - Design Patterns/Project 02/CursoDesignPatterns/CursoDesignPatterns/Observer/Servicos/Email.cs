using CursoDesignPatterns.Observer.Comandos.Interface;
using CursoDesignPatterns.Observer.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDesignPatterns.Observer.Servicos
{
    public class Email : IPosGerarNota
    {
        public void Executar(NotaFiscal notaFiscal)
        {
            Console.WriteLine("Simulando - enviado por email com sucesso");
        }
    }
}
