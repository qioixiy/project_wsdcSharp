namespace wsdcSharp
{
    partial class FormManager
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
            this.button_chongzhi = new System.Windows.Forms.Button();
            this.textBox_chongzhi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_xiaofeikaID = new System.Windows.Forms.TextBox();
            this.button_setxiaofeikaiID = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_canpanID = new System.Windows.Forms.TextBox();
            this.btn_canpanID = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_chongzhi
            // 
            this.button_chongzhi.Location = new System.Drawing.Point(259, 27);
            this.button_chongzhi.Name = "button_chongzhi";
            this.button_chongzhi.Size = new System.Drawing.Size(75, 23);
            this.button_chongzhi.TabIndex = 0;
            this.button_chongzhi.Text = "充值";
            this.button_chongzhi.UseVisualStyleBackColor = true;
            this.button_chongzhi.Click += new System.EventHandler(this.button_chongzhi_Click);
            // 
            // textBox_chongzhi
            // 
            this.textBox_chongzhi.Location = new System.Drawing.Point(107, 24);
            this.textBox_chongzhi.Name = "textBox_chongzhi";
            this.textBox_chongzhi.Size = new System.Drawing.Size(100, 21);
            this.textBox_chongzhi.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "添加消费卡金额";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "消费卡ID";
            // 
            // textBox_xiaofeikaID
            // 
            this.textBox_xiaofeikaID.Location = new System.Drawing.Point(107, 67);
            this.textBox_xiaofeikaID.Name = "textBox_xiaofeikaID";
            this.textBox_xiaofeikaID.Size = new System.Drawing.Size(100, 21);
            this.textBox_xiaofeikaID.TabIndex = 4;
            // 
            // button_setxiaofeikaiID
            // 
            this.button_setxiaofeikaiID.Location = new System.Drawing.Point(259, 65);
            this.button_setxiaofeikaiID.Name = "button_setxiaofeikaiID";
            this.button_setxiaofeikaiID.Size = new System.Drawing.Size(75, 23);
            this.button_setxiaofeikaiID.TabIndex = 5;
            this.button_setxiaofeikaiID.Text = "设置";
            this.button_setxiaofeikaiID.UseVisualStyleBackColor = true;
            this.button_setxiaofeikaiID.Click += new System.EventHandler(this.button_setxiaofeikaID_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "餐盘ID";
            // 
            // textBox_canpanID
            // 
            this.textBox_canpanID.Location = new System.Drawing.Point(107, 106);
            this.textBox_canpanID.Name = "textBox_canpanID";
            this.textBox_canpanID.Size = new System.Drawing.Size(100, 21);
            this.textBox_canpanID.TabIndex = 4;
            // 
            // btn_canpanID
            // 
            this.btn_canpanID.Location = new System.Drawing.Point(259, 106);
            this.btn_canpanID.Name = "btn_canpanID";
            this.btn_canpanID.Size = new System.Drawing.Size(75, 23);
            this.btn_canpanID.TabIndex = 5;
            this.btn_canpanID.Text = "设置";
            this.btn_canpanID.UseVisualStyleBackColor = true;
            this.btn_canpanID.Click += new System.EventHandler(this.button_setcanpanID_Click);
            // 
            // FormManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 183);
            this.Controls.Add(this.btn_canpanID);
            this.Controls.Add(this.textBox_canpanID);
            this.Controls.Add(this.button_setxiaofeikaiID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_xiaofeikaID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_chongzhi);
            this.Controls.Add(this.button_chongzhi);
            this.MaximizeBox = false;
            this.Name = "FormManager";
            this.Text = "管理";
            this.Load += new System.EventHandler(this.FormManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_chongzhi;
        private System.Windows.Forms.TextBox textBox_chongzhi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_xiaofeikaID;
        private System.Windows.Forms.Button button_setxiaofeikaiID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_canpanID;
        private System.Windows.Forms.Button btn_canpanID;
    }
}