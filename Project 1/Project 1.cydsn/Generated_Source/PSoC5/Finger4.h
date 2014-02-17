/*******************************************************************************
* File Name: Finger4.h  
* Version 1.90
*
* Description:
*  This file containts Control Register function prototypes and register defines
*
* Note:
*
********************************************************************************
* Copyright 2008-2012, Cypress Semiconductor Corporation.  All rights reserved.
* You may use this file only in accordance with the license, terms, conditions, 
* disclaimers, and limitations in the end user license agreement accompanying 
* the software package with which this file was provided.
*******************************************************************************/

#if !defined(CY_PINS_Finger4_H) /* Pins Finger4_H */
#define CY_PINS_Finger4_H

#include "cytypes.h"
#include "cyfitter.h"
#include "cypins.h"
#include "Finger4_aliases.h"

/* Check to see if required defines such as CY_PSOC5A are available */
/* They are defined starting with cy_boot v3.0 */
#if !defined (CY_PSOC5A)
    #error Component cy_pins_v1_90 requires cy_boot v3.0 or later
#endif /* (CY_PSOC5A) */

/* APIs are not generated for P15[7:6] */
#if !(CY_PSOC5A &&\
	 Finger4__PORT == 15 && ((Finger4__MASK & 0xC0) != 0))


/***************************************
*        Function Prototypes             
***************************************/    

void    Finger4_Write(uint8 value) ;
void    Finger4_SetDriveMode(uint8 mode) ;
uint8   Finger4_ReadDataReg(void) ;
uint8   Finger4_Read(void) ;
uint8   Finger4_ClearInterrupt(void) ;


/***************************************
*           API Constants        
***************************************/

/* Drive Modes */
#define Finger4_DM_ALG_HIZ         PIN_DM_ALG_HIZ
#define Finger4_DM_DIG_HIZ         PIN_DM_DIG_HIZ
#define Finger4_DM_RES_UP          PIN_DM_RES_UP
#define Finger4_DM_RES_DWN         PIN_DM_RES_DWN
#define Finger4_DM_OD_LO           PIN_DM_OD_LO
#define Finger4_DM_OD_HI           PIN_DM_OD_HI
#define Finger4_DM_STRONG          PIN_DM_STRONG
#define Finger4_DM_RES_UPDWN       PIN_DM_RES_UPDWN

/* Digital Port Constants */
#define Finger4_MASK               Finger4__MASK
#define Finger4_SHIFT              Finger4__SHIFT
#define Finger4_WIDTH              1u


/***************************************
*             Registers        
***************************************/

/* Main Port Registers */
/* Pin State */
#define Finger4_PS                     (* (reg8 *) Finger4__PS)
/* Data Register */
#define Finger4_DR                     (* (reg8 *) Finger4__DR)
/* Port Number */
#define Finger4_PRT_NUM                (* (reg8 *) Finger4__PRT) 
/* Connect to Analog Globals */                                                  
#define Finger4_AG                     (* (reg8 *) Finger4__AG)                       
/* Analog MUX bux enable */
#define Finger4_AMUX                   (* (reg8 *) Finger4__AMUX) 
/* Bidirectional Enable */                                                        
#define Finger4_BIE                    (* (reg8 *) Finger4__BIE)
/* Bit-mask for Aliased Register Access */
#define Finger4_BIT_MASK               (* (reg8 *) Finger4__BIT_MASK)
/* Bypass Enable */
#define Finger4_BYP                    (* (reg8 *) Finger4__BYP)
/* Port wide control signals */                                                   
#define Finger4_CTL                    (* (reg8 *) Finger4__CTL)
/* Drive Modes */
#define Finger4_DM0                    (* (reg8 *) Finger4__DM0) 
#define Finger4_DM1                    (* (reg8 *) Finger4__DM1)
#define Finger4_DM2                    (* (reg8 *) Finger4__DM2) 
/* Input Buffer Disable Override */
#define Finger4_INP_DIS                (* (reg8 *) Finger4__INP_DIS)
/* LCD Common or Segment Drive */
#define Finger4_LCD_COM_SEG            (* (reg8 *) Finger4__LCD_COM_SEG)
/* Enable Segment LCD */
#define Finger4_LCD_EN                 (* (reg8 *) Finger4__LCD_EN)
/* Slew Rate Control */
#define Finger4_SLW                    (* (reg8 *) Finger4__SLW)

/* DSI Port Registers */
/* Global DSI Select Register */
#define Finger4_PRTDSI__CAPS_SEL       (* (reg8 *) Finger4__PRTDSI__CAPS_SEL) 
/* Double Sync Enable */
#define Finger4_PRTDSI__DBL_SYNC_IN    (* (reg8 *) Finger4__PRTDSI__DBL_SYNC_IN) 
/* Output Enable Select Drive Strength */
#define Finger4_PRTDSI__OE_SEL0        (* (reg8 *) Finger4__PRTDSI__OE_SEL0) 
#define Finger4_PRTDSI__OE_SEL1        (* (reg8 *) Finger4__PRTDSI__OE_SEL1) 
/* Port Pin Output Select Registers */
#define Finger4_PRTDSI__OUT_SEL0       (* (reg8 *) Finger4__PRTDSI__OUT_SEL0) 
#define Finger4_PRTDSI__OUT_SEL1       (* (reg8 *) Finger4__PRTDSI__OUT_SEL1) 
/* Sync Output Enable Registers */
#define Finger4_PRTDSI__SYNC_OUT       (* (reg8 *) Finger4__PRTDSI__SYNC_OUT) 


#if defined(Finger4__INTSTAT)  /* Interrupt Registers */

    #define Finger4_INTSTAT                (* (reg8 *) Finger4__INTSTAT)
    #define Finger4_SNAP                   (* (reg8 *) Finger4__SNAP)

#endif /* Interrupt Registers */

#endif /* CY_PSOC5A... */

#endif /*  CY_PINS_Finger4_H */


/* [] END OF FILE */
