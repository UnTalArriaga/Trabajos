%{
	#include <stdio.h>
	#include <ctype.h>
	extern int yylex(void);
	void yyerror(char *mensaje); 
%}

%token I
%token PABRE
%token PCIERRA
%token RESTA
%token SUMA
%token PUNTOCOMA

%start INICIO

%%
INICIO	: INICIO E PUNTOCOMA {printf("CADENA VALIDA\n");}
		| E PUNTOCOMA {printf("CADENA VALIDA\n");}
		| error PUNTOCOMA {yyerrok;}
		;

E 		: T 
		| T EP
		;
	   
EP	   	: SUMA T	
	   	| RESTA T
		| /*VACIO*/
	   	;

T 	   	: I
	   	| PABRE E PCIERRA
		;

%%
int main (void){
	yyparse();
	return 0;
}

