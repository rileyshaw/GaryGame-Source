using UnityEngine;
using System.Collections;

public class BreakableBox : MonoBehaviour {
	private Animator enemyanimator;
	private Transform playerscript;
	private GUIscript guiscript;
	void Start(){
		playerscript = GameObject.FindGameObjectWithTag ("Finish").transform;
		guiscript =GameObject.FindGameObjectWithTag("GameController").GetComponent<GUIscript>();
	}
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider theCollision){
		if (theCollision.tag == "weapon"  & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("Attack") == true){
			Instantiate (Resources.Load("Broken Box"),transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
}
