#include <16f877.h> //biblioteca del micro
#fuses HS,NOPROTECT, //parámetros físicos - eléctricos del controlador
#use delay(clock=20000000) // 20 MHz establece el reloj a utilizar
// reserva la memoria donde esta el bootloader
#org 0x1F00, 0x1FFF void loader16F877(void) {}
// El código prende y apaga 8 bits de la salida portb cada segundo.
void main(){
   while(1){
      output_b(0xff); // '11111111' salida para portb
      delay_ms(1000); // retardo de 1s
      output_b(0x00); // '00000000' salida para portb
      delay_ms(1000); // retardo de 1s
   } //while
}//main

