using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;





namespace msp430_serail_comunication_form
{
   
    
    
    public partial class GLOVE_DATA : Form
    {
        string Finger_1 = "";
        string Finger_2 = "";
        string Finger_3 = "";
        string Finger_4 = "";
        string Finger_5 = "";
        string AccZ = "";
        string AccY = "";
        string AccX = "";
      

        public GLOVE_DATA()
        {
            InitializeComponent();
            COMINIT.Enabled = true;
            COMPortSelector.Enabled = true;
            OPEN_COM.Enabled = false;
            CLOSE_COM.Enabled = false;
        }

        private string Rxstring = "";

        private void OPEN_COM_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort.IsOpen)
                {
                    // set status
                    ERROR_BOX.Text = serialPort.PortName + "open!";
                    // open port 
                    // disable button
                    serialPort.Open();
                    COMINIT.Enabled = false;
                    COMPortSelector.Enabled = false;
                    OPEN_COM.Enabled = false;
                    CLOSE_COM.Enabled = true;
                    timer1.Enabled = true;

                }
                else
                {
                    ERROR_BOX.Text = serialPort.PortName + "is being used by another program";
                }
            }
            catch (System.IO.IOException ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void COMINIT_Click(object sender, EventArgs e)
        {

            // make sure port is not already opened
            try
            {
                if (!serialPort.IsOpen)
                {
                    // set status
                    ERROR_BOX.Text = serialPort.PortName + "ready!";
                    // open port 
                    // disable button
                    COMINIT.Enabled = false;
                    COMPortSelector.Enabled = false;
                    OPEN_COM.Enabled = true;
                    CLOSE_COM.Enabled = true;

                }
                else
                {
                    ERROR_BOX.Text = serialPort.PortName + "is being used by another program";
                }
            }
            catch (UnauthorizedAccessException ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void COMPortSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort.PortName = (String)COMPortSelector.SelectedItem;
        }

        private void CLOSE_COM_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            serialPort.Close();
            COMINIT.Enabled = true;
            COMPortSelector.Enabled = true;
            OPEN_COM.Enabled = false;
            CLOSE_COM.Enabled = false;
            ERROR_BOX.Text = serialPort.PortName + "conection closed";
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {

                Rxstring = serialPort.ReadExisting();
                this.Invoke(new EventHandler(DisplayText));

            }
            catch (System.TimeoutException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void DisplayText(object s, EventArgs e)
        {
            string datastring = "";
            rawDATAbox.AppendText(Rxstring);
            datastring = Rxstring.TrimStart('\t', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
            datastring = datastring.TrimEnd('\t', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
            string[] data = datastring.Split('\t');


            for (int i = 0; i < data.Length-1; i++)
            {
                ERROR_BOX.AppendText(data[i]);
                ERROR_BOX.AppendText("\t");
                if (data[i].StartsWith("A"))
                {
                    Finger_1 = data[i].TrimStart('A');
                    finger_1box.Text = Finger_1;
                }
                if (data[i].StartsWith("B"))
                {
                    Finger_2 = data[i].TrimStart('B');
                    finger_2box.Text = Finger_2;
                }
                if (data[i].StartsWith("C"))
                {
                    Finger_3 = data[i].TrimStart('C');
                    finger_3box.Text = Finger_3;
                }
                if (data[i].StartsWith("D"))
                {
                    Finger_4 = data[i].TrimStart('D');
                    finger_4box.Text = Finger_4;
                }
                if (data[i].StartsWith("E"))
                {
                    Finger_5 = data[i].TrimStart('E');
                    finger_5box.Text = Finger_5;
                }
                if (data[i].StartsWith("F"))
                {
                    Acc_Xbox.Text = data[i].TrimStart('F');
                }
                if (data[i].StartsWith("G"))
                {
                    Acc_Ybox.Text = data[i].TrimStart('G');
                }
                if (data[i].StartsWith("I"))
                {
                    Acc_Zbox.Text = data[i].TrimStart('I');
                }

            }

        }






        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            try
            {
                string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(Finger_1);
                sb.AppendLine(Finger_2);
                sb.AppendLine(Finger_3);
                sb.AppendLine(Finger_4);
                using (var fileStream = new FileStream(mydocpath + @"\GloveData.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                using (StreamWriter outfile = new StreamWriter(fileStream))
                {
                    outfile.Write(sb.ToString());
                    outfile.Close();
                }
            }
            catch (Exception E)
            {

            }
            timer1.Enabled = true;
        }

    }
}
