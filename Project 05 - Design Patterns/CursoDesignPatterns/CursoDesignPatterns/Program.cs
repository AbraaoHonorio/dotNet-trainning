using CursoDesignPatterns.Banco;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {

            Conta contaa = new Conta(50);
            Conta contab = new Conta(1500);
            contab.DataAbertura = DateTime.Now;
            Conta contac = new Conta(500000);
            Conta contad = new Conta(500001);
            IList<Conta> contas = new List<Conta>();
            contas.Add(contaa);
            contas.Add(contab);
            contas.Add(contac);
            contas.Add(contad);
            Console.WriteLine(contas.Where(c => c.Saldo > 500000 || c.Saldo < 100).ToList().Count);

            Banco.Filtro saldoMaior500MilReais = new SaldoMaior500MilReais(new FiltroMesmoMes());
            Banco.Filtro saldoMenor100Reais = new SaldoMenor100Reais(saldoMaior500MilReais);

            Console.WriteLine(saldoMenor100Reais.Filtra(contas).Count);
            /*   Decorator.Imposto iss = new Decorator.ISS();
               Decorator.Imposto icms = new Decorator.ICMS(iss);
               Decorator.Orcamento orcamento = new Decorator.Orcamento(501);

               Console.WriteLine(icms.Calcula(orcamento));*/



            /* TemplateMethod.TemplateDeImpostoCondicional icpp = new TemplateMethod.ICPP();
           TemplateMethod.TemplateDeImpostoCondicional ikcv = new TemplateMethod.IKCV();

           TemplateMethod.Orcamento orcamento = new TemplateMethod.Orcamento(501);
           orcamento.AdicionaItem(new TemplateMethod.Item("Fone", 270.0));
           orcamento.AdicionaItem(new TemplateMethod.Item("Fone", 270.0));
           orcamento.AdicionaItem(new TemplateMethod.Item("Fone", 270.0));

           Console.WriteLine("ICPP ->'  " + icpp.Calcula(orcamento));
           Console.WriteLine("IKCV ->'  " + ikcv.Calcula(orcamento)); */

            /* IImposto iss = new ISS();
            IImposto icms = new ICMS();

            Orcamento orcamento = new Orcamento();
            orcamento.setValor(100);
            CalculadorDeImpostos calculadorDeImpostos = new CalculadorDeImpostos();
            calculadorDeImpostos.RealizaCalculo(orcamento,iss);
            calculadorDeImpostos.RealizaCalculo(orcamento, icms);*/
            /*
            ChainOfResponsibility.CalculadorDeDescontos calculador = new ChainOfResponsibility.CalculadorDeDescontos();

            ChainOfResponsibility.Orcamento orcamento = new ChainOfResponsibility.Orcamento(501);
            orcamento.AdicionaItem(new ChainOfResponsibility.Item("Fone",270.0));
            orcamento.AdicionaItem(new ChainOfResponsibility.Item("Mouse", 80.0));
            orcamento.AdicionaItem(new ChainOfResponsibility.Item("Teclado", 151.0));
            if(orcamento.Valido() != false)
            {
                double desconto = calculador.Calcula(orcamento);
                Console.WriteLine("->'  " + desconto);
            }
            else
            {
                Console.WriteLine(" orcamento não válido");
            }
           */
            Console.ReadKey();
        }

    }
}
