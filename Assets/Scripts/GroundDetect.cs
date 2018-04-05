using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetect : MonoBehaviour {
	public Animator anim;
	public Collider col;
	// Use this for initialization
	void Start () {
		anim = GetComponentInParent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.CompareTag ("Ground")) {
			anim.SetBool ("onGround",true);
		} 
		if (col.gameObject.CompareTag ("Stabable")) {
			anim.SetBool ("onGround",true);

		}



	}
}
