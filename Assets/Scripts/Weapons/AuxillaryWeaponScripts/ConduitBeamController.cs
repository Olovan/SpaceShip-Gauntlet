using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ConduitBeamController : MonoBehaviour {

	public float beamLifeTime = 1;
	public float beamSpeed = 1;
	public float jumpRadius = 0.1f;

	GameObject creator;
	ConduitBeamSystemManager manager;
	LineRenderer lineRenderer;
	float startTime;
	GameObject target;
	Vector3 originPosition;
	Vector3 frontPosition;
	Vector3 backPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target == null || target == creator)
		{
			selfDestruct();
			return;
		}
		frontPosition = target.transform.position;
		backPosition = Vector3.Lerp(backPosition,frontPosition, beamSpeed * (Time.time - startTime) / Vector3.Distance(backPosition,frontPosition));
		lineRenderer.SetPosition (0, backPosition);
		lineRenderer.SetPosition (1, frontPosition);
		if (Vector3.Distance(backPosition,frontPosition) < .1)
		{
			conduitHit();
		}
	}

	public void assignValues(GameObject iCaller, Vector3 iOriginPosition, GameObject iTarget, float iStartTime, ConduitBeamSystemManager iManager)
	{
		creator = iCaller;
		originPosition = iOriginPosition;
		backPosition = originPosition;
		target = iTarget;
		manager = iManager;
		startTime = Time.time;
		lineRenderer = GetComponent<LineRenderer> ();
	}

	public void duplicate()
	{
		Collider2D[] targets = (Physics2D.OverlapCircleAll (target.transform.position, jumpRadius));
		if (targets.Length < 1)
			return;
		foreach (Collider2D jumpTarget in targets)
		{
			if(!manager.targets.Contains(jumpTarget.gameObject) && jumpTarget.gameObject != creator)
			{
				ObjectFactory.createConduitBeam(creator,frontPosition,jumpTarget.gameObject,manager);
			}

		}
	}

	public void selfDestruct()
	{
		Destroy(gameObject);
	}

	public void conduitHit() //Check if there is a custom behavior on the object and if there isn't then just destroy it and duplicate
	{
		ConduitBehavior behaviorScript = target.GetComponent<ConduitBehavior> ();
		if (behaviorScript != null) {
			behaviorScript.behavior(this);
		} else {
			duplicate ();
			Destroy (target.gameObject);
			selfDestruct ();
		}
	}
}



public class ConduitBeamSystemManager {
	public List<GameObject> targets;

	public ConduitBeamSystemManager()
	{
		targets = new List<GameObject>();
	}
}
