using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Karoushi.AI
{
    /// <summary>
    /// Basic class of the AI
    /// </summary>
    public abstract class AI : MonoBehaviour
    {
        private NavMeshAgent agent;
        private Animator anim;
        protected State currentState;

        /// <summary>
        /// Default Start function
        /// </summary>
        protected virtual void Start()
        {
            agent = this.GetComponent<NavMeshAgent>();
            anim = this.GetComponent<Animator>();
        }

        /// <summary>
        /// Default Update function
        /// </summary>
        private void Update()
        {
            if (currentState != null)
            {
                currentState = currentState.Process();
            } else
            {
                DestructibleComponent component = this.GetComponent<DestructibleComponent>();
                Debug.LogWarning("You forgot to override the Start() method and set a default state for "+component.name);
            }
        }
    }
}
