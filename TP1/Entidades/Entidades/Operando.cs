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
            : this(double.Parse(strNumero))
        { }

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
                this.numero = ValidarOperando(this.numero.ToString());
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
            string valorBinario = string.Empty; //variable que vamos a retornar
            int resultDiv = (int)numero;
            int restoDiv;
            //Generamos dos variables una para verificar si el resultado de la division es igual a 0 y otra para verificar el resto

            if(Math.Abs(resultDiv) > 0)
            {
                do
                {
                    restoDiv = resultDiv % 2;
                    resultDiv /= 2;
                    valorBinario = restoDiv.ToString() + valorBinario; // lo hago de esta manera para ir dejando la ultima division en la primer posicion
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
            string valorBinario = string.Empty; //variable que vamos a retornar
            //int resultDiv = (int)numero;
            int resultDiv;
            int restoDiv;
            //Generamos dos variables una para verificar si el resultado de la division es igual a 0 y otra para verificar el resto

            if (int.TryParse(numero, out resultDiv))
            {
                if (Math.Abs(resultDiv) > 0)
                {
                    do
                    {
                        restoDiv = resultDiv % 2;
                        resultDiv /= 2;
                        valorBinario = restoDiv.ToString() + valorBinario; // lo hago de esta manera para ir dejando la ultima division en la primer posicion
                    } while (resultDiv > 0);
                }
                else
                {
                    valorBinario = "Valor inválido";
                }
            }

            return valorBinario;
        }

        /*public string BinarioDecimal(string binario)
        {
            int numero;

            if(int.TryParse(binario, out numero))
            {
                Math.Abs(numero);
            }

            return "";
        }*/

        public static double operator - (Operando n1, Operando n2)
        {
            return n1 - n2;
        }
        public static double operator +(Operando n1, Operando n2)
        {
            return n1 + n2;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1 * n2;
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
