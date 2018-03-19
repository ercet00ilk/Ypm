//Copyright 2017 (c) YedekParcaMerkezi(YPM). Tüm hakkı saklıdır. By Erdal Çetin
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using YPM.Veri.Kaynak;

namespace YPM.Birim.Genel.Birim.Generic
{

    public abstract class GenericBirim<T>
        : IGenericBirim<T>
        where T : class
    {
        private YpmSebil _sebil;
        private DbSet<T> _kur;
        private bool Disposed { get; set; }


        public GenericBirim(YpmSebil sebil)
        {
            _sebil = sebil;
            _kur = sebil.Set<T>();
        }

        public virtual T Bul(Expression<Func<T, bool>> eslesen)
        {
            return _kur.SingleOrDefault(eslesen);
        }

        public virtual async Task<T> BulAsync(Expression<Func<T, bool>> eslesen)
        {
            return await _kur.SingleOrDefaultAsync(eslesen);
        }

        public virtual IQueryable<T> BulEslesen(Expression<Func<T, bool>> belirti)
        {
            IQueryable<T> sorgu = _kur.Where(belirti);
            return sorgu;
        }

        public virtual async Task<ICollection<T>> BulEslesenAsyn(Expression<Func<T, bool>> belirti)
        {
            return await _kur.Where(belirti).ToListAsync();
        }

        public ICollection<T> BulKoleksiyon(Expression<Func<T, bool>> eslesen)
        {
            return _kur.Where(eslesen).ToList();
        }

        public async Task<ICollection<T>> BulKoleksiyonAsync(Expression<Func<T, bool>> eslesen)
        {
            return await _kur.Where(eslesen).ToListAsync();
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
                    _sebil.Dispose();
                }
                Disposed = true;
            }
        }

        public virtual T Ekle(T varlik)
        {
            _kur.Add(varlik);
            _sebil.SaveChanges();
            return varlik;
        }

        public virtual async Task<T> EkleAsync(T varlik)
        {
            _kur.Add(varlik);
            await _sebil.SaveChangesAsync();
            return varlik;
        }

        public T Getir(int id)
        {
            return _kur.Find(id);
        }

        public virtual async Task<T> GetirAsync(int id)
        {
            return await _kur.FindAsync(id);
        }

        public IQueryable<T> GetirTumKoleksiyon(params Expression<Func<T, object>>[] dahilOzellikler)
        {
            IQueryable<T> sorgu = GetirTumKoleksiyon();

            foreach (Expression<Func<T, object>> dahilOzellik in dahilOzellikler)
            {
                sorgu = sorgu.Include<T, object>(dahilOzellik);
            }

            return sorgu;
        }

        public IQueryable<T> GetirTumKoleksiyon()
        {
            return _kur;
        }

        public virtual async Task<ICollection<T>> GetirTumKoleksiyonAsyn()
        {
            return await _kur.ToListAsync();
        }

        public T Guncelle(T varlik, object anahtar)
        {
            if (varlik == null) return null;
            T varMi = _kur.Find(anahtar);
            if (varMi != null)
            {
                _sebil.Entry(varMi).CurrentValues.SetValues(varlik);
                _sebil.SaveChanges();
            }
            return varMi;
        }

        public virtual async Task<T> GuncelleAsyn(T varlik, object anahtar)
        {
            if (varlik == null) return null;
            T varMi = await _kur.FindAsync(anahtar);
            if (varMi != null)
            {
                _sebil.Entry(varMi).CurrentValues.SetValues(varlik);
                await _sebil.SaveChangesAsync();
            }
            return varMi;
        }

        public virtual void Kaydet()
        {
            _sebil.SaveChanges();
        }

        public virtual async Task<int> KaydetAsync()
        {
            return await _sebil.SaveChangesAsync();
        }

        public int Say()
        {
            return _kur.Count();
        }

        public async Task<int> SayAsync()
        {
            return await _kur.CountAsync();
        }

        public virtual void Sil(T varlik)
        {
            _kur.Remove(varlik);
            _sebil.SaveChanges();
        }

        public virtual async Task<int> SilAsync(T varlik)
        {
            _kur.Remove(varlik);
            return await _sebil.SaveChangesAsync();
        }
    }
}