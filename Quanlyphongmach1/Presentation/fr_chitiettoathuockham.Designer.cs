namespace Quanlyphongmach1.Presentation
{
    partial class fr_chitiettoathuockham
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgv_dsctthk = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_cachdung = new System.Windows.Forms.TextBox();
            this.txt_congdung = new System.Windows.Forms.TextBox();
            this.txt_donvi = new System.Windows.Forms.TextBox();
            this.txt_soluong = new System.Windows.Forms.TextBox();
            this.txt_tenthuoc = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_themmoi = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.cbo_ma = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsctthk)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Pink;
            this.groupBox4.Controls.Add(this.panel6);
            this.groupBox4.Controls.Add(this.panel5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(623, 322);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Kê đơn thuốc";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgv_dsctthk);
            this.panel6.Location = new System.Drawing.Point(2, 155);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(615, 161);
            this.panel6.TabIndex = 1;
            // 
            // dgv_dsctthk
            // 
            this.dgv_dsctthk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsctthk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_dsctthk.Location = new System.Drawing.Point(0, 0);
            this.dgv_dsctthk.Name = "dgv_dsctthk";
            this.dgv_dsctthk.ReadOnly = true;
            this.dgv_dsctthk.Size = new System.Drawing.Size(615, 161);
            this.dgv_dsctthk.TabIndex = 0;
            this.dgv_dsctthk.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ds_CellClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txt_cachdung);
            this.panel5.Controls.Add(this.txt_congdung);
            this.panel5.Controls.Add(this.txt_donvi);
            this.panel5.Controls.Add(this.txt_soluong);
            this.panel5.Controls.Add(this.txt_tenthuoc);
            this.panel5.Controls.Add(this.label21);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.cbo_ma);
            this.panel5.Controls.Add(this.label19);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Location = new System.Drawing.Point(2, 25);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(615, 128);
            this.panel5.TabIndex = 0;
            // 
            // txt_cachdung
            // 
            this.txt_cachdung.Location = new System.Drawing.Point(89, 98);
            this.txt_cachdung.Name = "txt_cachdung";
            this.txt_cachdung.Size = new System.Drawing.Size(438, 26);
            this.txt_cachdung.TabIndex = 11;
            // 
            // txt_congdung
            // 
            this.txt_congdung.Location = new System.Drawing.Point(313, 68);
            this.txt_congdung.Name = "txt_congdung";
            this.txt_congdung.ReadOnly = true;
            this.txt_congdung.Size = new System.Drawing.Size(214, 26);
            this.txt_congdung.TabIndex = 11;
            // 
            // txt_donvi
            // 
            this.txt_donvi.Location = new System.Drawing.Point(313, 36);
            this.txt_donvi.Name = "txt_donvi";
            this.txt_donvi.ReadOnly = true;
            this.txt_donvi.Size = new System.Drawing.Size(110, 26);
            this.txt_donvi.TabIndex = 11;
            // 
            // txt_soluong
            // 
            this.txt_soluong.Location = new System.Drawing.Point(89, 37);
            this.txt_soluong.Name = "txt_soluong";
            this.txt_soluong.Size = new System.Drawing.Size(123, 26);
            this.txt_soluong.TabIndex = 11;
            this.txt_soluong.TextChanged += new System.EventHandler(this.txt_soluong_TextChanged);
            this.txt_soluong.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_soluong_KeyPress);
            // 
            // txt_tenthuoc
            // 
            this.txt_tenthuoc.Location = new System.Drawing.Point(313, 5);
            this.txt_tenthuoc.Name = "txt_tenthuoc";
            this.txt_tenthuoc.ReadOnly = true;
            this.txt_tenthuoc.Size = new System.Drawing.Size(214, 26);
            this.txt_tenthuoc.TabIndex = 10;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(90, 20);
            this.label21.TabIndex = 0;
            this.label21.Text = "Cách dùng:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btn_luu);
            this.panel7.Controls.Add(this.btn_xoa);
            this.panel7.Controls.Add(this.btn_themmoi);
            this.panel7.Controls.Add(this.btn_sua);
            this.panel7.Location = new System.Drawing.Point(533, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(79, 121);
            this.panel7.TabIndex = 9;
            // 
            // btn_luu
            // 
            this.btn_luu.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_luu.Image = global::Quanlyphongmach1.Properties.Resources.save_16;
            this.btn_luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_luu.Location = new System.Drawing.Point(4, 89);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Padding = new System.Windows.Forms.Padding(2);
            this.btn_luu.Size = new System.Drawing.Size(72, 30);
            this.btn_luu.TabIndex = 1;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_luu.UseVisualStyleBackColor = false;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Image = global::Quanlyphongmach1.Properties.Resources.delete_16;
            this.btn_xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xoa.Location = new System.Drawing.Point(4, 59);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Padding = new System.Windows.Forms.Padding(2);
            this.btn_xoa.Size = new System.Drawing.Size(72, 30);
            this.btn_xoa.TabIndex = 1;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_xoa.UseVisualStyleBackColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_themmoi
            // 
            this.btn_themmoi.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_themmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_themmoi.Image = global::Quanlyphongmach1.Properties.Resources.add_new_16;
            this.btn_themmoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_themmoi.Location = new System.Drawing.Point(4, 1);
            this.btn_themmoi.Name = "btn_themmoi";
            this.btn_themmoi.Padding = new System.Windows.Forms.Padding(2);
            this.btn_themmoi.Size = new System.Drawing.Size(72, 30);
            this.btn_themmoi.TabIndex = 1;
            this.btn_themmoi.Text = "Thêm";
            this.btn_themmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_themmoi.UseVisualStyleBackColor = false;
            this.btn_themmoi.Click += new System.EventHandler(this.btn_themmoi_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sua.Image = global::Quanlyphongmach1.Properties.Resources.edit_16;
            this.btn_sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sua.Location = new System.Drawing.Point(4, 31);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Padding = new System.Windows.Forms.Padding(2);
            this.btn_sua.Size = new System.Drawing.Size(72, 30);
            this.btn_sua.TabIndex = 1;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sua.UseVisualStyleBackColor = false;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(223, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(91, 20);
            this.label20.TabIndex = 0;
            this.label20.Text = "Công dụng:";
            // 
            // cbo_ma
            // 
            this.cbo_ma.FormattingEnabled = true;
            this.cbo_ma.Location = new System.Drawing.Point(89, 3);
            this.cbo_ma.Name = "cbo_ma";
            this.cbo_ma.Size = new System.Drawing.Size(123, 28);
            this.cbo_ma.TabIndex = 1;
            this.cbo_ma.SelectedIndexChanged += new System.EventHandler(this.cbo_ma_SelectedIndexChanged);
            this.cbo_ma.TextChanged += new System.EventHandler(this.cbo_ma_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(223, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 20);
            this.label19.TabIndex = 0;
            this.label19.Text = "Đơn vị:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(222, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(84, 20);
            this.label17.TabIndex = 0;
            this.label17.Text = "Tên thuốc:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 41);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 20);
            this.label18.TabIndex = 0;
            this.label18.Text = "Số lượng:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(79, 20);
            this.label16.TabIndex = 0;
            this.label16.Text = "Mã thuốc:";
            // 
            // fr_chitiettoathuockham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(623, 322);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fr_chitiettoathuockham";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết toa thuốc khám";
            this.Load += new System.EventHandler(this.fr_chitiettoathuockham_Load);
            this.groupBox4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsctthk)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgv_dsctthk;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txt_cachdung;
        private System.Windows.Forms.TextBox txt_congdung;
        private System.Windows.Forms.TextBox txt_donvi;
        private System.Windows.Forms.TextBox txt_soluong;
        private System.Windows.Forms.TextBox txt_tenthuoc;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_themmoi;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbo_ma;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
    }
}