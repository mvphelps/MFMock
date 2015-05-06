using System;
using MFMock;
using MFMockTesters;
using MFUnit;
using Microsoft.SPOT;

namespace Examples
{
    //This class demonstrates mocking the AnalogInput and the OutputPort objects.
    public class ThermostatTests
    {
        public void OneHeatCycle()
        {
            
            var temp = new AnalogInputTester();
            //Our samples shoudl demonstrate that the furnas does not run at the 
            //set point or 1 degree below. It will then turn on if lower, and stay 
            //on up to 1 degree above the set point.
            temp.RawSamples = new int[] {72, 71, 70, 72, 73};
            var furnas = new OutputPortTester(false);
            var t = new Thermostat(temp, furnas);
            
            
            //A timer fires the thermostat to check conditions at regular intervals. 
            //We'll just invoke it enough times to go through our samples.
            t.SetPoint = 72;    //Note that setting the setpoint causes a read!
            Assert.AreEqual(0, furnas.ChangeLog.Length);    //The correct temp will not cause an output change. 
            t.Timer();
            Assert.AreEqual(0, furnas.ChangeLog.Length);    //One below the correct temp will not cause an output change.
            t.Timer();
            Assert.AreEqual(true, furnas.ChangeLog[0].State);   //Two below should turn on.
            t.Timer();
            Assert.AreEqual(1, furnas.ChangeLog.Length);    //Still on after we reach the set point.
            t.Timer();
            Assert.AreEqual(false, furnas.ChangeLog[1].State);  //Turn off once we are one above the set point.
        }
    }

    public class Thermostat
    {
        private readonly IAnalogInput mTemp;
        private readonly IOutputPort mFurnas;
        private int mSetPoint;

        public Thermostat(IAnalogInput temp, IOutputPort furnas)
        {
            mTemp = temp;
            mFurnas = furnas;
        }

        public int SetPoint
        {
            get { return mSetPoint; }
            set
            {
                mSetPoint = value;
                Timer();
            }
        }

        public void Timer()
        {
            var currentTemp = mTemp.ReadRaw();
            if (currentTemp < SetPoint - 1)
            {
                mFurnas.Write(true);
            }
            if (currentTemp >= SetPoint + 1)
            {
                mFurnas.Write(false);
            }
        }
    }
}
