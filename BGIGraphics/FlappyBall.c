// CHIRAG SINGH RAJPUT
// FLAPPY BALL (FLAPPY BIRD CLONE)

#include <graphics.h>
#include <stdio.h>
#include <conio.h>
#include <dos.h>
#include <stdlib.h>

float gravity = 0.4;

void run();
void draw();
void update();
void check();
int maxy, maxx, score, t;
void generatepipe(int);
void drawpipe();
void updatepipe();
struct pipe {
  int x;
  int y;
} pipe[2] = {{0, 0}, {-20, 0}};

struct ball {
  int y;
  int x;
  float yspeed;
  int direction;
} ball = {0, 0, 1};

void generatepipe(int i) {
  randomize();
  t = (maxy - maxy / 9) / 4;
  pipe[i].x = maxx;
  pipe[i].y = rand() % t + t;
}
void drawpipe() {
  int i;
  for (i = 0; i < 2; i++) {
    rectangle(pipe[i].x + 20, 0, pipe[i].x, pipe[i].y);
    rectangle(pipe[i].x + 20, maxy - pipe[i].y, pipe[i].x, maxy);
  }
}
void updatepipe() {
  int i;
  for (i = 0; i < 2; i++)
    pipe[i].x--;
}
void check() {
  int i, temp;
  for (i = 0; i <= 0; i++) {
    if (pipe[i].x < ball.x && pipe[i].y > ball.y ||
        pipe[i].x < ball.x && ball.y > maxy - pipe[i].y) {

      outtextxy(maxx / 2, maxy / 2, "GAME OVER");
      printf("SCORE  = %d", score);
      getch();
      delay(2000);
      exit(0);
    }
  }
  if (pipe[0].x == maxx / 2)
    generatepipe(1);
  if (pipe[0].x < 0) {
    score++;
    pipe[0].x = pipe[1].x;
    pipe[0].y = pipe[1].y;
    generatepipe(1);
  }

  if (ball.y > maxy) {
    ball.y = maxy;
    ball.yspeed = 0;
  } else if (ball.y < 0) {
    ball.y = 0;
    ball.yspeed = 0;
  }
}

void update() {
  char c;
  if (kbhit()) {
    c = getch();
    if (c == 'w') {
      if (ball.yspeed > -5 || ball.yspeed == 0)
        ball.yspeed -= 7;
    } else if (c == 'x')
      exit(0);
  } else {
    ball.y += ball.yspeed;
    ball.yspeed += gravity;
  }
}

void draw() {
  circle(ball.x, ball.y, 20);
  // floodfill(ball.x,ball.y,WHITE);
}

void run() {
  int i;
  generatepipe(0);
  while (1) {
    cleardevice();
    draw();
    drawpipe(0);
    drawpipe(1);
    delay(10);
    check();
    update();
    updatepipe();
    // delay(20);
    // cleardevice();
  }
}

void main() {
  int gd = DETECT, gm;
  initgraph(&gd, &gm, "C:\\TURBOC3\\BGI");
  ball.x = 50;
  ball.y = 10;
  maxy = getmaxy();
  maxx = getmaxx();
  run();
  getch();
  closegraph();
}
