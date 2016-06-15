using UnityEngine;
using System.Collections;

public class isjumping : MonoBehaviour {
	public  bool isjumpinger;
	private Transform cube;
	// Use this for initialization
	void OnCollisionStay(){
		Debug.Log ("on");
		isjumpinger = false;
	}
	void OnCollisionExit(){
		Debug.Log ("off");
		isjumpinger = true;
	}
}
