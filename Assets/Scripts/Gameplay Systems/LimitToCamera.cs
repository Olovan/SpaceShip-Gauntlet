using UnityEngine;
using System.Collections;

public class LimitToCamera : MonoBehaviour {

	float maxVertical;
	float minVertical;

	// Use this for initialization
	void Start () {
		maxVertical = Camera.main.ScreenToWorldPoint (Camera.main.pixelRect.max).y;
		minVertical = Camera.main.ScreenToWorldPoint (Camera.main.pixelRect.min).y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, Mathf.Clamp (transform.position.y, minVertical , maxVertical), transform.position.z);
	}
}
