using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUiUpdater : MonoBehaviour {

	Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = ScoreManager.score.ToString();
	}
}
