using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoushi
{
    /// <summary>
    /// Class of the score manager
    /// It manages everything related to the score
    /// </summary>
    public class ScoreManager : Singleton<ScoreManager>
    {
        [HideInInspector]
        public Score Score;

        /// <summary>
        /// This method creates a new score and override the last one.
        /// <example> Example(s):
        /// <code>
        ///     ScoreManager.Instance.CreateNewScore();
        /// </code>
        /// </example>
        /// </summary>
        public void CreateNewScore()
        {
            Score = new Score();
        }

        //// TODO When the global statistics will be implemented
        /// <summary>
        /// This method saves the current score in the global statistics.
        /// <example> Example(s):
        /// <code>
        ///     ScoreManager.Instance.SaveScore();
        /// </code>
        /// </example>
        /// </summary>
        /*public void SaveScore()
        {

        }*/
    }
}
