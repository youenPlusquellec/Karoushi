using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoushi
{
    /// <summary>
    /// Basic class of a Panda
    /// </summary>
    public class Panda : Player
    {        
        /// <summary>
        /// Called when the panda dies.
        /// <example> Example(s) :
        /// <code>
        ///     panda.Die();
        /// </code>
        /// </example>
        /// </summary>
        protected override void Die()
        {
            base.Die();
            // TODO  Add behavior 
        }
    }
}
