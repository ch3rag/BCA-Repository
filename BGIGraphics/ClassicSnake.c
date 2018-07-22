// CHIRAG SINGH RAJPUT
// CLASSIC SNAKE GAME

#include <iostream> 
#include <conio.h > 
#include <graphics.h > 
#include <cstdlib> 
#include <dos.h> 
#include <time.h>

class Map {
    int mapx;
    int mapy;
    public: void initmap();
    public: void drawmap();
    friend void run();
};

void Map::initmap() {
    mapx = 300;
    mapy = 300;
}

void Map::drawmap() {
    rectangle(0, 0, mapx, mapy);
}

class Food {
    public: int x;
    int y;
    void generatefood();
    void drawfood();
};

void Food::generatefood() {
    x = rand() % 28 + 1;
    y = rand() % 28 + 1;
}

void Food::drawfood() {
    circle(x * 10, y * 10, 5);
    floodfill(x * 10, y * 10, WHITE);
}

class Snake {
    public: int headx;
    int heady;
    int direction;
    int length;
    int snake_body[30][30];
    void initsnake();
    void drawsnake();
    int updatesnake_nokey();
    void updatesnake_key(char);
    void eat();
};

void Snake::updatesnake_key(char ch) {
    if (ch == 's' && direction != 3) {
        direction = 1;
    } else if (ch == 'a' && direction != 0) {
        direction = 2;
    } else if (ch == 'w' && direction != 1) {
        direction = 3;
    } else if (ch == 'd' && direction != 2) {
        direction = 0;
    }
}

int Snake::updatesnake_nokey() {

    for (int i = 0; i < 30; i++) {
        for (int j = 0; j < 30; j++) {
            if (snake_body[i][j] != 0) {
                snake_body[i][j]--;
            }
        }
    }
    if (direction == 0 && snake_body[heady][headx + 1] == 0) {
        snake_body[heady][headx + 1] = length;
        headx += 1;
    } else
    if (direction == 1 && snake_body[heady + 1][headx] == 0) {
        snake_body[heady + 1][headx] = length;
        heady += 1;
    } else
    if (direction == 2 && snake_body[heady][headx - 1] == 0) {
        snake_body[heady][headx - 1] = length;
        headx -= 1;
    } else
    if (direction == 3 && snake_body[heady - 1][headx] == 0) {
        snake_body[heady - 1][headx] = length;
        heady -= 1;
    } else return -1;
}

void Snake::initsnake() {
    headx = 15;
    heady = 15;
    direction = 0;
    length = 5;
    for (int i = 0; i < 30; i++) {
        for (int j = 0; j < 30; j++) {
            snake_body[i][j] = 0;
        }
    }
    for (int i = length; i >= 0; i--) {
        snake_body[15][15 - i] = length - i;
    }
}

void Snake::drawsnake() {
    for (int i = 0; i < 30; i++) {
        for (int j = 0; j < 30; j++) {
            if (snake_body[i][j] > 0) {
                rectangle(j * 10 - 5, i * 10 - 5, j * 10 + 5, i * 10 + 5);
            }
        }
    }
    floodfill(headx * 10, heady * 10, WHITE);
}

void run() {
    Map m;
    Food f;
    Snake s;
    m.initmap();
    m.drawmap();
    f.generatefood();
    f.drawfood();
    s.initsnake();
    s.drawsnake();
    while (1) {
        if (kbhit()) {
            s.updatesnake_key(getch());
        }
        if (s.headx == f.x && s.heady == f.y) {
            s.length++;
            f.generatefood();
            continue;
        }
        if ((s.updatesnake_nokey() == -1) || (s.headx >= 30 || s.heady >= 30 || s.headx < 0 || s.heady < 0)) {
            outtextxy(getmaxx() / 2, getmaxy() / 2, "GAME OVER!");
            std::cout << "SCORE : " << s.length - 5;
            getch();
            exit(0);
        }
        delay(100);
        cleardevice();
        m.drawmap();
        f.drawfood();
        s.drawsnake();
    }
}

int main(int argc, char * argv[]) {
    int gd = DETECT, gm;
    initgraph( & gd, & gm, "C:\\TC\\BGI");
    srand(time(0));
    run();
    closegraph();
    getch();
}
