using UnityEngine;
using System.Collections;

public class MoveUpAndDown : MonoBehaviour {

	public float length;
	public float frequency;
	Vector2 startingPos;


	// Use this for initialization
	void Start () {
		startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2(transform.position.x, startingPos.y + Mathf.Sin (2 * Mathf.PI * Time.time / frequency) * length);
	}
}
