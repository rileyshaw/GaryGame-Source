using UnityEngine;
using System.Collections;

public class weaponhover : playersetup {
	public int weaplevel = 2;
	public int weapdamage = 3;
	public string weaptype = "";
	public string weapname = "Broken Stick";
	public int weapattspeed = 20;
	public int weaphealth = 0;
	public int weapshield = 0;
	public int weapbleeddamage;
	public decimal weapbleeddamagechance;
	public decimal weapstunchance;
	public decimal weapcriticalchance;
	public decimal weaphealthabsorb;
	public int weapadrenaline;
	public decimal weaparmor;
	private Transform playerscript;
	private Transform playerobject;
	private Transform weapon;
	public float distance;

	// Use this for initialization
	void Start () {
		playerscript = GameObject.FindGameObjectWithTag ("GameController").transform;
		playerobject = GameObject.FindGameObjectWithTag ("Finish").transform;
		weapon = gameObject.transform;
	}
	void FixedUpdate () {
		distance = Mathf.Abs(weapon.transform.position.x-playerobject.position.x); 
	}
	void OnMouseOver(){
		if(this.transform.parent == null){
			playerscript.GetComponent<GUIscript> ().ishoveringweap = true;
			playerscript.GetComponent<GUIscript> ().ishovering = false;
			playerscript.GetComponent<GUIscript> ().weaplevel = weaplevel;
			playerscript.GetComponent<GUIscript> ().weapdamage = weapdamage;
			playerscript.GetComponent<GUIscript> ().weaptype = weaptype;
			playerscript.GetComponent<GUIscript> ().weapname = weapname;
			playerscript.GetComponent<GUIscript> ().weapadrenaline = weapadrenaline;
			playerscript.GetComponent<GUIscript> ().weapattspeed = weapattspeed;
			playerscript.GetComponent<GUIscript> ().weaparmor = weaparmor;
			playerscript.GetComponent<GUIscript> ().weapbleeddamage = weapbleeddamage;
			playerscript.GetComponent<GUIscript> ().weapbleeddamagechance = weapbleeddamagechance;
			playerscript.GetComponent<GUIscript> ().weapcriticalchance = weapcriticalchance;
			playerscript.GetComponent<GUIscript> ().weaphealth = weaphealth;
			playerscript.GetComponent<GUIscript> ().weaphealthabsorb = weaphealthabsorb;
			playerscript.GetComponent<GUIscript> ().weapshield = weapshield;
			playerscript.GetComponent<GUIscript> ().weapstunchance = weapstunchance;

			playerscript.GetComponent<GUIscript> ().weaplocked = weapon;
		}
	}
}
