#include<16F877.h>
#define use_portd_lcd true //Puerto B para LCD
#define LCD_DATA_PORT getenv("SFR:PORTF")
#fuses HS,NOWDT,NOPROTECT

//Directivas ADC
#device ADC=8 //8 bits de resolucion
#use delay(clock=20000000)

#use i2c(MASTER,SDA=PIN_C4,SCL=PIN_C3,SLOW,NOFORCE_SW)
//#define use_portd true

#org 0x1F00, 0x1FFF void loader16F877(void){}
#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7)//Configuracion Serie

#include <i2c_LCD.c>

long convert;  //Conversion A/D
float res;  //Resultado de Volts
long cont=0;

float volts(long conv);
#int_rtcc//interrupcion TIMER0
 
 void clock_isr(){
   if(cont==763){ //impresiones cada 10 seg
      convert=read_adc(); //obtener el resultado
      res=volts(convert); 
      
      printf("Dec= %04ld\n\r",convert);
      printf("Hex= %04lx\n\r\n\r",convert);
      
      lcd_gotoxy(1,1);
      printf(lcd_putc, "%1.2f Voltaje\n",res);
      
      //Salida por puerto D
      output_d(convert);
      cont=0;
   }
   else{
      cont++;
      }
   }
 
 float volts(long con){
   res=(float)con*(0.01953);
   return res;
 }
 
 void main(){
   lcd_init(0x4E,16,2); //Inica el LCD
   setup_port_a(ALL_ANALOG); //PUERTO A ANALOGICO
   setup_adc(ADC_CLOCK_INTERNAL);  
   set_adc_channel(0); //Seleccionamos el canal 0
   delay_us(20);

   set_timer0(0); //Timer0 en 0x00
   setup_counters(RTCC_INTERNAL,RTCC_DIV_256); //Freq y prescalado
   enable_interrupts(INT_RTCC); //Activacion de TIMER0
   enable_interrupts(GLOBAL); //Activacion de interrupciones Globales
   
   set_tris_d(0x00);
   output_d(0x00);
   
   while(TRUE){
      
      }
   
   }

