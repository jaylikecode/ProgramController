namespace ProgramController
{
    partial class ProgramControllerForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgramControllerForm));
            this.DemoGB = new System.Windows.Forms.GroupBox();
            this.OperatorGB = new System.Windows.Forms.GroupBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.OperatorGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // DemoGB
            // 
            this.DemoGB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DemoGB.Location = new System.Drawing.Point(2, 2);
            this.DemoGB.Name = "DemoGB";
            this.DemoGB.Size = new System.Drawing.Size(564, 108);
            this.DemoGB.TabIndex = 0;
            this.DemoGB.TabStop = false;
            this.DemoGB.Text = "Demon";
            // 
            // OperatorGB
            // 
            this.OperatorGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperatorGB.Controls.Add(this.startBtn);
            this.OperatorGB.Location = new System.Drawing.Point(2, 116);
            this.OperatorGB.Name = "OperatorGB";
            this.OperatorGB.Size = new System.Drawing.Size(564, 80);
            this.OperatorGB.TabIndex = 1;
            this.OperatorGB.TabStop = false;
            this.OperatorGB.Text = "Operator";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(21, 35);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 23);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "启动";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // ProgramControllerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 198);
            this.Controls.Add(this.OperatorGB);
            this.Controls.Add(this.DemoGB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProgramControllerForm";
            this.Text = "ProgramController";
            this.OperatorGB.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DemoGB;
        private System.Windows.Forms.GroupBox OperatorGB;
        private System.Windows.Forms.Button startBtn;
    }
}

