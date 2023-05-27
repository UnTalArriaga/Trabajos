processor 16f877
#include <p16f877a.inc>
valor1 equ h'21'
valor2 equ h'22'
valor3 equ h'23'
cte1 equ 0xe0
cte2 equ 0xa0
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
loop2
	MOVLW b'01000001' ;Semáforo 1 Verde, Semaforo 2 Rojo
	MOVWF PORTB
	CALL retardo ;Retardo de 2 seg
	MOVLW b'00100001' ;Semáforo 1 Amarillo, Semaforo 2 Rojo
	MOVWF PORTB
	CALL retardo ;Retardo de 2 seg
	MOVLW b'00010100' ;Semáforo 1 Rojo, Semaforo 2 Verde
	MOVWF PORTB
	CALL retardo ;Retardo de 2 seg
	MOVLW b'00010010' ;Semaforo 1 Rojo, Semaforo 2 Amarillo
	MOVWF PORTB
	CALL retardo ;Retardo de 2 seg
	GOTO loop2 ;Se repite
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