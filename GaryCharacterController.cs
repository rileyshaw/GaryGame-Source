using UnityEngine;
using System.Collections;
public class GaryCharacterController : MonoBehaviour {
	// Use this for initialization
	private Transform player;
	public int jumpcount = 0;
	public bool isplaying = true;
	public bool isattacking = false;
	public Animator weaponanim;
	public bool alreadyhit = false;
	public bool isbouncing = false;
	public string weaponname;
	public GUIscript guiscript;
	public float animationlength;
	public bool ishit = false;
	private playersetup playersetup;
	private bool losingadrenaline = false;
	public bool isshieldwaiting = false;
	public bool isshielddelay = false;
	private bool isjumped = false;
	public bool isdarting = false;
	public int hitcounter = 0;
	public bool istouch = false;
	public bool onladder = false;
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Finish");
		player = go.transform;
		guiscript = GameObject.Find ("GameController").transform.GetComponent<GUIscript>();
		playersetup = GameObject.FindGameObjectWithTag("GameController").transform.GetComponent<playersetup>();
		GameObject.Find ("GameController").transform.GetComponent<playersetup>().player.adrenalinecurrent = 0;
		playersetup.guiscript = gameObject.transform.GetComponent<GUIscript>();

	}
	void FixedUpdate(){
		if(guiscript.isinitialized == true){
			if(isplaying == true ){
				if(losingadrenaline == false){
					StartCoroutine(loseadrenaline());
				}
				if (Input.mousePosition.x-Screen.width/2>0 & weaponanim.GetBool("Attack") == false) {
					player.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
					GameObject.Find ("Player").transform.FindChild(guiscript.objectname).transform.position = new Vector3(GameObject.Find ("Player").transform.FindChild(guiscript.objectname).transform.position.x,GameObject.Find ("Player").transform.FindChild(guiscript.objectname).transform.position.y,-.85f);
					GameObject.Find ("Player").transform.FindChild(guiscript.objectname).transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
					weaponanim.SetBool("isright",true);
				}else if(Input.mousePosition.x-Screen.width/2<0 & weaponanim.GetBool("Attack") == false){
					player.transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
					GameObject.Find ("Player").transform.FindChild(guiscript.objectname).transform.position = new Vector3(GameObject.Find ("Player").transform.FindChild(guiscript.objectname).transform.position.x,GameObject.Find ("Player").transform.FindChild(guiscript.objectname).transform.position.y,-.85f);
					GameObject.Find ("Player").transform.FindChild(guiscript.objectname).transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
					weaponanim.SetBool("isright",false);
				}
				if (Input.GetMouseButton(0) == true & isattacking == false){
					if(Input.mousePosition.x > 20 & Input.mousePosition.x < 330 &  Input.mousePosition.y > 20 &  Input.mousePosition.y < 220){

					}else{
						if(guiscript.ishovering == true |guiscript.ishoveringweap == true){

							if(Input.mousePosition.x > Screen.width-350  & Input.mousePosition.x < Screen.width-20 & Input.mousePosition.y > 20 & Input.mousePosition.y < 220  ){
							}else{
								isattacking = true;
								weaponanim.SetBool("Attack",true);
								StartCoroutine(attacking());
							}
						}else{
							isattacking = true;
							weaponanim.SetBool("Attack",true);
							StartCoroutine(attacking());
						}
					}

				}
				if(isdarting == false & onladder == false){
					if(Input.GetKey(KeyCode.D) == false & Input.GetKey(KeyCode.A) == false ){
						weaponanim.SetBool("ismoving",false);
					}
					if(ishit == false){
						if(Input.GetKey(KeyCode.D) == false & isbouncing ==false){
							rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
						}
						if(Input.GetKey(KeyCode.A) == false &isbouncing == false){
							rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
						}
						if(Input.GetKey(KeyCode.A) == true){
							rigidbody.velocity = new Vector3(-5, rigidbody.velocity.y, 0);
							weaponanim.SetBool("ismoving",true);
							isbouncing = false;
						}
						if(Input.GetKey(KeyCode.D) == true){
							rigidbody.velocity = new Vector3(5, rigidbody.velocity.y, 0);
							weaponanim.SetBool("ismoving",true);
							isbouncing = false;
						}

					}
					if(Input.GetKey(KeyCode.W) == true & jumpcount <1 & isjumped == false){
						rigidbody.velocity = new Vector3(rigidbody.velocity.x,5, 0);
						isjumped = true;
						jumpcount++;
					}
					if(Input.GetKey(KeyCode.W) == false){
						isjumped = false;
					}
				}else if(isdarting == false & onladder == true){
					if(Input.GetKey(KeyCode.D) == false & Input.GetKey(KeyCode.A) == false ){
						weaponanim.SetBool("ismoving",false);
					}
					if(ishit == false){
						if(Input.GetKey(KeyCode.D) == false & isbouncing ==false){
							rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
						}
						if(Input.GetKey(KeyCode.A) == false &isbouncing == false){
							rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
						}
						if(Input.GetKey(KeyCode.A) == true){
							rigidbody.velocity = new Vector3(-5, rigidbody.velocity.y, 0);
							weaponanim.SetBool("ismoving",true);
							isbouncing = false;
						}
						if(Input.GetKey(KeyCode.D) == true){
							rigidbody.velocity = new Vector3(5, rigidbody.velocity.y, 0);
							weaponanim.SetBool("ismoving",true);
							isbouncing = false;
						}
						
					}
					if(Input.GetKey(KeyCode.W) == true){
						rigidbody.velocity = new Vector3(rigidbody.velocity.x,5, 0);
					}
					if(Input.GetKey(KeyCode.S) == true){
						rigidbody.velocity = new Vector3(rigidbody.velocity.x,-5, 0);
					}
					if(Input.GetKey(KeyCode.W) == false & Input.GetKey(KeyCode.S) == false){
						rigidbody.velocity = new Vector3(rigidbody.velocity.x,0, 0);
					}
				}
			}else{
				rigidbody.velocity = new Vector3(0,0, 0);
				if(isbouncing == false){
					weaponanim.SetBool("ismoving",false);

				}
			}
		}
	}
	void OnCollisionStay(Collision theCollision){
		foreach (ContactPoint contact in theCollision.contacts) {
			if(contact.normal.y > 0.97){
				jumpcount = 0;
				isbouncing = false;
				break;
			}
		}
		if (theCollision.gameObject.tag == "enemy") {
			foreach (ContactPoint contact in theCollision.contacts) {
				if(contact.normal.y > 0.9f){
					if(istouch ==false){
						istouch = true;
						StartCoroutine(touchdelay());
						if(playersetup.player.shield <=0){
							playersetup.player.currenthealth -= theCollision.transform.parent.gameObject.GetComponent<cubeenemy>().damage;
						}else{
							playersetup.player.shield -= theCollision.transform.parent.gameObject.GetComponent<cubeenemy>().damage;
							if(playersetup.player.shield <0){
								playersetup.player.shield = 0;
							}
						}
						GameObject damagetext = (GameObject)(Instantiate(Resources.Load("damagetext") ,((new Vector3(player.transform.position.x,player.transform.position.y+.8f,player.transform.position.z))), Quaternion.identity));
						damagetext.GetComponent<textrise>().type = 2;
						damagetext.GetComponent<textrise>().transformer = new Vector3(player.transform.position.x,player.transform.position.y,player.transform.position.z);
						damagetext.GetComponent<TextMesh>().text = "-" + theCollision.transform.parent.gameObject.GetComponent<cubeenemy>().damage  + " hp";
						player.GetComponent<GaryCharacterController>().hitcounter++;
						player.GetComponent<GaryCharacterController>().isshielddelay=true;
						StartCoroutine(player.GetComponent<GaryCharacterController>().shielddelay(player.GetComponent<GaryCharacterController>().hitcounter));
						rigidbody.velocity = new Vector3(Random.Range(-5,5),5, 0);
						isbouncing = true;
						if (playersetup.player.currenthealth <=0 & isplaying == true ){
							playersetup.player.currenthealth = 0;
							isplaying = false;
							playersetup.player.totaldeaths++;
							GameObject.Find ("GameController").transform.GetComponent<GUIscript>().gameover();
						}
					}
					break;
				}
			}
		}
	}
	void OnCollisionExit(){
		StartCoroutine(jumpwait());
	}
	void Update(){
		if(isplaying == true){
			Camera.main.transform.position = new Vector3(player.position.x,Camera.main.transform.position.y,player.position.z -8);
			if(Camera.main.transform.position.y < player.position.y -1){
				Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,player.position.y-1 ,player.position.z -8);
			}
			if(Camera.main.transform.position.y > player.position.y + 2){
				Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,player.position.y +2,player.position.z -8);
			}
			if(playersetup.player.shield <= playersetup.player.overshield & isshieldwaiting == false & isshielddelay == false){
				isshieldwaiting = true;
				StartCoroutine(shieldregen());
			}
		}
	}
	IEnumerator jumpwait() {
		yield return new WaitForSeconds(0.1f);
	}
	IEnumerator attacking() {
		weaponanim.speed = (float)(guiscript.playerweapattspeedbuff*(GameObject.FindGameObjectWithTag("GameController").GetComponent<playersetup>().player.attackspeed + guiscript.playerweapattspeed)* (1+playersetup.itemtypes[guiscript.playerweaptypei].bonusattackspeed) /10);
		yield return new WaitForSeconds(GameObject.FindGameObjectWithTag("GameController").GetComponent<playersetup>().currentweapontype.animationlength  / weaponanim.speed);
		weaponanim.SetBool("Attack",false);
		weaponanim.speed = 1;
		alreadyhit = false;
		isattacking = false;

	}
    public IEnumerator ishitwait() {
		yield return new WaitForSeconds(.6f);
		ishit = false;
	}
	IEnumerator loseadrenaline() {
		losingadrenaline = true;
		yield return new WaitForSeconds(1);
		losingadrenaline = false;
		if(GameObject.Find ("GameController").transform.GetComponent<playersetup>().player.adrenalinecurrent > 0){
			GameObject.Find ("GameController").transform.GetComponent<playersetup>().player.adrenalinecurrent--;
		}
	
	}
	IEnumerator shieldregen() {
		yield return new WaitForSeconds(.2f);
		isshieldwaiting = false;
		if(isshielddelay == false){
			playersetup.player.shield= playersetup.player.shield + (int)(1+playersetup.player.overshield/50);
			if(playersetup.player.shield> playersetup.player.overshield){
				playersetup.player.shield = playersetup.player.overshield;
			}
		}
	}
	public IEnumerator shielddelay(int hitcounta) {
		yield return new WaitForSeconds(3f);
		if(hitcounter == hitcounta){
			hitcounter = 0;
			isshielddelay = false;
		}
	}
	public IEnumerator touchdelay() {
		yield return new WaitForSeconds(.2f);
		istouch = false;
	}
	public IEnumerator handability1(){
		weaponanim.SetBool("Uppercutattack",true);
		StartCoroutine(handability1delay());
		yield return new WaitForSeconds(.6f);
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("Uppercutattack",false);


	}
	IEnumerator handability1delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[0].perks[0].abilitycooldowncurrent++;
		if(playersetup.itemtypes[0].perks[0].abilitycooldowncurrent < playersetup.itemtypes[0].perks[0].abilitycooldownmax){
			StartCoroutine(handability1delay());
		}
	}
	public IEnumerator handability2wait() {	
		StartCoroutine(handability2delay());
		yield return new WaitForSeconds(5f);
	
		guiscript.playerweapdamagebuff = guiscript.playerweapdamagebuff - 1;
		guiscript.playerweapattspeedbuff = guiscript.playerweapattspeedbuff - 1;
	}
	 IEnumerator handability2delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[0].perks[6].abilitycooldowncurrent++;
		if(playersetup.itemtypes[0].perks[6].abilitycooldowncurrent < playersetup.itemtypes[0].perks[6].abilitycooldownmax){
			StartCoroutine(handability2delay());
		}
	}
	public IEnumerator handability3delay() {	
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[0].perks[9].abilitycooldowncurrent++;
		if(playersetup.itemtypes[0].perks[9].abilitycooldowncurrent < playersetup.itemtypes[0].perks[9].abilitycooldownmax){
			StartCoroutine(handability3delay());
		}
	}
	public IEnumerator handability4(){
		weaponanim.SetBool("Tornadoattack",true);
		StartCoroutine(handability4delay());
		yield return new WaitForSeconds(3f);
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("Tornadoattack",false);
	}
	IEnumerator handability4delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[0].perks[15].abilitycooldowncurrent++;
		if(playersetup.itemtypes[0].perks[15].abilitycooldowncurrent < playersetup.itemtypes[0].perks[15].abilitycooldownmax){
			StartCoroutine(handability4delay());
		}
	}
	public IEnumerator shortswordability1(){
		weaponanim.SetBool("jab",true);
		StartCoroutine(shortswordability1delay());
		yield return new WaitForSeconds(.8f);
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("jab",false);
		
		
	}
	IEnumerator shortswordability1delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[1].perks[0].abilitycooldowncurrent++;
		if(playersetup.itemtypes[1].perks[0].abilitycooldowncurrent < playersetup.itemtypes[1].perks[0].abilitycooldownmax){
			StartCoroutine(shortswordability1delay());
		}
	}
	public IEnumerator shortswordability2(){
		weaponanim.SetBool("double",true);
		StartCoroutine(shortsworddelay2());
		yield return new WaitForSeconds(.6f);
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("double",false);
		
		
	}
	IEnumerator shortsworddelay2() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[1].perks[6].abilitycooldowncurrent++;
		if(playersetup.itemtypes[1].perks[6].abilitycooldowncurrent < playersetup.itemtypes[1].perks[6].abilitycooldownmax){
			StartCoroutine(shortsworddelay2());
		}
	}
	public IEnumerator shortswordability3wait() {	
		StartCoroutine(shortswordability3delay());
		yield return new WaitForSeconds(5f);
		guiscript.playerweapdamagebuff = guiscript.playerweapdamagebuff - 4;
	}
	IEnumerator shortswordability3delay() {	
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[1].perks[9].abilitycooldowncurrent++;
		if(playersetup.itemtypes[1].perks[9].abilitycooldowncurrent < playersetup.itemtypes[1].perks[9].abilitycooldownmax){
			StartCoroutine(shortswordability3delay());
		}
	}
	public IEnumerator shortswordability4(){
		weaponanim.SetBool("dart",true);
		isdarting = true;
		if(weaponanim.GetBool("isright") == true){
			rigidbody.velocity = new Vector3(7, rigidbody.velocity.y, 0);
		}else{
			rigidbody.velocity = new Vector3(-7, rigidbody.velocity.y, 0);
		}
		StartCoroutine(shortswordability4delay());
		yield return new WaitForSeconds(1f);
		isdarting = false;
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("dart",false);
		
		
	}
	IEnumerator shortswordability4delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[1].perks[15].abilitycooldowncurrent++;
		if(playersetup.itemtypes[1].perks[15].abilitycooldowncurrent < playersetup.itemtypes[1].perks[15].abilitycooldownmax){
			StartCoroutine(shortswordability4delay());
		}
	}
	public IEnumerator bluntability1(){
		weaponanim.SetBool("heavy",true);
		StartCoroutine(bluntability1delay());
		yield return new WaitForSeconds(.8f);
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("heavy",false);
		
		
	}
	IEnumerator bluntability1delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[2].perks[0].abilitycooldowncurrent++;
		if(playersetup.itemtypes[2].perks[0].abilitycooldowncurrent < playersetup.itemtypes[2].perks[0].abilitycooldownmax){
			StartCoroutine(bluntability1delay());
		}
	}
	public IEnumerator bluntability2wait() {	
		StartCoroutine(bluntability2delay());
		yield return new WaitForSeconds(5f);
		
		guiscript.playerweaphealthabsorbbuff = guiscript.playerweaphealthabsorbbuff - .5m;
		guiscript.playerweapattspeedbuff = guiscript.playerweapattspeedbuff - 1;
	}
	IEnumerator bluntability2delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[2].perks[6].abilitycooldowncurrent++;
		if(playersetup.itemtypes[2].perks[6].abilitycooldowncurrent < playersetup.itemtypes[2].perks[6].abilitycooldownmax){
			StartCoroutine(bluntability2delay());
		}
	}
	public IEnumerator bluntability3(){
		weaponanim.SetBool("slam",true);
		StartCoroutine(bluntability3delay());
		yield return new WaitForSeconds(.8f);
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("slam",false);
	}
	IEnumerator bluntability3delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[2].perks[9].abilitycooldowncurrent++;
		if(playersetup.itemtypes[2].perks[9].abilitycooldowncurrent < playersetup.itemtypes[2].perks[9].abilitycooldownmax){
			StartCoroutine(bluntability3delay());
		}
	}
	public IEnumerator bluntability4wait() {	
		StartCoroutine(bluntability4delay());
		yield return new WaitForSeconds(10f);
		guiscript.playerweapcriticalchancebuff = guiscript.playerweapcriticalchancebuff - 1;
	}
	IEnumerator bluntability4delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[2].perks[15].abilitycooldowncurrent++;
		if(playersetup.itemtypes[2].perks[15].abilitycooldowncurrent < playersetup.itemtypes[2].perks[15].abilitycooldownmax){
			StartCoroutine(bluntability4delay());
		}
	}
	public IEnumerator daggerability1(){
		weaponanim.SetBool("slash",true);
		StartCoroutine(daggerability1delay());
		yield return new WaitForSeconds(.8f);
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("slash",false);
		
		
	}
	IEnumerator daggerability1delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[3].perks[0].abilitycooldowncurrent++;
		if(playersetup.itemtypes[3].perks[0].abilitycooldowncurrent < playersetup.itemtypes[3].perks[0].abilitycooldownmax){
			StartCoroutine(daggerability1delay());
		}
	}
	public IEnumerator daggerability2wait() {	
		StartCoroutine(daggerability2delay());
		yield return new WaitForSeconds(5f);
		
		guiscript.playerweapdamagebuff = guiscript.playerweapdamagebuff - 3;
	}
	IEnumerator daggerability2delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[3].perks[6].abilitycooldowncurrent++;
		if(playersetup.itemtypes[3].perks[6].abilitycooldowncurrent < playersetup.itemtypes[3].perks[6].abilitycooldownmax){
			StartCoroutine(daggerability2delay());
		}
	}
	public IEnumerator daggerability3wait() {	
		StartCoroutine(daggerability3delay());
		yield return new WaitForSeconds(5f);
		
		guiscript.playerweapattspeedbuff = guiscript.playerweapattspeedbuff - 1;
	}
	IEnumerator daggerability3delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[3].perks[9].abilitycooldowncurrent++;
		if(playersetup.itemtypes[3].perks[9].abilitycooldowncurrent < playersetup.itemtypes[3].perks[9].abilitycooldownmax){
			StartCoroutine(daggerability3delay());
		}
	}
	public IEnumerator daggerability4(){
		weaponanim.SetBool("storm",true);
		StartCoroutine(daggerability4delay());
		yield return new WaitForSeconds(1.067f);
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("storm",false);
		
		
	}
	IEnumerator daggerability4delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[3].perks[15].abilitycooldowncurrent++;
		if(playersetup.itemtypes[3].perks[15].abilitycooldowncurrent < playersetup.itemtypes[3].perks[15].abilitycooldownmax){
			StartCoroutine(daggerability4delay());
		}
	}
	public IEnumerator axeability1(){
		weaponanim.SetBool("chop",true);
		StartCoroutine(axeability1delay());
		yield return new WaitForSeconds(.8f);
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("chop",false);
		
		
	}
	IEnumerator axeability1delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[4].perks[0].abilitycooldowncurrent++;
		if(playersetup.itemtypes[4].perks[0].abilitycooldowncurrent < playersetup.itemtypes[4].perks[0].abilitycooldownmax){
			StartCoroutine(axeability1delay());
		}
	}
	public IEnumerator axeability2delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[4].perks[6].abilitycooldowncurrent++;
		if(playersetup.itemtypes[4].perks[6].abilitycooldowncurrent < playersetup.itemtypes[4].perks[6].abilitycooldownmax){
			StartCoroutine(axeability2delay());
		}
	}
	public IEnumerator axeability3(){
		weaponanim.SetBool("uppercut",true);
		StartCoroutine(axeability3delay());
		yield return new WaitForSeconds(.6f);
		alreadyhit = false;
		isattacking = false;
		weaponanim.SetBool("uppercut",false);
		
		
	}
	IEnumerator axeability3delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[4].perks[9].abilitycooldowncurrent++;
		if(playersetup.itemtypes[4].perks[9].abilitycooldowncurrent < playersetup.itemtypes[4].perks[9].abilitycooldownmax){
			StartCoroutine(axeability3delay());
		}
	}
	public IEnumerator daxeability4wait() {	
		StartCoroutine(axeability4delay());

		yield return new WaitForSeconds(5f);
		
		guiscript.ishealing = false;
	}
	IEnumerator axeability4delay() {
		yield return new WaitForSeconds(1);
		playersetup.itemtypes[4].perks[15].abilitycooldowncurrent++;
		if(playersetup.itemtypes[4].perks[15].abilitycooldowncurrent < playersetup.itemtypes[4].perks[15].abilitycooldownmax){
			StartCoroutine(axeability4delay());
		}
	}
	public IEnumerator regenhealth(){
		if(guiscript.ishealing == true){
			yield return new WaitForSeconds(.2f);
			playersetup.player.currenthealth =  playersetup.player.currenthealth+ (int)(playersetup.player.overhealth * .04f);
			if(playersetup.player.overhealth <playersetup.player.currenthealth){
				playersetup.player.currenthealth = playersetup.player.overhealth;
				guiscript.ishealing = false;
			}
			StartCoroutine(regenhealth());
		}
	}
}












