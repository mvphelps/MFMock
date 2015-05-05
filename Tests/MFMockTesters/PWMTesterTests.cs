using System;
using MFMock;
using MFMockTesters;
using MFUnit;
using Microsoft.SPOT;

namespace Tests.MFMockTesters
{
    public class PWMTesterTests
    {
        public void RecordStartedAndStoppedStates()
        {
            var t = new PWMTester();
            Assert.IsFalse(t.IsStarted);
            Assert.IsFalse(t.WasStarted);
            Assert.IsTrue(t.IsStopped);
            Assert.IsFalse(t.WasStopped);
            t.Start();
            Assert.IsTrue(t.IsStarted);
            Assert.IsTrue(t.WasStarted);
            Assert.IsFalse(t.IsStopped);
            Assert.IsFalse(t.WasStopped);
            t.Stop();
            Assert.IsFalse(t.IsStarted);
            Assert.IsTrue(t.WasStarted);
            Assert.IsTrue(t.IsStopped);
            Assert.IsTrue(t.WasStopped);
        }

        public void RecordChanges()
        {
            var t = new PWMTester();
            IPWM pwm = t;

            pwm.DutyCycle = .5;
            pwm.Start();
            pwm.DutyCycle = .25;
            pwm.DutyCycle = .75;
            pwm.Stop();

            var log = t.ChangeLog;
            AssertLog(log[0], false, .5);
            AssertLog(log[1], true, .5);
            AssertLog(log[2], true, .25);
            AssertLog(log[3], true, .75);
            AssertLog(log[4], false, .75);


        }

        private void AssertLog(PWMChange entry, bool isStarted, double dutyCycle)
        {
            Assert.AreEqual(isStarted, entry.Started);
            Assert.AreEqual(dutyCycle, entry.DutyCycle);
        }
    }
}
