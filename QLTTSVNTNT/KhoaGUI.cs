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
    public partial class KhoaGUI : Form
    {
        public KhoaGUI()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            List<KhoaDTO> lst = KhoaBLL.ReadAll();
            dataGridView1.DataSource = lst;
            dataGridView1.Columns["MaKhoa"].HeaderText = "Mã khoa";
            dataGridView1.Columns["TenKhoa"].HeaderText = "Tên khoa";
            dataGridView1.Columns["GhiChu"].HeaderText = "Ghi chú";
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaKhoa.Text) && !string.IsNullOrEmpty(txtTenKhoa.Text) && !string.IsNullOrEmpty(txtGhiChu.Text) )
            {
                KhoaDTO khoa = new KhoaDTO();
                khoa.MaKhoa = txtMaKhoa.Text;
                khoa.TenKhoa = txtTenKhoa.Text;
                khoa.GhiChu = txtGhiChu.Text;
                if (KhoaBLL.FindByMaKhoa(khoa.MaKhoa) != null)
                {
                    MessageBox.Show("Mã khoa đã tồn tại!");
                    return;
                }
                if (KhoaBLL.FindByTenKhoa(khoa.TenKhoa) != null)
                {
                    MessageBox.Show("Tên khoa đã tồn tại!");
                    return;
                }
                if (KhoaBLL.Insert(khoa) > 0)
                {
                    MessageBox.Show("Thêm khoa thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm khoa không thành công!");
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
                string maKhoa = row.Cells["MaKhoa"].Value.ToString();
                KhoaDTO khoa = KhoaBLL.FindByMaKhoa(maKhoa);

                // Gán giá trị vào các TextBox hoặc các control khác
                txtMaKhoa.Text = khoa.MaKhoa;
                txtTenKhoa.Text = khoa.TenKhoa;
                txtGhiChu.Text = khoa.GhiChu;
      
            }
        }
        private void Clear()
        {
            txtMaKhoa.Text = string.Empty;
            txtTenKhoa.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
   
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
           try
            {
                if (!string.IsNullOrEmpty(txtMaKhoa.Text) && !string.IsNullOrEmpty(txtTenKhoa.Text) && !string.IsNullOrEmpty(txtGhiChu.Text))
                {
                    KhoaDTO khoa = new KhoaDTO();
                    khoa.MaKhoa = txtMaKhoa.Text;
                    khoa.TenKhoa = txtTenKhoa.Text;
                    khoa.GhiChu = txtGhiChu.Text;
                    if (KhoaBLL.FindByMaKhoa(khoa.MaKhoa) == null)
                    {
                        MessageBox.Show("Mã khoa không tồn tại!");
                        return;
                    }

                    if (KhoaBLL.Update(khoa) > 0)
                    {
                        MessageBox.Show("Cập nhật khoa thành công!");
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật khoa không thành công!");
                    }

                }
                else
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tên khoa đã tồn tại!");
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text != "")
            {
                string maKhoa = txtMaKhoa.Text;

                if (KhoaBLL.Delete(maKhoa) > 0)
                {
                    LoadData();
                    MessageBox.Show("Đã xóa khoa.");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Xóa khoa không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khoa cần xóa!");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadData();
            Clear();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<KhoaDTO> lst = KhoaBLL.FindKhoa(txtTimKiem.Text);
            dataGridView1.DataSource = lst;
            dataGridView1.Columns["MaKhoa"].HeaderText = "Mã khoa";
            dataGridView1.Columns["TenKhoa"].HeaderText = "Tên khoa";
            dataGridView1.Columns["GhiChu"].HeaderText = "Ghi chú";
        }
        private void KhoaGUI_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
