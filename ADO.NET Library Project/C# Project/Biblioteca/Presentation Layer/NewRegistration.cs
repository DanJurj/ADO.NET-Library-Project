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
    public partial class NewRegistration : Form
    {
        private BusinessLayer _legBusinessLayer = new BusinessLayer();
        public NewRegistration()
        {
            InitializeComponent();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (Application.OpenForms.Count <= 1)
                Application.Exit();
        }
        private void btn_register_Click(object sender, EventArgs e)
        {
            if (tb_cnp.Text == "" || tb_nume.Text == "" || tb_pass.Text == "" || tb_prenume.Text == "" || tb_username.Text == "")
            {
                MessageBox.Show("Va rugam completati toate campurile!");
                return;
            }
            if (_legBusinessLayer.NotUniqueUsername(tb_username.Text.ToString()))
            {
                MessageBox.Show("Acest Username este deja luat!\nVa rugam selectati altul!");
                return;
            }
            string nume = tb_nume.Text.ToString();
            string prenume = tb_prenume.Text.ToString();
            string cnp = tb_cnp.Text.ToString();
            string username = tb_username.Text.ToString();
            string pass = tb_pass.Text.ToString();
            if (_legBusinessLayer.CreateNewUser(nume, prenume, cnp, username, pass))
            {
                MessageBox.Show("Registration Succeded!");
                _legBusinessLayer.AddPermission(_legBusinessLayer.GetUserID(username, pass), 1);
            }
            else
                MessageBox.Show("Registration Failed!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login_frame = new Login();
            login_frame.Show();
            this.Close();
        }
    }
}
