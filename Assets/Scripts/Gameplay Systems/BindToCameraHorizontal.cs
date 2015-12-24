using UnityEngine;
using System.Collections;

public class BindToCameraHorizontal : MonoBehaviour {

	public bool boundToRightSide;
	public float offsetFromSide;

	float leftX;
	float rightX;

	// Use this for initialization
	void Start () {
		leftX = Camera.main.ScreenToWorldPoint (Camera.main.pixelRect.min).x;
		rightX = Camera.main.ScreenToWorldPoint (Camera.main.pixelRect.max).x;
	}
	
	// Update is called once per frame
	void Update () {

		leftX = Camera.main.ScreenToWorldPoint (Camera.main.pixelRect.min).x;
		rightX = Camera.main.ScreenToWorldPoint (Camera.main.pixelRect.max).x;
		transform.position = boundToRightSide ? new Vector3 (rightX + offsetFromSide, transform.position.y, transform.position.z) : new Vector3 (leftX + offsetFromSide, transform.position.y, transform.position.z);
	}
}
