// CHIRAG SINGH RAJPUT 
/*******\
AVL TREES
\*******/

#include <stdio.h>
#include <conio.h>
#include <stdlib.h>
typedef enum { FALSE, TRUE } boolean;
struct node {
  int data;
  int balance;
  struct node *lchild;
  struct node *rchild;
} * root;
struct node *search(int data, struct node *temp) {
  if (temp != NULL) {
    if (data < temp->data)
      temp = search(data, temp->lchild);
    else if (data > temp->data)
      temp = search(data, temp->rchild);
  }
  return temp;
}
void inorder(struct node *temp) {
  if (root == NULL) {
    printf("TREE IS EMPTY!");
    return;
  }
  if (temp != NULL) {
    inorder(temp->lchild);
    printf("%d ", temp->data);
    inorder(temp->rchild);
  }
}

void display(struct node *temp, int level) {
  int i;
  if (temp != NULL) {
    display(temp->rchild, level + 1);
    printf("\n");
    for (i = 0; i < level; i++) {
      printf(" ");
    }
    printf("%d", temp->data);
    display(temp->lchild, level + 1);
  }
}
// AVL INSERTION MODULE//
struct node *insert(int data, struct node *pptr, int *height) {
  struct node *aptr, *bptr;
  if (pptr == NULL) {
    pptr = malloc(sizeof(struct node));
    pptr->lchild = NULL;
    pptr->rchild = NULL;
    pptr->data = data;
    pptr->balance = 0;
    *height = TRUE;
    return (pptr);
  }
  if (data < pptr->data) {
    pptr->lchild = insert(data, pptr->lchild, height);
    if (*height == TRUE) {
      switch (pptr->balance) {
      case -1:
        pptr->balance = 0;
        *height = FALSE;
        break;
      case 0:
        pptr->balance = 1;
        break;
      case 1:
        aptr = pptr->lchild;
        if (aptr->balance == 1) {
          printf("LEFT TO LEFT ROTATION");
          pptr->lchild = aptr->rchild;
          aptr->rchild = pptr;
          aptr->balance = 0;
          pptr->balance = 0;
          pptr = aptr;
        } else {
          printf("LEFT TO RIGHT ROTATION");
          bptr = aptr->rchild;
          aptr->rchild = bptr->lchild;
          bptr->lchild = aptr;
          pptr->lchild = bptr->rchild;
          bptr->rchild = pptr;
          if (bptr->balance == -1) {
            pptr->balance = 0;
            aptr->balance = 1;
          } else {
            pptr->balance = -1;
            aptr->balance = 0;
          }
          bptr->balance = 0;
          pptr = bptr;
        }
        *height = FALSE;
      }
    }
  }
  if (data > pptr->data) {
    pptr->rchild = insert(data, pptr->rchild, height);
    if (*height == TRUE) {
      switch (pptr->balance) {
      case 0:
        pptr->balance = -1;
        break;
      case 1:
        pptr->balance = 0;
        *height = FALSE;
        break;
      case -1:
        aptr = pptr->rchild;
        if (aptr->balance == -1) {
          printf("RIGHT TO RIGHT ROTATION");
          pptr->rchild = aptr->lchild;
          aptr->lchild = pptr;
          pptr->balance = 0;
          aptr->balance = 0;
          pptr = aptr;
        } else {
          printf("RIGHT TO LEFT ROTATION");
          bptr = aptr->lchild;
          aptr->lchild = bptr->rchild;
          bptr->rchild = aptr;
          pptr->rchild = bptr->lchild;
          bptr->lchild = pptr;
          if (bptr->balance == 1) {
            pptr->balance = 0;
            aptr->balance = -1;
          } else {
            pptr->balance = 1;
            aptr->balance = 0;
          }
          bptr->balance = 0;
          pptr = bptr;
        }
        *height = FALSE;
      }
    }
  }

  return (pptr);
}
boolean height = FALSE;
void main() {
  int ch, data;
  while (1) {
    clrscr();
    printf("AVL TREES\n\n");
    printf("1. INSERT\n");
    printf("2. INORDER TRANSVERSAL\n");
    printf("3. DISPLAY\n");
    printf("4. EXIT\n");
    printf("5. ENTER YOUR CHOICE : ");
    scanf("%d", &ch);
    switch (ch) {
    case 1:
      printf("ENTER THE DATA TO BE INSERTED : ");
      scanf("%d", &data);
      if (search(data, root) == NULL)
        root = insert(data, root, &height);
      else
        printf("DATA ALREADY EXISTS!");
      break;
    case 3:
      display(root, 1);
      break;
    case 2:
      inorder(root);
      break;
    case 4:
      exit(0);
    }
    getch();
  }
}
