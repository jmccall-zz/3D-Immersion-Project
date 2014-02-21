namespace WindowsFormsApplication1
{
    partial class GenericHidForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenericHidForm));
            this.SetVidPidButton = new System.Windows.Forms.Button();
            this.PWM_Button = new System.Windows.Forms.Button();
            this.VidTextBox = new System.Windows.Forms.MaskedTextBox();
            this.PidTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Status = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AdcValueBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SwStatus = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DutyTextBox = new System.Windows.Forms.NumericUpDown();
            this.LED_State_CheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.AdcValueBox7 = new System.Windows.Forms.RichTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.AdcValueBox6 = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.AdcValueBox5 = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.AdcValueBox4 = new System.Windows.Forms.RichTextBox();
            this.AdcValueBox3 = new System.Windows.Forms.RichTextBox();
            this.AdcValueBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.InputTimer = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DutyTextBox)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SetVidPidButton
            // 
            this.SetVidPidButton.Location = new System.Drawing.Point(74, 76);
            this.SetVidPidButton.Name = "SetVidPidButton";
            this.SetVidPidButton.Size = new System.Drawing.Size(59, 21);
            this.SetVidPidButton.TabIndex = 4;
            this.SetVidPidButton.Text = "Set";
            this.SetVidPidButton.UseVisualStyleBackColor = true;
            this.SetVidPidButton.Click += new System.EventHandler(this.Set_VidPid_Click);
            // 
            // PWM_Button
            // 
            this.PWM_Button.Location = new System.Drawing.Point(152, 26);
            this.PWM_Button.Name = "PWM_Button";
            this.PWM_Button.Size = new System.Drawing.Size(58, 23);
            this.PWM_Button.TabIndex = 2;
            this.PWM_Button.Text = "Update";
            this.PWM_Button.UseVisualStyleBackColor = true;
            this.PWM_Button.Click += new System.EventHandler(this.Update_PWM_Click);
            // 
            // VidTextBox
            // 
            this.VidTextBox.Location = new System.Drawing.Point(62, 19);
            this.VidTextBox.Name = "VidTextBox";
            this.VidTextBox.Size = new System.Drawing.Size(82, 20);
            this.VidTextBox.TabIndex = 1;
            this.VidTextBox.Text = "0x04B4";
            this.VidTextBox.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.VidTextBox_MaskInputRejected);
            // 
            // PidTextBox
            // 
            this.PidTextBox.Location = new System.Drawing.Point(62, 46);
            this.PidTextBox.Name = "PidTextBox";
            this.PidTextBox.Size = new System.Drawing.Size(82, 20);
            this.PidTextBox.TabIndex = 3;
            this.PidTextBox.Text = "0xE177";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vendor ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Product ID:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Status);
            this.groupBox1.Controls.Add(this.PidTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.VidTextBox);
            this.groupBox1.Controls.Add(this.SetVidPidButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(258, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 129);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status.Location = new System.Drawing.Point(52, 107);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(103, 16);
            this.Status.TabIndex = 6;
            this.Status.Text = "Disconnected";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "USB:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "PWM Duty Cycle:";
            // 
            // AdcValueBox
            // 
            this.AdcValueBox.Location = new System.Drawing.Point(86, 41);
            this.AdcValueBox.Name = "AdcValueBox";
            this.AdcValueBox.ReadOnly = true;
            this.AdcValueBox.Size = new System.Drawing.Size(78, 23);
            this.AdcValueBox.TabIndex = 1;
            this.AdcValueBox.Text = "";
            this.AdcValueBox.TextChanged += new System.EventHandler(this.AdcValueBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Finger#1:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(65, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "LED:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Switch Status:";
            // 
            // SwStatus
            // 
            this.SwStatus.BackColor = System.Drawing.Color.Red;
            this.SwStatus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SwStatus.Location = new System.Drawing.Point(91, 11);
            this.SwStatus.Name = "SwStatus";
            this.SwStatus.Size = new System.Drawing.Size(50, 23);
            this.SwStatus.TabIndex = 3;
            this.SwStatus.Text = "Off";
            this.SwStatus.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DutyTextBox);
            this.groupBox2.Controls.Add(this.LED_State_CheckBox);
            this.groupBox2.Controls.Add(this.PWM_Button);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(10, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 83);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // DutyTextBox
            // 
            this.DutyTextBox.Location = new System.Drawing.Point(96, 28);
            this.DutyTextBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DutyTextBox.Name = "DutyTextBox";
            this.DutyTextBox.Size = new System.Drawing.Size(50, 20);
            this.DutyTextBox.TabIndex = 1;
            this.DutyTextBox.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // LED_State_CheckBox
            // 
            this.LED_State_CheckBox.AutoSize = true;
            this.LED_State_CheckBox.Checked = true;
            this.LED_State_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LED_State_CheckBox.Location = new System.Drawing.Point(96, 60);
            this.LED_State_CheckBox.Name = "LED_State_CheckBox";
            this.LED_State_CheckBox.Size = new System.Drawing.Size(15, 14);
            this.LED_State_CheckBox.TabIndex = 4;
            this.LED_State_CheckBox.UseVisualStyleBackColor = true;
            this.LED_State_CheckBox.CheckedChanged += new System.EventHandler(this.LED_State_CheckBox_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.AdcValueBox7);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.AdcValueBox6);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.AdcValueBox5);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.AdcValueBox4);
            this.groupBox3.Controls.Add(this.AdcValueBox3);
            this.groupBox3.Controls.Add(this.AdcValueBox2);
            this.groupBox3.Controls.Add(this.SwStatus);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.AdcValueBox);
            this.groupBox3.Location = new System.Drawing.Point(10, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(229, 249);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 220);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Z-Acc:";
            // 
            // AdcValueBox7
            // 
            this.AdcValueBox7.BackColor = System.Drawing.SystemColors.Control;
            this.AdcValueBox7.Location = new System.Drawing.Point(86, 211);
            this.AdcValueBox7.Name = "AdcValueBox7";
            this.AdcValueBox7.ReadOnly = true;
            this.AdcValueBox7.Size = new System.Drawing.Size(78, 23);
            this.AdcValueBox7.TabIndex = 14;
            this.AdcValueBox7.Text = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 191);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Y-Acc:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // AdcValueBox6
            // 
            this.AdcValueBox6.BackColor = System.Drawing.SystemColors.Control;
            this.AdcValueBox6.Location = new System.Drawing.Point(86, 182);
            this.AdcValueBox6.Name = "AdcValueBox6";
            this.AdcValueBox6.ReadOnly = true;
            this.AdcValueBox6.Size = new System.Drawing.Size(78, 23);
            this.AdcValueBox6.TabIndex = 12;
            this.AdcValueBox6.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 162);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "X-Acc:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // AdcValueBox5
            // 
            this.AdcValueBox5.BackColor = System.Drawing.SystemColors.Control;
            this.AdcValueBox5.Location = new System.Drawing.Point(86, 153);
            this.AdcValueBox5.Name = "AdcValueBox5";
            this.AdcValueBox5.ReadOnly = true;
            this.AdcValueBox5.Size = new System.Drawing.Size(78, 23);
            this.AdcValueBox5.TabIndex = 10;
            this.AdcValueBox5.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Finger#4:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Finger#3:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Finger#2:";
            // 
            // AdcValueBox4
            // 
            this.AdcValueBox4.BackColor = System.Drawing.SystemColors.Control;
            this.AdcValueBox4.Location = new System.Drawing.Point(86, 124);
            this.AdcValueBox4.Name = "AdcValueBox4";
            this.AdcValueBox4.ReadOnly = true;
            this.AdcValueBox4.Size = new System.Drawing.Size(78, 23);
            this.AdcValueBox4.TabIndex = 6;
            this.AdcValueBox4.Text = "";
            // 
            // AdcValueBox3
            // 
            this.AdcValueBox3.BackColor = System.Drawing.SystemColors.Control;
            this.AdcValueBox3.Location = new System.Drawing.Point(86, 96);
            this.AdcValueBox3.Name = "AdcValueBox3";
            this.AdcValueBox3.ReadOnly = true;
            this.AdcValueBox3.Size = new System.Drawing.Size(78, 23);
            this.AdcValueBox3.TabIndex = 5;
            this.AdcValueBox3.Text = "";
            // 
            // AdcValueBox2
            // 
            this.AdcValueBox2.BackColor = System.Drawing.SystemColors.Control;
            this.AdcValueBox2.Location = new System.Drawing.Point(86, 68);
            this.AdcValueBox2.Name = "AdcValueBox2";
            this.AdcValueBox2.ReadOnly = true;
            this.AdcValueBox2.Size = new System.Drawing.Size(78, 23);
            this.AdcValueBox2.TabIndex = 4;
            this.AdcValueBox2.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(10, 350);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox1.Size = new System.Drawing.Size(308, 50);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "Note: Altering the default Vendor ID (0x04B4) and Product ID (0xE177) may prohibi" +
    "t interfacing with the USB device. ";
            // 
            // InputTimer
            // 
            this.InputTimer.Interval = 20;
            this.InputTimer.Tick += new System.EventHandler(this.InputTimer_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // GenericHidForm
            // 
            this.AcceptButton = this.PWM_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 390);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(443, 538);
            this.MinimumSize = new System.Drawing.Size(443, 249);
            this.Name = "GenericHidForm";
            this.Text = "Generic HID Test Interface";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DutyTextBox)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SetVidPidButton;
        private System.Windows.Forms.Button PWM_Button;
        private System.Windows.Forms.MaskedTextBox VidTextBox;
        private System.Windows.Forms.MaskedTextBox PidTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox AdcValueBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SwStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox LED_State_CheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown DutyTextBox;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer InputTimer;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox AdcValueBox4;
        private System.Windows.Forms.RichTextBox AdcValueBox3;
        private System.Windows.Forms.RichTextBox AdcValueBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RichTextBox AdcValueBox7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox AdcValueBox6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox AdcValueBox5;
    }
}

