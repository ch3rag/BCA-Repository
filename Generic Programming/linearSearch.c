// CHIRAG SINGH RAJPUT
// GENERIC LINEAR SEARCH

#include <stdio.h>
#include <string.h>

int linearSearch(void * array, void * key, int size, int elemSize) {
	int i;
	for(i = 0 ; i < size ; i++) {
		void * elem = (char *)array + i * elemSize;
		if(memcmp(key, elem, elemSize) == 0) {
			return i;
		}
	}
	
	return -1;
}

int main(int argc, char * argv[]) {
	
	int intArray[8] = {5,123,45,12,76,89,32,342};
	int key = 342;
	
	double doubleArray[5] = {1.23132, 123.123213, 56.154, 453.3, 45.67};
	double dKey = 453.3;
	
	int position = linearSearch(intArray, &key, 8, sizeof(int));
	
	if(position == -1) {
		printf("\nElement not found.");
	} else {
		printf("\nElement found at index: %d", position);
	}
	
	position = linearSearch(doubleArray, &dKey, 5, sizeof(double));
	
	if(position == -1) {
		printf("\nElement not found.");
	} else {
		printf("\nElement found at index: %d", position);
	}
	
	
	return 0;
}
