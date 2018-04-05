using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour {
	public float bulletSpeed;
	public LineRenderer grappleLine;
	float grappleVal = 0;
	float grappleShoot = 0;
	Vector3 grapplePos;
	Quaternion grappleRot;
	public Transform hand;
	MeshRenderer rend;
	private GameObject player;
	Rigidbody2D rbody;
	// Use this for initialization
	void Start () {
		rend = GetComponent<MeshRenderer> ();
		player = GameObject.FindGameObjectWithTag("MainChara");
		rbody = player.GetComponent<Rigidbody2D> ();
	}



	// Update is called once per frame
	void FixedUpdate () {
		if ((transform.position - hand.transform.position).magnitude >= 25) {
			grappleShoot = 0;
			grappleVal = 0;
		}



		if (grappleShoot == 0) {
			transform.localPosition = hand.transform.position;
			transform.localRotation = hand.transform.rotation;
			rend.enabled = false;
			grappleLine.enabled = false;
			if (Input.GetButtonDown ("Fire2")) {
				grappleShoot = 1;
				return;
			}
		}


		
		if (grappleShoot == 1) {
			rend.enabled = true;
			grappleLine.enabled = true;
			if (grappleVal == 0){
					transform.Translate (0, bulletSpeed, 0);
		}

			if (Input.GetButtonDown ("Fire2")) {
				grappleShoot = 0;
				grappleVal = 0;
				//rbody.AddForce (0, 70, 0, ForceMode2D.Impulse);
				return;
			}
		}


			if (grappleVal == 1) {
			
			rbody.AddForce ((transform.position-hand.position)*50, ForceMode2D.Force);
					return;
				}

		


	}
			




	void OnTriggerEnter2D(Collider2D other){


		if (grappleShoot == 1) {
			//if (other.gameObject.CompareTag ("Enemy")) {
				//grappleVal = 1;
		
			//}
			if (other.gameObject.CompareTag ("Stabable")) {
				grappleVal = 1;			

			}
			if (other.gameObject.CompareTag ("Ground")) {
				grappleVal = 1;
	


			}
		}
	}
}
