namespace ATM
{
    partial class ATM
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
            this.numberText = new System.Windows.Forms.TextBox();
            this.pinText = new System.Windows.Forms.TextBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.pinLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.informationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // numberText
            // 
            this.numberText.Location = new System.Drawing.Point(344, 244);
            this.numberText.Name = "numberText";
            this.numberText.Size = new System.Drawing.Size(392, 28);
            this.numberText.TabIndex = 0;
            this.numberText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // pinText
            // 
            this.pinText.Location = new System.Drawing.Point(344, 301);
            this.pinText.Name = "pinText";
            this.pinText.Size = new System.Drawing.Size(392, 28);
            this.pinText.TabIndex = 1;
            this.pinText.UseSystemPasswordChar = true;
            this.pinText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(277, 247);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(62, 18);
            this.numberLabel.TabIndex = 2;
            this.numberLabel.Text = "账号：";
            // 
            // pinLabel
            // 
            this.pinLabel.AutoSize = true;
            this.pinLabel.Location = new System.Drawing.Point(277, 304);
            this.pinLabel.Name = "pinLabel";
            this.pinLabel.Size = new System.Drawing.Size(62, 18);
            this.pinLabel.TabIndex = 3;
            this.pinLabel.Text = "密码：";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(379, 406);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(266, 44);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "登录";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.Font = new System.Drawing.Font("华文新魏", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.informationLabel.Location = new System.Drawing.Point(417, 170);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(181, 29);
            this.informationLabel.TabIndex = 5;
            this.informationLabel.Text = "请登录后继续";
            // 
            // ATM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 611);
            this.Controls.Add(this.informationLabel);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.pinLabel);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.pinText);
            this.Controls.Add(this.numberText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATM";
            this.Text = "ATM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numberText;
        private System.Windows.Forms.TextBox pinText;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Label pinLabel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label informationLabel;
    }
}

