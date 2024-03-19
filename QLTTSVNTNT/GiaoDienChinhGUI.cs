using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTTSVNTNT
{
    public partial class GiaoDienChinhGUI : Form
    {
        public GiaoDienChinhGUI()
        {
            InitializeComponent();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhanVienGUI gui = new NhanVienGUI();
            gui.MdiParent = this;
            gui.Show();
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhoaGUI gui = new KhoaGUI();
            gui.MdiParent = this;
            gui.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SinhVienGUI gui = new SinhVienGUI();
            gui.MdiParent = this;
            gui.Show();
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LopGUI gui = new LopGUI();
            gui.MdiParent = this;
            gui.Show();
        }

    

        private void nộiTrúToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoiNgoaiTruGUI gui = new NoiNgoaiTruGUI();
            gui.MdiParent = this;
            gui.Show();
        }

        private void sốLượngSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BaoCaoGUI gui = new BaoCaoGUI();
            gui.MdiParent = this;
            gui.Show();
        }
    }
}
