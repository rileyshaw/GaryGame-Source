using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
	private GaryCharacterController controller;
	private Rigidbody rigidbody_;
	// Use this for initialization
	void Start () {
		controller = GameObject.FindGameObjectWithTag("Finish").transform.GetComponent<GaryCharacterController>();
		rigidbody_ = GameObject.FindGameObjectWithTag("Finish").transform.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void OnTriggerStay(Collider theCollision){
		if (theCollision.tag == "Finish"){
			rigidbody_.useGravity =false;
			controller.onladder = true;
		}
	}
	void OnTriggerExit(Collider theCollision){
		if (theCollision.tag == "Finish"){
			rigidbody_.useGravity =true;
			controller.onladder = false;
		}
	}
}
