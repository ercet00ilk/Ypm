using GercekVarlik.Mulk.Varlik.Ortak;

namespace GercekVarlik.Mulk.Varlik.Kurulum.Ortak
{
    public class KurulumGercek
        : AbsOrtakVarlik
    {
        public override int Id { get; set; }

        public string Tip { get; set; }

        public string Ad { get; set; }

        public bool Sonuc { get; set; }
    }
}