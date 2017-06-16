using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static int gridWidth = 10;
	public static int gridHeight = 11;

	public GameObject[] blocks;

	// Use this for initialization
	void Start () {
		spawnBlocks();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool CheckIsInsideGrid(Vector2 pos) {
		return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
	}

	public Vector2 Round(Vector2 pos) {
		return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
	}

	public void spawnBlocks() {
		GameObject element = blocks[Random.Range(0, blocks.Length)];
		Vector2 spawnPos = new Vector2(5.0f, 11f);
		Quaternion spawnRot = Quaternion.identity;
		GameObject SpawnObject = (GameObject)Instantiate(element, spawnPos, spawnRot);
	}
}
