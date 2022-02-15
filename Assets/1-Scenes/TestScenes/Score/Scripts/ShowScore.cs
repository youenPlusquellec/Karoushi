using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Karoushi;

namespace Karoushi.Scene
{
    [RequireComponent(typeof(Text))]
    public class ShowScore : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        public void UpdateScore()
        {
            string scoreText = "Total : " + ScoreManager.Instance.Score.TotalScore + "\n" +
                             "Furnitures Score : " + ScoreManager.Instance.Score.FurnituresScore + "\n" +
                             "Colleagues Score : " + ScoreManager.Instance.Score.ColleaguesScore + "\n" +
                             "Casuals Score : " + ScoreManager.Instance.Score.CasualsScore + "\n";

            scoreText += "\nTotal of Furnitures destroyed : " + ScoreManager.Instance.Score.DestroyedFurnituresCount + "\n";
            foreach (KeyValuePair<string, int> entry in ScoreManager.Instance.Score.DestroyedFurnitures)
            {
                scoreText += "\tNumber of " + entry.Key + " destroyed : " + entry.Value + "\n";
            }

            scoreText += "\nTotal of Colleagues destroyed : " + ScoreManager.Instance.Score.DestroyedColleaguesCount + "\n";
            foreach (KeyValuePair<string, int> entry in ScoreManager.Instance.Score.DestroyedColleagues)
            {
                scoreText += "\tNumber of " + entry.Key + " destroyed : " + entry.Value + "\n";
            }

            scoreText += "\nTotal of Furnitures destroyed : " + ScoreManager.Instance.Score.DestroyedCasualsCount + "\n";
            foreach (KeyValuePair<string, int> entry in ScoreManager.Instance.Score.DestroyedCasuals)
            {
                scoreText += "\tNumber of " + entry.Key + " destroyed : " + entry.Value + "\n";
            }

            this.text.text = scoreText;
        }
    }
}
