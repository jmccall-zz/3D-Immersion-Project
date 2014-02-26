/*
This script will set up database tables accordingly and allow a user to login.
NOTE: If you wish to change the structure of a table and re-create it, you will need to regenerate
the entire database.  This is done by deleting the corresponding database file from the 
projects root folder.  For example "RehabStats.sqdb". Delete that and re-run the script.  It 
will be automatically generated. 
*/

import System.Data;
import Mono.Data.Sqlite;

private var db_control : dbAccess;
private var user_found = false;
private var failed_user_login = false;
private var failed_user_create = false;
private var deleted_user = false;
private var row;
private var query;
private var scroll_position : Vector2;
private var results : ArrayList = new ArrayList();
private var database_data : ArrayList = new ArrayList();

public var calibration_scene_name = "CalibrateGlove";
public var game_scene_name = "AvatarFrontfacing";
public var db_name = "RehabStats.sqdb";
public var user_table_name = "UserProfiles";
public var calib_table_name = "CalibData";
public var first_name = "First Name";
public var last_name = "Last Name";
public var txt_field_width : int = 100;
public var button_width : int = 100;

public var user_field_names = new Array (
	"p_id",
	"first_name",
	"last_name"
);
public var user_field_values = new Array (
	"INT PRIMARY KEY",
	"VARCHAR(100)",
	"VARCHAR(100)"
);
public var user_constraints = "";

public var calib_field_names = new Array (
	"user_id",
	"index_0",
	"index_15",
	"index_30",
	"index_45",
	"index_60",
	"index_75",
	"index_90",
	"middle_0",
	"middle_15",
	"middle_30",
	"middle_45",
	"middle_60",
	"middle_75",
	"middle_90",
	"ring_0",
	"ring_15",
	"ring_30",
	"ring_45",
	"ring_60",
	"ring_75",
	"ring_90",
	"pinky_0",
	"pinky_15",
	"pinky_30",
	"pinky_45",
	"pinky_60",
	"pinky_75",
	"pinky_90"
);	
public var calib_field_values = new Array (
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT",
	"INT"
);
public var calib_constraints = "FOREIGN KEY(user_id) REFERENCES " + user_table_name + "(" + user_field_names[0] + ")";

// Use this for initialization
function Start () {
	// Boolean indicating whether table already exists
	var user_table_exists;
	var calib_table_exists;
	db_control = new dbAccess();

	// Open up database.  Will create database if it doesn't exist.
	db_control.OpenDB (db_name);
	Debug.Log ("Opened Database");

	user_table_exists = db_control.TableExists(user_table_name);
	calib_table_exists = db_control.TableExists(calib_table_name);

	// Check if user profile table exists and create it if not
	if (!user_table_exists) {
		Debug.Log ("Creating Table: " + user_table_name);
		db_control.CreateTable (user_table_name, user_field_names, user_field_values, user_constraints);
	} else {
		Debug.Log ("User Table Already Exists");
	}
	// Check if calibration table exists and create it if not
	if (!calib_table_exists) {
		Debug.Log ("Creating Table: " + calib_table_name);
		db_control.CreateTable (calib_table_name, calib_field_names, calib_field_values, calib_constraints);
	} else {
		Debug.Log ("Calibration Table Already Exists");
	}

}

// Update is called once per frame
function Update () {

}

function OnGUI() {

	GUI.Box(new Rect (25,25,Screen.width - 50, Screen.height - 50),"");
	GUILayout.BeginArea(new Rect(50, 50, Screen.width - 100, Screen.height - 100));
	// Check if user has already been found
	if (!user_found){
		LoginOptions();
	} else {
		Debug.Log("A User Has Been Found: " + first_name + " " + last_name);
	}
	if (failed_user_login)
		DisplayHorizLabel("Login Failed. User Not Found");
	if (failed_user_create)
		DisplayHorizLabel("User Already Exists. Please Login");
	if (deleted_user)
		DisplayHorizLabel("User Deleted");
	// Show all users
	ShowUsers();
	GUILayout.EndArea ();
	
}

