using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour {
	Rigidbody rbody;
	Collider shellCollider;
	Collider playerCollider;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody> ();
		rbody.AddForce (-5, 10, 0, ForceMode.Impulse);
		rbody.AddTorque(0,0,180,ForceMode.Impulse);
		shellCollider = GetComponent<Collider> ();
		playerCollider = GameObject.FindGameObjectWithTag("MainChara").GetComponent<Collider>();
		StartCoroutine ("killShell");


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Physics.IgnoreCollision (shellCollider, playerCollider);

	}

	IEnumerator killShell(){
		yield return new WaitForSeconds (5);
		Destroy (gameObject);
	}

}
