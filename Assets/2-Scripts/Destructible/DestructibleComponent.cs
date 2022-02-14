using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoushi
{
    /// <summary>
    /// Basic class of a Destructible component
    /// Everything which can be destructed and gives xp to the player is here
    /// </summary>
    public abstract class DestructibleComponent : MonoBehaviour
    {
        protected bool isDestroyed = false;

        [SerializeField]
        protected float maxHealth;

        [SerializeField]
        protected float currentHealth;

        [SerializeField]
        protected float scoreToGive;

        /// <summary>
        /// Default Start function
        /// </summary>
        protected virtual void Start()
        {
            this.currentHealth = this.maxHealth;
        }

        /// <summary>
        /// This function is called when a component taking damage amount.
        /// <example> Example(s):
        /// <code>
        ///     component.TakeDamage(5);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage">Damage the component will take</param>
        public virtual void TakeDamage(float damage)
        {
            if (damage < 0)
            {
                return;
            }

            currentHealth = currentHealth - damage;

            if (damage > 0)
            {
                if (currentHealth <= 0)
                {
                    if (!isDestroyed)
                    {
                        isDestroyed = true;
                        Die();
                    }
                }
            }
        }

        /// <summary>
        /// Gives score to the player.
        /// <example> Example(s) :
        /// <code>
        ///     component.GiveScoreToPlayer();
        /// </code>
        /// </example>
        /// </summary>
        protected virtual void GiveScoreToPlayer()
        {
            if (this.scoreToGive <= 0) return;
            // TODO Add score to total
        }

        /// <summary>
        /// Called when the component is destroyed.
        /// <example> Example(s) :
        /// <code>
        ///     component.Die();
        /// </code>
        /// </example>
        /// </summary>
        protected virtual void Die()
        {
            Debug.Log(this.name + " >> Die()");
            this.GiveScoreToPlayer();
        }
    }
}
