// CHIRAG SINGH RAJPUT
// QUICK SORT

#include <stdio.h>

    int partition(int a[10], int lb, int ub) {
        int j = lb, i = j - 1, pivot = a[ub], temp;
        while (j < ub) {
            if (a[j] <= pivot) {
                i++;
                temp = a[i];
                a[i] = a[j];
                a[j] = temp;
            }
            j++;
        }
        temp = a[i + 1];
        a[i + 1] = a[ub];
        a[ub] = temp;
        return i + 1;
    }

void quicksort(int a[10], int lb, int ub) {
    int pivot;
    if (lb < ub) {
        pivot = partition(a, lb, ub);
        quicksort(a, lb, pivot - 1);
        quicksort(a, pivot + 1, ub);
    }
}

int main(int argc, char * argv[]) {
    int i;
    int arr[10] = {
        9,
        6,
        2,
        6,
        -1,
        0,
        12,
        67,
        -65,
        98
    };
    quicksort(arr, 0, 9);
    for (i = 0; i < 10; i++) {
        printf("%d ", arr[i]);
    }
    return 0;
}
