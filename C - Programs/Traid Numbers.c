// Chirag Singh Rajput

/*

write a program to print triad numbers. any three numbers will be triad numbers if they satisfy the following conditions.
1) each number is a three number.
2) all the digits in the three numbers(total 9 digits) should be different.

*/

#
include < stdio.h >

    int main(int argc, char * argv[]) {

        int a, b, c, f = 1, i, d = 0, j, e, g;
        clrscr();
        printf("Enter Three Numbers : \n");
        scanf("%d%d%d", & a, & b, & c);
        if (a < 100 && a > 999 || b < 100 && b > 999 || c < 100 && c > 999)
            f = 0;
        else if (b != (a * 2) || c != (a * 3))
            f = 0;
        else
            for (i = 1; i <= 3; i++) {
                if (a % 10 == e % 10 || a % 10 == g % 10)
                    f = 0;
                else {
                    e /= 10;
                    g /= 10;
                }
                if (b % 10 == c % 10)
                    f = 0;
                else
                    c /= 10;

            }
        //printf("\n%d",d);
        if (f == 0)
            printf("Numbers Not Triad!");
        else
            printf("Numbers Are Triad!");
        getch();
    }
