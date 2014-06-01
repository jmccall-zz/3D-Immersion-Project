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
            this.COMPortSelector2 = new System.Windows.Forms.ListBox();
            this.ERROR_BOX2 = new System.Windows.Forms.RichTextBox();
            this.CLOSE_COM2 = new System.Windows.Forms.Button();
            this.OPEN_COM2 = new System.Windows.Forms.Button();
            this.COMINIT2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.rawDATAbox2 = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.Pressure_Box2 = new System.Windows.Forms.TextBox();
            this.Pressure_Box1 = new System.Windows.Forms.TextBox();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.Pressure_Box22 = new System.Windows.Forms.TextBox();
            this.Pressure_Box12 = new System.Windows.Forms.TextBox();
            this.Acc_Zbox2 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.Acc_Ybox2 = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.Acc_Xbox2 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.finger_5box2 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.finger_4box2 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.finger_3box2 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.finger_2box2 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.finger_1box2 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.serialPort2 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.rawDATAbox.Size = new System.Drawing.Size(188, 79);
            this.rawDATAbox.TabIndex = 0;
            this.rawDATAbox.Text = "";
            // 
            // COMINIT
            // 
            this.COMINIT.Location = new System.Drawing.Point(209, 49);
            this.COMINIT.Name = "COMINIT";
            this.COMINIT.Size = new System.Drawing.Size(83, 23);
            this.COMINIT.TabIndex = 1;
            this.COMINIT.Text = "INIT";
            this.COMINIT.UseVisualStyleBackColor = true;
            this.COMINIT.Click += new System.EventHandler(this.COMINIT_Click);
            // 
            // OPEN_COM
            // 
            this.OPEN_COM.Location = new System.Drawing.Point(209, 76);
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
            this.COMPortSelector.Location = new System.Drawing.Point(209, 134);
            this.COMPortSelector.Name = "COMPortSelector";
            this.COMPortSelector.Size = new System.Drawing.Size(83, 43);
            this.COMPortSelector.TabIndex = 3;
            this.COMPortSelector.SelectedIndexChanged += new System.EventHandler(this.COMPortSelector_SelectedIndexChanged);
            // 
            // CLOSE_COM
            // 
            this.CLOSE_COM.Location = new System.Drawing.Point(209, 105);
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
            this.ERROR_BOX.Size = new System.Drawing.Size(188, 43);
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
            this.textBox1.Text = "Right Hand Glove";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.COMPortSelector2);
            this.groupBox1.Controls.Add(this.ERROR_BOX2);
            this.groupBox1.Controls.Add(this.CLOSE_COM2);
            this.groupBox1.Controls.Add(this.OPEN_COM2);
            this.groupBox1.Controls.Add(this.COMINIT2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.rawDATAbox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.COMPortSelector);
            this.groupBox1.Controls.Add(this.ERROR_BOX);
            this.groupBox1.Controls.Add(this.CLOSE_COM);
            this.groupBox1.Controls.Add(this.OPEN_COM);
            this.groupBox1.Controls.Add(this.COMINIT);
            this.groupBox1.Controls.Add(this.rawDATAbox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 195);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SerialConnection";
            // 
            // COMPortSelector2
            // 
            this.COMPortSelector2.AllowDrop = true;
            this.COMPortSelector2.FormattingEnabled = true;
            this.COMPortSelector2.Items.AddRange(new object[] {
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
            this.COMPortSelector2.Location = new System.Drawing.Point(502, 139);
            this.COMPortSelector2.Name = "COMPortSelector2";
            this.COMPortSelector2.Size = new System.Drawing.Size(79, 43);
            this.COMPortSelector2.TabIndex = 13;
            this.COMPortSelector2.SelectedIndexChanged += new System.EventHandler(this.COMPortSelector2_SelectedIndexChanged);
            // 
            // ERROR_BOX2
            // 
            this.ERROR_BOX2.Location = new System.Drawing.Point(328, 134);
            this.ERROR_BOX2.Name = "ERROR_BOX2";
            this.ERROR_BOX2.Size = new System.Drawing.Size(168, 43);
            this.ERROR_BOX2.TabIndex = 12;
            this.ERROR_BOX2.Text = "";
            this.ERROR_BOX2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // CLOSE_COM2
            // 
            this.CLOSE_COM2.Location = new System.Drawing.Point(502, 110);
            this.CLOSE_COM2.Name = "CLOSE_COM2";
            this.CLOSE_COM2.Size = new System.Drawing.Size(83, 23);
            this.CLOSE_COM2.TabIndex = 11;
            this.CLOSE_COM2.Text = "CLOSE";
            this.CLOSE_COM2.UseVisualStyleBackColor = true;
            this.CLOSE_COM2.Click += new System.EventHandler(this.CLOSE_COM2_Click);
            // 
            // OPEN_COM2
            // 
            this.OPEN_COM2.Location = new System.Drawing.Point(502, 81);
            this.OPEN_COM2.Name = "OPEN_COM2";
            this.OPEN_COM2.Size = new System.Drawing.Size(83, 23);
            this.OPEN_COM2.TabIndex = 10;
            this.OPEN_COM2.Text = "OPEN";
            this.OPEN_COM2.UseVisualStyleBackColor = true;
            this.OPEN_COM2.Click += new System.EventHandler(this.OPEN_COM2_Click);
            // 
            // COMINIT2
            // 
            this.COMINIT2.Location = new System.Drawing.Point(502, 52);
            this.COMINIT2.Name = "COMINIT2";
            this.COMINIT2.Size = new System.Drawing.Size(83, 23);
            this.COMINIT2.TabIndex = 9;
            this.COMINIT2.Text = "INIT";
            this.COMINIT2.UseVisualStyleBackColor = true;
            this.COMINIT2.Click += new System.EventHandler(this.COMINIT2_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Location = new System.Drawing.Point(328, 25);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(109, 20);
            this.textBox3.TabIndex = 8;
            this.textBox3.Text = "Left Hand Glove";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // rawDATAbox2
            // 
            this.rawDATAbox2.Location = new System.Drawing.Point(328, 54);
            this.rawDATAbox2.Name = "rawDATAbox2";
            this.rawDATAbox2.Size = new System.Drawing.Size(168, 74);
            this.rawDATAbox2.TabIndex = 7;
            this.rawDATAbox2.Text = "";
            this.rawDATAbox2.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
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
            this.groupBox3.Size = new System.Drawing.Size(308, 153);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Glove data";
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox8.Location = new System.Drawing.Point(168, 127);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(64, 20);
            this.textBox8.TabIndex = 19;
            this.textBox8.Text = "Pressure#2";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox7.Location = new System.Drawing.Point(168, 101);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(64, 20);
            this.textBox7.TabIndex = 18;
            this.textBox7.Text = "Pressure#1";
            // 
            // Pressure_Box2
            // 
            this.Pressure_Box2.Location = new System.Drawing.Point(238, 127);
            this.Pressure_Box2.Name = "Pressure_Box2";
            this.Pressure_Box2.Size = new System.Drawing.Size(54, 20);
            this.Pressure_Box2.TabIndex = 17;
            // 
            // Pressure_Box1
            // 
            this.Pressure_Box1.Location = new System.Drawing.Point(238, 101);
            this.Pressure_Box1.Name = "Pressure_Box1";
            this.Pressure_Box1.Size = new System.Drawing.Size(54, 20);
            this.Pressure_Box1.TabIndex = 16;
            // 
            // Acc_Zbox
            // 
            this.Acc_Zbox.Location = new System.Drawing.Point(238, 75);
            this.Acc_Zbox.Name = "Acc_Zbox";
            this.Acc_Zbox.Size = new System.Drawing.Size(54, 20);
            this.Acc_Zbox.TabIndex = 15;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox17.Location = new System.Drawing.Point(168, 75);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(64, 20);
            this.textBox17.TabIndex = 14;
            this.textBox17.Text = "AccZ";
            // 
            // Acc_Ybox
            // 
            this.Acc_Ybox.Location = new System.Drawing.Point(238, 49);
            this.Acc_Ybox.Name = "Acc_Ybox";
            this.Acc_Ybox.Size = new System.Drawing.Size(54, 20);
            this.Acc_Ybox.TabIndex = 13;
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox19.Location = new System.Drawing.Point(168, 49);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(64, 20);
            this.textBox19.TabIndex = 12;
            this.textBox19.Text = "AccY";
            // 
            // Acc_Xbox
            // 
            this.Acc_Xbox.Location = new System.Drawing.Point(238, 21);
            this.Acc_Xbox.Name = "Acc_Xbox";
            this.Acc_Xbox.Size = new System.Drawing.Size(54, 20);
            this.Acc_Xbox.TabIndex = 11;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox9.Location = new System.Drawing.Point(168, 21);
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
            this.finger_5box.Size = new System.Drawing.Size(64, 20);
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
            this.finger_4box.Size = new System.Drawing.Size(64, 20);
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
            this.finger_3box.Size = new System.Drawing.Size(64, 20);
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
            this.finger_2box.Size = new System.Drawing.Size(64, 20);
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
            this.finger_1box.Size = new System.Drawing.Size(64, 20);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox5);
            this.groupBox2.Controls.Add(this.textBox10);
            this.groupBox2.Controls.Add(this.Pressure_Box22);
            this.groupBox2.Controls.Add(this.Pressure_Box12);
            this.groupBox2.Controls.Add(this.Acc_Zbox2);
            this.groupBox2.Controls.Add(this.textBox16);
            this.groupBox2.Controls.Add(this.Acc_Ybox2);
            this.groupBox2.Controls.Add(this.textBox20);
            this.groupBox2.Controls.Add(this.Acc_Xbox2);
            this.groupBox2.Controls.Add(this.textBox22);
            this.groupBox2.Controls.Add(this.finger_5box2);
            this.groupBox2.Controls.Add(this.textBox24);
            this.groupBox2.Controls.Add(this.finger_4box2);
            this.groupBox2.Controls.Add(this.textBox26);
            this.groupBox2.Controls.Add(this.finger_3box2);
            this.groupBox2.Controls.Add(this.textBox28);
            this.groupBox2.Controls.Add(this.finger_2box2);
            this.groupBox2.Controls.Add(this.textBox30);
            this.groupBox2.Controls.Add(this.finger_1box2);
            this.groupBox2.Controls.Add(this.textBox32);
            this.groupBox2.Location = new System.Drawing.Point(340, 221);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 153);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Glove data";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox5.Location = new System.Drawing.Point(149, 123);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(64, 20);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = "Pressure#2";
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox10.Location = new System.Drawing.Point(149, 97);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(64, 20);
            this.textBox10.TabIndex = 18;
            this.textBox10.Text = "Pressure#1";
            // 
            // Pressure_Box22
            // 
            this.Pressure_Box22.Location = new System.Drawing.Point(219, 123);
            this.Pressure_Box22.Name = "Pressure_Box22";
            this.Pressure_Box22.Size = new System.Drawing.Size(57, 20);
            this.Pressure_Box22.TabIndex = 17;
            // 
            // Pressure_Box12
            // 
            this.Pressure_Box12.Location = new System.Drawing.Point(219, 97);
            this.Pressure_Box12.Name = "Pressure_Box12";
            this.Pressure_Box12.Size = new System.Drawing.Size(57, 20);
            this.Pressure_Box12.TabIndex = 16;
            // 
            // Acc_Zbox2
            // 
            this.Acc_Zbox2.Location = new System.Drawing.Point(219, 71);
            this.Acc_Zbox2.Name = "Acc_Zbox2";
            this.Acc_Zbox2.Size = new System.Drawing.Size(57, 20);
            this.Acc_Zbox2.TabIndex = 15;
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox16.Location = new System.Drawing.Point(149, 71);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(64, 20);
            this.textBox16.TabIndex = 14;
            this.textBox16.Text = "AccZ";
            // 
            // Acc_Ybox2
            // 
            this.Acc_Ybox2.Location = new System.Drawing.Point(219, 47);
            this.Acc_Ybox2.Name = "Acc_Ybox2";
            this.Acc_Ybox2.Size = new System.Drawing.Size(57, 20);
            this.Acc_Ybox2.TabIndex = 13;
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox20.Location = new System.Drawing.Point(149, 45);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(64, 20);
            this.textBox20.TabIndex = 12;
            this.textBox20.Text = "AccY";
            // 
            // Acc_Xbox2
            // 
            this.Acc_Xbox2.Location = new System.Drawing.Point(219, 21);
            this.Acc_Xbox2.Name = "Acc_Xbox2";
            this.Acc_Xbox2.Size = new System.Drawing.Size(57, 20);
            this.Acc_Xbox2.TabIndex = 11;
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox22.Location = new System.Drawing.Point(149, 19);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(64, 20);
            this.textBox22.TabIndex = 10;
            this.textBox22.Text = "AccX";
            // 
            // finger_5box2
            // 
            this.finger_5box2.Location = new System.Drawing.Point(85, 125);
            this.finger_5box2.Name = "finger_5box2";
            this.finger_5box2.Size = new System.Drawing.Size(58, 20);
            this.finger_5box2.TabIndex = 9;
            // 
            // textBox24
            // 
            this.textBox24.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox24.Location = new System.Drawing.Point(15, 125);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(64, 20);
            this.textBox24.TabIndex = 8;
            this.textBox24.Text = "Finger#5";
            // 
            // finger_4box2
            // 
            this.finger_4box2.Location = new System.Drawing.Point(85, 99);
            this.finger_4box2.Name = "finger_4box2";
            this.finger_4box2.Size = new System.Drawing.Size(58, 20);
            this.finger_4box2.TabIndex = 7;
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox26.Location = new System.Drawing.Point(15, 99);
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(64, 20);
            this.textBox26.TabIndex = 6;
            this.textBox26.Text = "Finger#4";
            // 
            // finger_3box2
            // 
            this.finger_3box2.Location = new System.Drawing.Point(85, 71);
            this.finger_3box2.Name = "finger_3box2";
            this.finger_3box2.Size = new System.Drawing.Size(58, 20);
            this.finger_3box2.TabIndex = 5;
            // 
            // textBox28
            // 
            this.textBox28.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox28.Location = new System.Drawing.Point(15, 71);
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new System.Drawing.Size(64, 20);
            this.textBox28.TabIndex = 4;
            this.textBox28.Text = "Finger#3";
            // 
            // finger_2box2
            // 
            this.finger_2box2.Location = new System.Drawing.Point(85, 45);
            this.finger_2box2.Name = "finger_2box2";
            this.finger_2box2.Size = new System.Drawing.Size(58, 20);
            this.finger_2box2.TabIndex = 3;
            // 
            // textBox30
            // 
            this.textBox30.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox30.Location = new System.Drawing.Point(15, 45);
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new System.Drawing.Size(64, 20);
            this.textBox30.TabIndex = 2;
            this.textBox30.Text = "Finger#2";
            // 
            // finger_1box2
            // 
            this.finger_1box2.Location = new System.Drawing.Point(85, 19);
            this.finger_1box2.Name = "finger_1box2";
            this.finger_1box2.Size = new System.Drawing.Size(58, 20);
            this.finger_1box2.TabIndex = 1;
            // 
            // textBox32
            // 
            this.textBox32.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBox32.Location = new System.Drawing.Point(15, 19);
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new System.Drawing.Size(64, 20);
            this.textBox32.TabIndex = 0;
            this.textBox32.Text = "Finger#1";
            // 
            // serialPort2
            // 
            this.serialPort2.ReceivedBytesThreshold = 50;
            this.serialPort2.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort2_DataReceived);
            // 
            // GLOVE_DATA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "GLOVE_DATA";
            this.Text = "GLOVE_DATA";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ListBox COMPortSelector2;
        private System.Windows.Forms.RichTextBox ERROR_BOX2;
        private System.Windows.Forms.Button CLOSE_COM2;
        private System.Windows.Forms.Button OPEN_COM2;
        private System.Windows.Forms.Button COMINIT2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.RichTextBox rawDATAbox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox Pressure_Box22;
        private System.Windows.Forms.TextBox Pressure_Box12;
        private System.Windows.Forms.TextBox Acc_Zbox2;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox Acc_Ybox2;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.TextBox Acc_Xbox2;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox finger_5box2;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.TextBox finger_4box2;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox finger_3box2;
        private System.Windows.Forms.TextBox textBox28;
        private System.Windows.Forms.TextBox finger_2box2;
        private System.Windows.Forms.TextBox textBox30;
        private System.Windows.Forms.TextBox finger_1box2;
        private System.Windows.Forms.TextBox textBox32;
        private System.IO.Ports.SerialPort serialPort2;
    }
}

