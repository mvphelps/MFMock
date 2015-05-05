using System;
using System.Collections;
using MFMock;

namespace MFMockTesters
{
    public class PWMTester : IPWM
    {
        public void Dispose()
        {
        }
        public void Start()
        {
            IsStarted = true;
            WasStarted = true;
            RecordChange();
        }

        public void Stop()
        {
            IsStarted = false;
            WasStopped = true;
            RecordChange();
        }

        public double DutyCycle
        {
            get { return mDutyCycle; }
            set
            {
                mDutyCycle = value;
                RecordChange();
            }
        }


        // Testing helpers below this line.
        /// <summary>
        /// True after invoking Start, False after invoking Stop.
        /// </summary>
        public bool IsStarted { get; private set; }
        /// <summary>
        /// True after invoking Stop, False after invoking Start.
        /// </summary>
        public bool IsStopped {get { return !IsStarted; }}
        /// <summary>
        /// The Start() was invoked at least once.
        /// </summary>
        public bool WasStarted { get; private set; }
        /// <summary>
        /// The Stop() was invoked at least once.
        /// </summary>
        public bool WasStopped { get; private set; }
        /// <summary>
        /// A record of the state changes of this PWM output. Every start 
        /// or stop and every duty cycle change. For example, if you set 
        /// duty cycle to 50%, and then invoke Start, there will be two
        /// change log events. The first shows IsStarted=false, and 
        /// DutyCycle = 0.50, the second shows IsStarted=true, and
        /// DutyCycle = 0.50.
        /// </summary>
        public PWMChange[] ChangeLog
        {
            get { return (PWMChange[])mChangeLog.ToArray(typeof(PWMChange)); }
        }
        private readonly ArrayList mChangeLog;
        private double mDutyCycle;

        public PWMTester()
        {
            mChangeLog = new ArrayList();
            IsStarted = false;
            WasStarted = false;
            WasStopped = false;
        }
        private void RecordChange()
        {
            mChangeLog.Add(new PWMChange(IsStarted, DutyCycle));
        }

    }
    public class PWMChange
    {
        /// <summary>
        /// True if Start was the last method invoked. False if Stop was.
        /// </summary>
        public readonly bool Started;
        /// <summary>
        /// True if Stop was the last method invoked. False if Start was.
        /// </summary>
        public bool Stopped{get { return !Started; }}
        /// <summary>
        /// The assigned duty cycle. 
        /// </summary>
        public readonly double DutyCycle;

        public PWMChange(bool started, double dutyCycle)
        {
            Started = started;
            DutyCycle = dutyCycle;
        }
    }
}