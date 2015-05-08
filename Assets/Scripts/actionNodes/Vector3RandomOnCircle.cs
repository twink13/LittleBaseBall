using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo(  category = "twink/action/")]
public class Vector3RandomOnCircle : ActionNode {
	
	[VariableInfo(canBeConstant = false)]
	public Vector3Var storeDir;
	
	public bool useX;
	public bool useY;
	public bool useZ;
	
	// Use this for initialization
	public override void Reset () {
		storeDir = new ConcreteVector3Var ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		storeDir.Value = Random.onUnitSphere;
		if (useX && useY)
		{
			storeDir.Value = new Vector3(storeDir.Value.x, storeDir.Value.y, 0);
		}
		else if(useY && useZ)
		{
			storeDir.Value = new Vector3(0, storeDir.Value.y, storeDir.Value.z);
		}
		else if(useX && useZ)
		{
			storeDir.Value = new Vector3(storeDir.Value.x, 0, storeDir.Value.z);
		}
		else
		{
			return Status.Error;
		}
		storeDir.Value.Normalize();
		return Status.Success;
	}
}
