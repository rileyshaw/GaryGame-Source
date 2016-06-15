using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {
	public GameObject door;
	private bool ishovering = false;
	private GameObject temp;
	private bool open  = false;
	public bool openRight = true;
	public bool isrunning = false;
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
			xptext.GetComponent<TextMesh>().text = "Press F to switch lever";
			temp = xptext;
		}
		if(theCollision.tag == "Finish"){
			if(Input.GetKey(KeyCode.F) == true & isrunning == false){
				isrunning = true;
				StartCoroutine(wait());
				if(open == false){
					open = true;
					if(openRight == true){
						door.transform.GetComponent<Animation>().Play("RIght Open");
					}else{
						door.transform.GetComponent<Animation>().Play("LeftOpen");
					}
					gameObject.transform.GetComponent<Animation>().Play("Close");
				}else{
					open = false;
					if(openRight == true){
						door.transform.GetComponent<Animation>().Play("RIghtClose");
					}else{
						door.transform.GetComponent<Animation>().Play("LeftClose");
					}
					gameObject.transform.GetComponent<Animation>().Play("Open");
				}
			}
		}
	}
	void OnTriggerExit(Collider theCollision){
		if (theCollision.tag == "Finish"){
			ishovering = false;
			Destroy(temp);
		}
	}
	IEnumerator wait() {
		yield return new WaitForSeconds(2f);
		isrunning = false;
	}
}
