/***********************************************************************
*                     Author: Bharat Singh Rajput                      *
*               Last Updated: September 9, 2020 09:23 PM               *
*                       File Name: MagicSquare.c                       *
*                          Source Language: c                          *
*       Repository: http://github.com/ch3rag/bca-repository.git        *
*                                                                      *
*                       --- Code Description ---                       *
*                        Magic Matrix Generator                        *
***********************************************************************/

/*********** NOTES ***********/
/* For Odd Order Matrices: (n = 2n + 1 for n >= 1)
1. Place a 1 top center position of the matrix. We'll move consecutively through the other squares and place the numbers 2, 3, 4, etc. 
2. diagonally up and to the right when you can
3. down if you cannot.

/* For DOUBLY Even Order Matrices: (n = 4n for n >= 1)
1. Start by filling in the square sequentially from the top left corner, across the top row, then move down row by row until the square is filled in.
2. Identify the numbers in the boxes along the two diagonals.
3. Invert the boxes using the center of the square as a pivot point. 
*/
// http://mesosyn.com/mental1-4.html
// https://math.stackexchange.com/questions/76411/how-to-construct-magic-squares-of-even-order

// Note: AS OF NOW IT DOES NOT GENERATE MATRICES OF ORDER 4n + 2 

#include <stdio.h>
#include <math.h>

void generateEvenMatrix(int order) {
    int matrix[order][order];
    int counter = 1;
    for (int i = 0; i < order; i++) { //Initialize Matrix
        for (int j = 0; j < order; j++) {
            matrix[i][j] = counter++;
        }
    }

    for (int i = 0; i < order; i += 4) {
        for (int j = 0; j < order; j += 4) {
            for (int y = 0; y < 4; y++) {
                for (int x = 0; x < 4; x++) {
                    if (y == x || (y + x) == 3) {
                        matrix[i + y][j + x] = order * order + 1 - matrix[i + y][j + x];
                    }
                }
            }
        }
    }

    for (int i = 0; i < order; i++) {
        int sum = 0;
        for (int j = 0; j < order; j++) {
            printf("%5d", matrix[i][j]);
            sum = sum + matrix[i][j];
        }
        printf("    Sum = %d\n\n", sum);
    }
}

void generateOddMatrix(int order) {

    int matrix[order][order];
    int i = 1;
    int x = floor(order / 2), y = 0;

    for (int i = 0; i < order; i++) { //Initialize Matrix to 0
        for (int j = 0; j < order; j++) {
            matrix[i][j] = 0;
        }
    }

    while (i <= order * order) {
        matrix[y][x] = i;
        int newY = (order + (y - 1)) % order;
        int newX = (x + 1) % order;

        if (matrix[newY][newX] != 0) {
            y = (y + 1) % order;
        } else {
            x = newX;
            y = newY;
        }
        i++;
    }

    for (int i = 0; i < order; i++) {
        int sum = 0;
        for (int j = 0; j < order; j++) {
            printf("%5d", matrix[i][j]);
            sum = sum + matrix[i][j];
        }
        printf("    Sum = %d\n\n", sum);
    }
}

int main() {

    int order;
    printf("Enter Order Of The Matrix: ");
    scanf("%d", & order);

    if (order % 2 == 1) {
        generateOddMatrix(order);
    } else {
        generateEvenMatrix(order);
    }
    return 0;
}