using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Karoushi.Test
{
    public class PandaTest
    {
        /*[Test]
        public void PandaTakeDamagesTest()
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
        }*/

        [UnityTest]
        public IEnumerator PandaTakeDamagesTest()
        {
            GameObject go = new GameObject();
            Panda panda = go.AddComponent<Panda>();

            /*// Set default values
            this.currentHealth = 100;

            // Remove 20 hp
            this.TakeDamage(20);
            Assert.AreEqual(80, this.currentHealth);

            // Remove 0 hp
            this.TakeDamage(-20);
            Assert.AreEqual(80, this.currentHealth);

            // Kill it*/
            panda.TakeDamage(80);
            //Assert.AreEqual(0, this.currentHealth);
            //Assert.IsTrue(this.isDead);
            yield return null;

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }
    }
}
