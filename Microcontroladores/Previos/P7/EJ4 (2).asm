	processor 16f877 ; Indica la versión de procesador
	include<p16f877.inc> ; Incluye la librería del procesador
	valor1 equ h'21'
	valor2 equ h'22'
	valor3 equ h'23'
	cte1 equ 50
	cte2 equ .200
	cte3 equ .82
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	BSF STATUS,RP0 ; Cambiamos al banco 01
	BCF STATUS,RP1 ;
	MOVLW B'00000000' ; configura al puerto B como 8 salidas
	MOVWF TRISB ; carga la configuracion
	BSF TXSTA,BRGH ; prende bit BRGH --> alta velocidad
	MOVLW D'129' ; W=129, como BRGH=1 => 129->9600 baudios
	MOVWF SPBRG ; se configura a 9600 baudios
	BCF TXSTA,SYNC ; apagamos bit SYNC --> modo asíncrono
	BCF STATUS,RP0 ; cambiamos al banco 00
	BSF RCSTA,SPEN ; prende bit SPEN --> habilita el puerto serie
	BSF RCSTA,CREN ; prende bit CREN --> haiblita recepcion
RECIBE:
	BTFSS PIR1,RCIF ; espera en bucle a que termine recepción
	GOTO RECIBE ; vuelve a esperar
	BCF STATUS,Z ; limpia bandera zero
	MOVLW '0' ; W <-- 'D'
	SUBWF RCREG,W ; W = RCREG - W = RCREG - D
	BTFSC STATUS,Z ; checa si la resta fue 0 y char fue D
	GOTO DERECHA ; CORRIMIENTO DERECHA
	BCF STATUS,Z ; limpia Z
	MOVLW '0' ; W <-- 'd'
	SUBWF RCREG,W ; W = RCREG - W = RCREG - d
	BTFSC STATUS,Z ; checa si la resta fue 0 y char fue i
	GOTO DERECHA ; CORRIMIENTO DERECHA
	BCF STATUS,Z
	MOVLW '1'
	SUBWF RCREG,W ; W = RCREG - W = RCREG - I
	BTFSC STATUS,Z ; checa si la resta fue 0 y char fue I
	GOTO IZQUIERDA ; CORRIMIENTO IZQUIERDA
	BCF STATUS,Z
	MOVLW '1'
	SUBWF RCREG,W ; W = RCREG - W = RCREG - i
	BTFSC STATUS,Z ; checa si la resta fue 0 y char fue i
	GOTO IZQUIERDA ; CORRIMIENTO IZQUIERDA
	GOTO RECIBE ; va a recibir siguiente char
DERECHA:
	BCF STATUS,C ; limpia carry
	MOVLW b'00000000' ;
	MOVWF PORTB ; carga 10000000 en el puerto b
	GOTO RECIBE ; va a recibir siguiente char
CORRDER:
	CALL RETARDO
	RRF PORTB ; corrimiento derecha
	BTFSS STATUS,C ; checa si se desborda
	GOTO CORRDER ; vuelve a otro corrimiento
	GOTO RECIBE ; va a recibir siguiente char
IZQUIERDA:
	BCF STATUS,C ; limpia carry
	MOVLW b'00000001' ;
	MOVWF PORTB ; carga 00000001 en el puerto b
	GOTO RECIBE ; va a recibir siguiente char
CORRIZQ:
	CALL RETARDO
	RLF PORTB ; corrimiento izquierda
	BTFSS STATUS,C ; checa si se desborda
	GOTO CORRIZQ ; vuelve a otro corrimiento
	GOTO RECIBE ; va a recibir siguiente char
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