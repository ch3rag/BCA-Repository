// CHIRAG SINGH RAJPUT
// MATRIX MULTIPLIER IN C

#include <stdio.h> 
#include <stdlib.h>

typedef struct array {
    int * p;
    int rows;
    int cols;
} array;

array a1, a2, result;

int e1(int * p, int row, int col) {
    return *(p + row * a1.cols + col);
}
int e2(int * p, int row, int col) {
    return *(p + row * a2.cols + col);
}
void e3i(int * p, int row, int col, int value) {
    *(p + row * result.cols + col) = value;
}

int main(int argc, char * argv[]) {
	
    int i, a, b, j, k, temp = 0;
    printf("ENTER NUMBER OF ROWS OF ARRAY 1: ");
    scanf("%d", & a1.rows);
    printf("ENTER NUMBER OF COLUMNS OF ARRAY 1: ");
    scanf("%d", & a1.cols);
    printf("ENTER NUMBER OF ROWS OF ARRAY 2: ");
    scanf("%d", & a2.rows);
    printf("ENTER NUMBER OF COLUMNS OF ARRAY 2: ");
    scanf("%d", & a2.cols);
    if (a1.cols != a2.rows) {
        printf("MULTIPLICATION NOT POSSIBLE!");
        exit(0);
    }
    
    //DMA
    result.rows = a1.rows;
    result.cols = a2.cols;
    a1.p = (int *) calloc(a1.rows * a1.cols, sizeof(int));
    a2.p = (int *) calloc(a2.rows * a2.cols, sizeof(int));
    result.p = (int *) calloc(a1.rows * a2.cols, sizeof(int));
    //INPUT
    printf("ENTER ARRAY 1:\n");
    for (i = 0; i < a1.rows * a1.cols; i++) {
        scanf("%d", a1.p + i);
    }
    printf("ENTER ARRAY 2:\n");
    for (i = 0; i < a2.rows * a2.cols; i++) {
        scanf("%d", a2.p + i);
    }
    printf("\n\n\n");
    for (i = 0; i < a1.rows; i++) {
        for (j = 0; j < a2.cols; j++) {
            for (k = 0; k < a2.rows; k++) {
                // printf("%d = %d + %d X %d \n",temp,temp,e1(a1.p,i,k),e2(a2.p,k,j));
                temp = temp + e1(a1.p, i, k) * e2(a2.p, k, j);
            }
            e3i(result.p, i, j, temp);
            temp = 0;
        }
    }
    for (i = 0; i < result.cols * result.rows; i++) {
        printf("%d ", *(result.p + i));
        if ((i + 1) % result.cols == 0)
            printf("\n");
    }
    
    return 0;
}
