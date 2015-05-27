using System;
using MFMock;

namespace MFMockTesters
{
    /// <summary>
    /// Allows mocking of an InputPort object. Assign data values to be read via the Samples property.
    /// </summary>
    public class InputPortTester : IInputPort
    {
        
        public void Dispose()
        {
        }
        /// <summary>
        /// Returns the next data sample, and automatically advances to the next sample to 
        /// prepare for another Read() invocation.
        /// </summary>
        /// <returns></returns>
        public bool Read()
        {
            return mSamples[mSampleIndex++];
        }

        // Testing helpers below this line.

        public InputPortTester()
        {   //If the dev fails to supply samples, this will still allow us to fail with the IndexOutOfRangeException
            mSamples = new bool[] { };
        }
        public InputPortTester(bool[] samples)
        {
            mSamples = samples;
        }
        /// <summary>
        /// Assigns a single sample for reading.
        /// </summary>
        public bool Sample
        {
            get { return mSamples[mSampleIndex]; }
            set
            {
                mSamples=new bool[]{value};
                mSampleIndex = 0;
            }
        }
        /// <summary>
        /// Assigns a series of samples for reading.
        /// </summary>
        public bool[] Samples
        {
            get { return mSamples; }
            set
            {
                mSamples = value;
                mSampleIndex = 0;
            }
        }
        

        private bool[] mSamples;
        private int mSampleIndex;
        /// <summary>
        /// Indicates the index of the next sample to be read. Zero based index, the first sample is index 0.
        /// </summary>
        public int ReadIndex
        {
            get { return mSampleIndex; }
        }
    }
}