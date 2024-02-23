using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using STM32Bootloading.Helpers;
using STM32Bootloading.Models;
using Newtonsoft.Json;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using System.Threading;

namespace STM32Bootloading
{


    public partial class Form_Settings : Form
    {

        private static SerialPort port;
        DEV_TYPE DevType = DEV_TYPE.DC;
        // private SerialPort serialPort;
        public Form_Settings()
        {
            InitializeComponent();
            // const int OneFrim = 256;
        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> serialPorts = SerialPort.GetPortNames().ToList();
                Combo_PortList.DataSource = serialPorts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void Btn_Get_Settings_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] dataByte = new byte[2];
                System.Threading.Thread.Sleep(100);
                dataByte[0] = 0x00;
                //dataByte[1] = 0xFF;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xFF;
                port.Write(dataByte, 0, 1);
                byte[] rx_buff1 = new byte[15];
                rx_buff1 = ReadPortBytes(15);
                MessageBox.Show($"Commands\n{rx_buff1[0]:x2}\n{rx_buff1[1]:x2}\n{rx_buff1[2]:x2}\n{rx_buff1[3]:x2}\n{rx_buff1[4]:x2}\n" +
                 $"{rx_buff1[5]:x2}\n{rx_buff1[6]:x2}\n{rx_buff1[7]:x2}\n{rx_buff1[8]:x2}\n{rx_buff1[9]:x2}\n{rx_buff1[10]:x2}\n{rx_buff1[11]:x2}\n" +
                 $"{rx_buff1[12]:x2}\n{rx_buff1[13]:x2}\n{rx_buff1[14]:x2}\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_All_Disable()
        {           
            Btn_Get_Settings.Enabled = false;           
            Connect_Device.Enabled = false;
            Btn_Disconnect.Enabled = false;
            Btn_Connect.Enabled = true;           
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }

        private void Btn_connectDevice_Disable()
        {           
            Btn_Get_Settings.Enabled = false;    
            Connect_Device.Enabled = false;
            Btn_Disconnect.Enabled = true;
            Btn_Connect.Enabled = false;        
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = true;
        }


        private void Btn_All_Enable()
        {            
            Btn_Get_Settings.Enabled = true;          
            Connect_Device.Enabled = true;
            Btn_Disconnect.Enabled = true;
            Btn_Connect.Enabled = false;         
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }
             

        private byte[] ReadPortBytes(int numberOfBytes)
        {
            byte[] bytes = new byte[numberOfBytes];

            try
            {
                for (int i = 0; i < numberOfBytes; i++)
                    bytes[i] = Convert.ToByte(port.ReadByte());
                return bytes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                port.Close();

                throw;
            }
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                string port_name = Combo_PortList.Text;
                //combo_serialList = serialPorts[0];
                port = new SerialPort(port_name, 115200, Parity.None, 8, StopBits.One);
                port.WriteTimeout = 1000;
                port.ReadTimeout = 2000;
                port.Open();
                Btn_connectDevice_Disable();
                //MessageBox.Show("Port Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
           
        private void ClearBuffer()
        {
            port.DiscardOutBuffer();
            port.DiscardInBuffer();
        }

        private void Btn_Disconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (port != null && port.IsOpen)
                {
                    port.Close();
                    Btn_All_Disable();
                    //MessageBox.Show("Port Disconnected");
                }
                else
                {
                    Btn_All_Disable();
                    MessageBox.Show("Port is already disconnected");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Disconnect port failed: {ex.Message}");
            }
        }

        private void Btn_ConnectDevice_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] dataByte = new byte[1];
                System.Threading.Thread.Sleep(1);
                dataByte[0] = 0x7F;
                port.Write(dataByte, 0, 1);
               // System.Threading.Thread.Sleep(1);
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);                
                if (rx_buff[0] == 0x79)
                {                  
                    Btn_Get_Settings.Enabled = true;                  
                    Connect_Device.Enabled = false;
                    Btn_Disconnect.Enabled = true;
                    Btn_Connect.Enabled = false;                  
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = false;
                    button5.Enabled = true;
                    button6.Enabled = true;
                    button7.Enabled = false;
                    button8.Enabled = false;
                    button9.Enabled = false;
                    
                    byte[] dataByte8 = new byte[2];                    
                    //System.Threading.Thread.Sleep(100);
                    dataByte8[0] = 0x01;
                   // dataByte8[1] = 0xFE;
                    port.Write(dataByte8, 0, 1);
                    //System.Threading.Thread.Sleep(1);
                    dataByte8[0] = 0xFE;
                    port.Write(dataByte8, 0, 1);
                    byte[] rx_buff1 = new byte[5];
                    rx_buff1 = ReadPortBytes(5);
                    txt_DevVersion.Text = rx_buff1[1].ToString("x");
                    // byte[] dataByte8 = new byte[2];
                    //System.Threading.Thread.Sleep(1);
                    dataByte8[0] = 0x02;
                   // dataByte8[2] = 0xFD;
                    port.Write(dataByte8, 0, 1);
                   // System.Threading.Thread.Sleep(100);
                    dataByte8[0] = 0xFD;
                    port.Write(dataByte8, 0, 1);
                    //byte[] rx_buff1 = new byte[5];
                    rx_buff1 = ReadPortBytes(5);
                    Numeric_Erros.Text = rx_buff1[3].ToString("x");
                   
                } 
                else if (rx_buff[0] == 0x1F) MessageBox.Show($"0x1F");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        


