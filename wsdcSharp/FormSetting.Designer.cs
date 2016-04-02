namespace wsdcSharp
{
    partial class FormSetting
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
            this.textBox_RecvData = new System.Windows.Forms.TextBox();
            this.comboBox_SerialPort = new System.Windows.Forms.ComboBox();
            this.button_send_test = new System.Windows.Forms.Button();
            this.textBox_in = new System.Windows.Forms.TextBox();
            this.button_openSerialPort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_BandRate = new System.Windows.Forms.ComboBox();
            this.checkBox_hex = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox_RecvData
            // 
            this.textBox_RecvData.Location = new System.Drawing.Point(12, 135);
            this.textBox_RecvData.Multiline = true;
            this.textBox_RecvData.Name = "textBox_RecvData";
            this.textBox_RecvData.Size = new System.Drawing.Size(303, 204);
            this.textBox_RecvData.TabIndex = 0;
            this.textBox_RecvData.TextChanged += new System.EventHandler(this.textBox_RecvData_TextChanged);
            this.textBox_RecvData.MouseMove += new System.Windows.Forms.MouseEventHandler(this.textBox_RecvData_MouseMove);
            // 
            // comboBox_SerialPort
            // 
            this.comboBox_SerialPort.FormattingEnabled = true;
            this.comboBox_SerialPort.Location = new System.Drawing.Point(75, 22);
            this.comboBox_SerialPort.Name = "comboBox_SerialPort";
            this.comboBox_SerialPort.Size = new System.Drawing.Size(121, 20);
            this.comboBox_SerialPort.TabIndex = 1;
            this.comboBox_SerialPort.SelectedIndexChanged += new System.EventHandler(this.comboBox_SerialPort_SelectedIndexChanged);
            // 
            // button_send_test
            // 
            this.button_send_test.Location = new System.Drawing.Point(240, 92);
            this.button_send_test.Name = "button_send_test";
            this.button_send_test.Size = new System.Drawing.Size(75, 23);
            this.button_send_test.TabIndex = 2;
            this.button_send_test.Text = "发送";
            this.button_send_test.UseVisualStyleBackColor = true;
            this.button_send_test.Click += new System.EventHandler(this.button_send_test_Click);
            // 
            // textBox_in
            // 
            this.textBox_in.Location = new System.Drawing.Point(12, 92);
            this.textBox_in.Name = "textBox_in";
            this.textBox_in.Size = new System.Drawing.Size(184, 21);
            this.textBox_in.TabIndex = 3;
            this.textBox_in.TextChanged += new System.EventHandler(this.textBox_in_TextChanged);
            // 
            // button_openSerialPort
            // 
            this.button_openSerialPort.Location = new System.Drawing.Point(240, 19);
            this.button_openSerialPort.Name = "button_openSerialPort";
            this.button_openSerialPort.Size = new System.Drawing.Size(75, 23);
            this.button_openSerialPort.TabIndex = 2;
            this.button_openSerialPort.Text = "打开";
            this.button_openSerialPort.UseVisualStyleBackColor = true;
            this.button_openSerialPort.Click += new System.EventHandler(this.button_openSerialPort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "串口号";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "波特率";
            // 
            // comboBox_BandRate
            // 
            this.comboBox_BandRate.FormattingEnabled = true;
            this.comboBox_BandRate.Location = new System.Drawing.Point(75, 55);
            this.comboBox_BandRate.Name = "comboBox_BandRate";
            this.comboBox_BandRate.Size = new System.Drawing.Size(121, 20);
            this.comboBox_BandRate.TabIndex = 1;
            this.comboBox_BandRate.SelectedIndexChanged += new System.EventHandler(this.comboBox_BandRate_SelectedIndexChanged);
            // 
            // checkBox_hex
            // 
            this.checkBox_hex.AutoSize = true;
            this.checkBox_hex.Location = new System.Drawing.Point(14, 119);
            this.checkBox_hex.Name = "checkBox_hex";
            this.checkBox_hex.Size = new System.Drawing.Size(42, 16);
            this.checkBox_hex.TabIndex = 5;
            this.checkBox_hex.Text = "hex";
            this.checkBox_hex.UseVisualStyleBackColor = true;
            this.checkBox_hex.CheckedChanged += new System.EventHandler(this.checkBox_hex_CheckedChanged);
            this.checkBox_hex.CheckStateChanged += new System.EventHandler(this.checkBox_hex_CheckStateChanged);
            // 
            // FormSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 356);
            this.Controls.Add(this.checkBox_hex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_in);
            this.Controls.Add(this.button_openSerialPort);
            this.Controls.Add(this.button_send_test);
            this.Controls.Add(this.comboBox_BandRate);
            this.Controls.Add(this.comboBox_SerialPort);
            this.Controls.Add(this.textBox_RecvData);
            this.MaximizeBox = false;
            this.Name = "FormSetting";
            this.Text = "连接设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSetting_FormClosing);
            this.Load += new System.EventHandler(this.FormSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_RecvData;
        private System.Windows.Forms.ComboBox comboBox_SerialPort;
        private System.Windows.Forms.Button button_send_test;
        private System.Windows.Forms.TextBox textBox_in;
        private System.Windows.Forms.Button button_openSerialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_BandRate;
        private System.Windows.Forms.CheckBox checkBox_hex;
    }
}