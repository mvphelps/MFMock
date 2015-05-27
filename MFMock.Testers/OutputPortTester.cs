using System;
using System.Collections;
using MFMock;
using Microsoft.SPOT.Hardware;

namespace MFMockTesters
{
    public class OutputPortTester : IOutputPort
    {
        public OutputPortTester(bool initialState)
        {
            mValue = initialState;
            mChangeLog = new ArrayList();
        }
        public void Dispose()
        {

        }
        public bool Read()
        {
            return mValue;
        }

        public void Write(bool state)
        {
            mValue = state;
            mChangeLog.Add(new OutputChange(state));
        }

        // Testing helpers below this line.
        /// <summary>
        /// A record of changes in this output.
        /// </summary>
        public OutputChange[] ChangeLog
        {
            get { return (OutputChange[])mChangeLog.ToArray(typeof(OutputChange)); }
        }
        private bool mValue;
        private ArrayList mChangeLog;
        

    }
    public class OutputChange
    {
        /// <summary>
        /// Corresponds directly to the value sent to .Write.
        /// </summary>
        public readonly bool State;

        public OutputChange(bool state)
        {
            State = state;
        }
    }
}