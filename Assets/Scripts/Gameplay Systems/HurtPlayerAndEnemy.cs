using UnityEngine;
using System.Collections;

public class HurtPlayerAndEnemy : MonoBehaviour {

	public GameObject creator;
	public int damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject == creator)
			return;
		else if (other.tag == "Player")
		{
			PlayerHealthManager.applyDamage(damage);
		}
		else if (other.tag == "Enemy")
		{
			other.GetComponent<EnemyHealthManager>().applyDamage(damage);
		}
	}
}
