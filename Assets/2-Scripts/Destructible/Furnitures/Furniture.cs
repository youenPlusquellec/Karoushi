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
        public GameObject DestroyedVersion;

        /// <summary>
        /// Gives score to the player.
        /// <example> Example(s) :
        /// <code>
        ///     furniture.GiveScoreToPlayer();
        /// </code>
        /// </example>
        /// </summary>
        protected override void GiveScoreToPlayer()
        {
            base.GiveScoreToPlayer();
            if (ScoreManager.Instance != null)
            {
                Score score = ScoreManager.Instance.Score;
                if (score != null)
                {
                    score.FurnituresScore += this.scoreToGive;
                    if (score.DestroyedFurnitures.ContainsKey(this.furnitureName))
                    {
                        score.DestroyedFurnitures[this.furnitureName] += 1;
                    }
                    else
                    {
                        score.DestroyedFurnitures.Add(this.furnitureName, 1);
                    }
                }
            }
        }

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
            if (DestroyedVersion != null)
            {
                Instantiate(DestroyedVersion, transform.position, transform.rotation);
            }

            // Remove the current object
            Destroy(gameObject);
        }
    }
}
