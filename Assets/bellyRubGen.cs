using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellyRubGen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		char[] sel = generateRandom();
		foreach (char x in sel){
			Debug.Log(x);
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	char[] generateRandom() {
		char[][] keyboard = new char[][] {
			new char[10],
			new char[10],
			new char[10]
		};
		string qz = "qwertyuiopasdfghjkl;zxcvbnm,./";
		int counter = 0;
		for (int i = 0; i < keyboard.Length; i++){
			for (int j = 0; j < keyboard[0].Length; j++){
				keyboard [i][j] = qz [counter++];

			}
		}
		int ranRow = (int)Random.Range (0, keyboard.Length - 1);
		int ranCol = (int)Random.Range (0, keyboard[0].Length - 1);
		return new char[] {keyboard[ranRow][ranCol], keyboard[ranRow][ranCol+1], 
			keyboard[ranRow+1][ranCol], keyboard[ranRow+1][ranCol+1]};
	}
}
