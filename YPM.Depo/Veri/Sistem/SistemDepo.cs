﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YPM.Depo.Veri.Sistem
{
    public class SistemDepo
         : ISistemDepo
    {
        private bool Disposed { get; set; }

        ~SistemDepo()
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

        public DateTime TarihGetir()
        {
            throw new NotImplementedException();
        }
    }
}
