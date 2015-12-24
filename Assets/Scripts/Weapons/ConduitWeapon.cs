using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConduitWeapon : Weapon {

	public float lastShotFiredTime;
	public float shotCooldown = 5;
	public bool stillFiring = false;
	public float targettingRadius = 5;
	public float jumpRadius;

	// Use this for initialization
	void Start () {
		cooldown = shotCooldown;
		lastShotFiredTime = -shotCooldown;
		lastShot = lastShotFiredTime;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void fire(uint level, GameObject caller, Vector3 clickPosition)
	{
		if (!ableToFire())
		{
			return;
		}
		Collider2D[] targets = (Physics2D.OverlapCircleAll (clickPosition, targettingRadius));
		if (targets.Length < 1)
			return;
		lastShotFiredTime = Time.time;
		lastShot = lastShotFiredTime;
		GameObject target = findClosestGameObjectToPosition (clickPosition, targets);
		ConduitBeamSystemManager currentManager = new ConduitBeamSystemManager ();
		ObjectFactory.createConduitBeam(caller, caller.transform.position, target, currentManager);
	}

	bool ableToFire()
	{
		if (stillFiring)
			return false;
		if (Time.time - lastShotFiredTime < shotCooldown)
			return false;
		if (Time.timeScale == 0)
			return false;
		return true;

	}

	GameObject findClosestGameObjectToPosition(Vector2 position, Collider2D[] gameObjectlist)
	{
		GameObject closestObject = null;
		foreach(Collider2D currentObject in gameObjectlist)
		{
			if(closestObject == null || Vector2.Distance(currentObject.transform.position,position) < Vector2.Distance(closestObject.transform.position, position))
				closestObject = currentObject.gameObject;
		}
		return closestObject;
	}
}

