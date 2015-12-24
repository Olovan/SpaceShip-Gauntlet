using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {

	public float secondsToDestruction = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		secondsToDestruction -= Time.deltaTime;
		if (secondsToDestruction < 0)
			Destroy (gameObject);
	}
}
