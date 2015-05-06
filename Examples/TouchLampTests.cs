using System;
using MFMock;
using MFMockTesters;
using MFUnit;
using Microsoft.SPOT;

namespace Examples
{
    //This class demonstrates mocking InterruptPort, and PWM.
    public class TouchLampTests
    {
        public void UserTouchesToBrighten()
        {
            var brightness = new PWMTester();
            var touch = new InterruptPortTester();
            touch.Samples = new bool[] { true, true, true, true, true};
            var lamp = new TouchLamp(brightness, touch);

            touch.FireInterrupt();  //First interrupt causes us to start the PWM, and set the duty cycle. This is 2 events.
            Assert.AreEqual(.25, brightness.ChangeLog[0].DutyCycle);
            Assert.AreEqual(true, brightness.ChangeLog[1].Started);
            
            touch.FireInterrupt();
            Assert.AreEqual(.5, brightness.ChangeLog[2].DutyCycle); //subsequent touch increased brightness.

            touch.FireInterrupt();
            Assert.AreEqual(.75, brightness.ChangeLog[3].DutyCycle); //subsequent touch increased brightness.

            touch.FireInterrupt();
            Assert.AreEqual(1.0, brightness.ChangeLog[4].DutyCycle); //subsequent touch increased brightness to full.

            touch.FireInterrupt();
            Assert.AreEqual(true, brightness.ChangeLog[5].Stopped); //last touch goes back to 0 - turns off the light.
        }
    }

    public class TouchLamp
    {
        private readonly IPWM mBrightness;
        private readonly IInterruptPort mTouch;
        double mDutyCycle;
            
        public TouchLamp(IPWM brightness, IInterruptPort touch)
        {
            mBrightness = brightness;
            mTouch = touch;
            mTouch.OnInterrupt += Touched;
            mDutyCycle = 0;
        }

        private void Touched(uint data1, uint data2, DateTime time)
        {
            var newDutyCyle = mDutyCycle + .25;

            if (newDutyCyle > 1)
            {
                newDutyCyle = 0;
                mBrightness.Stop();
            }
            else
            {
                mBrightness.DutyCycle = newDutyCyle;
                if (mDutyCycle==0)  //start if we were stopped before the latest input.
                {
                    mBrightness.Start();        
                }
            }
            //Store the new state for the next touch.
            mDutyCycle = newDutyCyle;
        }
    }
    
}
