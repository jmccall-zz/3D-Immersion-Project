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
	"INTEGER PRIMARY KEY",
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
	"INTEGER",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL",
	"REAL"
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
	// Set up display box.  It's just about full screen
	GUI.Box(new Rect (25,25,Screen.width - 50, Screen.height - 50),"");
	GUILayout.BeginArea(new Rect(50, 50, Screen.width - 100, Screen.height - 100));
	
	// If a user has not been found already, display login menu
	if (!user_found){
		LoginOptions();
	} else {
		Debug.Log("A User Has Been Found: " + first_name + " " + last_name);
	}
	
	// Display helpful messages for failed user logins, creations, deletions
	if (failed_user_login)
		DisplayHorizLabel("Login Failed. User Not Found");
	if (failed_user_create)
		DisplayHorizLabel("User Already Exists. Please Login");
	if (deleted_user)
		DisplayHorizLabel("User Deleted");
		
	// Show all users currently in database
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
	// Attempt to search and find a user in the database
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
		// Login successful now skip calibration and head to game
		} else {
			user_found = true;
			failed_user_login = false;
			failed_user_create = false;
			// Set active user for project
			SetActiveUser(first_name, last_name);
			db_control.CloseDB ();
			Debug.Log ("Closed Database");
			Application.LoadLevel(game_scene_name);
		}
	}
	// Attempt to create a user here
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
			query = "INSERT INTO UserProfiles VALUES (NULL,'" + first_name + "','" + last_name + "');";
			db_control.BasicQuery(query);
			// Set active user for project
			SetActiveUser(first_name, last_name);
			db_control.CloseDB ();
			Debug.Log ("Closed Database");
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

/* Display all rows in the UserProfiles database.  This is helpful for debugging purposes. */
function ShowUsers(){
	database_data = db_control.ReadFullTable("UserProfiles");
	GUILayout.Label("Database Contents");
	scrollPosition = GUILayout.BeginScrollView(scroll_position, GUILayout.Height(100));
	for (var line : ArrayList in database_data){
		GUILayout.BeginHorizontal();
		for (var s in line){
			GUILayout.Label(s.ToString(), GUILayout.Width(0));
			Debug.Log("Line Array Count: " + line.Count.ToString() + "\n" + line[0].ToString());
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

/* Set the active user for the project. Do this using PlayerPrefs as they can be accessed throughout the project */
function SetActiveUser(first_name : String, last_name : String) {
	var query = "SELECT p_id FROM UserProfiles WHERE first_name='" + first_name + "' AND last_name='" + last_name + "';";
	var results = db_control.BasicQuery(query);
	// Set the PlayerPref
	PlayerPrefs.SetInt("ActiveUser", results[0][0]);
}


/* When play mode is stopped make sure to close the database.  This helps avoid some database
   issues upon early exit.
*/
function OnApplicationQuit() {
	db_control.CloseDB ();
	Debug.Log ("Closed Database");
}
