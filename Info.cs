using UnityEngine;
using System.Collections;
public class Info : MonoBehaviour {
	public int level = 1;
	public float currentHealth = 100;
	public float maxHealth = 100;
	public Transform objtransform;
	void Start(){
		objtransform = transform;
	}
	void OnMouseOver() {
		Main main = FindObjectOfType(typeof(Main)) as Main;
		main.ReplaceInfo(this);
		Debug.Log("inside");
	}
}