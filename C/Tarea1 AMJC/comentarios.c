//Programa hecho por:\
Arriaga Mejía José Carlos
#include <stdio.h>

//comentarios validos

//Primero
//sdasdsdasd ds/das/dasdas \dasdas\
dasdsdasd

//Segundo
/*sdasdasdsad*asdsadsa/dsadsadasd*\/adsad da
 asda
 *\/ asda
 */

//Tercero
//

//Cuarto
/**/

//Quinto
//\
das
void q0();
void q1();
void q2();
void q3();
void q4();
void q5();
void q7();
void q8();
 
int i=-1;
char com[256];

void main(){
    FILE *ap;
    int j=0;
    ap=fopen("prueba.txt","r");

    while (feof(ap)==NULL){
        com[j]=fgetc(ap);
        if (com[j]==EOF){
            int bandera=j;
            for (j=0;j<bandera; j++)
            {
                printf("%c", com[j]);
            }
            q0();
            i=-1;
        }
        j++;
    }
    fclose(ap);
}

void q0(){
    i++;
    if (com[i]=='/'){
        q1();
    }else{
        printf("\nComenatario invalido\n");
    }
}
void q1(){
    i++;
    if (com[i]=='*'){
        q2();
    }else if (com[i]=='/'){
        q3();
    }else{
        printf("\nComenatario invalido\n");
    }
}
void q2(){
    i++;
    if (com[i]=='*'){
        q4();
    }else{
        q2();
    }
}
void q3(){
    i++;
    if(com[i]=='\n'){
        q8();
    }else if(com[i]=='\\'){
        q5();
    }else if (com[i]==EOF){
        printf("\nComentario Valido\n");
    }else {
        q3();
    }
}
void q4(){
    i++;
    if (com[i]=='/'){
        q7();
    }else{
        q2();
    }
}
void q5(){
    i++;
    if (com[i]==EOF){
        printf("\nComentario Valido\n");
    }else {
        q3();
    }
}
void q7(){
    i++;
    if (com[i]=='\n'||com[i]=='\0'||com[i]=='\t'){
            q8();
        }else {
            printf("\nComentario Invalido\n");
        }
}
void q8(){
    i++;
    if (com[i]==EOF){
            printf("\nComentario Valido\n");
        }else {
            printf("\nComentario Invalido\n");
        }
}
