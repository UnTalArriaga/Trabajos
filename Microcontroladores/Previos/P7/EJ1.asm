	processor 16f877
	include<p16f877.inc>
	
	ORG 0
	GOTO INICIO
	
	ORG 5
INICIO: 
	BSF STATUS,RP0;Banco 01
	BCF STATUS,RP1
	BSF TXSTA,BRGH;Configura la velocidad de comunicación BRGH=0
	MOVLW D'129'
	MOVWF SPBRG;Baund rate de 2400
	BCF TXSTA,SYNC ;Desactiva comunicación sincrona
	BSF TXSTA,TXEN ;activa transmisión
	BCF STATUS,RP0 ;Banco 00
	BSF RCSTA,SPEN ;habilita puerto serie
	BSF RCSTA,CREN ;activa la recepción continua en modo de comunicación asíncrona
RECIBE: 
	BTFSS PIR1,RCIF ;Verfifica si la recepción fue completa
	GOTO RECIBE
	MOVF RCREG,W ;guarda el mesanje
	MOVWF TXREG ;manda el mensaje a transmisión
	BSF STATUS,RP0 ;cambia a banco 01
TRASMITE:
	BTFSS TXSTA,TRMT ;verifica que se haya terminado de transmitir
	GOTO TRASMITE
	BCF STATUS,RP0 ;cambia a banco 00
	GOTO RECIBE
	END