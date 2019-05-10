#include<stdio.h>
#include<conio.h>
void main()
{
    int a[10][10], i, j, k=0, l=0, m, n; 
    clrscr(); 
    printf("\nROWS: "); 
    scanf("%d", &n); 
    printf("\nCOLS: "); 
    scanf("%d", &m); 
    printf("\nMatrix\n"); 
    for(i=0; i<n; i++) {           
        for(j=0; j<m; j++) {
            scanf("%d", &a[i][j]); 
        }
    }

    for(i=0; i<n; i++) {
        for(j=0; j<m; j++) {
            printf("%d ", a[i][j]); 
        }
        printf("\n");  
    }

    while(k<m&&l<n) {
        for(i=l; i<n; i++) {
            printf("%d ", a[k][i]); 
        }
        k++; 

        for(i=k; i<m; i++) {
            printf("%d ", a[i][n-1]); 
        }
        n--; 

        if(k<m) {
            for(i=n-1; i>=1; i--) {
                printf("%d ", a[m-1][i]); 
            }
            m--; 
        }
        if(l<n) {
            for(i=m; i>=k; i--) {
                printf("%d ", a[i][l]);     
            }
            l++; 
        }
    }
    getch(); 
}
