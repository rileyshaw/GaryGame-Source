using UnityEngine;
using System.Collections;

public class finish : MonoBehaviour {
	private Transform playerscript;
	private bool gamewon = false;
	public GUISkin win;
	public Vector3 eulerAngleVelocity = new Vector3(0, 100, 0);
	private float originy;
	// Use this for initialization
	void Start () {
		playerscript = GameObject.FindGameObjectWithTag ("Finish").transform;
		originy = transform.position.y;
	}
	void Update(){
		Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity);
		rigidbody.MoveRotation(rigidbody.rotation * deltaRotation);
	}
	void OnTriggerStay(Collider c){
		if(c.tag == "Finish" & playerscript.GetComponent<GaryCharacterController>().isplaying == true){
			GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<GUIscript>().cubecount++;
			if(GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<GUIscript>().cubecount >=3){
				playerscript.GetComponent<GaryCharacterController>().isplaying = false;
				if(GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().acts[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentact].levels[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentlevel].completed == false){
					GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().acts[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentact].goldencubescurrent += 3;
				}

				GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().acts[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentact].levels[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentlevel].completed = true;
				GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().acts[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentact].levels[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentlevel].goldencubescurrent = 3;
				if(GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentlevel < 9){
					GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().acts[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentact].levels[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentlevel+1].islocked = false;
				}else{
					if(GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentact<4){
						GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().acts[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentact+1].islocked= false;
						GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().acts[GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().currentact+1].levels[0].islocked = false;
					}
				}
				gamewon = true;
			}else{
				Destroy(gameObject);
			}
		}
	}
	void OnGUI(){
		if(gamewon == true){
			transform.position = Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,originy + 1.5f,transform.position.z),1 * Time.deltaTime);
			GUI.skin = win;
			GUI.Label(new Rect(Screen.width/2-100,Screen.height/2-200,200,100),"You Win!");
			if(GUI.Button(new Rect(Screen.width/2-100,Screen.height/2-100,200,100),"Menu")){
				GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<GUIscript>().cubecount = 0;
				GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().player.currenthealth  =GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().player.overhealth;
				for(int i = 0;i<GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().itemtypes.Length;i++){
					GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().itemtypes[i].perks[0].abilitycooldowncurrent = GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().itemtypes[i].perks[0].abilitycooldownmax;
					GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().itemtypes[i].perks[6].abilitycooldowncurrent = GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().itemtypes[i].perks[6].abilitycooldownmax;
					GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().itemtypes[i].perks[9].abilitycooldowncurrent = GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().itemtypes[i].perks[9].abilitycooldownmax;
					GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().itemtypes[i].perks[15].abilitycooldowncurrent = GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<playersetup>().itemtypes[i].perks[15].abilitycooldownmax;
					
					
					
				}
				GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<GUIscript>().guimenu = 102;
				GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<GUIscript>().currentacthover2++;
				GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<GUIscript>().hoverchangingright2 = true;
				GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<GUIscript>().isinitialized =false;
				GameObject.FindGameObjectWithTag ("GameController").transform.GetComponent<GUIscript>().gameend = false;
				
				Application.LoadLevel(0);
			}
		}
	}
}
