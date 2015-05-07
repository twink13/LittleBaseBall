using UnityEngine;
using System.Collections;
using BehaviourMachine;
using System.Collections.Generic;

[NodeInfo ( category = "twink/otherBlackboard/")]
public class OtherDynamicListRemove : ActionNode {
	
	public GameObjectVar other;
	public Variable varToRemove;
	public string otherListVarName;
	
	// Use this for initialization
	public override void Reset () {
		other = new ConcreteGameObjectVar ();
		varToRemove = new Variable ();
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
		if (varToRemove.isNone)
		{
			return Status.Error;
		}
		if (other.Value == null)
		{
			return Status.Error;
		}
		
		DynamicList otherListVar = other.Value.GetComponent<InternalBlackboard>().GetDynamicList (otherListVarName);
		if (otherListVar == null)
		{
			return Status.Error;
		}
		otherListVar.Remove (varToRemove.genericValue);
		return Status.Success;
	}
}
