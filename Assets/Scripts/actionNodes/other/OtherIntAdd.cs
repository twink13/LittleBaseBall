using UnityEngine;
using System.Collections;
using BehaviourMachine;
using System.Collections.Generic;

[NodeInfo ( category = "twink/otherBlackboard/")]
public class OtherIntAdd : ActionNode {
	
	public GameObjectVar other;
	public IntVar var;
	public string otherVarName;
	
	// Use this for initialization
	public override void Reset () {
		other = new ConcreteGameObjectVar ();
		var = new ConcreteIntVar ();
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
		if (other.Value == null)
		{
			return Status.Error;
		}
		
		IntVar otherVar = other.Value.GetComponent<InternalBlackboard>().GetIntVar (otherVarName);
		if (otherVar == null)
		{
			return Status.Error;
		}
		otherVar.Value += var.Value;
		return Status.Success;
	}
}
