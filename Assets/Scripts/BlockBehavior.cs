using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour {

	float fall = 0;
	public float fallSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		CheckUserInput();

	}

	//Assign controls to arrow keys
	void CheckUserInput() {
		
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			transform.position += new Vector3(1, 0, 0);

			if (CheckIsValidPosition()) {
				FindObjectOfType<Game>().UpdateGrid(this);
			} else {
				transform.position += new Vector3(-1, 0, 0);
			}
		}
	    else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			transform.position += new Vector3(-1, 0, 0);
			
			if (CheckIsValidPosition()) {
				FindObjectOfType<Game>().UpdateGrid(this);
			} else {
				transform.position += new Vector3(1, 0, 0);
			}
		}
         else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.Rotate(0, 0, 90);

			if (CheckIsValidPosition()) {
				FindObjectOfType<Game>().UpdateGrid(this);
			} else {
				transform.Rotate(0, 0, -90);
			}
		}
		else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallSpeed) {
			transform.position += new Vector3(0, -1, 0);

			if (CheckIsValidPosition()) {
				FindObjectOfType<Game>().UpdateGrid(this);
			} else {
				transform.position += new Vector3(0, 1, 0);

				//FindObjectOfType<Game>().MoveBlockDown((int)transform.position.x, (int)transform.position.y);

				enabled = false;

				FindObjectOfType<Game>().spawnBlocks();
			}

			fall = Time.time;
		}
	}

	bool CheckIsValidPosition() {

		foreach (Transform mino in transform) 	{

			Vector2 pos = FindObjectOfType<Game>().Round(mino.position);

			if (FindObjectOfType<Game>().CheckIsInsideGrid(pos) == false) {
				return false;
			}

			if (FindObjectOfType<Game>().GetTransformAtGridPosition(pos) != null && FindObjectOfType<Game>().GetTransformAtGridPosition(pos).parent != transform) {
				return false;
			}
		}

		return true;
	}
}
