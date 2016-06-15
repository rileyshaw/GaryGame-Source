using UnityEngine;
using System.Collections;

public class cubeenemy : MonoBehaviour {
	public Transform enemy;
	private Transform player;
	public int level;
	public bool hitting = false;

	public int currenthealth;
	public float distance;
	public Animator weaponanim;
	public string enemyname;


	public float alertradius = 4;
	public int enemyi;

	public int damage;
	public int attackspeed;
	public int maxhealth;
	public int maxshield;
	public int bleeddamage;
	public decimal speed;
	public decimal bleeddamagechance;
	public decimal stunchance;
	public decimal criticalchance;
	public decimal healthabsorb;
	public decimal armor;

	public bool alreadyhit = false;
	private Transform cubeheatlhbar;
	public GameObject xpexplosion;
	public GUIscript guiscript;
	public bool ishovering;
	public int xpreward;
	public string objectname;
	public int currentshield;
	public bool ishit = false;
	public playersetup playersetup;
	public bool isbleeding;
	public int bleedhitsleft;
	public bool isstunned = false;
	public bool isexploding = false;
	public string animatorobject;
	private int hitstaken = 0;
	// Use this for initialization
	void Start () {	
		playersetup = GameObject.Find ("GameController").transform.GetComponent<playersetup>();
		GameObject go = GameObject.FindGameObjectWithTag("Finish");
		player = go.transform;
		enemy = transform.FindChild ("Cube").transform;
		if(playersetup.enemies[enemyi].hasweapon == true){
			weaponanim = enemy.FindChild (objectname).GetComponent<Animator>();
		}

		currenthealth = maxhealth;
		cubeheatlhbar = transform.FindChild("Healthbar").transform;
		guiscript = GameObject.Find ("GameController").transform.GetComponent<GUIscript>();
	
	}
	
