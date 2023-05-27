#include <16F877.h> // biblioteca del microprocesador
#fuses HS,NOWDT,NOPROTECT // conexiones el�ctricas
#use delay(clock=20000000) // 20 MHz
#use i2c(MASTER, SDA=PIN_C4, SCL=PIN_C3,SLOW, NOFORCE_SW) // configuraci�n comunicaci�n s�ncrona I2C
#include <i2c_LCD.c> // biblioteca para control de display LCD.
int contador=0; // variable contadora para aumenta
// funcion para escribir por medio de i2c
void escribir_i2c() {
i2c_start(); // inicia comunicaci�n i2c
i2c_write(0x45); //escribe 0x42=01000010 --> 0100001=33 dir, 0 = Escritura
contador = i2c_read(); // escribe la variable global contador
i2c_stop(); // finaliza comunicaci�n i2c
}
// funcion para escribir a trav�s de puerto paralelo
void escribir_puerto() {
output_d(contador);
}
// funci�n para escribir en el display lcd
void escribir_lcd() {
lcd_gotoxy(11,2); //posiciona cursor en (11,2)
printf(lcd_putc, "%x", contador);
}
// funci�n para leer de dispositivo i2c
void leer_i2c() {
i2c_start(); // inicia comunicaci�n i2c
i2c_write(0x41); // excribe 0x41 = 0100000 1 --> 0100000 = 32, 1 = Lectura
contador = i2c_read(0);
i2c_stop(); // finaliza comunicaci�n I2C
}
//el programa es un cronometro de medio segundo
void main() {
lcd_init(78,16,2); // inicializaci�n display lcd --> dir = 0100111 = 39
lcd_gotoxy(1,1); // posiciona cursor en 1,1
printf(lcd_putc,"UNAM\n"); //escribe en display
lcd_gotoxy(1,2); // posiciona cursor en 1,2
printf(lcd_putc,"Contador= "); // escribe en display
while(true) {
leer_i2c(); // lee valor
escribir_i2c(); // escribe en consola
escribir_puerto(); // escribe por puerto b
escribir_lcd();
delay_ms(500); // retardo de medio segundo
}
}
