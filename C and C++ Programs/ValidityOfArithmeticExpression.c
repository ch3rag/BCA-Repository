/***********************************/
/*VALIDITY OF ARITHMETIC EXPRESSION*/
/************USING STACK************/
/***********************************/
#include <stdio.h>
#include <conio.h>
#include <string.h>
#define MAX 10
char stack[MAX], top = -1;
void push(char bracket)
{
    if (top == MAX - 1) {
        printf("STACK OVERFLOW!");
        return;
    }
    stack[++top] = bracket;
}

char pop()
{
    if (top == -1) {
        printf("STACK UNDERFLOW!");
    }
    else
        return stack[top--];
}

void main()
{
    int valid = 1, i;
    char exp[MAX];
    clrscr();
    printf("ENTER AN ARITHMETIC EXPRESSION : ");
    gets(exp);
    for (i = 0; i < strlen(exp); i++) {
        if (exp[i] == '(' || exp[i] == '{' || exp[i] == '[') {
            push(exp[i]);
        }
        if (exp[i] == ')' || exp[i] == '}' || exp[i] == ']') {
            if (top == -1)
                valid = 0;
            else if (exp[i] == ')' && pop() != '(')
                valid = 0;
            else if (exp[i] == '}' && pop() != '{')
                valid = 0;
            else if (exp[i] == ']' && pop() != '[')
                valid = 0;
        }
    }
    if (top != -1)
        valid = 0;

    if (valid == 1)
        printf("STATEMENT IS VALID!");
    else
        printf("INVALID STATEMENT!");
    getch();
}
