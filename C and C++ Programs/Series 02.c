// Chirag Singh Rajput

/*

Enter N :  10
 + 1  - 3  + 5  - 7  + 9  - 11  + 13  - 15  + 17  - 19  = -10 
 
 */

#include <stdio.h>

    int main(int argc, char * argv[]) {
        int i, n, sum = 0, j = 1;

        printf("Enter N : ");
        scanf("%d", & n);
        for (i = 1; i <= n; i++) {
            if (i % 2 == 0) {
                printf(" - %d ", j);
                sum = sum - j;
            } else {
                printf(" + %d ", j);
                sum = sum + j;
            }
            j += 2;
        }
        printf(" = %d", sum);
        return 0;
    }
