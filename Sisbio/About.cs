using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public partial class About : Form
    {
        public About()
        {
            // Inicializa os componentes
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Abre o link no navegador padrão
            System.Diagnostics.Process.Start("http://www.gnu.org/licenses/");
        }
    }
}
