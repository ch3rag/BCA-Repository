// Chirag Sing Rajput
// Factorial Series

#include <stdio.h>

int main(int argc, char *argv[]) {
  int n, i, j;
  long int fact = 1, sum = 0;
  printf("Enter N :");
  scanf("%d", &n);
  for (i = 1; i <= n; i++) {
    printf("%d! +", i);
    for (j = 1; j <= i; j++) {
      fact = fact * j;
    }
    sum = fact + sum;
    fact = 1;
  }
  printf(" = %ld", sum);
  return 0;
}
