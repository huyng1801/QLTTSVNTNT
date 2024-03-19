using BLL;
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
    public partial class ChonSinhVienGUI : Form
    {

        private NoiNgoaiTruGUI noiTruGUI;
        private string maKhoa;
        public ChonSinhVienGUI(NoiNgoaiTruGUI noiTruGUI, string maKhoa)
        {
            InitializeComponent();
      
            this.noiTruGUI = noiTruGUI;
            this.maKhoa = maKhoa;
        }
        private void LoadData()
        {
            string maLop = cboLop.SelectedValue != null ? cboLop.SelectedValue.ToString() : "";
            DataTable dt = SinhVienBLL.ReadAllForTable(maLop);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["MaSinhVien"].HeaderText = "Mã sinh viên";
            dataGridView1.Columns["HoTen"].HeaderText = "Họ tên";
            dataGridView1.Columns["TenLop"].HeaderText = "Tên lớp";
            dataGridView1.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["GioiTinh"].HeaderText = "Giới tính";
            dataGridView1.Columns["DanToc"].HeaderText = "Dân tộc";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["Email"].HeaderText = "Email";
        }

        private void LoadDataComboBox()
        {
            DataTable dt = LopBLL.ReadAllForTable(maKhoa);
            cboLop.DataSource = dt;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

        }
        private void ChonSinhVienGUI_Load(object sender, EventArgs e)
        {
            LoadDataComboBox();
            LoadData();

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string maLop = cboLop.SelectedValue != null ? cboLop.SelectedValue.ToString() : "";
            DataTable lst = SinhVienBLL.FindBySinhVien(maLop, txtTimKiem.Text);
            dataGridView1.DataSource = lst;

            dataGridView1.Columns["MaSinhVien"].HeaderText = "Mã sinh viên";
            dataGridView1.Columns["HoTen"].HeaderText = "Họ tên";
            dataGridView1.Columns["TenLop"].HeaderText = "Tên lớp";
            dataGridView1.Columns["NgaySinh"].HeaderText = "Ngày sinh";
            dataGridView1.Columns["GioiTinh"].HeaderText = "Giới tính";
            dataGridView1.Columns["DanToc"].HeaderText = "Dân tộc";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["Email"].HeaderText = "Email";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy giá trị từ cột tương ứng
                string maSinhVien = row.Cells["MaSinhVien"].Value.ToString();
                SinhVienDTO sinhVien = SinhVienBLL.FindByMaSinhVien(maSinhVien);

                    noiTruGUI.ChonSinhVien(sinhVien);
                
                this.Hide();

            }
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
