namespace TriThucBooksApp
{
    partial class FormTheLoai
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtMaTL;
        private System.Windows.Forms.TextBox txtTenTL;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblNgayTao;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvTheLoai;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtMaTL = new System.Windows.Forms.TextBox();
            this.txtTenTL = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblNgayTao = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvTheLoai = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheLoai)).BeginInit();
            this.SuspendLayout();

            // txtMaTL (ReadOnly theo yêu cầu)
            this.txtMaTL.Location = new System.Drawing.Point(120, 20);
            this.txtMaTL.Name = "txtMaTL";
            this.txtMaTL.ReadOnly = true;
            this.txtMaTL.Size = new System.Drawing.Size(200, 23);

            // txtTenTL
            this.txtTenTL.Location = new System.Drawing.Point(120, 60);
            this.txtTenTL.Name = "txtTenTL";
            this.txtTenTL.Size = new System.Drawing.Size(200, 23);

            // txtMoTa (Multiline theo yêu cầu)
            this.txtMoTa.Location = new System.Drawing.Point(120, 100);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(200, 60);

            // lblNgayTao
            this.lblNgayTao.AutoSize = true;
            this.lblNgayTao.Location = new System.Drawing.Point(120, 175);
            this.lblNgayTao.Name = "lblNgayTao";
            this.lblNgayTao.Text = "Ngày tạo: ";

            // txtTimKiem
            this.txtTimKiem.Location = new System.Drawing.Point(120, 210);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 23);

            // Các nút chức năng[cite: 1]
            this.btnThem.Location = new System.Drawing.Point(350, 20);
            this.btnThem.Name = "btnThem";
            this.btnThem.Text = "Thêm";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);

            this.btnSua.Location = new System.Drawing.Point(440, 20);
            this.btnSua.Name = "btnSua";
            this.btnSua.Text = "Sửa";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);

            this.btnXoa.Location = new System.Drawing.Point(530, 20);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            this.btnLamMoi.Location = new System.Drawing.Point(620, 20);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);

            this.btnTimKiem.Location = new System.Drawing.Point(330, 209);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);

            // dgvTheLoai
            this.dgvTheLoai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTheLoai.Location = new System.Drawing.Point(20, 250);
            this.dgvTheLoai.Name = "dgvTheLoai";
            this.dgvTheLoai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTheLoai.Size = new System.Drawing.Size(750, 200);
            this.dgvTheLoai.SelectionChanged += new System.EventHandler(this.dgvTheLoai_SelectionChanged);

            // FormTheLoai
            this.ClientSize = new System.Drawing.Size(800, 470);
            this.Controls.Add(this.dgvTheLoai);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblNgayTao);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.txtTenTL);
            this.Controls.Add(this.txtMaTL);
            this.Name = "FormTheLoai";
            this.Text = "Quản Lý Thể Loại Sách - Tri Thức Books";
            this.Load += new System.EventHandler(this.FormTheLoai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTheLoai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}