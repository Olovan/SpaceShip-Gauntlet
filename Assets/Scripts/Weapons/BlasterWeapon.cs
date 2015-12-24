using UnityEngine;
using System.Collections;

public class BlasterWeapon : Weapon {

	float cooldownTime = 0.5f;
	float cooldownCounter = 0;
	float bulletSpeed = 10;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		cooldownCounter -= Time.deltaTime;
	}

	public override void fire(uint level, GameObject caller, Vector3 target)
	{
		if(cooldownCounter < 0)
		{
			GameObject currentBullet = ObjectFactory.createBlasterBeam(new Vector3 (caller.transform.position.x, caller.transform.position.y, 0));
			Rigidbody2D currentBulletRigidBody = currentBullet.GetComponent<Rigidbody2D>();
			currentBullet.GetComponent<HurtPlayerAndEnemy>().creator = caller;
			target = new Vector3 (target.x, target.y, 0);
			target = target - caller.transform.position;
			currentBulletRigidBody.velocity = target.normalized * bulletSpeed;
			cooldownCounter = cooldownTime;
		}
	}
}
