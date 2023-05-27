processor 16f877A
#include <p16f877a.inc>
	valor1 equ h'21'
	valor2 equ h'22'
	valor3 equ h'23'
	cte1 equ .002
	cte2 equ .200
	cte3 equ .82
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	CLRF PORTE ; Limpia PORTE
	BSF STATUS,RP0 ; Cambia a banco 1
	MOVLW 00H ; Define puertos A como analógico
	MOVWF ADCON1
	CLRF TRISD ; Limpia TRISD para que sea salidas
	BCF STATUS,RP0 ; Cambia al banco 0
	MOVLW B'11111001' 	; Cargamos 11xxxxxx freq,xx111xxx canales, xxxxx00x estado conversion go/done,
						; xxxxxxx1 prender convertidor
	MOVWF ADCON0
CICLO:
	BSF ADCON0,GO ; inicia conversión A/D
	CALL RETARDO_20US ; espera un retardo
ESPERA:
	BTFSC ADCON0,GO ; checa si acabó (vale 0)
	GOTO ESPERA ; se queda en ciclo esperando}
	MOVF ADRESH,W ; lee el resultado
	MOVLW B'00000000' ; 0
	SUBWF ADRESH,W ; W = ADRESH - 0
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CERO ; es negativo, entonces es cero
	MOVLW B'00100000' ; 
	SUBWF ADRESH,W ; W = ADRESH - 32
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO UNO ; es negativo, entonces es uno
	MOVLW B'01000000' ; 
	SUBWF ADRESH,W ; W = ADRESH - 64
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO DOS ; es negativo, entonces es dos
	MOVLW B'01100000' ; 
	SUBWF ADRESH,W ; W = ADRESH - 96
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO TRES ; es negativo, entonces es tres
	MOVLW B'10000000' ; 
	SUBWF ADRESH,W ; W = ADRESH - 128
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CUATRO ; es negativo, entonces es cuatro
	MOVLW B'10100000' ; 
	SUBWF ADRESH,W ; W = ADRESH - 160
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CINCO
	MOVLW B'11000000' ; 
	SUBWF ADRESH,W ; W = ADRESH - 192
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO SEIS 
	MOVLW B'11100000' ; 
	SUBWF ADRESH,W ; W = ADRESH - 224
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO SIETE
	MOVLW B'11111111' ; 
	SUBWF ADRESH,W ; W = ADRESH - 255
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO OCHO
CERO:;num de led encendido 
	MOVLW B'00000000' ; W = valor de salida = 0
	GOTO CARGA
UNO:
	MOVLW B'00000001' ; W = valor de salida = 1
	GOTO CARGA
DOS:
	MOVLW B'00000010' ; W = valor de salida = 2
	GOTO CARGA
TRES:
	MOVLW B'00000100' ; W = valor de salida = 3
	GOTO CARGA
CUATRO:
	MOVLW B'00001000' ; W = valor de salida = 4
	GOTO CARGA
CINCO:
	MOVLW B'00010000' ; W = valor de salida = 5
	GOTO CARGA
SEIS:
	MOVLW B'00100000' ; W = valor de salida = 6
	GOTO CARGA
SIETE:
	MOVLW B'01000000' ; W = valor de salida = 7
	GOTO CARGA
OCHO:
	MOVLW B'10000000' ; W = valor de salida = 8
	GOTO CARGA
CARGA:
	MOVWF PORTD ; se carga la salida del programa
	GOTO CICLO
RETARDO_20US ; subrutina de retardo
	MOVLW cte1
	MOVWF valor1
tres
	MOVLW cte2
	MOVWF valor2
dos
	MOVLW cte3
	MOVWF valor3
uno
	DECFSZ valor3
	GOTO uno
	DECFSZ valor2
	GOTO dos
	DECFSZ valor1
	GOTO tres
	RETURN
END