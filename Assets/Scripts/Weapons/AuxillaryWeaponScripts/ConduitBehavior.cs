using UnityEngine;
using System.Collections;

public abstract class ConduitBehavior : MonoBehaviour {
	public abstract void behavior(ConduitBeamController beamController);
}
