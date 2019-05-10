#include<stdio.h>
#include<conio.h>
void main()
{
  int a[100][100]={0}, i, j, o, c=1; 
  clrscr(); 
  printf("Enter Order Of Matrix : "); 
  scanf("%d", &o); 
  for(i=0; i<o; i++) {
    for(j=i; j<o-i; j++) {
      a[i][j]=c++; 
    }
    for(j=i+1; j<=o-i-1; j++) {
      a[j][o-i-1]=c++;  
    }
    for(j=o-i-2; j>i; j--) {
      a[o-i-1][j]=c++; 
    }
    for(j=o-i-1; j>i; j--) {
      a[j][i]=c++; 
    }
  }
  for(i=0; i<o; i++) {
    for(j=0; j<o; j++) {
      printf("%d ", a[i][j]); 
    }
    printf("\n"); 
  }
  getch(); 
}