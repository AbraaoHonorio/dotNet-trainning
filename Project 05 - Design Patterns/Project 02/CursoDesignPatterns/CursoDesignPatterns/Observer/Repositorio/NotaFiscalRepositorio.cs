using CursoDesignPatterns.Observer.Comandos.Interface;
using CursoDesignPatterns.Observer.Modelos;
using CursoDesignPatterns.Observer.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDesignPatterns.Observer.Repositorio
{
    public class NotaFiscalRepositorio : INotaFiscalRepositorio, IPosGerarNota
    {
        public void Executar(NotaFiscal notaFiscal)
        {
            Salvar(notaFiscal);
        }

        public void Salvar(NotaFiscal notaFiscal)
        {
            Console.WriteLine("Simulando - salvo no banco com sucesso");
        }
    }
}
