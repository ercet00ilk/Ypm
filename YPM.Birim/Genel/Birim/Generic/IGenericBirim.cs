using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace YPM.Birim.Genel.Birim.Generic
{
    public partial interface IGenericBirim<T>
        : IDisposable
          where T : class
    {
        T Ekle(T varlik);
        Task<T> EkleAsync(T varlik);
        int Say();
        Task<int> SayAsync();
        void Sil(T varlik);
        Task<int> SilAsync(T varlik);
        T Bul(Expression<Func<T, bool>> eslesen);
        ICollection<T> BulKoleksiyon(Expression<Func<T, bool>> eslesen);
        Task<ICollection<T>> BulKoleksiyonAsync(Expression<Func<T, bool>> eslesen);
        Task<T> BulAsync(Expression<Func<T, bool>> eslesen);
        IQueryable<T> BulEslesen(Expression<Func<T, bool>> belirti);
        Task<ICollection<T>> BulEslesenAsyn(Expression<Func<T, bool>> belirti);
        T Getir(int id);
        IQueryable<T> GetirTumKoleksiyon();
        Task<ICollection<T>> GetirTumKoleksiyonAsyn();
        IQueryable<T> GetirTumKoleksiyon(params Expression<Func<T, object>>[] dahilOzellik);
        Task<T> GetirAsync(int id);
        void Kaydet();
        Task<int> KaydetAsync();
        T Guncelle(T varlik, object anahtar);
        Task<T> GuncelleAsyn(T varlik, object anahtar);
    }
}
