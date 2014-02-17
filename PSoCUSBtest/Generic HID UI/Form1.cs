
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using CyUSB;



namespace WindowsFormsApplication1
{
    public partial class GenericHidForm : Form
    {

        // *********************** START OF PROGRAM MAIN ****************************** //
        
        //Constant variables for locations in Input and Output Data Arrays
        
        //Constants for Input Buffer Array
        //const uint Switch_Status_Position = 1; 
        //const uint ADC_Byte1_Position = 2;
        //const uint ADC_Byte2_Position = 3;
        //const uint ADC_Byte3_Position = 4;
        //const uint ADC_Byte4_Position = 5;

        const uint Finger1_Byte1_Position = 1;
        const uint Finger1_Byte2_Position = 2;
        const uint Finger2_Byte1_Position = 3;
        const uint Finger2_Byte2_Position = 4;
        const uint Finger3_Byte1_Position = 5;
        const uint Finger3_Byte2_Position = 6;
        const uint Finger4_Byte1_Position = 7;
        const uint Finger4_Byte2_Position = 8;

        
        //Constants fro Output Buffer Array
        const uint LED_State_Position = 1;
        const uint PWM_DutyCycle_Position = 2;
        
        USBDeviceList usbDevices = null;        // Pointer to list of USB devices
        CyHidDevice myHidDevice = null;         // Handle of USB device

        int i;

        int debugcnt = 0;

        uint finger1_1 = 0;
        uint finger1_2 = 0;
        uint finger2_1 = 0;
        uint finger2_2 = 0;
        uint finger3_1 = 0;
        uint finger3_2 = 0;
        uint finger4_1 = 0;
        uint finger4_2 = 0;

        static uint Filter_Size = 5;

        uint[]  finger1Array = new uint[Filter_Size];
        uint[]  finger2Array = new uint[Filter_Size];
        uint[]  finger3Array = new uint[Filter_Size];
        uint[]  finger4Array = new uint[Filter_Size];

        uint FingerCNT = 0;

        uint Finger1HLDR;
        uint Finger2HLDR;
        uint Finger3HLDR;
        uint Finger4HLDR;


        

        uint DutyCycle = 0;                     // WRITE: Duty cycle to set PSOC PWM

        int Vendor_ID = 0x04B4;                       // Cypress Vendor ID 
        int Product_ID = 0xE177;                       // Example Project Product ID

        NumericUpDown DutyCycleUpDown;          // Handler for PWM updown control

        
        

        /**********************************************************************
        * NAME: GenericHIDForm
        * 
        * DESCRIPTION: Main function called initalled upon the starting of the
        * application. Used to unitialize variables, the GUI application, register
        * the event handlers, and check for a connected device.
        * 
        ***********************************************************************/
        
        public GenericHidForm()
        {
            //Initialize the main GUI
            InitializeComponent();

            //Set initial values
            DutyCycleUpDown = new NumericUpDown();
            DutyCycleUpDown.Value = 10;
            DutyCycleUpDown.Minimum = 0;
            DutyCycleUpDown.Maximum = 100;
            
            //Callback to set numeric updown box value
            DutyCycleUpDown.ValueChanged += new EventHandler(DutyCycleUpDown_OnValueChanged);

            // Create a list of CYUSB devices for this application
            usbDevices = new USBDeviceList(CyConst.DEVICES_HID);

            //Add event handlers for device attachment and device removal
            usbDevices.DeviceAttached += new EventHandler(usbDevices_DeviceAttached);
            usbDevices.DeviceRemoved += new EventHandler(usbDevices_DeviceRemoved);

            //Connect to the USB device
            GetDevice();

        }


       /**********************************************************************
       * NAME: DutyCycleUpDown_OnValueChanged
       * 
       * DESCRIPTION: Event Handler for the numeric up/down text field. This 
       * function is called when the value in the next field is updated with
       * the arrows so that the value is the text field can be properlly updated
       * to reflect the change.
       * 
       ***********************************************************************/
        private void DutyCycleUpDown_OnValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine(DutyCycleUpDown.Value);
        }

        /**********************************************************************
        * NAME: usbDevices_DeviceRemoved
        * 
        * DESCRIPTION: Event handler for the removal of a USB device. When the removal
        * of a USB device is detected, this function will be called which will check to
        * see if the device removed was the device we were using. If so, then reset
        * device handler (myHidDevice), disable the timer, and update the GUI.
        * 
        ***********************************************************************/

