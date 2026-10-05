using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Bai1_Chuong8.Models;
namespace TriThucBooksApp
{
    public partial class FormTheLoai : Form
    {
        private readonly TriThucBooksContext _context;

        public FormTheLoai()
        {
            InitializeComponent();
            _context = new TriThucBooksContext();
        }

        private void FormTheLoai_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // Hàm tải dữ liệu lên DataGridView[cite: 1]
        private void LoadData()
        {
            var data = _context.TheLoaiSaches.ToList();
            dgvTheLoai.DataSource = data;
        }

        // Tự động đổ dữ liệu dòng đang chọn lên các TextBox[cite: 1]
        private void dgvTheLoai_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTheLoai.CurrentRow != null && dgvTheLoai.CurrentRow.Index >= 0)
            {
                txtMaTL.Text = dgvTheLoai.CurrentRow.Cells["MaTL"].Value?.ToString();
                txtTenTL.Text = dgvTheLoai.CurrentRow.Cells["TenTheLoai"].Value?.ToString();
                txtMoTa.Text = dgvTheLoai.CurrentRow.Cells["MoTa"].Value?.ToString();
                lblNgayTao.Text = "Ngày tạo: " + dgvTheLoai.CurrentRow.Cells["NgayTao"].Value?.ToString();
            }
        }

        // Làm mới Form[cite: 1]
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaTL.Clear();
            txtTenTL.Clear();
            txtMoTa.Clear();
            txtTimKiem.Clear();
            lblNgayTao.Text = "Ngày tạo: ";
            LoadData();
        }

        // Chức năng Thêm mới[cite: 1]
        private async void btnThem_Click(object sender, EventArgs e)
        {
            // Validate: Không bỏ trống Tên thể loại[cite: 1]
            if (string.IsNullOrWhiteSpace(txtTenTL.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate: Không cho phép trùng tên thể loại khi thêm[cite: 1]
            bool isExist = _context.TheLoaiSaches.Any(t => t.TenTheLoai.ToLower() == txtTenTL.Text.Trim().ToLower());
            if (isExist)
            {
                MessageBox.Show("Tên thể loại đã tồn tại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newTheLoai = new TheLoaiSach
            {
                TenTheLoai = txtTenTL.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                SoLuongSach = 0,
                NgayTao = DateTime.Now
            };

            // Dùng context.Add() và SaveChangesAsync()[cite: 1]
            _context.TheLoaiSaches.Add(newTheLoai);
            await _context.SaveChangesAsync();

            MessageBox.Show("Thêm thể loại thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData(); // Cập nhật lại DataGridView ngay sau khi lưu[cite: 1]
        }

        // Chức năng Cập nhật (Sửa)[cite: 1]
        private async void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTL.Text)) return;

            int id = int.Parse(txtMaTL.Text);
            var theLoai = _context.TheLoaiSaches.FirstOrDefault(t => t.MaTL == id);

            if (theLoai != null)
            {
                if (string.IsNullOrWhiteSpace(txtTenTL.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên thể loại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                theLoai.TenTheLoai = txtTenTL.Text.Trim();
                theLoai.MoTa = txtMoTa.Text.Trim();

                await _context.SaveChangesAsync();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        // Chức năng Xóa có cảnh báo và bắt lỗi DbUpdateException[cite: 1]
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTL.Text)) return;

            // Hộp thoại xác nhận MessageBox YesNo[cite: 1]
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa thể loại này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                int id = int.Parse(txtMaTL.Text);
                var theLoai = _context.TheLoaiSaches.FirstOrDefault(t => t.MaTL == id);

                if (theLoai != null)
                {
                    try
                    {
                        _context.TheLoaiSaches.Remove(theLoai);
                        await _context.SaveChangesAsync();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnLamMoi_Click(sender, e);
                    }
                    catch (DbUpdateException)
                    {
                        // Thông báo khi thể loại đang được sách khác tham chiếu[cite: 1]
                        MessageBox.Show("Không thể xóa do thể loại này đang được sách khác tham chiếu!", "Lỗi ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Chức năng Tìm kiếm dùng LINQ (Where + Contains)[cite: 1]
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            // Lọc hiển thị trực tiếp trên DataGridView mà không cần tải lại toàn bộ Form[cite: 1]
            var result = _context.TheLoaiSaches
                                 .Where(t => t.TenTheLoai.ToLower().Contains(keyword))
                                 .ToList();

            dgvTheLoai.DataSource = result;
        }
    }
}