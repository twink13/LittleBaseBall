using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo(  category = "LittleBaseBall/")]
public class SetPowerText : ActionNode {
	
	public FloatVar power;
	public StringVar text;
	
	[System.NonSerialized]
	UILabel m_label = null;
	
	// Use this for initialization
	public override void Reset () {
		power = new ConcreteFloatVar ();
		text = new ConcreteStringVar ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		text.Value = "power: " + Mathf.Floor (power.Value);
		return Status.Success;
	}
}
