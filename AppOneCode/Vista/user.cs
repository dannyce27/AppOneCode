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
    public partial class user : UserControl
    {

        private int id;
        private string name;
       

       
        public user()
        {
            InitializeComponent();
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;

            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }


        private void user_Load(object sender, EventArgs e)
        {

        }
    }
}
