/*******************************************************************************
* File Name: Finger3.h  
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

#if !defined(CY_PINS_Finger3_H) /* Pins Finger3_H */
#define CY_PINS_Finger3_H

#include "cytypes.h"
#include "cyfitter.h"
#include "cypins.h"
#include "Finger3_aliases.h"

/* Check to see if required defines such as CY_PSOC5A are available */
/* They are defined starting with cy_boot v3.0 */
#if !defined (CY_PSOC5A)
    #error Component cy_pins_v1_90 requires cy_boot v3.0 or later
#endif /* (CY_PSOC5A) */

/* APIs are not generated for P15[7:6] */
#if !(CY_PSOC5A &&\
	 Finger3__PORT == 15 && ((Finger3__MASK & 0xC0) != 0))


/***************************************
*        Function Prototypes             
***************************************/    

void    Finger3_Write(uint8 value) ;
void    Finger3_SetDriveMode(uint8 mode) ;
uint8   Finger3_ReadDataReg(void) ;
uint8   Finger3_Read(void) ;
uint8   Finger3_ClearInterrupt(void) ;


/***************************************
*           API Constants        
***************************************/

/* Drive Modes */
#define Finger3_DM_ALG_HIZ         PIN_DM_ALG_HIZ
#define Finger3_DM_DIG_HIZ         PIN_DM_DIG_HIZ
#define Finger3_DM_RES_UP          PIN_DM_RES_UP
#define Finger3_DM_RES_DWN         PIN_DM_RES_DWN
#define Finger3_DM_OD_LO           PIN_DM_OD_LO
#define Finger3_DM_OD_HI           PIN_DM_OD_HI
#define Finger3_DM_STRONG          PIN_DM_STRONG
#define Finger3_DM_RES_UPDWN       PIN_DM_RES_UPDWN

/* Digital Port Constants */
#define Finger3_MASK               Finger3__MASK
#define Finger3_SHIFT              Finger3__SHIFT
#define Finger3_WIDTH              1u


/***************************************
*             Registers        
***************************************/

/* Main Port Registers */
/* Pin State */
#define Finger3_PS                     (* (reg8 *) Finger3__PS)
/* Data Register */
#define Finger3_DR                     (* (reg8 *) Finger3__DR)
/* Port Number */
#define Finger3_PRT_NUM                (* (reg8 *) Finger3__PRT) 
/* Connect to Analog Globals */                                                  
#define Finger3_AG                     (* (reg8 *) Finger3__AG)                       
/* Analog MUX bux enable */
#define Finger3_AMUX                   (* (reg8 *) Finger3__AMUX) 
/* Bidirectional Enable */                                                        
#define Finger3_BIE                    (* (reg8 *) Finger3__BIE)
/* Bit-mask for Aliased Register Access */
#define Finger3_BIT_MASK               (* (reg8 *) Finger3__BIT_MASK)
/* Bypass Enable */
#define Finger3_BYP                    (* (reg8 *) Finger3__BYP)
/* Port wide control signals */                                                   
#define Finger3_CTL                    (* (reg8 *) Finger3__CTL)
/* Drive Modes */
#define Finger3_DM0                    (* (reg8 *) Finger3__DM0) 
#define Finger3_DM1                    (* (reg8 *) Finger3__DM1)
#define Finger3_DM2                    (* (reg8 *) Finger3__DM2) 
/* Input Buffer Disable Override */
#define Finger3_INP_DIS                (* (reg8 *) Finger3__INP_DIS)
/* LCD Common or Segment Drive */
#define Finger3_LCD_COM_SEG            (* (reg8 *) Finger3__LCD_COM_SEG)
/* Enable Segment LCD */
#define Finger3_LCD_EN                 (* (reg8 *) Finger3__LCD_EN)
/* Slew Rate Control */
#define Finger3_SLW                    (* (reg8 *) Finger3__SLW)

/* DSI Port Registers */
/* Global DSI Select Register */
#define Finger3_PRTDSI__CAPS_SEL       (* (reg8 *) Finger3__PRTDSI__CAPS_SEL) 
/* Double Sync Enable */
#define Finger3_PRTDSI__DBL_SYNC_IN    (* (reg8 *) Finger3__PRTDSI__DBL_SYNC_IN) 
/* Output Enable Select Drive Strength */
#define Finger3_PRTDSI__OE_SEL0        (* (reg8 *) Finger3__PRTDSI__OE_SEL0) 
#define Finger3_PRTDSI__OE_SEL1        (* (reg8 *) Finger3__PRTDSI__OE_SEL1) 
/* Port Pin Output Select Registers */
#define Finger3_PRTDSI__OUT_SEL0       (* (reg8 *) Finger3__PRTDSI__OUT_SEL0) 
#define Finger3_PRTDSI__OUT_SEL1       (* (reg8 *) Finger3__PRTDSI__OUT_SEL1) 
/* Sync Output Enable Registers */
#define Finger3_PRTDSI__SYNC_OUT       (* (reg8 *) Finger3__PRTDSI__SYNC_OUT) 


#if defined(Finger3__INTSTAT)  /* Interrupt Registers */

    #define Finger3_INTSTAT                (* (reg8 *) Finger3__INTSTAT)
    #define Finger3_SNAP                   (* (reg8 *) Finger3__SNAP)

#endif /* Interrupt Registers */

#endif /* CY_PSOC5A... */

#endif /*  CY_PINS_Finger3_H */


/* [] END OF FILE */
