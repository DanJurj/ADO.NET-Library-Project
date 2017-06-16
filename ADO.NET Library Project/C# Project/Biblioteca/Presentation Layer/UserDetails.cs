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
    public partial class UserDetails : Form
    {
        BusinessLayer _leg = new BusinessLayer();
        public UserDetails(int id)
        {
            InitializeComponent();
            dgv_userDetails.DataSource = _leg.GetUserDetails(id);
            dgv_userPerm.DataSource = _leg.GetUserPermissions(id);
        }
    }
}
