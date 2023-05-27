%{
	#include <stdio.h>
	#include "y.tab.h"
	int yylex();
	void yyerror(char *msg);
	int lineno = 1;
%}

%option yylineno
%option noyywrap

%%

"i" 			{return I;}
"(" 			{return PABRE;}
")"				{return PCIERRA;}
"+"				{return SUMA;}
"-" 			{return RESTA;}
";"				{return PUNTOCOMA;}
"e"				{printf("Error lexico en la linea %d\n",lineno);}
.				{printf("Error lexico en la linea %d\n",lineno);}
"\n" 			{lineno++;}

%%
void yyerror(char *msg) {
	printf("Error en la linea: %d\nLa cadena ingresada no es valida para la gramática\n", lineno);
}

