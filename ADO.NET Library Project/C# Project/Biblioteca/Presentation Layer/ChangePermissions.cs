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
    public partial class ChangePermissions : Form
    {
        private BusinessLayer _leg = new BusinessLayer();
        private int id_user;
        MainForm _form;
        public ChangePermissions(MainForm frm,int id_userCurent)
        {
            InitializeComponent();
            LockButtons();
            dgv_user.DataSource = _leg.GetUser2();
            _form = frm;
            if (id_userCurent == 1)
                btn_delUser.Enabled = true;
            else
                btn_delUser.Enabled = false;
        }
        public void LockButtons()
        {
            btn_add0.Enabled = false;
            btn_add1.Enabled = false;
            btn_add2.Enabled = false;
            btn_add3.Enabled = false;
            btn_add4.Enabled = false;
            btn_rem0.Enabled = false;
            btn_rem1.Enabled = false;
            btn_rem2.Enabled = false;
            btn_rem3.Enabled = false;
            btn_rem4.Enabled = false;
        }
        public void UnlockButtons()
        {
            btn_add0.Enabled = true;
            btn_add1.Enabled = true;
            btn_add2.Enabled = true;
            btn_add3.Enabled = true;
            btn_add4.Enabled = true;
            btn_rem0.Enabled = true;
            btn_rem1.Enabled = true;
            btn_rem2.Enabled = true;
            btn_rem3.Enabled = true;
            btn_rem4.Enabled = true;
        }
        private int GetID_user()
        {
            string username = dgv_user.SelectedRows[0].Cells[0].Value.ToString();
            id_user = _leg.GetUserID2(username);
            return id_user;
        }
        private void RefreshPermissions()
        {
            string username = dgv_user.SelectedRows[0].Cells[0].Value.ToString();
            id_user = _leg.GetUserID2(username);
            dgv_permissions.DataSource = _leg.GetUserPermissions(id_user);
        }
        private void dgv_user_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.RowIndex != dgv_user.RowCount - 1)
            {
                RefreshPermissions();
                UnlockButtons();               
            }
        }

        private void btn_add1_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.AddPermission(id_user, 1);
            RefreshPermissions();
            _form.SetPermissions();
        }

        private void btn_add2_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.AddPermission(id_user, 2);
            RefreshPermissions();
            _form.SetPermissions();
        }

        private void btn_add3_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.AddPermission(id_user, 3);
            RefreshPermissions();
            _form.SetPermissions();
        }

        private void btn_add4_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.AddPermission(id_user, 4);
            RefreshPermissions();
            _form.SetPermissions();
        }

        private void btn_add0_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.AddPermission(id_user, 0);
            RefreshPermissions();
        }

        private void btn_rem1_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.RemovePermission(id_user, 1);
            RefreshPermissions();
            _form.SetPermissions();
        }

        private void btn_rem2_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.RemovePermission(id_user, 2);
            RefreshPermissions();
            _form.SetPermissions();
        }

        private void btn_rem3_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.RemovePermission(id_user, 3);
            RefreshPermissions();
            _form.SetPermissions();
        }

        private void btn_rem4_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.RemovePermission(id_user, 4);
            RefreshPermissions();
            _form.SetPermissions();
        }

        private void btn_rem0_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.RemovePermission(id_user, 0);
            RefreshPermissions();
            _form.SetPermissions();
        }

        private void btn_delUser_Click(object sender, EventArgs e)
        {
            int id_user = GetID_user();
            _leg.RemoveAllPermissions(id_user);
            _leg.RemoveUser(id_user);
            dgv_user.DataSource = _leg.GetUser2();
            RefreshPermissions();
        }
    }
}
