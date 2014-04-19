import System.Data;
import Mono.Data.Sqlite;

private var db_control : dbAccess;
private var menu_scroll : Vector2;
private var data_scroll : Vector2;

private var txt_field_style : GUIStyle;
private var userselect_button : GUIStyle;
private var menu_button : GUIStyle;
private var skin : GUISkin;
private var menu_box : Rect;
private var display_box : Rect;

public var first_name = "First Name";
public var last_name = "Last Name";
public var txt_field_width : int = 300;
public var txt_field_height : int = 40;
public var button_width : int = 200;
public var user_selection = true;
public var view_calibrations = false;
public var view_results = false;


// Use this for initialization
function Start () {
	db_control = new dbAccess();
	// Define GUI area sizes
	menu_box = new Rect(50, 50, Screen.width / 4, Screen.height - 100);
	display_box = new Rect(menu_box.xMax + 25, 50, Screen.width * 0.75, Screen.height - 100);
}

// Update is called once per frame
function Update () {

}

function OnGUI() {
	// Set up GUI styles
	skin = GUI.skin;
	userselect_button = new GUIStyle(skin.GetStyle("Button"));
	menu_button = new GUIStyle(skin.GetStyle("Button"));
	txt_field_style = new GUIStyle(skin.GetStyle("TextField"));
	txt_field_style.fontSize = 20;
	userselect_button.alignment = TextAnchor.MiddleCenter;
	menu_button.alignment = TextAnchor.MiddleLeft;
	
	// Set up display box.  It's just about full screen
	GUI.Box(new Rect (25,25,Screen.width - 50, Screen.height - 50),"");
	
	// Menu Area Begin 
	GUILayout.BeginArea(menu_box);
	menu_scroll = DisplayFullTable(db_control.user_table, menu_scroll);
	// Menu Area End
	GUILayout.EndArea();
	
	// Display Area Begin 
	GUILayout.BeginArea(display_box);
	data_scroll = DisplayFullTable(db_control.user_table, data_scroll);
	// Display Area End
	GUILayout.EndArea();
	
}


/* Display all rows in the specified table.  This is helpful for debugging purposes. */
function DisplayFullTable(table_name : String, scroll_position : Vector2){
	var database_data : ArrayList = new ArrayList();
	// Display Table Name
	DisplayHorizLabel("Contents of: " + table_name);
	db_control.OpenDB();
	database_data = db_control.ReadFullTable(table_name);
	db_control.CloseDB();
	//GUILayout.Label("Database Contents");
	scroll_position = GUILayout.BeginScrollView(scroll_position, GUILayout.Height(200));
	
	for (var line : ArrayList in database_data){
		// Display first 4 fields of user profiles table, id, created datetime, and name (first, last)
		GUILayout.BeginHorizontal();
		GUILayout.Label(line[0].ToString(), GUILayout.Width(0));
		GUILayout.Label(line[1].ToString(), GUILayout.Width(0));
		GUILayout.Label(line[2].ToString(), GUILayout.Width(0));
		GUILayout.Label(line[3].ToString(), GUILayout.Width(0));

		// Check if the user has made a selection
		if (GUILayout.Button("Select", userselect_button, GUILayout.Width(100))) {
			Debug.Log("You selected user: " + line[0]);
			user_selection = false;
		}
		GUILayout.EndHorizontal();
	}
	GUILayout.EndScrollView();
	
	return scroll_position;
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
