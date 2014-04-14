#C:\\Python34\\python

import sqlite3
import random
import matplotlib.pyplot as plt
import dateutil

#db = "TestDB"
db = "C:\\Users\\jmccall\\Documents\\3D-Immersion-Project\\MainGame\\RehabStats.sqdb"
con = sqlite3.connect(db)
print("Database Opened")


#con.execute('''CREATE TABLE STROKEDATA
#(ID INT PRIMARY KEY NOT NULL,
#DATA INT NOT NULL);''')

#for i in range (0,1024):
#   con.execute("INSERT INTO STROKEDATA (ID, DATA) VALUES(" + str(i) + "," + str(random.randint(0,1024)) + ");")

x = []
y = []

cur = con.cursor()
cur = con.execute("SELECT p_id, created_dtm from UserProfiles")
for row in cur:
	x.append(row[0])
	y.append(row[1])
	
print (x)
print (y)

