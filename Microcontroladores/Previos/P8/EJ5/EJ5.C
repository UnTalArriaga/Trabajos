#include <16f877.h> //biblioteca del micro
#fuses HS,NOPROTECT, //par�metros f�sicos - el�ctricos del controlador
#use delay(clock=20000000) // 20 MHz establece el reloj a utilizar
#define use_portd_lcd true // establece PORTD como conexi�n del display LCD
#include <lcd.c> // biblioteca para control de display LCD.
// el programa escribe la frase UNAM FI en display LCD
void main() {
lcd_init(); //inicializaci�n del display
   while( TRUE ) {
      lcd_gotoxy(1,1); //posiciona cursor en (1,1) inicio del primero
      printf(lcd_putc," UNAM \n "); //escribe los chars en el LCD
      lcd_gotoxy(1,2); //posiciona cursor en (1,2) inicio del segundo
      printf(lcd_putc," FI \n "); //escribe los chars en el LCD
      delay_ms(300); //retardo de 300ms
   } //end while
}//end main