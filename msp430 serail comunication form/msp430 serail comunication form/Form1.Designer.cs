namespace msp430_serail_comunication_form
{
    partial class GLOVE_DATA
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
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.rawDATAbox = new System.Windows.Forms.RichTextBox();
            this.COMINIT = new System.Windows.Forms.Button();
            this.OPEN_COM = new System.Windows.Forms.Button();
            this.COMPortSelector = new System.Windows.Forms.ListBox();
            this.CLOSE_COM = new System.Windows.Forms.Button();
            this.ERROR_BOX = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Acc_Zbox = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.Acc_Ybox = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.Acc_Xbox = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.finger_5box = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.finger_4box = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.finger_3box = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.finger_2box = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.finger_1box = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Pressure_Box1 = new System.Windows.Forms.TextBox();
            this.Pressure_Box2 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.ReceivedBytesThreshold = 50;
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // rawDATAbox
            // 
            this.rawDATAbox.Location = new System.Drawing.Point(15, 49);
            this.rawDATAbox.Name = "rawDATAbox";
            this.rawDATAbox.Size = new System.Drawing.Size(297, 79);
            this.rawDATAbox.TabIndex = 0;
            this.rawDATAbox.Text = "";
            // 
            // COMINIT
            // 
            this.COMINIT.Location = new System.Drawing.Point(310, 47);
            this.COMINIT.Name = "COMINIT";
            this.COMINIT.Size = new System.Drawing.Size(83, 23);
            this.COMINIT.TabIndex = 1;
            this.COMINIT.Text = "INIT";
            this.COMINIT.UseVisualStyleBackColor = true;
            this.COMINIT.Click += new System.EventHandler(this.COMINIT_Click);
            // 
            // OPEN_COM
            // 
            this.OPEN_COM.Location = new System.Drawing.Point(310, 76);
            this.OPEN_COM.Name = "OPEN_COM";
            this.OPEN_COM.Size = new System.Drawing.Size(83, 23);
            this.OPEN_COM.TabIndex = 2;
            this.OPEN_COM.Text = "OPEN";
            this.OPEN_COM.UseVisualStyleBackColor = true;
            this.OPEN_COM.Click += new System.EventHandler(this.OPEN_COM_Click);
            // 
            // COMPortSelector
            // 
            this.COMPortSelector.AllowDrop = true;
            this.COMPortSelector.FormattingEnabled = true;
            this.COMPortSelector.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24"});
            this.COMPortSelector.Location = new System.Drawing.Point(310, 134);
            this.COMPortSelector.Name = "COMPortSelector";
            this.COMPortSelector.Size = new System.Drawing.Size(91, 43);
            this.COMPortSelector.TabIndex = 3;
            this.COMPortSelector.SelectedIndexChanged += new System.EventHandler(this.COMPortSelector_SelectedIndexChanged);
            // 
            // CLOSE_COM
            // 
            this.CLOSE_COM.Location = new System.Drawing.Point(310, 105);
            this.CLOSE_COM.Name = "CLOSE_COM";
            this.CLOSE_COM.Size = new System.Drawing.Size(83, 23);
            this.CLOSE_COM.TabIndex = 4;
            this.CLOSE_COM.Text = "CLOSE";
            this.CLOSE_COM.UseVisualStyleBackColor = true;
            this.CLOSE_COM.Click += new System.EventHandler(this.CLOSE_COM_Click);
            // 
            // ERROR_BOX
            // 
            this.ERROR_BOX.Location = new System.Drawing.Point(15, 134);
            this.ERROR_BOX.Name = "ERROR_BOX";
            this.ERROR_BOX.Size = new System.Drawing.Size(297, 43);
            this.ERROR_BOX.TabIndex = 5;
            this.ERROR_BOX.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(15, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(96, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Raw Data Stream";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.COMPortSelector);
            this.groupBox1.Controls.Add(this.ERROR_BOX);
            this.groupBox1.Controls.Add(this.CLOSE_COM);
            this.groupBox1.Controls.Add(this.OPEN_COM);
            this.groupBox1.Controls.Add(this.COMINIT);
            this.groupBox1.Controls.Add(this.rawDATAbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 195);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SerialConnection";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox8);
            this.groupBox3.Controls.Add(this.textBox7);
            this.groupBox3.Controls.Add(this.Pressure_Box2);
            this.groupBox3.Controls.Add(this.Pressure_Box1);
            this.groupBox3.Controls.Add(this.Acc_Zbox);
            this.groupBox3.Controls.Add(this.textBox17);
            this.groupBox3.Controls.Add(this.Acc_Ybox);
            this.groupBox3.Controls.Add(this.textBox19);
            this.groupBox3.Controls.Add(this.Acc_Xbox);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Controls.Add(this.finger_5box);
            this.groupBox3.Controls.Add(this.textBox11);
            this.groupBox3.Controls.Add(this.finger_4box);
            this.groupBox3.Controls.Add(this.textBox13);
            this.groupBox3.Controls.Add(this.finger_3box);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.finger_2box);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.finger_1box);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Location = new System.Drawing.Point(12, 221);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(432, 155);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Glove data";
            // 
            // Acc_Zbox
            // 
            this.Acc_Zbox.Location = new System.Drawing.Point(301, 73);
            this.Acc_Zbox.Name = "Acc_Zbox";
            this.Acc_Zbox.Size = new System.Drawing.Size(113, 20);
            this.Acc_Zbox.TabIndex = 15;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox17.Location = new System.Drawing.Point(231, 73);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(64, 20);
            this.textBox17.TabIndex = 14;
            this.textBox17.Text = "AccZ";
            // 
            // Acc_Ybox
            // 
            this.Acc_Ybox.Location = new System.Drawing.Point(301, 47);
            this.Acc_Ybox.Name = "Acc_Ybox";
            this.Acc_Ybox.Size = new System.Drawing.Size(113, 20);
            this.Acc_Ybox.TabIndex = 13;
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox19.Location = new System.Drawing.Point(231, 47);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(64, 20);
            this.textBox19.TabIndex = 12;
            this.textBox19.Text = "AccY";
            // 
            // Acc_Xbox
            // 
            this.Acc_Xbox.Location = new System.Drawing.Point(301, 19);
            this.Acc_Xbox.Name = "Acc_Xbox";
            this.Acc_Xbox.Size = new System.Drawing.Size(113, 20);
            this.Acc_Xbox.TabIndex = 11;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox9.Location = new System.Drawing.Point(231, 19);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(64, 20);
            this.textBox9.TabIndex = 10;
            this.textBox9.Text = "AccX";
            this.textBox9.TextChanged += new System.EventHandler(this.textBox9_TextChanged);
            // 
            // finger_5box
            // 
            this.finger_5box.Location = new System.Drawing.Point(85, 125);
            this.finger_5box.Name = "finger_5box";
            this.finger_5box.Size = new System.Drawing.Size(113, 20);
            this.finger_5box.TabIndex = 9;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox11.Location = new System.Drawing.Point(15, 125);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(64, 20);
            this.textBox11.TabIndex = 8;
            this.textBox11.Text = "Finger#5";
            // 
            // finger_4box
            // 
            this.finger_4box.Location = new System.Drawing.Point(85, 99);
            this.finger_4box.Name = "finger_4box";
            this.finger_4box.Size = new System.Drawing.Size(113, 20);
            this.finger_4box.TabIndex = 7;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox13.Location = new System.Drawing.Point(15, 99);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(64, 20);
            this.textBox13.TabIndex = 6;
            this.textBox13.Text = "Finger#4";
            // 
            // finger_3box
            // 
            this.finger_3box.Location = new System.Drawing.Point(85, 71);
            this.finger_3box.Name = "finger_3box";
            this.finger_3box.Size = new System.Drawing.Size(113, 20);
            this.finger_3box.TabIndex = 5;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox6.Location = new System.Drawing.Point(15, 71);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(64, 20);
            this.textBox6.TabIndex = 4;
            this.textBox6.Text = "Finger#3";
            // 
            // finger_2box
            // 
            this.finger_2box.Location = new System.Drawing.Point(85, 45);
            this.finger_2box.Name = "finger_2box";
            this.finger_2box.Size = new System.Drawing.Size(113, 20);
            this.finger_2box.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox4.Location = new System.Drawing.Point(15, 45);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(64, 20);
            this.textBox4.TabIndex = 2;
            this.textBox4.Text = "Finger#2";
            // 
            // finger_1box
            // 
            this.finger_1box.Location = new System.Drawing.Point(85, 19);
            this.finger_1box.Name = "finger_1box";
            this.finger_1box.Size = new System.Drawing.Size(113, 20);
            this.finger_1box.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox2.Location = new System.Drawing.Point(15, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(64, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "Finger#1";
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Pressure_Box1
            // 
            this.Pressure_Box1.Location = new System.Drawing.Point(301, 99);
            this.Pressure_Box1.Name = "Pressure_Box1";
            this.Pressure_Box1.Size = new System.Drawing.Size(113, 20);
            this.Pressure_Box1.TabIndex = 16;
            // 
            // Pressure_Box2
            // 
            this.Pressure_Box2.Location = new System.Drawing.Point(301, 125);
            this.Pressure_Box2.Name = "Pressure_Box2";
            this.Pressure_Box2.Size = new System.Drawing.Size(113, 20);
            this.Pressure_Box2.TabIndex = 17;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox7.Location = new System.Drawing.Point(231, 99);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(64, 20);
            this.textBox7.TabIndex = 18;
            this.textBox7.Text = "Pressure#1";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox8.Location = new System.Drawing.Point(231, 125);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(64, 20);
            this.textBox8.TabIndex = 19;
            this.textBox8.Text = "Pressure#2";
            // 
            // GLOVE_DATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 386);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(480, 424);
            this.MinimumSize = new System.Drawing.Size(480, 424);
            this.Name = "GLOVE_DATA";
            this.Text = "GLOVE_DATA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.RichTextBox rawDATAbox;
        private System.Windows.Forms.Button COMINIT;
        private System.Windows.Forms.Button OPEN_COM;
        private System.Windows.Forms.ListBox COMPortSelector;
        private System.Windows.Forms.Button CLOSE_COM;
        private System.Windows.Forms.RichTextBox ERROR_BOX;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox Acc_Zbox;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox Acc_Ybox;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox Acc_Xbox;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox finger_5box;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox finger_4box;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox finger_3box;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox finger_2box;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox finger_1box;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox Pressure_Box2;
        private System.Windows.Forms.TextBox Pressure_Box1;
    }
}

