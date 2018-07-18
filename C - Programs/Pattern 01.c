// PATTERN 

/*       5
 	   5 4 5
     5 4 3 5 5
   5 4 3 2 3 4 5
 5 4 3 2 1 2 3 4 5 
   5 4 3 2 3 4 5
     5 4 3 4 5
       5 4 5
         5
*/

#include  <stdio.h>

    int main(int argc, char * argv[]) {

        int i, j;
        for (i = 5; i >= 1; i--) {
            for (j = 1; j <= i; j++)
                printf(" ");

            for (j = 5; j >= i; j--)
                printf("%d", j);

            for (j = i; j < 5; j++)
                printf("%d", j + 1);
            printf("\n");
        }
        for (i = 1; i <= 4; i++) {
            for (j = 0; j <= i; j++)
                printf(" ");

            for (j = 5; j > i; j--)
                printf("%d", j);
            for (j = i + 2; j <= 5; j++)
                printf("%d", j);

            printf("\n");
        }
        return 0;
    }
