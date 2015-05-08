//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {
	
	/// <summary>
	/// Sets the rigidbody velocity.
	/// </summary>
	[NodeInfo ( category = "twink/action/Rigidbody/",
	           icon = "Rigidbody",
	           description = "Sets the rigidbody isFreeze",
	           url = "http://docs.unity3d.com/Documentation/ScriptReference/Rigidbody-velocity.html")]
	public class SetFreezeRotationRotation : ActionNode {
		
		/// <summary>
		/// The game object that has a rigidbody in it.
		/// </summary>
		[VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object that has a rigidbody in it")]
		public GameObjectVar gameObject;
		
		/// <summary>
		/// isFreeze.
		/// </summary>
		[VariableInfo(requiredField = false, nullLabel = "Don't Use", tooltip = "set value")]
		public BoolVar isFreeze;
		
		[System.NonSerialized]
		Rigidbody m_Rigidbody = null;
		
		public override void Reset () {
			gameObject = new ConcreteGameObjectVar(this.self);
			isFreeze = new ConcreteBoolVar();
		}
		
		public override Status Update () {
			// Get the rigidbody
			if (m_Rigidbody == null || m_Rigidbody.gameObject != gameObject.Value)
				m_Rigidbody = gameObject.Value != null ? gameObject.Value.GetComponent<Rigidbody>() : null;
			
			// Validate members?
			if  (m_Rigidbody == null)
				return Status.Error;
			
			// Set freezeRotation
			m_Rigidbody.freezeRotation = isFreeze.Value;
			
			return Status.Success;
		}
	}
}