using CursoDesignPatterns.Decorator;


namespace CursoDesignPatterns.Decorator
{
    public class ICMS : Imposto
    {

        public ICMS(Imposto outroImposto) : base(outroImposto) { }
        public ICMS() : base() { }


        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.01 + CalculaDoOutroImposto(orcamento);
        }
    }
}
