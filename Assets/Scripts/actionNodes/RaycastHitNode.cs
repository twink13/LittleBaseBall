using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo(  category = "twink/action/")]
public class RaycastHitNode : ActionNode {

	[VariableInfo(requiredField = false, nullLabel = "Don't Store")]
	public Vector3Var storePos;
	[VariableInfo(requiredField = false, nullLabel = "Don't Store")]
	public Vector3Var storeNormal;
	[VariableInfo(requiredField = false, nullLabel = "Don't Store")]
	public GameObjectVar storeGameObject;

	// Use this for initialization
	public override void Reset () {
		storePos = new ConcreteVector3Var ();
		storeGameObject = new ConcreteGameObjectVar ();
		storeNormal = new ConcreteVector3Var ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			if (!storePos.isNone)
			{
				storePos.Value = hit.point;
			}
			if (!storeNormal.isNone)
			{
				storeNormal.Value = hit.normal;
			}
			if (!storeGameObject.isNone)
			{
				storeGameObject.Value = hit.collider.gameObject;
			}

			return Status.Success;
		}
		return Status.Failure;
	}
}
