using System;
using System.Security.Cryptography.X509Certificates;
using MFMockTesters;
using MFUnit;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Tests.MFMockTesters
{
    public class InterruptPortTesterTests
    {
        private bool fired = false;
        private uint fired_value = 0;
        public void FireInterrupt()
        {
            
            var x = new InterruptPortTester();
            x.OnInterrupt += SeeInterrupt;

            x.Sample = true;
            x.FireInterrupt();
            Assert.IsTrue(fired);
            Assert.AreEqual((uint)1, fired_value);

            x.Sample = false; fired = false;
            x.FireInterrupt();
            Assert.IsTrue(fired);
            Assert.AreEqual((uint)0, fired_value);
        }

        public void ConstructWithSamples()
        {

            var x = new InterruptPortTester(new bool[]{true, false});
            x.OnInterrupt += SeeInterrupt;

            x.FireInterrupt();
            Assert.IsTrue(fired);
            Assert.AreEqual((uint)1, fired_value);

            fired = false;
            x.FireInterrupt();
            Assert.IsTrue(fired);
            Assert.AreEqual((uint)0, fired_value);


        }
        private void SeeInterrupt(uint data1, uint data2, DateTime time)
        {
            fired = true;
            fired_value = data2;
        }
    }
}
