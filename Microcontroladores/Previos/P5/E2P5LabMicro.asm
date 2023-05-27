processor p16f877      ;Se indica el procesador con el que se 
include <p16f877.inc> ;trabajara
 
valor1 equ h'21'
valor2 equ h'22'
valor3 equ h'23'
cte1 equ 03h   ;50us
cte2 equ 08h  ;250us
cte3 equ 30h  ;0.25s
 
;valores para los retrasos de cada "estado de duraci€n"
contadorq1 equ 0x24
contadorq2 equ 0x25
contador3 equ 0x26
 
            org 0h            ;Se indica el vector de reset
            goto Inicio       ;
 
            org 5h            ;Inicio del programa
Inicio:               ;
            clrf PORTA        ;Se limpia la informacion de los puertos A
            bsf STATUS,RP0    ;Cambio al Banco 1
            bcf STATUS,RP1    ;
            movlw h'0'        ;Se carga W con 00
            movwf TRISB       ;Configura Puerto B como salida
            clrf PORTB        ;Limpia los bits de Puerto B
 
            movlw 0x06         ;Configura los puertos A como digitales
            movwf ADCON1
            movlw 0x3f         ;Configura el Puerto A como entrada
            movwf TRISA
            bcf STATUS,RP0    ;Regresa al Banco 0
 
Ciclo:
            movfw PORTA
            xorlw 0X00        ;Revisamos si se solicita el estado 0 (Motores parados)
            btfsc STATUS,Z
            goto q0
 
            movfw PORTA
            xorlw 0X01        ;Revisamos si se solicita el estado 1 (5 segundos horario)
            btfsc STATUS,Z
            goto q1_1
            
            movfw PORTA
            xorlw 0X02        ;Revisamos si se solicita el estado 2 (10 anti-horario)
            btfsc STATUS,Z
            goto q2_2
 
            movfw PORTA
            xorlw 0X03        ;Revisamos si se solicita el estado 3 (5 vueltas horario)
            btfsc STATUS,Z
            goto q3_3
 
            movfw PORTA
            xorlw 0X04        ;Revisamos si se solicita el estado 3 (5 vueltas anti horario)
            btfsc STATUS,Z
            goto q4_4
 
q0: ;Estado q0: Motor en paro
            clrf PORTB        ;Se limpian los puertos B
            movfw PORTA
            xorlw 0x00
            btfsc STATUS,Z
            goto Ciclo
            goto q0
 
q1_1:
            movlw 0x02
            movwf contador3
            goto q1
 
q1: ;Estado q1: Gira en sentido horario durante 5 segundos
            movlw 0xff        ;(5 segundos)
            movwf contadorq1
            goto Ciclo_horario
 
Ciclo_horario:
            movfw PORTA
            xorlw 0x00
            btfsc STATUS,Z
            goto q0
 
            call retardo
            movlw b'10000000'
            movwf PORTB
            
            call retardo
            movlw b'01000000'
            movwf PORTB
            
            call retardo
            movlw b'00100000'
            movwf PORTB
            
            call retardo
            movlw b'00010000'
            movwf PORTB
 
            decf contadorq1
            btfss STATUS,Z
            goto Ciclo_horario
            decf contador3
            btfss STATUS,Z
            goto Ciclo_horario
            goto q0
 
q2_2:
            movlw 0x03
            movwf contador3
            goto q2
 
q2: ;Estado q2: Gira en sentido anti horario por 10 segundos
            movlw 0xff          ;(10 segundos)
            movwf contadorq2
            goto Ciclo_antihorario
 
Ciclo_antihorario:
            movfw PORTA
            xorlw 0x00
            btfsc STATUS,Z
            goto q0
 
            call retardo
            movlw b'00010000'
            movwf PORTB
            call retardo
 
            movlw b'00100000'
            movwf PORTB
            call retardo
 
            movlw b'01000000'
            movwf PORTB
            call retardo
 
            movlw b'10000000'
            movwf PORTB
 
            decf contadorq2
            btfss STATUS,Z
            goto Ciclo_antihorario;
            decf contador3
            btfss STATUS,Z
            goto Ciclo_antihorario;
            goto q0
 
q3_3:
            movlw 0x0A
            movwf contador3
            goto q3
 
q3: ;Estado q3: Gira cinco vueltas en sentido horario
            movlw 0xff           ;Repetir el patr€n 5 veces
            movwf contadorq1
            goto Ciclo_horario
 
q4_4:
            movlw 0x14
            movwf contador3
            goto q4
 
q4: ;Estado q4: Gira 10 vueltas en sentido anti horario
            movlw 0x0b           ;Repetir el patr€n 10 veces
            movwf contadorq2
            goto Ciclo_antihorario
 
retardo:
            movlw cte1
            movwf valor1
tres:
            movwf cte2
            movwf valor2
dos: 
            movlw cte3
            movwf valor3
uno: 
            decfsz valor3
            goto uno          ;3N+1
            decfsz valor2
            goto dos          ;(3N+1)M+3M+1
            decfsz valor1
            goto tres         ;[(3N+1)M+3M+1]P+3P+1
            return
 
            end               ;Fin del programa
