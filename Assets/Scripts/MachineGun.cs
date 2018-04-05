using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour {
	public GameObject bullet;
	public float shootSpeed = 0.1f;
	private float shootVal = 0;
	public Transform shoot;
	private Vector3 antiShoot;
	private Rigidbody rbody;
	private Collider playerCollider;
	private Collider enemyCollider;
	// Use this for initialization
	void Start () {
		rbody = GameObject.FindGameObjectWithTag("MainChara").GetComponent<Rigidbody>();
		//enemyCollider = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider>();
		//playerCollider = GameObject.FindGameObjectWithTag("MainChara").GetComponent<Collider>();

	}
	void FixedUpdate(){
		Physics.IgnoreCollision (playerCollider, this.GetComponent<Collider>());
	
		if (transform.parent == null) {
			//Physics.IgnoreLayerCollision (10, 11, true);
		}else{
			//Physics.IgnoreLayerCollision (10, 11, false);
		}

	}

	// Update is called once per frame
	void Update () {





		if (transform.parent == GameObject.FindGameObjectWithTag("Hand").transform) {
			if (shootVal == 0) {
				if (Input.GetButtonDown ("Fire1")) {
					FindObjectOfType<AudioManager> ().Play ("MachineGun");
					antiShoot = transform.position - shoot.position;
					shootVal = 1;
					StartCoroutine ("shootWait");

				}
			}
		}
	}
	IEnumerator shootWait()
	{
		
		Instantiate (bullet, shoot.transform.position, shoot.transform.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		//rbody.AddForce (antiShoot * 20,ForceMode.Impulse);
		yield return new WaitForSeconds (shootSpeed);
		Instantiate (bullet, shoot.transform.position, shoot.transform.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		//rbody.AddForce (antiShoot * 20,ForceMode.Impulse);
		yield return new WaitForSeconds (shootSpeed);
		Instantiate (bullet, shoot.transform.position, shoot.transform.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		//rbody.AddForce (antiShoot * 20,ForceMode.Impulse);
		yield return new WaitForSeconds (shootSpeed);
		Instantiate (bullet, shoot.transform.position, shoot.transform.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		//rbody.AddForce (antiShoot * 20,ForceMode.Impulse);
		yield return new WaitForSeconds (shootSpeed);
		Instantiate (bullet, shoot.transform.position, shoot.transform.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		//rbody.AddForce (antiShoot * 20,ForceMode.Impulse);
		yield return new WaitForSeconds (shootSpeed);
		Instantiate (bullet, shoot.transform.position, shoot.transform.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		//rbody.AddForce (antiShoot * 20,ForceMode.Impulse);
		yield return new WaitForSeconds (shootSpeed);
		Instantiate (bullet, shoot.transform.position, shoot.transform.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		//rbody.AddForce (antiShoot * 20,ForceMode.Impulse);
		yield return new WaitForSeconds (shootSpeed);
		Instantiate (bullet, shoot.transform.position, shoot.transform.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		//rbody.AddForce (antiShoot * 20,ForceMode.Impulse);
		yield return new WaitForSeconds (shootSpeed);
		Instantiate (bullet, shoot.transform.position, shoot.transform.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		//rbody.AddForce (antiShoot * 20,ForceMode.Impulse);
		yield return new WaitForSeconds (shootSpeed);
		Instantiate (bullet, shoot.transform.position, shoot.transform.rotation*Quaternion.Euler(0,0,Random.Range(-3,3)));
		//rbody.AddForce (antiShoot * 20,ForceMode.Impulse);
		yield return new WaitForSeconds (shootSpeed);
		shootVal = 0;

	}


}
