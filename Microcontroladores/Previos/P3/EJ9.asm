processor 16f877
#include <p16f877a.inc>
valor1 equ h'21'
valor2 equ h'22'
valor3 equ h'23'
cte1 equ 90h
cte2 equ 50h
cte3 equ 60h
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	BSF STATUS,RP0
	BCF STATUS,RP1
	MOVLW H'0'
	MOVWF TRISB
	BCF STATUS,RP0
	CLRF PORTB
EJER:
	BCF STATUS,C ; Limpia carry
	MOVLW 0x80 ; W <- 0x80
	MOVWF PORTB ; ROTA <- (W)
	CALL retardo
ES_CERO:
	BTFSC PORTB,0 ; checa bit 0 de PORTB
	GOTO EJER ; sigue con corrimiento
	RRF PORTB,1
	CALL retardo
	goto ES_CERO
retardo
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