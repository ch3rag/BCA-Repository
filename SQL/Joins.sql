USE CHIRAG 

CREATE TABLE CUSTOMER (CUSTOMER_ID INT PRIMARY KEY, CUST_NAME VARCHAR(25), CITY VARCHAR(20), GRADE INT, SALESMAN_ID INT)
INSERT INTO CUSTOMER VALUES(3002,'Nick Rimando','New York',100,5001)
INSERT INTO CUSTOMER VALUES(3005,'Graham Zusi','California',200,5002)
INSERT INTO CUSTOMER VALUES(3001,'Brad Guzan','London',NULL,5005)
INSERT INTO CUSTOMER VALUES(3004,'Fabian Johns','Paris',300,5006)
INSERT INTO CUSTOMER VALUES(3007,'Brad Davis','New York',200,5001)
INSERT INTO CUSTOMER VALUES(3009,'Geoff Camero','Berlin',100,5003)
INSERT INTO CUSTOMER VALUES(3008,'Julian Green','London',300,5002)
INSERT INTO CUSTOMER VALUES(3003,'Jozy Altidor','Moscow',200,5007)
INSERT INTO CUSTOMER VALUES(3010, 'Chirag Singh','Lucknow', NULL, NULL)


CREATE TABLE SALESMAN(SALESMAN_ID INT PRIMARY KEY, SALESMAN_NAME VARCHAR(25), CITY VARCHAR(35), COMMISSION FLOAT)
INSERT INTO SALESMAN VALUES(5001,'James Hoog','New York',0.15)
INSERT INTO SALESMAN VALUES(5002,'Nail Knite','Paris',0.13)
INSERT INTO SALESMAN VALUES(5005,'Pit Alex','London',0.11)
INSERT INTO SALESMAN VALUES(5006 ,'Mc Lyon','Paris' ,0.14)
INSERT INTO SALESMAN VALUES(5003 ,'Lauson Hen',NULL,0.12)
INSERT INTO SALESMAN VALUES( 5007 ,'Paul Adam','Rome' ,0.13)
INSERT INTO SALESMAN VALUES(5008,'David DeGraw', 'Sao Paulo', 0.16)


CREATE TABLE ORDERS(ORD_NO INT PRIMARY KEY, PURCH_AMT FLOAT, ORD_DATE DATETIME, CUSTOMER_ID INT, SALESMAN_ID INT)

INSERT INTO ORDERS VALUES(70001,150.5,'2012-10-05',3005,5002)
INSERT INTO ORDERS VALUES(70009,270.65,'2012-09-10',3001,5005)
INSERT INTO ORDERS VALUES(70002,65.26,'2012-10-05',3002,5001)
INSERT INTO ORDERS VALUES(70004,110.5,'2012-08-17',3009,5003)
INSERT INTO ORDERS VALUES(70007,948.5,'2012-09-10',3005,5002)
INSERT INTO ORDERS VALUES(70005,2400.6,'2012-07-27',3007,5001)
INSERT INTO ORDERS VALUES(70008,5760,'2012-09-10',3002,5001)
INSERT INTO ORDERS VALUES(70010,1983.43,'2012-10-10',3004,5006)
INSERT INTO ORDERS VALUES(70003,2480.4,'2012-10-10',3009,5003)
INSERT INTO ORDERS VALUES(70012,250.45,'2012-06-27',3008,5002)
INSERT INTO ORDERS VALUES(70011,75.29 ,'2012-08-17',3003,5007)
INSERT INTO ORDERS VALUES(70013,3045.6,'2012-04-25',3002,5001)

SELECT * FROM ORDERS

SELECT * FROM CUSTOMER

SELECT SALESMAN.SALESMAN_ID, SALESMAN.SALESMAN_NAME, SALESMAN.CITY, CUSTOMER.CUST_NAME FROM SALESMAN LEFT JOIN CUSTOMER ON SALESMAN.SALESMAN_ID = CUSTOMER.CUSTOMER_ID

SELECT CUSTOMER.CUST_NAME, SALESMAN.SALESMAN_NAME FROM CUSTOMER INNER JOIN SALESMAN ON CUSTOMER.SALESMAN_ID = SALESMAN.SALESMAN_ID

SELECT * FROM CUSTOMER WHERE GRADE < 300

SELECT CUSTOMER.CUST_NAME, SALESMAN.SALESMAN_NAME FROM CUSTOMER LEFT JOIN SALESMAN ON CUSTOMER.SALESMAN_ID = SALESMAN.SALESMAN_ID WHERE CUSTOMER.GRADE < 300

