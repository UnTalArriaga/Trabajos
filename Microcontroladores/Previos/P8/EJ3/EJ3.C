#include <16f877.h> //biblioteca del micro
#fuses HS,NOPROTECT, //parámetros físicos - eléctricos del controlador
#use delay(clock=20000000) // 20 MHz establece el reloj a utilizar
// reserva la memoria donde esta el bootloader
#org 0x1F00, 0x1FFF void loader16F877(void) {}

int var1; // variable global

// el programa asigna la entrada PORTA a la salida PORTB
void main(){
   while(1){
      var1=input_a(); //lee la entrada del puerto A y almacena en var1
      output_b(var1); //asigna var1 a salida del puerto B
   }//while
}//main

