/*****************************************************************************
* File Name: main.c
*
* Version: 1.1
*
* Description:
* The example project will include a full speed USB component configured to enumerate 
* as a HID. The project will read a value from an ADC and monitor the status of a push
* button on a DVK board. This collected information will be transfered to the host via an
* IN tranfser. An interface application will be used in conjunction to allow the user to adjust the 
* Duty Cycle of a PWM and control the On/Off state of an LED. This information will be transfered to 
* the PSoC via an OUT transfer.
*
* Owner:
* Robert Murphy (RLRM)
*
* Hardware Dependency:
* CY8CKIT-001
* CY8CKIT-030
* CY8CKIT-050
*
* Code Tested With:
* 1. PSoC Creator 2.0
* 2. DP8051-Keil Generic Compiler
* 3. ARM GCC Compiler
******************************************************************************
* Copyright (2011), Cypress Semiconductor Corporation.
******************************************************************************
* This software is owned by Cypress Semiconductor Corporation (Cypress) and is
* protected by and subject to worldwide patent protection (United States and
* foreign), United States copyright laws and international treaty provisions.
* Cypress hereby grants to licensee a personal, non-exclusive, non-transferable
* license to copy, use, modify, create derivative works of, and compile the
* Cypress Source Code and derivative works for the sole purpose of creating
* custom software in support of licensee product to be used only in conjunction
* with a Cypress integrated circuit as specified in the applicable agreement.
* Any reproduction, modification, translation, compilation, or representation of
* this software except as specified above is prohibited without the express
* written permission of Cypress.
*
* Disclaimer: CYPRESS MAKES NO WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, WITH
* REGARD TO THIS MATERIAL, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
* WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
*
* Cypress reserves the right to make changes without further notice to the
* materials described herein. Cypress does not assume any liability arising out
* of the application or use of any product or circuit described herein. Cypress
* does not authorize its products for use as critical components in life-support
* systems where a malfunction or failure may reasonably be expected to result in
* significant injury to the user. The inclusion of Cypress' product in a life-
* support systems application implies that the manufacturer assumes all risk of
* such use and in doing so indemnifies Cypress against all charges. Use may be
* limited by and subject to the applicable Cypress software license agreement.
*****************************************************************************/

#include <device.h>
#include <stdio.h>

/* Declare defines for constant variables */
#define DEVICE_ID 0
#define IN_ENDPOINT 0x01
#define OUT_ENDPOINT 0x02
#define MAX_NUM_BYTES  8
#define UnassignedAddress 0

/* Array Positioning for IN Data */
#define ADC_Pos_1 0
#define ADC_Pos_2 1
#define ADC_Pos_3 2
#define ADC_Pos_4 3
#define ADC_Pos_5 4
#define ADC_Pos_6 5
#define ADC_Pos_7 6
#define ADC_Pos_8 7

uint8 Mux_cycle = 0;

/* Array Positioning for OUT Data */
#define LED_State_Pos 0
#define PWM_DC_Pos 1

/* Input and Output Data Buffers */
uint8 IN_Data_Buffer[16];  /* [0] = Button Status, [1..4] = ADC Result, [5..7] = Unused */
uint8 OUT_Data_Buffer[16]; /* [0] = LED State, [1] = PWM Duty Cycle, [2..7] = Unused */

/* Display buffer for Character LCD */
char ADC_Display_Data[10];
char PWM_Duty_Display_Data[5];

/* Various Application Variables */
int32 ADC_Result;
int8 PWM_DutyCycle;
uint8 OUT_COUNT;
uint16 LCD_Update_Timer = 0x00;

/* Function Prototypes */
void Process_EP2 (void);
void Process_EP1 (void);
void Update_LCD (void); 

int8 ValHoldF11 = 0;
int8 ValHoldF12 = 0;
int8 ValHoldF21 = 0;
int8 ValHoldF22 = 0;
int8 ValHoldF31 = 0;
int8 ValHoldF32 = 0;
int8 ValHoldF41 = 0;
int8 ValHoldF42 = 0;

int32 Finger1Array[10];
int32 Finger2Array[10];
int32 Finger3Array[10];
int32 Finger4Array[10];

