using UnityEngine;
using System.Collections;

public static class myInput{

	static float movementAreaCutoffPixel = 100; //

	public static bool Fire()
	{
		if (Input.GetKey (KeyCode.Mouse0))
			return true;
		if (Input.touches.Length > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
			return true;
		return false;
	}

	public static void assignMovementAreaCutoff(int screenPixelWidth, float percentageOfScreen) //assign Percentage of Screen in the X axis devoted to moving the ship up and down
	{
		movementAreaCutoffPixel = screenPixelWidth * percentageOfScreen / 100;
	}
}
