using UnityEngine;
using System.Collections;

public class playersetup : MonoBehaviour {
	public Player player = new Player ();
	public ItemType capacityshield = new ItemType();
	public ItemType regenshield = new ItemType();

	public Weapon[] weapons = new Weapon[5];
	public ItemType[] itemtypes = new ItemType[6];
	public Enemy[] enemies = new Enemy[5];
	public ItemType currentweapontype;
	public Item currentweapon;
	public Item[] Inventory = new Item[21];
	public GUIscript guiscript;
	public Act[] acts = new Act[5];

	public int currentact;
	public int currentlevel;
	// Use this for initialization

	void Start () {
		DontDestroyOnLoad(transform.gameObject);
		guiscript = GameObject.Find("GameController").GetComponent<GUIscript>();
		for(int i = 0;i<20;i++){
			Inventory[i].name = "";
		}
		acts[0].levels = new Level[10];
		acts[1].levels = new Level[10];
		acts[2].levels = new Level[10];
		acts[3].levels = new Level[10];
		acts[4].levels = new Level[10];
		for(int j= 0;j<acts.Length;j++){
			acts[j].goldencubesmax = 30;
			acts[j].islocked= true;
			for(int i= 0;i<acts[j].levels.Length;i++){
				acts[j].levels[i].levelname = (j+1) +"-" + (i+1);
				acts[j].levels[i].islocked = true;
				acts[j].levels[i].goldencubescurrent = 0;
				acts[j].levels[i].goldencubesmax = 3;
				acts[j].levels[i].sceneloader = (j*10)+i;
				acts[j].levels[i].completed = false;
			}
		}

		acts[0].islocked= false;
		acts[0].levels[0].islocked = false;
		acts[0].levels[1].islocked = false;
		acts[0].levelname = "Act I";
		acts[1].levelname = "Act II";
		acts[2].levelname = "Act III";
		acts[3].levelname = "Act IV";
		acts[4].levelname = "Act V";

		acts[0].picture = Resources.Load("actpic1") as Texture;
		acts[1].picture = Resources.Load("actpic2") as Texture;
		acts[2].picture = Resources.Load("actpic3") as Texture;
		acts[3].picture = Resources.Load("actpic4") as Texture;
		acts[4].picture = Resources.Load("actpic5") as Texture;






		player.playerlevel = 1;

		player.overhealth = 10;
		player.basehealth = player.overhealth;
		player.overshield = 0;
		player.baseshield = player.overshield;

		player.damage = 3;
		player.attackspeed = 10;
		player.adrenalinemax = 100;
		player.adrenalinerate = 5;
		player.adrenalinecurrent = 80;
		player.armor = 0;
		player.bleeddamage = 0;
		player.bleeddamagechance = 0;
		player.criticalchance = 0;
		player.healthabsorb = 0;
		player.stunchance = 0;

	

		itemtypes[0].perks = new Perk[17];
		itemtypes[1].perks = new Perk[17];
		itemtypes[2].perks = new Perk[17];
		itemtypes[3].perks = new Perk[17];
		itemtypes[4].perks = new Perk[17];
		itemtypes[5].perks = new Perk[17];

		itemtypes[0].challenges = new Challenge[15];
		itemtypes[1].challenges = new Challenge[15];
		itemtypes[2].challenges = new Challenge[15];
		itemtypes[3].challenges = new Challenge[15];
		itemtypes[4].challenges = new Challenge[15];
		itemtypes[5].challenges = new Challenge[15];

		itemtypes[0].xptolevel = 500;
		itemtypes[0].currentxp = 0;
		itemtypes[0].overallxp = 0;
		itemtypes[0].currentlevel = 1;
		itemtypes[0].name = "Hand";
		itemtypes[0].animationlength = .783f;
		itemtypes[0].bonusattackspeed = 0;
		itemtypes[0].bonusdamage = 0;
		itemtypes[0].bonushealth = 0;
		itemtypes[0].bonusshield = 0;
		itemtypes[0].bonusadrenaline= 0;
		itemtypes[0].bonusarmor = 0;
		itemtypes[0].bonusbleeddamage = 0;
		itemtypes[0].bonuscriticalchance = 0;
		itemtypes[0].bonushealthabsorb= 0;
		itemtypes[0].bonusstunchance = 0;
		itemtypes[0].currentchallengescomplete = 0;
		for(int i= 0;i<itemtypes.Length;i++){
			for(int j= 0;j<itemtypes.Length;j++){
				itemtypes[i].challenges[j].iscomplete = false; 
			}
			itemtypes[i].challenges[0].currentprogress = 0;
			itemtypes[i].challenges[0].currenttier = 0;
			itemtypes[i].challenges[0].description = "Kill 100 enemies with your hand";
			itemtypes[i].challenges[0].maxprogress = 100;
			itemtypes[i].challenges[0].maxtier = 1;
			itemtypes[i].challenges[0].name = "Killer";
			itemtypes[i].challenges[0].xpreward = 200;
			itemtypes[i].challenges[0].reward = "+25 Health";

			itemtypes[i].challenges[1].currentprogress = 0;
			itemtypes[i].challenges[1].currenttier = 0;
			itemtypes[i].challenges[1].description = "Finish off 30 enemies with an ability";
			itemtypes[i].challenges[1].maxprogress = 30;
			itemtypes[i].challenges[1].maxtier = 1;
			itemtypes[i].challenges[1].name = "Competent";
			itemtypes[i].challenges[1].xpreward = 200;
			itemtypes[i].challenges[1].reward = "+25 Damage";

			itemtypes[i].challenges[2].currentprogress = 0;
			itemtypes[i].challenges[2].currenttier = 0;
			itemtypes[i].challenges[2].description = "Deal 10000 Damage";
			itemtypes[i].challenges[2].maxprogress = 10000;
			itemtypes[i].challenges[2].maxtier = 1;
			itemtypes[i].challenges[2].name = "God of War";
			itemtypes[i].challenges[2].xpreward = 200;
			itemtypes[i].challenges[2].reward = "+25 Damage";

			itemtypes[i].challenges[3].currentprogress = 0;
			itemtypes[i].challenges[3].currenttier = 0;
			itemtypes[i].challenges[3].description = "Deal 100 Critical Hits";
			itemtypes[i].challenges[3].maxprogress = 100;
			itemtypes[i].challenges[3].maxtier = 1;
			itemtypes[i].challenges[3].name = "Critical Acclaim";
			itemtypes[i].challenges[3].xpreward = 200;
			itemtypes[i].challenges[3].reward = "+2% Critical Hit chance";

			itemtypes[i].challenges[4].currentprogress = 0;
			itemtypes[i].challenges[4].currenttier = 0;
			itemtypes[i].challenges[4].description = "Deal 2000 Bleeding Damage";
			itemtypes[i].challenges[4].maxprogress = 2000;
			itemtypes[i].challenges[4].maxtier = 1;
			itemtypes[i].challenges[4].name = "Shredder";
			itemtypes[i].challenges[4].xpreward = 200;
			itemtypes[i].challenges[4].reward = "+10 Bleed Damage";

			itemtypes[i].challenges[5].currentprogress = 0;
			itemtypes[i].challenges[5].currenttier = 0;
			itemtypes[i].challenges[5].description = "Stun 100 enemies";
			itemtypes[i].challenges[5].maxprogress = 100;
			itemtypes[i].challenges[5].maxtier = 1;
			itemtypes[i].challenges[5].name = "Stunner";
			itemtypes[i].challenges[5].xpreward = 200;
			itemtypes[i].challenges[5].reward = "+2% Stun Chance";

			itemtypes[i].challenges[6].currentprogress = 0;
			itemtypes[i].challenges[6].currenttier = 0;
			itemtypes[i].challenges[6].description = "Absorb 1000 health from enemies";
			itemtypes[i].challenges[6].maxprogress = 1000;
			itemtypes[i].challenges[6].maxtier = 1;
			itemtypes[i].challenges[6].name = "Greedy";
			itemtypes[i].challenges[6].xpreward = 200;
			itemtypes[i].challenges[6].reward = "+2% Health Absorb";

			itemtypes[i].challenges[7].currentprogress = 0;
			itemtypes[i].challenges[7].currenttier = 0;
			itemtypes[i].challenges[7].description = "Kill 10 enemies while airborne";
			itemtypes[i].challenges[7].maxprogress = 10;
			itemtypes[i].challenges[7].maxtier = 1;
			itemtypes[i].challenges[7].name = "Acrobatic";
			itemtypes[i].challenges[7].xpreward = 200;
			itemtypes[i].challenges[7].reward = "+2 Attack Speed";

			itemtypes[i].challenges[9].currentprogress = 0;
			itemtypes[i].challenges[9].currenttier = 0;
			itemtypes[i].challenges[9].description = "Kill 100 Evil Cubes";
			itemtypes[i].challenges[9].maxprogress = 100;
			itemtypes[i].challenges[9].maxtier = 1;
			itemtypes[i].challenges[9].name = "Evil Conqueror";
			itemtypes[i].challenges[9].xpreward = 200;
			itemtypes[i].challenges[9].reward = "+25 Damage";

			itemtypes[i].challenges[10].currentprogress = 0;
			itemtypes[i].challenges[10].currenttier = 0;
			itemtypes[i].challenges[10].description = "Kill 100 Fast Cubes";
			itemtypes[i].challenges[10].maxprogress = 100;
			itemtypes[i].challenges[10].maxtier = 1;
			itemtypes[i].challenges[10].name = "Fast Conqueror";
			itemtypes[i].challenges[10].xpreward = 200;
			itemtypes[i].challenges[10].reward = "+25 Damage";

			itemtypes[i].challenges[11].currentprogress = 0;
			itemtypes[i].challenges[11].currenttier = 0;
			itemtypes[i].challenges[11].description = "Kill 100 Heavy Cubes";
			itemtypes[i].challenges[11].maxprogress = 100;
			itemtypes[i].challenges[11].maxtier = 1;
			itemtypes[i].challenges[11].name = "Heavy Conqueror";
			itemtypes[i].challenges[11].xpreward = 200;
			itemtypes[i].challenges[11].reward = "+25 Damage";

			itemtypes[i].challenges[12].currentprogress = 0;
			itemtypes[i].challenges[12].currenttier = 0;
			itemtypes[i].challenges[12].description = "Kill 100 Deadly Cubes";
			itemtypes[i].challenges[12].maxprogress = 100;
			itemtypes[i].challenges[12].maxtier = 1;
			itemtypes[i].challenges[12].name = "Deadly Conqueror";
			itemtypes[i].challenges[12].xpreward = 200;
			itemtypes[i].challenges[12].reward = "+25 Damage";

			itemtypes[i].challenges[13].currentprogress = 0;
			itemtypes[i].challenges[13].currenttier = 0;
			itemtypes[i].challenges[13].description = "Kill 100 Suicide Cubes";
			itemtypes[i].challenges[13].maxprogress = 100;
			itemtypes[i].challenges[13].maxtier = 1;
			itemtypes[i].challenges[13].name = "Suicide Conqueror";
			itemtypes[i].challenges[13].xpreward = 200;
			itemtypes[i].challenges[13].reward = "+25 Damage";

			itemtypes[i].challenges[8].currentprogress = 0;
			itemtypes[i].challenges[8].currenttier = 0;
			itemtypes[i].challenges[8].description = "Kill an enemy with a single hit";
			itemtypes[i].challenges[8].maxprogress = 1;
			itemtypes[i].challenges[8].maxtier = 1;
			itemtypes[i].challenges[8].name = "Owned!";
			itemtypes[i].challenges[8].xpreward = 200;
			itemtypes[i].challenges[8].reward = "+25 Damage";
		}

		itemtypes[0].perks[0].perkname = "Uppercut";
		itemtypes[0].perks[0].perkdescription = "A powerful punch that deals more damage and stuns the enemy upon impact for a short amount of time";
		itemtypes[0].perks[0].picture = Resources.Load("handability1") as Texture;
		itemtypes[0].perks[0].bonusattackspeed = 0;
		itemtypes[0].perks[0].bonusdamage =0;
		itemtypes[0].perks[0].bonushealth =0;
		itemtypes[0].perks[0].bonusshield =0;
		itemtypes[0].perks[0].currentlevel =0;
		itemtypes[0].perks[0].maxlevel =1;
		itemtypes[0].perks[0].abilitycost =20;
		itemtypes[0].perks[0].abilitycooldownmax =5;
		itemtypes[0].perks[0].abilitycooldowncurrent =5;
		itemtypes[0].perks[0].isability = true;

		itemtypes[0].perks[1].perkname = "Strong Arm";
		itemtypes[0].perks[1].perkdescription = "Increases damage while unarmed";
		itemtypes[0].perks[1].bonusdamage =.05m;
		itemtypes[0].perks[1].maxlevel =3;
		itemtypes[0].perks[1].isability = false;

		itemtypes[0].perks[2].perkname = "Tough Arm";
		itemtypes[0].perks[2].perkdescription = "Reduces damage taken while unarmed and increases health";
		itemtypes[0].perks[2].bonusarmor = .05m;
		itemtypes[0].perks[2].bonushealth =.05m;
		itemtypes[0].perks[2].maxlevel =3;
		itemtypes[0].perks[2].isability = false;

		itemtypes[0].perks[3].perkname = "Quick Arm";
		itemtypes[0].perks[3].perkdescription = "Increases attack speed while unarmed";
		itemtypes[0].perks[3].bonusattackspeed = .05m;
		itemtypes[0].perks[3].maxlevel =3;
		itemtypes[0].perks[3].isability = false;

		itemtypes[0].perks[4].perkname = "Bloody Knuckles";
		itemtypes[0].perks[4].perkdescription = "Inceases chances to deal damage over time while unarmed";
		itemtypes[0].perks[4].bonusbleeddamage =.3m;
		itemtypes[0].perks[4].maxlevel =3;
		itemtypes[0].perks[4].isability = false;

		itemtypes[0].perks[5].perkname = "Stunner";
		itemtypes[0].perks[5].perkdescription = "Inceases chances to stun enemy for 3 seconds while unarmed";
		itemtypes[0].perks[5].bonusstunchance =.03m;
		itemtypes[0].perks[5].maxlevel =3;
		itemtypes[0].perks[5].isability = false;

		itemtypes[0].perks[6].perkname = "Fists of Fury";
		itemtypes[0].perks[6].perkdescription = "Inceases damage and attack speed for 5 seconds";
		itemtypes[0].perks[6].maxlevel =1;
		itemtypes[0].perks[6].isability = true;
		itemtypes[0].perks[6].picture = Resources.Load("handability2") as Texture;
		itemtypes[0].perks[6].abilitycost =35;
		itemtypes[0].perks[6].abilitycooldownmax =10;
		itemtypes[0].perks[6].abilitycooldowncurrent =10;

		itemtypes[0].perks[7].perkname = "Energizer";
		itemtypes[0].perks[7].perkdescription = "Inceases adrenaline per hit dealt while unarmed";
		itemtypes[0].perks[7].bonusadrenaline =.2m;
		itemtypes[0].perks[7].maxlevel =3;
		itemtypes[0].perks[7].isability = false;

		itemtypes[0].perks[8].perkname = "Helping Hand";
		itemtypes[0].perks[8].perkdescription = "Absorbs health every time an attack is dealt on an enemy while unarmed";
		itemtypes[0].perks[8].bonushealthabsorb =.03m;
		itemtypes[0].perks[8].maxlevel =3;
		itemtypes[0].perks[8].isability = false;

		itemtypes[0].perks[9].perkname = "Fistful of Health";
		itemtypes[0].perks[9].perkdescription = "Instantly adds back 30 percent of total health";
		itemtypes[0].perks[9].maxlevel =1;
		itemtypes[0].perks[9].isability = true;
		itemtypes[0].perks[9].picture = Resources.Load("handability3") as Texture;
		itemtypes[0].perks[9].abilitycost =50;
		itemtypes[0].perks[9].abilitycooldownmax =20;
		itemtypes[0].perks[9].abilitycooldowncurrent =20;

		itemtypes[0].perks[10].perkname = "Critical Fist";
		itemtypes[0].perks[10].perkdescription = "Increases critical hit chance while unarmed";
		itemtypes[0].perks[10].bonuscriticalchance =.06m;
		itemtypes[0].perks[10].maxlevel =3;
		itemtypes[0].perks[10].isability = false;

		itemtypes[0].perks[11].perkname = "Armored Fist";
		itemtypes[0].perks[11].perkdescription = "Increases armor while unarmed";
		itemtypes[0].perks[11].bonusarmor =.06m;
		itemtypes[0].perks[11].maxlevel =3;
		itemtypes[0].perks[11].isability = false;

		itemtypes[0].perks[12].perkname = "Stronger Arm";
		itemtypes[0].perks[12].perkdescription = "Increases damage while unarmed";
		itemtypes[0].perks[12].bonusdamage =.2m;
		itemtypes[0].perks[12].maxlevel =3;
		itemtypes[0].perks[12].isability = false;

		itemtypes[0].perks[13].perkname = "Tougher Arm";
		itemtypes[0].perks[13].perkdescription = "Increases health while unarmed";
		itemtypes[0].perks[13].bonushealth =.2m;
		itemtypes[0].perks[13].maxlevel =3;
		itemtypes[0].perks[13].isability = false;

		itemtypes[0].perks[14].perkname = "Quicker Arm";
		itemtypes[0].perks[14].perkdescription = "Increases attack speed while unarmed";
		itemtypes[0].perks[14].bonusattackspeed =.2m;
		itemtypes[0].perks[14].maxlevel =3;
		itemtypes[0].perks[14].isability = false;

		itemtypes[0].perks[15].perkname = "Twister Fister";
		itemtypes[0].perks[15].perkdescription = "Transforms Gary into a tornado of destruction, sucking in enemies and dealing extra damage for 3 seconds";
		itemtypes[0].perks[15].maxlevel =1;
		itemtypes[0].perks[15].isability = true;
		itemtypes[0].perks[15].picture = Resources.Load("handability4") as Texture;
		itemtypes[0].perks[15].abilitycost =75;
		itemtypes[0].perks[15].abilitycooldownmax =20;
		itemtypes[0].perks[15].abilitycooldowncurrent =20;

		itemtypes[1].perks[0].perkname = "Riposte";
		itemtypes[1].perks[0].perkdescription = "A quick jab dealing 4x damage";
		itemtypes[1].perks[0].picture = Resources.Load("shortswordability1") as Texture;
		itemtypes[1].perks[0].currentlevel =0;
		itemtypes[1].perks[0].maxlevel =1;
		itemtypes[1].perks[0].abilitycost =20;
		itemtypes[1].perks[0].abilitycooldownmax =5;
		itemtypes[1].perks[0].abilitycooldowncurrent =5;
		itemtypes[1].perks[0].isability = true;
		
		itemtypes[1].perks[1].perkname = "Quick Blade";
		itemtypes[1].perks[1].perkdescription = "Increases attack speed with shortswords";
		itemtypes[1].perks[1].bonusattackspeed =.05m;
		itemtypes[1].perks[1].maxlevel =3;
		itemtypes[1].perks[1].isability = false;
		
		itemtypes[1].perks[2].perkname = "Stunning Blade";
		itemtypes[1].perks[2].perkdescription = "Increasing stun chance with shortswords";
		itemtypes[1].perks[2].bonusstunchance =.05m;
		itemtypes[1].perks[2].maxlevel =3;
		itemtypes[1].perks[2].isability = false;
		
		itemtypes[1].perks[3].perkname = "Absorbing Blade";
		itemtypes[1].perks[3].perkdescription = "Increases health absorb with shortswords";
		itemtypes[1].perks[3].bonushealthabsorb = .05m;
		itemtypes[1].perks[3].maxlevel =3;
		itemtypes[1].perks[3].isability = false;
		
		itemtypes[1].perks[4].perkname = "Sharp Edge";
		itemtypes[1].perks[4].perkdescription = "Inceases damage with shortswords";
		itemtypes[1].perks[4].bonusdamage =.03m;
		itemtypes[1].perks[4].maxlevel =3;
		itemtypes[1].perks[4].isability = false;
		
		itemtypes[1].perks[5].perkname = "Pristine Edge";
		itemtypes[1].perks[5].perkdescription = "Inceases shield with shortswords";
		itemtypes[1].perks[5].bonusshield =.03m;
		itemtypes[1].perks[5].maxlevel =3;
		itemtypes[1].perks[5].isability = false;
		
		itemtypes[1].perks[6].perkname = "Double Whammy";
		itemtypes[1].perks[6].perkdescription = "A double slice attack for 3x damage each";
		itemtypes[1].perks[6].maxlevel =1;
		itemtypes[1].perks[6].isability = true;
		itemtypes[1].perks[6].picture = Resources.Load("shortswordability2") as Texture;
		itemtypes[1].perks[6].abilitycost =35;
		itemtypes[1].perks[6].abilitycooldownmax =10;
		itemtypes[1].perks[6].abilitycooldowncurrent =10;
		
		itemtypes[1].perks[7].perkname = "Critical Cutlass";
		itemtypes[1].perks[7].perkdescription = "Inceases critical chance with shortswords";
		itemtypes[1].perks[7].bonuscriticalchance =.06m;
		itemtypes[1].perks[7].maxlevel =3;
		itemtypes[1].perks[7].isability = false;
	
		itemtypes[1].perks[8].perkname = "Protective Cutlass";
		itemtypes[1].perks[8].perkdescription = "Increases shield with shortswords";
		itemtypes[1].perks[8].bonusshield =.06m;
		itemtypes[1].perks[8].maxlevel =3;
		itemtypes[1].perks[8].isability = false;
		
		itemtypes[1].perks[9].perkname = "Dose of Damage";
		itemtypes[1].perks[9].perkdescription = "x4 damage for 5 seconds";
		itemtypes[1].perks[9].maxlevel =1;
		itemtypes[1].perks[9].isability = true;
		itemtypes[1].perks[9].picture = Resources.Load("shortswordability3") as Texture;
		itemtypes[1].perks[9].abilitycost =50;
		itemtypes[1].perks[9].abilitycooldownmax =20;
		itemtypes[1].perks[9].abilitycooldowncurrent =20;
		
		itemtypes[1].perks[10].perkname = "Consuming Cutlass";
		itemtypes[1].perks[10].perkdescription = "Increases health absorb with shortswords";
		itemtypes[1].perks[10].bonushealthabsorb =.06m;
		itemtypes[1].perks[10].maxlevel =3;
		itemtypes[1].perks[10].isability = false;
		
		itemtypes[1].perks[11].perkname = "Stunnning Cutlass";
		itemtypes[1].perks[11].perkdescription = "Increases stun chance with shortswords";
		itemtypes[1].perks[11].bonusstunchance =.06m;
		itemtypes[1].perks[11].maxlevel =3;
		itemtypes[1].perks[11].isability = false;
	
		itemtypes[1].perks[12].perkname = "Quicker Blade";
		itemtypes[1].perks[12].perkdescription = "Increases attack speed with shortswords";
		itemtypes[1].perks[12].bonusattackspeed =.2m;
		itemtypes[1].perks[12].maxlevel =3;
		itemtypes[1].perks[12].isability = false;
	
		itemtypes[1].perks[13].perkname = "Stunnning Blade";
		itemtypes[1].perks[13].perkdescription = "Increases stun chance with shortswords";
		itemtypes[1].perks[13].bonusstunchance =.2m;
		itemtypes[1].perks[13].maxlevel =3;
		itemtypes[1].perks[13].isability = false;
		
		itemtypes[1].perks[14].perkname = "Absorbing Blade";
		itemtypes[1].perks[14].perkdescription = "Increases health absorb with shortswords";
		itemtypes[1].perks[14].bonushealthabsorb =.2m;
		itemtypes[1].perks[14].maxlevel =3;
		itemtypes[1].perks[14].isability = false;
		
		itemtypes[1].perks[15].perkname = "Deadly Dash";
		itemtypes[1].perks[15].perkdescription = "Sprint forward with your shortsword dealing 8x damage to anything in the way";
		itemtypes[1].perks[15].maxlevel =1;
		itemtypes[1].perks[15].isability = true;
		itemtypes[1].perks[15].picture = Resources.Load("shortswordability4") as Texture;
		itemtypes[1].perks[15].abilitycost =75;
		itemtypes[1].perks[15].abilitycooldownmax =20;
		itemtypes[1].perks[15].abilitycooldowncurrent =20;

		itemtypes[2].perks[0].perkname = "Consume";
		itemtypes[2].perks[0].perkdescription = "A heavy attack dealing 2x damage to return as health";
		itemtypes[2].perks[0].picture = Resources.Load("bluntability1") as Texture;
		itemtypes[2].perks[0].currentlevel =0;
		itemtypes[2].perks[0].maxlevel =1;
		itemtypes[2].perks[0].abilitycost =20;
		itemtypes[2].perks[0].abilitycooldownmax =5;
		itemtypes[2].perks[0].abilitycooldowncurrent =5;
		itemtypes[2].perks[0].isability = true;
		
		itemtypes[2].perks[1].perkname = "Heavy Club";
		itemtypes[2].perks[1].perkdescription = "Increases damage with blunts";
		itemtypes[2].perks[1].bonusdamage =.05m;
		itemtypes[2].perks[1].maxlevel =3;
		itemtypes[2].perks[1].isability = false;
		
		itemtypes[2].perks[2].perkname = "Deadly Club";
		itemtypes[2].perks[2].perkdescription = "Increases critical chance with blunts";
		itemtypes[2].perks[2].bonuscriticalchance =.05m;
		itemtypes[2].perks[2].maxlevel =3;
		itemtypes[2].perks[2].isability = false;
	
		itemtypes[2].perks[3].perkname = "Bloody Club";
		itemtypes[2].perks[3].perkdescription = "Increases bleeding chance with blunts";
		itemtypes[2].perks[3].bonusbleeddamagechance= .05m;
		itemtypes[2].perks[3].maxlevel =3;
		itemtypes[2].perks[3].isability = false;
		
		itemtypes[2].perks[4].perkname = "Healthy Hammer";
		itemtypes[2].perks[4].perkdescription = "Inceases health with blunts";
		itemtypes[2].perks[4].bonushealth =.03m;
		itemtypes[2].perks[4].maxlevel =3;
		itemtypes[2].perks[4].isability = false;
	
		itemtypes[2].perks[5].perkname = "Quick Hammer";
		itemtypes[2].perks[5].perkdescription = "Inceases attack speed with blunts";
		itemtypes[2].perks[5].bonusattackspeed =.03m;
		itemtypes[2].perks[5].maxlevel =3;
		itemtypes[2].perks[5].isability = false;
	
		itemtypes[2].perks[6].perkname = "Speedy Conusme";
		itemtypes[2].perks[6].perkdescription = "2x attack speed for 5 seconds, aborbing 1/2 of all damage";
		itemtypes[2].perks[6].maxlevel =1;
		itemtypes[2].perks[6].isability = true;
		itemtypes[2].perks[6].picture = Resources.Load("bluntability2") as Texture;
		itemtypes[2].perks[6].abilitycost =35;
		itemtypes[2].perks[6].abilitycooldownmax =10;
		itemtypes[2].perks[6].abilitycooldowncurrent =10;
		
		itemtypes[2].perks[7].perkname = "Armored Stick";
		itemtypes[2].perks[7].perkdescription = "Inceases armor with blunts";
		itemtypes[2].perks[7].bonusarmor =.06m;
		itemtypes[2].perks[7].maxlevel =3;
		itemtypes[2].perks[7].isability = false;
		
		itemtypes[2].perks[8].perkname = "Protective Stick";
		itemtypes[2].perks[8].perkdescription = "Increases shield with blunts";
		itemtypes[2].perks[8].bonusshield =.06m;
		itemtypes[2].perks[8].maxlevel =3;
		itemtypes[2].perks[8].isability = false;
	
		itemtypes[2].perks[9].perkname = "Downward Crush";
		itemtypes[2].perks[9].perkdescription = "Jump into the air and slam into the ground with your weapon first for 5x damage";
		itemtypes[2].perks[9].maxlevel =1;
		itemtypes[2].perks[9].isability = true;
		itemtypes[2].perks[9].picture = Resources.Load("bluntability3") as Texture;
		itemtypes[2].perks[9].abilitycost =50;
		itemtypes[2].perks[9].abilitycooldownmax =20;
		itemtypes[2].perks[9].abilitycooldowncurrent =20;
	
		itemtypes[2].perks[10].perkname = "Heavy Stick";
		itemtypes[2].perks[10].perkdescription = "Increases damage with shortswords";
		itemtypes[2].perks[10].bonusdamage =.06m;
		itemtypes[2].perks[10].maxlevel =3;
		itemtypes[2].perks[10].isability = false;
		
		itemtypes[2].perks[11].perkname = "Energized Stick";
		itemtypes[2].perks[11].perkdescription = "Increases adrenaline with blunts";
		itemtypes[2].perks[11].bonusadrenaline =.06m;
		itemtypes[2].perks[11].maxlevel =3;
		itemtypes[2].perks[11].isability = false;
		
		itemtypes[2].perks[12].perkname = "Heavier Club";
		itemtypes[2].perks[12].perkdescription = "Increases damage with blunts";
		itemtypes[2].perks[12].bonusdamage =.2m;
		itemtypes[2].perks[12].maxlevel =3;
		itemtypes[2].perks[12].isability = false;
		
		itemtypes[2].perks[13].perkname = "Deadlier Club";
		itemtypes[2].perks[13].perkdescription = "Increases critical chance with blunts";
		itemtypes[2].perks[13].bonuscriticalchance =.2m;
		itemtypes[2].perks[13].maxlevel =3;
		itemtypes[2].perks[13].isability = false;
		
		itemtypes[2].perks[14].perkname = "Bloodier Club";
		itemtypes[2].perks[14].perkdescription = "Increases bleeding chance with blunts";
		itemtypes[2].perks[14].bonusbleeddamage =.2m;
		itemtypes[2].perks[14].maxlevel =3;
		itemtypes[2].perks[14].isability = false;
		
		itemtypes[2].perks[15].perkname = "Critical Chances";
		itemtypes[2].perks[15].perkdescription = "For 10 seconds each attack landed is a critical hit";
		itemtypes[2].perks[15].maxlevel =1;
		itemtypes[2].perks[15].isability = true;
		itemtypes[2].perks[15].picture = Resources.Load("bluntability4") as Texture;
		itemtypes[2].perks[15].abilitycost =75;
		itemtypes[2].perks[15].abilitycooldownmax =20;
		itemtypes[2].perks[15].abilitycooldowncurrent =20;
	
		itemtypes[3].perks[0].perkname = "Bleeding Slice";
		itemtypes[3].perks[0].perkdescription = "An attack for 2x bleed damage";
		itemtypes[3].perks[0].picture = Resources.Load("daggerability1") as Texture;
		itemtypes[3].perks[0].currentlevel =0;
		itemtypes[3].perks[0].maxlevel =1;
		itemtypes[3].perks[0].abilitycost =20;
		itemtypes[3].perks[0].abilitycooldownmax =5;
		itemtypes[3].perks[0].abilitycooldowncurrent =5;
		itemtypes[3].perks[0].isability = true;
		
		itemtypes[3].perks[1].perkname = "Strong Shank";
		itemtypes[3].perks[1].perkdescription = "Increases damage with daggers";
		itemtypes[3].perks[1].bonusdamage =.05m;
		itemtypes[3].perks[1].maxlevel =3;
		itemtypes[3].perks[1].isability = false;
		
		itemtypes[3].perks[2].perkname = "Deadly Shank";
		itemtypes[3].perks[2].perkdescription = "Increases critical chance with daggers";
		itemtypes[3].perks[2].bonuscriticalchance =.05m;
		itemtypes[3].perks[2].maxlevel =3;
		itemtypes[3].perks[2].isability = false;
		
		itemtypes[3].perks[3].perkname = "Quick Shank";
		itemtypes[3].perks[3].perkdescription = "Increases attack speed with daggers";
		itemtypes[3].perks[3].bonusattackspeed= .05m;
		itemtypes[3].perks[3].maxlevel =3;
		itemtypes[3].perks[3].isability = false;
		
		itemtypes[3].perks[4].perkname = "Speedy Dirk";
		itemtypes[3].perks[4].perkdescription = "Inceases attack speed with daggers";
		itemtypes[3].perks[4].bonusattackspeed =.03m;
		itemtypes[3].perks[4].maxlevel =3;
		itemtypes[3].perks[4].isability = false;
		
		itemtypes[3].perks[5].perkname = "Bloody Dirk";
		itemtypes[3].perks[5].perkdescription = "Inceases bleeding damage chance with daggers";
		itemtypes[3].perks[5].bonusbleeddamage=.03m;
		itemtypes[3].perks[5].maxlevel =3;
		itemtypes[3].perks[5].isability = false;
		
		itemtypes[3].perks[6].perkname = "Dose of Damage";
		itemtypes[3].perks[6].perkdescription = "x4 damage for 5 seconds";
		itemtypes[3].perks[6].maxlevel =1;
		itemtypes[3].perks[6].isability = true;
		itemtypes[3].perks[6].picture = Resources.Load("daggerability2") as Texture;
		itemtypes[3].perks[6].abilitycost =35;
		itemtypes[3].perks[6].abilitycooldownmax =10;
		itemtypes[3].perks[6].abilitycooldowncurrent =10;
		
		itemtypes[3].perks[7].perkname = "Stunning Blade";
		itemtypes[3].perks[7].perkdescription = "Inceases stun chance with daggers";
		itemtypes[3].perks[7].bonusstunchance =.06m;
		itemtypes[3].perks[7].maxlevel =3;
		itemtypes[3].perks[7].isability = false;
		
		itemtypes[3].perks[8].perkname = "Energizing Blade";
		itemtypes[3].perks[8].perkdescription = "Increases adrenaline rate with daggers";
		itemtypes[3].perks[8].bonusadrenaline =.06m;
		itemtypes[3].perks[8].maxlevel =3;
		itemtypes[3].perks[8].isability = false;
		
		itemtypes[3].perks[9].perkname = "Burst of Speed";
		itemtypes[3].perks[9].perkdescription = "2x attack speed for 5 seconds";
		itemtypes[3].perks[9].maxlevel =1;
		itemtypes[3].perks[9].isability = true;
		itemtypes[3].perks[9].picture = Resources.Load("daggerability3") as Texture;
		itemtypes[3].perks[9].abilitycost =50;
		itemtypes[3].perks[9].abilitycooldownmax =20;
		itemtypes[3].perks[9].abilitycooldowncurrent =20;
		
		itemtypes[3].perks[10].perkname = "Critical Blade";
		itemtypes[3].perks[10].perkdescription = "Increases critical chance with daggers";
		itemtypes[3].perks[10].bonuscriticalchance =.06m;
		itemtypes[3].perks[10].maxlevel =3;
		itemtypes[3].perks[10].isability = false;
		
		itemtypes[3].perks[11].perkname = "Bloody Blade";
		itemtypes[3].perks[11].perkdescription = "Increases bleeding chance with daggers";
		itemtypes[3].perks[11].bonusbleeddamage =.06m;
		itemtypes[3].perks[11].maxlevel =3;
		itemtypes[3].perks[11].isability = false;
		
		itemtypes[3].perks[12].perkname = "Stronger Shank";
		itemtypes[3].perks[12].perkdescription = "Increases damage with daggers";
		itemtypes[3].perks[12].bonusdamage =.2m;
		itemtypes[3].perks[12].maxlevel =3;
		itemtypes[3].perks[12].isability = false;
		
		itemtypes[3].perks[13].perkname = "Deadlier Shank";
		itemtypes[3].perks[13].perkdescription = "Increases critical chance with daggers";
		itemtypes[3].perks[13].bonuscriticalchance =.2m;
		itemtypes[3].perks[13].maxlevel =3;
		itemtypes[3].perks[13].isability = false;
		
		itemtypes[3].perks[14].perkname = "Quicker Shank";
		itemtypes[3].perks[14].perkdescription = "Increases attack speed with daggers";
		itemtypes[3].perks[14].bonusattackspeed =.2m;
		itemtypes[3].perks[14].maxlevel =3;
		itemtypes[3].perks[14].isability = false;
		
		itemtypes[3].perks[15].perkname = "Shank Storm";
		itemtypes[3].perks[15].perkdescription = "Slice 6 times dealing x2 damage with each hit";
		itemtypes[3].perks[15].maxlevel =1;
		itemtypes[3].perks[15].isability = true;
		itemtypes[3].perks[15].picture = Resources.Load("daggerability4") as Texture;
		itemtypes[3].perks[15].abilitycost =75;
		itemtypes[3].perks[15].abilitycooldownmax =20;
		itemtypes[3].perks[15].abilitycooldowncurrent =20;
	
		itemtypes[4].perks[0].perkname = "Annihilating Chop";
		itemtypes[4].perks[0].perkdescription = "An overhead chop dealing x4 damage";
		itemtypes[4].perks[0].picture = Resources.Load("axeability1") as Texture;
		itemtypes[4].perks[0].currentlevel =0;
		itemtypes[4].perks[0].maxlevel =1;
		itemtypes[4].perks[0].abilitycost =20;
		itemtypes[4].perks[0].abilitycooldownmax =5;
		itemtypes[4].perks[0].abilitycooldowncurrent =5;
		itemtypes[4].perks[0].isability = true;
		
		itemtypes[4].perks[1].perkname = "Strong Hatchet";
		itemtypes[4].perks[1].perkdescription = "Increases damage with axes";
		itemtypes[4].perks[1].bonusdamage =.05m;
		itemtypes[4].perks[1].maxlevel =3;
		itemtypes[4].perks[1].isability = false;
		
		itemtypes[4].perks[2].perkname = "Heatlhy Hatchet";
		itemtypes[4].perks[2].perkdescription = "Increases health with axes";
		itemtypes[4].perks[2].bonuscriticalchance =.05m;
		itemtypes[4].perks[2].maxlevel =3;
		itemtypes[4].perks[2].isability = false;
		
		itemtypes[4].perks[3].perkname = "Bloody Hatchet";
		itemtypes[4].perks[3].perkdescription = "Increases bleeding damage chance with axes";
		itemtypes[4].perks[3].bonusbleeddamage= .05m;
		itemtypes[4].perks[3].maxlevel =3;
		itemtypes[4].perks[3].isability = false;
		
		itemtypes[4].perks[4].perkname = "Protective Tomahawk";
		itemtypes[4].perks[4].perkdescription = "Inceases shiled with axes";
		itemtypes[4].perks[4].bonusshield =.03m;
		itemtypes[4].perks[4].maxlevel =3;
		itemtypes[4].perks[4].isability = false;
		
		itemtypes[4].perks[5].perkname = "Stunning Tomahawk";
		itemtypes[4].perks[5].perkdescription = "Inceases stun chance with axes";
		itemtypes[4].perks[5].bonusstunchance =.03m;
		itemtypes[4].perks[5].maxlevel =3;
		itemtypes[4].perks[5].isability = false;
		
		itemtypes[4].perks[6].perkname = "Shield Recharge";
		itemtypes[4].perks[6].perkdescription = "Instantly refills your shield";
		itemtypes[4].perks[6].maxlevel =1;
		itemtypes[4].perks[6].isability = true;
		itemtypes[4].perks[6].picture = Resources.Load("axeability2") as Texture;
		itemtypes[4].perks[6].abilitycost =35;
		itemtypes[4].perks[6].abilitycooldownmax =10;
		itemtypes[4].perks[6].abilitycooldowncurrent =10;
		
		itemtypes[4].perks[7].perkname = "Armored Axe";
		itemtypes[4].perks[7].perkdescription = "Inceases armor with axes";
		itemtypes[4].perks[7].bonusarmor =.06m;
		itemtypes[4].perks[7].maxlevel =3;
		itemtypes[4].perks[7].isability = false;
		
		itemtypes[4].perks[8].perkname = "Healthy Axe";
		itemtypes[4].perks[8].perkdescription = "Increases health with axes";
		itemtypes[4].perks[8].bonushealth =.06m;
		itemtypes[4].perks[8].maxlevel =3;
		itemtypes[4].perks[8].isability = false;
		
		itemtypes[4].perks[9].perkname = "Bloody Uppercut";
		itemtypes[4].perks[9].perkdescription = "An uppercut that causes bleed damage and stuns the enemy";
		itemtypes[4].perks[9].maxlevel =1;
		itemtypes[4].perks[9].isability = true;
		itemtypes[4].perks[9].picture = Resources.Load("axeability3") as Texture;
		itemtypes[4].perks[9].abilitycost =50;
		itemtypes[4].perks[9].abilitycooldownmax =20;
		itemtypes[4].perks[9].abilitycooldowncurrent =20;
		
		itemtypes[4].perks[10].perkname = "Strong Axe";
		itemtypes[4].perks[10].perkdescription = "Increases damage with axes";
		itemtypes[4].perks[10].bonusdamage =.06m;
		itemtypes[4].perks[10].maxlevel =3;
		itemtypes[4].perks[10].isability = false;
	
		itemtypes[4].perks[11].perkname = "Critical Axe";
		itemtypes[4].perks[11].perkdescription = "Increases critical chance with axes";
		itemtypes[4].perks[11].bonuscriticalchance =.06m;
		itemtypes[4].perks[11].maxlevel =3;
		itemtypes[4].perks[11].isability = false;
	
		itemtypes[4].perks[12].perkname = "Stronger Hatchet";
		itemtypes[4].perks[12].perkdescription = "Increases damage with axes";
		itemtypes[4].perks[12].bonusdamage =.2m;
		itemtypes[4].perks[12].maxlevel =3;
		itemtypes[4].perks[12].isability = false;
	
		itemtypes[4].perks[13].perkname = "Healthier Hatchet";
		itemtypes[4].perks[13].perkdescription = "Increases health with axes";
		itemtypes[4].perks[13].bonushealth =.2m;
		itemtypes[4].perks[13].maxlevel =3;
		itemtypes[4].perks[13].isability = false;
		
		itemtypes[4].perks[14].perkname = "Bloodier Hathcet";
		itemtypes[4].perks[14].perkdescription = "Increases bleeding damage chance with axes";
		itemtypes[4].perks[14].bonusbleeddamage =.2m;
		itemtypes[4].perks[14].maxlevel =3;
		itemtypes[4].perks[14].isability = false;
		
		itemtypes[4].perks[15].perkname = "Total Regeneration";
		itemtypes[4].perks[15].perkdescription = "Rapidly regenerate health for 5 seconds";
		itemtypes[4].perks[15].maxlevel =1;
		itemtypes[4].perks[15].isability = true;
		itemtypes[4].perks[15].picture = Resources.Load("axeability4") as Texture;
		itemtypes[4].perks[15].abilitycost =75;
		itemtypes[4].perks[15].abilitycooldownmax =20;
		itemtypes[4].perks[15].abilitycooldowncurrent =20;

		
		itemtypes[5].perks[0].perkname = "Devastatiing Slash";
		itemtypes[5].perks[0].perkdescription = "A slash that deals x6 damage";
		itemtypes[5].perks[0].picture = Resources.Load("longswordability1") as Texture;
		itemtypes[5].perks[0].currentlevel =0;
		itemtypes[5].perks[0].maxlevel =1;
		itemtypes[5].perks[0].abilitycost =20;
		itemtypes[5].perks[0].abilitycooldownmax =5;
		itemtypes[5].perks[0].abilitycooldowncurrent =5;
		itemtypes[5].perks[0].isability = true;
		
		itemtypes[5].perks[1].perkname = "Strong Blade";
		itemtypes[5].perks[1].perkdescription = "Increases damage with longswords";
		itemtypes[5].perks[1].bonusdamage =.05m;
		itemtypes[5].perks[1].maxlevel =3;
		itemtypes[5].perks[1].isability = false;
		
		itemtypes[5].perks[2].perkname = "Bloody Blade";
		itemtypes[5].perks[2].perkdescription = "Increases bleeding damage chance with longswords";
		itemtypes[5].perks[2].bonusbleeddamage =.05m;
		itemtypes[5].perks[2].maxlevel =3;
		itemtypes[5].perks[2].isability = false;
	
		itemtypes[5].perks[3].perkname = "Critical Blade";
		itemtypes[5].perks[3].perkdescription = "Increases critical chance with longswords";
		itemtypes[5].perks[3].bonuscriticalchance= .05m;
		itemtypes[5].perks[3].maxlevel =3;
		itemtypes[5].perks[3].isability = false;
		
		itemtypes[5].perks[4].perkname = "Strong Cutlass";
		itemtypes[5].perks[4].perkdescription = "Inceases damage with longswords";
		itemtypes[5].perks[4].bonusdamage =.03m;
		itemtypes[5].perks[4].maxlevel =3;
		itemtypes[5].perks[4].isability = false;
		
		itemtypes[5].perks[5].perkname = "Absorbing Cutlass";
		itemtypes[5].perks[5].perkdescription = "Inceases health absorb with longswords";
		itemtypes[5].perks[5].bonushealthabsorb =.03m;
		itemtypes[5].perks[5].maxlevel =3;
		itemtypes[5].perks[5].isability = false;
	
		itemtypes[5].perks[6].perkname = "Burst of Speed";
		itemtypes[5].perks[6].perkdescription = "x2 attack speed for 5 seconds";
		itemtypes[5].perks[6].maxlevel =1;
		itemtypes[5].perks[6].isability = true;
		itemtypes[5].perks[6].picture = Resources.Load("longswordability2") as Texture;
		itemtypes[5].perks[6].abilitycost =35;
		itemtypes[5].perks[6].abilitycooldownmax =10;
		itemtypes[5].perks[6].abilitycooldowncurrent =10;
		
		itemtypes[5].perks[7].perkname = "Bloody Rapier";
		itemtypes[5].perks[7].perkdescription = "Inceases bleeding damage chance with longswords";
		itemtypes[5].perks[7].bonusbleeddamage =.06m;
		itemtypes[5].perks[7].maxlevel =3;
		itemtypes[5].perks[7].isability = false;
		
		itemtypes[5].perks[8].perkname = "Strong Rapier";
		itemtypes[5].perks[8].perkdescription = "Increases damage with longswords";
		itemtypes[5].perks[8].bonusdamage =.06m;
		itemtypes[5].perks[8].maxlevel =3;
		itemtypes[5].perks[8].isability = false;
		
		itemtypes[5].perks[9].perkname = "Damage Resistor";
		itemtypes[5].perks[9].perkdescription = "Ignore all damage for 5 seconds";
		itemtypes[5].perks[9].maxlevel =1;
		itemtypes[5].perks[9].isability = true;
		itemtypes[5].perks[9].picture = Resources.Load("longswordability3") as Texture;
		itemtypes[5].perks[9].abilitycost =50;
		itemtypes[5].perks[9].abilitycooldownmax =20;
		itemtypes[5].perks[9].abilitycooldowncurrent =20;
	
		itemtypes[5].perks[10].perkname = "Speedy Rapier";
		itemtypes[5].perks[10].perkdescription = "Increases attack speed with longswords";
		itemtypes[5].perks[10].bonusattackspeed =.06m;
		itemtypes[5].perks[10].maxlevel =3;
		itemtypes[5].perks[10].isability = false;
	
		itemtypes[5].perks[11].perkname = "Energetic Rapier";
		itemtypes[5].perks[11].perkdescription = "Increases adrenaline rate with longswords";
		itemtypes[5].perks[11].bonusadrenaline =.06m;
		itemtypes[5].perks[11].maxlevel =3;
		itemtypes[5].perks[11].isability = false;
		
		itemtypes[5].perks[12].perkname = "Stronger Blade";
		itemtypes[5].perks[12].perkdescription = "Increases damage with longswords";
		itemtypes[5].perks[12].bonusdamage =.2m;
		itemtypes[5].perks[12].maxlevel =3;
		itemtypes[5].perks[12].isability = false;
		
		itemtypes[5].perks[13].perkname = "Bloodier Blade";
		itemtypes[5].perks[13].perkdescription = "Increases bleeding damage chance with longswords";
		itemtypes[5].perks[13].bonusbleeddamage =.2m;
		itemtypes[5].perks[13].maxlevel =3;
		itemtypes[5].perks[13].isability = false;
		
		itemtypes[5].perks[14].perkname = "Critical Blade";
		itemtypes[5].perks[14].perkdescription = "Increases critical chance with longswords";
		itemtypes[5].perks[14].bonuscriticalchance =.2m;
		itemtypes[5].perks[14].maxlevel =3;
		itemtypes[5].perks[14].isability = false;
	
		itemtypes[5].perks[15].perkname = "Earthquake";
		itemtypes[5].perks[15].perkdescription = "Smash your sword into the ground dealing x5 damage and stun to all enemies nearby";
		itemtypes[5].perks[15].maxlevel =1;
		itemtypes[5].perks[15].isability = true;
		itemtypes[5].perks[15].picture = Resources.Load("longswordability4") as Texture;
		itemtypes[5].perks[15].abilitycost =75;
		itemtypes[5].perks[15].abilitycooldownmax =20;
		itemtypes[5].perks[15].abilitycooldowncurrent =20;

		itemtypes[1].xptolevel = 500;
		itemtypes[1].currentxp = 0;
		itemtypes[1].overallxp = 0;
		itemtypes[1].currentlevel = 1;
		itemtypes[1].name = "Shortsword";
		itemtypes[1].animationlength = .8f;
		itemtypes[1].bonusattackspeed = 0;
		itemtypes[1].bonusdamage = 0;
		itemtypes[1].bonushealth = .8m;
		itemtypes[1].bonusshield = 0;
		itemtypes[1].bonusadrenaline= 0;
		itemtypes[1].bonusarmor = 0;
		itemtypes[1].bonusbleeddamage = 0;
		itemtypes[1].bonuscriticalchance = 0;
		itemtypes[1].bonushealthabsorb= 0;
		itemtypes[1].bonusstunchance = 0;
		itemtypes[1].animatorname = "Cylinder";
		itemtypes[1].isgun = false;


		itemtypes[2].xptolevel = 500;
		itemtypes[2].currentxp = 0;
		itemtypes[2].overallxp = 0;
		itemtypes[2].currentlevel = 1;
		itemtypes[2].name = "Blunt";
		itemtypes[2].animationlength = .8f;
		itemtypes[2].bonusattackspeed = 0;
		itemtypes[2].bonusdamage = 0;
		itemtypes[2].bonushealth = 0;
		itemtypes[2].bonusshield = 0;
		itemtypes[2].bonusadrenaline= 0;
		itemtypes[2].bonusarmor = 0;
		itemtypes[2].bonusbleeddamage = 0;
		itemtypes[2].bonuscriticalchance = 0;
		itemtypes[2].bonushealthabsorb= 0;
		itemtypes[2].bonusstunchance = 0;
		itemtypes[2].animatorname = "Cube";
		itemtypes[2].isgun = false;

		itemtypes[3].xptolevel = 500;
		itemtypes[3].currentxp = 0;
		itemtypes[3].overallxp = 0;
		itemtypes[3].currentlevel = 1;
		itemtypes[3].name = "Dagger";
		itemtypes[3].animationlength = .8f;
		itemtypes[3].bonusattackspeed = 0;
		itemtypes[3].bonusdamage = 0;
		itemtypes[3].bonushealth = 0;
		itemtypes[3].bonusshield = 0;
		itemtypes[3].bonusadrenaline= 0;
		itemtypes[3].bonusarmor = 0;
		itemtypes[3].bonusbleeddamage = 0;
		itemtypes[3].bonuscriticalchance = 0;
		itemtypes[3].bonushealthabsorb= 0;
		itemtypes[3].bonusstunchance = 0;
		itemtypes[3].animatorname = "Cube";
		itemtypes[3].isgun = false;

		itemtypes[4].xptolevel = 500;
		itemtypes[4].currentxp = 0;
		itemtypes[4].overallxp = 0;
		itemtypes[4].currentlevel = 1;
		itemtypes[4].name = "Axe";
		itemtypes[4].animationlength = .8f;
		itemtypes[4].bonusattackspeed = 0;
		itemtypes[4].bonusdamage = 0;
		itemtypes[4].bonushealth = 0;
		itemtypes[4].bonusshield = 0;
		itemtypes[4].bonusadrenaline= 0;
		itemtypes[4].bonusarmor = 0;
		itemtypes[4].bonusbleeddamage = 0;
		itemtypes[4].bonuscriticalchance = 0;
		itemtypes[4].bonushealthabsorb= 0;
		itemtypes[4].bonusstunchance = 0;
		itemtypes[4].animatorname = "Cube";
		itemtypes[4].isgun = false;

		itemtypes[5].xptolevel = 500;
		itemtypes[5].currentxp = 0;
		itemtypes[5].overallxp = 0;
		itemtypes[5].currentlevel = 1;
		itemtypes[5].name = "Longsword";
		itemtypes[5].animationlength = .8f;
		itemtypes[5].bonusattackspeed = 0;
		itemtypes[5].bonusdamage = 0;
		itemtypes[5].bonushealth = 0;
		itemtypes[5].bonusshield = 0;
		itemtypes[5].bonusadrenaline= 0;
		itemtypes[5].bonusarmor = 0;
		itemtypes[5].bonusbleeddamage = 0;
		itemtypes[5].bonuscriticalchance = 0;
		itemtypes[5].bonushealthabsorb= 0;
		itemtypes[5].bonusstunchance = 0;
		itemtypes[5].animatorname = "Cube_002";
		itemtypes[5].isgun = false;

	

		for(int i = 0;i<6;i++){
			itemtypes[i].perks[0].xmod = 0;
			itemtypes[i].perks[0].ymod = 0;
			itemtypes[i].perks[1].xmod = -2;
			itemtypes[i].perks[1].ymod = -1;
			itemtypes[i].perks[2].xmod = 0;
			itemtypes[i].perks[2].ymod = -1;
			itemtypes[i].perks[3].xmod = 2;
			itemtypes[i].perks[3].ymod = -1;
			itemtypes[i].perks[4].xmod = -1;
			itemtypes[i].perks[4].ymod = -2;
			itemtypes[i].perks[5].xmod = 1;
			itemtypes[i].perks[5].ymod = -2;
			itemtypes[i].perks[6].xmod = 0;
			itemtypes[i].perks[6].ymod = -3;
			itemtypes[i].perks[7].xmod = -1;
			itemtypes[i].perks[7].ymod = -4;
			itemtypes[i].perks[8].xmod = 1;
			itemtypes[i].perks[8].ymod = -4;
			itemtypes[i].perks[9].xmod = 0;
			itemtypes[i].perks[9].ymod = -5;
			itemtypes[i].perks[10].xmod = -1;
			itemtypes[i].perks[10].ymod = -6;
			itemtypes[i].perks[11].xmod = 1;
			itemtypes[i].perks[11].ymod = -6;
			itemtypes[i].perks[12].xmod = -2;
			itemtypes[i].perks[12].ymod = -7;
			itemtypes[i].perks[13].xmod = 0;
			itemtypes[i].perks[13].ymod = -7;
			itemtypes[i].perks[14].xmod = 2;
			itemtypes[i].perks[14].ymod = -7;
			itemtypes[i].perks[15].xmod = 0;
			itemtypes[i].perks[15].ymod = -8;
			
			
		}



		weapons[1].attackspeedmodifyer = 2;
		weapons[1].damagemodifyer = 1.2m;
		weapons[1].healthmodifyer = 0;
		weapons[1].shieldmodifyer = 0;
		weapons[1].adrenalinemodifyer = 0;
		weapons[1].armormodifyer = 0;
		weapons[1].bleeddamagechancemodifyer = 1;
		weapons[1].bleeddamagemodifyer = 0;
		weapons[1].criticalchancemodifyer = 0;
		weapons[1].healthabsorbmodifyer = 0;
		weapons[1].stunchancemodifyer = 0;
		weapons[1].itemtype = itemtypes[3].name;
		weapons[1].name = "Dull Dagger";
		weapons[1].animatorname = "Cube";

		weapons[2].attackspeedmodifyer = 1;
		weapons[2].damagemodifyer = 2m;
		weapons[2].healthmodifyer = 4;
		weapons[2].shieldmodifyer = 4;
		weapons[2].adrenalinemodifyer = 0;
		weapons[2].armormodifyer = 0;
		weapons[2].bleeddamagechancemodifyer = 0;
		weapons[2].bleeddamagemodifyer = 0;
		weapons[2].criticalchancemodifyer = .4m;
		weapons[2].healthabsorbmodifyer = 0;
		weapons[2].stunchancemodifyer = 0;
		weapons[2].itemtype = itemtypes[1].name;
		weapons[2].name = "Conditioned Cutlass";
		weapons[2].animatorname = "Cylinder";

		weapons[3].attackspeedmodifyer = 1;
		weapons[3].damagemodifyer = 1;
		weapons[3].healthmodifyer = 0;
		weapons[3].shieldmodifyer = 0;
		weapons[3].adrenalinemodifyer = 0;
		weapons[3].armormodifyer = 0;
		weapons[3].bleeddamagechancemodifyer = 0;
		weapons[3].bleeddamagemodifyer = 0;
		weapons[3].criticalchancemodifyer = 0;
		weapons[3].healthabsorbmodifyer = 0;
		weapons[3].stunchancemodifyer =1;
		weapons[3].itemtype = itemtypes[2].name;
		weapons[3].name = "Cracked Warhammer";
		weapons[3].animatorname ="Cube";

		weapons[4].attackspeedmodifyer = .4m;
		weapons[4].damagemodifyer = 2;
		weapons[4].healthmodifyer = .8m;
		weapons[4].shieldmodifyer = 0;
		weapons[4].adrenalinemodifyer = 0;
		weapons[4].armormodifyer = 0;
		weapons[4].bleeddamagechancemodifyer = 0;
		weapons[4].bleeddamagemodifyer = 0;
		weapons[4].criticalchancemodifyer = 0;
		weapons[4].healthabsorbmodifyer = 0;
		weapons[4].stunchancemodifyer =1;
		weapons[4].itemtype = itemtypes[4].name;
		weapons[4].name = "Worn Axe";
		weapons[4].animatorname ="Cube";

		weapons[0].attackspeedmodifyer = .3m;
		weapons[0].damagemodifyer = 3;
		weapons[0].healthmodifyer = 0;
		weapons[0].shieldmodifyer = 0;
		weapons[0].adrenalinemodifyer = 0;
		weapons[0].armormodifyer = 0;
		weapons[0].bleeddamagechancemodifyer = 0;
		weapons[0].bleeddamagemodifyer = 0;
		weapons[0].criticalchancemodifyer = 0;
		weapons[0].healthabsorbmodifyer = 1;
		weapons[0].stunchancemodifyer =1;
		weapons[0].itemtype = itemtypes[5].name;
		weapons[0].name = "Lacking Longsword";
		weapons[0].animatorname ="Cube_002";

		enemies[0].attackspeedmodifyer = 1;
		enemies[0].damagemodifyer = 1;
		enemies[0].healthmodifyer = 1;
		enemies[0].shieldmodifyer = 0;
		enemies[0].armormodifyer = 0;
		enemies[0].bleeddamagechancemodifyer = .1m;
		enemies[0].bleeddamagemodifyer = .1m;
		enemies[0].criticalchancemodifyer = 0;
		enemies[0].healthabsorbmodifyer = 0;
		enemies[0].stunchancemodifyer = 0;
		enemies[0].speed = 1;
		enemies[0].name = "Evil Cube";
		enemies[0].hasweapon = true;

		enemies[1].attackspeedmodifyer = 2;
		enemies[1].damagemodifyer = 1;
		enemies[1].healthmodifyer = .5m;
		enemies[1].shieldmodifyer = 0;
		enemies[1].armormodifyer = 0;
		enemies[1].bleeddamagechancemodifyer = .1m;
		enemies[1].bleeddamagemodifyer = .1m;
		enemies[1].criticalchancemodifyer = 0;
		enemies[1].healthabsorbmodifyer = 0;
		enemies[1].stunchancemodifyer = 0;
		enemies[1].speed = 1.5m;
		enemies[1].name = "Fast Cube";
		enemies[1].hasweapon = true;

		enemies[2].attackspeedmodifyer = 1;
		enemies[2].damagemodifyer = 3;
		enemies[2].healthmodifyer = 1.8m;
		enemies[2].shieldmodifyer = 0;
		enemies[2].armormodifyer = 0;
		enemies[2].bleeddamagechancemodifyer = .1m;
		enemies[2].bleeddamagemodifyer = .1m;
		enemies[2].criticalchancemodifyer = 0;
		enemies[2].healthabsorbmodifyer = 0;
		enemies[2].stunchancemodifyer = 0;
		enemies[2].speed = .7m;
		enemies[2].name = "Heavy Cube";
		enemies[2].hasweapon = true;

		enemies[3].attackspeedmodifyer = 3;
		enemies[3].damagemodifyer = 4;
		enemies[3].healthmodifyer = .6m;
		enemies[3].shieldmodifyer = 0;
		enemies[3].armormodifyer = 0;
		enemies[3].bleeddamagechancemodifyer = .1m;
		enemies[3].bleeddamagemodifyer = .1m;
		enemies[3].criticalchancemodifyer = 0;
		enemies[3].healthabsorbmodifyer = 0;
		enemies[3].stunchancemodifyer = 0;
		enemies[3].speed = 2m;
		enemies[3].name = "Deadly Cube";
		enemies[3].hasweapon = true;

		enemies[4].attackspeedmodifyer = 0;
		enemies[4].damagemodifyer = 2;
		enemies[4].healthmodifyer = .8m;
		enemies[4].shieldmodifyer = 0;
		enemies[4].armormodifyer = 0;
		enemies[4].bleeddamagechancemodifyer = 0;
		enemies[4].bleeddamagemodifyer = 0;
		enemies[4].criticalchancemodifyer = 0;
		enemies[4].healthabsorbmodifyer = 0;
		enemies[4].stunchancemodifyer = 0;
		enemies[4].speed = 1m;
		enemies[4].name = "Suicide Cube";
		enemies[4].hasweapon = false;

		player.xptolevel = 100;
		player.currentxp = 0;
		player.overallxp = 0;

		currentweapon.itemtype = itemtypes[0].name;
		currentweapontype = itemtypes[0];
		currentweapon.attackspeed = 0;
		currentweapon.damage = 1;
		currentweapon.health = 0;
		currentweapon.level = 0;
		currentweapon.name = "Hand";
		currentweapon.shield = 0;
		currentweapon.invslot = 20;

	}

