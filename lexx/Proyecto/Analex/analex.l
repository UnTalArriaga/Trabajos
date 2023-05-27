%option yylineno
%option noyywrap

%{
	#include <stdio.h>
%}
/* Identifica numeros enteros*/
digito [0-9]+	
/*Identifica numeros con decimal*/
real [0-9]*\.[0-9]+ 
/*Identifica cualquier letra*/
letra [A-Za-z] 
identificador (_|{letra})(_|{letra}|{digito})* 
/*Identifica identificadores validos en C*/

%%
{digito} {fprintf(yyout, "i");} 
{real} {fprintf(yyout, "i");}
{identificador} {fprintf(yyout, "i");}
 /*En las 3 anteriores escribe en el archivo AL.txt una i 
cada que encuentra alguna de ellas
En los siguientes escribe en Al.txt el simbolo que encuentre*/
[\(] {fprintf(yyout, "(");}
[\)] {fprintf(yyout, ")");}
"+"	{fprintf(yyout, "+");}
"-" {fprintf(yyout, "-");}
[";"] {fprintf(yyout,";");}
"\n" {fprintf(yyout, "\n");}
. {fprintf(yyout, "e");}

%%
int main() {
	FILE *in; 
	FILE *out;
	/*Abre el archivo prueba.txt donde esta la entrada que analizara*/
	yyin = fopen("prueba.txt", "r");
	/*Abre el archivo AL.txt donde ira transformando la entrada en los tokens*/
	yyout = fopen("AL.txt", "w");
	yylex();
	return 0;
}

