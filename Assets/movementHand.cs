using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movementHand : MonoBehaviour {
	public GameObject spot;
	public Image orgasmMeter;
	public Text titles;
	public GameObject haterObj;
	public Text hatersNum;

	public MeshRenderer spread;
	public MeshRenderer rest;
	public MeshRenderer flipmesh;
	public MeshRenderer flipoffmesh;

	public AudioSource intake;
	public AudioSource intake2;
	public AudioSource intake3;
	public AudioSource intake4;
	public AudioSource intake5;

	public AudioSource outtake;
	public AudioSource outtake2;

	public AudioSource moan;
	public AudioSource moan2;
	public AudioSource moan3;
	public AudioSource moan4;
	public AudioSource moan5;

	public AudioSource failure;
	public AudioSource orgasm;
	public AudioSource hate;
	public AudioSource flippin;

	public Light spotLight;

	float preserveY;
	bool flip = false;
	bool flipoff = false;
	bool space = false;
	public float waitTime = 120.0f;
	public float rate = .25f;
	bool start = false;

	char[][] keyboard;
	float[][] curCoordsX;
	float[][] curCoordsZ;

	char[] randSel;
	float[] randX;
	float[] randZ;

	float decreaseTime;
	float randomFlowTime;
	float haterEntrance;
	bool hater = false;
	float haterMult = 1.0f;
	bool g;
	bool endPlayed = false;
	bool haterPlayed = false;

	ArrayList lastTenChars = new ArrayList();
	// Use this for initialization
	void Start () {
		generateRandom();
		haterEntrance = Random.Range(.03f, .1f);
		Debug.Log (haterEntrance);
	}

	// Update is called once per frame
	void Update () {
		if (!start) {
			if (Input.GetKeyDown (KeyCode.G)) {
				g = true;
			} 

			if (Input.GetKeyUp (KeyCode.G)) {
				g = false;
			}

			orgasmMeter.enabled = false;
			titles.enabled = true;
			if (g)
				titles.text = "Q-P, A-;, Z-/ to move \n space to rub belly or flip off bad vibes \n up arrow to prepare flipping off";
			else
				titles.text = "hey there big girl, wanna play? ;->\nspace to start \n G for instructions";
			if (Input.GetKeyUp (KeyCode.Space)) {
				orgasmMeter.enabled = true;
				titles.enabled = false;
				start = true;
			}


		} else {
			if (orgasmMeter.fillAmount <= .01f) {
				titles.enabled = true;
				titles.text = "The mood was killed\nTry again?";
				if (!endPlayed) {
					failure.Play ();
					endPlayed = true;
				}
				orgasmMeter.enabled = false;
				if (Input.GetKeyDown (KeyCode.Space)) {
					orgasmMeter.enabled = true;
					orgasmMeter.fillAmount = 0.30f;
					generateRandom ();
					titles.enabled = false;
					endPlayed = false;
				}

			} else if (orgasmMeter.fillAmount >= .97f) {
				titles.enabled = true;
				if (!endPlayed) {
					orgasm.Play ();
					endPlayed = true;
				}
				titles.text = "now we can get to the best part, C U D D L E S ! ;-p \n space to play again";
				orgasmMeter.enabled = false;
				spotLight.enabled = false;
				if (Input.GetKeyDown (KeyCode.Space)) {
					endPlayed = false;
					orgasmMeter.enabled = true;
					orgasmMeter.fillAmount = 0.30f;
					generateRandom ();
					titles.enabled = false;
					spotLight.enabled = true;
				}
			} else {
				decreaseTime = rate / waitTime * Time.deltaTime;
				randomFlowTime -= decreaseTime;
				orgasmMeter.fillAmount -= decreaseTime * haterMult;
				Debug.Log (randomFlowTime);
				Debug.Log (hater);
				if (Mathf.Abs(randomFlowTime) >= haterEntrance) {
					Vector3 orig = haterObj.transform.position;
					hater = true;
					haterObj.transform.position = new Vector3 (.9f, orig.y, orig.z);
					Vector3 origNum = hatersNum.transform.position;
					hatersNum.transform.position = new Vector3 (1.2f, origNum.y, origNum.z);
					haterMult = 4.0f;
					if (!haterPlayed) {
						hate.Play ();
						haterPlayed = true;
					} else {
					}
					if (flipoff) {
						orig = haterObj.transform.position;
						haterObj.transform.position = new Vector3 (17.3f, orig.y, orig.z);
						origNum = hatersNum.transform.position;
						hatersNum.transform.position = new Vector3 (17.3f, origNum.y, origNum.z);
						Debug.Log ("flipflapping yu off homes");
						randomFlowTime = 0f;
						haterEntrance = Random.Range(.1f, .2f);
						hater = false;
						haterMult = 1.0f;
						haterPlayed = false;
						flippin.Play ();
					}
				} 
			}


			int correct = 0;
			for (int i = 0; i < lastTenChars.Count; i++) {
				if (randSel [0].Equals (lastTenChars [i]) ||
				    randSel [1].Equals (lastTenChars [i]) ||
				    randSel [2].Equals (lastTenChars [i]) ||
				    randSel [3].Equals (lastTenChars [i])) {
						correct++;
					
				}
					
			}

			if (correct >= 8) {
				generateRandom();
				orgasmMeter.fillAmount += 0.06f;
				lastTenChars = new ArrayList();
				float moanVal = Random.Range (0f, 1f);
				if (moanVal <= .2f) {
					moan.Play ();
				} else if (moanVal <= .4f) {
					moan2.Play ();
				} else if (moanVal <= .6f) {
					moan3.Play ();
				} else if (moanVal <= .8f) {
					moan4.Play ();
				} else {
					moan5.Play ();
				}
			}


			if (Input.GetKeyDown (KeyCode.Q)) {
				Vector3 x = new Vector3 (-5f, transform.position.y, 0f);
				transform.position = x;

					
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('q');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}

			}
			if (Input.GetKeyDown (KeyCode.W)) {
				Vector3 x = new Vector3 (-3.5f, transform.position.y, 0f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('w');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				Vector3 x = new Vector3 (-2f, transform.position.y, 0f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('e');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.R)) {
				Vector3 x = new Vector3 (-0.5f, transform.position.y, 0f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('r');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.T)) {
				Vector3 x = new Vector3 (1f, transform.position.y, 0f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('t');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.Y)) {
				Vector3 x = new Vector3 (2.5f, transform.position.y, 0f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('y');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.U)) {
				Vector3 x = new Vector3 (4f, transform.position.y, 0f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('u');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.I)) {
				Vector3 x = new Vector3 (5.5f, transform.position.y, 0f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('i');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.O)) {
				Vector3 x = new Vector3 (7f, transform.position.y, 0f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('o');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.P)) {
				Vector3 x = new Vector3 (8.5f, transform.position.y, 0f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('p');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}



			if (Input.GetKeyDown (KeyCode.A)) {
				Vector3 x = new Vector3 (-5f, transform.position.y, -1.5f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('a');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				Vector3 x = new Vector3 (-3.5f, transform.position.y, -1.5f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('s');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				Vector3 x = new Vector3 (-2f, transform.position.y, -1.5f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('d');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.F)) {
				Vector3 x = new Vector3 (-0.5f, transform.position.y, -1.5f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('f');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.G)) {
				Vector3 x = new Vector3 (1f, transform.position.y, -1.5f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('g');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.H)) {
				Vector3 x = new Vector3 (2.5f, transform.position.y, -1.5f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('h');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.J)) {
				Vector3 x = new Vector3 (4.0f, transform.position.y, -1.5f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('j');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.K)) {
				Vector3 x = new Vector3 (5.5f, transform.position.y, -1.5f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('k');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.L)) {
				Vector3 x = new Vector3 (7.0f, transform.position.y, -1.5f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add ('l');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.Semicolon)) {
				Vector3 x = new Vector3 (8.5f, transform.position.y, -1.5f);
				transform.position = x;
				if (space && !flipoff && !flip){
					lastTenChars.Add (';');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}


			if (Input.GetKeyDown (KeyCode.Z)) {
				Vector3 x = new Vector3 (-5f, transform.position.y, -3f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('z');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.X)) {
				Vector3 x = new Vector3 (-3.5f, transform.position.y, -3f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('x');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.C)) {
				Vector3 x = new Vector3 (-2.0f, transform.position.y, -3f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('c');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.V)) {
				Vector3 x = new Vector3 (-0.5f, transform.position.y, -3f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('v');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.B)) {
				Vector3 x = new Vector3 (1f, transform.position.y, -3f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('b');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.N)) {
				Vector3 x = new Vector3 (2.5f, transform.position.y, -3f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('n');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.M)) {
				Vector3 x = new Vector3 (4f, transform.position.y, -3f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('m');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.Comma)) {
				Vector3 x = new Vector3 (5.5f, transform.position.y, -3f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add (',');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.Period)) {
				Vector3 x = new Vector3 (7.0f, transform.position.y, -3f);
				transform.position = x;
				if (space && !flipoff && !flip) {
					lastTenChars.Add ('.');
					if (lastTenChars.Count > 10) {
						lastTenChars.RemoveAt (0);
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.Slash)) {
				Vector3 x = new Vector3 (8.5f, transform.position.y, -3f);
				transform.position = x;
				if (space && !flipoff && !flip) {
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
				spread.enabled = true;
				rest.enabled = false;
				flipmesh.enabled = false;
				flipoffmesh.enabled = false;
				float intakeVal = Random.Range (0f, 1f);
				if (intakeVal <= .2f) {
					intake.Play ();
				} else if (intakeVal <= .4f) {
					intake2.Play ();
				} else if (intakeVal <= .6f) {
					intake3.Play ();
				} else if (intakeVal <= .8f) {
					intake4.Play ();
				} else {
					intake5.Play ();
				}
			}

			if (Input.GetKeyDown (KeyCode.Space) && flip && !space) {
				space = true;
				flipoff = true;
				preserveY = transform.position.y;
				Vector3 x = new Vector3 (transform.position.x, 2f, transform.position.z);
				transform.position = x;
				spread.enabled = false;
				rest.enabled = false;
				flipmesh.enabled = false;
				flipoffmesh.enabled = true;

			}


			if (Input.GetKeyUp (KeyCode.Space)) {
				space = false;
				Vector3 x = new Vector3 (transform.position.x, preserveY, transform.position.z);
				transform.position = x;
				spread.enabled = false;
				rest.enabled = true;
				flipmesh.enabled = false;
				flipoffmesh.enabled = false;
				float outtakeVal = Random.Range (0f, 1f);
				if (outtakeVal <= .5f) {
					outtake.Play ();
				} else {
					outtake2.Play ();
				}

			}

			if (Input.GetKeyUp (KeyCode.Space) && flipoff) {
				space = false;
				Vector3 x = new Vector3 (transform.position.x, preserveY, transform.position.z);
				transform.position = x;
				flipoff = false;
				spread.enabled = false;
				rest.enabled = false;
				flipmesh.enabled = true;
				flipoffmesh.enabled = false;

			}

			if (Input.GetKeyDown (KeyCode.UpArrow) && !space) {
				flip = true;
				//transform.Rotate (new Vector3 (90f, 0f, 0f));
				spread.enabled = false;
				rest.enabled = false;
				flipmesh.enabled = true;
				flipoffmesh.enabled = false;
			}


			if (Input.GetKeyUp (KeyCode.UpArrow) && !space && flip) {
				flip = false;
				//transform.Rotate (new Vector3 (-90f, 0f, 0f));
				flipoff = false;
				spread.enabled = false;
				rest.enabled = true;
				flipmesh.enabled = false;
				flipoffmesh.enabled = false;

			}

			if (Input.GetKeyUp (KeyCode.UpArrow) && space && flip) {
				flip = false;
				//transform.Rotate (new Vector3 (-90f, 0f, 0f));
				flipoff = false;
				spread.enabled = false;
				rest.enabled = true;
				flipmesh.enabled = false;
				flipoffmesh.enabled = false;

			}

			Vector3 w = new Vector3 (randX[0]+.75f, -0.05f, randZ[0]-.75f);
			spot.transform.position = w;
		}
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