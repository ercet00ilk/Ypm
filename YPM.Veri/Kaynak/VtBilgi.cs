namespace YPM.Veri.Kaynak
{
    internal class VtBilgi
    {
        public static readonly VtBilgi Islem = new VtBilgi();

        private VtBilgi()
        {
        }

        public string BaglantiCumlesiVer()
        {
            // return @"server=94.73.170.9;database=u7148612_ToptanSebil;user=u7148612_Ercet00ilk;password=XVuv62U6;trusted_connection=false;MultipleActiveResultSets=true;";

            return @"server=.;database=YpmSebil;user=sa;password=Enter@50;trusted_connection=false;MultipleActiveResultSets=true;";
        }
    }
}