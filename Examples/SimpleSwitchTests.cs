using System;
using MFMock;
using MFMockTesters;
using MFUnit;
using Microsoft.SPOT;

namespace Examples
{
    //This class demonstrates the InputPort and OutputPort testers. It also 
    //shows working with one or multiple data samples.
    public class SimpleSwitchTests
    {
        public void TurnOn()
        {   //Demonstrates utilizing single-sample mode via the Sample property.
            var i = new InputPortTester();
            i.Sample = true;
            var o = new OutputPortTester(false);

            var simpleSwitch = new SimpleSwitch(i, o);
            simpleSwitch.Update();

            Assert.AreEqual(true, o.Read());
        }

        public void TurnOnAndOff()
        {   //Demonstrates utilizing multi-sample mode via the Samples property.
            var i = new InputPortTester(new []{true, false});
            var o = new OutputPortTester(false);

            var simpleSwitch = new SimpleSwitch(i, o);
            simpleSwitch.Update();
            simpleSwitch.Update();
            
            Assert.AreEqual(true, o.ChangeLog[0].State);
            Assert.AreEqual(false, o.ChangeLog[1].State);
        }
    }

    public class SimpleSwitch
    {
        private readonly IInputPort mInputPort;
        private readonly IOutputPort mOutputPort;

        public SimpleSwitch(IInputPort inputPort, IOutputPort outputPort)
        {
            mInputPort = inputPort;
            mOutputPort = outputPort;
        }

        public void Update()
        {
            mOutputPort.Write(mInputPort.Read());
        }
    }
}
