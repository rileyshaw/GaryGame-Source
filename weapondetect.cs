using UnityEngine;
using System.Collections;

public class weapondetect : MonoBehaviour {
	public bool isjumping = false;
	private GameObject player;
	private GameObject enemy;
	private Animator enemyanimator;
	private playersetup playersetup;
	public GUIscript guiscript;
	void Start(){
		try{
			enemy = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject;
			enemyanimator = gameObject.transform.parent.gameObject.GetComponent<Animator>();
			player = GameObject.FindGameObjectWithTag ("Finish");
			playersetup = GameObject.FindGameObjectWithTag("GameController").GetComponent<playersetup>();
			guiscript =GameObject.FindGameObjectWithTag("GameController").GetComponent<GUIscript>();
		} catch(System.NullReferenceException e){

		}
	}
	void OnCollisionStay(Collision theCollision){
		foreach (ContactPoint contact in theCollision.contacts) {
			if(contact.normal.y > 0.9f){
				isjumping = false;
				break;
			} 
		}
	}
	void OnTriggerStay(Collider c){
		if(enemy){
			if (c.tag == "Finish"  & enemy.GetComponent<cubeenemy>().alreadyhit == false & enemyanimator.GetBool("Attack") == true & player.GetComponent<GaryCharacterController>().isdarting == false){
				enemy.GetComponent<cubeenemy>().alreadyhit = true;
				if(playersetup.player.shield <=0){
					playersetup.player.currenthealth -= (int)((gameObject.transform.GetComponent<weaponhover>().weapdamage + enemy.GetComponent<cubeenemy>().damage)*(1-((playersetup.player.armor + guiscript.playerweaparmor+ playersetup.itemtypes[guiscript.guiweaptypei].bonusarmor))));
				}else{
					playersetup.player.shield -= (int)((gameObject.transform.GetComponent<weaponhover>().weapdamage + enemy.GetComponent<cubeenemy>().damage)*(1-((playersetup.player.armor + guiscript.playerweaparmor+ playersetup.itemtypes[guiscript.guiweaptypei].bonusarmor))));
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
				damagetext.GetComponent<TextMesh>().text = "-" +  (int)((gameObject.transform.GetComponent<weaponhover>().weapdamage + enemy.GetComponent<cubeenemy>().damage)*(1-((playersetup.player.armor + guiscript.playerweaparmor+ playersetup.itemtypes[guiscript.guiweaptypei].bonusarmor)))) + " hp";
				if(	enemy.GetComponent<cubeenemy>().weaponanim.GetBool("isright") == true){
					player.GetComponent<GaryCharacterController>().rigidbody.velocity = new Vector3(2.5f,2.5f,0);
				}else if(enemy.GetComponent<cubeenemy>().weaponanim.GetBool("isright") == false){
					player.GetComponent<GaryCharacterController>().rigidbody.velocity = new Vector3(-2.5f,2.5f,0);
				}
				player.GetComponent<GaryCharacterController>().ishit = true;
				StartCoroutine(player.GetComponent<GaryCharacterController>().ishitwait());
				if (playersetup.player.currenthealth <=0 &player.GetComponent<GaryCharacterController>().isplaying == true ){
					playersetup.player.currenthealth = 0;
					player.GetComponent<GaryCharacterController>().isplaying = false;
					guiscript.gameover();
				}
			}	
			if (c.tag == "jump"  & isjumping == false & enemy.GetComponent<cubeenemy>().isstunned == false){
				isjumping = true;
			}
		}
	
	}
}
