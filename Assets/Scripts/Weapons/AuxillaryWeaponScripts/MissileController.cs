using UnityEngine;
using System.Collections;

public class MissileController : MonoBehaviour {

	public float explosionRadius;
	public int explosionDamage;
	public float ghostTimer;

	GameObject owner;
	GameObject target;
	MissileMovement missileMovementController;

	// Use this for initialization
	void Awake () {
		missileMovementController = GetComponent<MissileMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		ghostTimer -= Time.deltaTime;
		if(target == null && owner == PlayerController.thePlayer.gameObject)
		{
			getClosestNewTarget();
		}
	}

	void getClosestNewTarget()
	{
		EnemyAI[] potentialEnemies = FindObjectsOfType<EnemyAI>();
		EnemyAI selectedEnemy = null;
		foreach (EnemyAI enemy in potentialEnemies)
		{
			if(selectedEnemy == null || Vector2.Distance(enemy.transform.position,transform.position) < Vector2.Distance(selectedEnemy.transform.position,transform.position))
			{
				selectedEnemy = enemy;
			}
		}
		if(selectedEnemy != null)
			missileMovementController.setTarget (selectedEnemy.gameObject);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject != owner && ghostTimer < 0)
		{
			explode();
		}
	}

	void explode()
	{
		Collider2D[] victims = Physics2D.OverlapCircleAll (transform.position, explosionRadius);
		foreach (Collider2D victimCollider in victims)
		{
			EnemyHealthManager victimHPman = victimCollider.GetComponent<EnemyHealthManager>();
			if (victimHPman != null)
			{
				victimHPman.applyDamage(explosionDamage);
			}
		}
		Destroy (gameObject);
	}

	public void setOwner(GameObject newOwner)
	{
		owner = newOwner;
	}

	public void setTarget(GameObject newTarget)
	{
		target = newTarget;
		missileMovementController.setTarget (newTarget);
	}
}
