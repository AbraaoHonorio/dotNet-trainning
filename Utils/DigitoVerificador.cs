  private string digitoVerificador(string sequencia)
  {
          return this.Modulo10(sequencia).ToString();
  }

  private int Modulo10(string sequencia)
  {
            int soma = 0, resto = 0, dac = 0;
            int pesos = 1;
         
            for (int i = 0; i < sequencia.Length; i++)
            {
                //Se i for um numero par, peso = 2
                if (i % 2 == 0)
                    pesos = 2;
                else
                    pesos = 1;

                int valorInt = Convert.ToInt32(sequencia[i].ToString());
                string resultado = (valorInt * pesos).ToString();

                if (resultado.ToString().Length > 1) // verifica se o resultado tem 2 digitos 
                {
                    soma += Convert.ToInt32(resultado[0].ToString());
                    soma += Convert.ToInt32(resultado[1].ToString());
                }

                else
                    soma += valorInt * pesos;
            }

            resto = soma % 10;

            
            if (resto == 0)
                return dac;

            else
                return (dac = 10 - resto);

  }
