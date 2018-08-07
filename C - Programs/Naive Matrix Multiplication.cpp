// NAIVE METHOD FOR MATRIX MULTIPLICATION
// CHIRAG SINGH RAJPUT

#include <iostream>


int main() {
	
	int r1,r2,c1,c2;
	
	std :: cout << "Enter Rows of Matrix A : ";
	std :: cin >> r1;
	std :: cout << "Enter Columns of Matrix A : ";
	std :: cin >> c1;
	
	std :: cout << "Enter Rows of Matrix B : ";
	std :: cin >> r2;
	std :: cout << "Enter Columns of Matrix B : ";
	std :: cin >> c2;
	
	if(c1 != r2) {
		std :: cout << "Multication not possible!";
		return 0;
	}
	
	int a[r1][c1];
	int b[r2][c2];
	int c[r1][c2];
	
	std :: cout << "Enter Matrix A :" << std :: endl;
	for(int i = 0 ; i < r1 ; i++) {
		for(int j = 0 ; j < c1 ; j++) {
			std :: cin >> a[i][j];
		}
	}
	
	std :: cout << "Enter Matrix B :" << std :: endl;
	for(int i = 0 ; i < r2 ; i++) {
		for(int j = 0 ; j < c2 ; j++) {
			std :: cin >> b[i][j];
		}
	}
	
	for(int i = 0 ; i < r1 ; i++) {
		for(int j = 0 ; j < c2 ; j++) {
			c[i][j] = 0;
			for(int k = 0 ; k < c1 ; k++) {
				c[i][j] += a[i][k] * b[k][j];				
			}
		}
	}
	
	std :: cout << std :: endl << "Result:" << std :: endl;
	for(int i = 0 ; i < r1 ; i++) {
		for(int j = 0 ; j < c2 ; j++) {
			std :: cout << c[i][j] << "  ";	
		}
		
		std :: cout << std :: endl;
	}
	return 0;
}
