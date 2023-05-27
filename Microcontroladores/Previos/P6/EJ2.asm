processor 16f877A
#include <p16f877a.inc>
	valor1 equ h'21'
	valor2 equ h'22'
	valor3 equ h'23'
	cte1 equ .002
	cte2 equ .200
	cte3 equ .82
	ORG 0
	GOTO INICIO
	ORG 5
INICIO:
	CLRF PORTE ; Limpia PORTE
	BSF STATUS,RP0 ; Cambia a banco 1
	MOVLW 00H ; Define puertos A como analógico
	MOVWF ADCON1
	CLRF TRISD ; Limpia TRISD para que sea salidas
	BCF STATUS,RP0 ; Cambia al banco 0
	MOVLW B'11111001' 	; Cargamos 11xxxxxx freq,xx111xxx canales, xxxxx00x estado conversion go/done,
						; xxxxxxx1 prender convertidor
	MOVWF ADCON0
CICLO:
	BSF ADCON0,GO ; inicia conversión A/D
	CALL RETARDO_20US ; espera un retardo
ESPERA:
	BTFSC ADCON0,GO ; checa si acabó (vale 0)
	GOTO ESPERA ; se queda en ciclo esperando}
	MOVF ADRESH,W ; lee el resultado
	MOVLW B'00110011' ; 51
	SUBWF ADRESH,W ; W = ADRESH - 51
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CERO ; es negativo, entonces es cero
	MOVLW B'01100111' ; 103
	SUBWF ADRESH,W ; W = ADRESH - 103
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO UNO ; es negativo, entonces es uno
	MOVLW B'10011011' ; 155
	SUBWF ADRESH,W ; W = ADRESH - 155
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO DOS ; es negativo, entonces es dos
	MOVLW B'11001111' ; 207
	SUBWF ADRESH,W ; W = ADRESH - 207
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO TRES ; es negativo, entonces es tres
	MOVLW B'11111001' ; 249
	SUBWF ADRESH,W ; W = ADRESH - 249
	BTFSS STATUS,C ; si es positivo siguiente comparacion
	GOTO CUATRO ; es negativo, entonces es cuatro
	GOTO CINCO
CERO:
	MOVLW B'00000000' ; W = valor de salida = 0
	GOTO CARGA
UNO:
	MOVLW B'00000001' ; W = valor de salida = 1
	GOTO CARGA
DOS:
	MOVLW B'00000010' ; W = valor de salida = 2
	GOTO CARGA
TRES:
	MOVLW B'00000011' ; W = valor de salida = 3
	GOTO CARGA
CUATRO:
	MOVLW B'00000100' ; W = valor de salida = 4
	GOTO CARGA
CINCO:
	MOVLW B'00000101' ; W = valor de salida = 5
	GOTO CARGA
CARGA:
	MOVWF PORTD ; se carga la salida del programa
	GOTO CICLO
; 0 - 51 = 0 --> '00110011'
; 52 - 103 = 1 --> '01100111'
; 104 - 155 = 2 --> '10011011'
; 156 - 207 = 3 --> '11001111'
; 208 - 249 = 4 --> '11111001'
; 250 - 255 = 5 --> '11111111'
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