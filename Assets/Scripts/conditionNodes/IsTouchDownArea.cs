using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo ( category = "twink/conditions/")]
public class IsTouchDownArea : ConditionNode {

	public override void Reset()
	{
	}
	
	public override Status Update()
	{
		if (!Input.GetMouseButton(0))
		{
			return Status.Failure;
		}
		float height = Screen.height;
		if (Input.mousePosition.y < height / 2)
		{
			if (onSuccess.id != 0)
			{
				owner.root.SendEvent(onSuccess.id);
			}
			return Status.Success;
		}
		return Status.Failure;
	}
}
