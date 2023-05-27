processor 16f877A
include <p16f877a.inc>
valor1 equ h'21'
valor2 equ h'22'
valor3 equ h'23'
cte1 equ 0x80
cte2 equ 50h
cte3 equ 60h
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
	goto CERO ; lo que nos lleva a una función.
	goto UNO
	goto DOS
	goto TRES
	goto CUATRO
	goto CINCO
	goto CERO ;Se repite para evitar que se salte a otra instrucción
	goto CERO ; y realice otro cosa que no queremos
CERO: ; todos apagados
	CLRF PORTB
	goto CICLO ; regresa a checar entrada selección
UNO: ; todos encendidos
	MOVLW 0xFF
	MOVWF PORTB
	goto CICLO ; regresa a checar entrada selección
DOS: ; corrimiento derecha
	BCF STATUS,C ; Limpia carry
	MOVLW 0x80 ; W <- 0x80
	MOVWF PORTB
	CALL retardo
DOS_CERO:
	BTFSC PORTB,0 ; checa bit 0
	GOTO CICLO ; regresa a checar entrada selección
	RRF PORTB,1
	CALL retardo
	goto DOS_CERO
TRES: ; corrimiento izquierda
	BCF STATUS,C ; Limpia carry
	MOVLW 0x01 ; W <- 0x01
	MOVWF PORTB
	CALL retardo
TRES_CERO:
	BTFSC PORTB,7 ; checa bit 7
	GOTO CICLO ; regresa a checar entrada selección
	RLF PORTB,1
	CALL retardo
	goto TRES_CERO
CUATRO: ; corrimiento derecha-izquierda
	BCF STATUS,C ; Limpia carry
	MOVLW 0x80 ; W <- 0x01
	MOVWF PORTB
	CALL retardo
CUATRO_CERO: ; derecha
	BTFSC PORTB,0 ; checa bit 0
	GOTO CUATRO_REG ; cambia corrimiento
	RRF PORTB,1
	CALL retardo
	goto CUATRO_CERO
CUATRO_REG: ; izquierda
	BTFSC PORTB,7 ; checa bit 7
	GOTO CICLO ; regresa a checar entrada selección
	RLF PORTB,1
	CALL retardo
	goto CUATRO_REG
CINCO: ; apagado-encendido
	CLRF PORTB ; apagado
	call retardo
	MOVLW 0xFF
	MOVWF PORTB ; encendido
	call retardo
	goto CICLO ; regresa a checar entrada selección
retardo ; subrutina de retardo
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