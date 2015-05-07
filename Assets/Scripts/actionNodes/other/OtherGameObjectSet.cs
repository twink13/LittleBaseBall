using UnityEngine;
using System.Collections;
using BehaviourMachine;
using System.Collections.Generic;

[NodeInfo ( category = "twink/otherBlackboard/")]
public class OtherGameObjectSet : ActionNode {
	
	public GameObjectVar other;
	public GameObjectVar var;
	public string otherVarName;
	
	// Use this for initialization
	public override void Reset () {
		other = new ConcreteGameObjectVar ();
		var = new ConcreteGameObjectVar ();
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
		
		GameObjectVar otherVar = other.Value.GetComponent<InternalBlackboard>().GetGameObjectVar (otherVarName);
		if (otherVar != null)
		{
			otherVar.Value = var.Value;
		}
		
		return Status.Success;
	}
}
