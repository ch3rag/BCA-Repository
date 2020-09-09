/***********************************************************************
*                     Author: Bharat Singh Rajput                      *
*               Last Updated: September 9, 2020 01:51 PM               *
*                   File Name: StarFieldSimulator.c                    *
*                          Source Language: c                          *
*       Repository: http://github.com/ch3rag/bca-repository.git        *
*                                                                      *
*                       --- Code Description ---                       *
*                         Star Field Simulator                         *
***********************************************************************/

#include <stdio.h>
#include <graphics.h>
#include <conio.h>
#include <stdlib.h>

#define NUM 500

int maxx, maxy;
float map(float, float, float, float, float);
struct stars {
    int x;
    int y;
    int px;
    int py;
}

stars[NUM];
void drawstars() {
    int i;
    for (i = 0; i < NUM; i++) {
        putpixel(stars[i].x, stars[i].y, BLUE);
        setcolor(i % 10);
        line(stars[i].px, stars[i].py, stars[i].x, stars[i].y);
    }
}

float map(float x, float u1, float v1, float u2, float v2) {
    return x * ((v2 - u2) / (v1 - u1)) + u2;
}

void updatestar() {
    int xspeed, yspeed, i;
    for (i = 0; i < NUM; i++) {
        xspeed = map(stars[i].x, 0, maxx, -15, 15);
        yspeed = map(stars[i].y, 0, maxy, -15, 15);
        if (stars[i].x < maxx && stars[i].x > 0 && stars[i].y < maxy &&
            stars[i].y > 0) {
            stars[i].px = stars[i].x;
            stars[i].py = stars[i].y;
        }
        stars[i].x += xspeed;
        stars[i].y += yspeed;
        if (xspeed == 0 && yspeed == 0) {
            stars[i].x = map(stars[i].x, -15, 15, maxx / 2 + 2, maxx / 2 - 2);
            stars[i].y = map(stars[i].y, -15, 15, maxy / 2 + 2, maxy / 2 - 2);
            stars[i].px = stars[i].x;
            stars[i].py = stars[i].y;
        }
        if (stars[i].x > maxx || stars[i].x < 0 || stars[i].y > maxy ||
            stars[i].y < 0) {
            stars[i].x = rand() % maxx;
            stars[i].y = rand() % maxy;
            stars[i].px = stars[i].x;
            stars[i].py = stars[i].y;
        }
    }
}

void run() {
    while (1) {
        if (kbhit()) exit(0);
        drawstars();
        updatestar();
        delay(40);
        cleardevice();
    }
}

void main() {
    int gd = DETECT, gm;
    int i;
    initgraph( & gd, & gm, "C:\\BGI");
    randomize();
    maxx = getmaxx();
    maxy = getmaxy();
    for (i = 0; i < NUM; i++) {
        stars[i].x = rand() % maxx;
        stars[i].y = rand() % maxy;
    }
    run();
    getch();
}