int finger1_cnt = 0;
int finger2_cnt = 0;
int finger3_cnt = 0;
int finger4_cnt = 0;

void main (void)
{
	/*Enable Global Interrupts */
	CYGlobalIntEnable; 
    
    //init mux
    AMux_1_Start();
	/*Initalize ADC */
	ADC_Start();
	ADC_StartConvert();
	
	/*Initalize LCD and place static text */
	LCD_Start();
	LCD_Position(0,0);
	LCD_PrintString("PSoC Generic HID");
	LCD_Position(1,0);
	LCD_PrintString("AD:");
	LCD_Position(1,11);
	LCD_PrintString("D:");
	
	/*Initalize PWM */
	PWM_Start();
	PWM_WriteCompare(10);
	
	/*Initalize LED Off */
	LED_2_Write(1);
	
    /* Start USBFS Operation for the DEVICE_ID and with 5V operation  */
    USBFS_Start(0, USBFS_DWR_VDDD_OPERATION); 
	
	/* Ensure device is configured before running code */
    while(USBFS_bGetConfiguration() == 0x00)
	{
		/* Waiting for device to be configured */
	}
	
    for(;;)
    {
		/* Prepare the push button and ADC data to be sent to the host */
		Process_EP1();
		
		/*Check to see if the IN Endpoint is empty. If so, load it with Input data to be tranfered */
		if(USBFS_GetEPState(IN_ENDPOINT) == USBFS_IN_BUFFER_EMPTY)
		{
			/* Load data located in IN_Data_Buffer and load it into the IN endpoint */
			USBFS_LoadEP(IN_ENDPOINT, IN_Data_Buffer, MAX_NUM_BYTES);
			/* Enable the OUT endpoint to recieve data */
			USBFS_EnableOutEP(OUT_ENDPOINT);
		}	
		
		/* Check to see if the OUT Endpoint is full from a recieved transaction. */
		if(USBFS_GetEPState(OUT_ENDPOINT) == USBFS_OUT_BUFFER_FULL)
		{
			/* Get the number of bytes recieved */
			OUT_COUNT = USBFS_GetEPCount(OUT_ENDPOINT);
			/* Read the OUT endpoint and store data in OUT_Data_Buffer */
			USBFS_ReadOutEP(OUT_ENDPOINT, OUT_Data_Buffer, OUT_COUNT);
			/* Re-enable OUT endpoint */
			USBFS_EnableOutEP(OUT_ENDPOINT);
		}
		
		/* Process the data recieved from the host */
		Process_EP2();
		
		/* Impliment a perodic delay for updating the LCD */
		if(LCD_Update_Timer >= 0x08FF)
		{
			/* Call function to update Character LCD with ADC and PWM Duty Cycle value */
			Update_LCD();
		}
		
		/* Increment LCD Timer */
		LCD_Update_Timer ++;
    }
}

/**********************************************************************
* NAME: Process_EP2
* 
* DESCRIPTION: Function to process the OUT data (data sent from the PC).
* This data includes the state of LED_2 (On or Off) and the duty cycle
* of the PWM attached to LED_1.
* 
***********************************************************************/
void Process_EP2 (void)
{
	/* Update PWM Compare Value */
	if((OUT_Data_Buffer[PWM_DC_Pos] > 0) && (OUT_Data_Buffer[PWM_DC_Pos] <= 100))
	{
		PWM_DutyCycle = OUT_Data_Buffer[PWM_DC_Pos];
		PWM_WriteCompare(PWM_DutyCycle);
	}
	
	/* Check to see if LED_2 Should be on */
	if(OUT_Data_Buffer[LED_State_Pos] != 0)
	{
		LED_2_Write(1);
	}
	else
	{
		LED_2_Write(0);
	}
}

