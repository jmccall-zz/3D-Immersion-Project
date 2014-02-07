using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

//using System.IO.Ports;

public class SerialScript : MonoBehaviour {
	string mydocpath;
	string[] line;
//	SerialPort serial;
	void Start () {
//		serial = new SerialPort("COM3", 9600);
		Debug.Log (mydocpath + @"\testfile.txt");
	}
	
	void Update () {

		//Debug.Log (entries[0]);
		Load ();
//		Debug.Log(serial.ReadLine());
	}

	bool Load () {
		mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		StreamReader theReader = new StreamReader (mydocpath + @"\testfile.txt", Encoding.Default);

		using (theReader) {
			do {
				for (int i = 0; i < 4; i++) {	
					//Debug.Log (i + " " + theReader.ReadLine());
				}
			}

			while (line != null);
			theReader.Close();
			return true;
		}
	}
} 