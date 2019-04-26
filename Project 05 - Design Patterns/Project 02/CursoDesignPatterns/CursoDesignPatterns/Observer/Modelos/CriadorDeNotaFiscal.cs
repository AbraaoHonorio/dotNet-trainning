
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CursoDesignPatterns.Observer.Comandos.Interface;
using CursoDesignPatterns.Observer.Servicos;

namespace CursoDesignPatterns.Observer.Modelos
{
    public class CriadorDeNotaFiscal
    {
        public string RazaoSocial { get; private set; }
        public string Cnpj { get; private set; }
        public DateTime DataHora { get; private set; }
        private IList<ItemDaNota> Itens => new List<ItemDaNota>();
        public double ValorTotal { get; private set; }
        public double Imposto { get; private set; }
        public string Observacao { get; private set; }
        private readonly IList<IPosGerarNota> ItensAcoes = new List<IPosGerarNota>();

        public NotaFiscal RetornaNotaFiscal()
        {
            var notaFiscal = new NotaFiscal(RazaoSocial, Cnpj, DataHora, ValorTotal, Imposto, Itens, Observacao);

            foreach (IPosGerarNota acao in ItensAcoes)
                acao.Executar(notaFiscal);

            return notaFiscal;
        }

        public CriadorDeNotaFiscal AdicionarRazaoSocial(String razaoSocial)
        {
            RazaoSocial = razaoSocial;
            return this;
        }

        public void AdicionarAcao(IPosGerarNota acao)
        {
            ItensAcoes.Add(acao);
        }

        public CriadorDeNotaFiscal AdicionarCnpj(String cnpj)
        {
            Cnpj = cnpj;
            return this;
        }

        public CriadorDeNotaFiscal AdicionarDataHora(DateTime dataHora)
        {
            DataHora = dataHora;
            return this;
        }

        public CriadorDeNotaFiscal AddItem(ItemDaNota item)
        {
            Itens.Add(item);
            ValorTotal += item.Valor;
            Imposto += item.Valor * 0.0;
            return this;
        }

        public CriadorDeNotaFiscal AddItens(List<ItemDaNota> itens)
        {
            foreach (var item in itens)
            {
                ValorTotal += item.Valor;
                Imposto += item.Valor * 0.05;

                Itens.Add(item);
            }
            return this;
        }

        public List<ItemDaNota> RetornaItens()
        {
            return Itens.ToList();
        }

        public CriadorDeNotaFiscal AdicionarObservacao(string observacao)
        {
            Observacao = observacao;
            return this;
        }
    }
}
