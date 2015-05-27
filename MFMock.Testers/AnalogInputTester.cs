using MFMock;

namespace MFMockTesters
{
    /// <summary>
    /// Allows mocking of a single AnalogInput. Assign data samples for 
    /// reading via the Samples or RawSamples property.
    /// </summary>
    public class AnalogInputTester : IAnalogInput
    {
        public void Dispose()
        {
        }
        /// <summary>
        /// Returns the next sample. Automatically advances to the next sample to prepare for
        /// another Read() invocation.
        /// </summary>
        /// <returns></returns>
        public double Read()
        {
            return mSamples[mSamplesIndex++];
        }
        /// <summary>
        /// Returns the next raw sample. Automatically advances to the next sample to prepare for
        /// another ReadRaw() invocation.
        /// </summary>
        /// <returns></returns>
        public int ReadRaw()
        {
            return mRawSamples[mReadRawSamplesIndex++];
        }

        // Testing helpers below this line.
        public AnalogInputTester()
        {
            mSamples = new double[]{};
            mRawSamples = new int[] {};
        }
        public AnalogInputTester(double[] samples)
        {
            mSamples = samples;
            mRawSamples = new int[] { };
        }
        public AnalogInputTester(int[] rawSamples)
        {
            mSamples = new double[] { };
            mRawSamples = rawSamples;
        }
        /// <summary>
        /// Assigns a single sample for reading.
        /// </summary>
        public double Sample
        {
            get { return mSamples[mSamplesIndex]; }
            set
            {
                mSamples = new double[] { value };
                mSamplesIndex = 0;
            }
        }
        /// <summary>
        /// Assigns a single raw sample for reading.
        /// </summary>
        public int RawSample
        {
            get { return mRawSamples[mReadRawSamplesIndex]; }
            set
            {
                mRawSamples = new int[] { value };
                mReadRawSamplesIndex = 0;
            }
        }
        /// <summary>
        /// Assigns a series of samples for reading.
        /// </summary>
        public double[] Samples
        {
            get { return mSamples; }
            set
            {
                mSamples = value;
                mSamplesIndex = 0;
            }
        }
        /// <summary>
        /// Assigns a series of raw samples for reading.
        /// </summary>
        public int[] RawSamples
        {
            get { return mRawSamples; }
            set
            {
                mRawSamples = value;
                mReadRawSamplesIndex = 0;
            }
        }
        /// <summary>
        /// Indicates the index of the next sample to be read. Zero based index, the first sample is index 0.
        /// </summary>
        public int ReadIndex
        {
            get { return mSamplesIndex; }
        }
        /// <summary>
        /// Indicates the index of the next Raw sample to be read. Zero based index, the first sample is index 0.
        /// </summary>
        public int ReadRawIndex
        {
            get { return mReadRawSamplesIndex; }
        }

        private double[] mSamples;
        private int[] mRawSamples;
        private int mSamplesIndex;
        private int mReadRawSamplesIndex;

    }
}