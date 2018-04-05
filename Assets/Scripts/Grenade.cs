using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
	GameObject[] enemies;
	Rigidbody rbody;
	int holdVal = 0;
	int explodeVal = 0;
	public GameObject pin;
	public CapsuleCollider expCol;
	// Use this for initialization
	void Start () {
		expCol.enabled = false;
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (GameObject go in enemies) {
			rbody = go.GetComponent<Rigidbody> ();
			if (rbody != null){
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		//if (transform.parent == null) {
		//	Physics.IgnoreLayerCollision (10, 11, true);
		//}else{
		//	Physics.IgnoreLayerCollision (10, 11, false);
		//}
	}



	void Update () {
		Physics.IgnoreLayerCollision (9, 10, true);

		if (transform.parent == GameObject.FindGameObjectWithTag("Hand").transform) {
			if (holdVal == 0) {
				if (Input.GetButtonDown ("Fire1")) {
					holdVal = 1;
					Instantiate (pin, transform.position, transform.rotation);


				}
			}
		}
		if (holdVal == 1) {
			StartCoroutine ("GrenadeBlow");
		}
		foreach (GameObject go in enemies) {
			if (explodeVal == 1) {
				rbody.AddExplosionForce (10, transform.position, 300);
				rbody.AddForce (new Vector3(0,30,0), ForceMode.Impulse);
			}

		}
	}
	IEnumerator GrenadeBlow(){
		
		yield return new WaitForSeconds (5);
		FindObjectOfType<AudioManager>().Play("Grenade");
		expCol.enabled = true;
		explodeVal = 1;
		yield return new WaitForSeconds (0.1f);
		explodeVal = 0;
		Destroy (gameObject);
	
	}
}
