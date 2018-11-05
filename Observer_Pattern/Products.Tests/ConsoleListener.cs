using System;
using System.IO;

namespace Products.Tests
{
    /// <summary>
    /// Console Listeners help read data from the console output stream.
    /// </summary>
    class ConsoleListener : IDisposable
    {
        private readonly StringWriter _swrite;
        private readonly TextWriter _twrite;

        public ConsoleListener()
        {
            _swrite = new StringWriter();
            _twrite = Console.Out;
            Console.SetOut(_swrite);
        }

        public string GetOutput()
        {
            return _swrite.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(_twrite);
            _swrite.Dispose();
        }
    }
}
