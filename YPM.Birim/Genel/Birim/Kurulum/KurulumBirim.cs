using GercekVarlik.Mulk.Varlik.Kurulum.Ortak;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YPM.Birim.Genel.Birim.Generic;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Kurulum
{
    public class KurulumBirim
         : GenericBirim<KurulumGercek>, IKurulumBirim
    {
        private readonly YpmSebil _sebil;

        public KurulumBirim(YpmSebil sebil)
            : base(sebil)
        {
            _sebil = sebil;
        }

        public static IKurulumBirim OrnekVer()
        {
            return new KurulumBirim(new YpmSebil());
        }

        public async Task AtesleProsedurOlustur()
        {
            await _sebil.Database.ExecuteSqlCommandAsync(@"
                        create proc sp_Atesle
                        @query nvarchar(max)
                        as
                        begin
                            set nocount on
                                EXECUTE sp_executesql @query
                            set nocount off
                        end");
        }
    }
}
