using UnityEngine;
using System.Collections;

public class textrise : MonoBehaviour {
	public Vector3 transformer;
	public int type;
	private Transform player;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Finish").transform;
	}
	void Update () {
		if(type == 0){
			if(transform.position.y - transformer.y <2){
				rigidbody.velocity = transform.up * 1.5f;
			}else{
				Destroy(transform.gameObject);
			}
		}
		if(type == 1){
			transform.position = new Vector3(player.transform.position.x,transform.position.y,transform.position.z);
			StartCoroutine(levelwait());
			if(transform.position.y - transformer.y <3){
				rigidbody.velocity = transform.up * 1.5f;
			}else{
				Destroy(transform.gameObject);
			}
		}
		if(type == 2){
			transform.position = new Vector3(transformer.x,transform.position.y,transform.position.z);
			if(transform.position.y - transformer.y <2){
				rigidbody.velocity = transform.up * 1.5f;
			}else{
				Destroy(transform.gameObject);
			}
		}
		if(type == 3){

		}
	}
	public IEnumerator levelwait(){
		yield return new WaitForSeconds(2f);
		Destroy(transform.gameObject);
	}
}
