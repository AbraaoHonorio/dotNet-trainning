using System;

namespace CursoDesignPatterns
{
    public class CalculadorDeImpostos
    {

        public void RealizaCalculo(Orcamento orcamento, Imposto imposto)
        {
            Console.WriteLine("->" + imposto.Calcula(orcamento));

        }

    }
}
