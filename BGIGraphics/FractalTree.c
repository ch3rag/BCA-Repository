// Fractal Tree
// Chirag Singh Rajput 

#include <stdio.h>
#include <conio.h>
#include <graphics.h>
#include <stdlib.h>
#include <math.h>
#define PI 3.14159
int width, height;

void branch(float x, float y, float length, float angle) {
	float x2 = x + length * cos(angle);
	float y2 = y + length * sin(angle);
	line(x, y, x2, y2);
	if(length > 10) {
		branch(x2, y2, length * 0.7, angle + PI/6);
		branch(x2, y2, length * 0.7, angle - PI/6);
	}
}

void main() {

	int gd = DETECT, gm;
	initgraph(&gd, &gm, "C:\\BGI");
	width = getmaxx();
	height = getmaxy();
	branch(width/2, height, 120, -PI/2);
	getch();
	closegraph();

}
