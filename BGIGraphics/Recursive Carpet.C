/***********************************************************************
*                     Author: Bharat Singh Rajput                      *
*               Last Updated: September 9, 2020 01:42 PM               *
*                    File Name: Recursive Carpet.C                     *
*                          Source Language: c                          *
*       Repository: http://github.com/ch3rag/bca-repository.git        *
*                                                                      *
*                       --- Code Description ---                       *
*                     Cool Recusive Carpet Pattern                     *
***********************************************************************/

#include <stdio.h>
#include <conio.h>
#include <graphics.h>

int maxx, maxy;
void sc(float left, float top, float right, float bottom) {
    rectangle(left + (right - left) / 3, top + (bottom - top) / 3, right - (right - left) / 3, bottom - (bottom - top) / 3);
    if (left < right - 1 || top < bottom - 1) {
        sc(left, top, right - (right - left) / 1.5, bottom - (bottom - top) / 1.5);
        sc(left + (right - left) / 1.5, top + (bottom - top) / 1.5, right, bottom);
        sc(left + (right - left) / 1.5, top, right, bottom - (bottom - top) / 1.5);
        sc(left, top + (bottom - top) / 1.5, right - (right - left) / 1.5, bottom);
        sc(left + (right - left) / 1.5, top, right - (right - left) / 1.5, bottom - (bottom - top) / 1.5);
        sc(left, top + (bottom - top) / 1.5, right - (right - left) / 1.5, bottom - (bottom - top) / 1.5);
        sc(left + (right - left) / 1.5, top + (bottom - top) / 1.5, right, bottom - (bottom - top) / 1.5);
        sc(left + (right - left) / 1.5, top + (bottom - top) / 1.5, right - (right - left) / 1.5, bottom);
    }
}

void main() {
    int gd = DETECT, gm;
    initgraph( & gd, & gm, "C:\TURBOC3\\BGI");
    maxx = getmaxx();
    maxy = getmaxy();
    rectangle(80, 0, 560, maxy);
    sc(80, 0, 560, maxy);
    getch();
}