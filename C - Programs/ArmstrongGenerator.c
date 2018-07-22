// CHIRAG SINGH RAJPUT
// ARMSTRONG NUMBER GENERATOR

#include<stdio.h>
#include<math.h>

    int main(int argc, char * argv[]) {
        long int n = 10, num, sum = 0;
        int len = 0, i, d;
        //printf("Input A Number : ");
        //scanf("%ld",&n);
        while (n < 10000) {
            sum = 0;
            num = n;
            len = 0;
            while (num > 0) {
                len++;
                num /= 10;
            }
            //printf("Length = %d",len);
            num = n;
            for (i = 0; i < len; i++) {

                d = num % 10;
                sum = sum + pow(d, len);
                num = num / 10;
            }
            //printf("\n%d\n",sum);
            if (sum == n)
                printf("\n%d Number Is Armstrong.", sum);
            //else
            //printf("Number Is Not Armstrong.");

            n++;
        }
    }
