// ANALOG CLOCK
// CHIRAG SINGH RAJPUT

#include <stdio.h>
#include <conio.h>
#include <graphics.h>
#include <dos.h>
#include <math.h>
#define PI 3.1415926536

//HOUR INITAL POS
int inith(int s) {
  if (s <= 12)
    return s * 30;
  if (s > 12 && s <= 24)
    s -= 12;
  return s * 30;
}

//MIN SEC INITIAL POS
int init(int s) {
  return s * 6;
}
//DEG TO RAD
double rad(int deg) {
  return (180 + deg) * (PI / 180);
}
//MAIN
int main() {
  //DECLARATIONS
  int gd = DETECT, gm;
  int midx, midy, i, j, k;
  int mx1, mx2, my1, my2, mxt, myt;
  int sx1, sx2, sy1, sy2, sxt, syt;
  int hx1, hy1, hx2, hy2, hxt, hyt;
  struct time t;
  int sec, min, hour;
  initgraph( & gd, & gm, "C:\\BGI");
  midx = getmaxx() / 2;
  midy = getmaxy() / 2;
  gettime( & t);
  sec = t.ti_sec;
  min = t.ti_min;
  hour = t.ti_hour;
  //DECLARATION ENDS
  //DEFINITIONS FOR SECOND HAND
  sx1 = midx;
  sy1 = midy;
  sx2 = midx;
  sy2 = (midy * 1.4 - midy);
  // DEFINITIONS FOR MINUTE HAND
  mx1 = midx;
  my1 = midy;
  mx2 = midx;
  my2 = (midy * 1.5 - midy);
  //DEFINITIONS FOR HOUR HAND
  hx1 = midx;
  hy1 = midy;
  hx2 = midx;
  hy2 = (midy * 1.6 - midy);
  // LOOPS
  for (k = inith(hour); k <= 360; k += 6) {
    hxt = hx1 + ((hx2 - hx1) * cos(rad(k)) - (hy1 - hy2) * sin(rad(k)));
    hyt = hy1 + ((hx2 - hx1) * sin(rad(k)) + (hy1 - hy2) * cos(rad(k)));
    for (j = init(min); j <= 360; j += 6) {
      mxt = mx1 + ((mx2 - mx1) * cos(rad(j)) - (my1 - my2) * sin(rad(j)));
      myt = my1 + ((mx2 - mx1) * sin(rad(j)) + (my1 - my2) * cos(rad(j)));
      for (i = init(sec); i <= 360; i += 6) {
	sxt = sx1 + ((sx2 - sx1) * cos(rad(i)) - (sy1 - sy2) * sin(rad(i)));
	syt = sy1 + ((sx2 - sx1) * sin(rad(i)) + (sy1 - sy2) * cos(rad(i)));
	setcolor(CYAN);
	line(sx1, sy1, sxt, syt);
	line(mx1, my1, mxt, myt);
	line(hx1, hy1, hxt, hyt);
	setcolor(RED);
	circle(midx, midy, 170);
	settextstyle(3, 0, 1);
	setcolor(BLUE);
	outtextxy(midx * 1.48, midy - 10, "3");
	outtextxy(midx * 1.49 - midx, midy - 10, "9");
	outtextxy(midx - 5, midy * 1.61, "6");
	outtextxy(midx - 10, midy * 1.3 - midy, "12");
	setcolor(RED);
	outtextxy(midx - 70, 15, "ANALOG CLOCK");
	outtextxy(midx - 95, getmaxy() - 40, "Press Any Key to Exit!");
	settextstyle(3, 1, 1);
	outtextxy(15, midy - 50, "BY CHIRAG");
	rectangle(10, 10, getmaxx() - 10, getmaxy() - 10);
	setbkcolor(WHITE);
	sec = 0;
	min = 0;
	hour = 0;
	delay(1000);
	cleardevice();
	if (kbhit())
	  exit(0);
      }
    }
  }
  return 0;
}
