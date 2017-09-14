using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_tp1BrianPariz
{
    class Numero
    {
        private double numero;

        //obtiene el numero
        public double GetNumero()
        {
            return numero;
        }

        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Numero()
        {
            numero = 0;
        }

        /// <summary>
        /// constructor con ingreso de numero
        /// </summary>
        /// <param name="num"></param>
        public Numero(double num)
        {
            numero = num;
        }

        /// <summary>
        /// constructor con ingreso de string
        /// </summary>
        /// <param name="num"></param>
        public Numero(string num)
        {
            SetNumero(num);
        }

        /// <summary>
        /// ingresa un string como numero y lo valida
        /// </summary>
        /// <param name="num"></param>
        private void SetNumero(string num)
        {
            numero = ValidarNumero(num);
        }

        /// <summary>
        /// valida el string y lo convierte a double
        /// </summary>
        /// <param name="num"></param>
        /// <returns>double validado</returns>
        private double ValidarNumero(string num)
        {
            double auxNum;

            if (!double.TryParse(num, out auxNum))
            { 
                auxNum = 0; 
            }
                
            return auxNum;
        }
    }
}
