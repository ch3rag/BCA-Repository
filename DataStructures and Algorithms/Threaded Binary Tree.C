/* THREADED BINARY TREE */
#include<stdio.h>
#include<conio.h>
#include<stdlib.h>
#define INFINITY 9999

typedef enum {THREAD , LINK} boolean;

struct node {
	int data;
	struct node *lchild;
	struct node *rchild;
	boolean left;
	boolean right;
} *head;

void find(int,struct node **,struct node **);

void nodeinfo() {
	int data;
	struct node *temp,*parent;
	printf("ENTER THE DATA : ");
	scanf("%d",&data);
	find(data,&temp,&parent);
	if(temp == NULL) {
		printf("DATA NOT FOUND!");
		return;
	}
	printf("NODE ADDRESS : %d DATA : %d\nLCHILD : %d DATA : %d\nRCHILD : %d DATA : %d\nLEFT : %d RIGHT : %d",temp,temp->data,temp->lchild,temp->lchild->data,temp->rchild,temp->rchild->data,temp->left,temp->right);
}


void preorder() {
	struct node *temp;
	if(head->lchild == head) {
		printf("TREE IS EMPTY!");
		return;
	}
	temp = head->lchild;
	while(temp != head) {
		printf("%d ",temp->data);
		if(temp->left == LINK) {
			temp = temp->lchild;
		} else if(temp->right == LINK) {
			temp = temp->rchild;
		} else {
			while(temp->right == THREAD && temp!= head) {
				temp = temp->rchild;
			}
			if(temp!=head) {
				temp = temp->rchild;
			}
		}
	}
}

void headini() {
	head         = malloc(sizeof(struct node));
	head->data   = INFINITY;
	head->rchild = head;
	head->right  = LINK;
	head->lchild = head;
	head->left   = THREAD;
}

void find(int data, struct node **location, struct node **parent) {
	struct node *par,*loc;
	if(head->lchild == head) {
		*location = NULL;
		*parent   = head;
		return;
	}
	if(data == head->lchild->data) {
		*location = head->lchild;
		*parent   = head;
		return;
	}
	loc = head->lchild;
	while(loc!=head) {
		par = loc;
		if(data < loc->data) {
			if(loc->left == LINK) {
				loc = loc->lchild;
			} else {
				break;
			}
		} else if(data > loc->data) {
			if(loc->right == LINK) {
				loc = loc->rchild;			
			} else {
				break;
			}
		}

		if(data == loc->data) {
			*location = loc;
			*parent   = par;
			return;
		}
	}
	*location = NULL;
	*parent   = par;
	return;
}

struct node *inorderpre(struct node *temp) {
	struct node *pre;
	if(temp->left == THREAD) {
		pre = temp->lchild;	
	} else {
		temp = temp->lchild;
		while(temp->right == LINK)
		temp = temp->rchild;
		pre = temp;
	}
	return pre;
}

struct node *inordersuc(struct node *temp) {
	struct node *suc;
	if(temp->right == THREAD) {
		suc = temp->rchild;
	} else {
		temp = temp->rchild;
		while(temp->left == LINK) {
			temp = temp->lchild;
		}
		suc = temp;
	}
	return suc;
}

void inorder() {
	struct node *temp;
	if(head->lchild == head) {
		printf("TREE IS EMPTY!");
		return;
	}

	temp = head->lchild;
	
	while(temp->left == LINK) {
		temp = temp->lchild;
	}

	printf("%d ",temp->data);
	while(1) {
		temp = inordersuc(temp);
		if(temp == head) {
			break;
		} else { 
			printf("%d ",temp->data);
		}
	}
}

void insert(int data) {
	struct node *parent,*location,*temp;
	find(data,&location,&parent);
	if(location != NULL) {
		printf("DATA ALREADY EXISTS!");
		return;
	}

	temp = malloc(sizeof(struct node));
	temp->data = data;
	temp->left = THREAD;
	temp->right = THREAD;

	if(parent == head) {
		head->lchild = temp;
		head->left   = LINK;
		temp->lchild = head;
		temp->rchild = head;
		return;
	}
	if(data < parent->data) {
		temp->lchild = parent->lchild;
		parent->lchild = temp;
		parent->left   = LINK;
		temp->rchild   = parent;
		return;
	}
	if(data > parent->data) {
		temp->rchild = parent->rchild;
		parent->rchild = temp;
		parent->right  = LINK;
		temp->lchild   = parent;
		return;
	}
}

void case_a(struct node *location, struct node *parent) {
	if(location == head->lchild) {
		head->lchild = head;
		head->left   = THREAD;
		free(location);
		return;
	} else if(location == parent->rchild) {
		parent->rchild = location->rchild;
		parent->right  = THREAD;
		free(location);
		return;
	} else if(location == parent->lchild) {
		parent->lchild = location->lchild;
		parent->left   = THREAD;
		free(location);
		return;
	}
}

void case_b(struct node *location,struct node *parent) {
	struct node *suc,*pre,*child;
	suc = inordersuc(location);
	pre = inorderpre(location);
	if(location->left == LINK){
		child = location->lchild;
		pre->rchild = suc;
	} else {
		child = location->rchild;
		suc->lchild = pre;
	}

	if(location == head) {
		head->lchild =  child;
		return;
	}

	if(location == parent->lchild) {
		parent->lchild = child;
	} else {
		parent->rchild = child;
	}
}

void case_c(struct node *location,struct node *parent) {
	struct node *suc,*sucpar;
	sucpar = location;
	suc    = location->rchild;
	while(suc->left == LINK) {
		sucpar = suc;
		suc = suc->lchild;
	}
	location->data = suc->data;
	if(suc->left == THREAD && suc->right == THREAD) {
		case_a(suc,sucpar);
	} else {
		case_b(suc,sucpar);	
	}
}

void deletef() {
	struct node *parent,*location;
	int data;
	if(head->lchild == head) {
		printf("TREE IS EMPTY!");
		return;
	}
	printf("ENTER DATA TO BE DELETED : ");
	scanf("%d",&data);
	find(data,&location,&parent);
	if(location == NULL) {
		printf("DATA NOT FOUND!");
		return;
	}
	if(location->left == THREAD && location->right == THREAD) {
		case_a(location,parent);
		return;
	} else if(location->left == LINK && location->right == LINK) {
		case_c(location,parent);
		return;
	} else {
		case_b(location,parent);
		return;
	}
}



void main() {
	int ch,data;
	headini();
	while (1) {
		clrscr();
		printf("THREADED BINARY TREE\n\n");
		printf("1. INSERT\n");
		printf("2. INORDER TRANVERSAL\n");
		printf("3. PREORDER TRANSVERSAL\n");
		printf("4. DELETE\n");
		printf("5. NODE INFO\n");
		printf("6. EXIT\n");
		printf("ENTER YOUR CHOICE : ");
		scanf("%d",&ch);
		switch(ch) {
			case 1 :
				 printf("ENTER THE DATA YOU WANT TO INSERT : ");
				scanf("%d",&data);
				insert(data);
				break;
			case 2 : 
				inorder();
				break;
			case 3 : 
				preorder();
				break;
			case 4 : 
				deletef();
				break;
			case 5 : 
				nodeinfo();
				break;
			case 6 : 
				exit(0);
		}
		getch();
	}
}

