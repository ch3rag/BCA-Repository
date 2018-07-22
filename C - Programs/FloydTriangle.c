// CHIRAG SINGH RAJPUT
// Program For Floyd's Triangle
#include <stdio.h>
    int main(int argc, char * argv[]) {
        int i, j, z;
        for (i = 0; i < 10; i++) {
            if (i % 2 == 0)
                z = 1;
            if (i % 2 == 1)
                z = 0;
            for (j = 0; j <= i; j++) {
                printf("%d", z);
                if (z == 1)
                    z = 0;
                else
                    z = 1;
            }
            printf("\n");
        }
        return 0;
    }
