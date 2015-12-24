using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHealthSlider : MonoBehaviour {

	Slider healthSlider;

	// Use this for initialization
	void Start () {
		healthSlider = GetComponent<Slider> ();
		healthSlider.maxValue = PlayerHealthManager.maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		healthSlider.value = PlayerHealthManager.healthPoints;
	}
}
