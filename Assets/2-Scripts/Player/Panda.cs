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
        protected override void Die()
        {
            Debug.Log("Oh no");
            Debug.Log("Panda is dead :(");
        }
    }
}