        int Num_frim = 1;
        private void button1_Click(object sender, EventArgs e)
        {            
            for (int j = 0; j < Num_frim; j++)
            {
                byte[] dataByte = new byte[2];
                dataByte[0] = 0x11;
               // dataByte[1] = 0xEE;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xEE;
                port.Write(dataByte, 0, 1);
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    int number = 0x08000000 + (j * 0x0100);
                    byte[] dataByte1 = BitConverter.GetBytes(number);                    
                    port.Write(new byte[] { dataByte1[3] }, 0, 1);
                    port.Write(new byte[] { dataByte1[2] }, 0, 1);
                    port.Write(new byte[] { dataByte1[1] }, 0, 1);
                    port.Write(new byte[] { dataByte1[0] }, 0, 1);
                    int result = 0x00;
                    int numberOfBytes = 4;
                    for (int i = 0; i < numberOfBytes; i++)
                    {
                        result ^= dataByte1[i];
                    }
                    byte[] resultBytes = BitConverter.GetBytes(result);
                    port.Write(resultBytes, 0, 1);
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        byte[] dataByte2 = new byte[2];
                       // System.Threading.Thread.Sleep(100);
                        dataByte2[0] = 0xFF;
                        //dataByte2[1] = 0x00;
                        port.Write(dataByte2, 0, 1);
                        dataByte2[0] = 0x00;
                        port.Write(dataByte2, 0, 1);
                    }
                    byte[] rx_buff9 = new byte[1];
                    rx_buff9 = ReadPortBytes(1);
                    byte[] rx_buff1 = new byte[256];
                    rx_buff1 = ReadPortBytes(256);
                    string memoryContent = "";// "Read Memory Bank1:\n";
                    // for (int i = 0  ; i < rx_buff1.Length ; i++)
                    for (int i = 0; i < 256; i++)
                    {
                        memoryContent += $"{rx_buff1[i]:X2} ";
                        // memoryContent += $" rx_buff1[{i}] = 0x{rx_buff1[i]:X2}";

                    }                    
                    textBox1.Text = memoryContent;
                    // }
                   // MessageBox.Show(memoryContent, "Memory Content", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // MessageBox.Show($"Read Memory: \n{rx_buff1[0]:x2}\n{rx_buff1[1]:x2}\n{rx_buff1[2]:x2}\n{rx_buff1[3]:x2}\n{rx_buff1[4]:x2}\n" +
                    // $"{rx_buff1[5]:x2}\n{rx_buff1[6]:x2}\n{rx_buff1[7]:x2}\n{rx_buff1[8]:x2}\n{rx_buff1[9]:x2}\n{rx_buff1[10]:x2}\n{rx_buff1[11]:x2}\n" +
                    // $"{rx_buff1[12]:x2}\n{rx_buff1[13]:x2}\n{rx_buff1[14]:x2}\n{rx_buff1[15]:x2}\n{rx_buff1[16]:x2}\n");
                }
                else if (rx_buff[0] == 0x1F) MessageBox.Show($"0x1F");
            }
        }
                
        private void Combo_PortList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
               
        private void button3_Click(object sender, EventArgs e)
        {
            byte[] dataByte = new byte[2];
            System.Threading.Thread.Sleep(100);            
            dataByte[0] = 0x44;
            //dataByte[1] = 0xBB;
            port.Write(dataByte, 0, 1);
            dataByte[0] = 0xBB;
            port.Write(dataByte, 0, 1);
            // System.Threading.Thread.Sleep(1);
            byte[] rx_buff = new byte[1];
            rx_buff = ReadPortBytes(1);
            if (rx_buff[0] == 0x79)
            {
                byte[] dataByte1 = new byte[3];
                System.Threading.Thread.Sleep(100);
                dataByte1[0] = 0xFF;
                //dataByte1[1] = 0xFE;
                //dataByte1[2] = 0x01;
                port.Write(dataByte1, 0, 1);
                dataByte1[0] = 0xFE;                
                port.Write(dataByte1, 0, 1);
                dataByte1[0] = 0x01;
                port.Write(dataByte1, 0, 1);
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    MessageBox.Show("Successful Erase Bank1", "Successful Erase Bank1", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else if (rx_buff[0] == 0x1f) { MessageBox.Show("Not Erase Bank1"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] dataByte = new byte[2];            
            dataByte[0] = 0x44;
            //dataByte[1] = 0xBB;
            port.Write(dataByte, 0, 1);
            dataByte[0] = 0xBB;
            port.Write(dataByte, 0, 1);
            byte[] rx_buff = new byte[1];
            rx_buff = ReadPortBytes(1);
            if (rx_buff[0] == 0x79)
            {
                byte[] dataByte1 = new byte[3];
                System.Threading.Thread.Sleep(100);
                dataByte1[0] = 0xFF;
                //dataByte1[1] = 0xFD;
                //dataByte1[2] = 0x02;
                port.Write(dataByte1, 0, 1);
                dataByte1[0] = 0xFD;                
                port.Write(dataByte1, 0, 1);
                dataByte1[0] = 0x02;
                port.Write(dataByte1, 0, 1);
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    MessageBox.Show("Successful Erase Bank2", "Successful Erase Bank2", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   // MessageBox.Show("Successful Erase Bank1");
                }
            }
            else if (rx_buff[0] == 0x1f) { MessageBox.Show("Not Erase Bank1");
            }        
    }
        const int OneFrim = 256;
        private void button4_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;

            try
            {
                // Read all lines from the hex file
                string[] lines = File.ReadAllLines(filePath);
                // Read the first 256 bytes from the hex file
                // byte[] fileBytes = ReadFirst256Bytes(filePath);
                int numberOfBytes = GetNumberOfBytes(filePath);
                int j = (numberOfBytes / 256) + 1;

                for (int chunkNumber = 0; chunkNumber < j + 1; chunkNumber++)
                {

                    byte[] fileBytes = ReadNext256Bytes(filePath, chunkNumber);
                    byte xorResult = CalculateXOR(fileBytes);
                    // Display the result
                    //  resultsTextBox.AppendText($"XOR of the first 256 bytes in {Path.GetFileName(filePath)}: 0x{xorResult:X2}\r\n");
                    byte[] dataByte3 = new byte[2];
                    // System.Threading.Thread.Sleep(100);                    
                    dataByte3[0] = 0x31;
                    //dataByte3[1] = 0xCE;
                    port.Write(dataByte3, 0, 1);
                    dataByte3[0] = 0xCE;
                    port.Write(dataByte3, 0, 1);
                    byte[] rx_buff = new byte[1];

                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        int number = 0x08000000 + (chunkNumber * 0x0100);
                        byte[] dataByte1 = BitConverter.GetBytes(number);
                        port.Write(new byte[] { dataByte1[3] }, 0, 1);
                        port.Write(new byte[] { dataByte1[2] }, 0, 1);
                        port.Write(new byte[] { dataByte1[1] }, 0, 1);
                        port.Write(new byte[] { dataByte1[0] }, 0, 1);
                        int result = 0x00;
                        // int numberOfBytes = 4;
                        for (int i = 0; i < 4; i++)
                        {
                            result ^= dataByte1[i];
                        }
                        byte[] resultBytes = BitConverter.GetBytes(result);
                        port.Write(resultBytes, 0, 1);                        
                        rx_buff = ReadPortBytes(1);
                        if (rx_buff[0] == 0x79)
                        {
                            byte[] dataByte5 = new byte[1];
                            byte[] dataByte6 = new byte[OneFrim];
                            byte[] dataByte7 = new byte[1];
                           // System.Threading.Thread.Sleep(100);
                            dataByte5[0] = 0xFF;
                            dataByte7[0] = xorResult;
                            port.Write(dataByte5, 0, 1);
                            foreach (byte b in fileBytes)
                            {
                                port.Write(new byte[] { b }, 0, 1); // Send one byte
                                                                    // Thread.Sleep(1); 
                            }
                            //port.Write(fileBytes, 0, OneFrim);
                            port.Write(dataByte7, 0, 1);
                            rx_buff = ReadPortBytes(1);
                            if (rx_buff[0] == 0x79)
                            {
                                if (j == chunkNumber)
                                {
                                    MessageBox.Show("Successful Program Bank1", "Successful Program Bank1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                     //   port.Write(dataToSend, 0, dataToSend.Length);
                                }
                            }
                            else //if (rx_buff[0] == 0x1f)
                            {
                                MessageBox.Show($"Not program - NAK {rx_buff[0]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  resultsTextBox.AppendText($"An error occurred: {ex.Message}\r\n");
            }
        }

        private int GetNumberOfBytes(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                return (int)fs.Length;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string filePath = filePathTextBox.Text;
            openFileDialog1.Filter = "Bin Files|*.bin|Hex Files|*.hex|All Files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog1.FileName;
                button4.Enabled = true;
                button9.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
            }
            
        }
        private byte[] ReadNext256Bytes(string filePath, int chunkNumber)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;
                int offset = chunkNumber * 256;
                byte[] buffer = new byte[256];

                // Set the position to read the appropriate chunk
                fs.Position = offset;

                bytesRead = fs.Read(buffer, 0, 256);

                return buffer;
            }
        }
        //private byte[] ReadFirst256Bytes(string filePath)
        //{
        //    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        //    {
        //        int bytesRead;
        //        byte[] buffer = new byte[256];
        //        bytesRead = fs.Read(buffer, 0, 256);
        //        return (buffer);
        //    }
        //}

        private byte CalculateXOR(byte[] buffer)
        {

            byte result = 0xff;
            int numberOfBytes = OneFrim;
            for (int i = 0; i < numberOfBytes; i++)
            {
                result ^= buffer[i];
            }
            return result;
        }
        private void filePathTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void resultsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_DevVersion_TextChanged(object sender, EventArgs e)
        {

        }

        private void Numeric_Battery_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Numeric_Erros_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }   

        private void button6_Click(object sender, EventArgs e)
        {
            
            for (int j = 0; j < Num_frim; j++)
            {
                byte[] dataByte = new byte[2];
                System.Threading.Thread.Sleep(100);
                dataByte[0] = 0x11;
                //dataByte[1] = 0xEE;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xEE;
                port.Write(dataByte, 0, 1);
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    int number = 0x08100000 + ((j) * 0x0100);
                    byte[] dataByte1 = BitConverter.GetBytes(number);
                    port.Write(new byte[] { dataByte1[3] }, 0, 1);
                    port.Write(new byte[] { dataByte1[2] }, 0, 1);
                    port.Write(new byte[] { dataByte1[1] }, 0, 1);
                    port.Write(new byte[] { dataByte1[0] }, 0, 1);
                    int result = 0x00;
                    int numberOfBytes = 4;
                    for (int i = 0; i < numberOfBytes; i++)
                    {
                        result ^= dataByte1[i];
                    }
                    byte[] resultBytes = BitConverter.GetBytes(result);
                    port.Write(resultBytes, 0, 1);
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        byte[] dataByte2 = new byte[2];
                       // System.Threading.Thread.Sleep(100);
                        dataByte2[0] = 0xFF;
                        //dataByte2[1] = 0x00;
                        port.Write(dataByte2, 0, 1);
                        dataByte2[0] = 0x00;
                        port.Write(dataByte2, 0, 1);
                    }
                    byte[] rx_buff9 = new byte[1];
                    rx_buff9 = ReadPortBytes(1);
                    byte[] rx_buff1 = new byte[256];
                    rx_buff1 = ReadPortBytes(256);
                    string memoryContent = "";// Read Memory Bank2:\n";
                    // for (int i = 0  ; i < rx_buff1.Length ; i++)
                    for (int i = 0; i < 256; i++)
                    {
                        memoryContent += $"{rx_buff1[i]:X2} ";
                        // memoryContent += $" rx_buff1[{i}] = 0x{rx_buff1[i]:X2}";

                    }
                    textBox2.Text = memoryContent;
                    //MessageBox.Show(memoryContent, "Memory Content", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rx_buff[0] == 0x1F) MessageBox.Show($"0x1F");
            }
        }
                
        private void button7_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;

            try
            {
                // Read all lines from the hex file
                string[] lines = File.ReadAllLines(filePath);
                // Read the first 256 bytes from the hex file
                // byte[] fileBytes = ReadFirst256Bytes(filePath);
                int numberOfBytes = GetNumberOfBytes(filePath);
                int j = (numberOfBytes / 256) + 1;

                for (int chunkNumber = 0; chunkNumber < j + 1; chunkNumber++)
                {

                    byte[] fileBytes = ReadNext256Bytes(filePath, chunkNumber);
                    byte xorResult = CalculateXOR(fileBytes);
                    // Display the result
                    //  resultsTextBox.AppendText($"XOR of the first 256 bytes in {Path.GetFileName(filePath)}: 0x{xorResult:X2}\r\n");
                    byte[] dataByte3 = new byte[2];                                       
                    dataByte3[0] = 0x31;
                    //dataByte3[1] = 0xCE;
                    port.Write(dataByte3, 0, 1);
                    dataByte3[0] = 0xCE;
                    port.Write(dataByte3, 0, 1);
                    byte[] rx_buff = new byte[1];
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        int number = 0x08100000 + (chunkNumber * 0x0100);
                        byte[] dataByte1 = BitConverter.GetBytes(number);
                        port.Write(new byte[] { dataByte1[3] }, 0, 1);
                        port.Write(new byte[] { dataByte1[2] }, 0, 1);
                        port.Write(new byte[] { dataByte1[1] }, 0, 1);
                        port.Write(new byte[] { dataByte1[0] }, 0, 1);
                        int result = 0x00;
                        // int numberOfBytes = 4;
                        for (int i = 0; i < 4; i++)
                        {
                            result ^= dataByte1[i];
                        }
                        byte[] resultBytes = BitConverter.GetBytes(result);
                        port.Write(resultBytes, 0, 1);
                        
                        rx_buff = ReadPortBytes(1);
                        if (rx_buff[0] == 0x79)
                        {
                            byte[] dataByte5 = new byte[1];
                            byte[] dataByte6 = new byte[OneFrim];
                            byte[] dataByte7 = new byte[1];
                           // System.Threading.Thread.Sleep(100);
                            dataByte5[0] = 0xFF;
                            dataByte7[0] = xorResult;
                            port.Write(dataByte5, 0, 1);                           
                            foreach (byte b in fileBytes)
                            {
                                port.Write(new byte[] { b }, 0, 1); // Send one byte
                               // Thread.Sleep(1); 
                            }
                           // port.Write(fileBytes, 0, OneFrim);
                            port.Write(dataByte7, 0, 1);
                            rx_buff = ReadPortBytes(1);
                            if (rx_buff[0] == 0x79)
                            {
                                if (j == chunkNumber)
                                {

                                    MessageBox.Show("Successful Program Bank2", "Successful Programing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                   
                                    //   port.Write(dataToSend, 0, dataToSend.Length);
                                }
                            }
                            else //if (rx_buff[0] == 0x1f)
                            {
                                MessageBox.Show($"Not program - NAK {rx_buff[0]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //  resultsTextBox.AppendText($"An error occurred: {ex.Message}\r\n");
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private bool ByteArraysEqual(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
                return false;

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                    return false;
            }

            return true;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;
            int numberOfBytes = GetNumberOfBytes(filePath);
            int NumPage = (numberOfBytes / 256) + 1;
            //string filePath = filePathTextBox.Text;
            for (int j = 0; j < NumPage; j++)
            {
                // Read all lines from the hex file
                string[] lines = File.ReadAllLines(filePath);                                
                byte[] fileBytes = ReadNext256Bytes(filePath, j);
                byte[] dataByte = new byte[2];
                //System.Threading.Thread.Sleep(100);
                dataByte[0] = 0x11;
                //dataByte[1] = 0xEE;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xEE;
                port.Write(dataByte, 0, 1);
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    int number = 0x08000000 + (j * 0x0100);
                    byte[] dataByte1 = BitConverter.GetBytes(number);
                    port.Write(new byte[] { dataByte1[3] }, 0, 1);
                    port.Write(new byte[] { dataByte1[2] }, 0, 1);
                    port.Write(new byte[] { dataByte1[1] }, 0, 1);
                    port.Write(new byte[] { dataByte1[0] }, 0, 1);
                    int result = 0x00;
                    int numAddress = 4;
                    for (int i = 0; i < numAddress; i++)
                    {
                        result ^= dataByte1[i];
                    }
                    byte[] resultBytes = BitConverter.GetBytes(result);
                    port.Write(resultBytes, 0, 1);
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        byte[] dataByte2 = new byte[2];                        
                        dataByte2[0] = 0xFF;
                        //dataByte2[1] = 0x00;
                        port.Write(dataByte2, 0, 1);
                        dataByte2[0] = 0x00;
                        port.Write(dataByte2, 0, 1);
                    }
                        byte[] rx_buff9 = new byte[1];
                        rx_buff9 = ReadPortBytes(1);
                        byte[] rx_buff1 = new byte[256];      
                        rx_buff1 = ReadPortBytes(256);
                    if (ByteArraysEqual(fileBytes, rx_buff1) && (NumPage-1 == j))
                    {
                        MessageBox.Show("Verify Ok", "Verification Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                    else if(!ByteArraysEqual(fileBytes, rx_buff1))
                    {
                        MessageBox.Show("Verify Fail", "Verification Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                
                }
                else if (rx_buff[0] == 0x1F) MessageBox.Show($"0x1F");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;
            int numberOfBytes = GetNumberOfBytes(filePath);
            int NumPage = (numberOfBytes / 256) + 1;
            //string filePath = filePathTextBox.Text;
            for (int j = 0; j < NumPage; j++)
            {
                // Read all lines from the hex file
                string[] lines = File.ReadAllLines(filePath);
                byte[] fileBytes = ReadNext256Bytes(filePath, j);
                byte[] dataByte = new byte[2];
                //System.Threading.Thread.Sleep(100);
                dataByte[0] = 0x11;
                //dataByte[1] = 0xEE;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xEE;
                port.Write(dataByte, 0, 1);
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    int number = 0x08100000 + (j * 0x0100);
                    byte[] dataByte1 = BitConverter.GetBytes(number);
                    port.Write(new byte[] { dataByte1[3] }, 0, 1);
                    port.Write(new byte[] { dataByte1[2] }, 0, 1);
                    port.Write(new byte[] { dataByte1[1] }, 0, 1);
                    port.Write(new byte[] { dataByte1[0] }, 0, 1);
                    int result = 0x00;
                    int numAddress = 4;
                    for (int i = 0; i < numAddress; i++)
                    {
                        result ^= dataByte1[i];
                    }
                    byte[] resultBytes = BitConverter.GetBytes(result);
                    port.Write(resultBytes, 0, 1);
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        byte[] dataByte2 = new byte[2];
                        dataByte2[0] = 0xFF;
                        //dataByte2[1] = 0x00;
                        port.Write(dataByte2, 0, 1);
                        dataByte2[0] = 0x00;
                        port.Write(dataByte2, 0, 1);
                    }
                    byte[] rx_buff9 = new byte[1];
                    rx_buff9 = ReadPortBytes(1);
                    byte[] rx_buff1 = new byte[256];
                    rx_buff1 = ReadPortBytes(256);
                    if (ByteArraysEqual(fileBytes, rx_buff1) && (NumPage - 1 == j))
                    {
                        MessageBox.Show("Verify Ok", "Verification Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else if (!ByteArraysEqual(fileBytes, rx_buff1))
                    {
                        MessageBox.Show("Verify Fail", "Verification Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                }
                else if (rx_buff[0] == 0x1F) MessageBox.Show($"0x1F");

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] dataByte = new byte[1];
                System.Threading.Thread.Sleep(1);
                dataByte[0] = 0x42;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0x6f;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0x6f;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0x74;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0x74;                
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x6f)
                { 
                button10.Enabled = false;
                System.Threading.Thread.Sleep(4000);
                Connect_Device.Enabled = true;               
                }
                else
                {
                    MessageBox.Show($"Master CPU not answer");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);         
          
            }
         }
    }
}
    


