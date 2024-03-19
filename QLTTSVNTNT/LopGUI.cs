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
    public partial class LopGUI : Form
    {
        public LopGUI()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            string maKhoa = cboKhoa.SelectedValue != null ? cboKhoa.SelectedValue.ToString() : "";
            DataTable dt = LopBLL.ReadAllForTable(maKhoa);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["MaLop"].HeaderText = "Mã lớp";
            dataGridView1.Columns["TenLop"].HeaderText = "Tên lớp";
            dataGridView1.Columns["TenKhoa"].HeaderText = "Khoa";
            dataGridView1.Columns["GhiChu"].HeaderText = "Ghi chú";

        }

        private void LoadDataComboBox()
        {
            List<KhoaDTO> lst = KhoaBLL.ReadAll();
            cboKhoa.DataSource = lst;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaLop.Text) && !string.IsNullOrEmpty(txtTenLop.Text) && !string.IsNullOrEmpty(txtGhiChu.Text))
            {
                LopDTO lop = new LopDTO();
                lop.MaLop = txtMaLop.Text;
                lop.MaKhoa = cboKhoa.SelectedValue.ToString();
                lop.TenLop = txtTenLop.Text;
                lop.GhiChu = txtGhiChu.Text;
                if (LopBLL.FindByMaLop(lop.MaLop) != null)
                {
                    MessageBox.Show("Mã lớp đã tồn tại!");
                    return;
                }
                if (LopBLL.FindByTenLop(lop.TenLop) != null)
                {
                    MessageBox.Show("Tên lớp đã tồn tại!");
                    return;
                }
                if (LopBLL.Insert(lop) > 0)
                {
                    MessageBox.Show("Thêm lớp thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm lớp không thành công!");
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
                string maLop = row.Cells["MaLop"].Value.ToString();
                LopDTO lop = LopBLL.FindByMaLop(maLop);

                // Gán giá trị vào các TextBox hoặc các control khác
                txtMaLop.Text = lop.MaLop;
                txtTenLop.Text = lop.TenLop;
                cboKhoa.SelectedValue = lop.MaKhoa;
                txtGhiChu.Text = lop.GhiChu;

            }
        }
        private void Clear()
        {
            txtMaLop.Text = string.Empty;
            txtTenLop.Text = string.Empty;
            txtGhiChu.Text = string.Empty;

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
          try
            {
                if (!string.IsNullOrEmpty(txtMaLop.Text) && !string.IsNullOrEmpty(txtTenLop.Text) && !string.IsNullOrEmpty(txtGhiChu.Text))
                {
                    LopDTO lop = new LopDTO();
                    lop.MaLop = txtMaLop.Text;
                    lop.TenLop = txtTenLop.Text;
                    lop.MaKhoa = cboKhoa.SelectedValue.ToString();
                    lop.GhiChu = txtGhiChu.Text;
                    if (LopBLL.FindByMaLop(lop.MaLop) == null)
                    {
                        MessageBox.Show("Mã lớp đã không tồn tại!");
                        return;
                    }
                  
                    if (LopBLL.Update(lop) > 0)
                    {
                        MessageBox.Show("Cập nhật lớp thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật lớp không thành công!");
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Tên lớp đã tồn tại!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaLop.Text != "")
            {
                string maLop = txtMaLop.Text;

                if (LopBLL.Delete(maLop) > 0)
                {
                    LoadData();
                    MessageBox.Show("Đã xóa lớp.");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Xóa lớp không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa!");
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
            string maKhoa = cboKhoa.SelectedValue != null ? cboKhoa.SelectedValue.ToString() : "";
            DataTable dt = LopBLL.FindLop(maKhoa, txtTimKiem.Text);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["MaLop"].HeaderText = "Mã lớp";
            dataGridView1.Columns["TenLop"].HeaderText = "Tên lớp";
            dataGridView1.Columns["TenKhoa"].HeaderText = "Khoa";
            dataGridView1.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        private void LopGUI_Load(object sender, EventArgs e)
        {
            LoadDataComboBox();
            LoadData();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
