// CHIRAG SINGH RAJPUT
// PARALLEL IO USING DELAYS AND CURSOR MOVEMENT
// COMPATIBLE WITH TURBO C++

#
include < iostream.h > #include < conio.h > #include < fstream.h > #include < string.h > #include < dos.h > #define DELAY 100
class INFO {
    public: void getDetails();
};

void drawLine() {
    for (int i = 0; i < 80; i++) {
        cout << "_";
    }
}

void INFO::getDetails() {
    fstream file;
    file.open("DETAILS.TXT", ios:: in | ios::out | ios::trunc);
    char bufferIn[100], bufferOut[200] = {
        '\0'
    };
    char ch = '\0';
    int f = 0, x = 0, y = 0, x_ = 1, y_ = 18, length = 0;
    char details[6][50] = {
        "ENTER ID : ",
        "ENTER NAME : ",
        "ENTER AGE :  ",
        "ENTER GENDER : ",
        "ENTER ADDRESS : ",
        "ENTER PHONE : ",
    };
    char details_[6][30] = {
        "ID : ",
        "NAME : ",
        "AGE :  ",
        "GENDER : ",
        "ADDRESS : ",
        "PHONE : ",
    };
    drawLine();
    cout << endl << "INPUT DETAILS :" << endl;
    drawLine();
    gotoxy(1, 13);
    drawLine();
    cout << endl << "FILE OUTPUT :" << endl;
    drawLine();
    gotoxy(1, 5);
    for (int i = 0; i < 6; i++) {
        int j = 0;
        cout << endl << details[i];
        x = wherex();
        y = wherey();
        while (ch != 13) {
            if (kbhit()) {
                gotoxy(x, y);
                ch = getch();
                if (ch == 8 && j > 0) {
                    j--;
                    cout << ch << ' ' << ch;
                }
                if (ch != 8) {
                    bufferIn[j++] = ch;
                    cout << ch;
                }
            }
            x = wherex();
            y = wherey();
            gotoxy(x_, y_);
            while (!kbhit() && bufferOut[f] != '\0') {
                delay(DELAY);
                cout << bufferOut[f++];
                if (bufferOut[f] == '\n') {
                    y_++;
                    x_ = -1;
                }
                x_++;
            }
            gotoxy(x, y);
        }
        bufferIn[j] = '\0';
        ch = '\0';
        file << details_[i] << bufferIn << endl;
        delete[] bufferOut;
        delete[] bufferIn;
        length += strlen(details_[i]) + j;
        file.seekp(0, file.beg);
        file.read(bufferOut, length);
        file.seekp(0, file.end);
        bufferOut[length] = '\0';
    }
    gotoxy(x_, y_);
    while (bufferOut[f] != '\0') {
        delay(DELAY);
        if (bufferOut[f] == '\n') {
            y_++;
            x_ = -1;
        }
        cout << bufferOut[f++];
        x_++;
    }
}

int main(int argc, char * argv[]) {
    INFO obj;
    clrscr();
    obj.getDetails();
    getch();
    return 0;
}
