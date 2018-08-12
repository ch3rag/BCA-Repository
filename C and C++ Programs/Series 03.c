// Chirag Singh Rajput

/*

Enter N :  10
1^4 + 2^4 + 3^4 + 4^4 + 5^4 + 6^4 + 7^4 + 8^4 + 9^4 + 10^4 +  = 25333 

*/

#include <stdio.h>

    int main(int argc, char * argv[]) {

        int n, i;
        int sum = 0;
        printf("Enter N : ");
        scanf("%d", & n);

        for (i = 1; i <= n; i++) {
            printf("%d^4 + ", i);
            sum = sum + (i * i * i * i);
        }

        printf(" = %ld", sum);
        return 0;
    }
