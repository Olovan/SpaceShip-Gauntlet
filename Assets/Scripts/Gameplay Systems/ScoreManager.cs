using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score;
	public static int highScore = 0;

	// Use this for initialization
	void Start () {
		resetScore ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void addScore(int scoreToAdd)
	{
		score += scoreToAdd;
		if (score > highScore)
			highScore = score;
	}

	public static void subtractScore(int scoreToSubtract)
	{
		score -= scoreToSubtract;
		if (score < 0)
			score = 0;
	}
	

	public static void resetScore()
	{
		score = 0;
	}
}
