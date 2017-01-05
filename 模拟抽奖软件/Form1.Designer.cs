namespace 模拟抽奖软件
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
            this.btnTrigger = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.customLabelControl1 = new CustomLabelControls.CustomLabelControl();
            this.SuspendLayout();
            // 
            // btnTrigger
            // 
            this.btnTrigger.Location = new System.Drawing.Point(123, 235);
            this.btnTrigger.Name = "btnTrigger";
            this.btnTrigger.Size = new System.Drawing.Size(75, 23);
            this.btnTrigger.TabIndex = 0;
            this.btnTrigger.UseVisualStyleBackColor = true;
            this.btnTrigger.Click += new System.EventHandler(this.btnTrigger_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.Location = new System.Drawing.Point(98, 72);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(155, 66);
            this.lblNumber.TabIndex = 1;
            this.lblNumber.Text = "123123123123";
            this.lblNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // customLabelControl1
            // 
            this.customLabelControl1.Location = new System.Drawing.Point(0, 0);
            this.customLabelControl1.Name = "customLabelControl1";
            this.customLabelControl1.Size = new System.Drawing.Size(150, 150);
            this.customLabelControl1.TabIndex = 2;
            this.customLabelControl1.Text = "werwerawer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.customLabelControl1);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnTrigger);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTrigger;
        private System.Windows.Forms.Label lblNumber;
        private CustomLabelControls.CustomLabelControl customLabelControl1;
    }
}

