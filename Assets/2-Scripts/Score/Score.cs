using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoushi
{

    /// <summary>
    /// Class of a game score
    /// </summary>
    public class Score
    {
        // Every scores
        public float TotalScore => FurnituresScore + ColleaguesScore + CasualsScore + BossScore;
        public float FurnituresScore = 0;
        public float ColleaguesScore = 0;
        public float CasualsScore = 0;
        public float BossScore = 0;

        // Other statistics
        public Dictionary<string, int> DestroyedFurnitures = new Dictionary<string, int>();
        public Dictionary<string, int> DestroyedColleagues= new Dictionary<string, int>();
        public Dictionary<string, int> DestroyedCasuals = new Dictionary<string, int>();
        public bool IsBossBeaten = false;
        public int NumberOfHidden = 0;
        public int TotalDamages = 0;

        // Count getters
        public int DestroyedFurnituresCount
        {
            get
            {
                int total = 0;
                foreach (KeyValuePair<string, int> entry in DestroyedFurnitures)
                {
                    total += entry.Value;
                }
                return total;
            }
        }

        public int DestroyedColleaguesCount
        {
            get
            {
                int total = 0;
                foreach (KeyValuePair<string, int> entry in DestroyedColleagues)
                {
                    total += entry.Value;
                }
                return total;
            }
        }

        public int DestroyedCasualsCount
        {
            get
            {
                int total = 0;
                foreach (KeyValuePair<string, int> entry in DestroyedCasuals)
                {
                    total += entry.Value;
                }
                return total;
            }
        }
    }
}