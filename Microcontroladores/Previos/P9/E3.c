#include <16F877.h> // biblioteca del microprocesador
#fuses HS,NOWDT,NOPROTECT // conexiones eléctricas
#use delay(clock=20000000) // 20 MHz
#use i2c(MASTER, SDA=PIN_C4, SCL=PIN_C3,SLOW, NOFORCE_SW) // configuración comunicación síncrona I2C
#include <i2c_LCD.c> // biblioteca para control de display LCD.
int contador=0; // variable contadora para aumenta
// función para escribir por medio de i2c
void escribir_i2c() {
i2c_start(); // inicia comunicación i2c
i2c_write(0x42); //escribe 0x42=0100001 0 --> 0100001=33 dir, 0=Escritura
i2c_write(contador); // escribe la variable global contador
i2c_stop(); // finaliza comunicación i2c
}
// función para escribir a través de puerto paralelo
void escribir_puerto() {
output_d(contador);
}
// función para escribir en el display lcd
void escribir_lcd() {
lcd_gotoxy(11,2); //posiciona cursor en (11,2)
printf(lcd_putc, "%d", contador);
}
//el programa es un cronometro de medio segundo
void main() {
lcd_init(78,16,2); // inicialización display lcd --> dir = 0100111 = 39
lcd_gotoxy(1,1); // posiciona cursor en 1,1
printf(lcd_putc,"UNAM\n"); //escribe en display
lcd_gotoxy(1,2); // posiciona cursor en 1,2
printf(lcd_putc,"Contador="); // escribe en display
while(true) {
escribir_i2c(); // escribe en consola
escribir_puerto(); // escribe por puerto d
escribir_lcd(); // escribe en el lcd
delay_ms(500); // retardo de medio segundo
contador++; // aumenta valor de contador
}
}

