processor 16f877A
include <p16f877a.inc>
	valor1 equ h'21'
	valor2 equ h'22'
	valor3 equ h'23'
	cte1 equ 0x80
	cte2 equ 50h
	cte3 equ 60h
	vueltas5 equ h'24'
	vueltas10 equ h'25'
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	CLRF PORTA ; Limpia PORTA
	BSF STATUS,RP0 ; Cambia a banco 1
	BCF STATUS,RP1
	MOVLW 06H ; Define puertos A y E como digitales
	MOVWF ADCON1
	MOVLW H'3F' ; Configura puerto A como entrada
	MOVWF TRISA
	MOVLW H'00' ; configura puerto B como salida
	MOVWF TRISB
	BCF STATUS,RP0 ; Cambia al banco 0
	CLRF PORTB
CICLO:
	MOVF PORTA,W	;W<- PORTA
	ANDLW B'00000111' ;W<- PORTA && 00000111
	ADDWF PCL,F ;(PCL) <-- (PORTA) AND 0X0F
	GOTO CERO
	GOTO UNO
	GOTO DOS
	GOTO TRES
	GOTO CUATRO
	GOTO CERO
	GOTO CERO
	GOTO CERO
CERO: ; motor parado, limpia salida
	CLRF PORTB
	GOTO CICLO
UNO: ; motor gira horario, una vuelta y checa
	MOVLW B'10000000'
	MOVWF PORTB
	BCF STATUS,C
UNO_REP: ; hace 4 pasos para dar una vuelta al motor
	CALL RETARDO
	RRF PORTB,F ; corrimiento derecha
	BTFSS STATUS,C ; checa si se llego al limite
	GOTO UNO_REP ; repite
	GOTO CICLO
DOS: ; motor gira antihorario, una vuelta y
	MOVLW B'00010000' ; vuelve a checar
	MOVWF PORTB
	BCF STATUS,C
DOS_REP: ; hace 4 pasos para dar una vuelta al motor
	CALL RETARDO
	RLF PORTB,F ; corrimiento izquierda
	BTFSS PORTB,4 ; checa si se llego al limite
	GOTO DOS_REP ; repite
	GOTO CICLO
TRES: ; 5 vueltas en sentido horario
	MOVLW 0x05 ; se carga el contador con 5
	MOVWF vueltas5
TRES_ITER: ; una iteración para cada una de las
	MOVLW B'10000000' ; cinco vueltas
	MOVWF PORTB
	BCF STATUS,C
TRES_VUELTA: ; hace 4 pasos por vuelta
	CALL RETARDO
	RRF PORTB,F ; corrimiento derecha
	BTFSS STATUS,C ; checa si se llego al limite
	GOTO TRES_VUELTA
	DECFSZ vueltas5 ; checa si ya se hicieron 5 vueltas
	GOTO TRES_ITER
	GOTO CICLO
CUATRO: ; 10 vueltas en sentido antihorario
	MOVLW 0x0A ; contador se inicia en 10
	MOVWF vueltas10
CUATRO_ITER: ; una iteración por vuelta completa
	MOVLW B'00010000'
	MOVWF PORTB
	BCF STATUS,C
CUATRO_VUELTA:
	CALL RETARDO
	RLF PORTB,F ; corrimiento izquierda
	BTFSS PORTB,4 ; checa limite
	GOTO CUATRO_VUELTA
	DECFSZ vueltas10 ; checa si se dieron las 10 vueltas
	GOTO CUATRO_ITER
	GOTO CICLO
RETARDO ; subrutina de retardo
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