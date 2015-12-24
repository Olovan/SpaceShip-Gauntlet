using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public float speed;
	public float targettingRange;

	Rigidbody2D myRigidBody;
	Weapon myWeapon;

	// Use this for initialization
	void Start () {
		myRigidBody = GetComponent<Rigidbody2D> ();
		myRigidBody.velocity = new Vector2 (-1 * speed, 0);
		transform.rotation = Quaternion.Euler (0, 0, 180);
		myWeapon = gameObject.AddComponent<BlasterWeapon> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Physics2D.OverlapCircle(transform.position, targettingRange, 256))
			myWeapon.fire (0, this.gameObject, PlayerController.thePlayer.transform.position);
	}
}
