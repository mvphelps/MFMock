using System;
using MFMock;
using MFUnit;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Tests
{
    public class InputPortTests
    {
        public void Wrap()
        {
            IInputPort p = new InputPort(Cpu.Pin.GPIO_Pin0, true, Port.ResistorMode.Disabled).Wrap();
            Assert.IsNotNull(p);    

            Assert.AreEqual(false, p.Read());
        }
    }
}
