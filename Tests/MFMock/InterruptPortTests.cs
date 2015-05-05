using System;
using MFMock;
using MFUnit;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace Tests
{
    public class InterruptPortTests
    {
        public void Wrap()
        {
            IInterruptPort p = new InterruptPort(Cpu.Pin.GPIO_Pin1, true, Port.ResistorMode.Disabled, Port.InterruptMode.InterruptEdgeBoth).Wrap();
            Assert.IsNotNull(p);    

            Assert.AreEqual(false, p.Read());

            //Can't really assert these, since we aren't running on a real 
            //device. If we were, we'd need to connect an output to an input, 
            //therefore would need a special setup for testing. Might do this
            //in the future.
            p.OnInterrupt += DummyMethod;
            p.EnableInterrupt();
            p.DisableInterrupt();
            p.ClearInterrupt();
            p.OnInterrupt -= DummyMethod;

        }

        private void DummyMethod(uint data1, uint data2, DateTime time)
        {
            //empty.
        }
    }
}
