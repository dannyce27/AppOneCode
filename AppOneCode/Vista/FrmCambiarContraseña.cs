using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppOneCode.Vista
{
    public partial class FrmCambiarContraseña : Form
    {
        public FrmCambiarContraseña()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmCambiarContraseña
            // 
            this.ClientSize = new System.Drawing.Size(546, 321);
            this.Name = "FrmCambiarContraseña";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCambiarContraseña_Load);
            this.ResumeLayout(false);

        }

        private void FrmCambiarContraseña_Load(object sender, EventArgs e)
        {

        }
    }
}
