//MATRIX MULIPLICATION DIVIDE AND CONQUER

//CHIRAG SINGH RAJPUT

#include <iostream>
#include <cstdlib>
#include <math.h>

int ** allocate(int order) {
	int ** arr = (int **) calloc (order, sizeof(int *));
	for(int i = 0 ; i < order ; i++) {
		arr[i] = (int *) calloc (order, sizeof(int));
	}
	return arr;
}

int ** addMatrix(int ** a,  int ** b, int order) {
 	 int ** cr = allocate(order);
	 for(int i = 0 ; i < order ; i++) {
 		for(int j = 0 ; j < order ; j++) {
 			cr[i][j] = a[i][j] + b[i][j];
		 }
	 }
	 
	 return cr;
}
 

void printMatrix(int ** mat, int order) {
	for(int i = 0 ; i < order ; i++) {
		for(int j = 0 ; j < order ; j++) {
			std :: cout << mat[i][j] << "  ";
		}

		std :: cout << std :: endl;
	}
 }

int ** combine(int ** a, int ** b, int ** c, int ** d, int order) {
	int ** result = allocate(order);
	int x = 0, y = 0;
	for(int i = 0 ; i < order/2 ; i++) {
		for(int j = 0 ; j < order/2 ; j++) {
			result[i][j] = a[x][y];
			y++;
		}
		x++;
		y = 0;
	}
	
	
	x = 0,y = 0;
	
	for(int i = 0 ; i < order/2 ; i++) {
		for(int j = order/2 ; j < order ; j++) {
			result[i][j] = b[x][y];
			y++;
		}
		x++;
		y = 0;
	}
	
	x = 0,y = 0;
	
	for(int i = order/2 ; i < order ; i++) {
		for(int j = 0 ; j < order/2 ; j++) {
			result[i][j] = c[x][y];
			y++;
		}
		x++;
		y = 0;
	}
	
	x = 0,y = 0;
	
	for(int i = order/2 ; i < order ; i++) {
		for(int j = order/2 ; j < order ; j++) {
			result[i][j] = d[x][y];
			y++;
		}
		x++;
		y = 0;
	}
	
	return result;
}

int ** divide(int ** a, int r, int c, int order) {
	int ** result = allocate(order);
	int x = 0, y = 0;
	for(int i = order * r ; i < order + (order * r) ; i++) {
		for(int j = order * c ; j < order + (order * c) ; j++) {
			result[x][y] = a[i][j];
			y++;
		}
		x++;
		y = 0;
	}
	return result;
}
int ** mulMat(int ** a, int ** b, int order) {
	if(order == 1) {
		int ** c = allocate(1);
		c[0][0] = a[0][0] * b[0][0];
		return c;
	} else if(order == 2) {
		int ** c = allocate(2);
		c[0][0] = a[0][0] * b[0][0]	+ a[0][1] * b[1][0];
		c[0][1] = a[0][0] * b[0][1] + a[0][1] * b[1][1];
		c[1][0] = a[1][0] * b[0][0] + a[1][1] * b[1][0];
		c[1][1] = a[1][0] * b[0][1] + a[1][1] * b[1][1];
		return c;
 	} else {
 		combine(addMatrix(mulMat(divide(a,0,0,order/2), divide(b,0,0,order/2),order/2), mulMat((divide(a,0,1,order/2)), divide(b,1,0,order/2),order/2), order/2), addMatrix(mulMat(divide(a,0,0,order/2), divide(b,0,1,order/2),order/2), mulMat((divide(a,0,1,order/2)), divide(b,1,1,order/2),order/2), order/2), addMatrix(mulMat(divide(a,1,0,order/2), divide(b,0,0,order/2),order/2), mulMat((divide(a,1,1,order/2)), divide(b,1,0,order/2),order/2), order/2), addMatrix(mulMat(divide(a,1,0,order/2), divide(b,0,1,order/2),order/2), mulMat((divide(a,1,1,order/2)), divide(b,1,1,order/2),order/2), order/2), order);	
	}	
}

int main() {
	int ** a;
	int ** b;
	int order;
	std :: cout << "Enter Order Of Matrix : ";
	std :: cin >>  order;
	double logn = log(order)/log(2);
	int n = pow(2,ceil(logn));	
	a = allocate(n);
	b = allocate(n);
	
	std :: cout << "Enter Matrix 1 : " << std :: endl;
	for(int i = 0 ; i < order ; i++) {
		for(int j = 0 ; j < order ; j++) {
			std :: cin >> a[i][j];
		}
	}
	
	std :: cout << "Enter Matrix 2 : " << std :: endl;
	
	for(int i = 0 ; i < order ; i++) {
		for(int j = 0 ; j < order ; j++) {
			std :: cin >> b[i][j];
		}
	}
	
	printMatrix(mulMat(a,b,n),order);
	return 0;	
}
