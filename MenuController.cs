using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	int menushowing = 1;
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
	private int i = 0;
	private int guimenu = 0;
	private bool ingame = true;
	private int itemsininv = 0;
	private bool invfull = false;
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
	
	private bool rotateobj = false;
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

	private playersetup playersetup;
	
	public bool displayingupdater = false;
	public string displayingname;
	public string displayingtype;
	
	public string objectname;
	public Transform temptransform;
	private bool gameend = false;
	private Camera maincamera;
	private Camera secondcamera;
	public GameObject menuplayer;
	public GameObject menuskills;
	public float scrollbarvalue;
	public float scrollbarvalue1;
	

	void Start () {
	
	}
	void OnGUI(){
		if (menushowing ==1){
			GUI.Box(new Rect(50,50,Screen.width-100,Screen.height-100),"");
			if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-50,200,100),"Play")){
				Application.LoadLevel(1);
			}

		}
	}
}
