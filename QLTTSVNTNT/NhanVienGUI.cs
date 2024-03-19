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
    public partial class NhanVienGUI : Form
    {
        public NhanVienGUI()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            List<NhanVienDTO> lst = NhanVienBLL.ReadAll();
            dataGridView1.DataSource = lst;

            dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dataGridView1.Columns["HoTen"].HeaderText = "Tên nhân viên";
            dataGridView1.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["Email"].HeaderText = "Email";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dataGridView1.Columns["MatKhau"].Visible = false;
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaNhanVien.Text) && !string.IsNullOrEmpty(txtTenNV.Text) && !string.IsNullOrEmpty(txtSoDienThoai.Text) && !string.IsNullOrEmpty(txtDiaChi.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtMatKhau.Text))
            {
                NhanVienDTO nhanVien = new NhanVienDTO();
                nhanVien.MaNhanVien = txtMaNhanVien.Text;
                nhanVien.HoTen = txtTenNV.Text;
                nhanVien.SoDienThoai = txtSoDienThoai.Text;
                nhanVien.Email = txtEmail.Text;
                nhanVien.DiaChi = txtDiaChi.Text;
                nhanVien.MatKhau = txtMatKhau.Text;
                if (NhanVienBLL.FindByMaNhanVien(nhanVien.MaNhanVien) != null)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!");
                    return;
                }
                if (NhanVienBLL.Insert(nhanVien) > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên không thành công!");
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
                string maNhanVien = row.Cells["MaNhanVien"].Value.ToString();
                NhanVienDTO nhanVien = NhanVienBLL.FindByMaNhanVien(maNhanVien);

                // Gán giá trị vào các TextBox hoặc các control khác
                txtMaNhanVien.Text = nhanVien.MaNhanVien;
                txtTenNV.Text = nhanVien.HoTen;
                txtSoDienThoai.Text = nhanVien.SoDienThoai;
                txtEmail.Text = nhanVien.Email;
                txtDiaChi.Text = nhanVien.DiaChi;
                txtMatKhau.Text = nhanVien.MatKhau;
            }
        }
        private void Clear()
        {
            txtMaNhanVien.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSoDienThoai.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaNhanVien.Text) && !string.IsNullOrEmpty(txtTenNV.Text) && !string.IsNullOrEmpty(txtSoDienThoai.Text) && !string.IsNullOrEmpty(txtDiaChi.Text) && !string.IsNullOrEmpty(txtEmail.Text) && !string.IsNullOrEmpty(txtMatKhau.Text))
            {
                NhanVienDTO nhanVien = new NhanVienDTO();
                nhanVien.MaNhanVien = txtMaNhanVien.Text;
                nhanVien.HoTen = txtTenNV.Text;
                nhanVien.SoDienThoai = txtSoDienThoai.Text;
                nhanVien.Email = txtEmail.Text;
                nhanVien.DiaChi = txtDiaChi.Text;
                nhanVien.MatKhau = txtMatKhau.Text;
                if (NhanVienBLL.FindByMaNhanVien(nhanVien.MaNhanVien) == null)
                {
                    MessageBox.Show("Mã nhân viên đã không tồn tại!");
                    return;
                }
                if (NhanVienBLL.Update(nhanVien) > 0)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhân viên không thành công!");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNhanVien.Text != "")
            {
                string maNhanVien = txtMaNhanVien.Text;

                if (NhanVienBLL.Delete(maNhanVien) > 0)
                {
                    LoadData();
                    MessageBox.Show("Đã xóa nhân viên.");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            Clear();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<NhanVienDTO> lst = NhanVienBLL.FindNhanVien(txtTimKiem.Text);
            dataGridView1.DataSource = lst;

            dataGridView1.Columns["MaNhanVien"].HeaderText = "Mã nhân viên";
            dataGridView1.Columns["HoTen"].HeaderText = "Tên nhân viên";
            dataGridView1.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            dataGridView1.Columns["Email"].HeaderText = "Email";
            dataGridView1.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dataGridView1.Columns["MatKhau"].HeaderText = "Mật khẩu";
            dataGridView1.Columns["MatKhau"].Visible = false;
        }

        private void NhanVienGUI_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
