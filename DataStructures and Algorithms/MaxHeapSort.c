// CHIRAG SINGH RAJPUT
// HEAP SORT
// MAX HEAP

#include <stdio.h> 
#define MAX 20

void swap(int * ip1, int * ip2) {
    int temp;
    temp = * ip1;
    * ip1 = * ip2;
    * ip2 = temp;
}

void createHeap(int a[MAX], int n) {

    int i, j = 0, parent, lchild, rchild;

    for (i = 0; i < n; i++) {

        parent = i;
        lchild = i * 2 + 1;
        rchild = i * 2 + 2;

        if (a[parent] < a[lchild] && lchild < n && a[lchild] >= a[rchild]) {
            swap( & a[parent], & a[lchild]);
        } else if (a[parent] < a[rchild] && rchild < n) {
            swap( & a[parent], & a[rchild]);
        }
    }
}

void adjustHeap(int a[MAX], int n) {
    int i, k;
    for (i = 0; i < n - 2; i++) {
        swap( & a[0], & a[n - i - 1]);
        createHeap(a, n - i - 1);
    }
}
int main(int argc, char * argv[]) {

    int n = 10, a[10] = {56,980,9,234,12,34,-213,2,-12,111}, i;

    createHeap(a, n);
    adjustHeap(a, n);
    for (i = 0; i < n; i++) {
        printf("%d ", a[i]);
    }
    return 0;
}
