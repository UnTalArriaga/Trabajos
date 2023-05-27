processor 16f877
include<p16f877.inc>
	valor1 equ h'21'
	valor2 equ h'22'
	valor3 equ h'23'
	cte1 equ .002
	cte2 equ .200
	cte3 equ .82
	valor1s equ h'24'
	valor2s equ h'25'
	valor3s equ h'26'
	cte1s equ 250
	cte2s equ .200
	cte3s equ .82
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	CLRF PORTE
	BSF STATUS,RP0 ; Cambiamos al banco 01
	BCF STATUS,RP1 ;
	MOVLW 00H ; Define puertos E como analógico
	MOVWF ADCON1
	BSF TXSTA,BRGH ; prende bit BRGH --> alta velocidad
	MOVLW D'129' ; W = 129, como BRGH = 1 => 129->9600 baudios
	MOVWF SPBRG ; se configura a 9600 baudios
	BCF TXSTA,SYNC ; apagamos bit SYNC --> modo asíncrono
	BSF TXSTA,TXEN ; prende bit TXEN --> habilita transmisión
	BCF STATUS,RP0 ; cambiamos al banco 00
	MOVLW B'11101001' ; Cargamos 11 freq, 101 canales
	MOVWF ADCON0
	BSF RCSTA,SPEN ; prende bit SPEN --> habilita el puerto serie
CICLO:
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL RETARDO_20US
	CALL REGRESO
	BSF ADCON0,GO ; inicia conversión A/D
	CALL RETARDO_20US ; espera un retardo
ESPERA:
	BTFSC ADCON0,GO ; checa si acabó (vale 0)
	GOTO ESPERA ; se queda en ciclo esperando
	MOVF ADRESH,W ; lee el resultado
	MOVLW d'1' ; 1
	SUBWF ADRESH,W ; W = ADRESH - 1
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CERO ; imprime cero
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO ; vuelve a leer
	MOVLW d'2' ; 2
	SUBWF ADRESH,W ; W = ADRESH - 2
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL DOS ; imprime uno
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'3' ; 3
	SUBWF ADRESH,W ; W = ADRESH - 3
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CUATRO ; imprime dos
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'4' ; 4
	SUBWF ADRESH,W ; W = ADRESH - 4
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL SEIS ; imprime tres
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'5' ; 5
	SUBWF ADRESH,W ; W = ADRESH - 5
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL OCHO ; imprime cuatro
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'6' ; 6
	SUBWF ADRESH,W ; W = ADRESH - 6
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL UNO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CERO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'7' ; 7
	SUBWF ADRESH,W ; W = ADRESH - 7
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL UNO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL DOS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'8' ; 8
	SUBWF ADRESH,W ; W = ADRESH - 8
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL UNO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CUATRO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'9' ; 9
	SUBWF ADRESH,W ; W = ADRESH - 9
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL UNO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL SEIS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'10' ; 10
	SUBWF ADRESH,W ; W = ADRESH - 10
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL UNO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL OCHO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'11' ; 11
	SUBWF ADRESH,W ; W = ADRESH - 11
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL DOS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CERO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'12' ; 12
	SUBWF ADRESH,W ; W = ADRESH - 12
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL DOS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL DOS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'13' ; 13
	SUBWF ADRESH,W ; W = ADRESH - 13
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL DOS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CUATRO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'14' ; 14
	SUBWF ADRESH,W ; W = ADRESH - 14
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL DOS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL SEIS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'15' ; 15
	SUBWF ADRESH,W ; W = ADRESH - 15
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL DOS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL OCHO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'16' ; 16
	SUBWF ADRESH,W ; W = ADRESH - 16
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL TRES
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CERO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'17' ; 17
	SUBWF ADRESH,W ; W = ADRESH - 17
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL TRES
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL DOS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'18' ; 18
	SUBWF ADRESH,W ; W = ADRESH - 18
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL TRES
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CUATRO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'19' ; 19
	SUBWF ADRESH,W ; W = ADRESH - 19
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL TRES
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL SEIS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'20' ; 20
	SUBWF ADRESH,W ; W = ADRESH - 20
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL TRES
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL OCHO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'21' ; 21
	SUBWF ADRESH,W ; W = ADRESH - 21
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CUATRO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CERO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'22' ; 22
	SUBWF ADRESH,W ; W = ADRESH - 22
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CUATRO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL DOS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'23' ; 23
	SUBWF ADRESH,W ; W = ADRESH - 23
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CUATRO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CUATRO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'24' ; 24
	SUBWF ADRESH,W ; W = ADRESH - 24
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CUATRO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL SEIS
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	MOVLW d'25' ; 25
	SUBWF ADRESH,W ; W = ADRESH - 25
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL CUATRO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	CALL OCHO
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CICLO
	CALL CINCO
	CALL CERO
	GOTO CICLO
REGRESO
	movlw d'10' ; salto de linea return en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmitereg
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmitereg ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
CERO
	movlw '0' ; carga char 0 en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmite0
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmite0 ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
UNO
	movlw '1' ; carga char 1 en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmite1
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmite1 ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
DOS
	movlw '2' ; carga char 2 en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmite2
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmite2 ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
TRES
	movlw '3' ; carga char 3 en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmite3
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmite3 ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
CUATRO
	movlw '4' ; carga char 4 en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmite4
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmite4 ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
CINCO
	movlw '5' ; carga char 5 en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmite5
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmite5 ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
SEIS
	movlw '6' ; carga char 6 en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmite6
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmite6 ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
SIETE
	movlw '7' ; carga char 7 en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmite7
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmite7 ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
OCHO
	movlw '8' ; carga char 8 en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmite8
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmite8 ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
NUEVE
	movlw '9' ; carga char 9 en W
	movwf TXREG ; carga W en registro transmision
	bsf STATUS,RP0 ; cambiamos al banco 01
transmite9
	btfss TXSTA,TRMT ; espera mientras no termine trans
	goto transmite9 ; espera...
	bcf STATUS,RP0 ; cambiamos al banco 00
	RETURN
RETARDO_20US ; subrutina de retardo
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