        public void usbDevices_DeviceRemoved(object sender, EventArgs e) 
        {

            USBEventArgs usbEvent = e as USBEventArgs;
            if ((usbEvent.ProductID == Product_ID) && (usbEvent.VendorID == Vendor_ID))
            {
                InputTimer.Enabled = false;         // Disable interrupts for polling HID device
                myHidDevice = null;
                GetDevice();                        // Process device status
            } 
        }

        /**********************************************************************
        * NAME: usbDevices_DeviceAttached
        * 
        * DESCRIPTION: Event handler for the attachment of a USB device. The function
        * first checks to see if a matching device is already connected by seeing
        * if the handler (myHidDevice) is null. If no device is previously attached,
        * the function will call GetDevice to check and see if a matching device was 
        * attached.
        * 
         ***********************************************************************/
        
        public void usbDevices_DeviceAttached(object sender, EventArgs e)
        {
            if (myHidDevice == null)
            {
                GetDevice();                        // Process device status
            }
        }


        /**********************************************************************
        * NAME: GetDevice
        * 
        * DESCRIPTION: Function checks to see if a matching USB device is attached
        * based on the VID and PID provided in the application. When a device is
        * found, it is assigned a handler (myHidDevice) and the GUI is updated to 
        * reflect the connection. Additionally, if the device is not connected,
        * the function will update the GUI to reflect the disconnection.
        * 
        ***********************************************************************/
   
        public void GetDevice()
        {
            //Look for device matching VID/PID
            myHidDevice = usbDevices[Vendor_ID, Product_ID] as CyHidDevice;

            if (myHidDevice != null)                //Check to see if device is already connected
            {

                Status.Text = "Connected";
                Status.ForeColor = Color.Green;
                SwStatus.Enabled = true;
                InputTimer.Enabled = true;          //Enable background timer

                Update_LED();                       //Initialize the LED based on current GUI configuration
                Update_PWMDutyCycle();              //Initialize the PWM based on current GUI configuration

            }
            
            else
            {
                Status.Text = "Disconnected";
                Status.ForeColor = Color.Red;
            }
        }


        /**********************************************************************
         * NAME: Update_PWMDutyCycle
         * 
         * DESCRIPTION: Function used to update the state of the PWM Duty Cycle 
         * on the PSoC device end by reading the value on the PWM Duty Cycle text field
         * (DutyTextBox), applying the change to the Output Data Buffer, and 
         * writing the OUT report.
         * 
         ***********************************************************************/
       
        public void Update_PWMDutyCycle()
        {
            //Update the Output Buffer for PWM based on selected checkbox setting
            DutyCycle = Convert.ToUInt32(DutyTextBox.Text);
            myHidDevice.Outputs.DataBuf[PWM_DutyCycle_Position] = (byte)DutyCycle;
            myHidDevice.WriteOutput();
        }

        /**********************************************************************
         * NAME: Update_LED
         * 
         * DESCRIPTION: Function used to update the state of the LED on the PSoC
         * device end by checking the current status of the LED check box, 
         * applying the change to the Output Data Buffer, and writing the OUT report.
         * 
         ***********************************************************************/
        
        public void Update_LED()
        {
            //Update the Output Buffer for LED based on selected checkbox setting
            if (LED_State_CheckBox.Checked)
            {
                myHidDevice.Outputs.DataBuf[LED_State_Position] = 0xFF;
            }

            else
            {
                myHidDevice.Outputs.DataBuf[LED_State_Position] = 0x00;
            }

            myHidDevice.WriteOutput();
        }

        /**********************************************************************
         * NAME: InputTimer_Tick
         * 
         * DESCRIPTION: Function called by Timer (InputTimer) which is used to poll
         * for input data every 10ms. Function will check contents of Input Data 
         * and change display of switch status and update the ADC Value field.
         * 
         ***********************************************************************/
        
