using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

	public static int gridWidth = 10;
	public static int gridHeight = 11;

	public GameObject[] blocks;

	public static Transform[,] grid = new Transform[gridWidth, gridHeight];

	// Use this for initialization
	void Start () {
		spawnBlocks();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// Start of clearing blocks
	public void DeleteBlockAt(int y) {
		for (int x = 0; x < gridWidth; x++) {
			Destroy(grid[x, y].gameObject);

			grid[x, y] = null;
		}
	}

	public void MoveRowDown(int y) {
		for (int x = 0; x < gridWidth; x++) {
			if (grid[x, y] != null) {
				grid[x, y - 1] = grid[x, y];
				grid[x, y] = null;
				grid[x, y - 1].position += new Vector3(0, -1, 0);
			}
		}
	}

	public void MoveAllRowsDown(int y) {
		for (int i = y; i < gridHeight; i++) {
			MoveRowDown(i);
		}
	}

	// Add a way to check how to clear rows
	public void DeleteRow() {
		for (int y = 0; y < gridHeight; y++) {
			if () {
				DeleteBlockAt(y);
				MoveAllRowsDown(y + 1);
				y--;
			}
		}
	}

	/* UH FIX THIS SO THAT IT PUTS BLOCKS DOWN
	public void MoveBlockDown(int x, int y) {
		if (grid[x, y] != null) {
				grid[x, y - 1] = grid[x, y];
				grid[x, y] = null;
				grid[x, y - 1].position += new Vector3(0, -1, 0);
		}
	}
	*/

	// End!


	public void UpdateGrid(BlockBehavior block) {
		for (int y = 0; y < gridHeight; y++) {
			for (int x = 0; x < gridWidth; x++) {
				if (grid[x, y] != null) {
					if (grid[x, y].parent == block.transform) {
						grid[x, y] = null;
					}
				}
			}
		}

		foreach (Transform blo in block.transform) {
			Vector2 pos = Round(blo.position);

			if (pos.y < gridHeight) {
				grid[(int)pos.x, (int)pos.y] = blo;
			}
		}
	}

	public Transform GetTransformAtGridPosition(Vector2 pos) {
		if (pos.y > gridHeight - 1)
		{
			return null;
		} else {
			return grid[(int)pos.x, (int)pos.y];
		}
	}

	public bool CheckIsInsideGrid(Vector2 pos) {
		return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
	}

	public Vector2 Round(Vector2 pos) {
		return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
	}

	public void spawnBlocks() {
		GameObject element = blocks[Random.Range(0, blocks.Length)];
		Vector2 spawnPos = new Vector2(5.0f, 12f);
		Quaternion spawnRot = Quaternion.identity;
		GameObject SpawnObject = (GameObject)Instantiate(element, spawnPos, spawnRot);
	}
}
