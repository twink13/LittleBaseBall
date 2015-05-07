using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo(  category = "twink/action/")]
public class Vector3Reflect : ActionNode {
	
	public Vector3Var inDir;
	public Vector3Var inNormal;
	
	[VariableInfo(canBeConstant = false)]
	public Vector3Var outDir;

	// Use this for initialization
	public override void Reset () {
		inDir = new ConcreteVector3Var ();
		inNormal = new ConcreteVector3Var ();
		outDir = new ConcreteVector3Var ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		outDir.Value = Vector3.Reflect (inDir.Value, inNormal.Value);
		return Status.Success;
	}
}
