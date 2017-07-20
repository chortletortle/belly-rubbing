using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementHand : MonoBehaviour {
	public GameObject spot;

	float preserveY;
	bool flip = false;
	bool space = false;

	char[][] keyboard;
	float[][] curCoordsX;
	float[][] curCoordsZ;

	char[] randSel;
	float[] randX;
	float[] randZ;

	ArrayList lastTenChars = new ArrayList();
	// Use this for initialization
	void Start () {
		generateRandom();
		foreach (char x in randSel){
			Debug.Log(x);
		}
		foreach (float x in randX){
			Debug.Log(x);
		}
		foreach (float x in randZ){
			Debug.Log(x);
		}

	}

	// Update is called once per frame
	void Update () {
		int correct = 0;
		for (int i = 0; i < lastTenChars.Count; i++) {
			if (randSel [0].Equals(lastTenChars [i]) ||
				randSel [1].Equals(lastTenChars [i]) ||
				randSel [2].Equals(lastTenChars [i]) ||
				randSel [3].Equals(lastTenChars [i]))
				correct++;
		}

		if (correct == 10) {
			generateRandom();
		}


		if (Input.GetKeyDown (KeyCode.Q)) {
			Vector3 x = new Vector3 (-5f, transform.position.y, 0f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('q');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}

		}
		if (Input.GetKeyDown (KeyCode.W)) {
			Vector3 x = new Vector3 (-3.5f, transform.position.y, 0f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('w');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			Vector3 x = new Vector3 (-2f, transform.position.y, 0f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('e');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			Vector3 x = new Vector3 (-0.5f, transform.position.y, 0f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('r');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			Vector3 x = new Vector3 (1f, transform.position.y, 0f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('t');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Y)) {
			Vector3 x = new Vector3 (2.5f, transform.position.y, 0f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('y');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.U)) {
			Vector3 x = new Vector3 (4f, transform.position.y, 0f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('u');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			Vector3 x = new Vector3 (5.5f, transform.position.y, 0f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('i');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			Vector3 x = new Vector3 (7f, transform.position.y, 0f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('o');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			Vector3 x = new Vector3 (8.5f, transform.position.y, 0f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('p');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}



		if (Input.GetKeyDown (KeyCode.A)) {
			Vector3 x = new Vector3 (-5f, transform.position.y, -1.5f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('a');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			Vector3 x = new Vector3 (-3.5f, transform.position.y, -1.5f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('s');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			Vector3 x = new Vector3 (-2f, transform.position.y, -1.5f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('d');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			Vector3 x = new Vector3 (-0.5f, transform.position.y, -1.5f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('f');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.G)) {
			Vector3 x = new Vector3 (1f, transform.position.y, -1.5f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('g');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			Vector3 x = new Vector3 (2.5f, transform.position.y, -1.5f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('h');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.J)) {
			Vector3 x = new Vector3 (4.0f, transform.position.y, -1.5f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('j');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.K)) {
			Vector3 x = new Vector3 (5.5f, transform.position.y, -1.5f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('k');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.L)) {
			Vector3 x = new Vector3 (7.0f, transform.position.y, -1.5f);
			transform.position = x;
			if (space){
				lastTenChars.Add ('l');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Semicolon)) {
			Vector3 x = new Vector3 (8.5f, transform.position.y, -1.5f);
			transform.position = x;
			if (space){
				lastTenChars.Add (';');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}






		if (Input.GetKeyDown (KeyCode.Z)) {
			Vector3 x = new Vector3 (-5f, transform.position.y, -3f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('z');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			Vector3 x = new Vector3 (-3.5f, transform.position.y, -3f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('x');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			Vector3 x = new Vector3 (-2.0f, transform.position.y, -3f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('c');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.V)) {
			Vector3 x = new Vector3 (-0.5f, transform.position.y, -3f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('v');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.B)) {
			Vector3 x = new Vector3 (1f, transform.position.y, -3f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('b');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.N)) {
			Vector3 x = new Vector3 (2.5f, transform.position.y, -3f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('n');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.M)) {
			Vector3 x = new Vector3 (4f, transform.position.y, -3f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('m');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Comma)) {
			Vector3 x = new Vector3 (5.5f, transform.position.y, -3f);
			transform.position = x;
			if (space) {
				lastTenChars.Add (',');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Period)) {
			Vector3 x = new Vector3 (7.0f, transform.position.y, -3f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('.');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
		}
		if (Input.GetKeyDown (KeyCode.Slash)) {
			Vector3 x = new Vector3 (8.5f, transform.position.y, -3f);
			transform.position = x;
			if (space) {
				lastTenChars.Add ('/');
				if (lastTenChars.Count > 10) {
					lastTenChars.RemoveAt (0);
				}
			}
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

		Vector3 w = new Vector3 (randX[0]+.75f, -0.05f, randZ[0]-.75f);
		spot.transform.position = w;
	}

	void generateRandom() {
		keyboard = new char[][] {
			new char[10],
			new char[10],
			new char[10]
		};
		curCoordsX = new float[][] {
			new float[10],
			new float[10],
			new float[10]
		};
		curCoordsZ = new float[][] {
			new float[10],
			new float[10],
			new float[10]
		};


		string qz = "qwertyuiopasdfghjkl;zxcvbnm,./";
		int counter = 0;
		for (int i = 0, z = 0; i < keyboard.Length; i++, z -= 3) {
			for (int j = 0, x = -10; j < keyboard [0].Length; j++, x += 3) {
				keyboard [i] [j] = qz [counter++];
				curCoordsX [i] [j] = (float)x / 2f;
				curCoordsZ [i] [j] = (float)z / 2f;

			}
		}
		int ranRow = (int)Mathf.Round(Random.Range (0, keyboard.Length - 1));
		Debug.Log(ranRow);
		int ranCol = (int)Mathf.Round(Random.Range (0, keyboard [0].Length - 2));
		randSel = new char[] {keyboard [ranRow] [ranCol], keyboard [ranRow] [ranCol + 1], 
			keyboard [ranRow + 1] [ranCol], keyboard [ranRow + 1] [ranCol + 1]
		};
		randX = new float[] {curCoordsX [ranRow] [ranCol], curCoordsX [ranRow] [ranCol + 1], 
			curCoordsX [ranRow + 1] [ranCol], curCoordsX [ranRow + 1] [ranCol + 1]
		};
		randZ = new float[] {curCoordsZ [ranRow] [ranCol], curCoordsZ [ranRow] [ranCol + 1], 
			curCoordsZ [ranRow + 1] [ranCol], curCoordsZ [ranRow + 1] [ranCol + 1]
		};
	}
}