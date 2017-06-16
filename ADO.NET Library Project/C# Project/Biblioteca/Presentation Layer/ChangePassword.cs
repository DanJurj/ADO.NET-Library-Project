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
    public partial class ChangePassword : Form
    {
        private BusinessLayer _leg = new BusinessLayer();
        private int id_user;
        MainForm frm;
        public ChangePassword(int id,MainForm frame)
        {
            InitializeComponent();
            id_user = id;
            frm = frame;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPass = tb_pass.Text.ToString();
            if (_leg.ChangePassword(id_user, newPass))
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
