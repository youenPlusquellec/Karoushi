using UnityEngine;


namespace Karoushi
{
    /// <summary>
    /// Basic class of a weapon
    /// </summary>
    public class Weapon : MonoBehaviour
    {
        [SerializeField]
        protected Player player;

        /// <summary>
        /// Enable or disable the weapon collider
        /// <example> Example(s):
        /// <code>
        ///     weapon.EnableCollider(true);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="value">true to enable collider</param>
        public void EnableCollider(bool value)
        {
            GetComponent<Collider>().enabled = value;
        }

        /// <summary>
        /// Called when the collider entering with another
        /// <example> Example(s):
        /// <code>
        ///     weapon.OnTriggerEnter(anotherCollider);
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="other">the collider the weapon is entering with</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "DestructibleComponent")
            {
                DestructibleComponent destructibleComponent = other.gameObject.GetComponentInParent<DestructibleComponent>();
                Debug.Log("Trigger on " + destructibleComponent);
                player.Attack(destructibleComponent);
            }
        }

    }
}
