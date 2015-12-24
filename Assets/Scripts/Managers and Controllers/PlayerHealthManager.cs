using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

	public static int healthPoints;
	public static int maxHealth = 5;

	// Use this for initialization
	void Start () {
		resetHP ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void applyDamage(int damage)
	{
		healthPoints -= damage;
		if (healthPoints < 0)
			kill();
	}

	public static void resetHP()
	{
		healthPoints = maxHealth;
	}

	public static void kill()
	{
		healthPoints = 0;
	}
}
