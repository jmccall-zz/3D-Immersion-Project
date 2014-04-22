#C:\\Python34\\python

import sqlite3
import random


class dbReader():
        db = "C:\\Users\\ckaminer\\Documents\\GitHub\\3D-Immersion-Project\\MainGame\\RehabStats.sqdb"
#       db = "TestDB"

        # connection Object
        con = []
        
        def __init__(self):
                #Initialize Database Connection
                self.con = sqlite3.connect(self.db)
                print("Database Opened")

        def readNames(self):
                names=[]
                cur = self.con.execute("SELECT first_name, last_name, p_id  from UserProfiles")
                for row in cur:
                        names.append(str(row[2]) + ' ' +  row[1] + ', ' + row[0])

                return names

        def readExerciseTables(self, p_id):
                tables = []
                cur = self.con.execute("SELECT rotations_ts, positions_ts from UserProfiles where p_id=" + str(p_id))
                for row in cur:
                        tables.append(row[0])
                        tables.append(row[1])
                return tables

        def readTimeTables(self, table_name):
                data = [[]]
                cur = self.con.execute("SELECT * from " + table_name)
                i = 0
                for row in cur:
                        data[i].append(row)
                        i = i + 1
                return data
        

#con.execute('''CREATE TABLE STROKEDATA
#(ID INT PRIMARY KEY NOT NULL,
#DATA INT NOT NULL);''')

#for i in range (0,1024):
#   con.execute("INSERT INTO STROKEDATA (ID, DATA) VALUES(" + str(i) + "," + str(random.randint(0,1024)) + ");")

#x = []
#y = []

#cur = con.cursor()
#cur = con.execute("SELECT p_id, created_dtm from UserProfiles")
#for row in cur:
#	x.append(row[0])
#	y.append(row[1])
	
#print (x)
#print (y)

if __name__ == '__main__':
        thedb = dbReader()
        print(thedb.readNames())


