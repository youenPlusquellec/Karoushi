using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Karoushi.Test
{
    public class ScoreManagerTest : ScoreManager
    {
        [Test]
        public void ScoreManagerCreatesNewScorePasses()
        {
            // Check there is no existing score 
            Assert.IsTrue(this.Score == null);

            // Create a score
            this.CreateNewScore();
            this.Score.FurnituresScore = 10;
            this.Score.ColleaguesScore = 20;
            this.Score.CasualsScore = 15;
            Assert.AreEqual(45, this.Score.TotalScore);

            // Create a new score
            this.CreateNewScore();
            Assert.AreEqual(0, this.Score.FurnituresScore);
            Assert.AreEqual(0, this.Score.ColleaguesScore);
            Assert.AreEqual(0, this.Score.CasualsScore);
            Assert.AreEqual(0, this.Score.TotalScore);

            // Clear the scene
            this.Score = null;
            Utils.ClearCurrentScene(true);
        }

        [Test]
        public void ScoreCountersPasses()
        {
            // Check there is no existing score 
            Assert.IsTrue(this.Score == null);

            // Create a score
            this.CreateNewScore();

            // Check furniture counts
            this.Score.DestroyedFurnitures.Add("Laptop", 2);
            this.Score.DestroyedFurnitures.Add("Table", 2);
            this.Score.DestroyedFurnitures.Add("Chair", 2);
            Assert.AreEqual(6, this.Score.DestroyedFurnituresCount);

            // Check colleagues counts
            this.Score.DestroyedColleagues.Add("Engineer", 2);
            this.Score.DestroyedColleagues.Add("Technician", 1);
            Assert.AreEqual(3, this.Score.DestroyedColleaguesCount);

            // Check casuals counts
            this.Score.DestroyedCasuals.Add("Client", 8);
            this.Score.DestroyedCasuals.Add("Patient", 2);
            Assert.AreEqual(10, this.Score.DestroyedCasualsCount);

            // Create a new score
            this.CreateNewScore();
            Assert.AreEqual(0, this.Score.DestroyedFurnituresCount);
            Assert.AreEqual(0, this.Score.DestroyedColleaguesCount);
            Assert.AreEqual(0, this.Score.DestroyedCasualsCount);

            // Clear the scene
            this.Score = null;
            Utils.ClearCurrentScene(true);
        }
    }
}
