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
    public partial class NoiNgoaiTruGUI : Form
    {
        public NoiNgoaiTruGUI()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            string maKhoa = cboKhoa.SelectedValue != null ? cboKhoa.SelectedValue.ToString() : "";
            DataTable dt = NoiNgoaiTruBLL.ReadAll(maKhoa);
            dataGridView1.DataSource = dt;

            dataGridView1.Columns["MaSinhVien"].HeaderText = "Mã sinh viên";
            dataGridView1.Columns["HoTen"].HeaderText = "Họ tên";
            
            
            dataGridView1.Columns["TuNgay"].HeaderText = "Từ ngày";
            dataGridView1.Columns["DenNgay"].HeaderText = "Đến ngày";
            dataGridView1.Columns["Loai"].HeaderText = "Loại";
        }
        private void LoadDataComboBox()
        {
            List<KhoaDTO> lst = KhoaBLL.ReadAll();
            cboKhoa.DataSource = lst;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
            List<string> lstLoai = new List<string> { "Nội trú", "Ngoại trú" };
            cboLoai.DataSource = lstLoai;

        }


        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        public void ChonSinhVien(SinhVienDTO sinhVienDTO)
        {
            txtSinhVien.Text = sinhVienDTO.MaSinhVien + " - " + sinhVienDTO.HoTen;
        }
        private void btnChonSinhVien_Click(object sender, EventArgs e)
        {
            string maKhoa = cboKhoa.SelectedValue != null ? cboKhoa.SelectedValue.ToString() : "";
            new ChonSinhVienGUI(this, maKhoa).ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSinhVien.Text) && !string.IsNullOrEmpty(cboLoai.Text))
            {
                NoiNgoaiTruDTO noiNgoaiTruDTO = new NoiNgoaiTruDTO();
                noiNgoaiTruDTO.MaSinhVien = txtSinhVien.Text.Split('-')[0].Trim();
                noiNgoaiTruDTO.TuNgay = dateTuNgay.Value;
                noiNgoaiTruDTO.DenNgay = dateDenNgay.Value;
                noiNgoaiTruDTO.Loai = cboLoai.Text;
                if (NoiNgoaiTruBLL.FindBySinhVien(noiNgoaiTruDTO.MaSinhVien) != null)
                {
                    MessageBox.Show("Thông tin cư trú của sinh viên đã tồn tại!");
                    return;
                }
             
                

                if (NoiNgoaiTruBLL.Insert(noiNgoaiTruDTO) > 0)
                {
                    MessageBox.Show("Thêm thông tin cư trú của sinh viên thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Thêm thông tin cư trú của sinh viên không thành công!");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSinhVien.Text) && !string.IsNullOrEmpty(cboLoai.Text))
            {
                NoiNgoaiTruDTO noiNgoaiTruDTO = new NoiNgoaiTruDTO();
                noiNgoaiTruDTO.MaSinhVien = txtSinhVien.Text.Split('-')[0].Trim();
                noiNgoaiTruDTO.TuNgay = dateTuNgay.Value;
                noiNgoaiTruDTO.DenNgay = dateDenNgay.Value;
                noiNgoaiTruDTO.Loai = cboLoai.Text;
                if (NoiNgoaiTruBLL.FindBySinhVien(noiNgoaiTruDTO.MaSinhVien) == null)
                {
                    MessageBox.Show("Thông tin cư trú của sinh viên đã tồn tại!");
                    return;
                }
       


                if (NoiNgoaiTruBLL.Update(noiNgoaiTruDTO) > 0)
                {
                    MessageBox.Show("Sửa thông tin cư trú của sinh viên thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin cư trú của sinh viên không thành công!");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtSinhVien.Text != "")
            {
                string maSinhVien = txtSinhVien.Text.Split('-')[0].Trim();
                NoiNgoaiTruDTO noiNgoaiTruDTO = NoiNgoaiTruBLL.FindBySinhVien(maSinhVien);
                if (NoiNgoaiTruBLL.Delete(noiNgoaiTruDTO.Ma) > 0)
                {
                    LoadData();
                    MessageBox.Show("Đã xóa thông tin cư trú của sinh viên.");

                }
                else
                {
                    MessageBox.Show("Xóa thông tin cư trú của sinh viên không thành công.");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin cư trú cần xóa!");
            }
        }
        private void Clear()
        {
            txtSinhVien.Text = string.Empty;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDataComboBox();
            LoadData();
            Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy giá trị từ cột tương ứng
                string maSinhVien = row.Cells["MaSinhVien"].Value.ToString();
                NoiNgoaiTruDTO noiNgoaiTruDTO = NoiNgoaiTruBLL.FindBySinhVien(maSinhVien);

                // Gán giá trị vào các TextBox hoặc các control khác
                txtSinhVien.Text = noiNgoaiTruDTO.MaSinhVien + " - " + SinhVienBLL.FindByMaSinhVien(noiNgoaiTruDTO.MaSinhVien).HoTen;
            
                dateTuNgay.Value = noiNgoaiTruDTO.TuNgay;
              
                if(noiNgoaiTruDTO.DenNgay == null)
                {
                    dateDenNgay.ResetText();
           
                }
                else
                {
                    dateDenNgay.Value = (DateTime)(noiNgoaiTruDTO.DenNgay != null ? noiNgoaiTruDTO.DenNgay : DateTime.Now);
                }
                cboLoai.Text = noiNgoaiTruDTO.Loai;
        

            }
        }

  

        private void NoiNgoaiTruGUI_Load(object sender, EventArgs e)
        {
            LoadDataComboBox();
            LoadData();
            Clear();
        }
    }
}
