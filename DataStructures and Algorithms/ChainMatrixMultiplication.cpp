// Chirag Singh Rajput
// Chain Matrix Multiplication

#include<iostream>

int main() {
	int n;
	std :: cout << "Enter The Number Of Martrix : ";
	std :: cin >> n;	
	
	int p[n+1];
	int m[n+1][n+1] = {0};
	int s[n+1][n+1] = {0};
	
	 
	for(int i = 0 ; i <= n ; i++) {
		std :: cout << "Enter P[" << i << "]: ";
		std :: cin >> p[i];
	}
	
	for(int d = 1 ; d < n ; d++) {
		for(int i = 1 ; i < n - d  + 1; i++) {
			int j = i + d;
			int min = 32767;
			for(int k = i; k < j ; k++) {
				int q = m[i][k] + m[k+1][j] + p[i-1] * p[k] * p[j];
				if(q < min) {
					min = q;
					s[i][j] = k;
				}
  			}
  			m[i][j] = min;
		} 	
	}
	
//	for(int i = 0 ; i <= n  ; i++) {
//		for(int j = 0 ; j <= n ; j++) {
//			std :: cout << m[i][j] << " ";
//		}
//		std :: cout << std :: endl;
//	}
	std :: cout << "Minimum Operations: " << m[1][n]; 
	return 0; 
	
}
