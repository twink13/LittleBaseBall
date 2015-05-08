using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo(  category = "twink/Ngui/")]
public class NguiLabelTextSet : ActionNode {
	
	public GameObjectVar labelOb;
	public StringVar text;

	[System.NonSerialized]
	UILabel m_label = null;
	
	// Use this for initialization
	public override void Reset () {
		labelOb = new ConcreteGameObjectVar ();
		text = new ConcreteStringVar ();
	}
	
	// Update is called once per frame
	public override Status Update () {
		m_label = labelOb.Value.GetComponent<UILabel> ();
		if (!m_label)
		{
			return Status.Error;
		}

		m_label.text = text.Value;
		return Status.Success;
	}
}
