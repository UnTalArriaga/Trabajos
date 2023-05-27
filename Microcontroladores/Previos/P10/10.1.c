#include <16F877.h>                 // Incluir el archivo de encabezado específico para el microcontrolador PIC 16F877

#fuses HS,NOWDT,NOPROTECT           // Configurar los fusibles del microcontrolador

#use delay(clock=20000000)          // Configurar la biblioteca de retraso para un reloj de 20 MHz

#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7)    // Configurar el módulo de comunicación serial RS-232

int contador=0;                       // Declarar la variable "contador" de tipo entero

#int_EXT                            // Indicar que la siguiente función es la rutina de interrupción externa
ext_int()
{
   contador++;                      // Incrementar el valor de "contador" en 1
   output_d(contador);              // Enviar el valor actualizado de "contador" al puerto de salida D
}

void main() {
   ext_int_edge(L_TO_H);             // Configurar la interrupción externa para que se active en el cambio de bajo a alto del pin
   enable_interrupts(INT_EXT);       // Habilitar la interrupción externa
   enable_interrupts(GLOBAL);        // Habilitar todas las interrupciones globales
   output_d(0x00);                   // Establecer el valor inicial del puerto de salida D en 0x00
   while( TRUE ) {}                  // Bucle infinito para mantener el programa en ejecución continua
}
