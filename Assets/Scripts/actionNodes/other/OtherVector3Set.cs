using UnityEngine;
using System.Collections;
using BehaviourMachine;
using System.Collections.Generic;

[NodeInfo ( category = "twink/otherBlackboard/")]
public class OtherVector3Set : ActionNode {

	public GameObjectVar other;
	public Vector3Var var;
	public string varName;

	// Use this for initialization
	public override void Reset () {
		other = new ConcreteGameObjectVar ();
		var = new ConcreteVector3Var ();
	}
	
	public override void OnValidate()
	{
	}
	
	// Update is called once per frame
	public override Status Update () {
		if (other.isNone)
		{
			return Status.Error;
		}
		if (var.isNone)
		{
			return Status.Error;
		}

		Vector3Var otherVar = other.Value.GetComponent<InternalBlackboard>().GetVector3Var (varName);
		if (otherVar != null)
		{
			otherVar.Value = var.Value;
		}

		return Status.Success;
	}
}
