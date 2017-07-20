using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementHand : MonoBehaviour {
	Rigidbody arby;
	float preserveY;
	bool flip = false;
	bool space = false;
	// Use this for initialization
	void Start () {
		arby = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Q)) {
			Vector3 x = new Vector3 (-5f, transform.position.y, 0f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			Vector3 x = new Vector3 (-4.5f, transform.position.y, 0f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			Vector3 x = new Vector3 (-4.0f, transform.position.y, 0f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Vector3 x = new Vector3 (-3.5f, transform.position.y, 0f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			Vector3 x = new Vector3 (-3.0f, transform.position.y, 0f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.Y)) {
			Vector3 x = new Vector3 (-2.5f, transform.position.y, 0f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.U)) {
			Vector3 x = new Vector3 (-2.0f, transform.position.y, 0f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			Vector3 x = new Vector3 (-1.5f, transform.position.y, 0f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			Vector3 x = new Vector3 (-1.0f, transform.position.y, 0f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			Vector3 x = new Vector3 (-0.5f, transform.position.y, 0f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			Vector3 x = new Vector3 (-5f, transform.position.y, -1f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			Vector3 x = new Vector3 (-4.5f, transform.position.y, -1f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			Vector3 x = new Vector3 (-4.0f, transform.position.y, -1f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			Vector3 x = new Vector3 (-3.5f, transform.position.y, -1f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.G)) {
			Vector3 x = new Vector3 (-3.0f, transform.position.y, -1f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			Vector3 x = new Vector3 (-2.5f, transform.position.y, -1f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.J)) {
			Vector3 x = new Vector3 (-2.0f, transform.position.y, -1f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			Vector3 x = new Vector3 (-1.5f, transform.position.y, -1f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			Vector3 x = new Vector3 (-1.0f, transform.position.y, -1f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			Vector3 x = new Vector3 (-5f, transform.position.y, -2f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			Vector3 x = new Vector3 (-4.5f, transform.position.y, -2f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			Vector3 x = new Vector3 (-4.0f, transform.position.y, -2f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			Vector3 x = new Vector3 (-3.5f, transform.position.y, -2f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			Vector3 x = new Vector3 (-3.0f, transform.position.y, -2f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.N)) {
			Vector3 x = new Vector3 (-2.5f, transform.position.y, -2f);
			transform.position = x;
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			Vector3 x = new Vector3 (-2.0f, transform.position.y, -2f);
			transform.position = x;
		}







		if (Input.GetKeyDown (KeyCode.Space) && !flip) {
			space = true;
			preserveY = transform.position.y;
			Vector3 x = new Vector3 (transform.position.x, 0f, transform.position.z);
			transform.position = x;
		}

		if (Input.GetKeyDown (KeyCode.Space) && flip && !space) {
			space = true;
			preserveY = transform.position.y;
			Vector3 x = new Vector3 (transform.position.x, 2f, transform.position.z);
			transform.position = x;
		}


		if (Input.GetKeyUp (KeyCode.Space)) {
			space = false;
			Vector3 x = new Vector3 (transform.position.x, preserveY, transform.position.z);
			transform.position = x;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && !space) {
			flip = true;
			transform.Rotate (new Vector3 (-90f, 0f, 0f));
		}
		if (Input.GetKeyUp (KeyCode.UpArrow) && !space) {
			flip = false;
			transform.Rotate (new Vector3 (90f, 0f, 0f));
		}
	}
}