SELECT CUSTOMER.CUST_NAME, CUSTOMER.CITY, ORDERS.ORD_NO, ORDERS.ORD_DATE, ORDERS.PURCH_AMT, SALESMAN.SALESMAN_NAME, SALESMAN.COMMISSION FROM CUSTOMER LEFT JOIN ORDERS ON ORDERS.CUSTOMER_ID = CUSTOMER.CUSTOMER_ID LEFT JOIN SALESMAN ON CUSTOMER.SALESMAN_ID = SALESMAN.SALESMAN_ID

SELECT SALESMAN.SALESMAN_ID, SALESMAN.SALESMAN_NAME, SALESMAN.CITY, CUSTOMER.CUST_NAME, CUSTOMER.CUSTOMER_ID, CUSTOMER.CITY FROM SALESMAN LEFT JOIN CUSTOMER ON SALESMAN.SALESMAN_ID = CUSTOMER.SALESMAN_ID

SELECT SALESMAN.SALESMAN_ID, SALESMAN.SALESMAN_NAME, SALESMAN.CITY, CUSTOMER.CUST_NAME, CUSTOMER.CUSTOMER_ID, CUSTOMER.CITY, ORDERS.ORD_NO, ORDERS.PURCH_AMT FROM SALESMAN LEFT JOIN CUSTOMER ON SALESMAN.SALESMAN_ID = CUSTOMER.SALESMAN_ID LEFT JOIN ORDERS ON ORDERS.CUSTOMER_ID = CUSTOMER.CUSTOMER_ID

UPDATE CUSTOMER SET SALESMAN_ID = 5008 WHERE CUSTOMER_ID = 3010

SELECT SALESMAN.SALESMAN_ID, SALESMAN.SALESMAN_NAME, CUSTOMER.CUST_NAME FROM SALESMAN LEFT JOIN CUSTOMER ON SALESMAN.SALESMAN_ID = CUSTOMER.SALESMAN_ID LEFT JOIN ORDERS 

SELECT CUSTOMER.CUSTOMER_ID, CUSTOMER.CUST_NAME, CUSTOMER.GRADE, ORDERS.ORD_NO, ORDERS.PURCH_AMT FROM CUSTOMER LEFT JOIN ORDERS ON ORDERS.CUSTOMER_ID = CUSTOMER.CUSTOMER_ID WHERE (PURCH_AMT >= 2000 AND GRADE IS NOT NULL) OR ORD_NO IS NULL

SELECT CUSTOMER.CUST_NAME, CUSTOMER.CITY, CUSTOMER.GRADE, SALESMAN.SALESMAN_NAME, ORDERS.ORD_NO, ORDERS.ORD_DATE, ORDERS.PURCH_AMT FROM SALESMAN LEFT JOIN CUSTOMER ON CUSTOMER.SALESMAN_ID = SALESMAN.SALESMAN_ID LEFT JOIN ORDERS ON ORDERS.CUSTOMER_ID = CUSTOMER.CUSTOMER_ID WHERE (PURCH_AMT >= 2000 AND GRADE IS NOT NULL) OR ORDERS.ORD_NO IS NULL

--

SELECT * FROM ORDERS ORDER BY ORD_DATE

SELECT * FROM CUSTOMER 

SELECT * FROM SALESMAN

INSERT INTO ORDERS VALUES(70014, 2077.75, '2012-08-20', 3011, 5008)

SELECT CUSTOMER.CUST_NAME, ORDERS.ORD_NO FROM ORDERS LEFT JOIN CUSTOMER ON ORDERS.CUSTOMER_ID = CUSTOMER.CUSTOMER_ID

SELECT CUSTOMER.CUST_NAME, CUSTOMER.CITY, ORDERS.ORD_NO, ORDERS.ORD_DATE, ORDERS.PURCH_AMT FROM ORDERS LEFT JOIN CUSTOMER ON ORDERS.CUSTOMER_ID = CUSTOMER.CUSTOMER_ID

SELECT CUSTOMER.CUST_NAME, CUSTOMER.CITY, ORDERS.ORD_NO, ORDERS.ORD_DATE, ORDERS.PURCH_AMT, CUSTOMER.GRADE FROM  CUSTOMER FULL OUTER JOIN ORDERS ON CUSTOMER.CUSTOMER_ID = ORDERS.CUSTOMER_ID WHERE (CUSTOMER.CUSTOMER_ID IS NOT NULL AND CUSTOMER.GRADE IS NOT NULL) OR (CUSTOMER.CUSTOMER_ID IS NULL AND CUSTOMER.GRADE IS NULL) 

SELECT SALESMAN.SALESMAN_NAME, CUSTOMER.CUST_NAME FROM SALESMAN, CUSTOMER

SELECT SALESMAN.SALESMAN_NAME, CUSTOMER.* , SALESMAN.* FROM SALESMAN CROSS JOIN CUSTOMER WHERE SALESMAN.CITY IS NOT NULL AND CUSTOMER.GRADE IS NOT NULL AND CUSTOMER.CITY <> SALESMAN.CITY
