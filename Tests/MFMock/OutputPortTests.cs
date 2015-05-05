using System;
using MFMock;
using MFUnit;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Tests
{
    public class OutputPortTests
    {
        public void Wrap()
        {
            IOutputPort p = new OutputPort(Cpu.Pin.GPIO_Pin2, false).Wrap();
            Assert.IsNotNull(p);    

            Assert.AreEqual(false, p.Read());
            p.Write(true);
            Assert.AreEqual(true, p.Read());
            p.Write(false);
            Assert.AreEqual(false, p.Read());
        }
    }
}
