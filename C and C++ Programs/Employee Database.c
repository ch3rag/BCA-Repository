// EMPLOYEE DATABASE MANAGEMENT
// CHIRAG SINGH RAJPUT

#include <stdio.h>
#include <unistd.h>
#include <dos.h>

struct meta {
	int lastID;
	int numRecords;
} META;

struct emp {
	int id;
	char name[30];
	int age;
	long salary;
} EMP;

//Loads Meta Data In A Structure
void loadMeta() {
	
	FILE * metaPointer;
	// If File Exists
	if (fopen("Config.dat", "r")) {
		metaPointer = fopen("Config.dat", "r");
		fscanf(metaPointer, "%*s\t%d\n", &META.lastID);
		fscanf(metaPointer, "%*s\t%d\n", &META.numRecords);
	} else {
		metaPointer = fopen("Config.dat", "w");
		fprintf(metaPointer,"%s\t%d\n", "LAST_ID", 1);
		fprintf(metaPointer,"%s\t%d\n", "NUM_RECORDS", 0);
	}
	
	fclose(metaPointer);
}

void updateMeta() {
	FILE * metaPointer;
	metaPointer = fopen("Config.dat", "w");
	fprintf(metaPointer,"%s\t%d\n", "LAST_ID", META.lastID + 1);
	fprintf(metaPointer,"%s\t%d\n", "NUM_RECORDS", META.numRecords + 1);
	fclose(metaPointer);
}

void add_record() {
	FILE *empPointer;
	loadMeta();
	empPointer = fopen("EMP.dat", "a");
	EMP.id = META.lastID;
	printf("Enter Employee Name: ");
	fflush(stdin);
	gets(EMP.name);
	printf("Enter Employee Age: ");
	scanf("%d", &EMP.age);
	printf("Enter Employee Salary: ");
	scanf("%ld", &EMP.salary);
	fprintf(empPointer, "%d\n%s\n%d\n%ld\n", EMP.id, EMP.name, EMP.age, EMP.salary);
	fclose(empPointer);
	updateMeta();
	printf("Employee Added!\n\n");
}

FILE * isDatabaseExists() {
	return fopen("EMP.dat", "r");
}

void printData() {
	printf("____________________________\n\nID : %d\nName: %s\nAge: %d\nSalary: %ld\n", EMP.id, EMP.name, EMP.age, EMP.salary);
}
void search_record() {
	int choice, id;
	char name[30];
	FILE * empPointer;
	
	
	if((empPointer = isDatabaseExists()) == NULL) {
		printf("Database Does Not Exists!");
		return;
	}
	
	printf("\n\n1. Search By ID\n2. Search By Name\nEnter Choice: ");
	scanf("%d", &choice);
	switch(choice) {
		case 1:
			printf("Enter ID: ");
			scanf("%d", &id);
			while(!feof(empPointer)) {
				fscanf(empPointer, "%d\n%[^\n]\n%d\n%ld\n", &EMP.id, &EMP.name, &EMP.age, &EMP.salary);
				if(id == EMP.id) {
					printData();
					fclose(empPointer);
					return;
				}
			}
			break;
		case 2:
			printf("Enter Name: ");
			fflush(stdin);
			gets(name);
			while(!feof(empPointer)) {
				fscanf(empPointer, "%d\n%[^\n]\n%d\n%ld\n", &EMP.id, &EMP.name, &EMP.age, &EMP.salary);
				if(strcmp(name, EMP.name) == 0) {
					printData();
					fclose(empPointer);
					return;
				}
		}
		break;
	}
	fclose(empPointer);
	printf("No Result Found!\n\n");
}

void view_records() {
	FILE * empPointer;
	if((empPointer = isDatabaseExists()) == NULL) {
		printf("Database Does Not Exists!");
		return;
	}
	while(!feof(empPointer)) {
		fscanf(empPointer, "%d\n%[^\n]\n%d\n%ld\n", &EMP.id, &EMP.name, &EMP.age, &EMP.salary);
		printData();
	}
	fclose(empPointer);
}

void delete_record() {
	FILE * empTemp, *empPointer;
	int flag = 0, id;
	if((empPointer = isDatabaseExists()) == NULL) {
		printf("Database Does Not Exists!");
		return;
	}	
	
	empTemp = fopen("Replica.dat", "w");
	printf("Enter ID: ");
	scanf("%d", &id);
	while(!feof(empPointer)) {
		fscanf(empPointer, "%d\n%[^\n]\n%d\n%ld\n", &EMP.id, &EMP.name, &EMP.age, &EMP.salary);
		if(id != EMP.id) {
			fprintf(empTemp, "%d\n%s\n%d\n%ld\n", EMP.id, EMP.name, EMP.age, EMP.salary);
		} else {
			flag = 1;
		}
	}
	fclose(empPointer);
	fclose(empTemp);
	if(flag == 0) {
		printf("Record Not Found!");
		remove("Replica.dat");
	} else {
		printf("Record Deleted Sucessfully");
		remove("EMP.dat");
		rename("Replica.dat", "EMP.dat");
	}
}

int main() {
	int choice;
	loadMeta();
	while(choice != 6) {
		printf("\n\n\nEmployee Database\n_____________________\n\n");
		printf("1.Search A Record\n");
		printf("2.View All Records\n");
		printf("3.Add A Record\n");
		printf("4.Delete A Record\n");
		printf("5.Clear Database\n");
		printf("6.Exit\n");
		printf("\nEnter Your Choice :");
		scanf("%d",&choice);
		switch (choice) {
			case 1: 
				search_record();
				break;
			case 2: 
				view_records(2);
				break;
			case 3: 
				add_record();
				break;
			case 4: 
				delete_record();
				break;
			case 5: 
				//clear_database();
				break;
			case 6: 
				break;
			default:
				printf("Wrong Choice!");
		}
	}	
	return 0;
}

 
