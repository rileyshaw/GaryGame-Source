using UnityEngine;
using System.Collections;

public class Chest : playersetup {
	private bool ishovering = false;
	private GameObject temp;
	private GameObject temp2;
	private bool open = false;
	private playersetup playersetup_;

	public Weapon weapon;
	public string weaponname = "";
	public string weaponobjectname = "";
	public int level = -1;
	public int weaponhealth = -1;
	public int weapondamage = -1;
	public int weaponattackspeed = -1;
	public int weaponshield = -1;
	public int weaponadrenaline= -1;
	public int weaponbleeddamage= -1;
	public float weaponbleeddamagechance= -1;
	public float weaponstunchance= -1;
	public float weaponcriticalchance= -1;
	public float weaponhealthabsorb= -1;
	public float weaponarmor= -1;
	public string itemtype= "";
	public int weaponlevel = -1;
	private int weaponi = 0;

	// Use this for initialization
	void Start(){
		 playersetup_ = GameObject.FindGameObjectWithTag("GameController").transform.GetComponent<playersetup>();
		if(weaponname == ""){
			weapon = playersetup_.weapons[Random.Range(0,playersetup_.weapons.Length)];
			weaponname = weapon.name;
		}else{
			for(int j = 0;j< playersetup_.weapons.Length;j++){
				if(weaponname ==  playersetup_.weapons[j].name){
					weapon =  playersetup_.weapons[j];
					weaponname = weapon.name;
				}
			}
		}
	
	}



	void OnTriggerStay(Collider theCollision){
		if (theCollision.tag == "Finish" & ishovering == false & open == false){
			ishovering = true;
			GameObject xptext = (GameObject)(Instantiate(Resources.Load("xptext") ,((new Vector3(transform.position.x,transform.position.y+.8f,transform.localPosition.z))), Quaternion.identity));
			xptext.GetComponent<textrise>().type = 3;
			xptext.GetComponent<textrise>().transformer = gameObject.transform.position;
			xptext.GetComponent<TextMesh>().text = "Press F to open chest";
			temp = xptext;
		}
		if(theCollision.tag == "Finish"){
			if(Input.GetKey(KeyCode.F) == true & open == false){
				weaponobjectname = weaponname + " Object";
				GameObject weapon1 = (GameObject)(Instantiate(Resources.Load(weaponobjectname) ,new Vector3(transform.position.x,transform.position.y-2,transform.position.z), Quaternion.identity));
				temp2 = weapon1;
				for (int n = 0;n< weapons.Length;n++){
					if(playersetup_.weapons[n].name == weaponname){
						weaponi = n;
						itemtype = playersetup_.weapons[n].itemtype;
					}
				}
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weapondetect>().enabled = true;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<BoxCollider>().isTrigger = true;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).tag = "Untagged";
				
				
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapattspeed = weaponattackspeed;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapdamage = weapondamage;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaplevel =weaponlevel;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapname = weaponname;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaphealth =weaponhealth;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapshield =weaponshield;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapadrenaline =weaponadrenaline;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaparmor =(decimal)weaponarmor;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapbleeddamage =weaponbleeddamage;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapbleeddamagechance =(decimal)weaponbleeddamagechance;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapcriticalchance =(decimal)weaponcriticalchance;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaphealthabsorb =(decimal)weaponhealthabsorb;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapstunchance =(decimal)weaponstunchance;
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaptype =itemtype;
				
				weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaplevel = level;
				
				if(weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaplevel== -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaplevel = Random.Range(1,50);
					level = weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaplevel;
				}
				if(weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapattspeed== -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapattspeed = (int)((float)(playersetup_.weapons[weaponi].attackspeedmodifyer)* Random.Range(8,((float)level/4)+8));
				}
				if(weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapdamage == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapdamage = (int)((float)(playersetup_.weapons[weaponi].damagemodifyer)* Random.Range(1+(float)level*level/2,((float)level*(float)level)));
					Debug.Log ((int)((float)(playersetup_.weapons[weaponi].damagemodifyer)* Random.Range(1+(float)level*level/2,((float)level*(float)level))));
				}	
				if(	weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaphealth == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaphealth =(int)((float)(playersetup_.weapons[weaponi].healthmodifyer)* Random.Range((float)level*(float)level/2,((float)level*(float)level)));
				}
				if(	weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapshield == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapshield = (int)((float)(playersetup_.weapons[weaponi].shieldmodifyer)* Random.Range((float)level*(float)level/2,((float)level*(float)level)));
				}
				if(	weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapadrenaline == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapadrenaline = (int)((float)(playersetup_.weapons[weaponi].adrenalinemodifyer)* Random.Range((float)level/50,((float)level/25)));
				}
				if(	weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaparmor == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaparmor = System.Math.Round(((playersetup_.weapons[weaponi].armormodifyer)* (decimal)Random.value/8),2);
				}
				if(	weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapbleeddamage == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapbleeddamage = (int)((playersetup_.weapons[weaponi].bleeddamagemodifyer)* Random.Range(level*level/2,(level*level)/5));
				}
				if(	weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapbleeddamagechance == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapbleeddamagechance = 	System.Math.Round(((playersetup_.weapons[weaponi].bleeddamagechancemodifyer)* (decimal)(Random.value/8)),2);
				}
				if(	weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapcriticalchance == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapcriticalchance = System.Math.Round(((playersetup_.weapons[weaponi].criticalchancemodifyer)* (decimal)Random.value/8),2);
				}
				if(	weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapcriticalchance == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapcriticalchance = System.Math.Round(((playersetup_.weapons[weaponi].criticalchancemodifyer)* (decimal)Random.value/8),2);
				}
				if(	weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaphealthabsorb == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weaphealthabsorb = System.Math.Round(((playersetup_.weapons[weaponi].healthabsorbmodifyer)* (decimal)Random.value/8),2);
				}
				if(	weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapstunchance == -1){
					weapon1.transform.FindChild(playersetup_.weapons[weaponi].animatorname).GetComponent<weaponhover>().weapstunchance = System.Math.Round(((playersetup_.weapons[weaponi].stunchancemodifyer)* (decimal)Random.value/8),2);
				}
				GameObject weap = weapon1;
				GameObject weaponer;
				weaponer = weap.transform.FindChild(playersetup_.weapons[weaponi].animatorname).gameObject;
				weaponer.transform.name = weap.name;
				weapon1.transform.DetachChildren();
				Destroy(weapon1.gameObject);
				weaponer.GetComponent<BoxCollider> ().isTrigger = false;
				weaponer.GetComponent<Rigidbody> ().isKinematic = true;
				temp2 = weaponer;
				Destroy(temp);
				gameObject.transform.parent.GetComponent<Animation>().Play();
				open = true;
				temp2.GetComponent<Rigidbody> ().isKinematic = false;
				temp2.transform.position = new Vector3(temp2.transform.position.x,temp2.transform.position.y+3,temp2.transform.position.z);
				temp2.GetComponent<weaponhover>().enabled = true;
				temp2.transform.rotation = Quaternion.identity;
				temp2.GetComponent<Rigidbody>().useGravity = true;
				temp2.GetComponent<Rigidbody>().velocity = new Vector3(0,8,-.4f);
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
