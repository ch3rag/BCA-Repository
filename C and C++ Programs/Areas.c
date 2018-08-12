// CHIRAG SINGH RAJPUT
// AREAS OF CIRCLE, CYLINDER, TRIANGLE

#include <stdio.h> 
#define pi 3.14
int main(int argc, char * argv[]) {
  int ch;
  float b, h, r;
  printf("\n\n1. Area Of Circle\n2. Area Of Cylinder\n3. Area Of Triangle\n\nEnter Your Choice : ");
  scanf("%d", & ch);
  switch (ch) {
  case 1:
    printf("Enter Radius Of Circle : ");
    scanf("%f", & r);
    printf("Area : %f", pi * r * r);
    break;
  case 2:
    printf("Enter Radius Of Base : ");
    scanf("%f", & r);
    printf("Enter Height Of Cylinder : ");
    scanf("%f", & h);
    printf("Area : %f", pi * r * r * h);
    break;
  case 3:
    printf("Enter Length Of Base :");
    scanf("%f", & b);
    printf("Enter Altitude Of Triangle : ");
    scanf("%f", & h);
    printf("Area : %f", (b * h * 0.5));
    break;
  default:
    printf("Wrong Choice!");
  }
  return 0;
}
