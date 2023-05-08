namespace Final_NienLuan
{
    partial class MainForm
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
            this.drawPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnCal = new System.Windows.Forms.Button();
            this.btnDFS = new System.Windows.Forms.Button();
            this.lb_number_cc = new System.Windows.Forms.TextBox();
            this.lb_DFS_result = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.save_file_dialog = new System.Windows.Forms.SaveFileDialog();
            this.open_file_dialog = new System.Windows.Forms.OpenFileDialog();
            this.btnChangeLocation = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawPanel
            // 
            this.drawPanel.BackColor = System.Drawing.SystemColors.Window;
            this.drawPanel.Location = new System.Drawing.Point(584, 39);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Size = new System.Drawing.Size(601, 512);
            this.drawPanel.TabIndex = 0;
            this.drawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPanel_Paint);
            this.drawPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseClick);
            this.drawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseDown);
            this.drawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseMove);
            this.drawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawPanel_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 82);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bài toán trên \r\nđồ thị vô hướng";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(484, 39);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 43);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(484, 168);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 43);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Xóa tất cả";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnShow);
            this.groupBox1.Controls.Add(this.btnCal);
            this.groupBox1.Controls.Add(this.btnDFS);
            this.groupBox1.Controls.Add(this.lb_number_cc);
            this.groupBox1.Controls.Add(this.lb_DFS_result);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 227);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 324);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tính toán";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(417, 265);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(113, 29);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Khôi phục màu";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(15, 265);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(94, 29);
            this.btnShow.TabIndex = 7;
            this.btnShow.Text = "Xác định";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnCal
            // 
            this.btnCal.Location = new System.Drawing.Point(436, 163);
            this.btnCal.Name = "btnCal";
            this.btnCal.Size = new System.Drawing.Size(94, 29);
            this.btnCal.TabIndex = 6;
            this.btnCal.Text = "Tính";
            this.btnCal.UseVisualStyleBackColor = true;
            this.btnCal.Click += new System.EventHandler(this.btnCal_Click);
            // 
            // btnDFS
            // 
            this.btnDFS.Location = new System.Drawing.Point(436, 68);
            this.btnDFS.Name = "btnDFS";
            this.btnDFS.Size = new System.Drawing.Size(94, 29);
            this.btnDFS.TabIndex = 5;
            this.btnDFS.Text = "Duyệt";
            this.btnDFS.UseVisualStyleBackColor = true;
            this.btnDFS.Click += new System.EventHandler(this.btnDFS_Click);
            // 
            // lb_number_cc
            // 
            this.lb_number_cc.Location = new System.Drawing.Point(15, 163);
            this.lb_number_cc.Name = "lb_number_cc";
            this.lb_number_cc.ReadOnly = true;
            this.lb_number_cc.Size = new System.Drawing.Size(392, 27);
            this.lb_number_cc.TabIndex = 4;
            // 
            // lb_DFS_result
            // 
            this.lb_DFS_result.Location = new System.Drawing.Point(15, 69);
            this.lb_DFS_result.Name = "lb_DFS_result";
            this.lb_DFS_result.ReadOnly = true;
            this.lb_DFS_result.Size = new System.Drawing.Size(392, 27);
            this.lb_DFS_result.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Xác định cây khung tối thiểu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số đồ thị liên thông";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Duyệt đồ thị";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1198, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveFileToolStripMenuItem,
            this.openFileToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveFileToolStripMenuItem
            // 
            this.saveFileToolStripMenuItem.Name = "saveFileToolStripMenuItem";
            this.saveFileToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.saveFileToolStripMenuItem.Text = "Lưu đồ thị";
            this.saveFileToolStripMenuItem.Click += new System.EventHandler(this.saveFileToolStripMenuItem_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(159, 26);
            this.openFileToolStripMenuItem.Text = "Mở đồ thị";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.infoToolStripMenuItem.Text = "Thông tin";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // open_file_dialog
            // 
            this.open_file_dialog.FileName = "open_file_dialog";
            // 
            // btnChangeLocation
            // 
            this.btnChangeLocation.Location = new System.Drawing.Point(484, 103);
            this.btnChangeLocation.Name = "btnChangeLocation";
            this.btnChangeLocation.Size = new System.Drawing.Size(94, 43);
            this.btnChangeLocation.TabIndex = 6;
            this.btnChangeLocation.Text = "Kéo đỉnh";
            this.btnChangeLocation.UseVisualStyleBackColor = true;
            this.btnChangeLocation.Click += new System.EventHandler(this.btnChangeLocation_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 565);
            this.Controls.Add(this.btnChangeLocation);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.drawPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Niên luận cơ sở ngành";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel drawPanel;
        private Label label1;
        private Button btnUpdate;
        private Button btnClear;
        private GroupBox groupBox1;
        private Button btnShow;
        private Button btnCal;
        private Button btnDFS;
        private TextBox lb_number_cc;
        private TextBox lb_DFS_result;
        private Label label4;
        private Label label3;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem infoToolStripMenuItem;
        private Button btnReset;
        private ToolStripMenuItem saveFileToolStripMenuItem;
        private SaveFileDialog save_file_dialog;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private OpenFileDialog open_file_dialog;
        private Button btnChangeLocation;
    }
}