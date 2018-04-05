using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GrappleMan : MonoBehaviour {
	private Animator anim;
	public float jumpHeight = 10;
	private Rigidbody rbody;
	private GameObject hand;
	private Collider handCollider;
	private Collider bodyCollider;

	private Vector3 currentPos;
	private Vector3 lastPos;
	private float weaponAngle;
	private Rigidbody gbody;
	private Vector3 throwVel;
	float rotateVal = 0;

	public GameObject chara;
	public GameObject grapple;
	float grappleShoot;
	public Transform groundCheck;
	public Slider playerHealth;
	public GameObject deadPlayer;
	RaycastHit ground;
	Vector3 origin;

	void Start () {
		origin = transform.position;
		rbody = GetComponent<Rigidbody> ();
		bodyCollider = GetComponent<Collider> ();
		hand = GameObject.FindGameObjectWithTag ("Hand");
		handCollider = hand.GetComponent<Collider> ();
		lastPos = hand.transform.position;
		anim = GetComponent<Animator> ();
		Cursor.lockState = CursorLockMode.Locked;

	}
	void FixedUpdate(){
		Physics.IgnoreCollision (bodyCollider, handCollider);


		Physics.Raycast (groundCheck.position, Vector3.down, out ground);
		Debug.Log (ground.distance);
		if (ground.distance < 0.1f) {
			anim.SetBool ("onGround", true);
			if (!Input.GetButton ("Jump")) {
				rbody.velocity = new Vector3 (0, 0, 0);
			}
		} else {
			anim.SetBool ("onGround", false);
		}



		//player movement
		float h = Input.GetAxis ("Horizontal");
		//float v = Input.GetAxis("Vertical");


		if (Input.GetKey ("a")) {
			if (rotateVal == 0) {
				chara.transform.localScale = new Vector3 (-1, 1, 1);

				rotateVal = 1;
			}
		}
		if (Input.GetKey ("d")) {
			if (rotateVal == 1) {
				chara.transform.localScale = new Vector3 (1, 1, 1);
				rotateVal = 0;
			}
		}






		if (Input.GetKey ("s")) {
			rbody.velocity = new Vector3 (0f, -10f, 0f);
		}

		if (anim.GetBool ("onGround") == true) {
			this.transform.Translate (h / 4, 0, 0);
		}







	}

	void Update ()
	{		

		if (playerHealth.value == 0) {
			transform.Rotate (0, 0, 10);
			playerHealth.transform.localScale = new Vector3 (0,0,0);
			Instantiate (deadPlayer, transform.position, transform.rotation);
			Destroy (gameObject);

		}

		if (Input.GetKeyDown ("escape")) {
			Cursor.lockState = CursorLockMode.None;
		}
		//prevent hand and weapon colliding with body

		//hand movement
		float x = Input.GetAxis ("Mouse X");
		float y = Input.GetAxis ("Mouse Y");



		//each item in grabable objects





		//add input to crosshair
		hand.transform.position += new Vector3 (x/5, y/5, 0.0f);




		//get center of the screen

		//distance from hand to center of player
		Vector3 handOrigin = hand.transform.position - transform.position;



		hand.transform.localRotation = Quaternion.LookRotation (Vector3.forward,handOrigin);


		//clamping and normalizing hand distance
		Vector3 clampedPosition = hand.transform.position;
		clampedPosition.x = Mathf.Clamp (handOrigin.x, -1, 1);
		clampedPosition.y = Mathf.Clamp (handOrigin.y, -1, 1);
		clampedPosition.Normalize ();

		//applying clamped and normalized value if beyond a certain distance from center
		if (handOrigin.sqrMagnitude > 1f) {

			hand.transform.position = clampedPosition + transform.position;

		}


		if (anim.GetBool ("onGround") == true) {

			if (Input.GetButtonDown ("Jump")) {

				rbody.velocity = new Vector3 (0f, jumpHeight, 0f);
				anim.SetBool("onGround",false);

			}


		}




	}

	void OnCollisionEnter(Collision collision){
		if (collision.collider.tag == "Bullet") {
			FindObjectOfType<AudioManager> ().Play ("Stab");
			playerHealth.value -= 5;
			ContactPoint contact = collision.contacts [0];
			rbody.AddForce (contact.point * 3, ForceMode.Impulse);
			Debug.DrawRay (contact.point, contact.normal, Color.white, 20, true);
		}

	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("FallZone")) {
			transform.position = origin;
			rbody.velocity = new Vector3 (0, 0, 0);

		}
	}
}

