using UnityEngine;
using System.Collections;

public class CylinderCatch : MonoBehaviour {

	public int catchCount;
	private float timer = 0.0f;
	private int user_id;
	private dbAccess db_control;
	private string scores_table;
	private string db_name;
	private string userid_field;
	private string time_field;
	private string count_field;

	// Use this for initialization
	void Start () {
		catchCount = 0;
		user_id = PlayerPrefs.GetInt ("ActiveUser");
		scores_table = PlayerPrefs.GetString ("ScoresTable");
		db_name = PlayerPrefs.GetString ("DBName");
		userid_field = "user_id";
		time_field = "reachback_time";
		count_field = "reachback_count";
		db_control = new dbAccess ();
	}
	
	// Update is called once per frame
	void Update () {
		if (catchCount < 3) {
			timer += Time.deltaTime;
		} else {
			Debug.Log(timer);
			// All cylinders were collected. Store the time in the database
			LogBestTime(user_id, timer);


		}
	}

	public void Caught() {
		catchCount++;
	}

	/* Update the given user's quickest completion time in the database */
	private void LogBestTime(int user_id, float time) {
		string query = "UPDATE " + scores_table + " SET " + time_field + "=" + time + " WHERE " + userid_field + "=" + user_id + ";";
		// Open up database
		db_control.OpenDB ();
		// Execute query
		db_control.BasicQuery (query);
		// Close up database
		db_control.CloseDB ();

	}
}
