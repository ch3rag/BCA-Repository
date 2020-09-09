/***********************************************************************
*                     Author: Bharat Singh Rajput                      *
*               Last Updated: September 9, 2020 01:50 PM               *
*                    File Name: Sierpinski Carpet.C                    *
*                          Source Language: c                          *
*       Repository: http://github.com/ch3rag/bca-repository.git        *
*                                                                      *
*                       --- Code Description ---                       *
*                          Sierpinski Carpet                           *
***********************************************************************/

#include <stdio.h>
#include <conio.h>
#include <graphics.h>

void sc(int x, int y, int side) {
    int sub = side / 3;
    rectangle(x, y, x + side, y + side);
    if (sub > 1) {
        sc(x - sub * 2, y - sub * 2, sub);
        sc(x + sub, y - sub * 2, sub);
        sc(x + sub * 4, y - sub * 2, sub);
        sc(x - sub * 2, y + sub, sub);
        sc(x - sub * 2, y + sub * 4, sub);
        sc(x + sub, y + sub * 4, sub);
        sc(x + sub * 4, y + sub * 4, sub);
        sc(x + sub * 4, y + sub, sub);
    }
}

void main() {
    int gd = DETECT, gm;
    initgraph( & gd, & gm, "C:\\TURBOC3\\BGI");
    sc(160, 160, 160);
    getch();
}