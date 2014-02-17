/*******************************************************************************
* File Name: Finger1.h  
* Version 1.70
*
* Description:
*  This file containts Control Register function prototypes and register defines
*
* Note:
*
********************************************************************************
* Copyright 2008-2010, Cypress Semiconductor Corporation.  All rights reserved.
* You may use this file only in accordance with the license, terms, conditions, 
* disclaimers, and limitations in the end user license agreement accompanying 
* the software package with which this file was provided.
********************************************************************************/

#if !defined(CY_PINS_Finger1_H) /* Pins Finger1_H */
#define CY_PINS_Finger1_H

#include "cytypes.h"
#include "cyfitter.h"
#include "cypins.h"
#include "Finger1_aliases.h"

/* Check to see if required defines such as CY_PSOC5A are available */
/* They are defined starting with cy_boot v3.0 */
#if !defined (CY_PSOC5A)
    #error Component cy_pins_v1_70 requires cy_boot v3.0 or later
#endif /* (CY_PSOC5A) */

/* APIs are not generated for P15[7:6] */
#if !(CY_PSOC5A &&\
	 Finger1__PORT == 15 && (Finger1__MASK & 0xC0))

/***************************************
*        Function Prototypes             
***************************************/    

void    Finger1_Write(uint8 value) ;
void    Finger1_SetDriveMode(uint8 mode) ;
uint8   Finger1_ReadDataReg(void) ;
uint8   Finger1_Read(void) ;
uint8   Finger1_ClearInterrupt(void) ;

/***************************************
*           API Constants        
***************************************/

/* Drive Modes */
#define Finger1_DM_ALG_HIZ         PIN_DM_ALG_HIZ
#define Finger1_DM_DIG_HIZ         PIN_DM_DIG_HIZ
#define Finger1_DM_RES_UP          PIN_DM_RES_UP
#define Finger1_DM_RES_DWN         PIN_DM_RES_DWN
#define Finger1_DM_OD_LO           PIN_DM_OD_LO
#define Finger1_DM_OD_HI           PIN_DM_OD_HI
#define Finger1_DM_STRONG          PIN_DM_STRONG
#define Finger1_DM_RES_UPDWN       PIN_DM_RES_UPDWN

/* Digital Port Constants */
#define Finger1_MASK               Finger1__MASK
#define Finger1_SHIFT              Finger1__SHIFT
#define Finger1_WIDTH              1u

/***************************************
*             Registers        
***************************************/

/* Main Port Registers */
/* Pin State */
#define Finger1_PS                     (* (reg8 *) Finger1__PS)
/* Data Register */
#define Finger1_DR                     (* (reg8 *) Finger1__DR)
/* Port Number */
#define Finger1_PRT_NUM                (* (reg8 *) Finger1__PRT) 
/* Connect to Analog Globals */                                                  
#define Finger1_AG                     (* (reg8 *) Finger1__AG)                       
/* Analog MUX bux enable */
#define Finger1_AMUX                   (* (reg8 *) Finger1__AMUX) 
/* Bidirectional Enable */                                                        
#define Finger1_BIE                    (* (reg8 *) Finger1__BIE)
/* Bit-mask for Aliased Register Access */
#define Finger1_BIT_MASK               (* (reg8 *) Finger1__BIT_MASK)
/* Bypass Enable */
#define Finger1_BYP                    (* (reg8 *) Finger1__BYP)
/* Port wide control signals */                                                   
#define Finger1_CTL                    (* (reg8 *) Finger1__CTL)
/* Drive Modes */
#define Finger1_DM0                    (* (reg8 *) Finger1__DM0) 
#define Finger1_DM1                    (* (reg8 *) Finger1__DM1)
#define Finger1_DM2                    (* (reg8 *) Finger1__DM2) 
/* Input Buffer Disable Override */
#define Finger1_INP_DIS                (* (reg8 *) Finger1__INP_DIS)
/* LCD Common or Segment Drive */
#define Finger1_LCD_COM_SEG            (* (reg8 *) Finger1__LCD_COM_SEG)
/* Enable Segment LCD */
#define Finger1_LCD_EN                 (* (reg8 *) Finger1__LCD_EN)
/* Slew Rate Control */
#define Finger1_SLW                    (* (reg8 *) Finger1__SLW)

/* DSI Port Registers */
/* Global DSI Select Register */
#define Finger1_PRTDSI__CAPS_SEL       (* (reg8 *) Finger1__PRTDSI__CAPS_SEL) 
/* Double Sync Enable */
#define Finger1_PRTDSI__DBL_SYNC_IN    (* (reg8 *) Finger1__PRTDSI__DBL_SYNC_IN) 
/* Output Enable Select Drive Strength */
#define Finger1_PRTDSI__OE_SEL0        (* (reg8 *) Finger1__PRTDSI__OE_SEL0) 
#define Finger1_PRTDSI__OE_SEL1        (* (reg8 *) Finger1__PRTDSI__OE_SEL1) 
/* Port Pin Output Select Registers */
#define Finger1_PRTDSI__OUT_SEL0       (* (reg8 *) Finger1__PRTDSI__OUT_SEL0) 
#define Finger1_PRTDSI__OUT_SEL1       (* (reg8 *) Finger1__PRTDSI__OUT_SEL1) 
/* Sync Output Enable Registers */
#define Finger1_PRTDSI__SYNC_OUT       (* (reg8 *) Finger1__PRTDSI__SYNC_OUT) 


#if defined(Finger1__INTSTAT)  /* Interrupt Registers */

    #define Finger1_INTSTAT                (* (reg8 *) Finger1__INTSTAT)
    #define Finger1_SNAP                   (* (reg8 *) Finger1__SNAP)

#endif /* Interrupt Registers */

#endif /* End Pins Finger1_H */

#endif
/* [] END OF FILE */
