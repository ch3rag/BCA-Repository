#include<stdio.h>
#include<conio.h>
#include<math.h>
void main() {
  int a,b,c;
  float x,y,d;
  clrscr();
  printf("Roots Of Quadratic Equation\nBy Chirag\n______________________________");
  printf("\n\n\nPlease Enter The Quadratic Equation in format given below : \n");
  printf("ax^2 + bx + c\n\n");
  scanf("%dx^2 + %dx + %d",&a,&b,&c);
  d = b*b - 4*a*c;
  if(d < 0) {
    printf("No Solutions!");
    goto end;
  } else {
    d = sqrt(d);
    a *= 2;
    x = (-b - d)/a;
    y = (-b + d)/a;
    printf("\n\nRoots ==>\n\nX = %10.2f\nY = %10.2f",x,y);
  }
  end:
  getch();
}