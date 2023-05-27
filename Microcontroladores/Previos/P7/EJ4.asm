	processor 16f877 ; Indica la versión de procesador
	include<p16f877.inc> ; Incluye la librería del procesador
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	BSF STATUS,RP0 ; Cambiamos al banco 01
	BCF STATUS,RP1 ;
	MOVLW B'00000000' ; configura al puerto B 8 bits salida
	MOVWF TRISB ; carga la configuracion
	BSF TXSTA,BRGH ; prende bit BRGH --> alta velocidad
	MOVLW D'129' ; W=129, como BRGH=1 => 129->9600 baudios
	MOVWF SPBRG ; se configura a 9600 baudios
	BCF TXSTA,SYNC ; apagamos bit SYNC --> modo asíncrono
	BCF STATUS,RP0 ; cambiamos al banco 00
	BSF RCSTA,SPEN ; prende bit SPEN --> habilita el puerto serie
	BSF RCSTA,SREN ; prende bit CREN --> haiblita recepcion
	CLRF PORTB
RECIBE:
	BTFSS PIR1,RCIF ; espera en bucle a que termine recepción
	GOTO RECIBE ; vuelve a esperar
	BCF STATUS,Z
	MOVLW '0'
	SUBWF RCREG,W ; W = RCREG - W = RCREG - 0
	BTFSC STATUS,Z ; checa si la resta fue 0 y char fue 0
	GOTO APAGA ; apaga salida
	BCF STATUS,Z
	MOVLW '1'
	SUBWF RCREG,W ; W = RCREG - W = RCREG - 1
	BTFSC STATUS,Z ; checa si la resta fue 0 y char fue 1
	GOTO PRENDE ; prende salida
	GOTO RECIBE ; se mantiene igual
APAGA:
	BCF STATUS,C ; limpia carry
	MOVLW b'00000000' ;
	MOVWF PORTB ; carga 00000001 en el puerto b
	GOTO RECIBE
PRENDE:
	BCF STATUS,C ; limpia carry
	MOVLW b'00000001' ;
	MOVWF PORTB ; carga 00000001 en el puerto b
	GOTO RECIBE
	END