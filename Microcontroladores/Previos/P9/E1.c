#include <16F877.h> // biblioteca del microprocesador
#fuses HS,NOWDT,NOPROTECT // conexiones eléctricas
#use delay(clock=20000000) // 20 MHz
#use i2c(MASTER, SDA=PIN_C4, SCL=PIN_C3,SLOW, NOFORCE_SW) // configuración comunicación síncrona I2C
int contador=0; // variable contadora para aumenta
// función para escribir por medio de i2c
void escribir_i2c() {
i2c_start(); // inicia comunicación i2c
i2c_write(0x42); // escribe 0x42 = 0100001 0 --> 0100001 = 33 dir, 0 = Escritura
i2c_write(contador); // escribe la variable global contador
i2c_stop(); // finaliza comunicación i2c
}
//el programa es un cronómetro de medio segundo
void main() {
while(true) {
escribir_i2c(); // escribe en consola
delay_ms(500); // retardo de medio segundo
contador++; // aumenta valor de contador
}
}

