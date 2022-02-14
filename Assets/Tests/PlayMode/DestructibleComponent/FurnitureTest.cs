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
    }
}
