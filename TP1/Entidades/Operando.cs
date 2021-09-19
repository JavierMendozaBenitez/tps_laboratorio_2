using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        public Operando()
            : this(0)
        { }

        public Operando(double numero)
        {
            this.numero = numero;
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        private double ValidarOperando(string strNumero)
        {
            double retorno = 0;

            if(double.TryParse(strNumero, out retorno))
            {
                return retorno;
            }
            else
            {
                return retorno;
            }
        }

        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(Convert.ToString(value));
            }
        }

        private bool EsBinario(string binario)
        {
            bool retorno = false;
            int cantidadCaracteres = binario.Length;
            
            foreach (char caracter in binario)
            {
                if (caracter != '1' && caracter != '0')
                {
                    retorno = false;
                    break;
                }
                else
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        public string BinarioDecimal(string binario)
        {
            double decimalConver = 0;
            string resultado = "Valor inválido";

            if(EsBinario(binario))
            {
                int cantidadCaracteres = binario.Length;
                foreach (char caracter in binario)
                {
                    cantidadCaracteres--;
                    if (caracter == '1')
                    {
                        decimalConver += (int)Math.Pow(2, cantidadCaracteres);
                    }
                }
                resultado = decimalConver.ToString();
            }
            return resultado;
        }

        public string DecimalBinario(double numero)
        {
            string valorBinario = string.Empty;
            int resultDiv = (int)numero;
            int restoDiv;

            resultDiv = Math.Abs(resultDiv);

            if (resultDiv > 0)
            {
                do
                {
                    restoDiv = resultDiv % 2;
                    resultDiv /= 2;
                    valorBinario = restoDiv.ToString() + valorBinario; 
                } while (resultDiv > 0);
            }
            else
            {
                valorBinario = "Valor inválido";
            }
                   
            return valorBinario;
        }

        public string DecimalBinario(string numero)
        {
            string valorBinario = string.Empty; 
            int resultDiv;
            int restoDiv;

            if (int.TryParse(numero, out resultDiv))
            {
                if (Math.Abs(resultDiv) > 0)
                {
                    do
                    {
                        restoDiv = resultDiv % 2;
                        resultDiv /= 2;
                        valorBinario = restoDiv.ToString() + valorBinario;
                    } while (resultDiv > 0);
                }
                else
                {
                    valorBinario = "Valor inválido";
                }
            }

            return valorBinario;
        }

        public static double operator - (Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            double retorno;

            if(n2.numero == 0)
            {
                retorno = double.MinValue;
            }
            else
            {
                retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
    }
}
