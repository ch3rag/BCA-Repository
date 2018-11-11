// CHIRAG SINGH RAJPUT
/*********/
/*	HEAP */
/*********/
/***************************************
NOTES :
EVERY PATH IN THE HEAP IS SORTED LIST.
The left and right child of node a[n]
will be a[2n+1] and a[2n+2].

FOR INSERTION : Insert the new element
at the end of the array and compare it
with it's parent. If it's greater than
it's parent then interchange them. Now
keep interchanging it until its parent
is greater than the inserted node.

FOR DELETION : Replace the last node with
the node to be deleted. If the replaced node
it less than it's parent and greater than it's
childs then it's at the right place. If it's
greater than it's parent then replace it
with it's parent. It parent is greater
then compare it with it's childs. If child
is greater then replace it with the
greater child.
IF THE REPLACED NODE IS GREATER THAN ITS
PARENTS, HEAD UP!
IF ITS SMALLER THAN ITS EITHER CHILD,
HEAD DOWN!
******************************************/
#include <stdio.h>
#include <conio.h>
#define HEAPSIZE 100
int a[HEAPSIZE], n;a

int find(int data)
{
    int i;
    for (i = 0; i < n; i++) {
        if (data == a[i])
            return i;
    }
    return -1;
}

void display()
{
    int i;
    if (n == 0) {
        printf("HEAP IS EMPTY!");
        return;
    }
    else
        for (i = 0; i < n; i++) {
            printf("A[%d] = %d\n ", i, a[i]);
        }
}
void insert(int data, int loc)
{
    int par;
    if (n == 0) {
        a[0] = data;
        return;
    }
    par = (loc - 1) / 2;
    while (data > a[par] && loc > 0) {
        a[loc] = a[par];
        loc = par;
        par = (loc - 1) / 2;
    }
    a[loc] = data;
}

void deletef(int loc)
{
    int par, left, right, temp;
    printf("a[loc] = %d a[n-1]= %d", a[loc], a[n - 1]);
    a[loc] = a[n - 1]; //REPLACED LAST NODE WITH THE DELETED NODE!

    n--; //DECREMENTED THE HEAP BY ONE!
    par = (loc - 1) / 2; //FIND ITS PARENT
    if (a[loc] > a[par]) { //IF ITS GREATER THAN ITS PARENT
        insert(a[loc], loc); //HEADING UP! WHICH IS SAME AS INSERTION!
        return; //NO NEED TO CHECK FUTHER
    }
    left = 2 * loc + 1; //LEFT CHILD
    right = 2 * loc + 2; //RIGHT CHILD

    while (a[loc] < a[right] || a[loc] < a[left]) {
        if (a[right] > a[left]) {
            temp = a[loc];
            a[loc] = a[right];
            a[right] = temp;
            loc = right;
        }
        else {
            temp = a[loc];
            a[loc] = a[left];
            a[left] = temp;
            loc = left;
        }
        left = 2 * loc + 1;
        right = 2 * loc + 2;
    }
}

int main()
{
    int ch, data, pos;
    while (1) {
        printf("HEAP\n\n");
        printf("1.INSERT\n");
        printf("2.DELETE\n");
        printf("3.DISPLAY\n");
        printf("4.EXIT\n");
        printf("\nENTER YOUR CHOICE  : ");
        scanf("%d", &ch);
        switch (ch) {
        case 1:
            printf("ENTER THE DATA TO BE INSERTED : ");
            scanf("%d", &data);
            insert(data, n);
            n++;
            break;
        case 2:
            printf("ENTER THE DATA TO BE DELETED : ");
            scanf("%d", &data);
            if ((pos = find(data)) != -1)
                deletef(pos);
            else
                printf("DATA NOT FOUND!");
            break;
        case 3:
            display();
            break;
        case 4:
            return 0;
        }
        getch();
    }
}
