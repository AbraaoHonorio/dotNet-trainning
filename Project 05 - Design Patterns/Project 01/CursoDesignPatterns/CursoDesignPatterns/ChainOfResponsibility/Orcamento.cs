using System.Collections.Generic;
using System.Linq;

namespace CursoDesignPatterns.ChainOfResponsibility
{
    public class Orcamento
    {
        public double Valor { get; private set; }
        public IList<Item> Itens { get; private set; }

        public Orcamento(double valor)
        {
            Valor = valor;
            Itens = new List<Item>();
      
        }
   
        public void AdicionaItem(Item item)
        {
            Itens.Add(item);
          

        }

        public double valorTotalCompras()
        {
            return Itens.Sum(item => item.Valor);
        }

        public bool Valido()
        {
            if (valorTotalCompras() > Valor)
                return false;

            return true;
        }
    }
    
}
