using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	public float xOffset;
	public float yAnchor = 0;
	public float zAnchor = -10;
	public PlayerController player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x + xOffset, yAnchor, zAnchor);
	}
}
