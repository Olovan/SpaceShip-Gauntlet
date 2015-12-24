using UnityEngine;
using System.Collections;

public class MissileMovement : MonoBehaviour {


	public float speed;
	public float turnSpeed;

	GameObject target;
	Rigidbody2D myRigidBody;

	// Use this for initialization
	void Start () {
		//player = FindObjectOfType<PlayerController> ();
		myRigidBody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) 
		{
			lookTowards (target.transform.position);
		}
		myRigidBody.velocity = transform.right * speed;
	}



	void lookTowards(Vector3 target)
	{
		float angle = findLookAngle (target);
		transform.rotation = Quaternion.Euler (0, 0, Mathf.Lerp(transform.rotation.eulerAngles.z, angle, turnSpeed / Mathf.Abs(transform.rotation.eulerAngles.z - angle) * Time.deltaTime));
	}

	float findLookAngle(Vector3 target)
	{
		target = target - transform.position;
		float angle = Mathf.Atan2 (target.normalized.y, target.normalized.x) * Mathf.Rad2Deg;
		if (angle - transform.rotation.eulerAngles.z > 180)
			angle -= 360;
		if (angle - transform.rotation.eulerAngles.z < -180)
			angle += 360;
		return angle;
	}

	public void setTarget(GameObject newTarget)
	{
		target = newTarget;
	}
}
