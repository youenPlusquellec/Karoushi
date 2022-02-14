using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoushi
{
    /// <summary>
    /// Basic class of a Furniture herited from destructible component
    /// </summary>
    public class Furniture : DestructibleComponent
    {
        [SerializeField]
        protected GameObject destroyedVersion;

        /// <summary>
        /// Called when the component is destroyed.
        /// <example> Example(s) :
        /// <code>
        ///     furniture.Die();
        /// </code>
        /// </example>
        /// </summary>
        protected override void Die()
        {
            // Call upper Die methods
            base.Die();

            // Spawn the shattered version
            if (destroyedVersion != null)
            {
                Instantiate(destroyedVersion, transform.position, transform.rotation);
            }

            // Remove the current object
            Destroy(gameObject);
        }
    }
}
