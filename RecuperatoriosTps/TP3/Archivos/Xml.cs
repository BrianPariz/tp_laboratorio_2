using Excepciones;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa los datos ingresados en un archivo XML en la dirección ingresada
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>true si lo creo correctamente, false si no</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, null))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, datos);
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
        /// Lee un archivo XML en la direccion ingresada y retorna los datos descerializados
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns>True si leyó los datos, falso si no</returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    datos = (T)ser.Deserialize(reader);
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            if (datos != null)
                return true;
            else
                return false;
        }
    }
}
