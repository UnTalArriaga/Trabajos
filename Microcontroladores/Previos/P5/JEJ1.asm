processor 16f877 
include <p16f877.inc>
	VALOR1 equ h'21' 
	VALOR2 equ h'22' 
	VALOR3 equ h'23' 
	CTE1 equ 20h 
	CTE2 equ 20h 
	CTE3 equ 20h
	ORG 0
	GOTO INICIO
	ORG 5
;Configura a B como entrada y lo pone en cero 
INICIO:	
	CLRF PORTA	;limpia port A
	BSF STATUS,RP0
	BCF STATUS,RP1	;cambiamos de banco de memoria
	MOVLW 06H	;definimos puertos A y E como digitales 
	MOVWF ADCON1
	MOVLW 0X3F
	MOVWF TRISA	;se configura todo A como entrada
	CLRF TRISB	;se configura B como	salida
	BCF STATUS,RP0	;cambiar al banco 0		
	CLRF PORTB	;limpiar las salidas	de B
main:
	MOVF PORTA,0	;W<- PORTA
	ANDLW B'00001111' ;W<- PORTA && 00000111
	ADDWF PCL,F	;PCL<- PORTA && 00000111
	GOTO ACCION0	;PCL + 0
	GOTO ACCION1	;PCL + 1
	GOTO ACCION2	;PCL + 2
	GOTO ACCION3	;PCL + 3
	GOTO ACCION4	;PCL + 4
	GOTO ACCION5	;PCL + 5
	GOTO ACCION6	;PCL + 6
	GOTO ACCION7	;PCL + 7
	GOTO ACCION8	;PCL + 8
	GOTO main	;PCL + 9
	GOTO main	;PCL + 10
	GOTO main	;PCL + 11
	GOTO main	;PCL + 12
	GOTO main	;PCL + 13
	GOTO main	;PCL + 14
	GOTO main	;PCL + 15
ACCION0: 
	CLRF PORTB	;limpia todas las salidas 
	GOTO main
ACCION1:
	MOVLW 0X30	;mueve el valor 0x30 a portb 
	MOVWF PORTB
	GOTO main
ACCION2:
	MOVLW 0X28	;mueve el valor 0x28 a portb 
	MOVWF PORTB
	GOTO main
ACCION3:
	MOVLW 0X06	;mueve el valor 0x06 a portb 
	MOVWF PORTB
	GOTO main
ACCION4:
	MOVLW 0X05	;mueve el valor 0x05 a portb 
	MOVWF PORTB
	GOTO main
ACCION5:
	MOVLW 0X36	;mueve el valor 0x36 a portb 
	MOVWF PORTB
	GOTO main
ACCION6:
	MOVLW 0X2D	;;mueve el valor 0x2D a portb 
	MOVWF PORTB
	GOTO main
ACCION7:
 	MOVLW 0x35	;;mueve el valor 0x2D a portb 
	MOVWF PORTB
	GOTO main
ACCION8:
	MOVLW 0x2E	;;mueve el valor 0x2D a portb 
	MOVWF PORTB
	GOTO main
retardo:
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