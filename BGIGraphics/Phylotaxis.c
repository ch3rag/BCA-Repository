/***********************************************************************
*                     Author: Bharat Singh Rajput                      *
*               Last Updated: September 9, 2020 01:41 PM               *
*                       File Name: Phylotaxis.c                        *
*                          Source Language: c                          *
*       Repository: http://github.com/ch3rag/bca-repository.git        *
*                                                                      *
*                       --- Code Description ---                       *
*                     Phylotaxis Pattern Generator                     *
***********************************************************************/

#include <graphics.h>
#include <conio.h>
#include <stdio.h>
#include <dos.h>
#include <stdlib.h>
#include <math.h>

#define PI 3.14159

double rad(int deg) {
    return (deg * PI) / 180;
}

int main() {
    int gd = DETECT, gm;
    int c = 6, r = 0, n = 1, midx, midy, i, x, y;
    initgraph( & gd, & gm, "C:\\TURBOC3\\BGI");
    midx = getmaxx() / 2;
    midy = getmaxy() / 2;
    for (i = 0; i < 1000; i++) {
        r = c * sqrt(n);
        x = r * cos(rad(n * 137.4));
        y = r * sin(rad(n * 137.4));
        setfillstyle(1, i % 20 + 1);
        setcolor(i % 20 + 1);
        circle(x + midx, y + midy, 2);
        floodfill(x + midx, y + midy, i % 20 + 1);
        n++;
    }
    getch();
    closegraph();
    return 0;
}