	public struct Player{
		public int playerlevel;
		public int basehealth;
		public int baseshield;
		public int damage;
		public int attackspeed;
		public int shield;
		public int maxshield;
		public int shieldrecharge;
		public int adrenalinerate;
		public int adrenalinemax;
		public int adrenalinecurrent;
		public int bleeddamage;
		public decimal bleeddamagechance;
		public decimal stunchance;
		public decimal criticalchance;
		public decimal healthabsorb;
		public decimal armor;

		public int addedhealth;
		public int addedshield;

		public int xptolevel;
		public int currentxp;
		public int currenthealth;
		public int overallxp;
		public string[] nickname;

		public int totalkills;
		public int totaldeaths;
		public int totaldamage;

		public int totalprogress;
		public int storyprogress;
		public int challengeprogress;
		public int sidemissionprogress;

		public int overhealth;
		public int overdamage;
		public int overattackspeed;
		public int overshield;
	}
	public struct ItemType{
		public int xptolevel;
		public int currentxp;
		public int overallxp;
		public int currentlevel;
		public bool isgun;
		public string name;
		public decimal bonushealth;
		public decimal bonusdamage;
		public decimal bonusattackspeed;
		public decimal bonusshield;
		public decimal bonusadrenaline;
		public decimal bonusbleeddamage;
		public decimal bonusbleeddamagechance;
		public decimal bonusstunchance;
		public decimal bonuscriticalchance;
		public decimal bonushealthabsorb;
		public decimal bonusarmor;
		public float animationlength;
		public int perkpoints;
		public int perksbought;
		public Perk[] perks;
		public Challenge[] challenges;
		public int currentchallengescomplete;
		public string animatorname;
	}
	public struct Perk{
		public string perkname;
		public string perkdescription;
		public int currentlevel;
		public int maxlevel;
		public bool isability;
		public Texture picture;
		public int abilitycost;
		public int abilitycooldownmax;
		public int abilitycooldowncurrent;
		public decimal bonushealth;
		public decimal bonusdamage;
		public decimal bonusattackspeed;
		public decimal bonusshield;
		public decimal bonusadrenaline;
		public decimal bonusbleeddamage;
		public decimal bonusbleeddamagechance;
		public decimal bonusstunchance;
		public decimal bonuscriticalchance;
		public decimal bonushealthabsorb;
		public decimal bonusarmor;
		public int xmod;
		public int ymod;
	}
	public struct Item{
		public int health;
		public int damage;
		public int attackspeed;
		public int shield;
		public int adrenaline;
		public int bleeddamage;
		public decimal bleeddamagechance;
		public decimal stunchance;
		public decimal criticalchance;
		public decimal healthabsorb;
		public decimal armor;
		public string name;
		public string itemtype;
		public int level;
		public int invslot;
	}
	public struct Challenge{
		public string name;
		public string description;
		public int maxtier;
		public int currenttier;
		public int currentprogress;
		public int maxprogress;
		public string reward;
		public int xpreward;
		public bool iscomplete;
	}
	public struct Enemy{
		public decimal healthmodifyer;
		public decimal damagemodifyer;
		public decimal attackspeedmodifyer;
		public decimal shieldmodifyer;
		public decimal bleeddamagemodifyer;
		public decimal bleeddamagechancemodifyer;
		public decimal stunchancemodifyer;
		public decimal criticalchancemodifyer;
		public decimal healthabsorbmodifyer;
		public decimal armormodifyer;
		public decimal speed;
		public string name;
		public bool hasweapon;
	}
	public struct Act{
		public int sceneloader;
		public Texture picture;
		public string levelname;
		public int goldencubescurrent;
		public int goldencubesmax;
		public Level[] levels;
		public bool islocked;
	}
	public struct Level{
		public Texture picture;
		public int sceneloader;
		public string levelname;
		public int goldencubescurrent;
		public int goldencubesmax;
		public bool islocked;
		public bool completed;

	}
	public struct Weapon{
		public decimal healthmodifyer;
		public decimal damagemodifyer;
		public decimal attackspeedmodifyer;
		public decimal shieldmodifyer;
		public decimal adrenalinemodifyer;
		public decimal bleeddamagemodifyer;
		public decimal bleeddamagechancemodifyer;
		public decimal stunchancemodifyer;
		public decimal criticalchancemodifyer;
		public decimal healthabsorbmodifyer;
		public decimal armormodifyer;
		public string name;
		public string animatorname;
		public string itemtype;

	}
	public void sortinventory(){
		for(int i = 0; i<19;i++){
			if(Inventory[i].name == ""){
				Inventory[i].name = Inventory[i+1].name;
				Inventory[i].attackspeed = Inventory[i+1].attackspeed;
				Inventory[i].damage = Inventory[i+1].damage;
				Inventory[i].health = Inventory[i+1].health;
				Inventory[i].itemtype = Inventory[i+1].itemtype;
				Inventory[i].level = Inventory[i+1].level;
				Inventory[i].shield = Inventory[i+1].shield;
				Debug.Log(GameObject.Find("GameController").GetComponent<GUIscript>().playerweaponslot);
				if(GameObject.Find("GameController").GetComponent<GUIscript>().playerweaponslot == i){
					GameObject.Find("GameController").GetComponent<GUIscript>().playerweaponslot--;
				}
				Inventory[i+1].name = "";
				Inventory[i+1].attackspeed = 0;
				Inventory[i+1].damage = 0;
				Inventory[i+1].health = 0;
				Inventory[i+1].itemtype = "";
				Inventory[i+1].level = 0;
				Inventory[i+1].shield = 0;

			}
		}
	}
	public void spawnenemies(){
		int i = 1;
		int totalenemies;
		GameObject spawn;
		totalenemies = GameObject.FindGameObjectsWithTag("spawn").Length;
		do{
			int enemyi = 0;
			spawn =	GameObject.Find("Spawn" + i);
			if(spawn.GetComponent<enemyinfo>().enemyname == ""){
				enemyi =  Random.Range(0,enemies.Length);
				spawn.GetComponent<enemyinfo>().enemyname = enemies[enemyi].name;
			}else{
				for (int n = 0;n< enemies.Length;n++){
					if(enemies[n].name == spawn.GetComponent<enemyinfo>().enemyname){
						enemyi = n;
					}
				}
			}
			GameObject enemyobj = (GameObject)(Instantiate(Resources.Load(spawn.GetComponent<enemyinfo>().enemyname) ,spawn.transform.position, Quaternion.identity));

			if(spawn.GetComponent<enemyinfo>().enemylevel == -1){
				spawn.GetComponent<enemyinfo>().enemylevel = player.playerlevel;
			}
			if(spawn.GetComponent<enemyinfo>().enemyattackspeed == -1){
				spawn.GetComponent<enemyinfo>().enemyattackspeed = (int)(enemies[enemyi].attackspeedmodifyer*(Random.Range(1,(spawn.GetComponent<enemyinfo>().enemylevel/2))));
			}
			if(spawn.GetComponent<enemyinfo>().enemydamage == -1){
				spawn.GetComponent<enemyinfo>().enemydamage =(int)(enemies[enemyi].damagemodifyer* Random.Range(1,(spawn.GetComponent<enemyinfo>().enemylevel*spawn.GetComponent<enemyinfo>().enemylevel/2)));
			}	
			if(spawn.GetComponent<enemyinfo>().enemyhealth == -1){
				spawn.GetComponent<enemyinfo>().enemyhealth = (int)(enemies[enemyi].healthmodifyer *Random.Range(10,(spawn.GetComponent<enemyinfo>().enemylevel*spawn.GetComponent<enemyinfo>().enemylevel*10)));
			}
			if(spawn.GetComponent<enemyinfo>().enemyarmor == -1){
				spawn.GetComponent<enemyinfo>().enemyarmor = enemies[enemyi].armormodifyer *((decimal)Random.value*spawn.GetComponent<enemyinfo>().enemylevel/120);
			}
			if(spawn.GetComponent<enemyinfo>().enemybleeddamage == -1){
				spawn.GetComponent<enemyinfo>().enemybleeddamage = (int)(enemies[enemyi].bleeddamagemodifyer *((decimal)(Random.value*spawn.GetComponent<enemyinfo>().enemylevel*spawn.GetComponent<enemyinfo>().enemylevel/10)));
			}
			if(spawn.GetComponent<enemyinfo>().enemybleeddamagechance == -1){
				spawn.GetComponent<enemyinfo>().enemybleeddamagechance = enemies[enemyi].bleeddamagechancemodifyer *((int)Random.value*spawn.GetComponent<enemyinfo>().enemylevel/120);
			}
			if(spawn.GetComponent<enemyinfo>().enemycriticalchance == -1){
				spawn.GetComponent<enemyinfo>().enemycriticalchance = enemies[enemyi].criticalchancemodifyer *((int)Random.value*spawn.GetComponent<enemyinfo>().enemylevel/120);
			}
			if(spawn.GetComponent<enemyinfo>().enemyhealthabsorb == -1){
				spawn.GetComponent<enemyinfo>().enemyhealthabsorb = enemies[enemyi].healthabsorbmodifyer *((int)Random.value*(spawn.GetComponent<enemyinfo>().enemylevel/100));
			}
			if(spawn.GetComponent<enemyinfo>().enemystunchance == -1){
				spawn.GetComponent<enemyinfo>().enemystunchance = enemies[enemyi].stunchancemodifyer *((int)Random.value*(spawn.GetComponent<enemyinfo>().enemylevel/120));
			}
			if(spawn.GetComponent<enemyinfo>().xp== -1){
				spawn.GetComponent<enemyinfo>().xp = (int)Random.Range((spawn.GetComponent<enemyinfo>().enemylevel*30),(spawn.GetComponent<enemyinfo>().enemylevel*70));			
			}
			if(spawn.GetComponent<enemyinfo>().weaponname == "" &  enemies[enemyi].hasweapon == true){
				spawn.GetComponent<enemyinfo>().weapon = weapons[Random.Range(0,weapons.Length)];
				spawn.GetComponent<enemyinfo>().weaponname = spawn.GetComponent<enemyinfo>().weapon.name;
			}else{
				for(int j = 0;j<weapons.Length;j++){
					if(spawn.GetComponent<enemyinfo>().weaponname == weapons[j].name){
						spawn.GetComponent<enemyinfo>().weapon = weapons[j];
						spawn.GetComponent<enemyinfo>().weaponname = spawn.GetComponent<enemyinfo>().weapon.name;
					}
				}
			}
			spawn.GetComponent<enemyinfo>().itemtype = spawn.GetComponent<enemyinfo>().weapon.itemtype;
			spawn.GetComponent<enemyinfo>().weaponobjectname  = spawn.GetComponent<enemyinfo>().weaponname +" Object";
			enemyobj.GetComponent<cubeenemy>().attackspeed = spawn.GetComponent<enemyinfo>().enemyattackspeed;
			enemyobj.GetComponent<cubeenemy>().enemyname = enemies[enemyi].name;
			enemyobj.GetComponent<cubeenemy>().enemyi =enemyi;
			enemyobj.GetComponent<cubeenemy>().damage = spawn.GetComponent<enemyinfo>().enemydamage;
			enemyobj.GetComponent<cubeenemy>().maxshield = spawn.GetComponent<enemyinfo>().enemyshield;
			enemyobj.GetComponent<cubeenemy>().level = spawn.GetComponent<enemyinfo>().enemylevel;
			enemyobj.GetComponent<cubeenemy>().maxhealth = spawn.GetComponent<enemyinfo>().enemyhealth;
			enemyobj.GetComponent<cubeenemy>().armor = spawn.GetComponent<enemyinfo>().enemyarmor;
			enemyobj.GetComponent<cubeenemy>().bleeddamage = spawn.GetComponent<enemyinfo>().enemybleeddamage;
			enemyobj.GetComponent<cubeenemy>().bleeddamagechance = spawn.GetComponent<enemyinfo>().enemybleeddamagechance;
			enemyobj.GetComponent<cubeenemy>().criticalchance = spawn.GetComponent<enemyinfo>().enemycriticalchance;
			enemyobj.GetComponent<cubeenemy>().healthabsorb = spawn.GetComponent<enemyinfo>().enemyhealthabsorb;
			enemyobj.GetComponent<cubeenemy>().stunchance = spawn.GetComponent<enemyinfo>().enemystunchance;
			enemyobj.GetComponent<cubeenemy>().speed = enemies[enemyi].speed;
			enemyobj.GetComponent<cubeenemy>().alertradius = spawn.GetComponent<enemyinfo>().distance;
			enemyobj.GetComponent<cubeenemy>().animatorobject = spawn.GetComponent<enemyinfo>().weapon.animatorname;

			enemyobj.GetComponent<cubeenemy>().objectname = spawn.GetComponent<enemyinfo>().weaponobjectname;
			enemyobj.GetComponent<cubeenemy>().xpreward = spawn.GetComponent<enemyinfo>().xp;
			if(enemies[enemyi].hasweapon == true){
				GameObject weapon = (GameObject)(Instantiate(Resources.Load(spawn.GetComponent<enemyinfo>().weaponobjectname) ,new Vector3(spawn.transform.position.x-.35f,spawn.transform.position.y,spawn.transform.position.z), Quaternion.identity));

				enemyobj.GetComponent<cubeenemy>().objectname = weapon.name;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weapondetect>().enabled = true;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<BoxCollider>().isTrigger = true;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).tag = "Untagged";
				weapon.transform.parent = enemyobj.transform.FindChild("Cube");

				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapattspeed = spawn.GetComponent<enemyinfo>().weaponattackspeed;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapdamage = spawn.GetComponent<enemyinfo>().weapondamage;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaplevel = spawn.GetComponent<enemyinfo>().weaponlevel;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapname = spawn.GetComponent<enemyinfo>().weaponname;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaphealth =spawn.GetComponent<enemyinfo>().weaponhealth;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapshield =spawn.GetComponent<enemyinfo>().weaponshield;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapadrenaline =spawn.GetComponent<enemyinfo>().weaponadrenaline;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaparmor =spawn.GetComponent<enemyinfo>().weaponarmor;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapbleeddamage =spawn.GetComponent<enemyinfo>().weaponbleeddamage;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapbleeddamagechance =spawn.GetComponent<enemyinfo>().weaponbleeddamagechance;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapcriticalchance =spawn.GetComponent<enemyinfo>().weaponcriticalchance;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaphealthabsorb =spawn.GetComponent<enemyinfo>().weaponhealthabsorb;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapstunchance =spawn.GetComponent<enemyinfo>().weaponstunchance;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaptype =spawn.GetComponent<enemyinfo>().itemtype;
				int weaponi = 0;
				for (int n = 0;n< weapons.Length;n++){
					if(weapons[n].name == spawn.GetComponent<enemyinfo>().weaponname){
						weaponi = n;
					}
				}
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaplevel = enemyobj.GetComponent<cubeenemy>().level;
				weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaptype = spawn.GetComponent<enemyinfo>().weapon.itemtype;
				if(weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapattspeed== -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapattspeed = (int)((float)(weapons[weaponi].attackspeedmodifyer)* Random.Range(8,((float)enemyobj.GetComponent<cubeenemy>().level/4)+8));
				}
				if(weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapdamage == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapdamage = (int)((float)(weapons[weaponi].damagemodifyer)* Random.Range(1+(float)enemyobj.GetComponent<cubeenemy>().level*(float)enemyobj.GetComponent<cubeenemy>().level/2,((float)enemyobj.GetComponent<cubeenemy>().level*(float)enemyobj.GetComponent<cubeenemy>().level)));
				}	
				if(	weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaphealth == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaphealth =(int)((float)(weapons[weaponi].healthmodifyer)* Random.Range((float)enemyobj.GetComponent<cubeenemy>().level*(float)enemyobj.GetComponent<cubeenemy>().level/2,((float)enemyobj.GetComponent<cubeenemy>().level*(float)enemyobj.GetComponent<cubeenemy>().level)));
				}
				if(	weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapshield == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapshield = (int)((float)(weapons[weaponi].shieldmodifyer)* Random.Range((float)enemyobj.GetComponent<cubeenemy>().level*(float)enemyobj.GetComponent<cubeenemy>().level/2,((float)enemyobj.GetComponent<cubeenemy>().level*(float)enemyobj.GetComponent<cubeenemy>().level)));
				}
				if(	weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapadrenaline == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapadrenaline = (int)((float)(weapons[weaponi].adrenalinemodifyer)* Random.Range((float)enemyobj.GetComponent<cubeenemy>().level/50,((float)enemyobj.GetComponent<cubeenemy>().level/25)));
				}
				if(	weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaparmor == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaparmor = System.Math.Round(((weapons[weaponi].armormodifyer)* (decimal)Random.value/8),2);
				}
				if(	weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapbleeddamage == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapbleeddamage = (int)((weapons[weaponi].bleeddamagemodifyer)* Random.Range(enemyobj.GetComponent<cubeenemy>().level*enemyobj.GetComponent<cubeenemy>().level/2,(enemyobj.GetComponent<cubeenemy>().level*enemyobj.GetComponent<cubeenemy>().level)/5));
				}
				if(	weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapbleeddamagechance == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapbleeddamagechance = 	System.Math.Round(((weapons[weaponi].bleeddamagechancemodifyer)* (decimal)(Random.value/8)),2);
				}
				if(	weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapcriticalchance == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapcriticalchance = System.Math.Round(((weapons[weaponi].criticalchancemodifyer)* (decimal)Random.value/8),2);
				}
				if(	weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapcriticalchance == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapcriticalchance = System.Math.Round(((weapons[weaponi].criticalchancemodifyer)* (decimal)Random.value/8),2);
				}
				if(	weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaphealthabsorb == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weaphealthabsorb = System.Math.Round(((weapons[weaponi].healthabsorbmodifyer)* (decimal)Random.value/8),2);
				}
				if(	weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapstunchance == -1){
					weapon.transform.FindChild(spawn.GetComponent<enemyinfo>().weapon.animatorname).GetComponent<weaponhover>().weapstunchance = System.Math.Round(((weapons[weaponi].stunchancemodifyer)* (decimal)Random.value/8),2);
				}
			}
			i++;
		}while(i <=totalenemies);
	}
	//end
	//of
	//script
}













