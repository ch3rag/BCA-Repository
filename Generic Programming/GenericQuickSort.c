// CHIRAG SINGH RAJPUT
// GENERIC QUICK SORT

#include <stdio.h>
#include <string.h>

//CUSTOM COMPARATOR FOR INT
//SIMILAR APPROACH CAN BE USED TO CREATE OTHER COMPARATORS
int intComparision(void * a, void * b) {
	int x = *(int*) a;
	int y = *(int*) b;
	return x - y;
}

int floatComparision(void * a, void * b) {
	float x = *(float *) a;
	float y = *(float *) b;
	
	return (x - y) > 0?1:0;
	 
}




void quickSort(void * array, int lb, int ub, int elemSize, int(*cmp)(void *, void *)) {
	if(lb < ub) {
		int k = partition(array, lb, ub, elemSize, cmp);
		quickSort(array, lb, k-1, elemSize, cmp);
		quickSort(array, k+1, ub, elemSize, cmp);
	}
}

int partition(void * array, int lb, int ub, int elemSize, int(*cmp)(void *, void *)) {
	
	void * pivot = (char *) array + ub * elemSize;
	int j = lb, i = lb - 1;
	char buffer[elemSize];
	void * elem;
	void * elem2;
	
	while(j < ub) {
		void * elem = (char *)array + j * elemSize;
		int compare = cmp(pivot, elem);
		if(compare > 0) {
			i++;
			elem2 = (char *)array + i * elemSize;
			memcpy(buffer, elem2, elemSize);		
			memcpy(elem2, elem, elemSize);
			memcpy(elem, buffer, elemSize);
		}
		j++;
	} 
	
	i++;
	
	elem = (char *)array + i * elemSize;
	memcpy(buffer, pivot, elemSize);		
	memcpy(pivot, elem, elemSize);
	memcpy(elem, buffer, elemSize);
	
	return i;
}

int main(int argc, char * argv[]) {
	int intArray[10] = {23, -12, 54, -122, 3432, 32, 11, 1, 7, 53}; 
	quickSort(intArray, 0, 9, sizeof(int), intComparision);
	
	// intComparision work as a Comparator
	
	int i;
	for(i = 0 ; i < 10 ; i++) {
		printf("%d ", intArray[i]);
	}
	
	printf("\n");
	
	float floatArray[10] = {12.342, 3.1415, -12.348, 99.235, 0.009, -0.001, 0, 7.43, 1.0, 1245.99};
	quickSort(floatArray, 0, 9, sizeof(float), floatComparision);
	
	for(i = 0 ; i < 10 ; i++) {
		printf("%.3f ", floatArray[i]);
	}
	
	return 0;
}
