using CursoDesignPatterns.models;
using System;

namespace CursoDesignPatterns
{
    public class EmAprovacao : IEstadoDeUmOrcamento
    {
        public int i = 0;

        public void AplicaDescontoExtra(Orcamento orcamento)
        {
            if (i < 1)
            {
                orcamento.Valor -= orcamento.Valor * 0.05;
                i++;
            }
            else
                throw new Exception("Orçamento já recebeu desconto");
        }

        public void Aprova(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Aprovado();
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void Reprova(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Reprovado();
        }
    }
}
