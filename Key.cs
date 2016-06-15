using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	public GameObject door;
	private bool ishovering = false;
	private GameObject temp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay(Collider theCollision){
		if (theCollision.tag == "Finish" & ishovering == false){
			ishovering = true;
			GameObject xptext = (GameObject)(Instantiate(Resources.Load("xptext") ,((new Vector3(transform.position.x,transform.position.y+.8f,transform.localPosition.z))), Quaternion.identity));
			xptext.GetComponent<textrise>().type = 3;
			xptext.GetComponent<textrise>().transformer = gameObject.transform.position;
			xptext.GetComponent<TextMesh>().text = "Press F to pick up key";
			temp = xptext;
		}
		if(theCollision.tag == "Finish"){
			if(Input.GetKey(KeyCode.F) == true){
				Destroy(temp);
				door.transform.GetComponent<Animation>().Play();
				Destroy(gameObject);
			}
		}
	}
	void OnTriggerExit(Collider theCollision){
		if (theCollision.tag == "Finish"){
			ishovering = false;
			Destroy(temp);
		}
	}
}
