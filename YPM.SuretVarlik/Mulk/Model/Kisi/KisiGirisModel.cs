using System;
using System.ComponentModel.DataAnnotations;

namespace YPM.SuretVarlik.Mulk.Model.Kisi
{
    public class KisiGirisModel
       : IDisposable
    {
        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen e-posta adresinizi geçerli bir formatta giriniz.")]
        [MaxLength(100, ErrorMessage = "E-Posta adresiniz max 100 karakter girebilirsiniz.")]
        [EmailAddress(ErrorMessage = "Lütfen  e-posta adresinizi geçerli bir formatta giriniz.")]
        public string email { get; set; }

        [StringLength(25, MinimumLength = 5, ErrorMessage = "Parolanızı 5-25 karakter arasında girebilirsiniz.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        public bool rememberme { get; set; }

        ~KisiGirisModel()
        {
            Dispose(false);
        }

        private bool Disposed { get; set; }

        protected virtual void Dispose(bool Disposing)
        {
            if (Disposed) return;
            if (Disposing)
            {
            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}