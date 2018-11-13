// MERGE SORT
// CHIRAG SINGH RAJPUT

#include <stdio.h>

void merge(int arr[], int lb, int pivot, int ub) {
	int l = lb, p = pivot + 1;
	int tempAr[ub - lb + 1], i = 0;
	while(l <= pivot && p <= ub) {
		if(arr[l] < arr[p]) {
			tempAr[i++] = arr[l++];
		} else {
			tempAr[i++] = arr[p++];
		}
	}
	
	if(l <= pivot) {
		while(l <= pivot) {
			tempAr[i++] = arr[l++];
		}
	} else if(p <= ub) {
		while(p <= ub) {
			tempAr[i++] = arr[p++];
		}
	}
	
	for(int j = lb, i = 0 ; j <= ub ; j++) {
		arr[j] = tempAr[i++]; 
	}
}

void divide(int arr[], int lb, int ub) {
	int pivot = (lb + ub) / 2;
	if (ub > lb) { 						//  Size of Array > 1
		divide(arr, lb, pivot);
		divide(arr, pivot + 1, ub);
	}
	merge(arr, lb, pivot, ub); 
}



void mergeSort(int n, int arr[]) {
	divide(arr, 0, n - 1);
}

int main() {
	int arr[] = {-1, 99, 66, -98, 123, 33, 56, 23, 198, -76};
	mergeSort(10, arr);
	for(int i = 0 ; i < 10 ; i++) {
		printf("%d ", arr[i]);
	}
}
