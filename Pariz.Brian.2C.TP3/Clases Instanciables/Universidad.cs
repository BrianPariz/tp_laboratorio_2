using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using EntidadesAbstractas;
using Archivos;

namespace EntidadesInstanciables
{
    public class Universidad
    {
        public enum EClases { Laboratorio, SPD, Legislacion, Programacion }

        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }

            set { this.alumnos = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }

            set { this.jornadas = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }

            set { this.profesores = value; }
        }

        /// <summary>
        /// Indexador
        /// </summary>
        /// <param name="i"></param>
        /// <returns>Devuelve o ingresa una jornada en la posición indicada</returns>
        public Jornada this[int i]
        {
            get { return this.jornadas[i]; }

            set { this.jornadas[i] = value; }
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Son iguales si la universidad contiene al alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>true si lo contiene, false si no</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.alumnos)
            {
                if (item == a && a != null)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Son diferentes si la universidad no contiene al alumno
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>false si lo contiene, true si no</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Agrega al alumno a la universidad si este no esta repetido, sino tira una excepcion
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns>la universidad si es que no lo contiene</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a && a != null)
                g.Alumnos.Add(a);
            else
                throw new AlumnoRepetidoException();

            return g;
        }

        /// <summary>
        /// Son iguales si la universidad contiene al profesor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>true si lo contiene, false si no</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == i)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Son diferentes si la universidad no contiene al profesor
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>false si lo contiene, true si no</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega al profesor a la universidad si este no esta repetido
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns>la universidad con el profesor si es que no esta repetido</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i && i != null) 
                g.Instructores.Add(i);

            return g;
        }

        /// <summary>
        /// Son iguales si la universidad tiene un profesor que puede dar la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>el profesor que puede dar la clase, sino una exception</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item == clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Son diferentes si la universidad tiene un profesor que no puede dar la clase
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>profesor que no da esa clase, sino una exception</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor item in g.Instructores)
            {
                if (item != clase)
                {
                    return item;
                }
            }

            throw new SinProfesorException();
        }

        /// <summary>
        /// Crea una jornada, si hay profesores que puedan dar la clase y si hay alumnos también
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns>La universidad con la jornada si es que fue posible crearla</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor i = null;
            List<Alumno> a = new List<Alumno>();

            i = (g == clase);

            foreach (Alumno alumno in g.Alumnos)
            {
                if(alumno == clase && i != alumno)
                {
                    a.Add(alumno);
                }
            }

            Jornada _jornada = new Jornada(clase, i)
            {
                Alumnos = a
            };

            if(a.Count != 0 && i != null)
                g.Jornadas.Add(_jornada);

            return g;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto que inicializa las listas
        /// </summary>
        public Universidad()
        {
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
            this.Alumnos = new List<Alumno>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos de las jornadas
        /// </summary>
        /// <returns>string con los datos</returns>
        private string MostrarDatos()
        {
            StringBuilder aux = new StringBuilder();

            foreach (Jornada item in this.jornadas)
            {
                aux.AppendLine(item.ToString());
            }

            return aux.ToString();
        }

        /// <summary>
        /// Sobreescritura del metodo ToString con los datos adquiridos del metodo MostrarDatos
        /// </summary>
        /// <returns>string con los datos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Guarda la universidad en un archivo xml serializado
        /// </summary>
        /// <param name="gim"></param>
        /// <returns>true si salió todo bien, false si no</returns>
        public static bool Guardar(Universidad gim)
        {
            Xml<string> archivo = new Xml<string>();

            if (archivo.Guardar("../../../ Universidad.xml", gim.ToString()))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Lee un archivo Xml serializado
        /// </summary>
        /// <returns>true si salió todo bien, false si no</returns>
        public static string Leer()
        {
            Xml<string> archivo = new Xml<string>();

            if (archivo.Leer("../../../ Universidad.xml", out string aux))
                return aux;
            else
                return "";
        }

        #endregion
    }
}
