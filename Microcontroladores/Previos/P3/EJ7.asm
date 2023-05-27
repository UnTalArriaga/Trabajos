processor 16f877		;Indica la versi[on del procesador
include <p16f877.inc>	;Incluye biblioteca de la version del procesador
						;Se crean 3 variables y 3 constantes
valor1 equ h'21' 	
valor2 equ h'22'
valor3 equ h'23'
cte1 equ 80h
cte2 equ 50h
cte3 equ 60h
	ORG 0				;Especifica el origen
	GOTO INICIO			;Manda al inicio del programa
	ORG 5				;Especifica el origen del programa
INICIO:					;etiqueta de inicio
	BSF STATUS,RP0		;Coloca en 1 al bit RP0 del registro STATUS
	BCF STATUS,RP1		;Coloca en 0 al bit RP1 del registro STATUS
						;banco 01
	MOVLW H'0'			;Carga 0 al registro W
	MOVWF TRISB			;Convierte el puerto B en pura salida, pasa el valor de W a los 8 bits del puerto B
	BCF STATUS,RP0		;Coloca en 0 al bit RP0 del registro STATUS
						;banco 00
	CLRF PORTB			;Limpia los datos del puerto B
loop2
	BSF PORTB,0			;Vuelve el bit 0 en entrada 
	CALL retardo		;va a retardo
	BCF PORTB,0			;Regresa el bit 0 a salida
	CALL retardo 		;va a retardo
	GOTO loop2			;se repite el loop
retardo
	MOVLW cte1			;Carga a w la direccion de cte1
	MOVWF valor1		;carga a valor1 el de w
tres
	MOVLW cte2			;Carga a w la direccion de cte3
	MOVWF valor2		;carga a valor2 el de w
dos
	MOVLW cte3			;Carga a w la direccion de cte3
	MOVWF valor3		;carga a valor2 el de w
uno
	DECFSZ valor3		;Deciendo en 1 el valor de valor3
 	GOTO uno			;regresa a la etiqueta uno
	DECFSZ valor2		;Deciendo en 1 el valor de valor2
	GOTO dos			;regresa a la etiqueta dos
	DECFSZ valor1		;Deciendo en 1 el valor de valor1
	GOTO tres			;regresa a la etiqueta tres
	RETURN				;retorna al ultimo llamado
	END