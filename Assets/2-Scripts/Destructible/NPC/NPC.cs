using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoushi
{
    /// <summary>
    /// Basic class of an abstracted NPC
    /// </summary>
    public abstract class NPC : DestructibleComponent
    {

        /// <summary>
        /// Default Start function
        /// </summary>
        protected override void Start()
        {
            base.Start();
            SetKinematic(true);
        }

        /// <summary>
        /// Active or not the ragdoll mode.
        /// <example> Example(s) :
        /// <code>
        ///     npc.SetKinematic(false); // Active the ragdoll
        /// </code>
        /// </example>
        /// </summary>
        void SetKinematic(bool newValue)
        {
            Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in bodies)
            {
                rb.isKinematic = newValue;
            }
        }

        /// <summary>
        /// Called when the component is destroyed.
        /// <example> Example(s) :
        /// <code>
        ///     npc.Die();
        /// </code>
        /// </example>
        /// </summary>
        protected override void Die()
        {
            // Call upper Die methods
            base.Die();

            // Active the ragdoll
            SetKinematic(false);
            GetComponent<Animator>().enabled = false;

            // Destroy the body after 10 seconds
            Destroy(gameObject, 10);
        }

    }
}
