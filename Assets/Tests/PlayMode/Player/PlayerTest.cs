using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Karoushi.Test
{
    public class PlayerTest : Player
    {
        [Test]
        public void PlayerInitialiseTest()
        {
            // Set default values
            this.maxHealth = 100;
            this.currentHealth = 0;
            this.currentRage = 10;
            Assert.AreEqual(0, this.currentHealth);
            Assert.AreEqual(10, this.currentRage);

            // Initialize player
            Start();
            Assert.AreEqual(100, this.currentHealth);
            Assert.AreEqual(0, this.currentRage);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }

        [Test]
        public void PlayerTakeDamagesTest()
        {
            // Set default values
            this.currentHealth = 100;

            // Remove 20 hp
            this.TakeDamage(20);
            Assert.AreEqual(80, this.currentHealth);

            // Remove 0 hp
            this.TakeDamage(-20);
            Assert.AreEqual(80, this.currentHealth);

            // Kill it
            this.TakeDamage(80);
            Assert.AreEqual(0, this.currentHealth);
            Assert.IsTrue(this.isDead);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }

        [Test]
        public void PlayerCanAttackTest()
        {
            // Set default values
            this.currentHealth = 100;
            this.attack = 10;

            // Create a destructible component
            GameObject furnitureGo = new GameObject();
            DestructibleComponent furniture = furnitureGo.AddComponent<Furniture>();
            furniture.CurrentHealth = 5;
            Assert.IsFalse(furniture.IsDestroyed);

            // Attack the component
            this.Attack(furniture);
            Assert.IsTrue(furniture.IsDestroyed);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }

        [Test]
        public void PlayerUpdateRageTest()
        {
            // Set default values
            this.maxRage = 80;
            this.currentRage = 50;

            // Add 20 rage points
            this.AddRage(20);
            Assert.AreEqual(70, this.currentRage);

            // Add 0 rage points
            this.AddRage(-20);
            Assert.AreEqual(70, this.currentRage);

            // Add 20 rage points -> Limit to 80 points
            this.AddRage(20);
            Assert.AreEqual(80, this.currentRage);

            // Remove 20 rage points
            this.RemoveRage(20);
            Assert.AreEqual(60, this.currentRage);

            // Remove 0 rage points
            this.RemoveRage(-20);
            Assert.AreEqual(60, this.currentRage);

            // Remove 80 rage points -> Limit to 0 points
            this.RemoveRage(80);
            Assert.AreEqual(0, this.currentRage);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }

        [UnityTest]
        public IEnumerator PlayerCanEnrageTest()
        {
            // Set default values
            this.maxRage = 100;
            this.currentRage = 40;
            this.ragePerSecond = 10;

            // Try to enrage -> not enough rage
            this.Enrage();
            yield return null;

            // Check if not enraged
            Assert.AreEqual(40, this.currentRage);
            Assert.IsFalse(this.isEnraged);
            
            // Add 20 rage points
            this.AddRage(20);
            Assert.AreEqual(60, this.currentRage);
            this.Enrage();
            Assert.IsTrue(this.isEnraged);
            Update();
            Assert.Greater(60, this.currentRage);

            // Check rage is consumed
            this.currentRage = 55;
            this.Enrage();
            Assert.IsFalse(this.isEnraged);
            Update();
            Assert.AreEqual(55, this.currentRage);

            // Check if rage consume completely
            this.ragePerSecond = 120;
            this.Enrage();
            Assert.IsTrue(this.isEnraged);
            this.currentRage = 0.01f;
            Update();
            Assert.IsFalse(this.isEnraged);
            Assert.AreEqual(0, this.currentRage);

            // Check if rage stop consumming
            this.currentRage = 60;
            Update();
            Assert.AreEqual(60, this.currentRage);
            

            // Clear the scene
            Utils.ClearCurrentScene();
            yield return null;
        }
    }
}
