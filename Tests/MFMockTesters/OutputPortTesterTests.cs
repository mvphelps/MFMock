using System;
using System.Threading;
using MFMock;
using MFMockTesters;
using MFUnit;
using Microsoft.SPOT;

namespace Tests.MFMockTesters
{
    public class OutputPortTesterTests
    {
        public void SetsInitialState()
        {
            var t = new OutputPortTester(true);
            IOutputPort port = t;

            Assert.AreEqual(true, port.Read());
        }
        public void RecordsChanges()
        {
            var t = new OutputPortTester(true);
            IOutputPort port = t;

            port.Write(false);
            port.Write(false);
            port.Write(true);
            port.Write(true);
            port.Write(false);

            var results = t.ChangeLog;
            Assert.AreEqual(false, results[0].State);
            Assert.AreEqual(false, results[1].State);
            Assert.AreEqual(true, results[2].State);
            Assert.AreEqual(true, results[3].State);
            Assert.AreEqual(false, results[4].State);
            //Assert.IsTrue(results[0].When < results[1].When);
            //Assert.IsTrue(results[1].When < results[2].When);
            //Assert.IsTrue(results[2].When < results[3].When);
            //Assert.IsTrue(results[3].When < results[4].When);

        }
    }
}
