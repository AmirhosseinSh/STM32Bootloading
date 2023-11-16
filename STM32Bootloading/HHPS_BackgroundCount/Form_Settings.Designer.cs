namespace STM32Bootloading
{
    partial class Form_Settings
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
            this.Btn_Set_Settings = new System.Windows.Forms.Button();
            this.Btn_Get_Settings = new System.Windows.Forms.Button();
            this.Btn_Erase_Memory = new System.Windows.Forms.Button();
            this.Btn_Download_Memory = new System.Windows.Forms.Button();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.Btn_Disconnect = new System.Windows.Forms.Button();
            this.Connect_Device = new System.Windows.Forms.Button();
            this.Btn_BootMode = new System.Windows.Forms.Button();
            this.Numeric_Battery = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_DevVersion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Btn_LoadConfigs = new System.Windows.Forms.Button();
            this.Combo_PortList = new System.Windows.Forms.ComboBox();
            this.Numeric_Erros = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Memory_Bar = new System.Windows.Forms.ProgressBar();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numeric_TOF_Range = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_TOF_Range)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Set_Settings
            // 
            this.Btn_Set_Settings.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Set_Settings.Enabled = false;
            this.Btn_Set_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Set_Settings.ForeColor = System.Drawing.Color.Green;
            this.Btn_Set_Settings.Location = new System.Drawing.Point(531, 286);
            this.Btn_Set_Settings.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Set_Settings.Name = "Btn_Set_Settings";
            this.Btn_Set_Settings.Size = new System.Drawing.Size(150, 40);
            this.Btn_Set_Settings.TabIndex = 0;
            this.Btn_Set_Settings.Text = "Set Settings";
            this.Btn_Set_Settings.UseVisualStyleBackColor = false;
            this.Btn_Set_Settings.Click += new System.EventHandler(this.Btn_Set_Settings_Click);
            // 
            // Btn_Get_Settings
            // 
            this.Btn_Get_Settings.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Get_Settings.Enabled = false;
            this.Btn_Get_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Get_Settings.ForeColor = System.Drawing.Color.SteelBlue;
            this.Btn_Get_Settings.Location = new System.Drawing.Point(689, 286);
            this.Btn_Get_Settings.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Get_Settings.Name = "Btn_Get_Settings";
            this.Btn_Get_Settings.Size = new System.Drawing.Size(150, 40);
            this.Btn_Get_Settings.TabIndex = 1;
            this.Btn_Get_Settings.Text = "Get Settings";
            this.Btn_Get_Settings.UseVisualStyleBackColor = false;
            this.Btn_Get_Settings.Click += new System.EventHandler(this.Btn_Get_Settings_Click);
            // 
            // Btn_Erase_Memory
            // 
            this.Btn_Erase_Memory.BackColor = System.Drawing.SystemColors.Control;
            this.Btn_Erase_Memory.Enabled = false;
            this.Btn_Erase_Memory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Erase_Memory.ForeColor = System.Drawing.Color.Red;
            this.Btn_Erase_Memory.Location = new System.Drawing.Point(636, 153);
            this.Btn_Erase_Memory.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Erase_Memory.Name = "Btn_Erase_Memory";
            this.Btn_Erase_Memory.Size = new System.Drawing.Size(150, 30);
            this.Btn_Erase_Memory.TabIndex = 4;
            this.Btn_Erase_Memory.Text = "Erase Memory";
            this.Btn_Erase_Memory.UseVisualStyleBackColor = false;
            this.Btn_Erase_Memory.Click += new System.EventHandler(this.Btn_Erase_Memory_Click);
            // 
            // Btn_Download_Memory
            // 
            this.Btn_Download_Memory.Enabled = false;
            this.Btn_Download_Memory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Download_Memory.ForeColor = System.Drawing.Color.SteelBlue;
            this.Btn_Download_Memory.Location = new System.Drawing.Point(636, 211);
            this.Btn_Download_Memory.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Download_Memory.Name = "Btn_Download_Memory";
            this.Btn_Download_Memory.Size = new System.Drawing.Size(150, 40);
            this.Btn_Download_Memory.TabIndex = 13;
            this.Btn_Download_Memory.Text = "Download Data";
            this.Btn_Download_Memory.UseVisualStyleBackColor = true;
            this.Btn_Download_Memory.Click += new System.EventHandler(this.Btn_Download_Memory_Click);
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Connect.Location = new System.Drawing.Point(603, 50);
            this.Btn_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Connect.Name = "Btn_Connect";
            this.Btn_Connect.Size = new System.Drawing.Size(103, 28);
            this.Btn_Connect.TabIndex = 14;
            this.Btn_Connect.Text = "Open";
            this.Btn_Connect.UseVisualStyleBackColor = true;
            this.Btn_Connect.Click += new System.EventHandler(this.Btn_Connect_Click);
            // 
            // Btn_Disconnect
            // 
            this.Btn_Disconnect.Enabled = false;
            this.Btn_Disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Disconnect.Location = new System.Drawing.Point(715, 50);
            this.Btn_Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Disconnect.Name = "Btn_Disconnect";
            this.Btn_Disconnect.Size = new System.Drawing.Size(103, 28);
            this.Btn_Disconnect.TabIndex = 15;
            this.Btn_Disconnect.Text = "Close";
            this.Btn_Disconnect.UseVisualStyleBackColor = true;
            this.Btn_Disconnect.Click += new System.EventHandler(this.Btn_Disconnect_Click);
            // 
            // Connect_Device
            // 
            this.Connect_Device.BackColor = System.Drawing.SystemColors.Control;
            this.Connect_Device.Enabled = false;
            this.Connect_Device.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connect_Device.ForeColor = System.Drawing.Color.Green;
            this.Connect_Device.Location = new System.Drawing.Point(603, 84);
            this.Connect_Device.Margin = new System.Windows.Forms.Padding(4);
            this.Connect_Device.Name = "Connect_Device";
            this.Connect_Device.Size = new System.Drawing.Size(215, 40);
            this.Connect_Device.TabIndex = 16;
            this.Connect_Device.Text = "Connect to Device";
            this.Connect_Device.UseVisualStyleBackColor = false;
            this.Connect_Device.Click += new System.EventHandler(this.Btn_ConnectDevice_Click);
            // 
            // Btn_BootMode
            // 
            this.Btn_BootMode.Enabled = false;
            this.Btn_BootMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_BootMode.Location = new System.Drawing.Point(365, 297);
            this.Btn_BootMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_BootMode.Name = "Btn_BootMode";
            this.Btn_BootMode.Size = new System.Drawing.Size(93, 29);
            this.Btn_BootMode.TabIndex = 17;
            this.Btn_BootMode.Text = "Boot Mode";
            this.Btn_BootMode.UseVisualStyleBackColor = true;
            this.Btn_BootMode.Click += new System.EventHandler(this.Btn_BootMode_Click);
            // 
            // Numeric_Battery
            // 
            this.Numeric_Battery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numeric_Battery.Location = new System.Drawing.Point(336, 56);
            this.Numeric_Battery.Margin = new System.Windows.Forms.Padding(4);
            this.Numeric_Battery.MaxLength = 100;
            this.Numeric_Battery.Name = "Numeric_Battery";
            this.Numeric_Battery.ReadOnly = true;
            this.Numeric_Battery.Size = new System.Drawing.Size(61, 24);
            this.Numeric_Battery.TabIndex = 32;
            this.Numeric_Battery.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(407, 60);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 16);
            this.label10.TabIndex = 33;
            this.label10.Text = "Battery(%)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(405, 26);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 45;
            this.label6.Text = "Version";
            // 
            // txt_DevVersion
            // 
            this.txt_DevVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DevVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txt_DevVersion.Location = new System.Drawing.Point(336, 23);
            this.txt_DevVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DevVersion.MaxLength = 100;
            this.txt_DevVersion.Name = "txt_DevVersion";
            this.txt_DevVersion.ReadOnly = true;
            this.txt_DevVersion.Size = new System.Drawing.Size(61, 24);
            this.txt_DevVersion.TabIndex = 44;
            this.txt_DevVersion.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(562, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 18);
            this.label14.TabIndex = 48;
            this.label14.Text = "Serial Port Number";
            // 
            // Btn_LoadConfigs
            // 
            this.Btn_LoadConfigs.BackColor = System.Drawing.Color.Moccasin;
            this.Btn_LoadConfigs.Enabled = false;
            this.Btn_LoadConfigs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_LoadConfigs.Location = new System.Drawing.Point(35, 8);
            this.Btn_LoadConfigs.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_LoadConfigs.Name = "Btn_LoadConfigs";
            this.Btn_LoadConfigs.Size = new System.Drawing.Size(215, 40);
            this.Btn_LoadConfigs.TabIndex = 50;
            this.Btn_LoadConfigs.Text = "Load Configurations";
            this.Btn_LoadConfigs.UseVisualStyleBackColor = false;
            this.Btn_LoadConfigs.Click += new System.EventHandler(this.Btn_LoadConfigs_Click);
            // 
            // Combo_PortList
            // 
            this.Combo_PortList.FormattingEnabled = true;
            this.Combo_PortList.Items.AddRange(new object[] {
            "Short (1)",
            "Medium (1.5)",
            "Long (2)",
            "Very Long (3)"});
            this.Combo_PortList.Location = new System.Drawing.Point(715, 8);
            this.Combo_PortList.Margin = new System.Windows.Forms.Padding(4);
            this.Combo_PortList.Name = "Combo_PortList";
            this.Combo_PortList.Size = new System.Drawing.Size(103, 24);
            this.Combo_PortList.TabIndex = 51;
            // 
            // Numeric_Erros
            // 
            this.Numeric_Erros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numeric_Erros.ForeColor = System.Drawing.Color.Black;
            this.Numeric_Erros.Location = new System.Drawing.Point(336, 87);
            this.Numeric_Erros.Margin = new System.Windows.Forms.Padding(4);
            this.Numeric_Erros.MaxLength = 100;
            this.Numeric_Erros.Name = "Numeric_Erros";
            this.Numeric_Erros.ReadOnly = true;
            this.Numeric_Erros.Size = new System.Drawing.Size(61, 24);
            this.Numeric_Erros.TabIndex = 55;
            this.Numeric_Erros.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(407, 88);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "Device Errors";
            // 
            // Memory_Bar
            // 
            this.Memory_Bar.Location = new System.Drawing.Point(336, 214);
            this.Memory_Bar.Maximum = 120;
            this.Memory_Bar.Name = "Memory_Bar";
            this.Memory_Bar.Size = new System.Drawing.Size(155, 23);
            this.Memory_Bar.TabIndex = 59;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(332, 241);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(151, 16);
            this.label18.TabIndex = 63;
            this.label18.Text = "0 \'  \'  \'  \'  \' 50% \'  \'  \'  \'  \' Full";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(113, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "TOF Range (mm)";
            // 
            // numeric_TOF_Range
            // 
            this.numeric_TOF_Range.Location = new System.Drawing.Point(13, 56);
            this.numeric_TOF_Range.Margin = new System.Windows.Forms.Padding(4);
            this.numeric_TOF_Range.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numeric_TOF_Range.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numeric_TOF_Range.Name = "numeric_TOF_Range";
            this.numeric_TOF_Range.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numeric_TOF_Range.Size = new System.Drawing.Size(93, 22);
            this.numeric_TOF_Range.TabIndex = 19;
            this.numeric_TOF_Range.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(497, 217);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 18);
            this.label17.TabIndex = 62;
            this.label17.Text = "Memory Level";
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 385);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.Memory_Bar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Numeric_Erros);
            this.Controls.Add(this.Combo_PortList);
            this.Controls.Add(this.Btn_LoadConfigs);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_DevVersion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Numeric_Battery);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numeric_TOF_Range);
            this.Controls.Add(this.Btn_BootMode);
            this.Controls.Add(this.Connect_Device);
            this.Controls.Add(this.Btn_Disconnect);
            this.Controls.Add(this.Btn_Connect);
            this.Controls.Add(this.Btn_Download_Memory);
            this.Controls.Add(this.Btn_Erase_Memory);
            this.Controls.Add(this.Btn_Get_Settings);
            this.Controls.Add(this.Btn_Set_Settings);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Settings";
            this.Text = "STM32Bootloading (v1.0.0)";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numeric_TOF_Range)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Set_Settings;
        private System.Windows.Forms.Button Btn_Get_Settings;
        private System.Windows.Forms.Button Btn_Erase_Memory;
        private System.Windows.Forms.Button Btn_Download_Memory;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.Button Btn_Disconnect;
        private System.Windows.Forms.Button Connect_Device;
        private System.Windows.Forms.Button Btn_BootMode;
        private System.Windows.Forms.TextBox Numeric_Battery;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_DevVersion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button Btn_LoadConfigs;
        private System.Windows.Forms.ComboBox Combo_PortList;
        private System.Windows.Forms.TextBox Numeric_Erros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar Memory_Bar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numeric_TOF_Range;
        private System.Windows.Forms.Label label17;
    }
}