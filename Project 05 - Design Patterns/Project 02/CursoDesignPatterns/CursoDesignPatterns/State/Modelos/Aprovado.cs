using System;
using System.Collections.Generic;
using System.Text;
using CursoDesignPatterns.models;

namespace CursoDesignPatterns
{
    public class Aprovado : IEstadoDeUmOrcamento
    {
        public int i=0;

        public void AplicaDescontoExtra(Orcamento orcamento)
        {
           
            if (i < 1)
            {
                i++;
                orcamento.Valor -= orcamento.Valor * 0.02;
            }
            else
                throw new Exception("Orçamento já recebeu desconto");

        }

        public void Aprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento já está em estado de aprovação");
        }

        public void Finaliza(Orcamento orcamento)
        {
            orcamento.EstadoAtual = new Finalizado();
        }

        public void Reprova(Orcamento orcamento)
        {
            throw new Exception("Orçamento está em aprovado, não pode ser reprovado agora");
        }
    }
}
