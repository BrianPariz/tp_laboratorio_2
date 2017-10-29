using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor estatico que inicializa el atributo estatico Random
        /// </summary>
        static Profesor()
        {
            Profesor._random = new Random();
        }

        /// <summary>
        /// Constructor por defecto que utiliza el constructor base por defecto
        /// </summary>
        private Profesor() : base()
        {
        }

        /// <summary>
        /// Constructor con los datos para llenar su clase, y la clase base, también le agrega dos clasesDelDía mediante el metodo RandomClases
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, EntidadesAbstractas.Persona.ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClases();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Aleatoreamente le agrega dos clases a un profesor
        /// </summary>
        private void RandomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                int aux = Profesor._random.Next(1, 5);

                switch (aux)
                {
                    case 1:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);

                        break;
                    case 2:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Legislacion);

                        break;
                    case 3:
                        this._clasesDelDia.Enqueue(Universidad.EClases.Programacion);

                        break;
                    default:
                        this._clasesDelDia.Enqueue(Universidad.EClases.SPD);

                        break;
                }
            }
        }

        /// <summary>
        /// Muestra los datos de su clase y sus clases base
        /// </summary>
        /// <returns>retorna una cadena de string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine(base.MostrarDatos());
            aux.AppendFormat(this.ParticiparEnClase());

            return aux.ToString();
        }

        /// <summary>
        /// Sobrescritura de ToString para mostrar los datos mediante el metodo MostrarDatos
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Muestra las clases que tiene el profesor en el día
        /// </summary>
        /// <returns>Cadena con las clases</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder aux = new StringBuilder();

            aux.AppendLine("CLASES DEL DÍA: ");

            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                aux.AppendLine(item.ToString());
            }

            return aux.ToString();
        }

        #endregion

        #region Operadores

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            if (i._clasesDelDia != null)
            {
                foreach (Universidad.EClases item in i._clasesDelDia)
                {
                    if (item == clase)
                        return true;
                }
            }

            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
