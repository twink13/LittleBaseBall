using UnityEngine;
using System.Collections;
using BehaviourMachine;
using System.Collections.Generic;

[NodeInfo ( category = "twink/")]
public class InitWayPoints : ActionNode {
	
	public DynamicList storeList;
	public Vector3Var speed;
	public IntVar maxHp;
	public LayerMask layers;
	
	// Use this for initialization
	public override void Reset () {
		storeList = new ConcreteDynamicList ();
		speed = new ConcreteVector3Var ();
		maxHp = new ConcreteIntVar ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		storeList.Clear ();

		RaycastHit hit;
		Vector3 lastPos = self.transform.position;
		Vector3 tempSpeed = speed.Value;
		float speedDistance = tempSpeed.magnitude * 20;
		Debug.Log("speedDistance = " + speedDistance);
		for (int i = 0; i < maxHp.Value; i++)
		{
			Debug.Log("i = " + i);
			Ray ray = new Ray(lastPos, tempSpeed);
			if (Physics.Raycast(ray, out hit, 10.0f, layers))
			{
				int posNum = Mathf.FloorToInt(hit.distance / speedDistance);
				Debug.Log("posNum = " + posNum);
				Debug.Log("hit.distance = " + hit.distance);
				for (int j = 0; j < posNum; j++)
				{
					Vector3 tempPos = lastPos + tempSpeed*20;
					Debug.Log("tempPos = " + tempPos);
					ConcreteVector3Var tempVar = new ConcreteVector3Var();
					tempVar.Value = tempPos;
					storeList.Add(tempVar);
					lastPos = tempPos;
				}
				tempSpeed = Vector3.Reflect (tempSpeed, hit.normal);
				lastPos = hit.point;
			}
		}
		return Status.Success;
	}
}
