#include<stdio.h>
#include<conio.h>
#include<graphics.h>
void sc(int x,int y,int side) {
	int sub = side/3;
	rectangle(x,y,x+side,y+side);
	if(sub>1){
		sc(x-sub*2,y-sub*2,sub);
		sc(x+sub,y-sub*2,sub);
		sc(x+sub*4,y-sub*2,sub);
		sc(x-sub*2,y+sub,sub);
		sc(x-sub*2,y+sub*4,sub);
		sc(x+sub,y+sub*4,sub);
		sc(x+sub*4,y+sub*4,sub);
		sc(x+sub*4,y+sub,sub);
	}
}

void main () {
	int gd=DETECT,gm;
	initgraph(&gd, &gm, "C:\\TURBOC3\\BGI");
	sc(160, 160, 160);
	getch();
}
