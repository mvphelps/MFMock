using System;

namespace MFMock
{
    public interface IInputPort:IDisposable
    {
        bool Read();
    }
}