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

namespace STM32Bootloading
{
    public partial class Form_Settings : Form
    {

        private static SerialPort port;
        DEV_TYPE DevType = DEV_TYPE.DC;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SendCommandData (string command, byte d1, byte d2, byte d3)
        {
            byte[] tx_buff = new byte[6];
            var commandchar = command.ToCharArray();
            tx_buff[0] = Convert.ToByte(commandchar[0]);
            tx_buff[1] = Convert.ToByte(commandchar[1]);
            tx_buff[2] = Convert.ToByte(commandchar[2]);
            tx_buff[3] = d1;
            tx_buff[4] = d2;
            tx_buff[5] = d3;
            port.Write(tx_buff, 0, 6);
        }

        private byte[] GetCommandData(string command)
        {
            try
            {
                byte[] rx_buff = new byte[6];
                var commandchar = command.ToCharArray();
                rx_buff = ReadPortBytes(6);

                if ((rx_buff[0] == commandchar[0]) & (rx_buff[1] == commandchar[1]) & (rx_buff[2] == commandchar[2]))
                    return new byte[3] { rx_buff[3], rx_buff[4], rx_buff[5]};
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Btn_Set_Settings_Click(object sender, EventArgs e)
        {
            try
            {

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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_All_Disable()
        {

            Btn_Download_Memory.Enabled = false;
            Btn_Get_Settings.Enabled = false;
            Btn_Set_Settings.Enabled = false;
            Btn_Erase_Memory.Enabled = false;
            Connect_Device.Enabled = false;
            Btn_Disconnect.Enabled = false;
            Btn_Connect.Enabled = true;
            Btn_BootMode.Enabled = false;

        }

        private void Btn_All_Enable()
        {

                Btn_Download_Memory.Enabled = true;
                Btn_Get_Settings.Enabled = true;
                Btn_Set_Settings.Enabled = true;
                Btn_Erase_Memory.Enabled = true;
                Connect_Device.Enabled = true;
                Btn_Disconnect.Enabled = true;
                Btn_Connect.Enabled = false;
                Btn_BootMode.Enabled = true;

            }
        private void Btn_Erase_Memory_Click(object sender, EventArgs e)                 // this function sets 15 high risk zones, by sending the 32 bytes packet of data.
        {
            try
            {

                port.ReadTimeout = 4000;                                                // Since it takes time for the device to erase, just increase wait time of response
                ClearBuffer();
                System.Threading.Thread.Sleep(100);
                // Erase Background Data
                SendCommandData("EBD", 255, 255, 255);
                System.Threading.Thread.Sleep(1);
                byte[] dataByte = GetCommandData("EBD");
                if (dataByte[0] == 1)                                               // The device sends 1 if the Erase Function is finished well.
                    MessageBox.Show("Memory is erased successfully");
                else
                    MessageBox.Show("Failed erasing memory");

 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Btn_Download_Memory_Click(object sender, EventArgs e)              ///////////// to DOWNLOAD Recorded Events //////////////////
        {            

            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
                Btn_All_Enable();
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
                    MessageBox.Show("Port is already disconnected");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Disconnect port failed: {ex.Message}");
            }
        }


        private void Btn_BootMode_Click(object sender, EventArgs e)                            // Enter Boot Mode
        {

        }

        private void Btn_ConnectDevice_Click(object sender, EventArgs e)
        {
            try
            {

                byte[] dataByte = new byte[1];
                //--- wait
                ClearBuffer();
                System.Threading.Thread.Sleep(100);
                dataByte[0] = 0x7F;
                port.Write(dataByte, 0, 1);               
                System.Threading.Thread.Sleep(1);
                byte[] rx_buff = new byte[1];                
                rx_buff = ReadPortBytes(1);
                if (rx_buff[0] == 0x79)
                {
                    //So you understand the communication is good and you can continue with other tasks
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Btn_LoadConfigs_Click(object sender, EventArgs e)
        {

            List<string> serialPorts = SerialPort.GetPortNames().ToList();
            Combo_PortList.DataSource = serialPorts;
        }

    }
}
