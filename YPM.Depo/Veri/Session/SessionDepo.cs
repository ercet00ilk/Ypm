using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.Depo.Veri.Session
{
    public class SessionDepo
        : ISessionDepo
    {
        private bool Disposed { get; set; }

        ~SessionDepo()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool Disposing)
        {
            if (!Disposed)
            {
                if (Disposing)
                {
                }
                Disposed = true;
            }
        }

        public int KisiIdGetir()
        {
            throw new NotImplementedException();
        }
    }
}
