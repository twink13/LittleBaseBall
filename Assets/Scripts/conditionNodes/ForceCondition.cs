using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo ( category = "twink/conditions/")]
public class ForceCondition : ConditionNode {
	public BoolVar setBool;

	public override void Reset()
	{
		setBool = new ConcreteBoolVar ();
	}

	public override Status Update()
	{
		if (setBool.Value == true)
		{
			return Status.Success;
		}
		return Status.Failure;
	}
}
