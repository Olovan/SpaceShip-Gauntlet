using UnityEngine;
using System.Collections;

public class DestroyOnTriggerEnter : MonoBehaviour {

	HurtPlayerAndEnemy hurtScript;
	public float ghostTimer;
	public bool ignoreWeapons;

	// Use this for initialization
	void Start () {
		hurtScript = GetComponent<HurtPlayerAndEnemy> ();
	}
	
	// Update is called once per frame
	void Update () {
		ghostTimer -= Time.deltaTime;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(hurtScript != null && other.gameObject == hurtScript.creator || ghostTimer > 0 || ignoreWeapons && (other.tag != "Enemy" || other.tag != "Player") )
		{
			return;
		}
		Destroy (gameObject);
	}
}
