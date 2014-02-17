/*******************************************************************************
* File Name: Finger2.h  
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

#if !defined(CY_PINS_Finger2_H) /* Pins Finger2_H */
#define CY_PINS_Finger2_H

#include "cytypes.h"
#include "cyfitter.h"
#include "cypins.h"
#include "Finger2_aliases.h"

/* Check to see if required defines such as CY_PSOC5A are available */
/* They are defined starting with cy_boot v3.0 */
#if !defined (CY_PSOC5A)
    #error Component cy_pins_v1_90 requires cy_boot v3.0 or later
#endif /* (CY_PSOC5A) */

/* APIs are not generated for P15[7:6] */
#if !(CY_PSOC5A &&\
	 Finger2__PORT == 15 && ((Finger2__MASK & 0xC0) != 0))


/***************************************
*        Function Prototypes             
***************************************/    

void    Finger2_Write(uint8 value) ;
void    Finger2_SetDriveMode(uint8 mode) ;
uint8   Finger2_ReadDataReg(void) ;
uint8   Finger2_Read(void) ;
uint8   Finger2_ClearInterrupt(void) ;


/***************************************
*           API Constants        
***************************************/

/* Drive Modes */
#define Finger2_DM_ALG_HIZ         PIN_DM_ALG_HIZ
#define Finger2_DM_DIG_HIZ         PIN_DM_DIG_HIZ
#define Finger2_DM_RES_UP          PIN_DM_RES_UP
#define Finger2_DM_RES_DWN         PIN_DM_RES_DWN
#define Finger2_DM_OD_LO           PIN_DM_OD_LO
#define Finger2_DM_OD_HI           PIN_DM_OD_HI
#define Finger2_DM_STRONG          PIN_DM_STRONG
#define Finger2_DM_RES_UPDWN       PIN_DM_RES_UPDWN

/* Digital Port Constants */
#define Finger2_MASK               Finger2__MASK
#define Finger2_SHIFT              Finger2__SHIFT
#define Finger2_WIDTH              1u


/***************************************
*             Registers        
***************************************/

/* Main Port Registers */
/* Pin State */
#define Finger2_PS                     (* (reg8 *) Finger2__PS)
/* Data Register */
#define Finger2_DR                     (* (reg8 *) Finger2__DR)
/* Port Number */
#define Finger2_PRT_NUM                (* (reg8 *) Finger2__PRT) 
/* Connect to Analog Globals */                                                  
#define Finger2_AG                     (* (reg8 *) Finger2__AG)                       
/* Analog MUX bux enable */
#define Finger2_AMUX                   (* (reg8 *) Finger2__AMUX) 
/* Bidirectional Enable */                                                        
#define Finger2_BIE                    (* (reg8 *) Finger2__BIE)
/* Bit-mask for Aliased Register Access */
#define Finger2_BIT_MASK               (* (reg8 *) Finger2__BIT_MASK)
/* Bypass Enable */
#define Finger2_BYP                    (* (reg8 *) Finger2__BYP)
/* Port wide control signals */                                                   
#define Finger2_CTL                    (* (reg8 *) Finger2__CTL)
/* Drive Modes */
#define Finger2_DM0                    (* (reg8 *) Finger2__DM0) 
#define Finger2_DM1                    (* (reg8 *) Finger2__DM1)
#define Finger2_DM2                    (* (reg8 *) Finger2__DM2) 
/* Input Buffer Disable Override */
#define Finger2_INP_DIS                (* (reg8 *) Finger2__INP_DIS)
/* LCD Common or Segment Drive */
#define Finger2_LCD_COM_SEG            (* (reg8 *) Finger2__LCD_COM_SEG)
/* Enable Segment LCD */
#define Finger2_LCD_EN                 (* (reg8 *) Finger2__LCD_EN)
/* Slew Rate Control */
#define Finger2_SLW                    (* (reg8 *) Finger2__SLW)

/* DSI Port Registers */
/* Global DSI Select Register */
#define Finger2_PRTDSI__CAPS_SEL       (* (reg8 *) Finger2__PRTDSI__CAPS_SEL) 
/* Double Sync Enable */
#define Finger2_PRTDSI__DBL_SYNC_IN    (* (reg8 *) Finger2__PRTDSI__DBL_SYNC_IN) 
/* Output Enable Select Drive Strength */
#define Finger2_PRTDSI__OE_SEL0        (* (reg8 *) Finger2__PRTDSI__OE_SEL0) 
#define Finger2_PRTDSI__OE_SEL1        (* (reg8 *) Finger2__PRTDSI__OE_SEL1) 
/* Port Pin Output Select Registers */
#define Finger2_PRTDSI__OUT_SEL0       (* (reg8 *) Finger2__PRTDSI__OUT_SEL0) 
#define Finger2_PRTDSI__OUT_SEL1       (* (reg8 *) Finger2__PRTDSI__OUT_SEL1) 
/* Sync Output Enable Registers */
#define Finger2_PRTDSI__SYNC_OUT       (* (reg8 *) Finger2__PRTDSI__SYNC_OUT) 


#if defined(Finger2__INTSTAT)  /* Interrupt Registers */

    #define Finger2_INTSTAT                (* (reg8 *) Finger2__INTSTAT)
    #define Finger2_SNAP                   (* (reg8 *) Finger2__SNAP)

#endif /* Interrupt Registers */

#endif /* CY_PSOC5A... */

#endif /*  CY_PINS_Finger2_H */


/* [] END OF FILE */
