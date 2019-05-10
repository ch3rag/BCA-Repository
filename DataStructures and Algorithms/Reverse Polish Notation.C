/**********************************
POLISH POSTFIX NOTATION USING STACK
***********************************/
#include<stdio.h>
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#include<math.h>
#define MAX 50

char infix[MAX],postfix[MAX];
char stack[MAX]={'#'};
int top = 0;

int precedence(char symbol) {
	switch(symbol) {
		case '(':
			return 0;
		case '+':
		case '-':
			return 1;
		case '*':
		case '/':
			return 2;
		case '^':
			return 3;
	}
}

void push(char symbol) {
	if(top == MAX-1){
		printf("STACK OVERFLOW!");
		return;
	}
	top++;
	stack[top] = symbol;
}

char pop() {
	if(top == 0) {
		printf("STACK UNDER FLOW!");
		return;
	}
	return stack[top--];
}

void convert() {
	int i,k;
	int j=0;
	printf("ENTER INFIX : ");
	fflush(stdin);
	gets(infix);
	infix[strlen(infix)] = '#';
	for( i = 0 ; i < strlen(infix); i++) {
		switch(infix[i]) {
		case ')' :  
			while(stack[top] != '(' && top != 0)
				postfix[j++] = pop();
			pop();
			break;

		case '(' :  
			push(infix[i]);
			break;

		case '*' :
		case '/' :
		case '+' :
		case '-' :
		case '^' : 
			while(stack[top] != '#' && precedence(infix[i])  < precedence(stack[top])) {
				postfix[j++] = pop();
			}
			push(infix[i]);
			break;
		case '#' : 
			while(stack[top] != '#') {
				if(stack[top] != '(')
					postfix[j++] = pop();
				else 
					pop();
			}
			break;
		default  : 
			postfix[j++] = infix[i];
		}
	}
	printf("POSTFIX : ");
	puts(postfix);
	return;
}
void evaluate() {
	int i,x,y,temp,j;
	printf("ENTER POSTFIX EXPRESSION : ");
	fflush(stdin);
	gets(postfix);
	postfix[strlen(postfix)] = '#';
	for(i = 0 ; postfix[i] != '#' ; i++ ) {
		if(postfix[i] >= '0' && postfix[i] <= '9') {
			push(postfix[i]  - 48 ) ;
		} else {
			x = pop();
			y = pop();
			switch(postfix[i]) {
				case '+': 
					push(x+y);
					break;

				case '-': 
					push(y-x);
					break;

				case '*': 
					push(x*y);
					break;

				case '/': 
					push(y/x);
					break;

				case '^': 
					push(pow(x,y));
					break;
			}	
		}
		printf("STACK : ");
		for(j = 1 ; j  <= top ; j++)
		printf("%d ",stack[j]);
		printf("\n");
	}
	printf("ANSWER  =  %d" , pop());
}

void main() {
	int ch;
	choice:
	clrscr();
	printf("POLISH POSTFIX CONVERSION AND EVALUATION USING STACK\n\n1.COVERT\n2.EVALUATE\n3.EXIT\nENTER YOUR CHOICE : ");
	scanf("%d",&ch);
	switch(ch) {
		case 1 : 
			convert();
			break;
		case 2 : 
			evaluate();
			break;
		case 3 : 
			exit(0);
			break;
		default : 
			break;
	}
	getch();
	goto choice;
}
