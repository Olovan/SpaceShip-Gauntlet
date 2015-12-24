using UnityEngine;
using System.Collections;

public class MissileWeapon : Weapon {

	public float coolDown = .2f;
	float lastTimeFired;
	GameObject owner;

	// Use this for initialization
	void Start () {
		owner = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void fire(uint level, GameObject caller, Vector3 target)
	{
		if (Time.time - lastTimeFired > coolDown)
		{
			GameObject currentMissile = ObjectFactory.createMissile (this.gameObject);
			GameObject closestEnemyToTarget = FindClosestEnemyToPosition(target);
			currentMissile.GetComponent<MissileController>().setTarget(closestEnemyToTarget);
			currentMissile.GetComponent<MissileController>().setOwner(caller);
			lastTimeFired = Time.time;
		}
	}

	GameObject FindClosestEnemyToPosition(Vector3 position)
	{
		if (owner != PlayerController.thePlayer.gameObject)
			return PlayerController.thePlayer.gameObject;
		else
		{
			EnemyHealthManager[] potentialEnemies = FindObjectsOfType<EnemyHealthManager>();
			EnemyHealthManager selectedEnemy = null;
			foreach (EnemyHealthManager enemy in potentialEnemies)
			{
				if(selectedEnemy == null || Vector2.Distance(enemy.transform.position,position) < Vector2.Distance(selectedEnemy.transform.position,position))
				{
					selectedEnemy = enemy;
				}
			}
			if (selectedEnemy != null)
				return selectedEnemy.gameObject;
			else
				return null;
		}
	}
}
