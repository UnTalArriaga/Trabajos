#include <16f877.h> //biblioteca del micro
#fuses HS,NOPROTECT, //parámetros físicos - eléctricos del controlador
#use delay(clock=20000000) // 20 MHz establece el reloj a utilizar
//utiliza estándar rs232 con la configuración:
//transmite por portC.6 y recibe por portC.7 con 9600 bauds
#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7)
// reserva la memoria donde esta el bootloader
#org 0x1F00, 0x1FFF void loader16F877(void) {}
// el programa controla 8 bits de salida e imprime en terminal mensaje
void main(){
   while(1){
      output_b(0xff); // salida llena de 8 bits
      printf(" Todos los bits encendidos \n\r"); //imprime en consola
      delay_ms(1000); // retardo 1s
      output_b(0x00); // salida limpia de 8 bits
      printf(" Todos los leds apagados \n\r"); //imprime en consola
      delay_ms(1000); // retardo 1s
   }//while
}//main
