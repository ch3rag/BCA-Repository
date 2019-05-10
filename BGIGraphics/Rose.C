#include<stdio.h>
#include<conio.h>
#include<graphics.h>
#include<math.h>
#include<stdlib.h>
#define PI 3.14159

float rad(int deg) {
 return (deg*PI)/180;
}
void main() {
    int gd=DETECT,gm;
    float a=100,n=7,d=1,k,midx,midy,i,x,y,px,py;
    initgraph(&gd,&gm,"C:\\TURBOC3\\BGI");
    x = midx = getmaxx()/2;
    y = midy = getmaxy()/2;
    k = n / d;
    for(i=0;i<=360;i+=1){
        px = x;
        py = y;
        x = a*cos(rad(k*i))*cos(rad(i))+midx;
        y = a*cos(rad(k*i))*sin(rad(i))+midy;
        if(i==0) 
            continue;
        line(px,py,x,y);
        if(kbhit())
            exit(0);
    }
getch();
}