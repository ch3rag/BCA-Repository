// CHIRAG SINGH RAJPUT
// INVERSE OF A MATRIX

#include <stdio.h>
#include <math.h>

void copyMat(int order, float source[order][order], float target[order][order]) {
	for(int i = 0 ; i < order ; i++) {
		for(int j = 0 ; j < order ; j++) {
			target[i][j] = source[i][j];			
		}
	}
}


void transpose(int order, float a[order][order]) {
	float tempMat[order][order];
	for(int i = 0 ; i < order ; i++) {
		for(int j = 0 ; j < order ; j++) {
			tempMat[j][i] = a[i][j];
		}
	}
	copyMat(order, tempMat, a);
} 

float determinant(int order, float a[order][order]) {
	float tempMat[order-1][order-1];
	float result = 0;
	if (order == 2) {
		return (a[0][0] * a[1][1] - a[0][1] * a[1][0]);
	} else {
		for(int k = 0 ; k < order ; k++) {
			int y = 0;
			for(int i = 1; i < order; i++) {
				int x = 0;
				for(int j = 0; j < order ; j++) {
					if(j != k) {
						tempMat[y][x] = a[i][j];
						x++;
					}
				}
				y++;
			}
			result = result + a[0][k] * pow(-1, k) * determinant(order - 1, tempMat);
		}
		return result;
	}
}	 


void cofactor(int order, float a[order][order]) {
	float tempMat[order-1][order-1];
	float cofact[order][order];
	for(int k = 0 ; k < order ; k++) {
		for(int l = 0 ; l < order ; l++) {
			int y = 0;
			for(int i = 0 ; i < order ; i++) {
				int x = 0;
				for(int j = 0 ; j < order ; j++) {
					if(i != k && j != l) {
						tempMat[y][x] = a[i][j];
						x++;
					}
				}
				if(i != k) y++;
			}
			
			cofact[k][l] = pow(-1, (k + l)) * determinant(order - 1, tempMat);
		}
	}
	copyMat(order, cofact, a);
}


void  inverse(int order, float a[order][order]) {
	float deter = determinant(order, a);
	cofactor(order, a);
	transpose(order, a);	
	for(int i = 0 ; i < order ; i++) {
		for(int j = 0 ; j < order ; j++) {
			a[i][j] /= deter;		
		}
	}
}


int main() {
	float yetAnotherMat[3][3] = {
						{3, 0, 2}, 
						{2, 0, -2}, 
						{0, 1, 1}};
	
	float mat[3][3] = {
						{6, 1, 1}, 
						{4, -2, 5}, 
						{2, 8, 7}};
						
	float largeMat[4][4] = {
						{1, 0, 2, -1}, 
						{0, 1, 0, -1},
						{0, 0, -6, 8},
						{0, 0, 0 , 5}};
	
	inverse(3, yetAnotherMat);

	for(int i = 0 ; i < 3 ; i++) {
		for(int j = 0 ; j < 3 ; j++) {
			printf("%.2f  ", yetAnotherMat[i][j]);
		}
		printf("\n");
	}	
	
	return 0;
}
