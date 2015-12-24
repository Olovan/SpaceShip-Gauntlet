using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public float spawnCooldown = 0.5f;
	float lastSpawnTime;
	public static float cameraTopY;
	public static float cameraBottomY;

	public GameObject enemyShip1;

	// Use this for initialization
	void Start () {
		cameraTopY = Camera.main.ScreenToWorldPoint(new Vector3 (0,Camera.main.pixelHeight,0)).y;
		cameraBottomY = Camera.main.ScreenToWorldPoint(new Vector3 (0,0,0)).y;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastSpawnTime > spawnCooldown)
		{
			Instantiate (enemyShip1, transform.position, Quaternion.identity);
			lastSpawnTime = Time.time;
			randomlyRelocate();
		}
	}

	void randomlyRelocate()
	{
		float newY = Random.Range (cameraBottomY, cameraTopY);
		transform.position = new Vector3 (transform.position.x, newY, transform.position.z);
	}
}
