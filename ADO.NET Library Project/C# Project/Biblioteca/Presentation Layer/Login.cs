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
    public partial class Login : Form
    {
        private BusinessLayer _legBusinessLayer = new BusinessLayer();
        public Login()
        {
            InitializeComponent();
            lbl_error.Hide();
        }
         protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if(Application.OpenForms.Count<=1)
                Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = tb_username.Text.ToString();
            string password = tb_password.Text.ToString();
            if (_legBusinessLayer.CheckCredentials(username, password))
            {
                MainForm main_form = new MainForm();
                main_form.Show();
                main_form.SetCurentUser(username, password);
                this.Close();
            }
            else
            {
                lbl_error.Show();
                tb_password.Text = "";
                tb_username.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewRegistration frame = new NewRegistration();
            frame.Show();
            this.Close();
        }
    }
}