/**********************************************************************
* NAME: Process_EP1
* 
* DESCRIPTION: Function to process the IN data (data sent to the PC).
* This data includes the value read from the DelSig ADC and the current 
* status of push button connected to SW_In.
* 
***********************************************************************/
void Process_EP1 (void)
{

	/* Check if ADC data is ready */
	if(ADC_IsEndConversion(ADC_RETURN_STATUS) != 0x00)
	{
        /* Read ADC Sample */
		ADC_Result = ADC_GetResult32();
        
        if (ADC_Result<0) ADC_Result = 0;
        if (ADC_Result>65536) ADC_Result = 65536;
        
        int i;
        if(Mux_cycle==0){
            
            Finger1Array[finger1_cnt] = ADC_Result;
            
            finger1_cnt++;
            int Val_Holder = 0;
            for (i=0;i<10;i++){
                Val_Holder = Val_Holder+Finger1Array[i];
            }
        
            Val_Holder = Val_Holder/10;
		    
            ValHoldF11 = (int8) 0x000000FF & (Val_Holder >>  8);
            ValHoldF12 = (int8) 0x000000FF & Val_Holder;
            
            finger1_cnt = finger1_cnt%10;
            
        }
        else if(Mux_cycle==1){
            Finger2Array[finger2_cnt] = ADC_Result;
            
            finger2_cnt++;
            int Val_Holder = 0;
            for (i=0;i<10;i++){
                Val_Holder = Val_Holder+Finger2Array[i];
            }
        
            Val_Holder = Val_Holder/10;
        
            ValHoldF21 = (int8) 0x000000FF & (Val_Holder >>  8);
            ValHoldF22 = (int8) 0x000000FF & Val_Holder;
            finger2_cnt = finger2_cnt%10;
        }
        else if(Mux_cycle==2){
            Finger3Array[finger3_cnt] = ADC_Result;
            
            finger3_cnt++;
            int Val_Holder = 0;
            for (i=0;i<10;i++){
                Val_Holder = Val_Holder+Finger3Array[i];
            }
        
            Val_Holder = Val_Holder/10;
        
        
            ValHoldF31 = (int8) 0x000000FF & (Val_Holder >>  8);
            ValHoldF32 = (int8) 0x000000FF & Val_Holder;
            finger3_cnt = finger3_cnt%10;
        }
        else if(Mux_cycle==3){
        
            Finger4Array[finger4_cnt] = ADC_Result;
            
            finger4_cnt++;
            int Val_Holder = 0;
            for (i=0;i<10;i++){
                Val_Holder = Val_Holder+Finger4Array[i];
            }
        
            Val_Holder = Val_Holder/10;
        
            ValHoldF41 = (int8) 0x000000FF & (Val_Holder >>  8);
            ValHoldF42 = (int8) 0x000000FF & Val_Holder;
            
            finger4_cnt = finger4_cnt%10;
        }
        IN_Data_Buffer[ADC_Pos_1] = ValHoldF11;
		IN_Data_Buffer[ADC_Pos_2] = ValHoldF12;
        IN_Data_Buffer[ADC_Pos_3] = ValHoldF21;
		IN_Data_Buffer[ADC_Pos_4] = ValHoldF22;
        IN_Data_Buffer[ADC_Pos_5] = ValHoldF31;
		IN_Data_Buffer[ADC_Pos_6] = ValHoldF32;
        IN_Data_Buffer[ADC_Pos_7] = ValHoldF41;
		IN_Data_Buffer[ADC_Pos_8] = ValHoldF42;
        
        
        AMux_1_Select(Mux_cycle);
        if (Mux_cycle<3)Mux_cycle++;
        else Mux_cycle = 0;
        
	}
}

/**********************************************************************
    * NAME: Update_LCD
* 
* DESCRIPTION: Function periodically update the Character LCD with the
* ADC value and PWM duty cycle.
* 
***********************************************************************/
void Update_LCD (void)
{
	/* Convert ADC Value to CHAR and display on Character LCD */
	sprintf(ADC_Display_Data, "%-7ld", ADC_Result);
	LCD_Position(1,3);
	LCD_PrintString(ADC_Display_Data);
	
	/* Convert PWM Duty Cycle to CHAR and display on Character LCD */
	sprintf(PWM_Duty_Display_Data, "%-3d", (int16)PWM_ReadCompare());
	LCD_Position(1,13);
	LCD_PrintString(PWM_Duty_Display_Data);	
	
	/* Reset LCD Update Timer */
	LCD_Update_Timer = 0x00;
}
/* [] END OF FILE */
