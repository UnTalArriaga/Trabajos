processor 16f877
#include <p16f877a.inc>
valor1 equ h'21'
valor2 equ h'22'
valor3 equ h'23'
cte1 equ 0xe0
cte2 equ 50h
cte3 equ 60h
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	BSF STATUS,RP0 ;Nos movemos al banco 01
	BCF STATUS,RP1 ;Para cambiar los TRIS
	MOVLW H'0' ;Se declara B como salidas
	MOVWF TRISB
	BCF STATUS,RP0
	CLRF PORTB ;Se limpia lo que haya en B
loop2
	MOVLW 0x00 ;Movemos 0s a todo PORTB, apagado
	MOVWF PORTB
	CALL retardo ;Retardo de 1 segundo
	MOVLW 0xff ;Movemos 1´s a todo PORTB, encendido
	MOVWF PORTB
	CALL retardo ;Retardo de 1 segundo
	GOTO loop2 ;Se repite todo
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