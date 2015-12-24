using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UiWeaponCooldownBar : MonoBehaviour {

	Slider slider;
	Weapon playerWeapon;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		slider.minValue = 0;
		if(playerWeapon != null)
			slider.maxValue = playerWeapon.cooldown;
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.time - playerWeapon.lastShot;
	}

	public void assignWeapon()
	{
		playerWeapon = FindObjectOfType<PlayerController> ().currentWeapon;
		if(playerWeapon != null)
			slider.maxValue = playerWeapon.cooldown;
	}

	public void assignWeapon(Weapon iWeapon)
	{
		playerWeapon = iWeapon;
		slider = GetComponent<Slider> ();
		if(slider != null && playerWeapon != null)
			slider.maxValue = playerWeapon.cooldown;
	}
}
