#include <16f877a.h>                      // Incluir el archivo de encabezado específico para el microcontrolador PIC 16F877A

#fuses HS,NOWDT,NOPROTECT                // Configurar los fusibles del microcontrolador (oscilador de alta velocidad, sin temporizador de vigilancia, sin protección de escritura)

#device ADC=10                           // Configurar el conversor analógico-digital (ADC) para 10 bits

#use delay(clock=20000000)               // Configurar la biblioteca de retraso para un reloj de 20 MHz

#use rs232(baud=57600, xmit=PIN_C6, rcv=PIN_C7)   // Configurar el módulo de comunicación serial RS-232 (57600 baudios, pines de transmisión y recepción)
#use i2c(MASTER, SDA=PIN_C4, SCL=PIN_C3,SLOW, NOFORCE_SW)
#include <i2c_LCD.c>                         // Incluir el archivo de la biblioteca LCD



void main(){
   unsigned long lecturaCAd_10bits;       // Declarar una variable para almacenar la lectura del ADC de 10 bits
   lcd_init(0x4E,16,2);                           // Inicializar el LCD
   lcd_putc('\f');                       // Limpiar la pantalla del LCD
   setup_port_a(ALL_ANALOG);              // Configurar el Puerto A como entrada analógica
   setup_adc(ADC_CLOCK_INTERNAL);         // Configurar el reloj interno del ADC
   set_adc_channel(0);                    // Configurar el canal del ADC a leer (en este caso, canal 0)
   delay_us(20);                          // Esperar un breve tiempo para estabilizar el ADC
   while(TRUE){
      lecturaCAd_10bits = read_adc();                     // Leer el valor del ADC de 10 bits
      output_d(lecturaCAD_10bits / 4);                    // Enviar los 8 bits superiores del valor del ADC al Puerto B
      lcd_gotoxy(1,1);                                    // Posicionar el cursor del LCD en la primera línea, primera columna
      lcd_putc("Voltaje: ");                               // Mostrar el texto "Voltaje: "
      lcd_gotoxy(1,2);                                    // Posicionar el cursor del LCD en la segunda línea, primera columna
      printf(lcd_putc, "Vin: %4.2f mV", 4.88758 * lecturaCAD_10bits);  // Mostrar el voltaje calculado en milivoltios
      printf("\n\rCAD(10 bits): Decimal=%04Lu, Hexadecimal=0X%LX; PORTB=0X%LX (8 bits)",
      lecturaCAD_10bits,lecturaCAD_10bits,lecturaCAD_10bits/4);  // Mostrar información sobre el valor del ADC y el Puerto B en la consola
      delay_ms(500);                                       // Esperar medio segundo
   }
}
