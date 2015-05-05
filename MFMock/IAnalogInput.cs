using System;

namespace MFMock
{
    public interface IAnalogInput:IDisposable
    {
        double Read();
        int ReadRaw();
    }
}