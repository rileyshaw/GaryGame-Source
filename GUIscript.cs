using UnityEngine;
using System.Collections;
using System;
public class GUIscript : MonoBehaviour {
	public GUISkin heatlh;
	public GUISkin heatlh2;
	public GUISkin heatlh3;
	public GUISkin xp;
	public GUISkin xp2;
	public GUISkin xp3;
	public GUISkin greentext;
	public GUISkin redtext;
	public GUISkin gameovergui;
	public GUISkin normaltext;
	public GUISkin inventoryspaces;
	public GUISkin yellowtext;
	public GUISkin shield;
	public GameObject fallingobj1;
	public GameObject fallingobj2;
	public GUISkin menu;
	public GUISkin highlightspace;
	public bool ishovering = false;
	public bool ishoveringweap = false;
	public GUISkin inventoryfont;
	public GUISkin bigfont;
	public GUISkin inventorybackground;
	public int i = 0;
	public int guimenu = 100;
	public bool ingame = true;
	public int itemsininv = 0;
	public bool invfull = false;
	public int weaplevel;
	public int weapdamage;
	public string weaptype;
	public string weapname;
	public int weapattspeed;
	public Transform weaplocked;
	public int weaphealth;
	public int weapshield;
	public int weapbleeddamage;
	public decimal weapbleeddamagechance;
	public decimal weapstunchance;
	public decimal weapcriticalchance;
	public decimal weaphealthabsorb;
	public decimal weaparmor;
	public int weapadrenaline;

	public int cubecount = 0;

	public bool rotateobj = false;
	public int playerweaponslot = 20;
	public int playerweaptypei = 0;
	public int guiweaptypei = 0;
	public int playerweaplevel;
	public string playerweaptype;
	public string playerweapname;

	public decimal  playerweapdamagebuff = 1;
	public decimal playerweapattspeedbuff= 1;
	public decimal playerweaphealthbuff= 1;
	public decimal playerweapshieldbuff= 1;
	public decimal playerweapadrenalineratebuff= 1;
	public decimal playerweapbleeddamagebuff= 1;
	public decimal playerweapbleeddamagechancebuff= 1;
	public decimal playerweapstunchancebuff= 1;
	public decimal playerweapcriticalchancebuff= 1;
	public decimal playerweaphealthabsorbbuff= 1;
	public decimal playerweaparmorbuff= 1;

	public int playerweapdamage;
	public int playerweapattspeed;
	public int playerweaphealth;
	public int playerweapshield;
	public int playerweapadrenalinerate;
	public int playerweapbleeddamage;
	public decimal playerweapbleeddamagechance;
	public decimal playerweapstunchance;
	public decimal playerweapcriticalchance;
	public decimal playerweaphealthabsorb;
	public decimal playerweaparmor;

	public int playerweapanimspeed;
	public int selectedperk;

	public int selectedweapslot = 20;
	public int selectedweaplevel;
	public int selectedweapdamage;
	public string selectedweaptype;
	public string selectedweapname;
	public int selectedweapattspeed;
	public int selectedweaphealth;
	public int selectedweapshield;
	public int selectedweapadrenalinerate;
	public int selectedweapbleeddamage;
	public decimal selectedweapbleeddamagechance;
	public decimal selectedweapstunchance;
	public decimal selectedweapcriticalchance;
	public decimal selectedweaphealthabsorb;
	public decimal selectedweaparmor;

	public int enemylevel;
	public int enemycurrenthealth;
	public int enemymaxhealth;
	public Transform enemylocked;

	public Transform playerobject;
	public playersetup playersetup;
	public cubeenemy cubeenemy;

	public bool displayingupdater = false;
	public string displayingname;
	public string displayingtype;

	public int actselected;

	public string objectname;
	public Transform temptransform;
	public bool gameend = false;
	public Camera maincamera;
	public Camera secondcamera;
	public GameObject menuplayer;
	public GameObject menuskills;
	public float scrollbarvalue;
	public float scrollbarvalue1;

