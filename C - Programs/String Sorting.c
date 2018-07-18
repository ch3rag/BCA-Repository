// Chirag Singh Rajput
// String Sorting

#include <stdio.h> 
#include <string.h>

int main(int argc, char * argv[]) {
    char s[3][10], temp[10];
    int i, j, k = 0;
    printf("Enter Three Strings : \n");
    for (i = 0; i < 3; i++)
        gets(s[i]);
    for (i = 0; i < 3; i++) {
        for (j = i + 1; j < 3; j++) {     	
            k = 0;
            if (s[i][0] > s[j][0]) {
                strcpy(temp, s[i]);
                strcpy(s[i], s[j]);
                strcpy(s[j], temp);
            } //If
            if (s[i][0] == s[j][0]) {
                while (s[i][k] == s[j][k]) {
                    k++;
                    if (s[i][k] > s[j][k]) {
                        strcpy(temp, s[i]);
                        strcpy(s[i], s[j]);
                        strcpy(s[j], temp);
                    } //if
                } //while
            } //if
        } //for
    } //for
    for (i = 0; i < 3; i++)
        puts(s[i]);
}
