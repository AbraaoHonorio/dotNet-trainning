using CursoDesignPatterns.Observer.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDesignPatterns.Observer.Comandos.Interface
{
    public interface IPosGerarNota
    {
        void Executar(NotaFiscal notaFiscal);
    }
}
