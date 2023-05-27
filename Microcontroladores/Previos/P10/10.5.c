//Se importa la biblioteca del PIC16F877
#include <16F877.h>
//Se configuran los fusibles
// -HS -> configuración  del oscilador la cual indica High speed es decir
//        frecuencias altas esto es a partir de 8 Mhz.
// -NOWDT -> Se deshabilita el Watch Dog Timer.
// -NOPROTECT -> Se deshabilita la proteccion de memoria en el programa.
#fuses HS,NOWDT,NOPROTECT
//Se indica el cristal con el que se trabajará, en este caso con aquel que tiene una frecuencia de 20 MHz
#use delay(clock=20000000)
//Se configura el modo maestro
// -MAESTRO
// -SDA        : Se configura el puerto C4 como linea de datos bidireccional
// -SCL        : Se configura el puerto C3 como linea de sincronizacion o señal de reloj
// -SLOW       : Se indica que trabaje a una velocidad baja
// -NOFORCE_SW : No se forza software, sino hardware
#use i2c(MASTER, SDA=PIN_C4, SCL=PIN_C3,SLOW, NOFORCE_SW)
#include "i2c_LCD.c"
//Configuracion de la comunicacion asincrona
#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7)

int vecesPresionada = 0, contador = 0, veces, seg,desborde=0;

//Funcion para la comunicacion i2c
void escribir_i2c(int direccion, int valor){
   i2c_start();         //Inicia la comunicacion I2C, enviando el bit S
   i2c_write(direccion);//Se indica la direccion del dispositivo
   i2c_write(valor);    //Se indica el dato que se le pasara a dicha direccion
   i2c_stop();          //Finaliza la comunicacion, envia el bit de paro
}

#int_rtcc
void clock_isr(){
   veces--;          //Se decrementa la variable veces
   SET_RTCC(232);    //Se carga el timer con 238
   if(veces==0){      //Pregunta si VECES ya llego a cero
      seg++;         //Cuando VECES llega a cero incrementa SEG (Transcurrio 1 seg)
      veces=150;//Vuelvo y cargo VECES con el valor 217
      desborde ++;
   }
  // lcd_gotoxy(1,2);                               //Se indica la columna y la fila donde aparecera el mensaje
   //printf(LCD_PUTC, "%d",);//Se imprime en el display de LCD el mensaje leido
   
}

/*Funcion que produce una interrupcion al apretar el boton mostrando las veces que ha 
sido presionado dicho dispositivo*/
#int_EXT
void ext_int(){
   vecesPresionada += 1;
   escribir_i2c(0x42,vecesPresionada);
   
   delay_ms(500);                                 //Se genera un retardo de 500 ms = 0.5 s
}

/*Funcion que produce una interrupcion para mandar un mensaje a terminal
cada que RB7, RB6, RB5 o RB4 tengan algun cambio de bajo a alto*/
#int_RB
void port_rb(){
   if (input_state(PIN_B7)) printf("\r\nCambio en PIN RB7 a ALTO\n");
   if (input_state(PIN_B6)) printf("\r\nCambio en PIN RB6 a ALTO\n");
   if (input_state(PIN_B5)) printf("\r\nCambio en PIN RB5 a ALTO\n");
   if (input_state(PIN_B4)) printf("\r\nCambio en PIN RB4 a ALTO\n");
}

/*Funcion que permite mostrar el contador de 0 a 20 y de 20 a 0 en los display de 7 segmentos*/
void mostrarContador(){
   int decenas = contador/10;
   int unidades = contador%10;
   
   output_d(decenas<<4|unidades);
   delay_ms(250);
}

//Funcion principal
void main() {   
   lcd_init(0x4E,16,2);     //Se inicializa el display con la dirección de escritura
   lcd_gotoxy(1,1);         //Se indica la columna y la fila donde aparecera el mensaje
   printf(LCD_PUTC, "Desbordamiento");
      
   setup_timer_0(RTCC_INTERNAL | RTCC_DIV_256 | RTCC_8_bit);
   ext_int_edge(L_TO_H);
   enable_interrupts(INT_EXT); //Habilita interrupción por TIMER0
   enable_interrupts(GLOBAL);  //Habilita las interrupciones globales
   enable_interrupts(INT_RB);  //Habilita la interrupcion por RB
   enable_interrupts(INT_RTCC);//Habiloita la interrupcion por RTCC
   
   boolean count = false;
   mostrarContador();
   while(true){
      if(seg==4){
         mostrarContador();
         //Se realiza el conteo de 0 a 20 y de 20 a 0 de forma indefinida
         if(contador <= 20 && count == false){
            contador++;
            if(contador == 20) count = true;
         }else if(contador <= 20 && count == true){
            contador--;
            if(contador == 0) count = false;
         }
         seg = 0;
      }
   }
}
