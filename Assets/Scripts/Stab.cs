using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour {
	int stabVal = 0;
	Vector3 stabPos;
	Quaternion stabRot;
	Rigidbody rbody;
	Collider playerCollider;
	public GameObject blood;
	private Collider enemyCollider;
	GameObject enemy;
	float speedPerSec;
	Vector3 oldPosition; 


	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody> ();
		blood= (GameObject)Resources.Load ("BloodSpurt"); 
		playerCollider = GameObject.FindGameObjectWithTag("MainChara").GetComponent<Collider>();
		enemyCollider = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider>();
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}
	void FixedUpdate(){
		Physics.IgnoreCollision (playerCollider, this.GetComponent<Collider>());

		//if (transform.parent == null) {
		//	Physics.IgnoreLayerCollision (10, 11, true);
		//}


	}


	void Update () {
		if (stabVal == 1) {
			this.transform.position = stabPos;
			this.transform.rotation = stabRot;

		}

		speedPerSec = Vector3.Distance (oldPosition, transform.position) / Time.deltaTime;
		oldPosition = transform.position;



	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag ("Stabable")) {
			
		stabVal = 1;
		stabPos = this.transform.position; 
		stabRot = this.transform.rotation;
		rbody.isKinematic = true;
		}
		if (other.gameObject.CompareTag ("Enemy")) {
			if (speedPerSec >= 10) {
			this.transform.parent = enemy.transform;
			stabVal = 1;
			stabPos = this.transform.position; 
			stabRot = this.transform.rotation;
			rbody.isKinematic = true;

				
					Instantiate (blood, transform.position, transform.rotation);
					
			}
		}
		if (other.gameObject.CompareTag ("Hand")) {

			stabVal = 0;

		}
}

	void OnTriggerExit(Collider other){

		if (other.gameObject.CompareTag ("Stabable")) {
			stabVal = 0;
		

		}
		if (other.gameObject.CompareTag ("Enemy")) {
			stabVal = 0;
		
		}
	
	}


}
