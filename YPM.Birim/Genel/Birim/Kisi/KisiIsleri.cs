using System;
using YPM.SuretVarlik.Mulk.Enum.Ortak;

namespace Birim.Genel.Birim.Kisi
{
    public class KisiIsleri
          : IKisiIsleri
    {

        private bool Disposed { get; set; }


        ~KisiIsleri()
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

        public static IKisiIsleri OrnekVer()
        {
            return new KisiIsleri();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public VarYok EPostaVarMi(string email)
        {
            throw new NotImplementedException();
        }

    }
}
