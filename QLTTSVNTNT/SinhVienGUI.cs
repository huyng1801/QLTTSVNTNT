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
    public partial class SinhVienGUI : Form
    {
        public SinhVienGUI()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            string maLop = cboLop.SelectedValue != null ? cboLop.SelectedValue.ToString() : "";
            DataTable dt= SinhVienBLL.ReadAllForTable(maLop);
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
            List<LopDTO> lst = LopBLL.ReadAll();
            cboLop.DataSource = lst;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaSinhVien.Text) && !string.IsNullOrEmpty(txtTenSinhVien.Text) && cboLop.SelectedValue != null && !string.IsNullOrEmpty(txtDanToc.Text) && !string.IsNullOrEmpty(txtDiaChi.Text) && !string.IsNullOrEmpty(txtSoDienThoai.Text) && !string.IsNullOrEmpty(txtEmail.Text))
            {
                SinhVienDTO sinhVien = new SinhVienDTO();
                sinhVien.MaSinhVien = txtMaSinhVien.Text;
                sinhVien.HoTen = txtTenSinhVien.Text;
                sinhVien.MaLop = cboLop.SelectedValue.ToString();
                sinhVien.NgaySinh = dateNgaySinh.Value;
                sinhVien.GioiTinh = rbtnNam.Checked;
                sinhVien.DanToc = txtDanToc.Text;
                sinhVien.DiaChi = txtDiaChi.Text;
                sinhVien.SoDienThoai = txtSoDienThoai.Text;
                sinhVien.Email = txtEmail.Text;
                if (SinhVienBLL.FindByMaSinhVien(sinhVien.MaSinhVien) != null)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!");
                    return;
                }
                if (SinhVienBLL.Insert(sinhVien) > 0)
                {
                    MessageBox.Show("Thêm sinh viên thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên không thành công!");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy giá trị từ cột tương ứng
                string maSinhVien = row.Cells["MaSinhVien"].Value.ToString();
                SinhVienDTO sinhVien = SinhVienBLL.FindByMaSinhVien(maSinhVien);

                // Gán giá trị vào các TextBox hoặc các control khác
                txtMaSinhVien.Text = sinhVien.MaSinhVien;
                txtTenSinhVien.Text = sinhVien.HoTen;
                cboLop.SelectedValue = sinhVien.MaLop;
                dateNgaySinh.Value = sinhVien.NgaySinh;
                rbtnNam.Checked = sinhVien.GioiTinh;
                rbtnNu.Checked = !sinhVien.GioiTinh;
                txtDanToc.Text = sinhVien.DanToc;
                txtDiaChi.Text = sinhVien.DiaChi;
                txtSoDienThoai.Text = sinhVien.SoDienThoai;
                txtEmail.Text = sinhVien.Email;

            }
        }
        private void Clear()
        {
            txtMaSinhVien.Text = string.Empty;
            txtTenSinhVien.Text = string.Empty;
           
            dateNgaySinh.Value = DateTime.Now;
            rbtnNam.Checked = true;
            rbtnNu.Checked = false;
            txtDanToc.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;
            txtEmail.Text = string.Empty;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaSinhVien.Text) && !string.IsNullOrEmpty(txtTenSinhVien.Text) && cboLop.SelectedValue != null && !string.IsNullOrEmpty(txtDanToc.Text) && !string.IsNullOrEmpty(txtDiaChi.Text) && !string.IsNullOrEmpty(txtSoDienThoai.Text) && !string.IsNullOrEmpty(txtEmail.Text))
            {
                SinhVienDTO sinhVien = new SinhVienDTO();
                sinhVien.MaSinhVien = txtMaSinhVien.Text;
                sinhVien.HoTen = txtTenSinhVien.Text;
                sinhVien.MaLop = cboLop.SelectedValue.ToString();
                sinhVien.NgaySinh = dateNgaySinh.Value;
                sinhVien.GioiTinh = rbtnNam.Checked;
                sinhVien.DanToc = txtDanToc.Text;
                sinhVien.DiaChi = txtDiaChi.Text;
                sinhVien.SoDienThoai = txtSoDienThoai.Text;
                sinhVien.Email = txtEmail.Text;
                if (SinhVienBLL.FindByMaSinhVien(sinhVien.MaSinhVien) == null)
                {
                    MessageBox.Show("Mã sinh viên không tồn tại!");
                    return;
                }
                if (SinhVienBLL.Update(sinhVien) > 0)
                {
                    MessageBox.Show("Cập nhật sinh viên thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật sinh viên không thành công!");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaSinhVien.Text != "")
            {
                string maSinhVien = txtMaSinhVien.Text;

                if (SinhVienBLL.Delete(maSinhVien) > 0)
                {
                    LoadData();
                    MessageBox.Show("Đã xóa sinh viên.");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Xóa sinh viên không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDataComboBox();
            LoadData();
            Clear();
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

        private void SinhVienGUI_Load(object sender, EventArgs e)
        {
          
            LoadDataComboBox();
            LoadData();
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
