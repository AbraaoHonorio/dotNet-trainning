using CursoDesignPatterns.Builder.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoDesignPatterns.Observer.Modelos
{
    public class NotaFiscal
    {
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataEmissao { get; set; }
        public double ValorBruto { get; set; }
        public double Imposto { get; set; }
        public IList<ItemDaNota> Itens { get; set; }
        public string Observacao { get; set; }


        public NotaFiscal(
            string razaoSocial, string cnpj, DateTime dataEmissao,
            double valorBruto, double imposto, IList<ItemDaNota> itens, string observacao)
        {
            RazaoSocial = razaoSocial;
            Cnpj = cnpj;
            DataEmissao = dataEmissao;
            ValorBruto = valorBruto;
            Imposto = imposto;
            Itens = itens;
            Observacao = observacao;
        }
    }
}
