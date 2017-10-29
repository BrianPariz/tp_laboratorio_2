using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Text.RegularExpressions;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad { Argentino, Extranjero }


        #region Atributos

        private string _nombre;
        private string _apellido;
        private EntidadesAbstractas.Persona.ENacionalidad _nacionalidad;
        private int _dni;

        #endregion

        #region Propiedades

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = ValidarNombreApellido(value);
            }
        }

        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = ValidarNombreApellido(value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }

            set
            {
                this._dni = ValidarDni(this.Nacionalidad, value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this._dni = ValidarDni(this.Nacionalidad, value);
            }

        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona() { }

        /// <summary>
        /// constructor base
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, EntidadesAbstractas.Persona.ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que inicializa un dni pasado como entero, reutiliza el constructor base
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, int dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor que inicializa un dni pasado como string, reutiliza el constructor base
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region "Validadores"

        /// <summary>
        /// Validará que el DNI esté dentro de los rangos permitidos
        /// </summary>
        /// <param name="dato">DNI numérico a validar</param>
        /// <returns>DNI validado si está todo OK, o 0 (cero) en caso de error</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato >= 1 && dato <= 99999999)
            {
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (dato < 1 || dato > 89999999)
                            throw new NacionalidadInvalidaException(dato.ToString());
                        break;
                    case ENacionalidad.Extranjero:
                        if (dato < 89999999 || dato > 99999999)
                            throw new NacionalidadInvalidaException();
                        break;
                }
            }
            else
                throw new DniInvalidoException();

            return dato;
        }

        /// <summary>
        /// Validará que el DNI sea numérico, y luego llamará a la validación numérica
        /// </summary>
        /// <param name="dato">DNI string a validar</param>
        /// <returns>DNI validado si está todo OK, o 0 (cero) en caso de error</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            // Quito los . que pueda tener el número
            dato = dato.Replace(".", "");
            // Compruebo que tenga al menos 1 caracter y no más de 8, dados por el número 99.999.999
            if (dato.Length < 1 || dato.Length > 8)
                throw new DniInvalidoException(dato.ToString());
            int numeroDni;

            try
            {
                numeroDni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }

            return ValidarDni(nacionalidad, numeroDni);
        }

        /// <summary>
        /// Validará que el nombre esté compuesto solo por caracteres latinos a-z A-Z
        /// </summary>
        /// <param name="dato">Nombre o apellido a validar</param>
        /// <returns>Nombre o apellido validado si está todo OK, o un string vacio en caso de error</returns>
        private string ValidarNombreApellido(string dato)
        {
            // Expresión regular para buscar solo caracteres de la a a la z minúsculas y mayúsculas con N repeticiones
            Regex regex = new Regex(@"[a-zA-Z]*");
            // Valido el dato
            Match match = regex.Match(dato);

            if (match.Success)
                return match.Value;
            else
                return "";
        }

        #endregion

        /// <summary>
        /// Sobrescritura del metodo ToString para mostrar los datos de la clase
        /// </summary>
        /// <returns>Los datos de su clase como string</returns>
        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine("NOMBRE COMPLETO: " + this.Nombre + ", " + this.Apellido);
            aux.AppendLine("NACIONALIDAD: " + this.Nacionalidad);

            return aux.ToString();
        }
    }
}