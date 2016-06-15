using UnityEngine;
using System.Collections;

public class controllercheck : MonoBehaviour {

	// Use this for initialization
	void Start () {

		if(GameObject.Find("GameController") == null){
			GameObject temp = (GameObject)Instantiate(Resources.Load("GameController"));
			temp.name = "GameController";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
