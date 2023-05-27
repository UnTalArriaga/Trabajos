#include <16f877a.h> // Libreria del microcontrolador 
#define use_portb_lcd true //Puerto B para LCD 
#define LCD_DATA_PORT getenv("SFR:PORTD") 
#device adc=8
#fuses HS,NOWDT,NOPROTECT //activa alta velocidad y no protege el celdigo 
#use delay(clock=20000000) //f=20Mhz
#use i2c(MASTER,SDA=PIN_C4,SCL=PIN_C3,SLOW,NOFORCE_SW)
#use rs232(baud=9600, xmit=PIN_C6, rcv=PIN_C7) 
#define use_portb_lcd true
#include <i2c_LCD.c>
#org 0x1F00, 0x1FFF void loaderl6F877(void) {}

int cont_hex=0; //Contador de 8 bits 
int convert=0; //Conversion de A/D
long cont_v=0; //Contador para impresion de voltajes 
long cont_n=0; //Contador para impresion de info en serie 
float res=0;//Conversion a Volts

#int_rtcc
void clock_isr(){ //codigo de la rutina
   //printf("%ld\n\r",cont_v); 
   cont_v++;
   cont_n++;
   if(cont_v==40){ //10 segundos conversion e impresion de Volts en LCD 
      delay_us(20); // retardos
      convert=read_adc(); //CONVERTIDOR A/D 
      res=(float)convert*(0.01953); //Conversion a volts, 0.1953 resolucion 
      lcd_gotoxy(1,1);
      printf(lcd_putc,"%1.2f Vol",res); //Impresion 
      cont_v=0;
   }

if(cont_n==100){ //Impresion cada 25 seg 
printf("*Jose carlos*\n\r");
printf("316017862\n\r");

printf("Grupo: 5\n\r");
printf("Microcomputadoras\n\r");
printf("\n\r");

cont_n=0;
}
}

void main(){ 
lcd_init(0x4E, 16,2);
setup_port_a(ALL_ANALOG); //Define al puerto A como analogico
// Define frecuencia de muestreo del convertidor A/D 
setup_adc(ADC_CLOCK_INTERNAL); 
set_adc_channel(0); // Configura el canal a usar 
delay_us(20); // retardos
set_timer0(0); // Inicia TIMERO en 00H 
setup_counters(RTCC_INTERNAL,RTCC_DIV_256); //Fuente de reloj y pre-divisor 
enable_interrupts(INT_RTCC); //Habilita interrupción por TIMERO 
enable_interrupts(GLOBAL); //Habilita interrupciones generales
set_tris_d(0x00);
 
while(true){
   output_d(cont_hex); //Salida de contador por puerto D 
   if(cont_hex==0xff){//Si llega a Oxff reinicia conteo
     cont_hex=0;
     }
   else{
     cont_hex++; //Aumenta el contador
     }
   delay_ms(250);
   }
}

