using System;

namespace Covid19.Morocco.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool _isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
                DisposeCore();
            _isDisposed = true;
        }

        protected virtual void DisposeCore()
        {
        }
    }
}