        private void InputTimer_Tick(object sender, EventArgs e)
        {
            if (myHidDevice != null)
            {
                InputTimer.Enabled = false;                                                     // Disable timer so we don't get another interrupt until we service this interrupt
                myHidDevice.ReadInput();                                                        // This CyUSB.DLL method uses the Win32 ReadFile() function to read IN data transferred to our application from the device

                debugcnt++;

                finger1_1 = myHidDevice.Inputs.DataBuf[Finger1_Byte1_Position];
                finger1_2 = myHidDevice.Inputs.DataBuf[Finger1_Byte2_Position];
                finger2_1 = myHidDevice.Inputs.DataBuf[Finger2_Byte1_Position];
                finger2_2 = myHidDevice.Inputs.DataBuf[Finger2_Byte2_Position];
                finger3_1 = myHidDevice.Inputs.DataBuf[Finger3_Byte1_Position];
                finger3_2 = myHidDevice.Inputs.DataBuf[Finger3_Byte2_Position];
                finger4_1 = myHidDevice.Inputs.DataBuf[Finger4_Byte1_Position];
                finger4_2 = myHidDevice.Inputs.DataBuf[Finger4_Byte2_Position];

                FingerCNT = FingerCNT % Filter_Size;

                    finger1Array[FingerCNT]= (finger1_1 << 8) + finger1_2;
                    finger2Array[FingerCNT] = (finger2_1 << 8) + finger2_2;
                    finger3Array[FingerCNT] = (finger3_1 << 8) + finger3_2;
                    finger4Array[FingerCNT] = (finger4_1 << 8) + finger4_2;





                                
                for (i = 0; i < Filter_Size; i++) { 
                
                    Finger1HLDR = finger1Array[i] + Finger1HLDR;
                    Finger2HLDR = finger2Array[i] + Finger2HLDR;
                    Finger3HLDR = finger3Array[i] + Finger3HLDR;
                    Finger4HLDR = finger4Array[i] + Finger4HLDR;
                }

                Finger1HLDR = Finger1HLDR / Filter_Size;
                Finger2HLDR = Finger2HLDR / Filter_Size;
                Finger3HLDR = Finger3HLDR / Filter_Size;
                Finger4HLDR = Finger4HLDR / Filter_Size;

                FingerCNT++;
                
                String finger1_Val = Finger1HLDR.ToString();
                String finger2_Val = Finger2HLDR.ToString();
                String finger3_Val = Finger3HLDR.ToString();
                String finger4_Val = Finger4HLDR.ToString();

                String debugcntst = finger1_1.ToString();

                AdcValueBox.Text = finger1_Val;
                AdcValueBox2.Text = finger2_Val;
                AdcValueBox3.Text = finger3_Val;
                AdcValueBox4.Text = finger4_Val;// finger4_Val;

                try
                {
                    string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine(finger1_Val);
                    sb.AppendLine(finger2_Val);
                    sb.AppendLine(finger3_Val);
                    sb.AppendLine(finger4_Val);
                    using (var fileStream = new FileStream(mydocpath + @"\testfile.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    using (StreamWriter outfile = new StreamWriter(fileStream))
                    {
                        outfile.Write(sb.ToString());
                        outfile.Close();
                    }
                }
                catch (Exception E) {
     
                }


                //Re-enable the timer
                InputTimer.Enabled = true;
            }
        }

        /**********************************************************************
         * NAME: Update_PWM_Click
         * 
         * DESCRIPTION: When "Update" button is pressed to update PWM value, function
         * checks to see if a matching USB device is currently connected. If so, function
         * calls another function to update the PWM Duty Cycle on the device.
         * 
         ***********************************************************************/
        
        private void Update_PWM_Click(object sender, EventArgs e)
        {
            //Respond to user pressing "Update" button. Make sure device is connected before hand.
            if (myHidDevice != null)
            {
                Update_PWMDutyCycle();
            }
        }


        /**********************************************************************
         * NAME: Set_VidPid_Click
         * 
         * DESCRIPTION: Updates the applications Vendor ID and Product ID based on 
         * user input when the "Set" button is clicked. This will cause the default VID
         * and PID of 0x04B4 and 0xE177 to be overwritten. The function will then
         * call GetDevice() to check for matching USB device.
         * 
         ***********************************************************************/
        
        private void Set_VidPid_Click(object sender, EventArgs e)
        {
            //Respond to update of VID and PID value by pressing the "Set" button
            Vendor_ID = Convert.ToInt32(VidTextBox.Text, 16);
            Product_ID = Convert.ToInt32(PidTextBox.Text, 16);
            GetDevice();
        }


        /**********************************************************************
         * NAME: LED_State_CheckBox_CheckedChanged
         * 
         * DESCRIPTION: When state of the LED State check box is changed, function
         * checks to see if a matching USB device is currently connected. If so, function
         * calls another function to update the LED state on the device.
         * 
         ***********************************************************************/
        
        private void LED_State_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Respond to change in LED checkbox state. Make sure device is connected before hand.
            if (myHidDevice != null)
            {
                Update_LED();
            }
        }

        private void VidTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void AdcValueBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


    }
}
