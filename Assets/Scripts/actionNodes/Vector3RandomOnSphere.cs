using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo(  category = "twink/action/")]
public class Vector3RandomOnSphere : ActionNode {
	
	[VariableInfo(canBeConstant = false)]
	public Vector3Var storeDir;
	
	// Use this for initialization
	public override void Reset () {
		storeDir = new ConcreteVector3Var ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		storeDir.Value = Random.onUnitSphere;
		return Status.Success;
	}
}
