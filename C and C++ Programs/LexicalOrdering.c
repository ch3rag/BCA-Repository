// CHIRAG SINGH RAJPUT
// LEXICAL ORDERING

#include <stdio.h>
#include <string.h>

int main(int argc, char * argv[]) {
	
	char words[8][20], temp[20];
	
	strcpy(words[0], "aaacc");
	strcpy(words[1], "aaaaa");
	strcpy(words[2], "aaaba");
	strcpy(words[3], "aaa");
	strcpy(words[4], "aacca");
	strcpy(words[5], "b");
	strcpy(words[6], "aac");
	strcpy(words[7], "bbbaa");
	
	for(int i = 0 ; i < 7 ; i++) {
		for(int j = i + 1 ; j < 8 ; j++) {
			int k = 0;
			while(1) {
				if(words[i][k] > words[j][k]) {
					strcpy(temp, words[i]);
					strcpy(words[i], words[j]);
					strcpy(words[j], temp);
					break;
				} else if(words[i][k] < words[j][k]) {
					break;
				}
				k++;
			}
		}
	}
	
	for(int i = 0 ; i < 8 ; i++) {
		puts(words[i]);
	}
	return 0;
}
