using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

	public int healthPoints;
	public int scoreValue;
	public bool damageable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void applyDamage(int damage)
	{
		if (damageable)
			healthPoints -= damage;
		if (healthPoints <= 0)
		{
			kill();
		}
	}

	void OnDestroy()
	{
		kill ();
	}

	public void kill()
	{
		healthPoints = 0;
		ScoreManager.addScore (scoreValue);
		Destroy (gameObject);
	}
}
