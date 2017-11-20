using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public delegate void ProgresoDescarga(int progreso);
    public delegate void FinDescarga(string html);

    public class Descargador
    {
        private string html;
        private Uri direccion;
        
        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }
        
        /// <summary>
        /// utiliza el servicio web para descargar el codigo html de una pagina
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                using (WebClient cliente = new WebClient())
                {
                    cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                    cliente.DownloadStringCompleted += WebClientDownloadCompleted;
                    cliente.DownloadStringAsync(this.direccion);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public event ProgresoDescarga EventoProgreso;

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.EventoProgreso.Invoke(e.ProgressPercentage);
        }

        public event FinDescarga EventoCompleto;

        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
                EventoCompleto.Invoke(this.html);
            }
            catch (Exception)
            {
                EventoCompleto.Invoke("ERROR");
            }
        }
    }
}
