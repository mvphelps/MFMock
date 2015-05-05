using System;

namespace MFMock
{
    public interface IOutputPort : IDisposable
    {
        bool Read();
        void Write(bool state);
    }
}