using YPM.SuretVarlik.Mulk.Suret.Session;

namespace YPM.Web.Genel.Wrapper.Session
{
    public interface ISessionSar
    {
        SessionIslemSuret SuAnki { get; set; }
        void Ekle(string anahtar, object deger);
        T Getir<T>(string anahtar);
        void Sil(string anahtar);
        void TumunuTemizle();
    }


    /* Kullanımı
            
            
            Dictionary<string, string> dc = new Dictionary<string, string>();

            dc.Add("test1", "deneme1");
            dc.Add("test2", "deneme2");

            _sessionSar.Ekle("ypm_test", dc);

            var sonuc = _sessionSar.Getir<Dictionary<string, string>>("ypm_test");
     
     
     
     */
}