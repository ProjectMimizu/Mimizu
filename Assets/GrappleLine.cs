using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleLine : MonoBehaviour {
	LineRenderer line;
	public Transform hand;
	public Transform grapple;

	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer> ();


	}
	
	// Update is called once per frame
	void Update () {
		line.SetPosition (0, hand.position);
		line.SetPosition (1, grapple.position);
	}
}
