using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta { AlDia, Deudor, Becado }

        #region Atributos

        private Universidad.EClases _ClaseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// constructor que inicializa su clase y la clase base, ademas de la clase que toma
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        public Alumno(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._ClaseQueToma = claseQueToma;
        }

        /// <summary>
        /// constructor que inicializa su clase y la clase base utilizando su otro constructor, también indica el estado de la cuenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="claseQueToma"></param>
        /// <param name="estadoCuenta"></param>
        public Alumno(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos de su clase y sus clases base
        /// </summary>
        /// <returns>Retorna los datos en string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine(base.MostrarDatos());

            if(this._estadoCuenta == EEstadoCuenta.AlDia)
                aux.AppendLine("ESTADO DE CUENTA: Cuota al día");
            else
                aux.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);

            aux.AppendLine(this.ParticiparEnClase());

            return aux.ToString();
        }

        /// <summary>
        /// sobrescritura del metodo ToString que utiliza el metodo privado MostrarDatos
        /// </summary>
        /// <returns>Retorna los datos en string</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Indica la clase que toma el alumno
        /// </summary>
        /// <returns>string</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASES DE: " + this._ClaseQueToma.ToString();
        }

        #endregion

        #region Operadores

        /// <summary>
        /// verifica si el alumno toma una clase, y si no es deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true si no es deudor y toma la clase, false lo contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a._estadoCuenta != EEstadoCuenta.Deudor && a._ClaseQueToma == clase)
                return true;
            else
                return false;
        }

        /// <summary>
        /// verifica si el alumno no toma una clase o si es deudor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>true es deudor o no toma la clase, false lo contrario</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

        #endregion
    }
}
