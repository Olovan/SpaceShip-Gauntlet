using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {

	public static PlayerController thePlayer;
	public float playerSpeed = 10;
	public float vertPlayerSpeed = 5;
	public string weaponTypeName;
	public Weapon currentWeapon;
	Rigidbody2D myRigidBody;

	float maxVertical;
	float minVertical;

	// Use this for initialization
	void Start () {
		thePlayer = this;
		myRigidBody = GetComponent<Rigidbody2D> ();
		myRigidBody.velocity = new Vector2 (playerSpeed, 0);
		FindObjectOfType<UiWeaponCooldownBar> ().assignWeapon (currentWeapon);
		maxVertical = Camera.main.ScreenToWorldPoint (Camera.main.pixelRect.max).y;
		minVertical = Camera.main.ScreenToWorldPoint (Camera.main.pixelRect.min).y;
		//currentWeapon = gameObject.AddComponent<BlasterWeapon>();
	}
	
	// Update is called once per frame
	void Update () {
		if(myInput.Fire())
		{
			shootGuns();
		}

		float vertMovement = Input.GetAxis ("Vertical") * vertPlayerSpeed;
		myRigidBody.velocity = new Vector2 (myRigidBody.velocity.x, vertMovement);

		transform.position = new Vector3 (transform.position.x, Mathf.Clamp (transform.position.y, minVertical , maxVertical), transform.position.z);
	}

	void shootGuns()
	{
		currentWeapon.fire (0, this.gameObject, Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
}