	public bool isinitialized = false;
	public int currentacthover1 = 0;
	public int acthovermidifyer1 = 0;
	public bool hoverchangingright1 = false;
public  bool hoverchangingleft1 = false;
	public int currentacthover2 = 0;
	public int acthovermidifyer2 = 0;
	public bool hoverchangingright2 = false;
	public bool hoverchangingleft2 = false;
	private Texture locktexture;
	public bool released = false;
	public bool ishealing = false;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
		playersetup = gameObject.transform.GetComponent<playersetup> ();
		menuplayer = GameObject.FindGameObjectWithTag("menuplayer");
		menuskills = GameObject.FindGameObjectWithTag("skills");
		secondcamera = GameObject.FindGameObjectWithTag("2ndCamera").camera;
		maincamera = GameObject.FindGameObjectWithTag("MainCamera").camera;
		locktexture = Resources.Load("lock")as Texture;


	}
	void Update(){
		if( Input.GetKeyDown(KeyCode.Escape) == true & gameend == false ){
			if(playerobject.GetComponent<GaryCharacterController>().isplaying == true){
				secondcamera.transform.localPosition = new Vector3(-20,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				maincamera.active = false;
				secondcamera.active = true;
				selectedweapname = playerweapname;
				selectedweaplevel = playerweaplevel;
				selectedweapdamage= playerweapdamage;
				selectedweaptype = playerweaptype;
				selectedweapattspeed = playerweapattspeed;
				selectedweapadrenalinerate =playerweapadrenalinerate;
				selectedweaparmor= playerweaparmor;
				selectedweapbleeddamage= playerweapbleeddamage;
				selectedweapbleeddamagechance= playerweapbleeddamagechance;
				selectedweapcriticalchance = playerweapcriticalchance;
				selectedweaphealth= playerweaphealth;
				selectedweaphealthabsorb= playerweaphealthabsorb;
				selectedweapshield = playerweapshield;
				selectedweapstunchance= playerweapstunchance;
				selectedweapslot = playerweaponslot;
				guimenu = 1;
				Time.timeScale = 0f;
				playerobject.GetComponent<GaryCharacterController>().isplaying = false;
			}else{
				secondcamera.transform.localPosition = new Vector3(0,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				selectedweapname = "";
				Time.timeScale = 1f;
				guimenu = 0;
				ingame = true;
				maincamera.active = true;
				secondcamera.active = false;
				rotateobj = false;
				playerobject.GetComponent<GaryCharacterController>().isplaying = true;
			}
		}
	}
	IEnumerator loadwait() {
		for(int i = 0;i<playersetup.itemtypes.Length;i++){
			playersetup.itemtypes[i].perks[0].abilitycooldowncurrent = playersetup.itemtypes[i].perks[0].abilitycooldownmax;
			playersetup.itemtypes[i].perks[6].abilitycooldowncurrent = playersetup.itemtypes[i].perks[6].abilitycooldownmax;
			playersetup.itemtypes[i].perks[9].abilitycooldowncurrent = playersetup.itemtypes[i].perks[9].abilitycooldownmax;
			playersetup.itemtypes[i].perks[15].abilitycooldowncurrent = playersetup.itemtypes[i].perks[15].abilitycooldownmax;
			
			
			
		}
		yield return new WaitForSeconds(.001f);
		
		playerweapattspeed = playersetup.currentweapon.attackspeed;
		playerweapdamage = playersetup.currentweapon.damage;
		playerweaplevel = playersetup.currentweapon.level;
		playerweapname = playersetup.currentweapon.name;
		playerweaptype = playersetup.currentweapon.itemtype;
		playerweaponslot = 20;

		playersetup.player.addedhealth = (int)(playersetup.player.basehealth*playersetup.itemtypes[playerweaptypei].bonushealth);

		playersetup.player.overhealth = playersetup.player.basehealth+playersetup.player.addedhealth;
		playersetup.player.addedshield = (int)(playersetup.player.baseshield*playersetup.itemtypes[playerweaptypei].bonusshield);

		playersetup.player.overshield = playersetup.player.baseshield+playersetup.player.addedshield;
		playersetup.player.overshield = playersetup.player.overshield + playersetup.currentweapon.shield;
		playersetup.player.overhealth = playersetup.player.overhealth + playersetup.currentweapon.health;

		playersetup.player.currenthealth = playersetup.player.overhealth;
		playersetup.player.shield = playersetup.player.overshield;


		playersetup.player.overattackspeed = playersetup.player.attackspeed + playersetup.currentweapon.attackspeed;
		playersetup.player.overdamage = playersetup.player.damage + playersetup.currentweapon.damage;

		playersetup.spawnenemies();
		if( GameObject.FindGameObjectWithTag("2ndCamera") != null){
			playerobject = GameObject.FindGameObjectWithTag("Finish").transform;
			menuplayer = GameObject.FindGameObjectWithTag("menuplayer");
			menuskills = GameObject.FindGameObjectWithTag("skills");
			secondcamera = GameObject.FindGameObjectWithTag("2ndCamera").camera;
			maincamera = GameObject.FindGameObjectWithTag("MainCamera").camera;
			maincamera.active = true;
			secondcamera.active = false;
			playersetup.player.currenthealth = playersetup.player.overhealth;
			objectname =  playersetup.currentweapon.name + " Object";
			if(objectname == ""){
				playerobject.GetComponent<GaryCharacterController>().weaponname = playersetup.currentweapon.name;

			}
			if(playersetup.currentweapon.name != "Hand"){
				int selectedweaptypei = 0;
				for(int i = 0;i < playersetup.itemtypes.Length;i++){
					if(playersetup.itemtypes[i].name == selectedweaptype){
						selectedweaptypei = i;
					}
				}
				playerweaponslot = playersetup.currentweapon.invslot;
				playerweapname = playersetup.currentweapon.name;
				playerweaplevel =playersetup.currentweapon.level;
				playerweapdamage= playersetup.currentweapon.damage;
				playerweaptype = playersetup.currentweapon.itemtype;
				playerweapattspeed = playersetup.currentweapon.attackspeed;
				playerweapadrenalinerate =playersetup.currentweapon.adrenaline;
				playerweaparmor= playersetup.currentweapon.armor;
				playerweapbleeddamage= playersetup.currentweapon.bleeddamage;
				playerweapbleeddamagechance= playersetup.currentweapon.bleeddamagechance;
				playerweapcriticalchance = playersetup.currentweapon.criticalchance;
				playerweaphealth= playersetup.currentweapon.health;
				playerweaphealthabsorb= playersetup.currentweapon.healthabsorb;
				playerweapshield = playersetup.currentweapon.shield;
				playerweapstunchance= playersetup.currentweapon.stunchance;
				temptransform = playerobject.transform.FindChild("Hand Object").transform;
				Destroy(playerobject.transform.FindChild("Hand Object").gameObject);
				playersetup.currentweapon.itemtype = playerweaptype;
				for(int i = 0;i < playersetup.itemtypes.Length;i++){
					if(playersetup.itemtypes[i].name == playerweaptype){
						playerweaptypei = i;
					}
				}
				playerobject.GetComponent<GaryCharacterController>().animationlength = playersetup.currentweapontype.animationlength;
				GameObject weapon = (GameObject)(Instantiate(Resources.Load(playerweapname + " Object") ,(temptransform.position), Quaternion.identity));
				playerobject.GetComponent<GaryCharacterController>().weaponanim = weapon.GetComponent<Animator>();
				weapon.transform.parent = playerobject.transform;
				weapon.transform.FindChild(playersetup.itemtypes[selectedweaptypei].animatorname).GetComponent<BoxCollider>().isTrigger = true;
				objectname = weapon.name;
				GameObject menuweapon = (GameObject)(Instantiate(Resources.Load(playerweapname + " Object") ,(GameObject.FindGameObjectWithTag("menuplayer").transform.FindChild("Hand Object").position), GameObject.FindGameObjectWithTag("menuplayer").transform.FindChild("Hand Object").rotation));
				Destroy(GameObject.FindGameObjectWithTag("menuplayer").transform.FindChild("Hand Object").gameObject);
				GameObject menuweaponobj;
				menuweapon.GetComponent<Animator>().enabled = false;
				menuweaponobj = menuweapon.transform.FindChild(playersetup.itemtypes[selectedweaptypei].animatorname).gameObject;
				Destroy(menuweapon.transform.FindChild("Camera").gameObject);
				Destroy(menuweapon.transform.FindChild("Lamp").gameObject);
				menuweapon.transform.parent = GameObject.FindGameObjectWithTag("menuplayer").transform;
				menuweaponobj.transform.position = new Vector3(menuweapon.transform.position.x,menuweapon.transform.position.y,menuweapon.transform.position.z); 
				menuweaponobj.transform.localRotation = Quaternion.Euler(90,0,0);
				menuweapon.transform.localRotation = Quaternion.Euler(0,0,0);
			}else{
				playerobject.GetComponent<GaryCharacterController>().weaponanim = playerobject.FindChild("Hand Object").GetComponent<Animator>();
				playerweaptypei = 0;
			}
		}	
		isinitialized = true;
	}
	void OnGUI(){
		if (guimenu == 100) {
			GUI.skin = bigfont;
			GUI.Label(new Rect(Screen.width/2-200, Screen.height/2-250,400,300)," ");
			GUI.skin = normaltext;
			/*if(GUI.Button (new Rect(Screen.width/2-100, Screen.height/2-150,200,80),"Inventory")){
				menuplayer = GameObject.FindGameObjectWithTag("menuplayer");
				menuskills = GameObject.FindGameObjectWithTag("skills");
				secondcamera = GameObject.FindGameObjectWithTag("2ndCamera").camera;
				maincamera = GameObject.FindGameObjectWithTag("MainCamera").camera;
				maincamera.enabled = false;
				secondcamera.enabled = true;
				secondcamera.transform.localPosition = new Vector3(0,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 2;
			}

			if(GUI.Button (new Rect(Screen.width/2-100, Screen.height/2-100,200,80),"Player")){
				menuplayer = GameObject.FindGameObjectWithTag("menuplayer");
				menuskills = GameObject.FindGameObjectWithTag("skills");
				secondcamera = GameObject.FindGameObjectWithTag("2ndCamera").camera;
				maincamera = GameObject.FindGameObjectWithTag("MainCamera").camera;
				maincamera.enabled = false;
				secondcamera.enabled = true;
				secondcamera.transform.localPosition = new Vector3(-40,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 3;
				scrollbarvalue = 0;
			}
		*/	if(GUI.Button (new Rect(Screen.width/2-100, Screen.height/2-50,200,80),"Options")){
				menuplayer = GameObject.FindGameObjectWithTag("menuplayer");
				menuskills = GameObject.FindGameObjectWithTag("skills");
				secondcamera = GameObject.FindGameObjectWithTag("2ndCamera").camera;
				maincamera = GameObject.FindGameObjectWithTag("MainCamera").camera;
				maincamera.enabled = false;
				secondcamera.enabled = true;
				secondcamera.transform.localPosition = new Vector3(-20,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 4;
			}
			if(GUI.Button (new Rect(Screen.width/2-100, Screen.height/2+50,200,80),"Quit")){
				Application.Quit();
			}
			if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-150,200,80),"Level Select")){
				guimenu = 101;	
			}
		}
		if (guimenu == 102) {
			for(int i = 0;i<10;i++){
				GUI.Box (new Rect(Screen.width/2-200-acthovermidifyer2+(800*i),Screen.height/2-200,400,400),"");
				GUI.skin = bigfont;
				GUI.Label(new Rect(Screen.width/2-200-acthovermidifyer2+(800*i),Screen.height/2-280,400,200),playersetup.acts[actselected].levels[i].levelname);
				GUI.Label(new Rect(Screen.width/2-200-acthovermidifyer2+(800*i),Screen.height/2+200,400,200),playersetup.acts[actselected].levels[i].goldencubescurrent + " / " +playersetup.acts[actselected].levels[i].goldencubesmax + " Golden Cubes"  );
				if(playersetup.acts[actselected].levels[i].islocked == false){
					GUI.DrawTexture (new Rect(Screen.width/2-190-acthovermidifyer2+(800*i),Screen.height/2-190,380,380),playersetup.acts[actselected].levels[i].picture);
					if(GUI.Button(new Rect(Screen.width/2-100-acthovermidifyer2+(800*i),Screen.height/2+280,200,80),"Enter Level")){
						guimenu = 0;
						cubecount = 0;
						Application.LoadLevel(actselected * 10 + i+1);
						playersetup.currentact = actselected;
						playersetup.currentlevel = i;
						StartCoroutine(loadwait());
					}
				}else{
					GUI.DrawTexture (new Rect(Screen.width/2-190-acthovermidifyer2+(800*i),Screen.height/2-190,380,380),locktexture);
					if(GUI.Button(new Rect(Screen.width/2-100-acthovermidifyer2+(800*i),Screen.height/2+280,200,80),"Locked")){
						
					}
				}
				
			}
			if(currentacthover2<9){
				if(GUI.Button (new Rect(Screen.width-60, Screen.height/2-50,50,50),">")){
					currentacthover2++;
					hoverchangingright2 = true;
				}
			}
			if(currentacthover2>0){
				if(GUI.Button (new Rect(10, Screen.height/2-50,50,50),"<")){
					currentacthover2--;
					hoverchangingleft2 = true;
				}
			}
			if(hoverchangingright2 == true & acthovermidifyer2 < currentacthover2*800){
				acthovermidifyer2 = acthovermidifyer2 + 20;
				
			}
			if(hoverchangingleft2 == true & acthovermidifyer2 > currentacthover2*800){
				acthovermidifyer2 = acthovermidifyer2 - 20;
				
			}
			
			if(GUI.Button (new Rect(80, Screen.height-90,100,40),"Back")){
				guimenu = 101;
				
				
			}
		}
		if (guimenu == 101) {
			for(int i = 0;i<5;i++){
				GUI.Box (new Rect(Screen.width/2-200-acthovermidifyer1+(800*i),Screen.height/2-200,400,400),"");
				GUI.skin = bigfont;
				GUI.Label(new Rect(Screen.width/2-200-acthovermidifyer1+(800*i),Screen.height/2-280,400,200),playersetup.acts[i].levelname);
				GUI.Label(new Rect(Screen.width/2-200-acthovermidifyer1+(800*i),Screen.height/2+200,400,200),playersetup.acts[i].goldencubescurrent + " / " +playersetup.acts[i].goldencubesmax + " Golden Cubes"  );
				if(playersetup.acts[i].islocked == false){
					GUI.DrawTexture (new Rect(Screen.width/2-190-acthovermidifyer1+(800*i),Screen.height/2-190,380,380),playersetup.acts[i].picture);
					if(GUI.Button(new Rect(Screen.width/2-100-acthovermidifyer1+(800*i),Screen.height/2+280,200,80),"Enter Act")){
						actselected = i;
						guimenu = 102;
					}
				}else{
					GUI.DrawTexture (new Rect(Screen.width/2-190-acthovermidifyer1+(800*i),Screen.height/2-190,380,380),locktexture);
					if(GUI.Button(new Rect(Screen.width/2-100-acthovermidifyer1+(800*i),Screen.height/2+280,200,80),"Locked")){

					}
				}
		
			}
			if(currentacthover1<4){
				if(GUI.Button (new Rect(Screen.width-60, Screen.height/2-50,50,50),">")){
					currentacthover1++;
					hoverchangingright1 = true;
				}
			}
			if(currentacthover1>0){
				if(GUI.Button (new Rect(10, Screen.height/2-50,50,50),"<")){
					currentacthover1--;
					hoverchangingleft1 = true;
				}
			}
			if(hoverchangingright1 == true & acthovermidifyer1 < currentacthover1*800){
				acthovermidifyer1 = acthovermidifyer1 + 20;

			}
			if(hoverchangingleft1 == true & acthovermidifyer1 > currentacthover1*800){
				acthovermidifyer1 = acthovermidifyer1 - 20;
				
			}

			if(GUI.Button (new Rect(80, Screen.height-90,100,40),"Back")){
				guimenu = 100;
				

			}

		}
		if (guimenu == 2) {
			menuplayer.transform.RotateAround(menuplayer.transform.position,Vector3.down,.5f);
			rotateobj = true;
			for(int x = 0;x<=3;x++){
				for(int y = 0;y<=4;y++){
					if (playersetup.Inventory[(y*4)+x].name == ""){
						GUI.skin = inventoryspaces;
						GUI.Box(new Rect((x*Screen.width/14)+100,(y*Screen.height/8)+100,Screen.width/16,Screen.height/9),"");
					}else{
						if(playerweaponslot == (y*4)+x){
							GUI.skin = highlightspace;
							GUI.Box(new Rect((x*Screen.width/14)+95,(y*Screen.height/8)+95,(Screen.width/16)+10,(Screen.height/9)+10),"");
						}
						GUI.skin = inventoryspaces;
						GUI.Box(new Rect((x*Screen.width/14)+95,(y*Screen.height/8)+95,(Screen.width/16)+10,(Screen.height/9)+10),"");
						GUI.DrawTexture(new Rect((x*Screen.width/14)+100,(y*Screen.height/8)+100,Screen.width/16,Screen.height/9),Resources.Load(playersetup.Inventory[(y*4)+x].name + " Pic") as Texture);
					}
					if(Input.GetMouseButton(0) == true){
						if (new Rect((x*Screen.width/14)+100,(y*Screen.height/8)+100,Screen.width/16,Screen.height/9).Contains(Event.current.mousePosition)){
							selectedweapname = playersetup.Inventory[(y*4)+x].name;
							selectedweaplevel = playersetup.Inventory[(y*4)+x].level;
							selectedweapdamage= playersetup.Inventory[(y*4)+x].damage;
							selectedweaptype = playersetup.Inventory[(y*4)+x].itemtype;
							selectedweapattspeed = playersetup.Inventory[(y*4)+x].attackspeed;
							selectedweapadrenalinerate =playersetup.Inventory[(y*4)+x].adrenaline;
							selectedweaparmor= playersetup.Inventory[(y*4)+x].armor;
							selectedweapbleeddamage= playersetup.Inventory[(y*4)+x].bleeddamage;
							selectedweapbleeddamagechance= playersetup.Inventory[(y*4)+x].bleeddamagechance;
							selectedweapcriticalchance = playersetup.Inventory[(y*4)+x].criticalchance;
							selectedweaphealth= playersetup.Inventory[(y*4)+x].health;
							selectedweaphealthabsorb= playersetup.Inventory[(y*4)+x].healthabsorb;
							selectedweapshield = playersetup.Inventory[(y*4)+x].shield;
							selectedweapstunchance= playersetup.Inventory[(y*4)+x].stunchance;
							selectedweapslot = (y*4)+x;
						}
					}
				}
			}
			if (selectedweapname != "" & selectedweapname != "Hand"){
				GUI.skin = inventoryfont;
				GUI.Label (new Rect (Screen.width/1.72f ,Screen.height/2-360, 500,200), selectedweaptype);
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2-310,500,200),"Level " + selectedweaplevel + " "+ selectedweapname);
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2-260,500,200),"Adrenaline: " + selectedweapadrenalinerate);
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2-230,500,200),"Armor: " + selectedweaparmor*100 + "%");
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2-200,500,200),"Attack Speed: " + selectedweapattspeed);
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2-170,500,200),"Bleed Damage: " + selectedweapbleeddamage);
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2-140,500,200),"Bleed Damage Chance: " + selectedweapbleeddamagechance*100 + "%");
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2-110,500,200),"Damage: " + selectedweapdamage);
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2-80,500,200),"Critical Chance: " + selectedweapcriticalchance*100 + "%");
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2-50,500,200),"Health: " + selectedweaphealth);
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2-20,500,200),"Health Absorb: " + selectedweaphealthabsorb*100 + "%");
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2+10,500,200),"Shield: " + selectedweapshield);
				GUI.Label(new Rect(Screen.width/1.72f,Screen.height/2+40,500,200),"Stun Chance: " + selectedweapstunchance*100 + "%");



	
				GUI.skin = normaltext;
				if(GUI.Button (new Rect(Screen.width/2 +240, Screen.height/2+100,140,60),"Equip")){

					playersetup.player.overhealth = playersetup.player.overhealth- playersetup.player.addedhealth;
					playersetup.player.overshield = playersetup.player.overshield- playersetup.player.addedshield;

					playersetup.player.overhealth = playersetup.player.overhealth- playerweaphealth;
					playersetup.player.overshield = playersetup.player.overshield- playerweapshield;

					playerweaponslot = selectedweapslot;
					playerweapname = selectedweapname;
					playerweaplevel =selectedweaplevel;
					playerweapdamage= selectedweapdamage;
					playerweaptype = selectedweaptype;
					playerweapattspeed = selectedweapattspeed;
					playerweapadrenalinerate = selectedweapadrenalinerate;
					playerweaparmor = selectedweaparmor;
					playerweapbleeddamage =selectedweapbleeddamage;
					playerweapbleeddamagechance= selectedweapbleeddamagechance;
					playerweapcriticalchance = selectedweapcriticalchance;
					playerweaphealth = selectedweaphealth;
					playerweaphealthabsorb= selectedweaphealthabsorb;
					playerweapshield = selectedweapshield;
					playerweapstunchance = selectedweapstunchance;


					playersetup.currentweapon.itemtype = playerweaptype;
					playersetup.currentweapon.attackspeed = playerweapattspeed;
					playersetup.currentweapon.damage = playerweapdamage;
					playersetup.currentweapon.health = playerweaphealth;
					playersetup.currentweapon.level = playerweaplevel;
					playersetup.currentweapon.name = playerweapname;

					playersetup.currentweapon.shield = playerweapshield;
					playersetup.currentweapon.adrenaline = playerweapadrenalinerate;
					playersetup.currentweapon.armor = playerweaparmor;
					playersetup.currentweapon.bleeddamage = playerweapbleeddamage;
					playersetup.currentweapon.bleeddamagechance = playerweapbleeddamagechance;
					playersetup.currentweapon.criticalchance = playerweapcriticalchance;
					playersetup.currentweapon.healthabsorb = playerweaphealthabsorb;
					playersetup.currentweapon.stunchance = playerweapstunchance;

					playersetup.currentweapon.invslot = playerweaponslot;



					playersetup.player.overshield = playersetup.player.overshield + playersetup.currentweapon.shield;
					playersetup.player.overhealth = playersetup.player.overhealth + playersetup.currentweapon.health;

					temptransform = playerobject.transform.FindChild(objectname).transform;
					Destroy(playerobject.transform.FindChild(objectname).gameObject);
					Destroy(GameObject.FindGameObjectWithTag("menuplayer").transform.FindChild(objectname).gameObject);
					playersetup.currentweapon.itemtype = playerweaptype;
					for(int i = 0;i < playersetup.itemtypes.Length;i++){
						if(playersetup.itemtypes[i].name == playerweaptype){
							playerweaptypei = i;
						}
					}
					playersetup.player.addedhealth = (int)(playersetup.player.basehealth*playersetup.itemtypes[playerweaptypei].bonushealth);
					playersetup.player.overhealth =playersetup.player.overhealth+playersetup.player.addedhealth;

					if(playersetup.player.overhealth<playersetup.player.currenthealth){
						playersetup.player.currenthealth =playersetup.player.overhealth;
					}

					playersetup.player.addedshield = (int)(playersetup.player.overshield*playersetup.itemtypes[playerweaptypei].bonusshield);
					playersetup.player.overshield =playersetup.player.overshield+playersetup.player.addedshield;
					
					if(playersetup.player.overshield<playersetup.player.shield){
						playersetup.player.shield =playersetup.player.overshield;
					}
					playerobject.GetComponent<GaryCharacterController>().animationlength = playersetup.itemtypes[playerweaptypei].animationlength;
					playersetup.currentweapontype = playersetup.itemtypes[playerweaptypei];

					GameObject weapon = (GameObject)(Instantiate(Resources.Load(playerweapname + " Object") ,(temptransform.position), Quaternion.identity));
					GameObject menuweapon = (GameObject)(Instantiate(Resources.Load(playerweapname + " Object") ,(GameObject.FindGameObjectWithTag("menuplayer").transform.FindChild(objectname).position), GameObject.FindGameObjectWithTag("menuplayer").transform.FindChild(objectname).rotation));
					GameObject menuweaponobj;
					menuweapon.GetComponent<Animator>().enabled = false;
					menuweaponobj = menuweapon.transform.FindChild(playersetup.itemtypes[playerweaptypei].animatorname).gameObject;
					Destroy(menuweapon.transform.FindChild("Camera").gameObject);
					Destroy(menuweapon.transform.FindChild("Lamp").gameObject);
					menuweapon.transform.parent = GameObject.FindGameObjectWithTag("menuplayer").transform;
					weapon.transform.parent = playerobject.transform;
					weapon.transform.FindChild(playersetup.itemtypes[playerweaptypei].animatorname).GetComponent<BoxCollider>().isTrigger = true;
					objectname = weapon.name;
					playerobject.GetComponent<GaryCharacterController>().weaponanim = weapon.GetComponent<Animator>();
					menuweaponobj.transform.position = new Vector3(menuweapon.transform.position.x,menuweapon.transform.position.y,menuweapon.transform.position.z); 
					menuweaponobj.transform.localRotation = Quaternion.Euler(90,0,0);
					menuweapon.transform.localRotation = Quaternion.Euler(0,0,0);
				}
				GUI.skin = normaltext;
				if(GUI.Button (new Rect(Screen.width/2 +400, Screen.height/2+100,140,60),"Drop")){
					int selectedweaptypei = 0;
					for(int i = 0;i < playersetup.itemtypes.Length;i++){
						if(playersetup.itemtypes[i].name == selectedweaptype){
							selectedweaptypei = i;
						}
					}
					invfull = false;
					itemsininv--;
					GameObject weap = (GameObject)Instantiate (Resources.Load(selectedweapname + " Object"),new Vector3(playerobject.transform.position.x + 1,playerobject.transform.position.y+1,playerobject.transform.position.z), Quaternion.identity);
					GameObject weapon;
					weap.transform.FindChild(playersetup.itemtypes[selectedweaptypei].animatorname).name = weap.name;
					weapon = weap.transform.FindChild(weap.name).gameObject;
					Destroy(weap.transform.FindChild("Camera").gameObject);
					Destroy(weap.transform.FindChild("Lamp").gameObject);
					weap.transform.DetachChildren();
					Destroy(weap.gameObject);
					weapon.GetComponent<weaponhover>().enabled = true;
					weapon.GetComponent<Rigidbody>().useGravity = true;
					weapon.GetComponent<weaponhover>().weapattspeed = selectedweapattspeed;
					weapon.GetComponent<weaponhover>().weapdamage= selectedweapdamage;
					weapon.GetComponent<weaponhover>().weaplevel = selectedweaplevel;
					weapon.GetComponent<weaponhover>().weapname = selectedweapname;
					weapon.GetComponent<weaponhover>().weaptype = selectedweaptype;
					weapon.GetComponent<weaponhover>().weapadrenaline = selectedweapadrenalinerate;
					weapon.GetComponent<weaponhover>().weaparmor= selectedweaparmor;
					weapon.GetComponent<weaponhover>().weapbleeddamage = selectedweapbleeddamage;
					weapon.GetComponent<weaponhover>().weapbleeddamagechance = selectedweapbleeddamagechance;
					weapon.GetComponent<weaponhover>().weapcriticalchance= selectedweapcriticalchance;
					weapon.GetComponent<weaponhover>().weaphealth = selectedweaphealth;
					weapon.GetComponent<weaponhover>().weaphealthabsorb = selectedweaphealthabsorb;
					weapon.GetComponent<weaponhover>().weapshield = selectedweapshield;
					weapon.GetComponent<weaponhover>().weapstunchance = selectedweapstunchance;

					weapon.GetComponent<weaponhover>().weaptype = selectedweaptype;
					weapon.transform.position = new Vector3(weapon.transform.position.x,weapon.transform.position.y,GameObject.FindGameObjectWithTag("Finish").transform.position.z);
			
					playersetup.Inventory[selectedweapslot].name = "";
					playersetup.Inventory[selectedweapslot].attackspeed = 0;
					playersetup.Inventory[selectedweapslot].damage = 0;
					playersetup.Inventory[selectedweapslot].health = 0;
					playersetup.Inventory[selectedweapslot].itemtype = "";
					playersetup.Inventory[selectedweapslot].level = 0;
					playersetup.Inventory[selectedweapslot].shield = 0;
					playersetup.Inventory[selectedweapslot].adrenaline = 0;
					playersetup.Inventory[selectedweapslot].armor = 0;
					playersetup.Inventory[selectedweapslot].bleeddamage = 0;
					playersetup.Inventory[selectedweapslot].bleeddamagechance = 0;
					playersetup.Inventory[selectedweapslot].criticalchance = 0;
					playersetup.Inventory[selectedweapslot].health = 0;
					playersetup.Inventory[selectedweapslot].healthabsorb = 0;
					playersetup.Inventory[selectedweapslot].stunchance = 0;
					if(playerweaponslot == selectedweapslot){
						playersetup.player.overshield = playersetup.player.overshield - playersetup.currentweapon.shield;
						playersetup.player.overhealth = playersetup.player.overhealth - playersetup.currentweapon.health;

						Destroy(GameObject.FindGameObjectWithTag("menuplayer").transform.FindChild(objectname).gameObject);
						GameObject hand = (GameObject)(Instantiate(Resources.Load("Hand Object") ,((playerobject.transform.FindChild(objectname).position)), Quaternion.identity));
						GameObject menuhand = (GameObject)(Instantiate(Resources.Load("Hand Object") ,(GameObject.FindGameObjectWithTag("menuplayer").transform.FindChild(objectname).position), GameObject.FindGameObjectWithTag("menuplayer").transform.FindChild(objectname).rotation));
						GameObject menuhandobj;
						menuhand.GetComponent<Animator>().enabled = false;
						menuhandobj = menuhand.transform.FindChild("Sphere").gameObject;
						Destroy(menuhand.transform.FindChild("Camera").gameObject);
						Destroy(menuhand.transform.FindChild("Lamp").gameObject);
						menuhand.transform.parent = GameObject.FindGameObjectWithTag("menuplayer").transform;
						Destroy(playerobject.transform.FindChild(objectname).gameObject);
					    hand.transform.parent = playerobject.transform;
						objectname = hand.name;
						playerobject.GetComponent<GaryCharacterController>().weaponanim = playerobject.transform.FindChild (objectname).GetComponent<Animator>();
						menuhandobj.transform.position = new Vector3(menuhand.transform.position.x,menuhand.transform.position.y,menuhand.transform.position.z); 
						menuhandobj.transform.localRotation = Quaternion.Euler(90,0,0);
						menuhand.transform.localRotation = Quaternion.Euler(0,0,0);
						playersetup.currentweapon.name = "Hand";
						playersetup.currentweapon.itemtype = "Hand";
						playerweaptypei = 0;
						playerweaponslot = 20;
						playerweapname = "Hand";
						playerweaplevel =0;
						playerweapdamage= 0;
						playerweapattspeed = 0;
						playerweapadrenalinerate =0;
						playerweaparmor= 0;
						playerweapbleeddamagechance = 0;
						playerweapbleeddamage = 0;
						playerweapcriticalchance =0;
						playerweaphealth= 0;
						playerweaphealthabsorb = 0;
						playerweapshield =0;
						playerweapstunchance= 0;

						playersetup.player.overhealth = playersetup.player.overhealth- playersetup.player.addedhealth;
						playersetup.player.addedhealth = (int)(playersetup.player.basehealth*playersetup.itemtypes[0].bonushealth);
						playersetup.player.overhealth = playersetup.player.overhealth + playersetup.player.addedhealth;
						if(playersetup.player.overhealth<playersetup.player.currenthealth){
							playersetup.player.currenthealth =playersetup.player.overhealth;
						}
						playersetup.player.overshield = playersetup.player.overshield- playersetup.player.addedshield;
						playersetup.player.addedshield = (int)(playersetup.player.baseshield*playersetup.itemtypes[playerweaptypei].bonusshield);
						playersetup.player.overshield = playersetup.player.overshield+playersetup.player.addedshield;
						if(playersetup.player.overshield < playersetup.player.shield){
							playersetup.player.shield = playersetup.player.overshield;
						}

						playersetup.currentweapon.attackspeed = 0;
						playersetup.currentweapon.damage = 0;
						playersetup.currentweapon.health = 0;
						playersetup.currentweapon.shield = 0;
						playersetup.currentweapon.adrenaline = 0;
						playersetup.currentweapon.armor = 0;
						playersetup.currentweapon.bleeddamage = 0;
						playersetup.currentweapon.bleeddamagechance = 0;
						playersetup.currentweapon.criticalchance = 0;
						playersetup.currentweapon.healthabsorb = 0;
						playersetup.currentweapon.stunchance = 0;
					}
					selectedweapslot = 20;

					
					selectedweapname ="Hand";
					playersetup.sortinventory();
 				}
			}
			GUI.skin = normaltext;
			if(GUI.Button (new Rect(200, Screen.height-90,100,40),"Resume")){
				secondcamera.transform.localPosition = new Vector3(0,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				selectedweapname = "";
				Time.timeScale = 1f;
				guimenu = 0;
				ingame = true;
				playerobject.GetComponent<GaryCharacterController>().isplaying = true;
				maincamera.active = true;
				secondcamera.active = false;
				rotateobj = false;
			}
			if(GUI.Button (new Rect(80, Screen.height-90,100,40),"Back")){
				secondcamera.transform.localPosition = new Vector3(-20,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 1;
			}

		}
		if(guimenu == 4){
			GUI.skin = normaltext;
			if(GUI.Button (new Rect(200, Screen.height-90,100,40),"Resume")){
				secondcamera.transform.localPosition = new Vector3(0,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				selectedweapname = "";
				Time.timeScale = 1f;
				guimenu = 0;
				ingame = true;
				playerobject.GetComponent<GaryCharacterController>().isplaying = true;
				maincamera.active = true;
				secondcamera.active = false;
				rotateobj = false;
			}
			if(GUI.Button (new Rect(80, Screen.height-90,100,40),"Back")){
				secondcamera.transform.localPosition = new Vector3(-20,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 1;
			}

		}
		if(guimenu == 1){
			GUI.skin = bigfont;
			GUI.Label(new Rect(150, Screen.height/2-250,400,300),"Paused");
			GUI.skin = normaltext;
			if(GUI.Button (new Rect(300, Screen.height/2-150,100,40),"Inventory")){
				secondcamera.transform.localPosition = new Vector3(0,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 2;
			}
			if(GUI.Button (new Rect(300, Screen.height/2-100,100,40),"Player")){
				secondcamera.transform.localPosition = new Vector3(-40,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 3;
				scrollbarvalue = 0;
			}
			if(GUI.Button (new Rect(300, Screen.height/2-50,100,40),"Options")){
				secondcamera.transform.localPosition = new Vector3(-20,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 4;
			}
			if(GUI.Button (new Rect(300, Screen.height/2,100,40),"Quit")){
				isinitialized =false;
				Time.timeScale = 1f;
				guimenu =100;
				Application.LoadLevel(0);
			}
			if(GUI.Button (new Rect(80, Screen.height-90,100,40),"Resume")){
				secondcamera.transform.localPosition = new Vector3(0,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				selectedweapname = "";
				Time.timeScale = 1f;
				guimenu = 0;
				ingame = true;
				playerobject.GetComponent<GaryCharacterController>().isplaying = true;
				maincamera.active = true;
				secondcamera.active = false;
				rotateobj = false;
			}
		}
		if(guimenu == 3){
			menuskills.transform.RotateAround(menuskills.transform.position,Vector3.down,.5f);
			menuskills.transform.localPosition = new Vector3(menuskills.transform.localPosition.x,scrollbarvalue/100 + -2.391561f,menuskills.transform.localPosition.z);
			scrollbarvalue+=-(int)(30*Input.GetAxis("Mouse ScrollWheel"));
			scrollbarvalue =  GUI.VerticalScrollbar(new Rect(Screen.width-50,50,30,Screen.height-100),scrollbarvalue,100, 0, 800);
			GUI.skin = normaltext;
			GUI.Box (new Rect(Screen.width/20,(100)-scrollbarvalue,(Screen.width-2*(Screen.width/20)-350),280),"");
			GUI.skin = xp2;
			GUI.Box (new Rect(Screen.width/5, 130-scrollbarvalue,400,30),"");
			GUI.skin = inventoryfont;
			GUI.Label(new Rect(Screen.width/9,120-scrollbarvalue,20 ,200),"Player Level " + playersetup.player.playerlevel);
			GUI.Label(new Rect(Screen.width/9,170-scrollbarvalue,20 ,200),"Total Progress ");
			GUI.Label(new Rect(Screen.width/9,220-scrollbarvalue,20 ,200),"Story Progress ");
			GUI.Label(new Rect(Screen.width/9,270-scrollbarvalue,20 ,200),"Challenge Progress ");
			GUI.Label(new Rect(Screen.width/9,320-scrollbarvalue,20 ,200),"Golden Cubes Progress ");


			if(GUI.Button (new Rect(Screen.width/1.5f,220-scrollbarvalue,100,40),"Perks")){
				secondcamera.transform.localPosition = new Vector3(-20,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 5;
			}


			GUI.skin = xp2;
			GUI.Box (new Rect(Screen.width/5, 180-scrollbarvalue,400,30),"");
			if(playersetup.player.totalprogress> 0){
				GUI.skin = xp3;
				GUI.Box (new Rect (Screen.width/5, 180-scrollbarvalue, ((playersetup.player.storyprogress + playersetup.player.challengeprogress + playersetup.player.sidemissionprogress)  * 400 / 284 ), 30), "");
			}
			GUI.skin = xp;
			GUI.Box (new Rect(Screen.width/5,180-scrollbarvalue,400,30), + Math.Round((playersetup.player.storyprogress + playersetup.player.challengeprogress + playersetup.player.sidemissionprogress)/2.84m,2) + "%");


			GUI.skin = xp2;
			GUI.Box (new Rect(Screen.width/5, 230-scrollbarvalue,400,30),"");
			if(playersetup.player.storyprogress> 0){
				GUI.skin = xp3;
				GUI.Box (new Rect (Screen.width/5, 230-scrollbarvalue, (playersetup.player.storyprogress * 400 /50), 30), "");
			}
			GUI.skin = xp;
			GUI.Box (new Rect(Screen.width/5,230-scrollbarvalue,400,30), + playersetup.player.storyprogress+ "/" + "50");

			GUI.skin = xp2;
			GUI.Box (new Rect(Screen.width/5, 280-scrollbarvalue,400,30),"");
			if(playersetup.player.challengeprogress> 0){
				GUI.skin = xp3;
				GUI.Box (new Rect (Screen.width/5, 280-scrollbarvalue, (playersetup.player.challengeprogress * 400 /84), 30), "");
			}
			GUI.skin = xp;
			GUI.Box (new Rect(Screen.width/5,280-scrollbarvalue,400,30), + playersetup.player.challengeprogress+ "/" + "84");


			GUI.skin = xp2;
			GUI.Box (new Rect(Screen.width/5, 330-scrollbarvalue,400,30),"");
			if(playersetup.player.sidemissionprogress> 0){
				GUI.skin = xp3;
				GUI.Box (new Rect (Screen.width/5, 330-scrollbarvalue, (playersetup.player.sidemissionprogress * 400 /150), 30), "");
			}
			GUI.skin = xp;
			GUI.Box (new Rect(Screen.width/5,330-scrollbarvalue,400,30), + playersetup.player.sidemissionprogress+ "/" + "150");



			if(playersetup.player.currentxp> 0){
				GUI.skin = xp3;
				GUI.Box (new Rect (Screen.width/5, 130-scrollbarvalue, (playersetup.player.currentxp * 400 /playersetup.player.xptolevel), 30), "");
			}
			GUI.skin = xp;
			GUI.Box (new Rect(Screen.width/5,130-scrollbarvalue,400,30),"Experience: " + playersetup.player.currentxp+ "/" +playersetup.player.xptolevel);
			GUI.Label(new Rect(Screen.width/2.2f,130-scrollbarvalue,200 ,200),"Base Player Stats" );
			GUI.Label(new Rect(Screen.width/2.2f,170-scrollbarvalue,200 ,200),"Attack Speed: " + playersetup.player.attackspeed);
			GUI.Label(new Rect(Screen.width/2.2f,190-scrollbarvalue,200 ,200),"Damage: " + playersetup.player.damage);
			GUI.Label(new Rect(Screen.width/2.2f,210-scrollbarvalue,200 ,200),"Heatlh: " + playersetup.player.overhealth);
			GUI.Label(new Rect(Screen.width/2.2f,230-scrollbarvalue,200 ,200),"Shield: " + playersetup.player.overshield );
			GUI.Label(new Rect(Screen.width/2.2f,250-scrollbarvalue,200 ,200),"Armor: " + playersetup.player.armor*100 + "%" );
			GUI.Label(new Rect(Screen.width/2.2f,270-scrollbarvalue,200 ,200),"Adrenaline: " + playersetup.player.adrenalinerate);
			GUI.Label(new Rect(Screen.width/2.2f,290-scrollbarvalue,200 ,200),"Bleed Damage: " + playersetup.player.bleeddamage );
			GUI.Label(new Rect(Screen.width/2.2f,310-scrollbarvalue,200 ,200),"Critical Hit Chance: " + playersetup.player.criticalchance*100 + "%" );
			GUI.Label(new Rect(Screen.width/2.2f,330-scrollbarvalue,200 ,200),"Heatlh Absorb: " + playersetup.player.healthabsorb*100 + "%"  );
			GUI.Label(new Rect(Screen.width/2.2f,350-scrollbarvalue,200 ,200),"Stun Chance: " + playersetup.player.stunchance*100 + "%" );


			GUI.Label(new Rect(Screen.width/1.9f,180-scrollbarvalue,200 ,200),"Total Kills: " + playersetup.player.totalkills);
			GUI.Label(new Rect(Screen.width/1.9f,210-scrollbarvalue,200 ,200),"Total Deaths: " + playersetup.player.totaldeaths);
			GUI.Label(new Rect(Screen.width/1.9f,240-scrollbarvalue,200 ,200),"Total Damage: " + playersetup.player.totaldamage);


			for(int i = 0;i<playersetup.itemtypes.Length;i++){
				GUI.skin = normaltext;
				GUI.Box (new Rect(Screen.width/20,(i*200)+425-scrollbarvalue,(Screen.width-2*(Screen.width/20)-350),160),"");
				GUI.skin = xp2;
				GUI.Box (new Rect(Screen.width/5, i*200+480-scrollbarvalue,200,30),"");
				GUI.skin = inventoryfont;
				GUI.Label(new Rect(Screen.width/9,(i*200)+470-scrollbarvalue,20 ,200),playersetup.itemtypes[i].name + " Level " + playersetup.itemtypes[i].currentlevel );
				if(playersetup.itemtypes[i].currentxp> 0){
					GUI.skin = xp3;
					GUI.Box (new Rect (Screen.width/5, i*200+480-scrollbarvalue, (playersetup.itemtypes[i].currentxp * 200 /playersetup.itemtypes[i].xptolevel), 30), "");
				}
				GUI.skin = xp;
				GUI.Box (new Rect(Screen.width/5,i*200+480-scrollbarvalue,200,30),"Experience"+": " + playersetup.itemtypes[i].currentxp+ "/" + playersetup.itemtypes[i].xptolevel);
				GUI.Label(new Rect(Screen.width/2.9f,(i*200)+430-scrollbarvalue,200 ,200),"Weapon Bonuses" );
				GUI.Label(new Rect(Screen.width/2.9f,(i*200)+470-scrollbarvalue,200 ,200),"Attack Speed: " + playersetup.itemtypes[i].bonusattackspeed*100 + "%" );
				GUI.Label(new Rect(Screen.width/2.9f,(i*200)+490-scrollbarvalue,200 ,200),"Damage: " + playersetup.itemtypes[i].bonusdamage*100 + "%" );
				GUI.Label(new Rect(Screen.width/2.9f,(i*200)+510-scrollbarvalue,200 ,200),"Heatlh: " + playersetup.itemtypes[i].bonushealth*100 + "%" );
				GUI.Label(new Rect(Screen.width/2.9f,(i*200)+530-scrollbarvalue,200 ,200),"Shield: " + playersetup.itemtypes[i].bonusshield*100 + "%" );
				GUI.Label(new Rect(Screen.width/2.9f+100,(i*200)+470-scrollbarvalue,200 ,200),"Armor: " + playersetup.itemtypes[i].bonusarmor*100 + "%" );
				GUI.Label(new Rect(Screen.width/2.9f+100,(i*200)+490-scrollbarvalue,200 ,200),"Adrenaline: " + playersetup.itemtypes[i].bonusadrenaline*100 + "%" );
				GUI.Label(new Rect(Screen.width/2.9f+100,(i*200)+510-scrollbarvalue,200 ,200),"Bleed Damage: " + playersetup.itemtypes[i].bonusbleeddamage*100 + "%" );
				GUI.Label(new Rect(Screen.width/2.9f+100,(i*200)+530-scrollbarvalue,200 ,200),"Critical Hit Chance: " + playersetup.itemtypes[i].bonuscriticalchance*100 + "%" );
				GUI.Label(new Rect(Screen.width/2.9f+200,(i*200)+470-scrollbarvalue,200 ,200),"Health Absorb: " + playersetup.itemtypes[i].bonushealthabsorb*100 + "%" );
				GUI.Label(new Rect(Screen.width/2.9f+200,(i*200)+490-scrollbarvalue,200 ,200),"Stun Chance: " + playersetup.itemtypes[i].bonusstunchance*100 + "%" );

				if(GUI.Button (new Rect(Screen.width/1.5f,(i*200)+440-scrollbarvalue,100,40),"Perks")){
					scrollbarvalue1 = 0;
					guiweaptypei = i;
					secondcamera.transform.localPosition = new Vector3(-20,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
					selectedperk = 16;
					guimenu = 5;
				}
				if(GUI.Button (new Rect(Screen.width/1.5f,(i*200)+500-scrollbarvalue,100,40),"Challenges")){
					scrollbarvalue1 = 0;
					guiweaptypei = i;
					secondcamera.transform.localPosition = new Vector3(-20,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
					guimenu = 6;
				}
				GUI.skin = inventoryfont;
				GUI.Label(new Rect(Screen.width/1.7f,(i*200)+470-scrollbarvalue,20 ,200),"Perk Points: " + playersetup.itemtypes[i].perkpoints );

			}
			if(GUI.Button (new Rect(200,30,100,40),"Resume")){
				secondcamera.transform.localPosition = new Vector3(0,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				selectedweapname = "";
				Time.timeScale = 1f;
				guimenu = 0;
				ingame = true;
				playerobject.GetComponent<GaryCharacterController>().isplaying = true;
				maincamera.active = true;
				secondcamera.active = false;
				rotateobj = false;
			}
			if(GUI.Button (new Rect(80,30,100,40),"Back")){
				secondcamera.transform.localPosition = new Vector3(-20,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 1;
			}
		}
		if(guimenu == 5){
			GUI.skin = normaltext;
			scrollbarvalue1+=-(30*Input.GetAxis("Mouse ScrollWheel"));
			scrollbarvalue1 =  GUI.VerticalScrollbar(new Rect(Screen.width-50,50,30,Screen.height-100),scrollbarvalue1,100.0F, 0.0F, 1000.0F);

			GUI.Box(new Rect((Screen.width/1.8f),(Screen.height/10),Screen.width/3f,Screen.height-Screen.height/3f),"");
			for(int i = 0;i<16;i++){
				if(playersetup.itemtypes[guiweaptypei].perks[i].currentlevel >= playersetup.itemtypes[guiweaptypei].perks[i].maxlevel){
					GUI.skin = highlightspace;
				}else{
					GUI.skin = inventoryspaces;
				}

				GUI.Box(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14),(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1,Screen.width/16,Screen.width/16),"");
					if(playersetup.itemtypes[guiweaptypei].perks[i].ymod == 0){
						GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),playersetup.itemtypes[guiweaptypei].perks[i].picture);
						if(Input.GetMouseButton(0) == true){
							if (new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14),(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1,Screen.width/16,Screen.width/16).Contains(Event.current.mousePosition)){
								selectedperk = i;
							}
						}
					}else if(playersetup.itemtypes[guiweaptypei].perks[i].ymod == -1){
						if(playersetup.itemtypes[guiweaptypei].perksbought > 0){
						GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),playersetup.itemtypes[guiweaptypei].perks[i].picture);
							if(Input.GetMouseButton(0) == true){
								if (new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14),(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1,Screen.width/16,Screen.width/16).Contains(Event.current.mousePosition)){
									selectedperk = i;
									
								}
							}
						}else{
							GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),locktexture);
						}
					}else if(playersetup.itemtypes[guiweaptypei].perks[i].ymod == -2){
						if(playersetup.itemtypes[guiweaptypei].perksbought > 3){
						GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),playersetup.itemtypes[guiweaptypei].perks[i].picture);
							if(Input.GetMouseButton(0) == true){
								if (new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14),(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1,Screen.width/16,Screen.width/16).Contains(Event.current.mousePosition)){
									selectedperk = i;
								
								}
							}
						}else{
							GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),locktexture);
						}
					}else if(playersetup.itemtypes[guiweaptypei].perks[i].ymod == -3){
						if(playersetup.itemtypes[guiweaptypei].perksbought > 6){
						GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),playersetup.itemtypes[guiweaptypei].perks[i].picture);
							if(Input.GetMouseButton(0) == true){
								if (new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14),(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1,Screen.width/16,Screen.width/16).Contains(Event.current.mousePosition)){
									selectedperk = i;
									
								}
							}
						}else{
							GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),locktexture);
						}
					}else if(playersetup.itemtypes[guiweaptypei].perks[i].ymod == -4){
						if(playersetup.itemtypes[guiweaptypei].perks[6].currentlevel> 0){
						GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),playersetup.itemtypes[guiweaptypei].perks[i].picture);
							if(Input.GetMouseButton(0) == true){
								if (new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14),(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1,Screen.width/16,Screen.width/16).Contains(Event.current.mousePosition)){
									selectedperk = i;
									
								}
							}
						}else{
							GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),locktexture);
						}
					}else if(playersetup.itemtypes[guiweaptypei].perks[i].ymod == -5){
						if(playersetup.itemtypes[guiweaptypei].perksbought > 10){
						GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),playersetup.itemtypes[guiweaptypei].perks[i].picture);
							if(Input.GetMouseButton(0) == true){
								if (new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14),(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1,Screen.width/16,Screen.width/16).Contains(Event.current.mousePosition)){
									selectedperk = i;
									
								}
							}
						}else{
							GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),locktexture);
						}
					}else if(playersetup.itemtypes[guiweaptypei].perks[i].ymod == -6){
						if(playersetup.itemtypes[guiweaptypei].perks[9].currentlevel> 0){
						GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),playersetup.itemtypes[guiweaptypei].perks[i].picture);
							if(Input.GetMouseButton(0) == true){
								if (new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14),(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1,Screen.width/16,Screen.width/16).Contains(Event.current.mousePosition)){
									selectedperk = i;
									
								}
							}
						}else{
							GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),locktexture);
						}
					}else if(playersetup.itemtypes[guiweaptypei].perks[i].ymod == -7){
						if(playersetup.itemtypes[guiweaptypei].perksbought > 19 & playersetup.itemtypes[guiweaptypei].perks[9].currentlevel> 0){
						GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),playersetup.itemtypes[guiweaptypei].perks[i].picture);
							if(Input.GetMouseButton(0) == true){
								if (new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14),(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1,Screen.width/16,Screen.width/16).Contains(Event.current.mousePosition)){
									selectedperk = i;
									
								}
							}
						}else{
							GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),locktexture);
						}
					}else if(playersetup.itemtypes[guiweaptypei].perks[i].ymod == -8){
						if(playersetup.itemtypes[guiweaptypei].perksbought > 24 & playersetup.itemtypes[guiweaptypei].perks[9].currentlevel> 0){
						GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),playersetup.itemtypes[guiweaptypei].perks[i].picture);
							if(Input.GetMouseButton(0) == true){
								if (new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14),(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1,Screen.width/16,Screen.width/16).Contains(Event.current.mousePosition)){
									selectedperk = i;
									
								}
							}
						}else{
							GUI.DrawTexture(new Rect((Screen.width/2-Screen.width/4)+(playersetup.itemtypes[guiweaptypei].perks[i].xmod*Screen.width/14)+5,(Screen.height/10)-(playersetup.itemtypes[guiweaptypei].perks[i].ymod*Screen.height/5)-scrollbarvalue1+5,Screen.width/16-10,Screen.width/16-10),locktexture);
						}
					}
			}
			if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].perkname != "" & playersetup.itemtypes[guiweaptypei].perks[selectedperk].perkname != null){
				GUI.skin = inventoryfont;
				GUI.Label (new Rect ((Screen.width/1.73f) ,(Screen.height/8), 500,200), playersetup.itemtypes[guiweaptypei].perks[selectedperk].perkname);
				GUI.skin = normaltext;
				GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16), 300,200), playersetup.itemtypes[guiweaptypei].perks[selectedperk].perkdescription);
				if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].currentlevel < playersetup.itemtypes[guiweaptypei].perks[selectedperk].maxlevel){
					GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+100), 300,200), "Current Weapon Bonuses");
					GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+100), 300,200), "Weapon Bonuses With Perk");
					int displaycounter = 0;
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusattackspeed >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Attack Speed Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusattackspeed*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150)+displaycounter, 300,200), "Attack Speed Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonusattackspeed+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusattackspeed)*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusdamage >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Damage Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusdamage*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150)+displaycounter, 300,200), "Damage Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonusdamage+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusdamage)*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonushealth >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Health Bonus: " + (playersetup.itemtypes[guiweaptypei].bonushealth*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150)+displaycounter, 300,200), "Health Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonushealth+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonushealth)*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusshield >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Shield Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusshield*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150)+displaycounter, 300,200), "Shield Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonusshield+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusshield)*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusarmor >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Armor Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusarmor*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Armor Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonusarmor+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusarmor)*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusadrenaline >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Adrenaline Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusadrenaline*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150)+displaycounter, 300,200), "Adrenaline Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonusadrenaline+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusadrenaline)*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusbleeddamage >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Bleed Damage Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusbleeddamage*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150)+displaycounter, 300,200), "Bleed Damage Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonusbleeddamage+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusbleeddamage)*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusbleeddamagechance >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Bleed Damage Chance Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusbleeddamagechance*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Bleed Damage Chance Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonusbleeddamagechance+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusbleeddamagechance)*100)+ "%");
						displaycounter = displaycounter + 25;
					}if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonuscriticalchance >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Critical Hit Chance Bonus: " + (playersetup.itemtypes[guiweaptypei].bonuscriticalchance*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150)+displaycounter, 300,200), "Critical Hit Chance Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonuscriticalchance+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonuscriticalchance)*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonushealthabsorb >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Health Absorb Bonus: " + (playersetup.itemtypes[guiweaptypei].bonushealthabsorb*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Heatlh Absorb Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonushealthabsorb+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonushealthabsorb)*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusstunchance >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12-Screen.width/15f,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Stun Chance Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusstunchance*100)+ "%");
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12+Screen.width/15f,(Screen.height/8)+(Screen.height/16+150)+displaycounter, 300,200), "Stun Chance Bonus: " + ((playersetup.itemtypes[guiweaptypei].bonusstunchance+playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusstunchance)*100)+ "%");
						displaycounter = displaycounter + 25;
					}
				}else{
					int displaycounter = 0;
					GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+100), 300,200), "Current Weapon Bonuses");
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusattackspeed >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Attack Speed Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusattackspeed*100)+ "%");

						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusdamage >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Damage Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusdamage*100)+ "%");

						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonushealth >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Health Bonus: " + (playersetup.itemtypes[guiweaptypei].bonushealth*100)+ "%");

						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusshield >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Shield Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusshield*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusarmor >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Armor Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusarmor*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusadrenaline >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Adrenaline Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusadrenaline*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusbleeddamage >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Bleed Damage Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusbleeddamage*100)+ "%");
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusbleeddamagechance >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Bleed Damage Chance Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusbleeddamagechance*100)+ "%");
						displaycounter = displaycounter + 25;
					}if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonuscriticalchance >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Critical Hit Chance Bonus: " + (playersetup.itemtypes[guiweaptypei].bonuscriticalchance*100)+ "%");;
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonushealthabsorb >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Health Absorb Bonus: " + (playersetup.itemtypes[guiweaptypei].bonushealthabsorb*100)+ "%");						
						displaycounter = displaycounter + 25;
					}
					if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusstunchance >0){
						GUI.Label (new Rect ((Screen.width/1.8f)+ Screen.width/12,(Screen.height/8)+(Screen.height/16+150+displaycounter), 300,200), "Stun Chance Bonus: " + (playersetup.itemtypes[guiweaptypei].bonusstunchance*100)+ "%");
						displaycounter = displaycounter + 25;
					}
				}
				GUI.skin = inventoryfont;
				GUI.Label (new Rect ((Screen.width/1.58f),(Screen.height/8)+(Screen.height/2.6f), 300,200),"Perk Level " +playersetup.itemtypes[guiweaptypei].perks[selectedperk].currentlevel +" of " + playersetup.itemtypes[guiweaptypei].perks[selectedperk].maxlevel );
				GUI.Label (new Rect ((Screen.width/1.58f),(Screen.height/8)+(Screen.height/2.3f), 300,200),playersetup.itemtypes[guiweaptypei].perkpoints + " Perk Points Available");
				if(playersetup.itemtypes[guiweaptypei].perkpoints > 0 & playersetup.itemtypes[guiweaptypei].perks[selectedperk].currentlevel < playersetup.itemtypes[guiweaptypei].perks[selectedperk].maxlevel ){
					if(GUI.Button (new Rect((Screen.width/1.8f)+ Screen.width/12+Screen.width/26f,(Screen.height/8)+(Screen.height/2f), 150,50),"Purchase")){
						playersetup.itemtypes[guiweaptypei].perksbought++;
						playersetup.itemtypes[guiweaptypei].perks[selectedperk].currentlevel++;
						playersetup.itemtypes[guiweaptypei].perkpoints--;
						playersetup.itemtypes[guiweaptypei].bonusattackspeed =  playersetup.itemtypes[guiweaptypei].bonusattackspeed+(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusattackspeed);
						playersetup.itemtypes[guiweaptypei].bonusdamage =	playersetup.itemtypes[guiweaptypei].bonusdamage+ (playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusdamage);
						playersetup.itemtypes[guiweaptypei].bonushealth = playersetup.itemtypes[guiweaptypei].bonushealth +(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonushealth);
						playersetup.itemtypes[guiweaptypei].bonusshield = playersetup.itemtypes[guiweaptypei].bonusshield + (playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusshield);
						playersetup.itemtypes[guiweaptypei].bonusarmor =  playersetup.itemtypes[guiweaptypei].bonusarmor+(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusarmor);
						playersetup.itemtypes[guiweaptypei].bonusadrenaline =	playersetup.itemtypes[guiweaptypei].bonusadrenaline+ (playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusadrenaline);
						playersetup.itemtypes[guiweaptypei].bonusbleeddamage = playersetup.itemtypes[guiweaptypei].bonusbleeddamage +(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusbleeddamage);
						playersetup.itemtypes[guiweaptypei].bonusbleeddamagechance = playersetup.itemtypes[guiweaptypei].bonusbleeddamagechance + (playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusbleeddamagechance);
						playersetup.itemtypes[guiweaptypei].bonuscriticalchance = playersetup.itemtypes[guiweaptypei].bonuscriticalchance +(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonuscriticalchance);
						playersetup.itemtypes[guiweaptypei].bonushealthabsorb = playersetup.itemtypes[guiweaptypei].bonushealthabsorb + (playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonushealthabsorb);
						playersetup.itemtypes[guiweaptypei].bonusstunchance = playersetup.itemtypes[guiweaptypei].bonusstunchance +(playersetup.itemtypes[guiweaptypei].perks[selectedperk].bonusstunchance);

						playersetup.player.addedhealth = (int)(playersetup.player.basehealth*playersetup.itemtypes[playerweaptypei].bonushealth);
						playersetup.player.overhealth =playersetup.player.basehealth+playersetup.player.addedhealth + playersetup.currentweapon.health;
						if(playersetup.player.overhealth<playersetup.player.currenthealth){
							playersetup.player.currenthealth =playersetup.player.overhealth;
						}

						playersetup.player.addedshield = (int)(playersetup.player.baseshield*playersetup.itemtypes[playerweaptypei].bonusshield);
						playersetup.player.overshield = playersetup.player.baseshield+playersetup.player.addedshield + playersetup.currentweapon.shield;
						if(playersetup.player.overshield < playersetup.player.shield){
							playersetup.player.shield = playersetup.player.overshield;
						}
						//Debug.Log(playersetup.player.addedshield);

					}
				}else if(playersetup.itemtypes[guiweaptypei].perkpoints == 0){
					if(GUI.Button (new Rect((Screen.width/1.8f)+ Screen.width/12+Screen.width/26f,(Screen.height/8)+(Screen.height/2f), 150,50),"No Points")){
						
					}
				}else if(playersetup.itemtypes[guiweaptypei].perks[selectedperk].currentlevel >= playersetup.itemtypes[guiweaptypei].perks[selectedperk].maxlevel){
					if(GUI.Button (new Rect((Screen.width/1.8f)+ Screen.width/12+Screen.width/26f,(Screen.height/8)+(Screen.height/2f), 150,50),"Max Level")){
						
					}
				}
			}

			if(GUI.Button (new Rect(200,30,100,40),"Resume")){
				secondcamera.transform.localPosition = new Vector3(0,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				selectedweapname = "";
				Time.timeScale = 1f;
				guimenu = 0;
				ingame = true;
				playerobject.GetComponent<GaryCharacterController>().isplaying = true;
				maincamera.active = true;
				secondcamera.active = false;
				rotateobj = false;
			}
			if(GUI.Button (new Rect(80,30,100,40),"Back")){
				secondcamera.transform.localPosition = new Vector3(-40,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 3;
			}
		}
		if(guimenu == 6){
			GUI.skin = normaltext;
			scrollbarvalue1+=-(30*Input.GetAxis("Mouse ScrollWheel"));
			scrollbarvalue1 =  GUI.VerticalScrollbar(new Rect(Screen.width-50,50,30,Screen.height-100),scrollbarvalue1,100.0F, 0.0F, 1000.0F);
			GUI.skin = bigfont;
			GUI.Label (new Rect(Screen.width/2-300,100-scrollbarvalue1,600,200),playersetup.itemtypes[guiweaptypei].name + " Challenges");
			GUI.skin = xp2;
			GUI.Box (new Rect(Screen.width/2-150, 200-scrollbarvalue1,300,30),"");
			GUI.skin = xp3; 
			GUI.Box (new Rect (Screen.width/2-150,200-scrollbarvalue1, (playersetup.itemtypes[guiweaptypei].currentchallengescomplete * 300 /14), 30), "");
			GUI.skin = xp;
			GUI.Box (new Rect(Screen.width/2-150, 200-scrollbarvalue1,300,30),"Challenges Complete: " + playersetup.itemtypes[guiweaptypei].currentchallengescomplete+ " of 14");


			for(int y = 0;y<=6;y++){
				for(int x = 0;x<=1;x++){
					GUI.skin = normaltext;
					GUI.Box (new Rect(Screen.width/8 +(x*(Screen.width/3+100)),(y*200)+425-scrollbarvalue1,(Screen.width/3),160),"");
					GUI.skin = inventoryfont;
					GUI.Label(new Rect(Screen.width/3.5f+(x*(Screen.width/3+100)),(y*200)+425-scrollbarvalue1,20 ,200),playersetup.itemtypes[guiweaptypei].challenges[2*y+x].name );
					GUI.Label(new Rect(Screen.width/3.5f+(x*(Screen.width/3+100)),(y*200)+455-scrollbarvalue1,20 ,100),playersetup.itemtypes[guiweaptypei].challenges[2*y+x].description );

					GUI.Label(new Rect(Screen.width/3.5f+(x*(Screen.width/3+100)),(y*200)+485-scrollbarvalue1,20 ,100),"+" + playersetup.itemtypes[guiweaptypei].challenges[2*y+x].xpreward + " Xp, " +  playersetup.itemtypes[guiweaptypei].challenges[2*y+x].reward);

					GUI.skin = xp2;
					GUI.Box (new Rect(Screen.width/4.4f+(x*(Screen.width/3+100)),(y*200)+ 540-scrollbarvalue1,200,30),"");
			

				
					if(playersetup.itemtypes[guiweaptypei].challenges[2*y+x].currentprogress<playersetup.itemtypes[guiweaptypei].challenges[2*y+x].maxprogress){
						GUI.skin = xp3; 
						
						GUI.Box (new Rect (Screen.width/4.4f+(x*(Screen.width/3+100)),(y*200)+540-scrollbarvalue1, ((float)playersetup.itemtypes[guiweaptypei].challenges[2*y+x].currentprogress* 200/(float)playersetup.itemtypes[guiweaptypei].challenges[2*y+x].maxprogress ), 30), "");
						GUI.skin = xp;
						GUI.Box (new Rect(Screen.width/4.4f+(x*(Screen.width/3+100)), (y*200)+540-scrollbarvalue1,200,30),(playersetup.itemtypes[guiweaptypei].challenges[2*y+x].currentprogress)+ " of " + (playersetup.itemtypes[guiweaptypei].challenges[2*y+x].maxprogress));
					}else{
						GUI.skin = xp3; 
						
						GUI.Box (new Rect (Screen.width/4.4f+(x*(Screen.width/3+100)),(y*200)+540-scrollbarvalue1,200, 30), "");
						GUI.skin = xp;
						GUI.Box (new Rect(Screen.width/4.4f+(x*(Screen.width/3+100)), (y*200)+540-scrollbarvalue1,200,30),("Challenge Completed!"));
					}
				}
			}



			GUI.skin = normaltext;
			if(GUI.Button (new Rect(200,30,100,40),"Resume")){
				secondcamera.transform.localPosition = new Vector3(0,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				selectedweapname = "";
				Time.timeScale = 1f;
				guimenu = 0;
				ingame = true;
				playerobject.GetComponent<GaryCharacterController>().isplaying = true;
				maincamera.active = true;
				secondcamera.active = false;
				rotateobj = false;
			}
			if(GUI.Button (new Rect(80,30,100,40),"Back")){
				secondcamera.transform.localPosition = new Vector3(-40,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
				guimenu = 3;
			}
		}
		if(guimenu == 0){
			if(displayingupdater == true){
				StartCoroutine(updatewait());
				GUI.Box(new Rect(Screen.width/2-150,50,300,150),"");

			}
			if(isinitialized == true){
					GUI.skin = highlightspace;
					if(playersetup.itemtypes[playerweaptypei].perks[0].currentlevel >0){
						if(playersetup.player.adrenalinecurrent >= playersetup.itemtypes[playerweaptypei].perks[0].abilitycost){
							if(playersetup.itemtypes[playerweaptypei].perks[0].abilitycooldowncurrent >= playersetup.itemtypes[playerweaptypei].perks[0].abilitycooldownmax){
								GUI.Box (new Rect(Screen.width/2-113, Screen.height-58,56,56),"");
								if(gameend == false){
									if(Input.GetKey(KeyCode.Alpha1) == true & playerobject.GetComponent<GaryCharacterController>().isattacking == false){
										playersetup.itemtypes[playerweaptypei].perks[0].abilitycooldowncurrent = 0;
										playersetup.player.adrenalinecurrent = playersetup.player.adrenalinecurrent - playersetup.itemtypes[playerweaptypei].perks[0].abilitycost; 
										if(playerweaptypei == 0){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().handability1()); 
										}
										if(playerweaptypei == 1){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().shortswordability1()); 
										}
										if(playerweaptypei == 2){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().bluntability1()); 
										}
										if(playerweaptypei == 3){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().daggerability1()); 
										}
										if(playerweaptypei == 4){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().axeability1()); 
										}
										if(playerweaptypei == 5){
											
										}
										if(playerweaptypei == 6){
											
										}
										if(playerweaptypei == 7){
											
										}
										if(playerweaptypei == 8){
											
										}
									}
								}
							}else{
								GUI.Box (new Rect(Screen.width/2-113, Screen.height-3-(float)playersetup.itemtypes[playerweaptypei].perks[0].abilitycooldowncurrent/(float)playersetup.itemtypes[playerweaptypei].perks[0].abilitycooldownmax*56,56,(float)playersetup.itemtypes[playerweaptypei].perks[0].abilitycooldowncurrent/(float)playersetup.itemtypes[playerweaptypei].perks[0].abilitycooldownmax*56),"");
							}
						}
						GUI.DrawTexture(new Rect(Screen.width/2-110, Screen.height-55,50,50),playersetup.itemtypes[playerweaptypei].perks[0].picture);
					}
					if(playersetup.itemtypes[playerweaptypei].perks[6].currentlevel >0){
						if(playersetup.player.adrenalinecurrent >= playersetup.itemtypes[playerweaptypei].perks[6].abilitycost){
							if(playersetup.itemtypes[playerweaptypei].perks[6].abilitycooldowncurrent >= playersetup.itemtypes[playerweaptypei].perks[6].abilitycooldownmax){
								GUI.Box (new Rect(Screen.width/2-58, Screen.height-58,56,56),"");
								if(gameend == false){
									if(Input.GetKey(KeyCode.Alpha2) == true & playerobject.GetComponent<GaryCharacterController>().isattacking == false){
										playersetup.itemtypes[playerweaptypei].perks[6].abilitycooldowncurrent = 0;
										playersetup.player.adrenalinecurrent = playersetup.player.adrenalinecurrent - playersetup.itemtypes[playerweaptypei].perks[6].abilitycost; 
										if(playerweaptypei == 0){
											playerweapdamagebuff = playerweapdamagebuff + 1;
											playerweapattspeedbuff = playerweapattspeedbuff + 1;
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().handability2wait()); 
										}
										if(playerweaptypei == 1){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().shortswordability2()); 
										}
										if(playerweaptypei == 2){
											playerweaphealthabsorbbuff = playerweaphealthabsorbbuff + .5m;
											playerweapattspeedbuff = playerweapattspeedbuff + 1;
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().bluntability2wait()); 
										}
										if(playerweaptypei == 3){
											playerweapdamagebuff = playerweapdamagebuff + 3;
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().daggerability2wait()); 
										}
										if(playerweaptypei == 4){
											playersetup.player.shield = playersetup.player.overshield;
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().axeability2delay()); 
										}
										if(playerweaptypei == 5){
											
										}
										if(playerweaptypei == 6){
											
										}
										if(playerweaptypei == 7){
											
										}
										if(playerweaptypei == 8){
											
										}
									}
								}
							}else{
								GUI.Box (new Rect(Screen.width/2-58, Screen.height-2-(float)playersetup.itemtypes[playerweaptypei].perks[6].abilitycooldowncurrent/(float)playersetup.itemtypes[playerweaptypei].perks[6].abilitycooldownmax*56,56,(float)playersetup.itemtypes[playerweaptypei].perks[6].abilitycooldowncurrent/(float)playersetup.itemtypes[playerweaptypei].perks[6].abilitycooldownmax*56),"");
							
							}
						}
						GUI.DrawTexture(new Rect(Screen.width/2-55, Screen.height-55,50,50),playersetup.itemtypes[playerweaptypei].perks[6].picture);
					}
					if(playersetup.itemtypes[playerweaptypei].perks[9].currentlevel >0){
						if(playersetup.player.adrenalinecurrent >= playersetup.itemtypes[playerweaptypei].perks[9].abilitycost){
							if(playersetup.itemtypes[playerweaptypei].perks[9].abilitycooldowncurrent >= playersetup.itemtypes[playerweaptypei].perks[9].abilitycooldownmax){
								GUI.Box (new Rect(Screen.width/2-3, Screen.height-58,56,56),"");
								if(gameend == false){
									if(Input.GetKey(KeyCode.Alpha3) == true & playerobject.GetComponent<GaryCharacterController>().isattacking == false){
										playersetup.itemtypes[playerweaptypei].perks[9].abilitycooldowncurrent = 0;
										playersetup.player.adrenalinecurrent = playersetup.player.adrenalinecurrent - playersetup.itemtypes[playerweaptypei].perks[9].abilitycost; 
										if(playerweaptypei == 0){
											playersetup.player.currenthealth =  playersetup.player.currenthealth+ (int)(playersetup.player.overhealth * .3f);
											if( playersetup.player.overhealth <playersetup.player.currenthealth){
												playersetup.player.currenthealth = playersetup.player.overhealth;
											}
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().handability3delay()); 
										}
										if(playerweaptypei == 1){
											playerweapdamagebuff = playerweapdamagebuff + 4;
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().shortswordability3wait()); 
										}
										if(playerweaptypei == 2){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().bluntability3()); 
										}
										if(playerweaptypei == 3){
											playerweapattspeedbuff = playerweapattspeedbuff + 1;
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().daggerability3wait()); 
										}
										if(playerweaptypei == 4){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().axeability3()); 
										}
										if(playerweaptypei == 5){
											
										}
										if(playerweaptypei == 6){
											
										}
										if(playerweaptypei == 7){
											
										}
										if(playerweaptypei == 8){
											
										}
									}
								}
							}else{
								GUI.Box (new Rect(Screen.width/2-3, Screen.height-2-(float)playersetup.itemtypes[playerweaptypei].perks[9].abilitycooldowncurrent/(float)playersetup.itemtypes[playerweaptypei].perks[9].abilitycooldownmax*56,56,(float)playersetup.itemtypes[playerweaptypei].perks[9].abilitycooldowncurrent/(float)playersetup.itemtypes[playerweaptypei].perks[9].abilitycooldownmax*56),"");
							}
						}
						GUI.DrawTexture(new Rect(Screen.width/2, Screen.height-55,50,50),playersetup.itemtypes[playerweaptypei].perks[9].picture);
					}
					if(playersetup.itemtypes[playerweaptypei].perks[15].currentlevel >0){
						if(playersetup.player.adrenalinecurrent >= playersetup.itemtypes[playerweaptypei].perks[15].abilitycost){
							if(playersetup.itemtypes[playerweaptypei].perks[15].abilitycooldowncurrent >= playersetup.itemtypes[playerweaptypei].perks[15].abilitycooldownmax){
								GUI.Box (new Rect(Screen.width/2+52, Screen.height-58,56,56),"");
								if(gameend == false){
									if(Input.GetKey(KeyCode.Alpha4) == true & playerobject.GetComponent<GaryCharacterController>().isattacking == false){
										playersetup.itemtypes[playerweaptypei].perks[15].abilitycooldowncurrent = 0;
										playersetup.player.adrenalinecurrent = playersetup.player.adrenalinecurrent - playersetup.itemtypes[playerweaptypei].perks[15].abilitycost; 
										if(playerweaptypei == 0){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().handability4()); 
										}
										if(playerweaptypei == 1){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().shortswordability4()); 
										}
										if(playerweaptypei == 2){
											playerweapcriticalchancebuff = playerweapcriticalchancebuff + 1;
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().bluntability4wait()); 
										}
										if(playerweaptypei == 3){
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().daggerability4()); 
										}
										if(playerweaptypei == 4){
											ishealing = true;
											StartCoroutine(playerobject.GetComponent<GaryCharacterController>().regenhealth()); 
										}
										if(playerweaptypei == 5){
											
										}
										if(playerweaptypei == 6){
											
										}
										if(playerweaptypei == 7){
											
										}
										if(playerweaptypei == 8){
											
										}
									}
								}
							}else{

								GUI.Box (new Rect(Screen.width/2+52, Screen.height-2-(float)playersetup.itemtypes[playerweaptypei].perks[15].abilitycooldowncurrent/(float)playersetup.itemtypes[playerweaptypei].perks[15].abilitycooldownmax*56,56,(float)playersetup.itemtypes[playerweaptypei].perks[15].abilitycooldowncurrent/(float)playersetup.itemtypes[playerweaptypei].perks[15].abilitycooldownmax*56),"");
							}
						}
						GUI.DrawTexture(new Rect(Screen.width/2+55, Screen.height-55,50,50),playersetup.itemtypes[playerweaptypei].perks[15].picture);
					}	
					GUI.skin = normaltext;
					GUI.Box (new Rect(Screen.width/2-110, Screen.height-55,50,50),"");
					GUI.Box (new Rect(Screen.width/2-55, Screen.height-55,50,50),"");
					GUI.Box (new Rect(Screen.width/2, Screen.height-55,50,50),"");
					GUI.Box (new Rect(Screen.width/2+55, Screen.height-55,50,50),"");
					GUI.skin = normaltext;
					GUI.Label (new Rect(Screen.width/2-110, Screen.height-75,50,50),"1");
					GUI.Label (new Rect(Screen.width/2-55, Screen.height-75,50,50),"2");
					GUI.Label (new Rect(Screen.width/2, Screen.height-75,50,50),"3");
					GUI.Label (new Rect(Screen.width/2+55, Screen.height-75,50,50),"4");

					GUI.Box(new Rect(20,Screen.height - 270,330,250),"");
					GUI.skin = normaltext;
					if( Input.GetKey(KeyCode.I) == true){
						secondcamera.transform.localPosition = new Vector3(0,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
						playerobject.GetComponent<GaryCharacterController>().isplaying = false;
						maincamera.active = false;
						secondcamera.active = true;
						selectedweapname = playerweapname;
						selectedweaplevel = playerweaplevel;
						selectedweapdamage= playerweapdamage;
						selectedweaptype = playerweaptype;
						selectedweapattspeed = playerweapattspeed;
						selectedweapadrenalinerate =playerweapadrenalinerate;
						selectedweaparmor= playerweaparmor;
						selectedweapbleeddamage= playerweapbleeddamage;
						selectedweapbleeddamagechance= playerweapbleeddamagechance;
						selectedweapcriticalchance = playerweapcriticalchance;
						selectedweaphealth= playerweaphealth;
						selectedweaphealthabsorb= playerweaphealthabsorb;
						selectedweapshield = playerweapshield;
						selectedweapstunchance= playerweapstunchance;
						selectedweapslot = playerweaponslot;
						guimenu = 2;
						Time.timeScale = 0f;
					}
					if( Input.GetKey(KeyCode.P) == true){
						secondcamera.transform.localPosition = new Vector3(-40,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
						playerobject.GetComponent<GaryCharacterController>().isplaying = false;
						maincamera.active = false;
						secondcamera.active = true;
						selectedweapname = playerweapname;
						selectedweaplevel = playerweaplevel;
						selectedweapdamage= playerweapdamage;
						selectedweaptype = playerweaptype;
						selectedweapattspeed = playerweapattspeed;
						selectedweapadrenalinerate =playerweapadrenalinerate;
						selectedweaparmor= playerweaparmor;
						selectedweapbleeddamage= playerweapbleeddamage;
						selectedweapbleeddamagechance= playerweapbleeddamagechance;
						selectedweapcriticalchance = playerweapcriticalchance;
						selectedweaphealth= playerweaphealth;
						selectedweaphealthabsorb= playerweaphealthabsorb;
						selectedweapshield = playerweapshield;
						selectedweapstunchance= playerweapstunchance;
						selectedweapslot = playerweaponslot;
						guimenu = 3;
						Time.timeScale = 0f;
					}
					if(GUI.Button (new Rect(80, Screen.height-90,100,40),"Menu")){
						secondcamera.transform.localPosition = new Vector3(-20,secondcamera.transform.localPosition.y,secondcamera.transform.localPosition.z);
						playerobject.GetComponent<GaryCharacterController>().isplaying = false;
						maincamera.active = false;
						secondcamera.active = true;
						selectedweapname = playerweapname;
						selectedweaplevel = playerweaplevel;
						selectedweapdamage= playerweapdamage;
						selectedweaptype = playerweaptype;
						selectedweapattspeed = playerweapattspeed;
						selectedweapadrenalinerate =playerweapadrenalinerate;
						selectedweaparmor= playerweaparmor;
						selectedweapbleeddamage= playerweapbleeddamage;
						selectedweapbleeddamagechance= playerweapbleeddamagechance;
						selectedweapcriticalchance = playerweapcriticalchance;
						selectedweaphealth= playerweaphealth;
						selectedweaphealthabsorb= playerweaphealthabsorb;
						selectedweapshield = playerweapshield;
						selectedweapstunchance= playerweapstunchance;
						selectedweapslot = playerweaponslot;
						guimenu = 1;
						Time.timeScale = 0f;
					}
					GUI.skin = heatlh;
					GUI.Label(new Rect(145, Screen.height-220,200,30),"Overall Level " + playersetup.player.playerlevel);
				

					GUI.Box (new Rect(80, Screen.height-200,200,30),"");
					GUI.skin = heatlh2; 
					if(playersetup.player.currenthealth>0){
						GUI.Box (new Rect (80, Screen.height-200, (playersetup.player.currenthealth * 200 /playersetup.player.overhealth), 30), "");
					}else{
						GUI.Box (new Rect (80, Screen.height-200, 0, 30), "");
					}

					GUI.skin = heatlh3;
					GUI.Box (new Rect(80, Screen.height-200,200,30),"Health: " + playersetup.player.currenthealth+ "/" + playersetup.player.overhealth);


					GUI.skin = normaltext;
					GUI.Label(new Rect(80, Screen.height-150,200,30),playersetup.currentweapon.itemtype +" Level: " + playersetup.itemtypes[playerweaptypei].currentlevel);

				
					if(playersetup.player.overshield > 0){
						GUI.skin = xp2;
						GUI.Box (new Rect(80, Screen.height-260,200,30),"");
						GUI.skin = shield; 
						GUI.Box (new Rect (80, Screen.height-260, (playersetup.player.shield * 200 /playersetup.player.overshield), 30), "");
						GUI.skin = heatlh3;
						GUI.Box (new Rect(80, Screen.height-260,200,30),"Shield: " + playersetup.player.shield+ "/" + playersetup.player.overshield);
					}
					if(cubecount >0){
						GUI.DrawTexture (new Rect(200, Screen.height-85,30,30),Resources.Load("GoldCubePic") as Texture);
					}
					if(cubecount >1){
						GUI.DrawTexture (new Rect(240, Screen.height-85,30,30),Resources.Load("GoldCubePic") as Texture);
					}
					if(cubecount >2){
						GUI.DrawTexture (new Rect(280, Screen.height-85,30,30),Resources.Load("GoldCubePic") as Texture);
					}
			
		
					


					GUI.skin = xp2;
					GUI.Box (new Rect(80, Screen.height-130,200,30),"");
					if(playersetup.player.adrenalinecurrent> 0){
						GUI.skin = yellowtext;
						GUI.Box (new Rect (80, Screen.height-130, (playersetup.player.adrenalinecurrent* 200 / playersetup.player.adrenalinemax), 30), "");
					}
					GUI.skin = xp;
					GUI.Box (new Rect(80,Screen.height-130,200,30),"Adrenaline: " + playersetup.player.adrenalinecurrent+ "/" + playersetup.player.adrenalinemax);

					if (ishovering == true & ishoveringweap == false){
						if(enemylocked){
							if (enemylocked.parent.transform.GetComponent<cubeenemy>().distance < 10){
								GUI.skin = normaltext;
								GUI.Box(new Rect(Screen.width- 350,Screen.height - 220,330,200),"");
								GUI.skin = normaltext;
								GUI.Label(new Rect(Screen.width- 230,Screen.height - 220,100,200),"Level " + enemylocked.parent.GetComponent<cubeenemy>().level + " "+  enemylocked.parent.GetComponent<cubeenemy>().enemyname);
								
								GUI.skin = heatlh;
								GUI.Box (new Rect(Screen.width- 280,Screen.height - 200,200,30),"");
								
								GUI.skin = heatlh2;
								GUI.Box (new Rect (Screen.width- 280 ,Screen.height - 200, ( enemylocked.parent.GetComponent<cubeenemy>().currenthealth * 200 /  enemylocked.parent.GetComponent<cubeenemy>().maxhealth), 30), "");
								
								
								GUI.skin = heatlh3;
								GUI.Box (new Rect(Screen.width- 280,Screen.height - 200,200,30),"Health: " +enemylocked.parent.GetComponent<cubeenemy>().currenthealth+ "/" + enemylocked.parent.GetComponent<cubeenemy>().maxhealth);
							}else{
								ishovering = false;
							}
						}
					}else if(ishovering == false & ishoveringweap == true){
						if(weaplocked){
							if (weaplocked.GetComponent<weaponhover>().distance < 2){
								GUI.skin = normaltext;
								GUI.Box(new Rect(Screen.width- 365,Screen.height - 270,345,250),"");
								GUI.skin = normaltext;
								GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 270, 200,200), weaptype);
								GUI.Label(new Rect(Screen.width- 380,Screen.height - 250,200,200),"Level " + weaplevel+ " " + weapname);
								if (invfull == false){
									if (GUI.Button(new Rect (Screen.width- 315 ,Screen.height - 60, 80,30),"Pick Up")){
										do{
											if(playersetup.Inventory[i].name == ""){
												playersetup.Inventory[i].attackspeed = weapattspeed;
												playersetup.Inventory[i].damage = weapdamage;
												playersetup.Inventory[i].level = weaplevel;
												playersetup.Inventory[i].itemtype = weaptype;
												playersetup.Inventory[i].name = weapname;
												playersetup.Inventory[i].health = weaphealth;
												playersetup.Inventory[i].shield = weapshield;
												playersetup.Inventory[i].armor = weaparmor;
												playersetup.Inventory[i].bleeddamage = weapbleeddamage;
												playersetup.Inventory[i].bleeddamagechance = weapbleeddamagechance;
												playersetup.Inventory[i].criticalchance = weapcriticalchance;
												playersetup.Inventory[i].healthabsorb = weaphealthabsorb;
												playersetup.Inventory[i].stunchance = weapstunchance;
												itemsininv++;
												i = 25;
												Destroy(weaplocked.gameObject);
											}
											if(itemsininv==20){
												invfull = true;
											}
											i = i + 1;
										}while(i <=playersetup.Inventory.Length);
										i = 0;
									}
								}else{
									GUI.Button(new Rect (Screen.width- 300 ,Screen.height - 100, 80,30),"Full");
								}
								if(playerweapname !="Hand"){
									int labelcounter = 0;
									GUI.skin = normaltext;
									GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 270, 200,200), playerweaptype);
									GUI.Label(new Rect(Screen.width- 200,Screen.height - 250,200,200),"Level " + playerweaplevel+ " " + playerweapname);
									if(playerweapadrenalinerate > 0){
										if(weapadrenaline > 0 | playerweapadrenalinerate > 0){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Adrenaline: " + weapadrenaline);
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height- 230+(labelcounter*15), 200,200), "Adrenaline: " + playerweapadrenalinerate);
										}else if(weaparmor < playerweaparmor){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Adrenaline: " + weapadrenaline);
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Adrenaline: " + playerweapadrenalinerate);
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Adrenaline: " + weapadrenaline);
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Adrenaline: " + playerweapadrenalinerate);
										}
										labelcounter++;
									}
									if(playerweaparmor > 0| weaparmor > 0){
										if(weaparmor > playerweaparmor){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Armor: " + weaparmor*100 + "%");
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height- 230+(labelcounter*15), 200,200), "Armor: " + playerweaparmor*100 + "%");
										}else if(weaparmor < playerweaparmor){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Armor: " + weaparmor*100 + "%");
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Armor: " + playerweaparmor*100 + "%");
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Armor: " + weaparmor*100 + "%");
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Armor: " + playerweaparmor*100 + "%");
										}
										labelcounter++;
									}

									if(playerweapattspeed > 0| weapattspeed > 0){
										if(weapattspeed > playerweapattspeed){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height- 230+(labelcounter*15), 200,200), "Attack Speed: " + weapattspeed);
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height- 230+(labelcounter*15), 200,200), "Attack Speed: " + playerweapattspeed);
										}else if(weapattspeed < playerweapattspeed){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Attack Speed: " + weapattspeed);
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Attack Speed: " + playerweapattspeed);
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Attack Speed: " + weapattspeed);
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Attack Speed: " + playerweapattspeed);
										}
										labelcounter++;
									}
									if(playerweapbleeddamage > 0 | weapbleeddamage > 0){
										if(weapbleeddamage > playerweapbleeddamage){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage: " + weapbleeddamage);
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage: " + playerweapbleeddamage);
										}else if(weapbleeddamage < playerweapbleeddamage){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage: " + weapbleeddamage);
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage: " + playerweapbleeddamage);
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage: " + weapbleeddamage);
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage: " + playerweapbleeddamage);
										}
										labelcounter++;
									}
									if(playerweapbleeddamagechance > 0| weapbleeddamagechance > 0){
										if(weapbleeddamagechance > playerweapbleeddamagechance){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage Chance: " + weapbleeddamagechance*100 + "%");
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage Chance: " + playerweapbleeddamagechance*100 + "%");
										}else if(weapbleeddamagechance < playerweapbleeddamagechance){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage Chance: " + weapbleeddamagechance*100 + "%");
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage Chance: " + playerweapbleeddamagechance*100 + "%");
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage Chance: " + weapbleeddamagechance*100 + "%");
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage Chance: " + playerweapbleeddamagechance*100 + "%");
										}
										labelcounter++;
									}
									if(playerweapcriticalchance > 0 | weapcriticalchance > 0){
										if(weapcriticalchance > playerweapcriticalchance){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Critical Chance: " + weapcriticalchance*100 + "%");
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height- 230+(labelcounter*15), 200,200), "Critical Chance: " + playerweapcriticalchance*100 + "%");
										}else if(weapcriticalchance < playerweapcriticalchance){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Critical Chance: " + weapcriticalchance*100 + "%");
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Critical Chance: " + playerweapcriticalchance*100 + "%");
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Critical Chance: " + weapcriticalchance*100 + "%");
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Critical Chance: " + playerweapcriticalchance*100 + "%");
										}
										labelcounter++;
									}
									if(playerweapdamage > 0 | weapdamage > 0){
										if(weapdamage > playerweapdamage){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Damage: " + weapdamage);
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Damage: " + playerweapdamage);
										}else if(weapdamage < playerweapdamage){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Damage: " + weapdamage);
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Damage: " + playerweapdamage);
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Damage: " + weapdamage);
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Damage: " + playerweapdamage);
										}
										labelcounter++;
									}
									if(playerweaphealth > 0 | weaphealth > 0){
										if(weaphealth > playerweaphealth){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height- 230+(labelcounter*15), 200,200), "Health: " + weaphealth);
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Health: " + playerweaphealth);
										}else if(weaphealth < playerweaphealth){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Health: " + weaphealth);
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Health: " + playerweaphealth);
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Health: " + weaphealth);
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Health: " + playerweaphealth);
										}
										labelcounter++;
									}
									if(playerweaphealthabsorb > 0| weaphealthabsorb > 0){
										if(weaphealthabsorb> playerweaphealthabsorb){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Health Absorb: " + weaphealthabsorb*100 + "%");
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Health Absorb: " + playerweaphealthabsorb*100 + "%");
										}else if(weapdamage < playerweaphealthabsorb){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Health Absorb: " + weaphealthabsorb*100 + "%");
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height- 230+(labelcounter*15), 200,200), "Health Absorb: " + playerweaphealthabsorb*100 + "%");
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Health Absorb: " + weaphealthabsorb*100 + "%");
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Health Absorb: " + playerweaphealthabsorb*100 + "%");
										}
										labelcounter++;
									}
									if(playerweapshield > 0 | weapshield > 0){
										if(weapshield > playerweapshield){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Shield: " + weapshield);
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Shield: " + playerweapshield);
										}else if(weapshield < playerweapshield){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Shield: " + weapshield);
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Shield: " + playerweapshield);
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Shield: " + weapshield);
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Shield: " + playerweapshield);
										}
										labelcounter++;
									}
									if(playerweapstunchance > 0 | weapstunchance > 0){
										if(weapstunchance > playerweapstunchance){
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Stun Chance: " + weapstunchance*100 + "%");
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Stun Chance: " + playerweapstunchance*100 + "%");
										}else if(weapshield < playerweapstunchance){
											GUI.skin = redtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Stun Chance: " + weapstunchance*100 + "%");
											GUI.skin = greentext;
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Stun Chance: " + playerweapstunchance*100 + "%");
										}else{
											GUI.skin = yellowtext;
											GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Stun Chance: " + weapstunchance*100 + "%");
											GUI.Label (new Rect (Screen.width- 200 ,Screen.height - 230+(labelcounter*15), 200,200), "Stun Chance: " + playerweapstunchance*100 + "%");
										}
										labelcounter++;
									}

								}else{
									int labelcounter = 0;
									GUI.skin = greentext;
									if(weapadrenaline > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Adrenaline: " + weapadrenaline);
										labelcounter++;
									}
									if(weaparmor > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Armor: " + weaparmor*100 + "%");
										labelcounter++;
									}
									if(weapattspeed > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Attack Speed: " + weapattspeed);
										labelcounter++;
									}
									if(weapbleeddamage > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage: " + weapbleeddamage);
										labelcounter++;
									}
									if(weapbleeddamagechance > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Bleed Damage Chance: " + weapbleeddamagechance*100 + "%");
										labelcounter++;
									}
									if(weapcriticalchance > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Critical Chance: " + weapcriticalchance*100 + "%");
										labelcounter++;
									}
									if(weapdamage > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Damage: " + weapdamage);
										labelcounter++;
									}
									if(weaphealth > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Health: " + weaphealth);
										labelcounter++;
									}
									if(weaphealthabsorb > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Health Absorb: " + weaphealthabsorb*100 + "%");
										labelcounter++;
									}
									if(weapshield > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Shield: " + weapshield);
										labelcounter++;
									}
									if(weapstunchance > 0){
										GUI.Label (new Rect (Screen.width- 380 ,Screen.height - 230+(labelcounter*15), 200,200), "Stun Chance: " + weapstunchance*100 + "%");
										labelcounter++;
									}
								}
							}else{
								ishoveringweap = false;
							}
						}
					}

				}
		}
		if(gameend == true){
			if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-100,200,100),"Menu")){
				playersetup.player.currenthealth  =playersetup.player.overhealth;
				guimenu = 102;
				acthovermidifyer2 = playersetup.currentlevel +1;
				isinitialized =false;
				gameend = false;

				Application.LoadLevel(0);
			}
		}
	}
	public void gameover(){
		Instantiate (fallingobj1 ,new Vector3(Camera.main.transform.position.x-4.5f,Camera.main.transform.position.y+3,-3), Quaternion.identity);
		Instantiate (fallingobj2 ,new Vector3(Camera.main.transform.position.x-3,Camera.main.transform.position.y-2,-3), Quaternion.identity);
		playerobject.GetComponent<GaryCharacterController>().isplaying = false;
		gameend = true;
	}
	IEnumerator releasewait() {
		yield return new WaitForSeconds(.6f);
		released = false;
	}
    IEnumerator updatewait() {
		yield return new WaitForSeconds(2f);
		displayingupdater = false;
	}


}












