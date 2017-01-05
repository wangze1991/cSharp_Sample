namespace FrmBaiduDictionary
{
    partial class FrmMain
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
            this.txtWord = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblWordTip = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtWord
            // 
            this.txtWord.Location = new System.Drawing.Point(35, 0);
            this.txtWord.MinimumSize = new System.Drawing.Size(207, 21);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(207, 21);
            this.txtWord.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(85, 27);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(32, 97);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 12);
            this.lblResult.TabIndex = 2;
            // 
            // lblWordTip
            // 
            this.lblWordTip.AutoSize = true;
            this.lblWordTip.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWordTip.Location = new System.Drawing.Point(0, 0);
            this.lblWordTip.Name = "lblWordTip";
            this.lblWordTip.Size = new System.Drawing.Size(29, 12);
            this.lblWordTip.TabIndex = 3;
            this.lblWordTip.Text = "单词";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblWordTip);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtWord);
            this.Name = "FrmMain";
            this.Text = "词典";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblWordTip;
    }
}

