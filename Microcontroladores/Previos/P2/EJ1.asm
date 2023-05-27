PROCESSOR 16f877			;Indica la versión del procesador
INCLUDE <p16f877.inc> 		;Incluye la biblioteca de la versión del procesador
ORG 0						;Especifica el origen
GOTO INICIO					;Manda al inicio del programa
ORG 5						;Especifica el origen del programa
INICIO: 
	BCF STATUS, RP1			;Coloca en 0 al bit RP1 del registro STATUS
	BSF STATUS, RP0			;Coloca en 1 al bit RP0 del registro STATUS
							;Selección del banco 01
	MOVLW 0x20				;Carga 0x20 al registro W
	MOVWF FSR				;Mueve el contenido de W al registro FSR (FSR=0x20)
LOOP: 
	MOVLW 0x5F				;Inicia el loop y carga a W 0x5F
	MOVWF INDF				;Retorna el valor que apunta FSR
	INCF FSR				;Incrementa al registro FSR (FSR=0x21)
	BTFSS FSR,4				;Verifica si el bit 6 de FRS sea 1 (FRS=0x40)
	GOTO LOOP				;Repite el loop
	GOTO $					;Se queda ejecutando esta operación
	END						;Fin del programa
