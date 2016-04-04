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
            this.components = new System.ComponentModel.Container();
            this.button_manager = new System.Windows.Forms.Button();
            this.button_setting = new System.Windows.Forms.Button();
            this.button_Exit = new System.Windows.Forms.Button();
            this.listView_orderList = new System.Windows.Forms.ListView();
            this.button_flush = new System.Windows.Forms.Button();
            this.btn_handle_order = new System.Windows.Forms.Button();
            this.serial_connect_status = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.textBox_process = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_manager
            // 
            this.button_manager.Enabled = false;
            this.button_manager.Location = new System.Drawing.Point(877, 487);
            this.button_manager.Name = "button_manager";
            this.button_manager.Size = new System.Drawing.Size(75, 23);
            this.button_manager.TabIndex = 0;
            this.button_manager.Text = "卡片管理";
            this.button_manager.UseVisualStyleBackColor = true;
            this.button_manager.Click += new System.EventHandler(this.button_manager_Click);
            // 
            // button_setting
            // 
            this.button_setting.Location = new System.Drawing.Point(877, 458);
            this.button_setting.Name = "button_setting";
            this.button_setting.Size = new System.Drawing.Size(75, 23);
            this.button_setting.TabIndex = 1;
            this.button_setting.Text = "设置串口";
            this.button_setting.UseVisualStyleBackColor = true;
            this.button_setting.Click += new System.EventHandler(this.button_setting_Click);
            // 
            // button_Exit
            // 
            this.button_Exit.Location = new System.Drawing.Point(877, 516);
            this.button_Exit.Name = "button_Exit";
            this.button_Exit.Size = new System.Drawing.Size(75, 23);
            this.button_Exit.TabIndex = 2;
            this.button_Exit.Text = "退出";
            this.button_Exit.UseVisualStyleBackColor = true;
            this.button_Exit.Click += new System.EventHandler(this.button_Exit_Click);
            // 
            // listView_orderList
            // 
            this.listView_orderList.FullRowSelect = true;
            this.listView_orderList.Location = new System.Drawing.Point(13, 28);
            this.listView_orderList.Name = "listView_orderList";
            this.listView_orderList.Size = new System.Drawing.Size(844, 511);
            this.listView_orderList.TabIndex = 3;
            this.listView_orderList.UseCompatibleStateImageBehavior = false;
            // 
            // button_flush
            // 
            this.button_flush.Location = new System.Drawing.Point(971, 28);
            this.button_flush.Name = "button_flush";
            this.button_flush.Size = new System.Drawing.Size(75, 23);
            this.button_flush.TabIndex = 4;
            this.button_flush.Text = "刷新";
            this.button_flush.UseVisualStyleBackColor = true;
            this.button_flush.Click += new System.EventHandler(this.button_flush_Click);
            // 
            // btn_handle_order
            // 
            this.btn_handle_order.Enabled = false;
            this.btn_handle_order.Location = new System.Drawing.Point(877, 28);
            this.btn_handle_order.Name = "btn_handle_order";
            this.btn_handle_order.Size = new System.Drawing.Size(75, 23);
            this.btn_handle_order.TabIndex = 5;
            this.btn_handle_order.Text = "处理订单";
            this.btn_handle_order.UseVisualStyleBackColor = true;
            this.btn_handle_order.Click += new System.EventHandler(this.btn_handle_order_Click);
            // 
            // serial_connect_status
            // 
            this.serial_connect_status.AutoSize = true;
            this.serial_connect_status.Location = new System.Drawing.Point(875, 433);
            this.serial_connect_status.Name = "serial_connect_status";
            this.serial_connect_status.Size = new System.Drawing.Size(65, 12);
            this.serial_connect_status.TabIndex = 6;
            this.serial_connect_status.Text = "设备未连接";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox_process
            // 
            this.textBox_process.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_process.Location = new System.Drawing.Point(877, 77);
            this.textBox_process.Multiline = true;
            this.textBox_process.Name = "textBox_process";
            this.textBox_process.ReadOnly = true;
            this.textBox_process.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox_process.Size = new System.Drawing.Size(169, 338);
            this.textBox_process.TabIndex = 7;
            this.textBox_process.TextChanged += new System.EventHandler(this.textBox_process_TextChanged);
            this.textBox_process.DoubleClick += new System.EventHandler(this.textBox_process_DoubleClick);
            this.textBox_process.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox_process_MouseDown);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 551);
            this.Controls.Add(this.textBox_process);
            this.Controls.Add(this.serial_connect_status);
            this.Controls.Add(this.btn_handle_order);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_manager;
        private System.Windows.Forms.Button button_setting;
        private System.Windows.Forms.Button button_Exit;
        private System.Windows.Forms.ListView listView_orderList;
        private System.Windows.Forms.Button button_flush;
        private System.Windows.Forms.Button btn_handle_order;
        private System.Windows.Forms.Label serial_connect_status;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox_process;
    }
}