using UnityEngine;
using System.Collections;

public class gamecontrollerhandle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(GameObject.Find("GameController") == null){
			GameObject gamecontroller = (GameObject)Instantiate(Resources.Load("GameController") ,(Vector3.zero), Quaternion.identity);
			gamecontroller.name = "GameController";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
