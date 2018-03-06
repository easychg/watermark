namespace WM
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_statusInfo = new System.Windows.Forms.Label();
            this.btnExec = new System.Windows.Forms.Button();
            this.txtMark = new System.Windows.Forms.TextBox();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lb_statusInfo);
            this.groupBox1.Controls.Add(this.btnExec);
            this.groupBox1.Controls.Add(this.txtMark);
            this.groupBox1.Controls.Add(this.txtDir);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 453);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(19, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(437, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "注：本工具加水印会删除原文件，只保存加水印后的文件，请将原文件复制一份！";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox1.Location = new System.Drawing.Point(19, 175);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(439, 272);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "水印图：";
            this.label2.Click += new System.EventHandler(this.lb_selectMark_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "文件夹：";
            this.label1.Click += new System.EventHandler(this.lb_selectDir_Click);
            // 
            // lb_statusInfo
            // 
            this.lb_statusInfo.AutoSize = true;
            this.lb_statusInfo.Location = new System.Drawing.Point(29, 132);
            this.lb_statusInfo.Name = "lb_statusInfo";
            this.lb_statusInfo.Size = new System.Drawing.Size(77, 12);
            this.lb_statusInfo.TabIndex = 3;
            this.lb_statusInfo.Text = "状态：未执行";
            // 
            // btnExec
            // 
            this.btnExec.Location = new System.Drawing.Point(383, 127);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(75, 23);
            this.btnExec.TabIndex = 2;
            this.btnExec.Text = "执行";
            this.btnExec.UseVisualStyleBackColor = true;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // txtMark
            // 
            this.txtMark.Location = new System.Drawing.Point(76, 86);
            this.txtMark.Name = "txtMark";
            this.txtMark.Size = new System.Drawing.Size(382, 21);
            this.txtMark.TabIndex = 1;
            this.txtMark.Click += new System.EventHandler(this.lb_selectMark_Click);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(76, 48);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(382, 21);
            this.txtDir.TabIndex = 0;
            this.txtDir.Click += new System.EventHandler(this.lb_selectDir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 477);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "水印";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMark;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.Button btnExec;
        private System.Windows.Forms.Label lb_statusInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}

