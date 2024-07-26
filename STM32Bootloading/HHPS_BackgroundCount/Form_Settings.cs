using Newtonsoft.Json;
using STM32Bootloading.Helpers;
using STM32Bootloading.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

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
           
        }

        private void Form_Settings_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> serialPorts = SerialPort.GetPortNames().ToList();
                Combo_PortList.DataSource = serialPorts;
                HextoBin.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        

        private void TestMCU_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] dataByte = new byte[2];
                System.Threading.Thread.Sleep(100);
                dataByte[0] = 0x00; //GET COMMAND               
                dataByte[1] = 0xFF; //GET COMMAND               
                port.Write(dataByte, 0, 2);
                //dataByte[0] = 0xFF;
                //port.Write(dataByte, 0, 1);
                byte[] rx_buff1 = new byte[15];
                rx_buff1 = ReadPortBytes(15);
                MessageBox.Show($"Test Pass\n{rx_buff1[0]:x2}\n{rx_buff1[1]:x2}\n{rx_buff1[2]:x2}\n{rx_buff1[3]:x2}\n{rx_buff1[4]:x2}\n" +
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
            TestMCU.Enabled = false;       
            Btn_Disconnect.Enabled = false;
            Btn_Connect.Enabled = true;           
            ReadBank1.Enabled = false;
            erasebank2.Enabled = false;
            eraseban1.Enabled = false;
            writebank1.Enabled = false;
            ReadFile.Enabled = false;
            ReadBank2.Enabled = false;
            writebank2.Enabled = false;
            VerifyBank1.Enabled = false;
            VerifyBank2.Enabled = false;
            HextoBin.Enabled = true;
            BootManager.Enabled = false;
            BootMaster.Enabled = false;
        }

        private void WriteMaster_Disable()
        {
            TestMCU.Enabled = false;
            ReadBank1.Enabled = false;
            eraseban1.Enabled = false;
            writebank1.Enabled = false;
            ReadFile.Enabled = false;
            VerifyBank1.Enabled = false;
            AutoProgramBank.Enabled = false;
            excutebank1.Enabled = false;
            BootMaster.Enabled = false;
            BootManager.Enabled = false;
            VerifyBank2.Enabled = false;
            ReadBank2.Enabled = false;
            writebank2.Enabled = false;
            erasebank2.Enabled = false;
            excutebank2.Enabled = false;
        }

        private void WriteMaster_Enable()
        {
            TestMCU.Enabled = true;
            ReadBank1.Enabled = true;
            eraseban1.Enabled = true;
            writebank1.Enabled = true;
            ReadFile.Enabled = true;
            VerifyBank1.Enabled = true;
            AutoProgramBank.Enabled = true;
            excutebank1.Enabled = true;
            BootMaster.Enabled = true;
            BootManager.Enabled = true;
            VerifyBank2.Enabled = true;
            ReadBank2.Enabled = true;
            writebank2.Enabled = true;
            erasebank2.Enabled = true;
            excutebank2.Enabled = true;
        }
        private void WriteManger_Disable()
        {
            TestMCU.Enabled = false;           
            ReadBank1.Enabled = false;          
            eraseban1.Enabled = false;
            writebank1.Enabled = false;
            ReadFile.Enabled = false;           
            VerifyBank1.Enabled = false;           
            AutoProgramBank.Enabled = false;
            excutebank1.Enabled = false;
            BootMaster.Enabled = false;
            BootManager.Enabled = false;
            
        }

        private void WriteManger_Enable()
        {
            TestMCU.Enabled = false;
            ReadBank1.Enabled = true;
            eraseban1.Enabled = true;
            writebank1.Enabled = true;
            ReadFile.Enabled = true;
            VerifyBank1.Enabled = true;           
            excutebank1.Enabled = true;
        }
        private void Btn_connectDevice_Disable()
        {           
            TestMCU.Enabled = false;   
            Btn_Disconnect.Enabled = true;
            Btn_Connect.Enabled = false;        
            ReadBank1.Enabled = false;
            erasebank2.Enabled = false;
            eraseban1.Enabled = false;
            writebank1.Enabled = false;
            ReadFile.Enabled = false;
            ReadBank2.Enabled = false;
            writebank2.Enabled = false;
            VerifyBank1.Enabled = false;
            VerifyBank2.Enabled = false;
            BootMaster.Enabled = true;
            BootManager.Enabled = true;
            BootSmartHandle.Enabled = true;
            AutoProgramBank.Enabled = false;
            HextoBin.Enabled = true;
            BootManager.Enabled = true;
            excutebank1.Enabled = false;
            excutebank2.Enabled = false;
        }


        private void Btn_All_Enable()
        {            
            TestMCU.Enabled = true;       
            Btn_Disconnect.Enabled = true;
            Btn_Connect.Enabled = false;         
            ReadBank1.Enabled = true;
            erasebank2.Enabled = true;
            eraseban1.Enabled = true;
            writebank1.Enabled = true;
            HextoBin.Enabled = true;
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

                //port.Close();
                return null;
                //throw;
            }
        }

        private void Btn_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                string port_name = Combo_PortList.Text;
                //combo_serialList = serialPorts[0];
                port = new SerialPort(port_name, 115200, Parity.None, 8, StopBits.One);
                port.WriteTimeout = 5000;
                port.ReadTimeout = 8000;
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
                    HextoBin.Enabled = true;
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

        
        private void MasterConnct1()
        {
            try
            {
                byte[] dataByte = new byte[1];
                System.Threading.Thread.Sleep(1000);
                port.DiscardInBuffer();
                port.DiscardOutBuffer();
                dataByte[0] = 0x7F;//requst confirmatin for boot command
                port.Write(dataByte, 0, 1);                
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79) //confirmatin
                {
                    TestMCU.Enabled = true;                    
                    Btn_Disconnect.Enabled = true;
                    Btn_Connect.Enabled = false;
                    ReadBank1.Enabled = true;                    
                    eraseban1.Enabled = true;
                    writebank1.Enabled = false;
                    ReadFile.Enabled = true;                    
                    VerifyBank1.Enabled = false;
                    VerifyBank2.Enabled = false;
                    HextoBin.Enabled = true;
                    excutebank1.Enabled = true;
                    excutebank2.Enabled = true;
                    erasebank2.Enabled = true;
                    ReadBank2.Enabled = true;
                    System.Threading.Thread.Sleep(10);
                    byte[] dataByte8 = new byte[2];                    
                    dataByte8[0] = 0x01; //request Ver                  
                    dataByte8[1] = 0xFE;
                    port.Write(dataByte8, 0, 2);
                    byte[] rx_buff1 = new byte[5];
                    rx_buff1 = ReadPortBytes(5);
                    txt_DevVersion.Text = rx_buff1[1].ToString("x");
                    System.Threading.Thread.Sleep(10);
                    dataByte8[0] = 0x02;//request ID
                    dataByte8[1] = 0xFD;
                    port.Write(dataByte8, 0, 2);
                    rx_buff1 = ReadPortBytes(5);
                    Numeric_Erros.Text = rx_buff1[3].ToString("x");
                }
                else if (rx_buff[0] == 0x1F) MessageBox.Show($"0x1F");
            }
            catch
            {
                MessageBox.Show($"Nothing");
            }
        }

        private void Managerconnct()
        {
            try
            {
                byte[] dataByte = new byte[1];
                System.Threading.Thread.Sleep(1);
                dataByte[0] = 0x7F;//requst confirmatin for boot command
                port.Write(dataByte, 0, 1);
                System.Threading.Thread.Sleep(100);
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)//confirmation
                {
                    TestMCU.Enabled = true;                    
                    Btn_Disconnect.Enabled = true;
                    Btn_Connect.Enabled = false;
                    ReadBank1.Enabled = true;                    
                    eraseban1.Enabled = true;
                    writebank1.Enabled = false;
                    ReadFile.Enabled = true;                    
                    VerifyBank1.Enabled = false;
                    VerifyBank2.Enabled = false;
                    HextoBin.Enabled = true;
                    excutebank1.Enabled = false;
                    excutebank2.Enabled = false;
                    byte[] dataByte8 = new byte[2];                   
                    dataByte8[0] = 0x01; //request Ver                   
                    port.Write(dataByte8, 0, 1);                    
                    dataByte8[0] = 0xFE;
                    port.Write(dataByte8, 0, 1);
                    byte[] rx_buff1 = new byte[5];
                    rx_buff1 = ReadPortBytes(5);
                    txt_DevVersion.Text = rx_buff1[1].ToString("x");                    
                    dataByte8[0] = 0x02;//request ID                    
                    port.Write(dataByte8, 0, 1);                    
                    dataByte8[0] = 0xFD;
                    port.Write(dataByte8, 0, 1);                    
                    rx_buff1 = ReadPortBytes(5);
                    Numeric_Erros.Text = rx_buff1[3].ToString("x");
                }
                else if (rx_buff[0] == 0x1F) MessageBox.Show($"0x1F");
            }
            catch
            {
                MessageBox.Show($"0x1F");
            }
        }
        private void Read1()
        {
            for (int j = 0; j < Num_frim; j++)
            {
                byte[] dataByte = new byte[2];
                dataByte[0] = 0x11;                
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
                        dataByte2[0] = 0xFF;                        
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
                }
                else if (rx_buff[0] == 0x1F) MessageBox.Show($"0x1F");
            }

        }


        int Num_frim = 1;
        

        private void ReadBank1_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < Num_frim; j++)
            {
                byte[] dataByte = new byte[2];
                byte[] tx_buff = new byte[5];
                dataByte[0] = 0x11;// READ COMMAND                
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xEE;
                port.Write(dataByte, 0, 1);
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    int number = 0x08000000 + (j * 0x0100);//ADDRESS

                    byte[] dataByte1 = BitConverter.GetBytes(number);
                    //port.Write(new byte[] { dataByte1[3] }, 0, 1);
                    //port.Write(new byte[] { dataByte1[2] }, 0, 1);
                    //port.Write(new byte[] { dataByte1[1] }, 0, 1);
                    //port.Write(new byte[] { dataByte1[0] }, 0, 1);
                    tx_buff[3] = dataByte1[0];
                    tx_buff[2] = dataByte1[1];
                    tx_buff[1] = dataByte1[2];
                    tx_buff[0] = dataByte1[3];
                    byte result = 0x00;
                    int numberOfBytes = 4;
                    for (int i = 0; i < numberOfBytes; i++)
                    {
                        result ^= dataByte1[i];
                    }
                    tx_buff[4] = result;
                    
                    port.Write(tx_buff, 0, 5);
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        byte[] dataByte2 = new byte[2];
                        dataByte2[0] = 0xFF; //NUMBER OF BYTE                       
                        dataByte2[1] = 0x00;
                        port.Write(dataByte2, 0, 2);
                    }
                    else
                        break;
                    //byte[] rx_buff9 = new byte[1];
                    //rx_buff9 = ReadPortBytes(1);
                    byte[] rx_buff1 = new byte[256];
                    rx_buff1 = ReadPortBytes(256);
                    string memoryContent = "";// "Read Memory Bank1:\n";
                    // for (int i = 0  ; i < rx_buff1.Length ; i++)
                    for (int i = 0; i < 256; i++)
                    {
                        memoryContent += $"{rx_buff1[i]:X2} ";
                    }
                    textBox1.Text = memoryContent;                   
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
               
        

        private void eraseban1_Click(object sender, EventArgs e)
        {
            if (flag_manager == 0) //BOOT MANAGER COMMAND
            {
                byte[] dataByte = new byte[2];
                System.Threading.Thread.Sleep(100);
                dataByte[0] = 0x44;//ERASE COMMAND               
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xBB;
                port.Write(dataByte, 0, 1);               
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    byte[] dataByte1 = new byte[3];
                    System.Threading.Thread.Sleep(100);
                    dataByte1[0] = 0xFF; //ERASE BANK1                   
                    port.Write(dataByte1, 0, 1);
                    dataByte1[0] = 0xFE;
                    port.Write(dataByte1, 0, 1);
                    dataByte1[0] = 0x01;
                    port.Write(dataByte1, 0, 1);
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        Read1();
                        MessageBox.Show("Successful Erase Bank1", "Successful Erase Bank1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (rx_buff[0] == 0x1f)
                {
                    MessageBox.Show("Not Erase Bank1");
                }
            }
            else//BOOT MASTER COMMAND
            {
                byte[] dataByte = new byte[2];
                System.Threading.Thread.Sleep(100);
                dataByte[0] = 0x44;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xBB;
                port.Write(dataByte, 0, 1);               
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    byte result = 0;
                    byte NumPage = 0xFF;
                    byte[] dataByte1 = new byte[3];                    
                    dataByte1[0] = 0x00;
                    result ^= dataByte1[0];
                    port.Write(dataByte1, 0, 1);
                    dataByte1[0] = NumPage;
                    result ^= dataByte1[0];
                    port.Write(dataByte1, 0, 1);


                    for (ushort i = 0; i <= NumPage; i++)
                    {
                        byte upperByte = (byte)(i >> 8);   // Extracting upper byte
                        byte lowerByte = (byte)(i & 0xFF); // Extracting lower byte
                        byte[] bytesToSendUp = { upperByte };
                        byte[] bytesToSendlow = { lowerByte };
                        port.Write(bytesToSendUp, 0, 1);
                        port.Write(bytesToSendlow, 0, 1);
                        // XOR each byte separately
                        result ^= upperByte;
                        result ^= lowerByte;
                    }
                    byte[] resultBytes = BitConverter.GetBytes(result);
                    port.Write(resultBytes, 0, 1);
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        Read1();
                        MessageBox.Show("Successful EraseManager", "Successful Erase Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (rx_buff[0] == 0x1f)
                    {
                        MessageBox.Show("Not Erase Manager");
                    }

                }
                else if (rx_buff[0] == 0x1f)
                {
                    MessageBox.Show("Not Erase Manager");
                }
            }
        }
        void Erase1()
        {
            byte[] dataByte = new byte[2];
            System.Threading.Thread.Sleep(100);
            dataByte[0] = 0x44;            
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
                port.Write(dataByte1, 0, 1);
                dataByte1[0] = 0xFE;
                port.Write(dataByte1, 0, 1);
                dataByte1[0] = 0x01;
                port.Write(dataByte1, 0, 1);
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    Read1();
                   // MessageBox.Show("Successful Erase Bank1", "Successful Erase Bank1", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (rx_buff[0] == 0x1f) { MessageBox.Show("Not Erase Bank1"); 
            }
        }
        const int OneFrim = 256;


        private void writebank_shh()
        {
            string filePath = filePathTextBox.Text;

            try
            {
                // Read all lines from the hex file
                string[] lines = File.ReadAllLines(filePath);
                // Read the first 256 bytes from the hex file
                // byte[] fileBytes = ReadFirst256Bytes(filePath);
                int numberOfBytes = GetNumberOfBytes(filePath);
                byte chunkSize = 0xff;
                int chunkQty = (numberOfBytes / chunkSize) + 1;
                
                for (int chunkNumber = 0; chunkNumber <= chunkQty; chunkNumber++)
                {
                    label4.Text = $"{((chunkNumber) * 100) / chunkQty}%";
                    byte[] fileBytes = ReadNext256Bytes(filePath, chunkNumber);
                    byte xorResult = CalculateXOR(fileBytes);
                    // Display the result
                    //  resultsTextBox.AppendText($"XOR of the first 256 bytes in {Path.GetFileName(filePath)}: 0x{xorResult:X2}\r\n");
                    byte[] cmdByte = new byte[2];
                    cmdByte[0] = 0x31; //WRITE COMMAND                   
                    cmdByte[1] = 0xCE;
                    port.Write(cmdByte, 0, 2);
                    System.Threading.Thread.Sleep(10);
                    byte[] rx_buff = new byte[1];
                    byte[] addr_reversed = new byte[5];
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        int number = 0x08000000 + (chunkNumber * 0x0100);//ADDRESS + CHECKSUM
                        byte[] addr = BitConverter.GetBytes(number);
                        addr_reversed[0] = addr[3];
                        addr_reversed[1] = addr[2];
                        addr_reversed[2] = addr[1];
                        addr_reversed[3] = addr[0];
                        byte checksum = 0x00;
                        // int numberOfBytes = 4;
                        for (int i = 0; i < 4; i++)
                        {
                            checksum ^= addr_reversed[i];
                        }
                        addr_reversed[4] = checksum;
                        port.Write(addr_reversed, 0, addr_reversed.Length);
                        System.Threading.Thread.Sleep(50);
                        rx_buff = ReadPortBytes(1);
                        if (rx_buff[0] != 0x79)
                        {
                            MessageBox.Show($"Failed programming");
                            return;
                        }

                        byte[] dataByte = new byte[1];
                        dataByte[0] = chunkSize;
                        dataByte = AppendByteArray(dataByte, fileBytes);
                        dataByte = AppendByte(dataByte, xorResult);
                        //port.Write(dataByte, 0, dataByte.Length);
                        port.Write(dataByte, 0, dataByte.Length-100);
                        System.Threading.Thread.Sleep(80);
                        port.Write(dataByte, dataByte.Length - 100, 100);
                        rx_buff = ReadPortBytes(1);
                        if (rx_buff[0] == 0x79)
                        {
                            if (chunkQty == chunkNumber)
                            {
                                //Read1();
                                cmdByte[0] = 0x21; //WRITE COMMAND                   
                                cmdByte[1] = 0xDE;
                                port.Write(cmdByte, 0, 2);
                                rx_buff = ReadPortBytes(1);
                                if (rx_buff[0] != 0x79)
                                {
                                    MessageBox.Show($"Failed programming");
                                    return;
                                }
                                byte[] addrByte = new byte[5];
                                addrByte[0] = 0x08; //WRITE COMMAND                   
                                addrByte[1] = 0x00;
                                addrByte[2] = 0x00;
                                addrByte[3] = 0x00;
                                addrByte[4] = 0x08;
                                port.Write(addrByte, 0, 5);
                                rx_buff = ReadPortBytes(1);
                                if (rx_buff[0] != 0x79)
                                {
                                    MessageBox.Show($"Failed programming");
                                    return;
                                }
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
                excutebank1.Enabled = true;
            }
            catch (Exception ex)
            {
                //  resultsTextBox.AppendText($"An error occurred: {ex.Message}\r\n");
            }
        }
        int Erase_shh()
        {
            byte[] dataByte = new byte[2];
            int memory_size = 127;
            dataByte[0] = 0x44;
            dataByte[1] = 0xBB;
            port.Write(dataByte, 0, 2);
            byte[] rx_buff = new byte[1];
            rx_buff = ReadPortBytes(1);
            if (rx_buff[0] == 0x1F)
            {
                return -1;
            }

            System.Threading.Thread.Sleep(100);
            dataByte[0] = (byte)(memory_size / 256);
            dataByte[1] = (byte)(memory_size%256);
            port.Write(dataByte, 0, 2);
            byte[] dataByte1 = new byte[2];
            int page_number = 0;
            byte[] sumxor = new byte[1];
            sumxor[0] = dataByte[1];
            do
            {
                dataByte1[0] = (byte)(page_number/256);
                dataByte1[1] = (byte)(page_number%256);
                //sumxor[0] += dataByte1[1];
                //dataByte1 = BitConverter.GetBytes(page_number);
                port.Write(dataByte1, 0, 2);
                sumxor[0] ^= dataByte1[1];
                page_number++;
            } while (page_number <= memory_size + 1);

                System.Threading.Thread.Sleep(10);
            dataByte1[0] = sumxor[0];
            port.Write(dataByte1, 0, 1);
            rx_buff[0] = 0;
            rx_buff = ReadPortBytes(1);
            if (rx_buff[0] == 0x79)
            {
            
                MessageBox.Show("Successful Erase SHH", "Successful Erase SHH", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            if (rx_buff[0] == 0x1f)
            {
                MessageBox.Show("Not Erase SHH");
            }
            return 1;
        }
        static byte[] AppendByte(byte[] byteArray, byte singleByte)
        {
            // Create a new array with size of original array + 1
            byte[] result = new byte[byteArray.Length + 1];

            // Copy the original array to the new array
            Array.Copy(byteArray, result, byteArray.Length);

            // Add the single byte to the end of the new array
            result[result.Length - 1] = singleByte;

            return result;
        }

        static byte[] AppendByteArray(byte[] originalArray, byte[] byteArrayToAppend)
        {
            // Create a new array with size of original array + array to append
            byte[] result = new byte[originalArray.Length + byteArrayToAppend.Length];

            // Copy the original array to the new array
            Array.Copy(originalArray, result, originalArray.Length);

            // Copy the byte array to append to the end of the new array
            Array.Copy(byteArrayToAppend, 0, result, originalArray.Length, byteArrayToAppend.Length);

            return result;
        }

        private void erasebank2_Click(object sender, EventArgs e)
        {
            byte[] dataByte = new byte[2];
            dataByte[0] = 0x44; //ERASE COMMAND           
            port.Write(dataByte, 0, 1);
            dataByte[0] = 0xBB;
            port.Write(dataByte, 0, 1);
            byte[] rx_buff = new byte[1];
            rx_buff = ReadPortBytes(1);
            if (rx_buff[0] == 0x79)
            {
                byte[] dataByte1 = new byte[3];
                System.Threading.Thread.Sleep(100);
                dataByte1[0] = 0xFF; //ERASE BANK2               
                port.Write(dataByte1, 0, 1);
                dataByte1[0] = 0xFD;
                port.Write(dataByte1, 0, 1);
                dataByte1[0] = 0x02;
                port.Write(dataByte1, 0, 1);
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    Read2();
                    MessageBox.Show("Successful Erase Bank2", "Successful Erase Bank2", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // MessageBox.Show("Successful Erase Bank1");
                }
            }
            else if (rx_buff[0] == 0x1f)
            {
                MessageBox.Show("Not Erase Bank1");
            }
        }

        void Earse2()
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
                port.Write(dataByte1, 0, 1);
                dataByte1[0] = 0xFD;
                port.Write(dataByte1, 0, 1);
                dataByte1[0] = 0x02;
                port.Write(dataByte1, 0, 1);
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                   
                   // MessageBox.Show("Successful Erase Bank2", "Successful Erase Bank2", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // MessageBox.Show("Successful Erase Bank1");
                }
            }
            else if (rx_buff[0] == 0x1f)
            {
                MessageBox.Show("Not Erase Bank2");
            }

        }
        

        private void writebank1_Click(object sender, EventArgs e)
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

                for (int chunkNumber = 0; chunkNumber <= j; chunkNumber++)
                {
                    label4.Text = $"{((chunkNumber) * 100) / j}%";
                    byte[] fileBytes = ReadNext256Bytes(filePath, chunkNumber);
                    byte xorResult = CalculateXOR(fileBytes);
                    // Display the result
                    //  resultsTextBox.AppendText($"XOR of the first 256 bytes in {Path.GetFileName(filePath)}: 0x{xorResult:X2}\r\n");
                    byte[] dataByte3 = new byte[2];                                       
                    dataByte3[0] = 0x31; //WRITE COMMAND                   
                    dataByte3[1] = 0xCE;
                    port.Write(dataByte3, 0, 2);

                    byte[] rx_buff = new byte[1];
                    byte[] tx_buff = new byte[5];
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        int number = 0x08000000 + (chunkNumber * 0x0100);//ADDRESS + CHECKSUM
                        byte[] dataByte1 = BitConverter.GetBytes(number);
                        //port.Write(new byte[] { dataByte1[3] }, 0, 1);
                        //port.Write(new byte[] { dataByte1[2] }, 0, 1);
                        //port.Write(new byte[] { dataByte1[1] }, 0, 1);
                        //port.Write(new byte[] { dataByte1[0] }, 0, 1);
                        tx_buff[0] = dataByte1[3];
                        tx_buff[1] = dataByte1[2];
                        tx_buff[2] = dataByte1[1];
                        tx_buff[3] = dataByte1[0];
                        byte result = 0x00;
                        // int numberOfBytes = 4;
                        for (int i = 0; i < 4; i++)
                        {
                            result ^= dataByte1[i];
                        }
                        tx_buff[4] = result;
                        port.Write(tx_buff, 0, 5);
                        rx_buff = ReadPortBytes(1);
                        if (rx_buff[0] == 0x79)
                        {
                            byte[] dataByte5 = new byte[1];
                            byte[] dataByte6 = new byte[OneFrim];
                            byte[] dataByte7 = new byte[1];
                            // System.Threading.Thread.Sleep(100);
                            dataByte5[0] = 0xFF;//NUMBER OF BYTE
                            dataByte7[0] = xorResult;//CHECKSUM
                            port.Write(dataByte5, 0, 1);
                            port.Write(fileBytes, 0, fileBytes.Length);
                            //foreach (byte b in fileBytes)
                            //{
                            //    port.Write(new byte[] { b }, 0, 1); // Send one byte
                            //                                        // Thread.Sleep(1); 
                            //}
                            //port.Write(fileBytes, 0, OneFrim);
                            System.Threading.Thread.Sleep(100);
                            port.Write(dataByte7, 0, 1);
                            rx_buff = ReadPortBytes(1);
                            if (rx_buff[0] == 0x79)
                            {
                                if (j == chunkNumber)
                                {
                                    Read1();
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
                excutebank1.Enabled = true;
            }
            catch (Exception ex)
            {
                //  resultsTextBox.AppendText($"An error occurred: {ex.Message}\r\n");
            }
        }

        void Write1()
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

                for (int chunkNumber = 0; chunkNumber <= j; chunkNumber++)
                {
                    label4.Text = $"{((chunkNumber) * 100) / j}%";
                    byte[] fileBytes = ReadNext256Bytes(filePath, chunkNumber);
                    byte xorResult = CalculateXOR(fileBytes);
                    // Display the result
                    //  resultsTextBox.AppendText($"XOR of the first 256 bytes in {Path.GetFileName(filePath)}: 0x{xorResult:X2}\r\n");
                    byte[] dataByte3 = new byte[2];                                       
                    dataByte3[0] = 0x31;                   
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
                                    Read1();
                                   // MessageBox.Show("Successful Program Bank1", "Successful Program Bank1", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                excutebank1.Enabled = true;
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
       

        private void ReadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string filePath = filePathTextBox.Text;
            if (flag_manager == 0)
            {
                openFileDialog1.Filter = "Bin Files|*.bin";//|Hex Files|*.hex|All Files|*.*
            }
            else
            {
                openFileDialog1.Filter = "Bin Files|Manager.bin";
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePathTextBox.Text = openFileDialog1.FileName;
                writebank1.Enabled = true;
                VerifyBank2.Enabled = true;
                writebank2.Enabled = true;
                VerifyBank1.Enabled = true;
                AutoProgramBank.Enabled = true;

                if (flag_manager == 0)
                {
                    VerifyBank2.Enabled = true;
                    writebank2.Enabled = true;
                    AutoProgramBank.Enabled = true;
                }
                else
                {
                    VerifyBank2.Enabled = false;
                    writebank2.Enabled = false;
                    AutoProgramBank.Enabled = false;
                }
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




        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }


        private void txt_DevVersion_TextChanged(object sender, EventArgs e)
        {

        }



        private void Numeric_Erros_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }   

        void Read2()
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
                        dataByte2[0] = 0xFF;                        
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

                    }
                    textBox2.Text = memoryContent;
                    //MessageBox.Show(memoryContent, "Memory Content", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rx_buff[0] == 0x1F) MessageBox.Show($"0x1F");
            }
        }
       

        private void ReadBank2_Click(object sender, EventArgs e)
        {

            for (int j = 0; j < Num_frim; j++)
            {
                byte[] dataByte = new byte[2];
                System.Threading.Thread.Sleep(100);
                dataByte[0] = 0x11;//READ COMMAND                
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xEE;
                port.Write(dataByte, 0, 1);
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    int number = 0x08100000 + ((j) * 0x0100);//Address + CHECKSUM
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
                        dataByte2[0] = 0xFF;  //NUMBER OF BYTE                      
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

                    }
                    textBox2.Text = memoryContent;
                    //MessageBox.Show(memoryContent, "Memory Content", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rx_buff[0] == 0x1F) MessageBox.Show($"0x1F");
            }
        }



       

        private void writebank2_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;
            // WriteMaster_Disable();

            try
            {
                // Read all lines from the hex file
                string[] lines = File.ReadAllLines(filePath);
                // Read the first 256 bytes from the hex file
                // byte[] fileBytes = ReadFirst256Bytes(filePath);
                int numberOfBytes = GetNumberOfBytes(filePath);
                int j = (numberOfBytes / 256) + 1;

                for (int chunkNumber = 0; chunkNumber <= j; chunkNumber++)
                {
                    label4.Text = $"{((chunkNumber) * 100) / j}%";
                    byte[] fileBytes = ReadNext256Bytes(filePath, chunkNumber);
                    byte xorResult = CalculateXOR(fileBytes);
                    // Display the result
                    //  resultsTextBox.AppendText($"XOR of the first 256 bytes in {Path.GetFileName(filePath)}: 0x{xorResult:X2}\r\n");
                    byte[] dataByte3 = new byte[2];
                    dataByte3[0] = 0x31;//WRITE COMMAND                    
                    port.Write(dataByte3, 0, 1);
                    dataByte3[0] = 0xCE;
                    port.Write(dataByte3, 0, 1);
                    byte[] rx_buff = new byte[1];
                    rx_buff = ReadPortBytes(1);
                    if (rx_buff[0] == 0x79)
                    {
                        int number = 0x08100000 + (chunkNumber * 0x0100);//ADDRESS + CHECKSUM
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
                            dataByte5[0] = 0xFF;// NUMBER OF BYTE
                            dataByte7[0] = xorResult;//CHECKSUM
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
                                    Read2();
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
                excutebank2.Enabled = true;
                // WriteMaster_Disable();
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
        

        private void VerifyBank1_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;
            int numberOfBytes = GetNumberOfBytes(filePath);
            int NumPage = (numberOfBytes / 256) + 1;
            //string filePath = filePathTextBox.Text;
            for (int j = 0; j <= NumPage; j++)
            {
                label5.Text = $"{(j * 100) / NumPage}%";                
                // Read all lines from the hex file
                string[] lines = File.ReadAllLines(filePath);                                
                byte[] fileBytes = ReadNext256Bytes(filePath, j);
                byte[] dataByte = new byte[2];                
                dataByte[0] = 0x11;  //read command               
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xEE;
                port.Write(dataByte, 0, 1);
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    int number = 0x08000000 + (j * 0x0100);//SEND ADDRESS
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
                        dataByte2[0] = 0xFF; //NUMBER OF BYTE                       
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
        void Verify1()
        {
            string filePath = filePathTextBox.Text;
            int numberOfBytes = GetNumberOfBytes(filePath);
            int NumPage = (numberOfBytes / 256) + 1;
            //string filePath = filePathTextBox.Text;
            for (int j = 0; j <= NumPage; j++)
            {
                label5.Text = $"{(j * 100) / NumPage}%";
                // Read all lines from the hex file
                string[] lines = File.ReadAllLines(filePath);
                byte[] fileBytes = ReadNext256Bytes(filePath, j);
                byte[] dataByte = new byte[2];               
                dataByte[0] = 0x11;                
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
                        MessageBox.Show("Program Complete", "Verification Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

           

        private void VerifyBank2_Click(object sender, EventArgs e)
        {
            string filePath = filePathTextBox.Text;
            int numberOfBytes = GetNumberOfBytes(filePath);
            int NumPage = (numberOfBytes / 256) + 1;
            //string filePath = filePathTextBox.Text;
            for (int j = 0; j <= NumPage; j++)
            {
                label5.Text = $"{(j * 100) / NumPage}%";
                // Read all lines from the hex file
                string[] lines = File.ReadAllLines(filePath);
                byte[] fileBytes = ReadNext256Bytes(filePath, j);
                byte[] dataByte = new byte[2];                
                dataByte[0] = 0x11;//command Read                
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0xEE;
                port.Write(dataByte, 0, 1);
                byte[] rx_buff = new byte[1];
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)//confirmation
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
                        dataByte2[0] = 0xFF; //NUMBER OF BYTE                      
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

       
        private void BootMaster_Click(object sender, EventArgs e)
        {
            try
            {
                string msg = "$BootModeActivation\n\r"; //request boot
                MessageBox.Show($"Wait a few seconds");
                port.Write(msg);
                int device_connection = 1;
                port.ReadTimeout = 1000;
                //for (int i = 0; i < 20; i++)
                //{

                //    System.Threading.Thread.Sleep(50);
                //    byte[] rx_buff1 = new byte[20];
                //    string rx_string = port.ReadLine();
                //    if (rx_string.Contains("BootModeActivated"))
                //    {
                //        device_connection = 1;
                //        break;
                //    }
                //}
                if (device_connection == 1)
                {
                    port.DiscardInBuffer();
                    port.DiscardOutBuffer();
                    BootMaster.Enabled = false;
                    BootManager.Enabled = false;
                    BootSmartHandle.Enabled = false;
                    System.Threading.Thread.Sleep(4000);
                    MasterConnct1();
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
        private void label4_Click(object sender, EventArgs e)
        {

        }

     

        private void label5_Click(object sender, EventArgs e)
        {

        }


        

        private void AutoProgramBank_Click(object sender, EventArgs e)
        {
            Erase_shh();
            //Erase1();
            writebank_shh();
            //Verify1();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        

        private void HextoBin_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Hex files (*.hex)|*.hex";
            openFileDialog.Title = "Select a .hex file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string inputHexFile = openFileDialog.FileName;
                textBox3.Text = inputHexFile;
                string outputBinFile = Path.ChangeExtension(inputHexFile, ".bin");

                try
                {
                    ConvertHexToBin(inputHexFile, outputBinFile);
                    MessageBox.Show("Conversion completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred during conversion: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConvertHexToBin(string inputHexFile, string outputBinFile)
        {
            using (StreamReader reader = new StreamReader(inputHexFile))
            using (BinaryWriter writer = new BinaryWriter(File.Create(outputBinFile)))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith(":"))
                    {
                        byte[] data = ParseHexRecord(line);
                        if (data != null)
                            writer.Write(data);
                    }
                }
            }
        }

        private byte[] ParseHexRecord(string hexRecord)
        {
            hexRecord = hexRecord.Trim();
            if (hexRecord.Length < 11 || hexRecord[0] != ':')
                throw new FormatException("Invalid Intel HEX record");

            int byteCount = Convert.ToInt32(hexRecord.Substring(1, 2), 16);
            int address = Convert.ToInt32(hexRecord.Substring(3, 4), 16);
            int recordType = Convert.ToInt32(hexRecord.Substring(7, 2), 16);

            if (byteCount * 2 + 11 != hexRecord.Length)
                throw new FormatException("Invalid Intel HEX record");

            if (recordType != 0)
            {
                Console.WriteLine($"Unsupported record type: {recordType}");
                return null;
            }

            byte[] data = new byte[byteCount];
            for (int i = 0; i < byteCount; i++)
            {
                int dataIndex = 9 + i * 2;
                data[i] = Convert.ToByte(hexRecord.Substring(dataIndex, 2), 16);
            }

            return data;
        }


        private void textBox3_TextChanged_2(object sender, EventArgs e)
        {

        }

       


        private void excutebank1_Click(object sender, EventArgs e)
        {
            byte[] dataByte3 = new byte[1];
            dataByte3[0] = 0x21;//JUMP AND EXCUTE
            port.Write(dataByte3, 0, 1);
            dataByte3[0] = 0xDE;
            port.Write(dataByte3, 0, 1);
            byte[] rx_buff = new byte[1];
            rx_buff = ReadPortBytes(1);
            if (rx_buff[0] == 0x79)
            {
                int number = 0x08000000;//JUMP ADDRESS
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
                //MessageBox.Show($"XOR_Result\n{result:x2}\n");
                byte[] resultBytes = BitConverter.GetBytes(result);
                port.Write(resultBytes, 0, 1);//
            }
            rx_buff = ReadPortBytes(1);
            if (rx_buff[0] == 0x79)
            {
                Btn_connectDevice_Disable();
                MessageBox.Show("Reset Ok", "Verification Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Reset Fail", "Verification Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }
        int flag_manager = 0;

        private void BootSmartHandle_Click(object sender, EventArgs e)
        {
            string msg = "$shhBootModeBT\n\r"; //request boot
            MessageBox.Show($"Wait a few seconds");
            port.Write(msg);
            port.ReadTimeout = 1000;
            MasterConnct1();
        }

        private void BootManager_Click(object sender, EventArgs e)//TODO
        {
            try
            {
                flag_manager = 1;
                //string msg = "BMan";
                //port.Write(msg);
                byte[] dataByte = new byte[1];
                System.Threading.Thread.Sleep(1);
                dataByte[0] = 0x42;
                port.Write(dataByte, 0, 1);// send word BMan and Manager go to Boot State
                dataByte[0] = 0x4D;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0x61;
                port.Write(dataByte, 0, 1);
                dataByte[0] = 0x6E;
                port.Write(dataByte, 0, 1);
                // System.Threading.Thread.Sleep(1);
                // byte[] rx_buff1 = new byte[1];
                // rx_buff1 = ReadPortBytes(1);
                //  if (rx_buff1[0] == 0x6f)
                // {
                BootMaster.Enabled = false;
                System.Threading.Thread.Sleep(4000);
                BootManager.Enabled = false;
                erasebank2.Enabled = false;
                ReadBank2.Enabled = false;
                TestMCU.Enabled = true;
                Btn_Disconnect.Enabled = true;
                Btn_Connect.Enabled = false;
                ReadBank1.Enabled = true;
                eraseban1.Enabled = true;
                writebank1.Enabled = false;
                ReadFile.Enabled = true;
                writebank2.Enabled = false;
                VerifyBank1.Enabled = false;
                VerifyBank2.Enabled = false;
                HextoBin.Enabled = true;
                excutebank1.Enabled = false;
                AutoProgramBank.Enabled = false;
                // }
                // else
                // {
                //    MessageBox.Show($"Master CPU not answer");
                // }

                Managerconnct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        

        private void excutebank2_Click(object sender, EventArgs e)
        {
            byte[] dataByte3 = new byte[1];//command jump to address and excute
            dataByte3[0] = 0x21;
            port.Write(dataByte3, 0, 1);
            dataByte3[0] = 0xDE;
            port.Write(dataByte3, 0, 1);
            byte[] rx_buff = new byte[1];
            rx_buff = ReadPortBytes(1);
            if (rx_buff[0] == 0x79)//Confirm excute command
            {
                int number = 0x08100000;//ADDRESS
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
                //MessageBox.Show($"XOR_Result\n{result:x2}\n");
                byte[] resultBytes = BitConverter.GetBytes(result);
                port.Write(resultBytes, 0, 1);//
            }
            rx_buff = ReadPortBytes(1);
            if (rx_buff[0] == 0x79)
            {
                Btn_connectDevice_Disable();
                MessageBox.Show("Reset Ok", "Verification Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Reset Fail", "Verification Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }


    }
}
    


