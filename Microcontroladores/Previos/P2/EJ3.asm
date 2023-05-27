PROCESSOR 16f877
#INCLUDE <p16f877.inc>
menor equ H'30' ;Nos ayudara a saber el menor valor al terminar el recorrido
inc_auxiliar equ H'31' ;APUNTADOR Nos ayudara a no perder el indice del incremento cuando recorramos consecutivamente
menor_posicion equ H'32' ;APUNTADOR Nos ayudara a saber la posición del menor valor
valor_aux equ H'33' ;Nos ayudara a guardar el valor en el apuntador de aux, para reemplazarlo en la posicion del menor
ORG 0
GOTO INICIO
ORG 5
INICIO: ;Las preparaciones para la primera iteracion
	MOVLW 0x20 ;Se empieza en la localidad 20
	MOVWF inc_auxiliar ;El auxiliar le pasara su valor a FSR, se controlara FSR, pero sirve para tener un valor fijo que incrementar
SIG_ITERACION:
	MOVF inc_auxiliar,0 ;Se mueve el auxiliar a W
	MOVWF FSR ;Se mueve W a FSR. Prepara FSR apuntando a 0x20, el inicio de los valores
	MOVF INDF,0 ;El valor de la localidad FSR se va a W
	MOVWF menor ;W se vuelve el menor, yendose a 0x30. De aqui partimos
	MOVWF valor_aux ;Este no se modificara, solo se guarda el valor para ordenar posteriormente
CHECK:
	INCF FSR ;El apuntador va a la siguiente localidad
	MOVFW FSR ;Se mueve el valor de FSR a W y se checa la localidad actual
	SUBLW 30h ;Se resta 30 a W y se checara si da 0, para confirmar que ya estamos en 30
	BTFSC STATUS,Z ;El valor de Z=0?S
	GOTO ORDENAR ;NO, Ya llegamos a la localidad 30
	MOVF INDF,0 ;SI, Lo que hay en la localidad actual se mueve a W
	SUBWF menor,0 ;RES >= W? (resultado-W)
	BTFSS STATUS,C ;Lo que hay en RES es mayor a W?
	GOTO RES_MENOR ;NO, se va a MENOR
	GOTO RES_MAYOR ;SI, se continúa el proceso
RES_MENOR: ;resultado menor es el valor más pequeño actualmente
	GOTO CHECK
RES_MAYOR: ;Existe un valor menor al resultado menor actual
	MOVF INDF,0 ;El valor donde se encuentra se manda a W
	MOVWF menor ;Se actualiza el menor valor
	MOVF FSR,0 ;Se mueve la posicion a W
	MOVWF menor_posicion ;Se guarda la posicion del menor
	GOTO CHECK
ORDENAR: ;En este proceso se ordenan los valores
	MOVF inc_auxiliar,0 ;El valor de esta localidad manda a un apuntador al inicio de la lista
	MOVWF FSR ;Actualizamos el FSR, para poder manipular esta localidad
	MOVF menor,0 ;El menor se mueve a W para ordenar
	MOVWF INDF ;Se mueve el menor a FSR o inicio de la iteracion actual
	MOVF menor_posicion,0 ;Se guarda en W el valor anterior del menor lugar
	MOVWF FSR ;La posicion de FSR se actualiza al lugar anterior del valor menor
	MOVF valor_aux,0 ;Se manda el valor auxiliar, anterior primer valor, a W
	MOVWF INDF ;Se actualiza la posicion con el valor de W (El primer valor actual de la lista)
	INCF inc_auxiliar ;Ahora empezaremos desde el siguiente valor
	CLRF menor ;Se limpian los valores de los auxiliares, por si acaso
	CLRF valor_aux
	CLRF menor_posicion
	MOVF inc_auxiliar,0 ;Se mueve el valor del auxiliar a W para revisar posicion de localidad
	SUBLW 30h ;Se resta el valor de la localidad final a W
	BTFSS STATUS,Z ;Skip if Z=1, Se salta si la resta da 0, indicando que ya terminamos
	GOTO SIG_ITERACION ;Se repite mientras no se haya llegado al final
TERMINAR:
	SLEEP
	END