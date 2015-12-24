using UnityEngine;
using System.Collections;

public class LaserWeapon : Weapon {

	public int damageDealt;

	bool firing;
	float laserLength = 100;
	float laserWidth = 0.2f;
	LineRenderer laserBeam;
	BoxCollider2D laserCollider;
	float fireCooldownTime = 0.2f;
	float cooldownCounter = 0;
	float fireDuration = 0.1f;
	float fireCounter = 0;
	bool ableToFire = false;

	// Use this for initialization
	void Start () {
		laserBeam = (ObjectFactory.createLaserbeam (transform.position)).GetComponent<LineRenderer>();
		laserBeam.SetVertexCount (2);
		laserBeam.SetWidth (laserWidth, laserWidth);
		laserCollider = laserBeam.GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!firing)
		{
			laserBeam.enabled = false;
			laserCollider.enabled = false;
		}

		firing = false;

		cooldownCounter -= Time.deltaTime;
		
		if(cooldownCounter < 0 && !ableToFire)
		{
			ableToFire = true;
			fireCounter = fireDuration;
		}
	}

	public override void fire(uint level, GameObject caller, Vector3 target)
	{
		if (ableToFire) 
		{
			laserBeam.GetComponent<HurtPlayerAndEnemy>().creator = caller;
			firing = true;
			laserBeam.enabled = true;
			laserCollider.enabled = true;
			target = new Vector3 (target.x, target.y, caller.transform.position.z);
			Vector3 laserVector = (target - caller.transform.position).normalized * laserLength;
			target = new Vector3 (caller.transform.position.x + laserVector.x, caller.transform.position.y + laserVector.y, caller.transform.position.z);
			laserBeam.SetPosition (0, caller.transform.position);
			laserBeam.SetPosition (1, target);
			laserCollider.size = new Vector2 (laserLength, laserWidth);
			laserCollider.offset = new Vector2 (laserLength/2, 0);
			laserCollider.transform.position = caller.transform.position;
			laserCollider.transform.rotation = Quaternion.Euler(0,0, Mathf.Atan2(laserVector.y,laserVector.x) * Mathf.Rad2Deg);
			fireCounter -= Time.deltaTime;
			if (fireCounter < 0)
			{
				cooldownCounter = fireCooldownTime;
				ableToFire = false;
			}
		}


	}

	void OnDestroy()
	{
		if(laserBeam != null)
		{
			Destroy (laserBeam.gameObject);
		}
	}
	
}
