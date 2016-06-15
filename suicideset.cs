using UnityEngine;
using System.Collections;

public class suicideset : MonoBehaviour {
	public int suicidedamage;
	// Use this for initialization
	void Start () {
		StartCoroutine(waiterlol());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator waiterlol() {
		yield return new WaitForSeconds(1f);
		Destroy(gameObject);
	}
}
