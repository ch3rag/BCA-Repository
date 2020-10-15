/***********************************************************************
*                     Author: Bharat Singh Rajput                      *
*               Last Updated: September 9, 2020 01:57 PM               *
*                   File Name: ArmstrongGenerator.c                    *
*                          Source Language: c                          *
*       Repository: http://github.com/ch3rag/bca-repository.git        *
*                                                                      *
*                       --- Code Description ---                       *
*                 Armstrong  Numbers From 0 To 10,000                  *
***********************************************************************/

#include <stdio.h>
#include <math.h>

int main(int argc, char * argv[]) {
    long int n = 10, num, sum = 0;
    int len = 0, i, d;
    while (n < 10000) {
        sum = 0;
        num = n;
        len = 0;
        while (num > 0) {
            len++;
            num /= 10;
        }
        num = n;
        for (i = 0; i < len; i++) {

            d = num % 10;
            sum = sum + pow(d, len);
            num = num / 10;
        }
        if (sum == n)
            printf("\n%d Number Is Armstrong.", sum);

        n++;
    }
}