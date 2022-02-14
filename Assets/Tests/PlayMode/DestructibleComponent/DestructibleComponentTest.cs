using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Karoushi.Test
{
    public class DestructibleComponentTest : DestructibleComponent
    {
        [Test]
        public void DestructibleComponentInitialiseTest()
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

        [Test]
        public void DestructibleComponentTakeDamagesTest()
        {
            // Set default values
            this.CurrentHealth = 100;

            // Remove 20 hp
            this.TakeDamage(20);
            Assert.AreEqual(80, this.CurrentHealth);

            // Remove 0 hp
            this.TakeDamage(-20);
            Assert.AreEqual(80, this.CurrentHealth);

            // Kill it
            this.TakeDamage(80);
            Assert.AreEqual(0, this.CurrentHealth);
            Assert.IsTrue(this.isDestroyed);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }

        // TODO  We can't create this test now
        /*[Test]
        public void DestructibleComponentGivesScoreToPlayerTest()
        {
            // Set default values
            this.scoreToGive = 50;

            // TODO 

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }*/
    }
}
