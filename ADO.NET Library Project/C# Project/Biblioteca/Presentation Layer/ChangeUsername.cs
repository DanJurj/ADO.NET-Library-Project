using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca.Presentation_Layer
{
    public partial class ChangeUsername : Form
    {
        private BusinessLayer _leg = new BusinessLayer();
        private int id_user;
        MainForm frm;
        public ChangeUsername(int id,MainForm frame)
        {
            InitializeComponent();
            id_user = id;
            frm = frame;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newUsername = tb_newUsername.Text.ToString();
            if (_leg.ChangeUsername(id_user, newUsername))
            {
                MessageBox.Show("Operation Successful!");
                frm.RefreshCredentials();
                this.Close();
            }
            else
                MessageBox.Show("Operation Failed!");
        }
    }
}
