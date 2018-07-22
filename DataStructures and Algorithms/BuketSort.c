// CHIRAG SINGH RAJPUT
// BUCKET SORT

#include <stdio.h> 
#define MAX 20

struct stacks {
    int stack[MAX];
    int top;
}
bucket[10], stack_main;

void initstack() {
    int i;
    for (i = 0; i < 10; i++) {
        bucket[i].top = -1;
    }
    stack_main.top = -1;
}

int popb(int place) {
    if (bucket[place].top == -1) {
        printf("BUCKET UNDERFLOW!");
    } else {
        return bucket[place].stack[bucket[place].top--];
    }
    return 0;
}

void pushb(int num, int place) {
    if (bucket[place].top == MAX - 1) {
        printf("BUCKET OVERFLOW");
    } else {
        bucket[place].stack[++bucket[place].top] = num;
    }
}

void push(int num) {
    if (stack_main.top == MAX - 1) {
        printf("STACK_MAIN OVERFLOW!");
    } else {
        stack_main.stack[++stack_main.top] = num;
    }
}

int pop() {
    if (stack_main.top == -1) {
        printf("STACK UNDERFLOW!");
    } else {
        return stack_main.stack[stack_main.top--];
    }
    return 0;
}

void RADIX(int a[MAX], int n) {
    int d, i, place = 1, num, temp = 0, passes = 0;
    for (i = 0; i < n; i++) { //CALCULATES MAX DIGITS
        num = a[i];
        while (num > 0) {
            temp++;
            num /= 10;
        }
        if (temp > passes) {
            passes = temp;
        }
        temp = 0;
    }
    for (i = 0; i < n; i++) { //PUSHES ARRAY ONTO STACK
        push(a[i]);
    }
    while (passes--) {
        while (stack_main.top != -1) { //PUSES STACK ONTO BUCKETS
            num = pop();
            d = (num % (10 * place)) / place;
            pushb(num, d);
        }
        for (i = 9; i >= 0; i--) { //POP BUCKETS AND PUSH BACK ONTO STACK
            while (bucket[i].top != -1) {
                push(popb(i));
            }
        }
        place *= 10;
    }
    i = 0;
    while (stack_main.top != -1) { //POP STACK AND OVERWRITE ARRAY
        a[i++] = pop();
    }
}

int main(int argc, char * argv[]) {
    int i, n, num, a[MAX];
    initstack();
    printf("ENTER N : ");
    scanf("%d", & n);
    for (i = 0; i < n; i++) {
        printf("ENTER ELEMENT A[%d]: ", i);
        scanf("%d", & a[i]);
    }
    RADIX(a, n);
    for (i = 0; i < n; i++) {
        printf("%d ", a[i]);
    }
    return 0;
}
