



private var anim : Animator;

var jumpHeight : float = 10;
private var rbody: Rigidbody2D;
private var hand: GameObject;
//var grabObj: GameObject = [];
	private var handCollider: Collider2D;
	private var bodyCollider: Collider2D;
	var grab: GameObject ;
	private var grabVal: int = 0;
	private var pressVal: int = 0;
	private var currentPos: Vector3;
	private var lastPos: Vector3;
	private var weaponAngle: float;
	private var gbody: Rigidbody2D;
	private var throwVel: Vector3;
	private var rotateVal: float = 0;
	private var grabRot;
	var chara:GameObject;
	var grapple: GameObject;
	var grappleShoot: float;
	//Collider[] grounded;
	var groundCheck: Transform;
	//float groundRadius = 0.1f;
	//public LayerMask whatIsGround;
	var playerHealth:GameObject;
	var deadPlayer: GameObject;
	var ground: RaycastHit;
	var origin: Vector3 ;


function Start() {
	
		origin = transform.position;
		rbody = GetComponent(Rigidbody2D);
		bodyCollider = GetComponent(Collider2D);
		hand = GameObject.FindGameObjectWithTag ("Hand");
		handCollider = hand.GetComponent(Collider2D);
		lastPos = hand.transform.position;
		anim = GetComponent(Animator);
		Cursor.lockState = CursorLockMode.Locked;

}

function FixedUpdate(){

		Physics2D.IgnoreCollision(bodyCollider, handCollider);
		if (Input.GetButton ("Jump")) {
				rbody.velocity = new Vector3 (0, 10, 0);
			}


			var h: float = Input.GetAxis ("Horizontal");



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
			rbody.velocity = new Vector3 (0f, -20f, 0f);
		}


			this.transform.Translate (h /4, 0, 0);

}

function Update ()
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
		var x: float = Input.GetAxis ("Mouse X");
		var y: float = Input.GetAxis ("Mouse Y");

		//all grabable items in scene
		//grabObj = GameObject.FindGameObjectsWithTag ("Grabable");

		//grabable objects that are within reach
		//var grabby: List.<GameObject>;

		//each item in grabable objects
		//foreach (GameObject (go) in grabObj) {


			//set reach range for grabable objects
			//if (Vector3.Distance (hand.transform.position, go.transform.position) <= 1.5f) {
				//for things within reach
				//if nothing in hand
				//if (Input.GetKeyDown ("e")) {
					//if (pressVal == 0) {
						//if (grabby.Count == 0) {
							

							//grabby.Add (go);
							//grab = grabby [0];
							//gbody = grab.GetComponent(Rigidbody2D);
							//Physics2D.IgnoreCollision (bodyCollider, grab.GetComponent(Collider2D));
							//grabVal = 1;


						//}
					//}
					//if (pressVal == 1) {
					//	gbody.velocity = throwVel * 20;
					//	grabby.Remove(go);
						//if (gbody.velocity.magnitude >= 10) {
						//	FindObjectOfType(AudioManager).Play("Throw");

					//	}
					//	grabVal = 0;


					//}
				//}
			//}
		//} 




		//add input to crosshair
		hand.transform.position += new Vector3 (x/5, y/5, 0.0f);




		//get center of the screen

		//distance from hand to center of player
		var handOrigin: Vector3 = hand.transform.position - transform.position;



		hand.transform.localRotation = Quaternion.LookRotation (Vector3.forward,handOrigin);

	
		//clamping and normalizing hand distance
		var clampedPosition: Vector3  = hand.transform.position;
		if (rotateVal == 0) {
			clampedPosition.x = Mathf.Clamp (handOrigin.x, 0.2f, 1);
		}
		if (rotateVal == 1) {
			clampedPosition.x = Mathf.Clamp (handOrigin.x, -1, -0.2f);
		}
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

		if (grab != null){


			if (rotateVal == 0) {
				grab.transform.localRotation = Quaternion.identity;

		}
			
			if (rotateVal == 1) {
				grab.transform.localRotation = Quaternion.Euler (0, 180, 0);
		}
		//grab on or off

		if (grabVal == 1) {
			grab.transform.position = hand.transform.position;
			
			grab.transform.parent  = hand.transform;
				handCollider.enabled = false;
			gbody.isKinematic = true;
		
			pressVal = 1;
		}
		if (grabVal == 0) {
			grab.transform.parent = null;
			gbody.isKinematic = false;
				handCollider.enabled = true;
			pressVal = 0;
			grab = null;
		
		}
		//get throw velocity
		currentPos = hand.transform.position;
		if (lastPos != currentPos) {
			throwVel = currentPos - lastPos;
			lastPos = currentPos;
		}


	





	}


	}


