using System.Windows.Forms;

namespace ImageResizer
{
    partial class frmImgResizer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImgResizer));
            btnLoadImg = new Button();
            pBImgIn = new PictureBox();
            btnClear = new Button();
            btnCrop = new Button();
            panelImg = new Panel();
            filename_view = new TextBox();
            PreviewPanel = new Panel();
            label9 = new Label();
            cropped_dest = new TextBox();
            label8 = new Label();
            label1 = new Label();
            previewBox = new PictureBox();
            panel1 = new Panel();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            label3 = new Label();
            auto_mode = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            add_canvas = new Button();
            AlignLT = new Button();
            AlignRt = new Button();
            RotateBtn = new Button();
            source_txt = new TextBox();
            label11 = new Label();
            label4 = new Label();
            panel2 = new Panel();
            label12 = new Label();
            detached_dest = new TextBox();
            panel3 = new Panel();
            label10 = new Label();
            BG_rem_dest = new TextBox();
            label15 = new Label();
            label16 = new Label();
            previewboxBG = new PictureBox();
            bg_rm = new Button();
            ((System.ComponentModel.ISupportInitialize)pBImgIn).BeginInit();
            panelImg.SuspendLayout();
            PreviewPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)previewBox).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)previewboxBG).BeginInit();
            SuspendLayout();
            // 
            // btnLoadImg
            // 
            btnLoadImg.BackColor = SystemColors.MenuHighlight;
            btnLoadImg.FlatAppearance.BorderSize = 0;
            btnLoadImg.FlatStyle = FlatStyle.Flat;
            btnLoadImg.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadImg.ForeColor = SystemColors.Control;
            btnLoadImg.Location = new Point(467, 42);
            btnLoadImg.Name = "btnLoadImg";
            btnLoadImg.Size = new Size(98, 28);
            btnLoadImg.TabIndex = 0;
            btnLoadImg.Text = "Load ";
            btnLoadImg.UseVisualStyleBackColor = false;
            btnLoadImg.Click += btnLoadImg_Click;
            // 
            // pBImgIn
            // 
            pBImgIn.BackColor = Color.White;
            pBImgIn.BorderStyle = BorderStyle.FixedSingle;
            pBImgIn.Location = new Point(2, 3);
            pBImgIn.MinimumSize = new Size(723, 567);
            pBImgIn.Name = "pBImgIn";
            pBImgIn.Size = new Size(723, 567);
            pBImgIn.SizeMode = PictureBoxSizeMode.Zoom;
            pBImgIn.TabIndex = 1;
            pBImgIn.TabStop = false;
            pBImgIn.MouseDown += pBImgIn_MouseDown;
            pBImgIn.MouseMove += pBImgIn_MouseMove;
            pBImgIn.MouseUp += pBImgIn_MouseUp;
            pBImgIn.MouseWheel += PBImgIn_MouseWheel;
            // 
            // btnClear
            // 
            btnClear.BackColor = SystemColors.ControlDark;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = SystemColors.Control;
            btnClear.Location = new Point(341, 42);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(98, 28);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnCrop
            // 
            btnCrop.Image = Properties.Resources.crop_9045699;
            btnCrop.Location = new Point(187, 233);
            btnCrop.Name = "btnCrop";
            btnCrop.Size = new Size(48, 44);
            btnCrop.TabIndex = 6;
            btnCrop.UseVisualStyleBackColor = true;
            btnCrop.Click += btnCrop_Click;
            // 
            // panelImg
            // 
            panelImg.AutoScroll = true;
            panelImg.BackColor = Color.White;
            panelImg.BorderStyle = BorderStyle.FixedSingle;
            panelImg.Controls.Add(pBImgIn);
            panelImg.Location = new Point(2, 2);
            panelImg.Name = "panelImg";
            panelImg.Size = new Size(730, 575);
            panelImg.TabIndex = 7;
            // 
            // filename_view
            // 
            filename_view.Location = new Point(365, 10);
            filename_view.Name = "filename_view";
            filename_view.Size = new Size(201, 23);
            filename_view.TabIndex = 8;
            // 
            // PreviewPanel
            // 
            PreviewPanel.BackColor = SystemColors.MenuBar;
            PreviewPanel.Controls.Add(label9);
            PreviewPanel.Controls.Add(cropped_dest);
            PreviewPanel.Controls.Add(label8);
            PreviewPanel.Controls.Add(label1);
            PreviewPanel.Controls.Add(previewBox);
            PreviewPanel.Controls.Add(btnCrop);
            PreviewPanel.Location = new Point(734, 3);
            PreviewPanel.Name = "PreviewPanel";
            PreviewPanel.Size = new Size(248, 283);
            PreviewPanel.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(4, 236);
            label9.Name = "label9";
            label9.Size = new Size(102, 15);
            label9.TabIndex = 20;
            label9.Text = "Cropped Location";
            // 
            // cropped_dest
            // 
            cropped_dest.Location = new Point(4, 254);
            cropped_dest.Name = "cropped_dest";
            cropped_dest.Size = new Size(177, 23);
            cropped_dest.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(189, 216);
            label8.Name = "label8";
            label8.Size = new Size(33, 15);
            label8.TabIndex = 18;
            label8.Text = "Crop";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(4, 6);
            label1.Name = "label1";
            label1.Size = new Size(55, 17);
            label1.TabIndex = 2;
            label1.Text = "Preview";
            // 
            // previewBox
            // 
            previewBox.BackColor = Color.White;
            previewBox.Location = new Point(3, 24);
            previewBox.Name = "previewBox";
            previewBox.Size = new Size(241, 189);
            previewBox.TabIndex = 0;
            previewBox.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.InactiveBorder;
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(auto_mode);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(add_canvas);
            panel1.Controls.Add(AlignLT);
            panel1.Controls.Add(AlignRt);
            panel1.Controls.Add(RotateBtn);
            panel1.Location = new Point(571, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(405, 71);
            panel1.TabIndex = 10;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(86, 39);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(52, 19);
            checkBox2.TabIndex = 21;
            checkBox2.Text = "Crop";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(86, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(68, 19);
            checkBox1.TabIndex = 20;
            checkBox1.Text = "BG Rem";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 52);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 19;
            label3.Text = "Auto Mode";
            // 
            // auto_mode
            // 
            auto_mode.BackColor = SystemColors.MenuHighlight;
            auto_mode.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            auto_mode.ForeColor = SystemColors.ButtonHighlight;
            auto_mode.Location = new Point(3, 7);
            auto_mode.Name = "auto_mode";
            auto_mode.Size = new Size(79, 44);
            auto_mode.TabIndex = 18;
            auto_mode.Text = "Start";
            auto_mode.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(352, 51);
            label7.Name = "label7";
            label7.Size = new Size(45, 15);
            label7.TabIndex = 17;
            label7.Text = "Canvas";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(287, 51);
            label6.Name = "label6";
            label6.Size = new Size(41, 15);
            label6.TabIndex = 16;
            label6.Text = "Rotate";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(153, 51);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 15;
            label5.Text = "Left";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(223, 51);
            label2.Name = "label2";
            label2.Size = new Size(35, 15);
            label2.TabIndex = 14;
            label2.Text = "Right";
            // 
            // add_canvas
            // 
            add_canvas.Image = (Image)resources.GetObject("add_canvas.Image");
            add_canvas.Location = new Point(352, 7);
            add_canvas.Name = "add_canvas";
            add_canvas.Size = new Size(48, 44);
            add_canvas.TabIndex = 13;
            add_canvas.UseVisualStyleBackColor = true;
            add_canvas.Click += add_canvas_Click;
            // 
            // AlignLT
            // 
            AlignLT.Image = Properties.Resources.rotate_left;
            AlignLT.Location = new Point(153, 7);
            AlignLT.Name = "AlignLT";
            AlignLT.Size = new Size(48, 44);
            AlignLT.TabIndex = 11;
            AlignLT.UseVisualStyleBackColor = true;
            AlignLT.Click += AlignLT_Click;
            // 
            // AlignRt
            // 
            AlignRt.Image = Properties.Resources.rotate_right;
            AlignRt.Location = new Point(220, 7);
            AlignRt.Name = "AlignRt";
            AlignRt.Size = new Size(48, 44);
            AlignRt.TabIndex = 10;
            AlignRt.UseVisualStyleBackColor = true;
            AlignRt.Click += AlignRt_Click;
            // 
            // RotateBtn
            // 
            RotateBtn.Image = Properties.Resources.nav_refresh_removebg_preview;
            RotateBtn.Location = new Point(287, 7);
            RotateBtn.Name = "RotateBtn";
            RotateBtn.Size = new Size(48, 44);
            RotateBtn.TabIndex = 9;
            RotateBtn.UseVisualStyleBackColor = true;
            RotateBtn.Click += RotateBtn_Click;
            // 
            // source_txt
            // 
            source_txt.Location = new Point(82, 10);
            source_txt.Name = "source_txt";
            source_txt.Size = new Size(237, 23);
            source_txt.TabIndex = 20;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(3, 14);
            label11.Name = "label11";
            label11.Size = new Size(52, 15);
            label11.TabIndex = 18;
            label11.Text = "Source : ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(331, 15);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 12;
            label4.Text = "File :";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(label12);
            panel2.Controls.Add(detached_dest);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(source_txt);
            panel2.Controls.Add(filename_view);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(btnClear);
            panel2.Controls.Add(btnLoadImg);
            panel2.Location = new Point(3, 579);
            panel2.Name = "panel2";
            panel2.Size = new Size(979, 77);
            panel2.TabIndex = 11;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(3, 42);
            label12.Name = "label12";
            label12.Size = new Size(63, 15);
            label12.TabIndex = 21;
            label12.Text = "Detached :";
            // 
            // detached_dest
            // 
            detached_dest.Location = new Point(82, 38);
            detached_dest.Name = "detached_dest";
            detached_dest.Size = new Size(237, 23);
            detached_dest.TabIndex = 22;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.MenuBar;
            panel3.Controls.Add(label10);
            panel3.Controls.Add(BG_rem_dest);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(previewboxBG);
            panel3.Controls.Add(bg_rm);
            panel3.Location = new Point(734, 290);
            panel3.Name = "panel3";
            panel3.Size = new Size(248, 287);
            panel3.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(4, 237);
            label10.Name = "label10";
            label10.Size = new Size(124, 15);
            label10.TabIndex = 21;
            label10.Text = "BG Removed Location";
            // 
            // BG_rem_dest
            // 
            BG_rem_dest.Location = new Point(4, 255);
            BG_rem_dest.Name = "BG_rem_dest";
            BG_rem_dest.Size = new Size(177, 23);
            BG_rem_dest.TabIndex = 20;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(173, 216);
            label15.Name = "label15";
            label15.Size = new Size(71, 15);
            label15.TabIndex = 18;
            label15.Text = "Bg Remover";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label16.Location = new Point(4, 6);
            label16.Name = "label16";
            label16.Size = new Size(137, 17);
            label16.TabIndex = 2;
            label16.Text = "BG Removed Preview";
            // 
            // previewboxBG
            // 
            previewboxBG.BackColor = Color.White;
            previewboxBG.Location = new Point(3, 24);
            previewboxBG.Name = "previewboxBG";
            previewboxBG.Size = new Size(241, 189);
            previewboxBG.TabIndex = 0;
            previewboxBG.TabStop = false;
            // 
            // bg_rm
            // 
            bg_rm.Image = (Image)resources.GetObject("bg_rm.Image");
            bg_rm.Location = new Point(187, 233);
            bg_rm.Name = "bg_rm";
            bg_rm.Size = new Size(48, 44);
            bg_rm.TabIndex = 6;
            bg_rm.UseVisualStyleBackColor = true;
            bg_rm.Click += bg_rm_Click;
            // 
            // frmImgResizer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(984, 658);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(PreviewPanel);
            Controls.Add(panelImg);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmImgResizer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MM Image Editor";
            Load += frmImgResizer_Load;
            ((System.ComponentModel.ISupportInitialize)pBImgIn).EndInit();
            panelImg.ResumeLayout(false);
            PreviewPanel.ResumeLayout(false);
            PreviewPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)previewBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)previewboxBG).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoadImg;
        private PictureBox pBImgIn;
        private Button btnClear;
        private Button btnCrop;
        private Panel panelImg;
        private TextBox filename_view;
        private Panel PreviewPanel;
        private PictureBox previewBox;
        private Panel panel1;
        private Label label1;
        private Button AlignLT;
        private Button AlignRt;
        private Button RotateBtn;
        private Label label4;
        private Button add_canvas;
        private Label label8;
        private TextBox source_txt;
        private Label label11;
        private Panel panel2;
        private Label label3;
        private Button auto_mode;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label2;
        private Panel panel3;
        private Label label16;
        private PictureBox previewboxBG;
        private Label label15;
        private Button bg_rm;
        private CheckBox checkBox1;
        private Label label9;
        private TextBox cropped_dest;
        private CheckBox checkBox2;
        private Label label12;
        private TextBox detached_dest;
        private Label label10;
        private TextBox BG_rem_dest;
    }
}