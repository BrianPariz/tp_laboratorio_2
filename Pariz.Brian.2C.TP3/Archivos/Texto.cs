using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda un archivo de texto en la direccion ingresada, con los datos ingresados
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si lo creo correctamente, false si no</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                if (!File.Exists(archivo))
                {
                    using (StreamWriter sw = new StreamWriter(archivo))
                    {
                        sw.WriteLine(datos);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(archivo))
                    {
                        sw.WriteLine(datos);
                    }
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            if (File.Exists(archivo))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Lee un archivo de texto en la direccion ingresada y retorna los datos leídos
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si leyó los datos, falso si no</returns>
        public bool Leer(string archivo, out string datos)
        {
            datos = "";

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            if (datos != "")
                return true;
            else
                return false;
        }
    }
}
