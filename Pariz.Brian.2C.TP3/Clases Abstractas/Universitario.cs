using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int _legajo;

        #region Metodos

        /// <summary>
        /// Sobrescritura del metodo Equals que verifica que el objeto recibido sea un universitario y que este sea igual al otro con el que se le compara
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true si son iguales, false si no</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario && this == (Universitario)obj)
                return true;
            else
                return false;
        }

        /// <summary>
        /// metodo que muestra los datos de su clase, y de su clase base
        /// </summary>
        /// <returns>todos los datos como string</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine(base.ToString());
            aux.AppendFormat("LEGAJO NÚMERO: " + this._legajo);

            return aux.ToString();
        }

        /// <summary>
        /// Metodo abstracto que se utilizará en las clases heredadas
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();

        #endregion

        #region Operadores

        /// <summary>
        /// Verifica si dos universitarios son iguales, por su dni o legajo
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>true si son iguales, false si no</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            try
            {
                if (pg1.DNI == pg2.DNI || pg1._legajo == pg2._legajo)
                    return true;
                else
                    return false;
            }
            catch(NullReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica si dos universitarios son diferentes, por su dni o legajo
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns>false si son iguales, true si no</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

        #region Constructores

        /// <summary>
        /// constructor por defecto que usa el constructor por defecto de la clase base
        /// </summary>
        public Universitario() : base() { }

        /// <summary>
        /// constructor con todos los datos para inicializar la clase y su clase base
        /// </summary>
        /// <param name="legajo"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Universitario(int legajo, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this._legajo = legajo;
        }

        #endregion
    }
}
