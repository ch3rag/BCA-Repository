// RADIX SORT 
// COUNTING SORT USED AS STABLE SORT

#include <stdio.h>
#include <stdlib.h>
#include <math.h>

int * countingSort(int * a, int n, int k) {
	int * c = (int *)calloc(k, sizeof(int));
	int * b = (int *)calloc(n, sizeof(int));
	for(int i = 0 ; i < n ; i++) {
		c[a[i]]++;
	} 
	for(int i = 1 ; i < k ; i++) {
		c[i] += c[i-1];
	}
	for(int i = 0 ; i < n ; i++) {
		b[c[a[i]] - 1] = a[i];
		c[a[i]]--;
	}
	return b;
}

int * radixSort(int * a, int n, int d, int radix) {
	for(int i = 0 ; i < d ; i++) {
		int * c     = (int *)calloc(radix, sizeof(int));
		int * digits = (int *)calloc(n, sizeof(int));
		int * b     = (int *)calloc(n, sizeof(int));
		for(int j = 0 ; j < n ; j ++) {
			int digit = (int)(a[j] / pow(10, i)) % 10;
			c[digit]++;
			digits[j] = digit;
		}
		for(int j = 1 ; j < radix ; j++) {
			c[j] += c[j-1];
		}
		for(int j = n - 1 ; j >= 0 ; j--) {
			b[c[digits[j]] - 1] = a[j];
			c[digits[j]]--;
		}
		a = b;
	}
	return a;
}




int main() {
	int arr[] = {22, 17, 64, 33, 28, 19, 74, 17, 10, 12};
	//int arr[] = {329, 768, 423, 121, 190};
	int * a = radixSort(arr, 10, 2, 10);
	for (int i = 0 ; i < 10 ; i++) {
		printf("%d\n", a[i]);
	}
	return 0;
}
