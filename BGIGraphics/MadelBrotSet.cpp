// CHIRAG SINGH RAJPUT
// MADELBROTSET 

#include<conio.h>
#include<graphics.h>
#include<math.h>
#include<stdlib.h>

double map(double n, double min, double max, double mapmin, double mapmax) {
	
	double delta = (mapmax - mapmin) / (max - min);
	return (mapmin + delta * (n - min));
}
	
int main(int argc, char * argv[]) {
	
	int gd = DETECT,gm;
	initgraph(&gd, &gm, "C:\\TC\\BGI");
	int maxx, maxy;
	double cx = 1.9;
 	double cy = 1.5;
 	int maxiterations = 300;
	maxx = getmaxx();
	maxy = getmaxy();
	for(int i =0 ; i < maxx; i++) {
		for(int j = 0 ; j < maxy; j++) {
			
			int px = i;
	 		int py = j;
	 		double a = map(px,0,maxx,-cx,cx);
	 		double b = map(py,0,maxy,-cy,cy);
	 		double z = 0;
	 		double b_ = b;
			double a_ = a;
			int k;
			for(k = 0 ; k < maxiterations ; k++) {
				
				double aa = (a * a) - (b * b);
				double bb = (2 * a * b);	
				a = aa + a_;
				b = bb + b_;
				z = a + b;	
				if(abs(z) > 4) {				
					break;
				}
			}
			if(k == maxiterations){
				putpixel(px, py, BLACK);
			} else {
				putpixel(px,py, map(k,0,maxiterations,0,16));
			}
		}
	}
	getch();
	closegraph();
	return 0;
}
