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
            this.TestMCU = new System.Windows.Forms.Button();
            this.Btn_Connect = new System.Windows.Forms.Button();
            this.Btn_Disconnect = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_DevVersion = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Combo_PortList = new System.Windows.Forms.ComboBox();
            this.Numeric_Erros = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ReadBank1 = new System.Windows.Forms.Button();
            this.erasebank2 = new System.Windows.Forms.Button();
            this.eraseban1 = new System.Windows.Forms.Button();
            this.writebank1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.ReadFile = new System.Windows.Forms.Button();
            this.ReadBank2 = new System.Windows.Forms.Button();
            this.writebank2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.VerifyBank1 = new System.Windows.Forms.Button();
            this.VerifyBank2 = new System.Windows.Forms.Button();
            this.BootMaster = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AutoProgramBank = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.HextoBin = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.excutebank1 = new System.Windows.Forms.Button();
            this.BootManager = new System.Windows.Forms.Button();
            this.excutebank2 = new System.Windows.Forms.Button();
            this.BootSmartHandle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestMCU
            // 
            this.TestMCU.BackColor = System.Drawing.SystemColors.Control;
            this.TestMCU.Enabled = false;
            this.TestMCU.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestMCU.ForeColor = System.Drawing.Color.SteelBlue;
            this.TestMCU.Location = new System.Drawing.Point(495, 289);
            this.TestMCU.Margin = new System.Windows.Forms.Padding(4);
            this.TestMCU.Name = "TestMCU";
            this.TestMCU.Size = new System.Drawing.Size(159, 40);
            this.TestMCU.TabIndex = 1;
            this.TestMCU.Text = "Test MCU ";
            this.TestMCU.UseVisualStyleBackColor = false;
            this.TestMCU.Click += new System.EventHandler(this.TestMCU_Click);
            // 
            // Btn_Connect
            // 
            this.Btn_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Connect.Location = new System.Drawing.Point(32, 45);
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
            this.Btn_Disconnect.Location = new System.Drawing.Point(144, 45);
            this.Btn_Disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Disconnect.Name = "Btn_Disconnect";
            this.Btn_Disconnect.Size = new System.Drawing.Size(103, 28);
            this.Btn_Disconnect.TabIndex = 15;
            this.Btn_Disconnect.Text = "Close";
            this.Btn_Disconnect.UseVisualStyleBackColor = true;
            this.Btn_Disconnect.Click += new System.EventHandler(this.Btn_Disconnect_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 7);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 45;
            this.label6.Text = "Version";
            // 
            // txt_DevVersion
            // 
            this.txt_DevVersion.Cursor = System.Windows.Forms.Cursors.No;
            this.txt_DevVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DevVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txt_DevVersion.Location = new System.Drawing.Point(304, 27);
            this.txt_DevVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txt_DevVersion.MaxLength = 100;
            this.txt_DevVersion.Name = "txt_DevVersion";
            this.txt_DevVersion.ReadOnly = true;
            this.txt_DevVersion.Size = new System.Drawing.Size(61, 24);
            this.txt_DevVersion.TabIndex = 44;
            this.txt_DevVersion.TextChanged += new System.EventHandler(this.txt_DevVersion_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(29, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(134, 18);
            this.label14.TabIndex = 48;
            this.label14.Text = "Serial Port Number";
            // 
            // Combo_PortList
            // 
            this.Combo_PortList.FormattingEnabled = true;
            this.Combo_PortList.Items.AddRange(new object[] {
            "Short (1)",
            "Medium (1.5)",
            "Long (2)",
            "Very Long (3)"});
            this.Combo_PortList.Location = new System.Drawing.Point(185, 13);
            this.Combo_PortList.Margin = new System.Windows.Forms.Padding(4);
            this.Combo_PortList.Name = "Combo_PortList";
            this.Combo_PortList.Size = new System.Drawing.Size(103, 24);
            this.Combo_PortList.TabIndex = 51;
            this.Combo_PortList.SelectedIndexChanged += new System.EventHandler(this.Combo_PortList_SelectedIndexChanged);
            // 
            // Numeric_Erros
            // 
            this.Numeric_Erros.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Numeric_Erros.ForeColor = System.Drawing.Color.Black;
            this.Numeric_Erros.Location = new System.Drawing.Point(393, 27);
            this.Numeric_Erros.Margin = new System.Windows.Forms.Padding(4);
            this.Numeric_Erros.MaxLength = 100;
            this.Numeric_Erros.Name = "Numeric_Erros";
            this.Numeric_Erros.ReadOnly = true;
            this.Numeric_Erros.Size = new System.Drawing.Size(61, 24);
            this.Numeric_Erros.TabIndex = 55;
            this.Numeric_Erros.TextChanged += new System.EventHandler(this.Numeric_Erros_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "ID Deivce";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ReadBank1
            // 
            this.ReadBank1.BackColor = System.Drawing.SystemColors.Control;
            this.ReadBank1.Enabled = false;
            this.ReadBank1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadBank1.ForeColor = System.Drawing.Color.SteelBlue;
            this.ReadBank1.Location = new System.Drawing.Point(66, 240);
            this.ReadBank1.Margin = new System.Windows.Forms.Padding(4);
            this.ReadBank1.Name = "ReadBank1";
            this.ReadBank1.Size = new System.Drawing.Size(181, 40);
            this.ReadBank1.TabIndex = 64;
            this.ReadBank1.Text = "Read Bank1";
            this.ReadBank1.UseVisualStyleBackColor = false;
            this.ReadBank1.Click += new System.EventHandler(this.ReadBank1_Click);
            // 
            // erasebank2
            // 
            this.erasebank2.BackColor = System.Drawing.SystemColors.Control;
            this.erasebank2.Enabled = false;
            this.erasebank2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erasebank2.ForeColor = System.Drawing.Color.SteelBlue;
            this.erasebank2.Location = new System.Drawing.Point(237, 372);
            this.erasebank2.Margin = new System.Windows.Forms.Padding(4);
            this.erasebank2.Name = "erasebank2";
            this.erasebank2.Size = new System.Drawing.Size(156, 40);
            this.erasebank2.TabIndex = 69;
            this.erasebank2.Text = "Erase Bank2";
            this.erasebank2.UseVisualStyleBackColor = false;
            this.erasebank2.Click += new System.EventHandler(this.erasebank2_Click);
            // 
            // eraseban1
            // 
            this.eraseban1.BackColor = System.Drawing.SystemColors.Control;
            this.eraseban1.Enabled = false;
            this.eraseban1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eraseban1.ForeColor = System.Drawing.Color.SteelBlue;
            this.eraseban1.Location = new System.Drawing.Point(66, 372);
            this.eraseban1.Margin = new System.Windows.Forms.Padding(4);
            this.eraseban1.Name = "eraseban1";
            this.eraseban1.Size = new System.Drawing.Size(156, 40);
            this.eraseban1.TabIndex = 70;
            this.eraseban1.Text = "Erase Bank1";
            this.eraseban1.UseVisualStyleBackColor = false;
            this.eraseban1.Click += new System.EventHandler(this.eraseban1_Click);
            // 
            // writebank1
            // 
            this.writebank1.BackColor = System.Drawing.SystemColors.Control;
            this.writebank1.Enabled = false;
            this.writebank1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writebank1.ForeColor = System.Drawing.Color.SteelBlue;
            this.writebank1.Location = new System.Drawing.Point(66, 283);
            this.writebank1.Margin = new System.Windows.Forms.Padding(4);
            this.writebank1.Name = "writebank1";
            this.writebank1.Size = new System.Drawing.Size(181, 40);
            this.writebank1.TabIndex = 71;
            this.writebank1.Text = "Write Bank1";
            this.writebank1.UseVisualStyleBackColor = false;
            this.writebank1.Click += new System.EventHandler(this.writebank1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(66, 328);
            this.filePathTextBox.Multiline = true;
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(190, 40);
            this.filePathTextBox.TabIndex = 74;
            this.filePathTextBox.TextChanged += new System.EventHandler(this.filePathTextBox_TextChanged);
            // 
            // ReadFile
            // 
            this.ReadFile.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ReadFile.Enabled = false;
            this.ReadFile.ForeColor = System.Drawing.Color.Brown;
            this.ReadFile.Location = new System.Drawing.Point(282, 334);
            this.ReadFile.Name = "ReadFile";
            this.ReadFile.Size = new System.Drawing.Size(111, 34);
            this.ReadFile.TabIndex = 75;
            this.ReadFile.Text = "Read File";
            this.ReadFile.UseVisualStyleBackColor = false;
            this.ReadFile.Click += new System.EventHandler(this.ReadFile_Click);
            // 
            // ReadBank2
            // 
            this.ReadBank2.BackColor = System.Drawing.SystemColors.Control;
            this.ReadBank2.Enabled = false;
            this.ReadBank2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReadBank2.ForeColor = System.Drawing.Color.SteelBlue;
            this.ReadBank2.Location = new System.Drawing.Point(267, 240);
            this.ReadBank2.Margin = new System.Windows.Forms.Padding(4);
            this.ReadBank2.Name = "ReadBank2";
            this.ReadBank2.Size = new System.Drawing.Size(181, 40);
            this.ReadBank2.TabIndex = 76;
            this.ReadBank2.Text = "Read Bank2";
            this.ReadBank2.UseVisualStyleBackColor = false;
            this.ReadBank2.Click += new System.EventHandler(this.ReadBank2_Click);
            // 
            // writebank2
            // 
            this.writebank2.BackColor = System.Drawing.SystemColors.Control;
            this.writebank2.Enabled = false;
            this.writebank2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writebank2.ForeColor = System.Drawing.Color.SteelBlue;
            this.writebank2.Location = new System.Drawing.Point(267, 284);
            this.writebank2.Margin = new System.Windows.Forms.Padding(4);
            this.writebank2.Name = "writebank2";
            this.writebank2.Size = new System.Drawing.Size(181, 40);
            this.writebank2.TabIndex = 77;
            this.writebank2.Text = "Write Bank2";
            this.writebank2.UseVisualStyleBackColor = false;
            this.writebank2.Click += new System.EventHandler(this.writebank2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(486, 30);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(183, 187);
            this.textBox1.TabIndex = 78;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 79;
            this.label1.Text = "Memory Bank1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(693, 32);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(179, 180);
            this.textBox2.TabIndex = 80;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(708, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 81;
            this.label3.Text = "Memory Bank2";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // VerifyBank1
            // 
            this.VerifyBank1.BackColor = System.Drawing.SystemColors.Control;
            this.VerifyBank1.Enabled = false;
            this.VerifyBank1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyBank1.ForeColor = System.Drawing.Color.SteelBlue;
            this.VerifyBank1.Location = new System.Drawing.Point(66, 195);
            this.VerifyBank1.Margin = new System.Windows.Forms.Padding(4);
            this.VerifyBank1.Name = "VerifyBank1";
            this.VerifyBank1.Size = new System.Drawing.Size(181, 40);
            this.VerifyBank1.TabIndex = 82;
            this.VerifyBank1.Text = "Verify Bank1";
            this.VerifyBank1.UseVisualStyleBackColor = false;
            this.VerifyBank1.Click += new System.EventHandler(this.VerifyBank1_Click);
            // 
            // VerifyBank2
            // 
            this.VerifyBank2.BackColor = System.Drawing.SystemColors.Control;
            this.VerifyBank2.Enabled = false;
            this.VerifyBank2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerifyBank2.ForeColor = System.Drawing.Color.SteelBlue;
            this.VerifyBank2.Location = new System.Drawing.Point(267, 195);
            this.VerifyBank2.Margin = new System.Windows.Forms.Padding(4);
            this.VerifyBank2.Name = "VerifyBank2";
            this.VerifyBank2.Size = new System.Drawing.Size(181, 40);
            this.VerifyBank2.TabIndex = 83;
            this.VerifyBank2.Text = "Verify Bank2";
            this.VerifyBank2.UseVisualStyleBackColor = false;
            this.VerifyBank2.Click += new System.EventHandler(this.VerifyBank2_Click);
            // 
            // BootMaster
            // 
            this.BootMaster.BackColor = System.Drawing.SystemColors.Control;
            this.BootMaster.Enabled = false;
            this.BootMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BootMaster.ForeColor = System.Drawing.Color.SeaGreen;
            this.BootMaster.Location = new System.Drawing.Point(67, 76);
            this.BootMaster.Margin = new System.Windows.Forms.Padding(4);
            this.BootMaster.Name = "BootMaster";
            this.BootMaster.Size = new System.Drawing.Size(180, 40);
            this.BootMaster.TabIndex = 84;
            this.BootMaster.Text = "Program Master";
            this.BootMaster.UseVisualStyleBackColor = false;
            this.BootMaster.Click += new System.EventHandler(this.BootMaster_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 16);
            this.label4.TabIndex = 85;
            this.label4.Text = "0%";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 86;
            this.label5.Text = "0%";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // AutoProgramBank
            // 
            this.AutoProgramBank.BackColor = System.Drawing.SystemColors.Control;
            this.AutoProgramBank.Enabled = false;
            this.AutoProgramBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AutoProgramBank.ForeColor = System.Drawing.Color.DarkCyan;
            this.AutoProgramBank.Location = new System.Drawing.Point(495, 219);
            this.AutoProgramBank.Margin = new System.Windows.Forms.Padding(4);
            this.AutoProgramBank.Name = "AutoProgramBank";
            this.AutoProgramBank.Size = new System.Drawing.Size(159, 62);
            this.AutoProgramBank.TabIndex = 87;
            this.AutoProgramBank.Text = "Auto Program\r\n Bank1";
            this.AutoProgramBank.UseVisualStyleBackColor = false;
            this.AutoProgramBank.Click += new System.EventHandler(this.AutoProgramBank_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.Control;
            this.button12.Enabled = false;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.DarkCyan;
            this.button12.Location = new System.Drawing.Point(693, 219);
            this.button12.Margin = new System.Windows.Forms.Padding(4);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(167, 62);
            this.button12.TabIndex = 88;
            this.button12.Text = "Auto Program\r\n Bank2\r\n";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // HextoBin
            // 
            this.HextoBin.BackColor = System.Drawing.SystemColors.Control;
            this.HextoBin.Enabled = false;
            this.HextoBin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HextoBin.ForeColor = System.Drawing.Color.SteelBlue;
            this.HextoBin.Location = new System.Drawing.Point(693, 289);
            this.HextoBin.Margin = new System.Windows.Forms.Padding(4);
            this.HextoBin.Name = "HextoBin";
            this.HextoBin.Size = new System.Drawing.Size(167, 40);
            this.HextoBin.TabIndex = 89;
            this.HextoBin.Text = "Hex to Bin";
            this.HextoBin.UseVisualStyleBackColor = false;
            this.HextoBin.Click += new System.EventHandler(this.HextoBin_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(682, 336);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(190, 40);
            this.textBox3.TabIndex = 90;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged_2);
            // 
            // excutebank1
            // 
            this.excutebank1.BackColor = System.Drawing.SystemColors.Control;
            this.excutebank1.Enabled = false;
            this.excutebank1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excutebank1.ForeColor = System.Drawing.Color.SteelBlue;
            this.excutebank1.Location = new System.Drawing.Point(66, 414);
            this.excutebank1.Margin = new System.Windows.Forms.Padding(4);
            this.excutebank1.Name = "excutebank1";
            this.excutebank1.Size = new System.Drawing.Size(156, 40);
            this.excutebank1.TabIndex = 91;
            this.excutebank1.Text = "Excute Bank1";
            this.excutebank1.UseVisualStyleBackColor = false;
            this.excutebank1.Click += new System.EventHandler(this.excutebank1_Click);
            // 
            // BootManager
            // 
            this.BootManager.BackColor = System.Drawing.SystemColors.Control;
            this.BootManager.Enabled = false;
            this.BootManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BootManager.ForeColor = System.Drawing.Color.SeaGreen;
            this.BootManager.Location = new System.Drawing.Point(268, 76);
            this.BootManager.Margin = new System.Windows.Forms.Padding(4);
            this.BootManager.Name = "BootManager";
            this.BootManager.Size = new System.Drawing.Size(180, 40);
            this.BootManager.TabIndex = 92;
            this.BootManager.Text = "Program Manager";
            this.BootManager.UseVisualStyleBackColor = false;
            this.BootManager.Click += new System.EventHandler(this.BootManager_Click);
            // 
            // excutebank2
            // 
            this.excutebank2.BackColor = System.Drawing.SystemColors.Control;
            this.excutebank2.Enabled = false;
            this.excutebank2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excutebank2.ForeColor = System.Drawing.Color.SteelBlue;
            this.excutebank2.Location = new System.Drawing.Point(237, 414);
            this.excutebank2.Margin = new System.Windows.Forms.Padding(4);
            this.excutebank2.Name = "excutebank2";
            this.excutebank2.Size = new System.Drawing.Size(156, 40);
            this.excutebank2.TabIndex = 93;
            this.excutebank2.Text = "Excute Bank2";
            this.excutebank2.UseVisualStyleBackColor = false;
            this.excutebank2.Click += new System.EventHandler(this.excutebank2_Click);
            // 
            // BootSmartHandle
            // 
            this.BootSmartHandle.BackColor = System.Drawing.SystemColors.Control;
            this.BootSmartHandle.Enabled = false;
            this.BootSmartHandle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BootSmartHandle.ForeColor = System.Drawing.Color.SeaGreen;
            this.BootSmartHandle.Location = new System.Drawing.Point(66, 124);
            this.BootSmartHandle.Margin = new System.Windows.Forms.Padding(4);
            this.BootSmartHandle.Name = "BootSmartHandle";
            this.BootSmartHandle.Size = new System.Drawing.Size(180, 40);
            this.BootSmartHandle.TabIndex = 94;
            this.BootSmartHandle.Text = "Program SH";
            this.BootSmartHandle.UseVisualStyleBackColor = false;
            this.BootSmartHandle.Click += new System.EventHandler(this.BootSmartHandle_Click);
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 478);
            this.Controls.Add(this.BootSmartHandle);
            this.Controls.Add(this.excutebank2);
            this.Controls.Add(this.BootManager);
            this.Controls.Add(this.excutebank1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.HextoBin);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.AutoProgramBank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BootMaster);
            this.Controls.Add(this.VerifyBank2);
            this.Controls.Add(this.VerifyBank1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.writebank2);
            this.Controls.Add(this.ReadBank2);
            this.Controls.Add(this.ReadFile);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.writebank1);
            this.Controls.Add(this.eraseban1);
            this.Controls.Add(this.erasebank2);
            this.Controls.Add(this.ReadBank1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Numeric_Erros);
            this.Controls.Add(this.Combo_PortList);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_DevVersion);
            this.Controls.Add(this.Btn_Disconnect);
            this.Controls.Add(this.Btn_Connect);
            this.Controls.Add(this.TestMCU);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Settings";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "STM32Bootloading (v1.0.0) ";
            this.Load += new System.EventHandler(this.Form_Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button TestMCU;
        private System.Windows.Forms.Button Btn_Connect;
        private System.Windows.Forms.Button Btn_Disconnect;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_DevVersion;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox Combo_PortList;
        private System.Windows.Forms.TextBox Numeric_Erros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ReadBank1;
        private System.Windows.Forms.Button erasebank2;
        private System.Windows.Forms.Button eraseban1;
        private System.Windows.Forms.Button writebank1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button ReadFile;
        private System.Windows.Forms.Button ReadBank2;
        private System.Windows.Forms.Button writebank2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button VerifyBank1;
        private System.Windows.Forms.Button VerifyBank2;
        private System.Windows.Forms.Button BootMaster;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button AutoProgramBank;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button HextoBin;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button excutebank1;
        private System.Windows.Forms.Button BootManager;
        private System.Windows.Forms.Button excutebank2;
        private System.Windows.Forms.Button BootSmartHandle;
    }
}