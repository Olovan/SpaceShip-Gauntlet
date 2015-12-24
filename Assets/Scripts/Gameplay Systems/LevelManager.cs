using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void restartLevel()
	{
		Application.LoadLevel (Application.loadedLevel);
	}
}
