using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo ( category = "twink/action/gameobject/")]
public class FindRigidbodyGameObjectFromParent : ActionNode {

	public GameObjectVar gameObject;
	public GameObjectVar storeTarget;

	// Use this for initialization
	public override void Reset () {
		gameObject = new ConcreteGameObjectVar ();
		storeTarget = new ConcreteGameObjectVar ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		GameObject tempGameObject = gameObject.Value;
		Rigidbody rigidbody = tempGameObject.GetComponent<Rigidbody>();
		Debug.Log ("1111111111");
		while(rigidbody == null)
		{
			Debug.Log ("22222222222222222");
			if (tempGameObject.transform.parent == null)
			{
				Debug.Log ("333333333333");
				return Status.Failure;
			}
			rigidbody = tempGameObject.transform.parent.gameObject.GetComponent<Rigidbody>();
			if (rigidbody != null)
			{
				Debug.Log ("44444444444444444");
				break;
			}
		}
		Debug.Log ("5555555555");
		storeTarget.Value = rigidbody.gameObject;
		return Status.Success;
	}
}
