// CHIRAG SINGH RAJPUT
// DEMONSTRATION ON PENDULUM 

#include <graphics.h>
#include <iostream>
#include <math.h>
#define GRAVITY 0.1
#define PI 3.14159

class Pendulum {
	public :
	float x;
	float y;
	float length;
	float mass;
	float angle;
	float angularVelocity;
	float angularAcceleration;
	
	public : Pendulum(float x, float y, float legth, float mass);
	public : void draw();
	public : void update();
};

Pendulum :: Pendulum(float x, float y, float length, float mass) {

	this->x = x;
	this->y = y;
	this->length = length;
	this->mass = mass;
	angle = 0;
	angularAcceleration = 0;
	angularVelocity = 0;
	std :: cout << "Pendulum: " << this->x << " " << this->y;
}

void Pendulum :: draw() {
	
	float x2 = x + length * cos(angle);
	float y2 = y + length * sin(angle);
	line(x, y, x2, y2);
	circle(x2, y2, mass);
	floodfill(x2, y2, WHITE);
}

void Pendulum :: update() {
	
	angularAcceleration = (GRAVITY * sin(angle + PI/2))/length;	
	angularVelocity += angularAcceleration;
	angle += angularVelocity;
		
}

int main(int argc, char * argv[]) {
		
	int gd = DETECT, gm;
	initgraph(&gd, &gm, "C:\\TC\\BGI");
	Pendulum pendulum(getmaxx()/2, 10, 200, 10);
	pendulum.draw();
	
	while(1) {
		pendulum.update();
		cleardevice();
		pendulum.draw();
		// TO DEMONSTRATE EFFECT OF LENGTH ON TIME PERIOD
		if(kbhit()) {
			switch(getch()) {
				case 'x' : exit(0); break;
				case '=' : pendulum.length++; break;
				case '-' : pendulum.length--; break;
 			}
		}
	}
	
	getch();
	closegraph();
	return 0;
	
}
