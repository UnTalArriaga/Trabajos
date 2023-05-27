PROCESSOR 16F877A
INCLUDE <P16F877A.INC>
	VALOR1 EQU 0X21
	VALOR2 EQU 0X22 ; REGISTROS PARA EL RETARDO
	VALOR3 EQU 0X23
	CTE1 EQU 2 ;20 ms
	CTE2 EQU .200 ; VALORES PARA EL RETARDO
	CTE3 EQU .82
RESET:
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	CLRF PORTA ;LIMPIA EL PUERTOS A Y B
	CLRF PORTB
	BSF STATUS,RP0 ;CAMBIA AL BANCO 01
	CLRF TRISB ;CONFIGURA LOS PINES DEL PUERTO B COMO SALIDAS
	MOVLW 0X06
	MOVWF ADCON1 ;CONFIGURA LOS PINES DEL PUERTO A Y E COMO I/O DIGITALES
	MOVLW 0X3F
	MOVWF TRISA ;PUERTO A COMO ENTRADAS
	BCF STATUS,RP0 ;REGRESA AL BANCO 0 
LOOP:
	MOVF PORTA,W ;W <-- (PORTA)
	CALL MOTORES
	MOVWF PORTB ;(PORTB) <-- W
	CALL RETARDO
	GOTO LOOP
MOTORES:
	MOVF PORTA,0	;W<- PORTA
	ANDLW B'00001111' ;W<- PORTA && 00001111
	ADDWF PCL,F ;(PCL) <-- (PORTA) AND 0X0F
	RETLW 0				;PARO 		PARO 0
	RETLW B'00001000' 	;PARO 		HORARIO 1
	RETLW B'00000100'   ;PARO 		ANTI-HORARIO 2
	RETLW B'00000010' 	;HORARIO 	PARO 3
	RETLW B'00000001' 	;ANTI-HORA	PARO 4
	RETLW B'00001010' 	;HORARIO 	HORARIO 5
	RETLW B'00000101' 	;ANTI-HORA 	ANTI-HORARIO 6
	RETLW B'00000110' 	;HORARIO 	ANTI-HORARIO 7
	RETLW B'00001001' 	;ANTI-HORA 	HORARIO 8
	RETLW 0 			;PARO 		PARO
	RETLW 0 	;PARO PARO
	RETLW 0 	;PARO PARO
	RETLW 0 	;PARO PARO
	RETLW 0 	;PARO PARO
	RETLW 0 	;PARO PARO
	RETLW 0 	;PARO PARO
RETARDO:
	MOVLW CTE1 ;W <-- CTE1
	MOVWF VALOR1 ;(VALOR1) <-- CTE1
TRES 
	MOVLW CTE2 ;W <-- CTE2
	MOVWF VALOR2 ;(VALOR2) <-- CTE2
DOS 
	MOVLW CTE3 ;W <-- CTE3
	MOVWF VALOR3 ;(VALOR3) <-- CTE3
UNO 
	DECFSZ VALOR3 ;(VALOR3)--, ?VALOR3 = 0?
	GOTO UNO ;NO, VE A UNO
	DECFSZ VALOR2 ;SI, ?VALOR2 = 0?
	GOTO DOS ;NO, VE A DOS
	DECFSZ VALOR1 ;SI, ?VALOR1 = 0?
	GOTO TRES ;NO, VE A TRES
EXT RETURN ;SI, SALE
	END