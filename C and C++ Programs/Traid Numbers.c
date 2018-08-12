// Chirag Singh Rajput

/*

write a program to print triad numbers. any three numbers will be triad numbers if they satisfy the following conditions.
1) each number is a three number.
2) all the digits in the three numbers(total 9 digits) should be different.
3) if a,b,c are triad numbers them, b = a * 2 and c = a * 3
	e.g:
	219 438 657
	267 534 801
*/

#include <stdio.h>

    int main(int argc, char * argv[]) {
    	
        int triads[3], flag = 1;
        printf("Enter Three Numbers : \n");
        for(int i = 0 ; i < 3 ; i++) {
        	scanf("%d", &triads[i]);
		}
		
		if(triads[1] != triads[0] * 2 || triads[2] != triads[0] * 3) {
			flag = 0;
		}   
		if(flag == 1) {
			for(int i = 0 ; i < 3 ; i++) {
				if(triads[i] < 100 || triads[i] > 999) {
					flag = 0;
					break;
				}
			}
		}
		
		if(flag == 1) {
			
			int digits[10] = {0};
			for(int i = 0 ; i < 3 ; i++) {
				while(triads[i] > 0) {
					int digit = triads[i] % 10;
					if(digits[digit] != 0) {
						flag = 0;
						break;
					} else {
						digits[digit] = 1;
					}
					triads[i] /= 10;
				}
			}
		}
	
        if (flag == 0)
            printf("Numbers Not Triad!");
        else
            printf("Numbers Are Triad!");
   		return 0;
    }
