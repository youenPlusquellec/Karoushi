using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

namespace Karoushi.Test
{
    public class FurnitureTest : Furniture
    {
        [Test]
        public void FurnitureInitialiseTest()
        {
            // Set default values
            this.maxHealth = 100;
            Assert.AreEqual(0, this.CurrentHealth);

            // Initialize destructible component
            Start();
            Assert.AreEqual(100, this.CurrentHealth);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }
    }

    public class FurnitureExternalTest
    {
        private GameObject examplePrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Tests/PlayMode/DestructibleComponent/example.prefab");

        [UnityTest]
        public IEnumerator FurnitureDiesTest()
        {
            // Instantiate a furniture
            GameObject furnitureGo = new GameObject();
            Furniture furniture = furnitureGo.AddComponent<Furniture>();
            yield return null;

            // Set default values
            furniture.CurrentHealth = 5;
            furniture.DestroyedVersion = examplePrefab;

            furniture.TakeDamage(10);
            yield return null;

            Assert.IsTrue(furniture == null);
            Assert.IsTrue(furnitureGo == null);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }

        [UnityTest]
        public IEnumerator FurnitureUpdateScoreTest()
        {
            // Instantiate a furniture
            GameObject furnitureGo = new GameObject();
            Furniture furniture = furnitureGo.AddComponent<Furniture>();
            yield return null;

            // Instantiate a furniture
            ScoreManager scoreManager = GameObject.Instantiate<ScoreManager>(AssetDatabase.LoadAssetAtPath<ScoreManager>("Assets/3-Prefabs/Score/ScoreManager.prefab"));
            scoreManager.CreateNewScore();
            yield return null;

            // Set default values
            furniture.CurrentHealth = 5;
            furniture.DestroyedVersion = examplePrefab;
            Assert.AreEqual(0, scoreManager.Score.FurnituresScore);
            Assert.AreEqual(0, scoreManager.Score.TotalScore);
            Assert.AreEqual(0, scoreManager.Score.DestroyedFurnituresCount);

            // kill the fourniture
            furniture.TakeDamage(10);
            Assert.IsTrue(scoreManager.Score != null, "Oh non le score :(");
            yield return null;

            // Check if score is updated
            Assert.Less(0, scoreManager.Score.FurnituresScore);
            Assert.Less(0, scoreManager.Score.TotalScore);
            Assert.AreEqual(1, scoreManager.Score.DestroyedFurnituresCount);
            Assert.IsTrue(ScoreManager.Instance.Score  != null, "Oh non le score :(");

            // Instantiate a second furniture
            GameObject furnitureGo2 = new GameObject();
            Furniture furniture2 = furnitureGo2.AddComponent<Furniture>();
            Assert.IsTrue(ScoreManager.Instance.Score != null, "Oh non le score :(");
            yield return null;

            // Set default values off the second fourniture
            furniture2.CurrentHealth = 5;
            furniture2.DestroyedVersion = examplePrefab;
            Assert.IsTrue(ScoreManager.Instance.Score != null, "Oh non le score :(");
            Assert.AreEqual(1, scoreManager.Score.DestroyedFurnituresCount);

            // Kill the second furniture
            furniture2.TakeDamage(10);
            yield return null;
            yield return null;
            Assert.IsTrue(ScoreManager.Instance.Score != null, "Oh non le score :(");
            Debug.Log("dead normalement");

            // Check if number of furniture is updated
            Assert.IsTrue(furniture2 == null);
            Assert.IsTrue(furnitureGo2 == null);
            Assert.AreEqual(2, scoreManager.Score.DestroyedFurnituresCount);

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
