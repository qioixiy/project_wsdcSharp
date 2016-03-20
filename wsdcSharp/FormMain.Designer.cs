namespace wsdcSharp
{
    partial class FormMain
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
            this.button_manager = new System.Windows.Forms.Button();
            this.button_setting = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.listView_orderList = new System.Windows.Forms.ListView();
            this.button_flush = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_manager
            // 
            this.button_manager.Location = new System.Drawing.Point(808, 66);
            this.button_manager.Name = "button_manager";
            this.button_manager.Size = new System.Drawing.Size(75, 23);
            this.button_manager.TabIndex = 0;
            this.button_manager.Text = "管理";
            this.button_manager.UseVisualStyleBackColor = true;
            this.button_manager.Click += new System.EventHandler(this.button_manager_Click);
            // 
            // button_setting
            // 
            this.button_setting.Location = new System.Drawing.Point(808, 28);
            this.button_setting.Name = "button_setting";
            this.button_setting.Size = new System.Drawing.Size(75, 23);
            this.button_setting.TabIndex = 1;
            this.button_setting.Text = "設置串口";
            this.button_setting.UseVisualStyleBackColor = true;
            this.button_setting.Click += new System.EventHandler(this.button_setting_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(808, 516);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "退出";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // listView_orderList
            // 
            this.listView_orderList.Location = new System.Drawing.Point(13, 28);
            this.listView_orderList.Name = "listView_orderList";
            this.listView_orderList.Size = new System.Drawing.Size(773, 511);
            this.listView_orderList.TabIndex = 3;
            this.listView_orderList.UseCompatibleStateImageBehavior = false;
            // 
            // button_flush
            // 
            this.button_flush.Location = new System.Drawing.Point(808, 478);
            this.button_flush.Name = "button_flush";
            this.button_flush.Size = new System.Drawing.Size(75, 23);
            this.button_flush.TabIndex = 4;
            this.button_flush.Text = "刷新";
            this.button_flush.UseVisualStyleBackColor = true;
            this.button_flush.Click += new System.EventHandler(this.button_flush_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(808, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 551);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_flush);
            this.Controls.Add(this.listView_orderList);
            this.Controls.Add(this.button_Exit);
            this.Controls.Add(this.button_setting);
            this.Controls.Add(this.button_manager);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "主界面";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_manager;
        private System.Windows.Forms.Button button_setting;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.ListView listView_orderList;
        private System.Windows.Forms.Button button_flush;
        private System.Windows.Forms.Button button1;
    }
}