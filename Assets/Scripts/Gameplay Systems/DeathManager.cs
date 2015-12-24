using UnityEngine;
using System.Collections;

public class DeathManager : MonoBehaviour {

	public GameObject gameOverScreen;

	// Use this for initialization
	void Start () {
		gameOverScreen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if( PlayerHealthManager.healthPoints <= 0 )
		{
			playerDeath();
		}
	}

	void playerDeath()
	{
		gameOverScreen.SetActive (true);
		Time.timeScale = 0;
	}
}
