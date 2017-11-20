using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this._alumnos;  }

            set { this._alumnos = value; }
        }

        public Universidad.EClases Clase
        {
            get { return this._clase; }

            set { this._clase = value; }
        }

        public Profesor Instructor
        {
            get { return this._instructor; }

            set { this._instructor = value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto que inicializa la lista de alumnos
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor que inciializa la clase y el instructor, reutiliza el constructor por defecto
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion

        #region Operadores

        /// <summary>
        /// Verifica si el alumno se encuentra en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>true si se encuentra, false si no</returns>
        public static bool operator ==(Jornada j, Alumno a) 
        {
            foreach (Alumno item in j.Alumnos)
            {
                if(item == a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Verifica si el alumno no se encuentra en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>false si se encuentra, true si no</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Si el alumno no se encuentra en la jornada, lo ingresa
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j.Alumnos.Add(a);

            return j;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Sobreescritura del metodo ToString que muestra los datos de la jornada, con el profesor y los alumnos
        /// </summary>
        /// <returns>string con todos los datos</returns>
        public override string ToString()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine("JORNADA:");
            aux.AppendLine("CLASE DE: " + this.Clase.ToString() + " POR " + this._instructor.ToString());

            aux.AppendLine("ALUMNOS:");
            foreach (Alumno item in Alumnos)
            {
                aux.AppendLine(item.ToString());
            }
            aux.AppendLine("<------------------------------------------------------------>");

            return aux.ToString();
        }

        /// <summary>
        /// Guarda una jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>true si salió todo bien, false si no</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivo = new Texto();

            if (archivo.Guardar("Jornada.txt", jornada.ToString()))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Lee un archivo de texto previamente guardado como Jornada.txt
        /// </summary>
        /// <returns>true si salió todo bien, false si no</returns>
        public static string Leer()
        {
            Texto archivo = new Texto();
            string aux;

            if (archivo.Leer("Jornada.txt", out aux))
                return aux;
            else
                return "";
        }

        #endregion 
    }
}
