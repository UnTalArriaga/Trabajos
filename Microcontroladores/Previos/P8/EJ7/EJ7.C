#include <16F877.h> //biblioteca del micro
#fuses HS,NOWDT,NOPROTECT,NOLVP //parametros físicos-eléctricos controlador
#use delay(clock=20000000) // 20 MHz establece el reloj a utilizar
#define use_portd_lcd true // establece PORTD como conexión del display LCD
#include <lcd.c> //biblioteca para control de display LCD.

// Variables globales
int conteo; // lleva la cuenta de veces que se activa señal
int dato; // lectura de señal
int ante; // señal anterior (no contar varias veces una misma activación)

// el programa escribe la cuenta de activaciones en decimal y hexadecimal
// en el display LCD.
void main() {
   lcd_init(); //inicialización del display
   conteo=0;
   while( TRUE ) {
      ante=dato;
      dato=input_state(PIN_A0);
      if(dato==1 && dato!=ante){ // detecta solo cambio por subida
         conteo++;
      }
      lcd_gotoxy(5,1); //posiciona cursor en (5,1) inicio del primero
      printf(lcd_putc," %d\n", conteo); //escribe los chars en el LCD
      lcd_gotoxy(5,2); //posiciona cursor en (5,2) inicio del segundo
      printf(lcd_putc," %x\n", conteo); //escribe los chars en el LCD
      delay_ms(100); //retardo de 300ms
   } //end while
}//end main

