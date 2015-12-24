using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

	public float cooldown = 0;
	public float lastShot = 0;

	public abstract void fire(uint level, GameObject caller, Vector3 target);

}
