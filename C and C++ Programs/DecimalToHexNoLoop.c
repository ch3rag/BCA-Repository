// CHIRAG SINGH RAJPUT
// DECIMAL TO HEXADECIMAL CONVERTOR
// NO LOOPS
// RANGE UPTO 999

#include <stdio.h>

int main(int argc, char *argv[]) {
  int dec, i = 0;
  char hex[3];
  printf("Enter A Decimal Number : ");
  scanf("%d", &dec);
  if (dec >= 0 && dec < 16) {
    if (dec % 16 < 10)
      hex[i] = 48 + dec;
    else
      hex[i] = 55 + dec;
    printf("Hexadecimal = %c", hex[i]);
  }
  if (dec == 16)
    printf("Hexadecimal = 10");
  if (dec > 16 && dec < 256) {
    if (dec % 16 < 10)
      hex[i] = 48 + dec % 16;
    else
      hex[i] = 55 + dec % 16;

    i++;
    dec /= 16;
    if (dec % 16 < 10)
      hex[i] = 48 + dec % 16;
    else
      hex[i] = 55 + dec % 16;
    printf("%c%c", hex[1], hex[0]);
  }

  if (dec >= 256 && dec < 1000) {
    if (dec % 16 < 10)
      hex[i] = 48 + dec % 16;
    else
      hex[i] = 55 + dec % 16;
    i++;
    dec /= 16;
    if (dec % 16 < 10)
      hex[i] = 48 + dec % 16;
    else
      hex[i] = 55 + dec % 16;
    i++;
    dec /= 16;
    if (dec % 16 < 10)
      hex[i] = 48 + dec % 16;
    else
      hex[i] = 55 + dec % 16;
    printf("%c%c%c", hex[2], hex[1], hex[0]);
  }

  return 0;
}
