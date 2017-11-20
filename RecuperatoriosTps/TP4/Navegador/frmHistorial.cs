using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";
        private List<string> listaHistorial;

        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga el historial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);

            if (archivos.Leer(out this.listaHistorial))
            {
                foreach (string url in this.listaHistorial)
                {
                    if(! object.ReferenceEquals(url, null))
                    {
                        lstHistorial.Items.Add(url);
                    }
                }
            }
            else
            {
                MessageBox.Show("Hubo un error al cargar el historial", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
