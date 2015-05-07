using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo(  category = "twink/action/")]
public class RaycastHitMouse : ActionNode {
	[VariableInfo(requiredField = false, nullLabel = "Don't Store")]
	public Vector3Var hitpos;
	[VariableInfo(requiredField = false, nullLabel = "Don't Store")]
	public GameObjectVar hitedGameObjectStore;
	[VariableInfo(requiredField = false, nullLabel = "Don't Store")]
	public Vector3Var storeNormal;
	
	// Use this for initialization
	public override void Reset () {
		hitpos = new ConcreteVector3Var ();
		hitedGameObjectStore = new ConcreteGameObjectVar ();
		storeNormal = new ConcreteVector3Var ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit))
		{
			if (!hitpos.isNone)
			{
				hitpos.Value = hit.point;
			}
			if (!storeNormal.isNone)
			{
				storeNormal.Value = hit.normal;
			}
			if (!hitedGameObjectStore.isNone)
			{
				hitedGameObjectStore.Value = hit.collider.gameObject;
			}
			
			return Status.Success;
		}
		return Status.Failure;
	}
}
