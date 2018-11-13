// GENERIC MERGE SORT
// CHIRAG SINGH RAJPUT

#include <stdio.h>
#include <math.h>
#include <string.h>
#include <stdlib.h>

int intComparator(void * a, void * b) {
	int aa = *(int *) a;
	int bb = *(int *) b;
	return aa - bb;
	
}

int floatComparator(void * a, void * b) {
	float aa = *(float *) a;
	float bb = *(float *) b;
	return aa - bb < 0? -1 : 1;
}

int charComparator(void * a, void * b) {
	char aa = *(char *) a;
	char bb = *(char *) b;
	return aa - bb;
}


void merge(void * arr, int lb, int pivot, int ub, int elemSize, int (* comparatorFn) (void *, void *)) {
	if(lb == ub) return;
	int l = lb, p = pivot + 1, i = 0;
	void * tempAr = malloc((ub - lb + 1) * elemSize);
	while(l <= pivot && p <= ub) {
		void * elem1 = (char *) arr + l * elemSize;
		void * elem2 = (char *) arr + p * elemSize;
		int cmp = comparatorFn(elem1, elem2);
		if(cmp < 0) { 								//Element 1 < Element 2
			memcpy(tempAr + i * elemSize, elem1, elemSize);
			l++; i++;
		} else {
			memcpy(tempAr + i * elemSize, elem2, elemSize);
			p++; i++;
		}
	}
	
	if (l <= pivot) {
		memcpy(tempAr + i * elemSize, arr + l * elemSize, (pivot - l + 1) * elemSize);
	} else if(p <= ub) {
		memcpy(tempAr + i * elemSize, arr + p * elemSize, (ub - p + 1) * elemSize);
	}
	memcpy(arr + lb * elemSize, tempAr, (ub - lb + 1) * elemSize);
}

void divide(void * arr, int lb, int ub, int elemSize, int (* comparatorFn) (void *, void *)) {
	int pivot = (lb + ub) / 2;
	if (ub > lb) {
		divide(arr, lb, pivot, elemSize, comparatorFn);
		divide(arr, pivot + 1, ub, elemSize, comparatorFn);
	}
	merge(arr, lb, pivot, ub, elemSize, comparatorFn);
}

void mergeSort(void * arr, int n, int elemSize, int (* comparatorFn) (void *, void *)) {
	divide(arr, 0, n-1, elemSize, comparatorFn);
}

int main() {
	int intAr[] = {-1, 99, 66, -98, 123, 33, 56, 23, 198, -76};
	float floatAr[]	 = {0.675, 1.234, 9.092, -0.2313, 1.235, -1.456, -3.12, 0, 0.001, -0.001};
	char charAr[] = "CHIRAG";
	mergeSort(intAr, 10, sizeof(int), intComparator);
	mergeSort(floatAr, 10, sizeof(float), floatComparator);
	mergeSort(charAr, strlen(charAr), sizeof(char), charComparator);
	for(int i = 0 ; i < 10 ; i++) {
		printf("%d ", intAr[i]);
	}
	printf("\n");
	for(int i = 0 ; i < 10 ; i++) {
		printf("%.4f ", floatAr[i]);
	}
	printf("\n");
	printf("%s", charAr);
	return 0;
}

