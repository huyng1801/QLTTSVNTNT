using BLL;
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
    public partial class BaoCaoGUI : Form
    {
        public BaoCaoGUI()
        {
            InitializeComponent();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            DateTime thang = dateThang.Value;
            DataTable dt = KhoaBLL.ThongKeSinhVienByKhoaAndMonth(thang);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["MaKhoa"].HeaderText = "Mã khoa";
            dataGridView1.Columns["TenKhoa"].HeaderText = "Tên khoa";
            dataGridView1.Columns["SoLuongNoiTru"].HeaderText = "Số lượng nội trú";
            dataGridView1.Columns["SoLuongNgoaiTru"].HeaderText = "Số lượng ngoại trú";
        }
    }
}
