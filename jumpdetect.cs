using UnityEngine;
using System.Collections;

public class jumpdetect : MonoBehaviour {
	public bool isjumping = false;
	private Transform playeranimator;
	private Transform enemy;
	private Animator enemyanimator;
	private Transform playerscript;
	private Transform enemyscript;
	public GUIscript guiscript;
	void Start(){
		enemy = gameObject.transform;
		enemyscript = enemy.parent.transform;
		playerscript = GameObject.FindGameObjectWithTag ("Finish").transform;
		playeranimator = playerscript.FindChild("Hand Object").transform;
		guiscript = GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<GUIscript>();
	}
	void OnCollisionStay(Collision theCollision){
		foreach (ContactPoint contact in theCollision.contacts) {
			if(contact.normal.y > 0.9f){
				isjumping = false;
				if(theCollision.gameObject.tag == "Finish" | theCollision.gameObject.tag == "enemy"){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(Random.Range(-3,3),4,0);
				}
				break;
			} 
		}
	}
	void OnTriggerStay(Collider c){
		if (c.tag == "jump"  & isjumping == false & enemyscript.GetComponent<cubeenemy>().ishit == false & playerscript.GetComponent<GaryCharacterController>().isplaying == true){
			isjumping = true;
			enemy.rigidbody.velocity = new Vector3(enemy.rigidbody.velocity.x, 5f, 0);
		}
		if (c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("Attack") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(4,4,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-4,4,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(ishitwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().takedamage();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("Uppercutattack") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(4,7,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-4,7,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(ishitwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().hand1();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("Tornadoattack") == true & enemyscript.GetComponent<cubeenemy>().ishit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(1,1,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-1,1,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(tornadowait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().hand4();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("jab") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(4,2,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-4,2,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(ishitwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().shortsword1();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("double") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(4,4,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-4,4,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(ishitwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().shortsword2();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("dart") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(4,6,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-4,6,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(ishitwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().shortsword4();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("heavy") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(4,4,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-4,4,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(ishitwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().blunt1();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("slam") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(4,4,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-4,4,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(ishitwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().blunt3();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("slash") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(4,4,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-4,4,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(ishitwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().dagger1();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("storm") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(1,1,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-1,1,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(stormwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().dagger4();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("chop") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(4,1,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-4,1,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(ishitwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().axe1();
		}else if(c.tag == "weapon" & playerscript.FindChild(guiscript.objectname).transform.GetComponent<Animator>().GetBool("uppercut") == true & playerscript.GetComponent<GaryCharacterController>().alreadyhit == false){
			if(enemyscript.GetComponent<cubeenemy>().ishit == false){
				if(playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(2,5,0);
				}else if (playerscript.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == false){
					enemyscript.GetComponent<cubeenemy>().enemy.rigidbody.velocity = new Vector3(-2,5,0);
				}
			}
			enemyscript.GetComponent<cubeenemy>().ishit = true;
			StartCoroutine(ishitwait());
			playerscript.GetComponent<GaryCharacterController>().alreadyhit = true;
			enemyscript.GetComponent<cubeenemy>().axe3();
		}

	}
	void OnMouseOver(){
		guiscript.enemylocked = enemy;
		guiscript.ishovering = true;
		guiscript.ishoveringweap = false;
		guiscript.enemylevel = enemyscript.GetComponent<cubeenemy> ().level;
		guiscript.enemycurrenthealth = enemyscript.GetComponent<cubeenemy> ().currenthealth;
		guiscript.enemymaxhealth = enemyscript.GetComponent<cubeenemy> ().maxhealth;
	}
	public IEnumerator ishitwait() {
		yield return new WaitForSeconds(.6f);
		enemyscript.GetComponent<cubeenemy>().ishit = false;
	}
	public IEnumerator tornadowait() {
		yield return new WaitForSeconds(.25f);
		playerscript.GetComponent<GaryCharacterController>().alreadyhit = false;
		enemyscript.GetComponent<cubeenemy>().ishit = false;
	}
	public IEnumerator stormwait() {
		yield return new WaitForSeconds(.12f);
		playerscript.GetComponent<GaryCharacterController>().alreadyhit = false;
		enemyscript.GetComponent<cubeenemy>().ishit = false;
	}
}

