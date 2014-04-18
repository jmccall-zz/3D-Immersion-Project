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
private var scroll_position : Vector2;
private var txt_field_style : GUIStyle;

public var first_name = "First Name";
public var last_name = "Last Name";
public var txt_field_width : int = 300;
public var txt_field_height : int = 40;
public var button_width : int = 200;


// Use this for initialization
function Start () {
	db_control = new dbAccess();
}

// Update is called once per frame
function Update () {

}

function OnGUI() {
	// Set up display box.  It's just about full screen
	GUI.Box(new Rect (25,25,Screen.width - 50, Screen.height - 50),"");
	GUILayout.BeginArea(new Rect(50, 50, Screen.width - 100, Screen.height - 100));
	
	// Initialize GUIStyles
	txt_field_style = GUI.skin.textField;
	txt_field_style.fontSize = 20;
	
	// Display our welcome message
	DisplayHorizLabel("DatabaseViewer:");
	
	DisplayFullTable(db_control.user_table);
		
	GUILayout.EndArea ();
	
}


/* Display all rows in the specified table.  This is helpful for debugging purposes. */
function DisplayFullTable(table_name : String){
	var database_data : ArrayList = new ArrayList();
	// Display Table Name
	DisplayHorizLabel("Contents of: " + table_name);
	db_control.OpenDB();
	database_data = db_control.ReadFullTable(table_name);
	db_control.CloseDB();
	//GUILayout.Label("Database Contents");
	scroll_position = GUILayout.BeginScrollView(scroll_position, GUILayout.Height(100));
	for (var line : ArrayList in database_data){
		GUILayout.BeginHorizontal();
		for (var s in line){
			GUILayout.Label(s.ToString(), GUILayout.Width(0));
		}
		GUILayout.EndHorizontal();
	}
	GUILayout.EndScrollView();
}

/* Display a horizontal label. This label will get its own horizontal space */
function DisplayHorizLabel(msg : String){
	GUILayout.BeginHorizontal();
	GUILayout.Label(msg);
	GUILayout.EndHorizontal();
}


/* 
When play mode is stopped make sure to close the database.  This helps avoid some database
issues upon early exit.  If database is not open, nullreference exception will be thrown. It's 
ok to ignore this.
*/
function OnApplicationQuit() {
	db_control.CloseDB ();
}
