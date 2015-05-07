using UnityEngine;
using System.Collections;
using BehaviourMachine;
using System.Collections.Generic;

[NodeInfo ( category = "twink/")]
public class DynamicListGetAsVector3 : ActionNode {
	
	public DynamicList list;
	public IntVar index;
	public Vector3Var storeObject;
	
	// Use this for initialization
	public override void Reset () {
		list = new ConcreteDynamicList ();
		index = new ConcreteIntVar ();
		storeObject = new ConcreteVector3Var ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		storeObject.Value = (list [index] as ConcreteVector3Var).Value;
		return Status.Success;
	}
}
