using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Karoushi.Test
{
    public class ConfigTest
    {
        private Config GenerateConfig()
        {
            Config config = new Config();

            config.GameVolume = 100;
            config.GameSoundEffectsVolume = 50;
            config.MouseHorizontalInversion = true;
            config.MouseVerticalInversion = false;
            config.MouseSensibility = 2.0f;

            return config;
        }

        // A Test behaves as an ordinary method
        [Test]
        public void ConfigTestSimplePasses()
        {
            Config config = GenerateConfig();

            // Check good generation
            Assert.AreEqual(100, config.GameVolume);
            Assert.AreEqual(50, config.GameSoundEffectsVolume);
            Assert.IsTrue(config.MouseHorizontalInversion);
            Assert.IsFalse(config.MouseVerticalInversion);
            Assert.AreEqual(2.0f, config.MouseSensibility);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }
    }
}
