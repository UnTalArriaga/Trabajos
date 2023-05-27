processor 16f877A
#include <p16f877a.inc>
	valor1 equ h'21'
	valor2 equ h'22'
	valor3 equ h'23'
	cte1 equ .002
	cte2 equ .200
	cte3 equ .82
	ve1 equ h'24'
	ve2 equ h'25'
	ve3 equ h'26'
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	CLRF PORTE ; Limpia PORTE
	BSF STATUS,RP0 ; Cambia a banco 1
	MOVLW 00H ; Define puertos E como analógico
	MOVWF ADCON1
	CLRF TRISD ; Limpia TRISD para que sea salidas
	BCF STATUS,RP0 ; Cambia al banco 0
CICLO:
	MOVLW B'11101001' ; Cargamos freq, canales, go/done, prender conv
	MOVWF ADCON0
	BSF ADCON0,GO ; inicia conversión A/D canal 5
	CALL RETARDO_20US ; espera un retardo
ESPERA1:
	BTFSC ADCON0,GO ; checa si acabó (vale 0)
	GOTO ESPERA1 ; se queda en ciclo esperando
	MOVF ADRESH,W ; lee el resultado
	MOVWF ve1 ; guarda ve1
	MOVLW B'11110001' ; Cargamos 11 freq, 110 canales, 00 algo, 1 prender conv
	MOVWF ADCON0
	BSF ADCON0,GO ; inicia conversión A/D canal 6
	CALL RETARDO_20US ; espera un retardo
ESPERA2:
	BTFSC ADCON0,GO ; checa si acabó (vale 0)
	GOTO ESPERA2 ; se queda en ciclo esperando
	MOVF ADRESH,W ; lee el resultado
	MOVWF ve2 ; guarda ve2
	MOVLW B'11111001' ; Cargamos freq, canales, go/done, prender conv
	MOVWF ADCON0
	BSF ADCON0,GO ; inicia conversión A/D canal 7
	CALL RETARDO_20US ; espera un retardo
ESPERA3:
	BTFSC ADCON0,GO ; checa si acabó (vale 0)
	GOTO ESPERA3 ; se queda en ciclo esperando
	MOVF ADRESH,W ; lee el resultado
	MOVWF ve3 ; guarda ve3
	MOVF ve3,W ; W = ve3
	BCF STATUS,C
	SUBWF ve2,W ; W = ve2 - ve3
	BTFSS STATUS,C ; si ve2 es mayor C prende
	GOTO VE3MAYOR ; si ve3 es mayor entra aquí (otra comparación)
	MOVF ve2,W ; W = ve2
	BCF STATUS,C
	SUBWF ve1,W ; W = ve1 - ve2
	BTFSS STATUS,C ; si ve1 es mayor C prende
	GOTO RES2 ; si ve2 es mayor va a RES2
	GOTO RES1 ; si ve1 es mayor va a RES1
VE3MAYOR:
	MOVF ve3,W ; W = ve3
	BCF STATUS,C
	SUBWF ve1,W ; W = ve1 - ve3
	BTFSS STATUS,C ; si ve1 es mayor C prende
	GOTO RES3 ; si ve3 es mayor va a RES3
	GOTO RES1 ; si ve1 es mayor va a RES1
RES1:
	MOVLW B'00000111' ; W = 1 mayor = salida 111
	GOTO CARGA
RES2:
	MOVLW B'00000011' ; W = 2 mayor = salida 011
	GOTO CARGA
RES3:
	MOVLW B'00000001' ; W = 3 mayor = salida 001
	GOTO CARGA
CARGA:
	MOVWF PORTD ; carga la salida
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