using UnityEngine;
using System.Collections;

public class suicideblock : MonoBehaviour {
	private int damage;
	private playersetup playersetup;
	private GameObject player;
	public GUIscript guiscript;
	// Use this for initialization
	void Start () {
		playersetup = GameObject.FindGameObjectWithTag("GameController").GetComponent<playersetup>();
		player = GameObject.FindGameObjectWithTag ("Finish");
		guiscript =  GameObject.FindGameObjectWithTag("GameController").GetComponent<GUIscript>();
		damage = gameObject.transform.parent.GetComponent<suicideset>().suicidedamage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionStay(Collision theCollision){
		if(theCollision.gameObject.tag == "Finish"){
			if(playersetup.player.shield <=0){
				playersetup.player.currenthealth -= (int)(( damage)*(1-((playersetup.player.armor + guiscript.playerweaparmor+ playersetup.itemtypes[guiscript.guiweaptypei].bonusarmor))));
			}else{
				playersetup.player.shield -= (int)(( damage)*(1-((playersetup.player.armor + guiscript.playerweaparmor+ playersetup.itemtypes[guiscript.guiweaptypei].bonusarmor))));
				if(playersetup.player.shield <0){
					playersetup.player.shield = 0;
				}
			}
			player.GetComponent<GaryCharacterController>().hitcounter++;
			player.GetComponent<GaryCharacterController>().isshielddelay=true;
			StartCoroutine(player.GetComponent<GaryCharacterController>().shielddelay(player.GetComponent<GaryCharacterController>().hitcounter));
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(player.transform.position.x,player.transform.position.y+.8f,player.transform.position.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-" +  (int)((damage)*(1-((playersetup.player.armor + guiscript.playerweaparmor+ playersetup.itemtypes[guiscript.guiweaptypei].bonusarmor)))) + " hp";
			if (playersetup.player.currenthealth <=0 &player.GetComponent<GaryCharacterController>().isplaying == true ){
				playersetup.player.currenthealth = 0;
				player.GetComponent<GaryCharacterController>().isplaying = false;
				guiscript.gameover();
			}
			Destroy(gameObject);
		}

	}
}
