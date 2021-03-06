﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string archivo;

        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        /// <summary>
        /// Guarda un archivo de texto en la direccion del archivo
        /// </summary>
        /// <param name="datos"></param>
        /// <returns>true si lo creo correctamente, false si no</returns>
        public bool Guardar(string datos)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(archivo))
                {
                    sw.WriteLine(datos);
                }
                    return true;
            }
            catch (Exception)
            {
                return false; ;
            }
        }

        /// <summary>
        /// Lee un archivo de texto y retorna los datos leídos en una cadena
        /// </summary>
        /// <param name="datos"></param>
        /// <returns>True si leyó bien los datos, falso si no</returns>
        public bool Leer(out List<string> datos)
        {
            datos = new List<string>();
            string line;
            int i = 0;

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        datos.Add(sr.ReadLine());
                        i++;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
