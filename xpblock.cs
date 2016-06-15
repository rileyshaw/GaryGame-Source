using UnityEngine;
using System.Collections;

public class xpblock : MonoBehaviour {
	private bool waiting = true;
	private Transform player;
	public int xpvalue;
	private playersetup playersetup;
	private GUIscript guiscript;

	// Use this for initialization
	void Start () {
		xpvalue = transform.parent.GetComponent<xpset> ().xpvalue;
		StartCoroutine (spawnwait ());
		player = GameObject.FindGameObjectWithTag ("Finish").transform;
		playersetup = GameObject.FindGameObjectWithTag("GameController").GetComponent<playersetup> ();
		guiscript =  GameObject.FindGameObjectWithTag("GameController").GetComponent<GUIscript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(waiting == false){
			transform.position = Vector3.MoveTowards(transform.position,player.position,7  * Time.deltaTime);
		}
	
	}
	void OnTriggerEnter(Collider c){
		if(c.collider.name == "Player"){
			addxp();
			Destroy(gameObject);
		}
	}
	IEnumerator spawnwait() {
		yield return new WaitForSeconds(.5f);
		waiting = false;
		transform.collider.isTrigger = true;
		transform.rigidbody.isKinematic = true;
	}
    void addxp(){
		playersetup.itemtypes[guiscript.playerweaptypei].currentxp = playersetup.itemtypes[guiscript.playerweaptypei].currentxp + xpvalue;
		levelupcheck();
		GameObject xptext = (GameObject)(Instantiate(Resources.Load("xptext") ,((new Vector3(player.transform.position.x,player.transform.position.y+.8f,player.transform.position.z))), Quaternion.identity));
		xptext.GetComponent<textrise>().type = 0;
		xptext.GetComponent<textrise>().transformer = player.transform.position;
		xptext.GetComponent<TextMesh>().text = "+"+xpvalue +" xp";
	}
	void levelupcheck(){
		if (playersetup.itemtypes[guiscript.playerweaptypei].currentxp >=playersetup.itemtypes[guiscript.playerweaptypei].xptolevel){
			playersetup.itemtypes[guiscript.playerweaptypei].currentlevel = playersetup.itemtypes[guiscript.playerweaptypei].currentlevel +1;
			playersetup.itemtypes[guiscript.playerweaptypei].currentxp = playersetup.itemtypes[guiscript.playerweaptypei].currentxp -playersetup.itemtypes[guiscript.playerweaptypei].xptolevel;
			playersetup.itemtypes[guiscript.playerweaptypei].xptolevel = (int)(playersetup.itemtypes[guiscript.playerweaptypei].xptolevel * 1.1f);
			playersetup.itemtypes[guiscript.playerweaptypei].perkpoints++;
			GameObject levelup = (GameObject)(Instantiate(Resources.Load("xptext") ,((new Vector3(player.transform.position.x,player.transform.position.y+2f,player.transform.position.z))), Quaternion.identity));
			levelup.GetComponent<textrise>().transformer = player.transform.position;
			levelup.GetComponent<textrise>().type = 1;
			levelup.GetComponent<TextMesh>().text = "Level Up!";
			if(playersetup.itemtypes[guiscript.playerweaptypei].currentxp >=playersetup.itemtypes[guiscript.playerweaptypei].xptolevel){
				levelupcheck();
			}
		}
	}
}
