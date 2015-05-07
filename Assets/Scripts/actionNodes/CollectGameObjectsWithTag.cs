using UnityEngine;
using System.Collections;
using BehaviourMachine;
using System.Collections.Generic;

[NodeInfo ( category = "twink/")]
public class CollectGameObjectsWithTag : ActionNode {
	
	public DynamicList storeList;
	public StringVar tagName;
	
	// Use this for initialization
	public override void Reset () {
		storeList = new ConcreteDynamicList ();
		tagName = new ConcreteStringVar ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		storeList.Clear ();
		GameObject[] bullets = GameObject.FindGameObjectsWithTag (tagName.Value);
		foreach(GameObject bullet in bullets)
		{
			storeList.Add (bullet);
		}
		return Status.Success;
	}
}
