using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
	public GameObject bullet;
	public float shootSpeed = 1;
	private float shootVal = 0;
	public Transform shoot;
	private Vector2 antiShoot;
	private Rigidbody2D rbody;
	private Collider2D playerCollider;
	private Collider2D enemyCollider;
	// Use this for initialization
	void Start () {

		rbody = GameObject.FindGameObjectWithTag("MainChara").GetComponent<Rigidbody2D>();
		playerCollider = GameObject.FindGameObjectWithTag("MainChara").GetComponent<Collider2D>();
		enemyCollider = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>();

	}
	void FixedUpdate(){
		Physics2D.IgnoreCollision (playerCollider, this.GetComponent<Collider2D>());

		if (transform.parent == null) {
			Physics2D.IgnoreLayerCollision (10, 11, true);
		}else{
			Physics2D.IgnoreLayerCollision (10, 11, false);
		}

	}
	
	// Update is called once per frame
	void Update () {





		if (transform.parent == GameObject.FindGameObjectWithTag("Hand").transform) {
			if (shootVal == 0) {
				if (Input.GetButtonDown ("Fire1")) {
					FindObjectOfType<AudioManager> ().Play ("GunShoot");
					antiShoot = transform.position - shoot.position;
					rbody.AddForce (antiShoot,ForceMode2D.Impulse);
					Debug.Log (antiShoot);
					Instantiate (bullet, shoot.transform.position, shoot.transform.rotation);
					shootVal = 1;
					StartCoroutine ("shootWait");

				}
			}
		}
	}
	IEnumerator shootWait()
	{
		yield return new WaitForSeconds (shootSpeed);
		shootVal = 0;

	}



}
