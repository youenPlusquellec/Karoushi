using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoushi {

    /// <summary>
    /// Basic class of a Player
    /// </summary>
    public abstract class Player : MonoBehaviour
    {
        protected bool isDead = false;
        protected bool isEnraged = false;
        protected Weapon weapon;

        [SerializeField]
        protected float maxHealth;

        [SerializeField]
        protected float currentHealth;

        [SerializeField]
        protected float maxRage;

        [SerializeField]
        protected float currentRage;

        [SerializeField]
        protected float attack;

        [SerializeField]
        [Tooltip("The rage spent per second on rage mode")]
        protected float ragePerSecond;

        /// <summary>
        /// Default Start function
        /// </summary>
        protected virtual void Start()
        {
            this.currentHealth = this.maxHealth;
            this.currentRage = 0;
            if (this)
            {
                this.weapon = GetComponentInChildren<Weapon>();
                if (this.weapon)
                    this.weapon.EnableCollider(false);
            }
        }

        /// <summary>
        /// Default Update function
        /// </summary>
        protected void Update()
        {
            CheckForEnrage();
        }

        /// <summary>
        /// Created to be called by an animation event.
        /// Called when the attack animation starts.
        /// <example> Example(s):
        /// <code>
        ///     this.AttackAnimationStart();
        /// </code>
        /// </example>
        /// </summary>
        public void AttackAnimationStart()
        {
            this.weapon.EnableCollider(true);
        }

        /// <summary>
        /// Created to be called by an animation event.
        /// Called when the attack animation starts.
        /// <example> Example(s):
        /// <code>
        ///     this.AttackAnimationEnd();
        /// </code>
        /// </example>
        /// </summary>
        public void AttackAnimationEnd()
        {
            this.weapon.EnableCollider(false);
        }

        /// <summary>
        /// This function is called when a player attack a destructible component.
        /// <example> Example(s):
        /// <code>
        ///     player.Attack(anotherEntity);
        /// </code>
        /// <code>
        ///     panda.Attack(assassin);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Attack(DestructibleComponent destructibleComponent)
        {
            destructibleComponent.TakeDamage(this.attack);
        }
        

        /// <summary>
        /// This function is called when a player taking damage amount.
        /// <example> Example(s):
        /// <code>
        ///     player.TakeDamage(5);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="damage">Damage the player will take</param>
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
                    if (!isDead)
                    {
                        isDead = true;
                        Die();
                    }
                }
            }
        }

        /// <summary>
        /// This function is called to check if enrage is possible.
        /// <example> Example(s):
        /// <code>
        ///     this.CheckForEnrage();
        /// </code>
        /// </example>
        /// </summary>
        private void CheckForEnrage()
        {
            if (isEnraged)
            {
                float rageToSpend = ragePerSecond * Time.deltaTime;
                RemoveRage(rageToSpend);

                if (this.currentRage <= 0)
                {
                    this.isEnraged = false;
                }
            }
        }

        /// <summary>
        /// Regenerate a part of rage. 
        /// <example> Example(s) :
        /// <code>
        ///     player.AddRage(20);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="rage">A rage value</param>
        public virtual void AddRage(float rage)
        {
            if (rage <= 0 || this.isEnraged) return;
            this.currentRage += rage;
            this.currentRage = this.currentRage.Clamp(0.0f, this.maxRage);
        }

        /// <summary>
        /// Remove a part of rage. 
        /// <example> Example(s) :
        /// <code>
        ///     player.RemoveRage(20);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="rage">A rage value</param>
        public virtual void RemoveRage(float rage)
        {
            if (rage <= 0) return;
            this.currentRage -= rage;
            this.currentRage = this.currentRage.Clamp(0.0f, this.maxRage);
        }

        /// <summary>
        /// Activate player's rage.
        /// <example> Example(s) :
        /// <code>
        ///     player.Enrage();
        /// </code>
        /// </example>
        /// </summary>
        public virtual void Enrage()
        {
            if (!isEnraged && this.currentRage > this.maxRage / 2)
            {
                this.isEnraged = true;
            }
            else if (isEnraged)
            {
                this.isEnraged = false;
            }
        }

        /// <summary>
        /// Called when the player dies.
        /// <example> Example(s) :
        /// <code>
        ///     player.Die();
        /// </code>
        /// </example>
        /// </summary>
        protected virtual void Die()
        {
            Debug.Log(this.GetType().Name + "Player >> Die()");
        }
    }
}