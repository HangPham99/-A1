using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuongCongTy
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            frmNhanVien frm1 = new frmNhanVien();
            frm1.Show();

        }

        private void sắpTăngMapbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private void maxLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaxLuong frm = new frmMaxLuong();
            frm.Show();
        }

        private void maxLươngMỗiPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMaxLuongMoiPhongBan frm = new frmMaxLuongMoiPhongBan();
            frm.Show();
        }
    }
}
