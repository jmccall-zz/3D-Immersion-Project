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
        string Finger_1 = "0";
        string Finger_2 = "0";
        string Finger_3 = "0";
        string Finger_4 = "0";
        string Finger_5 = "0";
        string AccZ = "0";
        string AccY = "0";
        string AccX = "0";
        string Finger_12 = "0";
        string Finger_22 = "0";
        string Finger_32 = "0";
        string Finger_42 = "0";
        string Finger_52 = "0";
        string AccZ2 = "0";
        string AccY2 = "0";
        string AccX2 = "0";
      

        public GLOVE_DATA()
        {
            InitializeComponent();
            COMINIT.Enabled = true;
            COMPortSelector.Enabled = true;
            OPEN_COM.Enabled = false;
            CLOSE_COM.Enabled = false;
            COMINIT2.Enabled = true;
            COMPortSelector2.Enabled = true;
            OPEN_COM2.Enabled = false;
            CLOSE_COM2.Enabled = false;
        }

        private string Rxstring = "";
        private string Rxstring2 = "";

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
        private void OPEN_COM2_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort2.IsOpen)
                {
                    // set status
                    ERROR_BOX2.Text = serialPort2.PortName + "open!";
                    // open port 
                    // disable button
                    serialPort2.Open();
                    COMINIT2.Enabled = false;
                    COMPortSelector2.Enabled = false;
                    OPEN_COM2.Enabled = false;
                    CLOSE_COM2.Enabled = true;
                    timer1.Enabled = true;

                }
                else
                {
                    ERROR_BOX2.Text = serialPort.PortName + "is being used by another program";
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
        private void COMINIT2_Click(object sender, EventArgs e)
        {

            // make sure port is not already opened
            try
            {
                if (!serialPort2.IsOpen)
                {
                    // set status
                    ERROR_BOX2.Text = serialPort2.PortName + "ready!";
                    // open port 
                    // disable button
                    COMINIT2.Enabled = false;
                    COMPortSelector2.Enabled = false;
                    OPEN_COM2.Enabled = true;
                    CLOSE_COM2.Enabled = true;

                }
                else
                {
                    ERROR_BOX2.Text = serialPort2.PortName + "is being used by another program";
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
        private void COMPortSelector2_SelectedIndexChanged(object sender, EventArgs e)
        {
            serialPort2.PortName = (String)COMPortSelector2.SelectedItem;
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
        private void CLOSE_COM2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            serialPort2.Close();
            COMINIT2.Enabled = true;
            COMPortSelector2.Enabled = true;
            OPEN_COM2.Enabled = false;
            CLOSE_COM2.Enabled = false;
            ERROR_BOX2.Text = serialPort.PortName + "conection closed";
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
        private void serialPort2_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {

                Rxstring2 = serialPort2.ReadExisting();
                this.Invoke(new EventHandler(DisplayText2));

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
                if (data[i].StartsWith("J"))
                {
                    Pressure_Box1.Text = data[i].TrimStart('J');
                }
                if (data[i].StartsWith("K"))
                {
                    Pressure_Box2.Text = data[i].TrimStart('K');
                }

            }

        }
        private void DisplayText2(object s, EventArgs e)
        {
            string datastring2 = "";
            rawDATAbox2.AppendText(Rxstring2);
            datastring2 = Rxstring2.TrimStart('\t', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
            datastring2 = datastring2.TrimEnd('\t', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
            string[] data = datastring2.Split('\t');


            for (int i = 0; i < data.Length - 1; i++)
            {
                ERROR_BOX2.AppendText(data[i]);
                ERROR_BOX2.AppendText("\t");
                if (data[i].StartsWith("A"))
                {
                    Finger_32 = data[i].TrimStart('A');
                    finger_3box2.Text = Finger_32;
                }
                if (data[i].StartsWith("B"))
                {
                    Finger_42 = data[i].TrimStart('B');
                    finger_4box2.Text = Finger_42;
                }
                if (data[i].StartsWith("C"))
                {
                    Finger_22 = data[i].TrimStart('C');
                    finger_2box2.Text = Finger_22;
                }
                if (data[i].StartsWith("D"))
                {
                    Finger_52 = data[i].TrimStart('D');
                    finger_5box2.Text = Finger_52;
                }
                if (data[i].StartsWith("E"))
                {
                    Pressure_Box12.Text = data[i].TrimStart('E');
                }
                if (data[i].StartsWith("F"))
                {
                    Acc_Xbox2.Text = data[i].TrimStart('F');
                }
                if (data[i].StartsWith("G"))
                {
                    Acc_Ybox2.Text = data[i].TrimStart('G');
                }
                if (data[i].StartsWith("I"))
                {
                    Acc_Zbox2.Text = data[i].TrimStart('I');
                }
                if (data[i].StartsWith("J"))
                {
                    Finger_12 = data[i].TrimStart('J');
                    finger_1box2.Text = Finger_12;
                }
                if (data[i].StartsWith("K"))
                {
                    Pressure_Box22.Text = data[i].TrimStart('K');
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
                sb.AppendLine(Finger_3);
                sb.AppendLine(Finger_4);
                sb.AppendLine(Finger_5);
                sb.AppendLine(Finger_2);

                sb.AppendLine(AccX);
                sb.AppendLine(AccY);
                sb.AppendLine(AccZ);

                sb.AppendLine(Finger_12);
                sb.AppendLine(Finger_32);
                sb.AppendLine(Finger_42);
                sb.AppendLine(Finger_52);
                sb.AppendLine(Finger_22);

                sb.AppendLine(AccX2);
                sb.AppendLine(AccY2);
                sb.AppendLine(AccZ2);

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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
