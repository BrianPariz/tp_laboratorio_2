using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_tp1BrianPariz
{
    class Calculadora
    {
        /// <summary>
        /// Se hacen las operaciones matemáticas
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns> de ser posible, el resultado, sino retorna 0</returns>
        public double Operar(Numero numero1, Numero numero2, string operador)
        {
            double auxResultado = 0;

            operador = ValidarOperador(operador);

            if (operador == "+")
                auxResultado = numero1.GetNumero() + numero2.GetNumero();
            if (operador == "-")
                auxResultado = numero1.GetNumero() - numero2.GetNumero();
            if (operador == "*")
                auxResultado = numero1.GetNumero() * numero2.GetNumero();
            if (operador == "/")
                if (numero2.GetNumero() != 0)
                    auxResultado = numero1.GetNumero() / numero2.GetNumero();
                else
                    auxResultado = 0;

            return auxResultado;
        }

        /// <summary>
        /// valida que se ingrese un operador válido
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>El operador ingresado y en caso contrario el operador + </returns>
        public string ValidarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
                operador = "+";

                return operador;
        }
    }
}
