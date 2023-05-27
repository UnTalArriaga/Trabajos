#include <16f877.h> //biblioteca del micro
#fuses HS,NOPROTECT, //parámetros físicos - eléctricos del controlador
#use delay(clock=20000000) // 20 MHz establece el reloj a utilizar
// utiliza estándar rs232 con la configuración:
// transmite por portC.6 y recibe por portC.7 con 9600 bauds
#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7)
// reserva la memoria donde esta el bootloader
#org 0x1F00, 0x1FFF void loader16F877(void) {}
char dato; // variable globar tipo caracter 8 bits

void correrDerecha(){ // corrimiento derecha
   output_b(0x80);
   delay_ms(500);
   output_b(0x40);
   delay_ms(500);
   output_b(0x20);
   delay_ms(500);
   output_b(0x10);
   delay_ms(500);
   output_b(0x08);
   delay_ms(500);
   output_b(0x04);
   delay_ms(500);
   output_b(0x02);
   delay_ms(500);
   output_b(0x01);
   delay_ms(500);
}
void correrIzquierda(){ // corrimiento izquierda
   output_b(0x01);
   delay_ms(500);
   output_b(0x02);
   delay_ms(500);
   output_b(0x04);
   delay_ms(500);
   output_b(0x08);
   delay_ms(500);
   output_b(0x10);
   delay_ms(500);
   output_b(0x20);
   delay_ms(500);
   output_b(0x40);
   delay_ms(500);
   output_b(0x80);
   delay_ms(500);
}
void correrMixto(){ // corrimiento mixto
   correrDerecha(); // llama corrimiento derecha
   correrIzquierda(); // llama corrimiento izquierda
}
// el programa realiza diversas acciones dependiendo de la entrada
void main(){
   while(1){
   scanf("%c", &dato); // recibe y almacena dato de entrada
   switch(dato) { // evalua el caso y realiza la acción
      case '0':
      output_b(0x00); // todos los bits apagados
      delay_ms(500);
      break;
      case '1':
      output_b(0xff); // todos los bits encendidos
      delay_ms(500);
      break;
      case '2':
      correrDerecha(); // Corrimeinto derecha
      output_b(0x00);
      delay_ms(500);
      break;
      case '3':
      correrIzquierda(); // Corrimiento izquierda
      output_b(0x00);
      delay_ms(500);
      break;
      case '4':
      correrMixto(); // ida y vuelta
      output_b(0x00);
      delay_ms(500);
      break;
      case '5':
      output_b(0xff); // apagar y encender
      delay_ms(500);
      output_b(0x00);
      delay_ms(500);
      break;
      default:
      break;
   }// switch
   }//while
}//main

