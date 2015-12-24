using UnityEngine;
using System.Collections;

public class ObjectFactory : MonoBehaviour {

	static ObjectFactory instance;
	public GameObject laserBeam;
	public GameObject blasterBeam;
	public GameObject missile;
	public GameObject conduitBeam;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static GameObject createLaserbeam(Vector3 position)
	{
		return (GameObject)Instantiate( instance.laserBeam, position, Quaternion.identity);
	}

	public static GameObject createBlasterBeam(Vector3 position)
	{
		return (GameObject)Instantiate(instance.blasterBeam, position, Quaternion.identity);
	}

	public static GameObject createMissile(GameObject caller)
	{
		return (GameObject)Instantiate (instance.missile, caller.transform.position, caller.transform.rotation);
	}

	public static GameObject createConduitBeam(GameObject creator, Vector3 origin, GameObject target, ConduitBeamSystemManager manager)
	{
		GameObject beam = (GameObject)Instantiate(instance.conduitBeam, origin, Quaternion.identity);
		beam.GetComponent<ConduitBeamController> ().assignValues (creator, origin, target, Time.time, manager);
		manager.targets.Add (target);
		return beam;
	}
}
