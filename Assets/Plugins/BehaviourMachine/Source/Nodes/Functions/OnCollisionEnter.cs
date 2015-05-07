//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
    /// </summary>
    [NodeInfo(  category = "Function/",
                icon = "Function",
                description = "OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider",
                url = "http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.OnCollisionEnter.html")]
    public class OnCollisionEnter : FunctionNode {

        /// <summary>
        /// Stores the other game object.
        /// </summary>
        [VariableInfo(requiredField = false, nullLabel = "Don't Store", canBeConstant = false, tooltip = "Stores the other game object")]
		public GameObjectVar other;
		[VariableInfo(requiredField = false, nullLabel = "Don't Store", canBeConstant = false)]
		public Vector3Var contactNormal;
		[VariableInfo(requiredField = false, nullLabel = "Don't Store", canBeConstant = false)]
		public Vector3Var contactPosition;

        public override void OnEnable () {
            if (this.enabled) {
                this.blackboard.onCollisionEnter += CollisionEnter;
                m_Registered = true;
            }
        }

        public override void OnDisable () {
            this.blackboard.onCollisionEnter -= CollisionEnter;
            m_Registered = false;
        }

        /// <summary>
        /// Callback registered to get blackboard.onCollisionEnter events.
        /// </summary>
        void CollisionEnter (Collision collision) {
			other.Value = collision.gameObject;
			contactNormal.Value = collision.contacts [0].normal;
			contactPosition.Value = collision.contacts [0].point;

            // Tick children
            this.OnTick();
        }

        public override void Reset () {
            base.Reset();
			other = new ConcreteGameObjectVar();
			contactNormal = new ConcreteVector3Var ();
			contactPosition = new ConcreteVector3Var ();
        }
    }
}