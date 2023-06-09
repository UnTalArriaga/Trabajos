#INCLUDE <P16F877A.INC>
	VALOR1 EQU 0X21
	VALOR2 EQU 0X22
	VALOR3 EQU 0X23
	CTE2 EQU 0X14
	CTE3 EQU 0X07
	TIEMPO EQU .19
	T_ON EQU 0X24
	T_OFF EQU 0X25
RESET:
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	CLRF PORTA ;LIMPIA EL PUERTOS A Y B
	CLRF PORTC
	BSF STATUS,RP0 ;CAMBIA AL BANCO 01 DE RAM
	CLRF TRISC ;CONFIGURA LOS PINES DEL PUERTO B COMO SALIDAS
	MOVLW 0X06
	MOVWF ADCON1 ;CONFIGURA LOS PINES DEL PUERTO A Y E COMO DIG
	MOVLW 0X3F
	MOVWF TRISA ;PUERTO A COMO ENTRADAS
	BCF STATUS,RP0 ;REGRESA AL BANCO 0 DE RAM
LOOP:
	MOVF PORTA,W ;W <-- (PORTA)
	SUBLW 0X04
	BTFSC STATUS,Z
	GOTO SW4
	MOVF PORTA,W
	SUBLW 0X02
	BTFSC STATUS,Z
	GOTO SW2
	MOVF PORTA,W
	SUBLW 0X01
	BTFSC STATUS,Z
	GOTO SW1
	GOTO NADA
SW4:
	MOVLW .05
	CALL SERVO
	GOTO LOOP
SW2:
	MOVLW .15
	CALL SERVO
	GOTO LOOP
SW1:
	MOVLW .25
	CALL SERVO
	GOTO LOOP
NADA:
	CLRF PORTB
	GOTO LOOP
SERVO:
	MOVWF T_ON
	SUBLW .200
	MOVWF T_OFF
	BSF PORTC,0
	MOVF T_ON,W
	CALL RETARDO
	BCF PORTC,0
	MOVF T_OFF,W
	CALL RETARDO
	RETURN
RETARDO:
	MOVWF VALOR1
TRES:
	MOVLW CTE2 ;W <-- CTE2
	MOVWF VALOR2 ;(VALOR2) <-- CTE2
DOS:
	MOVLW CTE3 ;W <-- CTE3
	MOVWF VALOR3 ;(VALOR3) <-- CTE3
UNO:
	DECFSZ VALOR3 ;(VALOR3)--, �VALOR3 = 0?
	GOTO UNO ;NO, VE A UNO
	DECFSZ VALOR2 ;SI, �VALOR2 = 0?
	GOTO DOS ;NO, VE A DOS
	DECFSZ VALOR1 ;SI, �VALOR1 = 0?
	GOTO TRES ;NO, VE A TRES
EXT RETURN ;SI, SALE
	END