using System;
using System.Collections.Generic;
using System.Text;

namespace Birim.Genel.Birim.Sistem
{
    public class SistemIsleri
            : ISistemIsleri
    {
        public static ISistemIsleri OrnekVer()
        {
            return new SistemIsleri();
        }

        private bool Disposed { get; set; }

        ~SistemIsleri()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool Disposing)
        {
            if (Disposed) return;
            if (Disposing)
            {
                //if (_ornek != null) _ornek = null;

            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public DateTime TarihGetir()
        {
            throw new NotImplementedException();
        }

        public string MacAdresGetir()
        {
            throw new NotImplementedException();
        }

        public string IpAdrGetir()
        {
            throw new NotImplementedException();
        }
    }
}
