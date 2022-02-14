using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Karoushi.Test
{
    public class SingletonTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void SingletonTestSimplePasses()
        {
            // Get 2 instances of Pandas
            Panda panda1 = Singleton<Panda>.Instance;
            Panda panda2 = Singleton<Panda>.Instance;
            Assert.AreSame(panda1, panda2);

            // Clear the scene
            Utils.ClearCurrentScene(true);
        }
    }
}
