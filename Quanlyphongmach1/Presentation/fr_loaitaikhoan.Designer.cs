namespace Quanlyphongmach1.Presentation
{
    partial class fr_loaitaikhoan
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_dsloaitk = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_tenloaitk = new System.Windows.Forms.TextBox();
            this.txt_maloaitk = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_luu = new System.Windows.Forms.Button();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_themmoi = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsloaitk)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 40);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(55, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "DANH MỤC LOẠI TÀI KHOẢN";
            // 
            // dgv_dsloaitk
            // 
            this.dgv_dsloaitk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsloaitk.Location = new System.Drawing.Point(0, 42);
            this.dgv_dsloaitk.Name = "dgv_dsloaitk";
            this.dgv_dsloaitk.ReadOnly = true;
            this.dgv_dsloaitk.Size = new System.Drawing.Size(402, 267);
            this.dgv_dsloaitk.TabIndex = 1;
            this.dgv_dsloaitk.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_dsloaitk_CellClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_tenloaitk);
            this.panel2.Controls.Add(this.txt_maloaitk);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 315);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(405, 83);
            this.panel2.TabIndex = 2;
            // 
            // txt_tenloaitk
            // 
            this.txt_tenloaitk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_tenloaitk.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenloaitk.Location = new System.Drawing.Point(141, 47);
            this.txt_tenloaitk.Name = "txt_tenloaitk";
            this.txt_tenloaitk.Size = new System.Drawing.Size(254, 27);
            this.txt_tenloaitk.TabIndex = 4;
            // 
            // txt_maloaitk
            // 
            this.txt_maloaitk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_maloaitk.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_maloaitk.Location = new System.Drawing.Point(141, 14);
            this.txt_maloaitk.Name = "txt_maloaitk";
            this.txt_maloaitk.Size = new System.Drawing.Size(254, 27);
            this.txt_maloaitk.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên loại tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã loại tài khoản:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_luu);
            this.panel3.Controls.Add(this.btn_xoa);
            this.panel3.Controls.Add(this.btn_themmoi);
            this.panel3.Controls.Add(this.btn_sua);
            this.panel3.Location = new System.Drawing.Point(0, 404);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(416, 50);
            this.panel3.TabIndex = 3;
            // 
            // btn_luu
            // 
            this.btn_luu.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_luu.Image = global::Quanlyphongmach1.Properties.Resources.save;
            this.btn_luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_luu.Location = new System.Drawing.Point(304, 0);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Padding = new System.Windows.Forms.Padding(2);
            this.btn_luu.Size = new System.Drawing.Size(99, 50);
            this.btn_luu.TabIndex = 1;
            this.btn_luu.Text = "Lưu";
            this.btn_luu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_luu.UseVisualStyleBackColor = false;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
            // 
            // btn_xoa
            // 
            this.btn_xoa.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_xoa.Image = global::Quanlyphongmach1.Properties.Resources.delete;
            this.btn_xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_xoa.Location = new System.Drawing.Point(203, 0);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Padding = new System.Windows.Forms.Padding(2);
            this.btn_xoa.Size = new System.Drawing.Size(99, 50);
            this.btn_xoa.TabIndex = 1;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_xoa.UseVisualStyleBackColor = false;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_themmoi
            // 
            this.btn_themmoi.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_themmoi.Image = global::Quanlyphongmach1.Properties.Resources.add_new;
            this.btn_themmoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_themmoi.Location = new System.Drawing.Point(2, 0);
            this.btn_themmoi.Name = "btn_themmoi";
            this.btn_themmoi.Padding = new System.Windows.Forms.Padding(2);
            this.btn_themmoi.Size = new System.Drawing.Size(99, 50);
            this.btn_themmoi.TabIndex = 1;
            this.btn_themmoi.Text = "Thêm";
            this.btn_themmoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_themmoi.UseVisualStyleBackColor = false;
            this.btn_themmoi.Click += new System.EventHandler(this.btn_themmoi_Click);
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_sua.Image = global::Quanlyphongmach1.Properties.Resources.edit;
            this.btn_sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sua.Location = new System.Drawing.Point(102, 0);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Padding = new System.Windows.Forms.Padding(2);
            this.btn_sua.Size = new System.Drawing.Size(99, 50);
            this.btn_sua.TabIndex = 1;
            this.btn_sua.Text = "Sửa";
            this.btn_sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_sua.UseVisualStyleBackColor = false;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // fr_loaitaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(404, 461);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgv_dsloaitk);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fr_loaitaikhoan";
            this.Text = "Loại Tài Khoản";
            this.Load += new System.EventHandler(this.fr_loaitaikhoan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsloaitk)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_dsloaitk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_tenloaitk;
        private System.Windows.Forms.TextBox txt_maloaitk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_themmoi;
    }
}