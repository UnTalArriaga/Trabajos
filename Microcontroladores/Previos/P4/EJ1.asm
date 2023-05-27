processor 16f877A
include <p16f877a.inc>
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
	
	MOVF PORTA,W ; se usan las entradas de A
	ADDWF PCL,F ; se le suma al contador la entrada
	GOTO CERO
	GOTO UNO
CERO:
	CLRF PORTB
	GOTO CICLO
UNO:
	MOVLW 0xFF
	MOVWF PORTB
	GOTO CICLO ; regresa a checar entrada selección
	
END