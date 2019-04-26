using CursoDesignPatterns.Observer.Modelos;
using CursoDesignPatterns.Observer.Repositorio;
using CursoDesignPatterns.Observer.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<ItemDaNota> itens = new List<ItemDaNota>
            {
                new ItemDaNota("produto 1", 10.0),
                new ItemDaNota("produto 2", 20.0),
                new ItemDaNota("produto 3", 30.0)
            };

            CriadorDeNotaFiscal criadorDeNotaFiscal = new CriadorDeNotaFiscal();
            criadorDeNotaFiscal.AdicionarRazaoSocial("Teste Company")
            .AdicionarCnpj("78137579000126")
            .AdicionarDataHora(DateTime.Now)
            .AdicionarObservacao("Teste")
            .AddItens(itens.ToList());


            criadorDeNotaFiscal.AdicionarAcao(new Email());
            criadorDeNotaFiscal.AdicionarAcao(new Sms());
            criadorDeNotaFiscal.AdicionarAcao(new NotaFiscalRepositorio());

            NotaFiscal notaFiscal = criadorDeNotaFiscal.RetornaNotaFiscal();
            Console.WriteLine(notaFiscal.ValorBruto);
            Console.WriteLine(notaFiscal.Imposto);


            /* 
        Orcamento orcamento = new Orcamento(500);
        Console.WriteLine(orcamento.Valor);

        orcamento.AplicaDescontoExtra();
        Console.WriteLine(orcamento.Valor);
        orcamento.AplicaDescontoExtra();
        Console.WriteLine(orcamento.Valor);

        orcamento.Aprova();

        orcamento.AplicaDescontoExtra();
        Console.WriteLine(orcamento.Valor);

        orcamento.Finaliza();

       */
            Console.ReadKey();
        }
    }
}