	// Update is called once per frame
	void explode(){
		GameObject obj = (GameObject)Instantiate (Resources.Load("suicideexplosion"), new Vector3(transform.FindChild("Cube").transform.position.x +.5f,transform.FindChild("Cube").transform.position.y,transform.FindChild("Cube").transform.position.z), transform.rotation);
		obj.GetComponent<suicideset>().suicidedamage = damage;
		Destroy(gameObject);
	}
	void Update () {
		if(isexploding == true){
			enemy.transform.localScale = new Vector3(enemy.transform.localScale.x+.04f,enemy.transform.localScale.y+.04f,enemy.transform.localScale.z+.04f);
			if(enemy.transform.localScale.x > 2){
				explode();
			}
		}
		if(playersetup.enemies[enemyi].hasweapon == true){
			if(player.GetComponent<GaryCharacterController>().isplaying == true){
				transform.FindChild ("Healthbar").transform.position = new Vector3 (enemy.position.x,enemy.position.y + 1f,enemy.position.z-.5f);
					if(isstunned == false){
						
						distance = Mathf.Abs(enemy.position.x-player.transform.position.x);
						if(ishit == false){
							if(distance <alertradius & weaponanim.GetBool("Attack") == false){
								if (enemy.position.x - player.position.x >0) {
									enemy.rigidbody.velocity = new Vector3(-4f*(float)speed,enemy.rigidbody.velocity.y, 0);
									enemy.rotation = Quaternion.Euler(new Vector3(0,0,0));
									weaponanim.SetBool("isright",false);
									weaponanim.SetBool("ismoving",true);
									if(enemyname != "Heavy Cube"){
										enemy.FindChild (objectname).transform.position = new Vector3(enemy.FindChild (objectname).transform.position.x,enemy.FindChild (objectname).transform.position.y,-.85f);
										enemy.FindChild (objectname).transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
									}else{
										enemy.FindChild (objectname).transform.position = new Vector3(enemy.FindChild (objectname).transform.position.x,enemy.FindChild (objectname).transform.position.y,-1.1f);
										enemy.FindChild (objectname).transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
									}
								}
								if (enemy.position.x - player.position.x  <=0) {
									enemy.rigidbody.velocity = new Vector3(4f*(float)speed, enemy.rigidbody.velocity.y, 0);
									enemy.rotation = Quaternion.Euler(new Vector3(0,-180,0));
									weaponanim.SetBool("isright",true);
									weaponanim.SetBool("ismoving",true);
									if(enemyname != "Heavy Cube"){
										enemy.FindChild (objectname).transform.position = new Vector3(enemy.FindChild (objectname).transform.position.x,enemy.FindChild (objectname).transform.position.y,-.85f);
										enemy.FindChild (objectname).transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
									}else{
										enemy.FindChild (objectname).transform.position = new Vector3(enemy.FindChild (objectname).transform.position.x,enemy.FindChild (objectname).transform.position.y,-1.1f);
										enemy.FindChild (objectname).transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
									}
								}
							}else{
								enemy.rigidbody.velocity = new Vector3(0,enemy.rigidbody.velocity.y,0);
								weaponanim.SetBool("ismoving",false);
							}
							if(distance < 1.3f & hitting == false){
								hitting = true;
								weaponanim.SetBool("Attack",true);
								StartCoroutine(hitwait());
								
							}
						}
					}else{
						weaponanim.SetBool("ismoving",false);
						enemy.rigidbody.velocity = new Vector3(enemy.rigidbody.velocity.x,enemy.rigidbody.velocity.y,0);
					}
				}else{
					enemy.rigidbody.velocity = new Vector3(0,enemy.rigidbody.velocity.y,0);
					weaponanim.SetBool("ismoving",false);
				}
			}else{
				if(isexploding == false){
					if(player.GetComponent<GaryCharacterController>().isplaying == true){
						if(isstunned == false){
							transform.FindChild ("Healthbar").transform.position = new Vector3 (enemy.position.x,enemy.position.y + 1f,enemy.position.z-.5f);
							distance = Mathf.Abs(Vector3.Distance(enemy.position,player.transform.position));
							if(ishit == false){
								if(distance <alertradius){
									if (enemy.position.x - player.position.x >0) {
										enemy.rigidbody.velocity = new Vector3(-4f*(float)speed,enemy.rigidbody.velocity.y, 0);
										enemy.rotation = Quaternion.Euler(new Vector3(0,0,0));
									}
									if (enemy.position.x - player.position.x  <=0) {
										enemy.rigidbody.velocity = new Vector3(4f*(float)speed, enemy.rigidbody.velocity.y, 0);
										enemy.rotation = Quaternion.Euler(new Vector3(0,-180,0));
									}
								}else{
									enemy.rigidbody.velocity = new Vector3(0,enemy.rigidbody.velocity.y,0);
								}
								if(distance < 2f ){
									hitting = true;
									isexploding = true;

								}
							}
						}else{
							enemy.rigidbody.velocity = new Vector3(0,enemy.rigidbody.velocity.y,0);
						}
					}else{
						enemy.rigidbody.velocity = new Vector3(0,enemy.rigidbody.velocity.y,0);
					}
				}else{	
				enemy.rigidbody.velocity = new Vector3(0,enemy.rigidbody.velocity.y,0);
				}
			}
			
		}
		IEnumerator hitwait() {
			weaponanim.speed  = ((float)(transform.GetComponent<cubeenemy>().attackspeed + enemy.FindChild (objectname).FindChild (animatorobject).GetComponent<weaponhover> ().weapattspeed)) / 10;
			yield return new WaitForSeconds(.52f / weaponanim.speed);
			weaponanim.speed = 1f;
			weaponanim.SetBool("Attack",false);
			alreadyhit = false;
			hitting = false;
			if (enemy.position.x - player.position.x >0 &weaponanim.GetBool("Attack") == false) {
				enemy.rotation = Quaternion.Euler(new Vector3(0,0,0));
				weaponanim.SetBool("isright",false);
				if(enemyname != "Heavy Cube"){
					enemy.FindChild (objectname).transform.position = new Vector3(enemy.FindChild (objectname).transform.position.x,enemy.FindChild (objectname).transform.position.y,-.85f);
					enemy.FindChild (objectname).transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
				}else{
					enemy.FindChild (objectname).transform.position = new Vector3(enemy.FindChild (objectname).transform.position.x,enemy.FindChild (objectname).transform.position.y,-1.1f);
					enemy.FindChild (objectname).transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
				}
			}
			if (enemy.position.x - player.position.x  <=0 & weaponanim.GetBool("Attack") == false) {
				enemy.rotation = Quaternion.Euler(new Vector3(0,-180,0));
				weaponanim.SetBool("isright",true);
				if(enemyname != "Heavy Cube"){
					enemy.FindChild (objectname).transform.position = new Vector3(enemy.FindChild (objectname).transform.position.x,enemy.FindChild (objectname).transform.position.y,-.85f);
					enemy.FindChild (objectname).transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
				}else{
					enemy.FindChild (objectname).transform.position = new Vector3(enemy.FindChild (objectname).transform.position.x,enemy.FindChild (objectname).transform.position.y,-1.1f);
					enemy.FindChild (objectname).transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
				}
			}

	}
	public void hand1(){
		if(currenthealth - (int)(3*guiscript.playerweapdamagebuff* (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete = true;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.stunchance = playersetup.player.stunchance + .02m;
			}
			isstunned = true;
			StartCoroutine(stunwait());

			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			currenthealth = currenthealth -(int)(3*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) <=  playersetup.player.overhealth) {
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			}else{
				playersetup.player.currenthealth =playersetup.player.overhealth;
			}
		}else{
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			if(playersetup.player.currenthealth + (int)(3*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)))< playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(3*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)));
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
			playersetup.player.totalkills++;
			currenthealth = 0;
			int damagedealt = (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
			death();
		}
	}
	public void hand4(){
		if(currenthealth - (int)(2*guiscript.playerweapdamagebuff* (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			currenthealth = currenthealth -(int)(3*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) <=  playersetup.player.overhealth) {
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
		}else{
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			if(playersetup.player.currenthealth + (int)(3*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)))< playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(3*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)));
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
			playersetup.player.totalkills++;
			currenthealth = 0;
			int damagedealt = (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
			death();
		}
	}
	public void shortsword1(){
		if(currenthealth - (int)(4*guiscript.playerweapdamagebuff* (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete = true;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.stunchance = playersetup.player.stunchance + .02m;
			}
			
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			currenthealth = currenthealth -(int)(4*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) <=  playersetup.player.overhealth) {
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			}else{
				playersetup.player.currenthealth =playersetup.player.overhealth;
			}
		}else{
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			if(playersetup.player.currenthealth + (int)(4*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)))< playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(4*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)));
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
			playersetup.player.totalkills++;
			currenthealth = 0;
			int damagedealt = (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
			death();
		}
	}
	public void shortsword2(){
		if(currenthealth - (int)(5*guiscript.playerweapdamagebuff* (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete = true;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.stunchance = playersetup.player.stunchance + .02m;
			}
			
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(5*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			currenthealth = currenthealth -(int)(5*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + (int)(5*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) <=  playersetup.player.overhealth) {
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(5*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			}else{
				playersetup.player.currenthealth =playersetup.player.overhealth;
			}
		}else{
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(5*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			if(playersetup.player.currenthealth + (int)(5*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)))< playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(5*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)));
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
			playersetup.player.totalkills++;
			currenthealth = 0;
			int damagedealt = (int)(5*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
			death();
		}

	}
	public void shortsword4(){
		if(currenthealth - (int)(8*guiscript.playerweapdamagebuff* (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete = true;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.stunchance = playersetup.player.stunchance + .02m;
			}
			
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(8*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			currenthealth = currenthealth -(int)(8*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + (int)(8*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) <=  playersetup.player.overhealth) {
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(8*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			}else{
				playersetup.player.currenthealth =playersetup.player.overhealth;
			}
		}else{
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(8*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			if(playersetup.player.currenthealth + (int)(8*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)))< playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(8*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)));
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
			playersetup.player.totalkills++;
			currenthealth = 0;
			int damagedealt = (int)(8*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
			death();
		}
	}
	public void blunt1(){
		if(currenthealth - (int)(2*guiscript.playerweapdamagebuff* (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete = true;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.stunchance = playersetup.player.stunchance + .02m;
			}
			
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(2*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			currenthealth = currenthealth -(int)(2*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			int damagedealt = (int)(2*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + damagedealt < playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + damagedealt;
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
		}else{
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(2*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			playersetup.player.totalkills++;
			currenthealth = 0;
			int damagedealt = (int)(2*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + damagedealt < playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + damagedealt;
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
			death();
		}
	}
	public void blunt3(){
		if(currenthealth - (int)(5*guiscript.playerweapdamagebuff* (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete = true;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.stunchance = playersetup.player.stunchance + .02m;
			}
			
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			currenthealth = currenthealth -(int)(5*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			int damagedealt = (int)(5*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + damagedealt < playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + damagedealt;
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
		}else{
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(5*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			playersetup.player.totalkills++;
			currenthealth = 0;
			int damagedealt = (int)(5*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + damagedealt < playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + damagedealt;
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
			death();
		}
	}
	public void dagger4(){
		if(currenthealth - (int)(2*guiscript.playerweapdamagebuff* (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete = true;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.stunchance = playersetup.player.stunchance + .02m;
			}
			
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(2*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			currenthealth = currenthealth -(int)(2*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			int damagedealt = (int)(2*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + damagedealt < playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + damagedealt;
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
		}else{
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(2*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			playersetup.player.totalkills++;
			currenthealth = 0;
			int damagedealt = (int)(2*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + damagedealt < playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + damagedealt;
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
			death();
		}
	}
	public void dagger1(){
		bleedhitsleft = 10;
		StartCoroutine(doublebleedhit());
		GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
		damagetext.GetComponent<textrise>().type = 2;
		damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
		damagetext.GetComponent<TextMesh>().text = "Bleed Hit!";
	}
	public void axe1(){
		if(currenthealth - (int)(4*guiscript.playerweapdamagebuff* (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete = true;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.stunchance = playersetup.player.stunchance + .02m;
			}
			isstunned = true;
			StartCoroutine(stunwait());
			
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			currenthealth = currenthealth -(int)(4*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(playersetup.player.currenthealth + (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) <=  playersetup.player.overhealth) {
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			}else{
				playersetup.player.currenthealth =playersetup.player.overhealth;
			}
		}else{
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			if(playersetup.player.currenthealth + (int)(4*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)))< playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(4*guiscript.playerweapdamagebuff*((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)));
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
			playersetup.player.totalkills++;
			currenthealth = 0;
			int damagedealt = (int)(4*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
			death();
		}
	}
	public void axe3(){
		bleedhitsleft = 10;
		StartCoroutine(bleedhit());
		GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
		damagetext.GetComponent<textrise>().type = 2;
		damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
		damagetext.GetComponent<TextMesh>().text = "Bleed Hit!";
		playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress++;
		if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete == false){
			playersetup.player.challengeprogress++;
			playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].xpreward;
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete = true;
			playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
			guiscript.displayingupdater = true;
			guiscript.displayingtype = "Weapon Challenge Complete!";
			guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].name;
			
			if(playersetup.player.currentxp >= playersetup.player.xptolevel){
				do{
					playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
					playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
					if(playersetup.player.playerlevel <=99){
						playersetup.player.playerlevel++;
					}
				}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
			}
			playersetup.player.stunchance = playersetup.player.stunchance + .02m;
		}
		
		GameObject damagetexter = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f+(.5f),transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
		damagetexter.GetComponent<textrise>().type = 2;
		damagetexter.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+(.5f),transform.position.z);
		damagetexter.GetComponent<TextMesh>().text = "Stunned!";
		isstunned = true;
		StartCoroutine(stunwait());

	}
	public void takedamage(){
		int healthoriginal = playersetup.player.currenthealth;
		int healthadded;
		int ishitter =0;
		hitstaken++;
		if (player.GetComponent<GaryCharacterController>().weaponanim.GetBool("isright") == true){
			ishit = true;
			enemy.rigidbody.velocity = new Vector3(2.5f,2.5f,0);
		}else{
			ishit = true;
			enemy.rigidbody.velocity = new Vector3(-2.5f,2.5f, 0);
		}
		if((int)(playersetup.player.adrenalinecurrent  + (playersetup.player.adrenalinerate +guiscript.playerweapadrenalinerate)*(1+playersetup.itemtypes[guiscript.playerweaptypei].bonusadrenaline))<= playersetup.player.adrenalinemax){
			playersetup.player.adrenalinecurrent =playersetup.player.adrenalinecurrent +(int)((playersetup.player.adrenalinerate + guiscript.playerweapadrenalinerate)*(1+playersetup.itemtypes[guiscript.playerweaptypei].bonusadrenaline));
		}else{
			playersetup.player.adrenalinecurrent =playersetup.player.adrenalinemax;
		}
		int orignialhealth = currenthealth;
		if(currenthealth - (int)(guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
			if(Random.value < (float)((playersetup.player.bleeddamagechance +guiscript.playerweapbleeddamagechance)  + (playersetup.itemtypes[guiscript.playerweaptypei].bonusbleeddamage))){
				ishitter++;
				bleedhitsleft = 10;
				StartCoroutine(bleedhit());
				GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
				damagetext.GetComponent<textrise>().type = 2;
				damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
				damagetext.GetComponent<TextMesh>().text = "Bleed Hit!";
			}
			if(Random.value < (float)(guiscript.playerweapdamagebuff*(playersetup.player.criticalchance +guiscript.playerweapcriticalchance) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonuscriticalchance))|| guiscript.playerweapcriticalchancebuff >=2){
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[3].currentprogress++;
				if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[3].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[3].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[3].iscomplete == false){
					playersetup.player.challengeprogress++;
					playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[3].xpreward;
					playersetup.itemtypes[guiscript.playerweaptypei].challenges[3].iscomplete = true;
					playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
					if(playersetup.player.currentxp >= playersetup.player.xptolevel){
						guiscript.displayingupdater = true;
						guiscript.displayingtype = "Weapon Challenge Complete!";
						guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[3].name;
						 
						do{
							playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
							playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
							if(playersetup.player.playerlevel <=99){
								playersetup.player.playerlevel++;
							}
						}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
					}
					playersetup.player.criticalchance = playersetup.player.criticalchance + .02m;
				}
				GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f+(ishitter*.4f),transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
				damagetext.GetComponent<textrise>().type = 2;
				damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+(ishitter*.4f),transform.position.z);
				damagetext.GetComponent<TextMesh>().text = "Critical Hit!";
				/*if(currenthealth - 3*((playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage))> 0){
					currenthealth = currenthealth -(int)(3*guiscript.playerweapdamagebuff*((playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)));
					playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(3*guiscript.playerweapdamagebuff*((playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)));
				}else{
					playersetup.player.totalkills++;
					currenthealth = 0;
					death();
				}
				*/ 
				int damagedealter = (int)(3*guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
				if(playersetup.player.currenthealth + (int)(3*(guiscript.playerweaphealthabsorbbuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  + (playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)))< playersetup.player.overhealth){
					playersetup.player.currenthealth = playersetup.player.currenthealth + (int)(3*(guiscript.playerweaphealthabsorbbuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  +(playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)));
				}else{
					playersetup.player.currenthealth = playersetup.player.overhealth;
				}
				if(guiscript.playerweapdamagebuff>1){
					playersetup.player.currenthealth = playersetup.player.currenthealth +(int)(damagedealter/(guiscript.playerweapdamagebuff-1));
					if(playersetup.player.currenthealth > playersetup.player.overhealth){
						playersetup.player.currenthealth = playersetup.player.overhealth;
					}
				}
				ishitter++;
			}
			if(Random.value < (float)(playersetup.player.stunchance +(guiscript.playerweapstunchance  * playersetup.itemtypes[guiscript.playerweaptypei].bonusstunchance) + guiscript.playerweapstunchance)){
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress++;
				if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete == false){
					playersetup.player.challengeprogress++;
					playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].xpreward;
					playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].iscomplete = true;
					playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
					guiscript.displayingupdater = true;
					guiscript.displayingtype = "Weapon Challenge Complete!";
					guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[5].name;
					 
					if(playersetup.player.currentxp >= playersetup.player.xptolevel){
						do{
							playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
							playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
							if(playersetup.player.playerlevel <=99){
								playersetup.player.playerlevel++;
							}
						}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
					}
					playersetup.player.stunchance = playersetup.player.stunchance + .02m;
				}

				GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f+(ishitter*.5f),transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
				damagetext.GetComponent<textrise>().type = 2;
				damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+(ishitter*.5f),transform.position.z);
				damagetext.GetComponent<TextMesh>().text = "Stunned!";
				ishitter++;
				isstunned = true;
				StartCoroutine(stunwait());
				
			}
			if(ishitter == 0){
				GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f+(ishitter*.5f),transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
				damagetext.GetComponent<textrise>().type = 2;
				damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+(ishitter*.5f),transform.position.z);
				damagetext.GetComponent<TextMesh>().text = "-"+ (int)(guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
				currenthealth = currenthealth -(int)((playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
				if(playersetup.player.currenthealth + (int)((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  + (playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) <= playersetup.player.overhealth) {
					playersetup.player.currenthealth = playersetup.player.currenthealth + (int)((playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  + (playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
				}else{
					playersetup.player.currenthealth = playersetup.player.overhealth;
				}
				int damagedealter = (int)(guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
				if(guiscript.playerweaphealthabsorbbuff>1){
					playersetup.player.currenthealth = playersetup.player.currenthealth +(int)(damagedealter*(guiscript.playerweaphealthabsorbbuff-1));
					if(playersetup.player.currenthealth > playersetup.player.overhealth){
						playersetup.player.currenthealth = playersetup.player.overhealth;
					}
				}
			}
			int damagedealt = orignialhealth - currenthealth;
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;

				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				 
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
		}else{
			GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
			damagetext.GetComponent<textrise>().type = 2;
			damagetext.GetComponent<textrise>().transformer = new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
			damagetext.GetComponent<TextMesh>().text = "-"+ (int)(guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)) + " hp";
			if(playersetup.player.currenthealth + (int)((guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  +(playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)))< playersetup.player.overhealth){
				playersetup.player.currenthealth = playersetup.player.currenthealth + (int)((guiscript.playerweapdamagebuff*(playersetup.player.healthabsorb +guiscript.playerweaphealthabsorb)  +(playersetup.itemtypes[guiscript.playerweaptypei].bonushealthabsorb) * (playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage)));
			}else{
				playersetup.player.currenthealth = playersetup.player.overhealth;
			}
			int damagedealter = (int)(guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			if(guiscript.playerweaphealthabsorbbuff>1){
				playersetup.player.currenthealth = playersetup.player.currenthealth +(int)(damagedealter*(guiscript.playerweaphealthabsorbbuff-1));
				if(playersetup.player.currenthealth > playersetup.player.overhealth){
					playersetup.player.currenthealth = playersetup.player.overhealth;
				}
			}
			playersetup.player.totalkills++;
			currenthealth = 0;
			int damagedealt = (int)(guiscript.playerweapdamagebuff*(playersetup.player.damage +guiscript.playerweapdamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusdamage));
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress + damagedealt;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[2].name;
				 
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
			death();
		}
		healthadded =  playersetup.player.currenthealth-healthoriginal;
		playersetup.itemtypes[guiscript.playerweaptypei].challenges[6].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[6].currentprogress + healthadded;
		if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[6].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[6].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[6].iscomplete == false){
			playersetup.player.challengeprogress++;
			playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
			playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[6].xpreward;
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[6].iscomplete = true;
			guiscript.displayingupdater = true;
			guiscript.displayingtype = "Weapon Challenge Complete!";
			guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[6].name;
			 
			if(playersetup.player.currentxp >= playersetup.player.xptolevel){
				do{
					playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
					playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
					if(playersetup.player.playerlevel <=99){
						playersetup.player.playerlevel++;
					}
				}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
			}
			playersetup.player.healthabsorb = playersetup.player.healthabsorb + .02m;
		}
		cubeheatlhbar.localScale = new Vector3(((float)currenthealth)/((float)maxhealth),.12f,.12f);

	}
	public void death(){
		if(player.GetComponent<GaryCharacterController>().jumpcount>0){
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[7].currentprogress++;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[7].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[7].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[7].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[7].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[7].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[7].name;
				 
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.attackspeed = playersetup.player.attackspeed + 2;
			}
		}
		if(hitstaken == 1){
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[8].currentprogress++;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[8].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[8].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[8].iscomplete == false){
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.challengeprogress++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[8].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[8].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[8].name;
				 
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
		}
		if(playersetup.enemies[enemyi].hasweapon == true){
			guiscript.enemylocked = null;
			GameObject obj = (GameObject)Instantiate (xpexplosion, new Vector3(transform.FindChild("Cube").transform.position.x +.5f,transform.FindChild("Cube").transform.position.y,transform.FindChild("Cube").transform.position.z), transform.rotation);
			GameObject weap = transform.FindChild("Cube").transform.FindChild(objectname).gameObject;
			GameObject weapon;
			xpset sc = obj.GetComponent<xpset>();
			Destroy(weap.transform.parent.FindChild("Sphere").gameObject);
			transform.FindChild("Cube").DetachChildren();
			weap.transform.FindChild(animatorobject).name = weap.name;
			weapon = weap.transform.FindChild(weap.name).gameObject;
			weap.transform.DetachChildren();
			Destroy(weap.gameObject);
			weapon.GetComponent<BoxCollider> ().isTrigger = false;
			weapon.GetComponent<weaponhover>().enabled = true;
			weapon.GetComponent<Rigidbody>().useGravity = true;
			weapon.GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-6,6),6,0);
			sc.xpvalue = (int)(xpreward / 8);
			Destroy(gameObject);
		}else{
			guiscript.enemylocked = null;
			GameObject obj = (GameObject)Instantiate (xpexplosion, new Vector3(transform.FindChild("Cube").transform.position.x +.5f,transform.FindChild("Cube").transform.position.y,transform.FindChild("Cube").transform.position.z), transform.rotation);
			xpset sc = obj.GetComponent<xpset>();
			sc.xpvalue = (int)(xpreward / 8);
			Destroy(gameObject);
		}
		playersetup.itemtypes[guiscript.playerweaptypei].challenges[0].currentprogress++;
		if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[0].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[0].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[0].iscomplete == false){
			playersetup.player.challengeprogress++;
			playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
			playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[0].xpreward;
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[0].iscomplete = true;
			guiscript.displayingupdater = true;
			guiscript.displayingtype = "Weapon Challenge Complete!";
			guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[0].name;
			 
			if(playersetup.player.currentxp >= playersetup.player.xptolevel){
				do{
					playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
					playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
					if(playersetup.player.playerlevel <=99){
						playersetup.player.playerlevel++;
					}
				}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
			}
			playersetup.player.overhealth = playersetup.player.overhealth + 25;
		}
		if(enemyname == "Evil Cube"){
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[9].currentprogress++;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[9].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[9].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[9].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[9].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[9].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[9].name;
				 
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
		}else if(enemyname == "Fast Cube"){
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[10].currentprogress++;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[10].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[10].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[10].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[10].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[10].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[10].name;
				 
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
		}else if(enemyname == "Heavy Cube"){
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[11].currentprogress++;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[11].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[11].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[11].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[11].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[11].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[11].name;
				 
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
		}else if(enemyname == "Deadly Cube"){
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[12].currentprogress++;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[12].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[12].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[12].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[12].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[12].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[12].name;
				 
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
		}else if(enemyname == "Suicide Cube"){
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[13].currentprogress++;
			if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[13].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[13].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[13].iscomplete == false){
				playersetup.player.challengeprogress++;
				playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
				playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[13].xpreward;
				playersetup.itemtypes[guiscript.playerweaptypei].challenges[13].iscomplete = true;
				guiscript.displayingupdater = true;
				guiscript.displayingtype = "Weapon Challenge Complete!";
				guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[13].name;
				 
				if(playersetup.player.currentxp >= playersetup.player.xptolevel){
					do{
						playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
						playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
						if(playersetup.player.playerlevel <=99){
							playersetup.player.playerlevel++;
						}
					}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
				}
				playersetup.player.damage = playersetup.player.damage + 25;
			}
		}
	}
	IEnumerator bleedhit() {
		yield return new WaitForSeconds(.4f);
		playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].currentprogress +  (int)((playersetup.player.bleeddamage +guiscript.playerweapbleeddamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusbleeddamage))+1;
		if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].iscomplete == false){
			playersetup.player.challengeprogress++;
			playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
			playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].xpreward;
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].iscomplete = true;
			guiscript.displayingupdater = true;
			guiscript.displayingtype = "Weapon Challenge Complete!";
			guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].name;
			 
			if(playersetup.player.currentxp >= playersetup.player.xptolevel){
				do{
					playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
					playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
					if(playersetup.player.playerlevel <=99){
						playersetup.player.playerlevel++;
					}
				}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
			}
			playersetup.player.bleeddamage = playersetup.player.bleeddamage + 10;
		}
		bleedhitsleft--;
		if(currenthealth -  (int)(1+((playersetup.player.bleeddamage +guiscript.playerweapbleeddamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusbleeddamage))) +1> 0){
			currenthealth = currenthealth - (int)(1+((playersetup.player.bleeddamage +guiscript.playerweapbleeddamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusbleeddamage))) ;
		}else{
			playersetup.player.totalkills++;
			currenthealth = 0;
			death();
		}
		GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
		damagetext.GetComponent<textrise>().type = 2;
		damagetext.GetComponent<textrise>().transformer =new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
		damagetext.GetComponent<TextMesh>().text = "-"+ (int)(1+((playersetup.player.bleeddamage +guiscript.playerweapbleeddamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusbleeddamage))) + " hp";
		if(bleedhitsleft >0){
			StartCoroutine(bleedhit());
		}
		cubeheatlhbar.localScale = new Vector3((float)currenthealth/(float)maxhealth,.12f,.12f);
	}
	IEnumerator stunwait() {
		yield return new WaitForSeconds(2f);
		isstunned = false;
	}
	IEnumerator doublebleedhit() {
		yield return new WaitForSeconds(.4f);
		playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].currentprogress = playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].currentprogress +  (int)((playersetup.player.bleeddamage +guiscript.playerweapbleeddamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusbleeddamage))+1;
		if(playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].currentprogress >= playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].maxprogress & playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].iscomplete == false){
			playersetup.player.challengeprogress++;
			playersetup.itemtypes[guiscript.playerweaptypei].currentchallengescomplete++;
			playersetup.player.currentxp = playersetup.player.currentxp + playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].xpreward;
			playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].iscomplete = true;
			guiscript.displayingupdater = true;
			guiscript.displayingtype = "Weapon Challenge Complete!";
			guiscript.displayingname = playersetup.itemtypes[guiscript.playerweaptypei].challenges[4].name;
			
			if(playersetup.player.currentxp >= playersetup.player.xptolevel){
				do{
					playersetup.player.currentxp = playersetup.player.currentxp - playersetup.player.xptolevel;
					playersetup.player.xptolevel = (int)(playersetup.player.xptolevel * 1.03f);
					if(playersetup.player.playerlevel <=99){
						playersetup.player.playerlevel++;
					}
				}while(playersetup.player.currentxp >= playersetup.player.xptolevel);
			}
			playersetup.player.bleeddamage = playersetup.player.bleeddamage + 10;
		}
		bleedhitsleft--;
		if(currenthealth - 2*(int)((playersetup.player.bleeddamage +guiscript.playerweapbleeddamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusbleeddamage))+1> 0){
			currenthealth = currenthealth - 2*(1+(int)((playersetup.player.bleeddamage +guiscript.playerweapbleeddamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusbleeddamage)));
		}else{
			playersetup.player.totalkills++;
			currenthealth = 0;
			death();
		}
		GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y+.8f,transform.FindChild("Cube").transform.localPosition.z))), Quaternion.identity));
		damagetext.GetComponent<textrise>().type = 2;
		damagetext.GetComponent<textrise>().transformer =new Vector3(transform.FindChild("Cube").transform.position.x,transform.FindChild("Cube").transform.position.y,transform.position.z);
		damagetext.GetComponent<TextMesh>().text = "-"+ (int)2*(1+((playersetup.player.bleeddamage +guiscript.playerweapbleeddamage) * (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusbleeddamage))) + " hp";
		if(bleedhitsleft >0){
			StartCoroutine(doublebleedhit());
		}
		cubeheatlhbar.localScale = new Vector3((float)currenthealth/(float)maxhealth,.12f,.12f);
	}
}







	


	