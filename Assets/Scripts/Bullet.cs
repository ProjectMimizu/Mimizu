using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float bulletSpeed;
	public GameObject blood;
	public GameObject flash;


	// Use this for initialization
	void Start () {
		Instantiate (flash, transform.position, transform.rotation);
		blood= (GameObject)Resources.Load ("BloodSpurt"); 
		StartCoroutine ("BulletLife");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate(0,bulletSpeed * Time.deltaTime, 0);
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.collider.tag == "Ground") {
			StartCoroutine ("BulletHit");
		}
	}
	IEnumerator BulletLife(){
		yield return new WaitForSeconds (3);
		Destroy (gameObject);
	}
	IEnumerator BulletHit(){

		yield return new WaitForSeconds (0.01f);
		Destroy (gameObject);
	}


}