function LoginOptions() {
	// This first block allows us to enter new entries into our table
	GUILayout.BeginHorizontal();
	first_name = GUILayout.TextField(first_name, GUILayout.Width (txt_field_width));
	last_name = GUILayout.TextField(last_name, GUILayout.Width (txt_field_width));
	GUILayout.EndHorizontal();
	
	GUILayout.BeginHorizontal();
	if (GUILayout.Button("Login", GUILayout.Width(button_width))){
		query = "SELECT first_name, last_name FROM UserProfiles WHERE first_name='" + 
			first_name + 
			"' AND last_name='" +
			last_name +
			"';";
		results = db_control.BasicQuery(query);
		// If nothing was returned from the query
		if (results.Count == 0) {
			failed_user_login = true;
			failed_user_create = false;
			Debug.Log("User Does Not Exists");
		// Login successful now print information on user
		} else {
			user_found = true;
			failed_user_login = false;
			failed_user_create = false;
			Debug.Log("User Found: " + results[0].ToString());
			Application.LoadLevel(game_scene_name);
		}
		//Debug.Log("Array length: " + results.Count.ToString());
		for each (row in results){
			Debug.Log(row.ToString());
		}
	}
	if (GUILayout.Button("Create User", GUILayout.Width(button_width))) {
		query = "SELECT first_name, last_name FROM UserProfiles WHERE first_name='" + 
			first_name + 
			"' AND last_name='" +
			last_name +
			"';";
		results = db_control.BasicQuery(query);
		// If a user was found show that it already exists
		if (results.Count > 0) {
			failed_user_create = true;
			failed_user_login = false;
			Debug.Log("This User Already Exists");
		} else {
			user_found = true;
			failed_user_login = false;
			failed_user_create = false;
			Debug.Log("Creating User: " + first_name + " " + last_name);
			// Insert user's name into database
			db_control.InsertIntoSpecific(user_table_name, Array("first_name", "last_name"), Array(first_name, last_name));
			Application.LoadLevel("CalibrateGlove");
		}
	}
	
	if (GUILayout.Button("Delete User", GUILayout.Width(button_width))) {
			
		DeleteUser(first_name, last_name);
		deleted_user = true;
		failed_user_create = false;
		failed_user_login = false;
		Debug.Log("Deleting user: " + first_name + " " + last_name);
		
	}
	
	GUILayout.EndHorizontal();
}

function ShowUsers(){
	database_data = db_control.ReadFullTable("UserProfiles");
	GUILayout.Label("Database Contents");
	scrollPosition = GUILayout.BeginScrollView(scroll_position, GUILayout.Height(100));
	for (var line : ArrayList in database_data){
		GUILayout.BeginHorizontal();
		for (var s in line){
			GUILayout.Label(s.ToString(), GUILayout.Width(0));
		}
		GUILayout.EndHorizontal();
	}
	GUILayout.EndScrollView();
}

function DisplayHorizLabel(msg : String){
	GUILayout.BeginHorizontal();
	GUILayout.Label(msg);
	GUILayout.EndHorizontal();
}

function DeleteUser(first_name : String, last_name : String) {
	var query = "DELETE FROM " + user_table_name + " WHERE first_name='" + first_name + "' AND last_name='" + last_name + "';";
	var results = db_control.BasicQuery(query);
	Debug.Log(results.Count);
	return results;
}

function OnApplicationQuit() {
	db_control.CloseDB ();
	Debug.Log ("Closed Database");
}



/*Right now, it'll load TestDB.sqdb in the project's root folder.


// These variables just hold info to display in our GUI
var firstName : String = "First Name";
var lastName : String = "Last Name"; 
var DatabaseEntryStringWidth = 100;
var scrollPosition : Vector2;
var databaseData : ArrayList = new ArrayList();

// This GUI provides us with a way to enter data into our database
//  as well as a way to view it
function OnGUI(){
	GUI.Box(Rect (25,25,Screen.width - 50, Screen.height - 50),""); 
	GUILayout.BeginArea(Rect(50, 50, Screen.width - 100, Screen.height - 100));
	// This first block allows us to enter new entries into our table
	GUILayout.BeginHorizontal();
	firstName = GUILayout.TextField(firstName, GUILayout.Width (DatabaseEntryStringWidth));
	lastName = GUILayout.TextField(lastName, GUILayout.Width (DatabaseEntryStringWidth));
	GUILayout.EndHorizontal();
	
	if (GUILayout.Button("Add to database")){
		// Insert the data
		InsertRow(firstName,lastName);
		// And update the readout of the database
		databaseData = ReadFullTable();
	}
	// This second block gives us a button that will display/refresh the contents of our database
	GUILayout.BeginHorizontal();
	if (GUILayout.Button ("Read Database"))	
		databaseData = ReadFullTable();
	if (GUILayout.Button("Clear"))
		databaseData.Clear();
	GUILayout.EndHorizontal();
	
	GUILayout.Label("Database Contents");
	scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Height(100));
	for (var line : ArrayList in databaseData){
		GUILayout.BeginHorizontal();
		for (var s in line){
			GUILayout.Label(s.ToString(), GUILayout.Width(DatabaseEntryStringWidth));
		}
		GUILayout.EndHorizontal();
	}
	
	GUILayout.EndScrollView();
	if (GUILayout.Button("Delete All Data")){
		DeleteTableContents();
		databaseData = ReadFullTable();
	}
	
	GUILayout.EndArea();
}

// Wrapper function for inserting our specific entries into our specific database and table for this file
function InsertRow(firstName, lastName){
	var values = new Array(("'"+firstName+"'"),("'"+lastName+"'"));
	db.InsertInto(TableName, values);
}

// Wrapper function, so we only mess with our table.
function ReadFullTable(){
	return db.ReadFullTable(TableName);
}

// Another wrapper function...
function DeleteTableContents(){
	db.DeleteTableContents(TableName);
}
*/