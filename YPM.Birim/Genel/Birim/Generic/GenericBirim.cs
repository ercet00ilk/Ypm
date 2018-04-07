//Copyright 2017 (c) YedekParcaMerkezi(YPM). Tüm hakkı saklıdır. By Erdal Çetin
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using YPM.SuretVarlik.Mulk.Enstruman;
using YPM.SuretVarlik.Mulk.Model.Istisna.Yapi.Birim;
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
            T donenDeger = null;

            bool IslemOnay = new bool();
            try
            {
                donenDeger = _kur.SingleOrDefault(eslesen);

                IslemOnay = true;
            }
            catch (Exception ex)
            {
                IslemOnay = false;

                using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                {
                    istisna.TamYol = GetType().FullName;
                    istisna.Method = MethodBase.GetCurrentMethod().Name;
                    istisna.KisiId = 0;
                    istisna.Hata = ex.ToString();
                    istisna.TabanHata = ex.GetBaseException().ToString();
                    istisna.Sonuc = " public virtual T Bul(Expression<Func<T, bool>> eslesen) ";
                    istisna.IslemOnay = IslemOnay;
                    istisna.Tarih = Tarih.GuncelTarihVer();
                    istisna.Veri = ex.Data;
                    istisna.Link = ex.HelpLink;
                    istisna.HSonuc = ex.HResult;
                    istisna.Kaynak = ex.Source;
                    istisna.Mesaj = ex.GetBaseException().Message;
                    istisna.YiginIzleme = ex.StackTrace;
                    istisna.Yazdir(istisna);
                }
            }

            return donenDeger;
        }

        public virtual async Task<T> BulAsync(Expression<Func<T, bool>> eslesen)
        {
            T donenDeger = null;

            bool IslemOnay = new bool();

            try
            {
                donenDeger = await _kur.SingleOrDefaultAsync(eslesen);

                IslemOnay = true;
            }
            catch (Exception ex)
            {
                IslemOnay = false;

                using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                {
                    istisna.TamYol = GetType().FullName;
                    istisna.Method = MethodBase.GetCurrentMethod().Name;
                    istisna.KisiId = 0;
                    istisna.Hata = ex.ToString();
                    istisna.TabanHata = ex.GetBaseException().ToString();
                    istisna.Sonuc = " public virtual async Task<T> BulAsync(Expression<Func<T, bool>> eslesen) ";
                    istisna.IslemOnay = IslemOnay;
                    istisna.Tarih = Tarih.GuncelTarihVer();
                    istisna.Veri = ex.Data;
                    istisna.Link = ex.HelpLink;
                    istisna.HSonuc = ex.HResult;
                    istisna.Kaynak = ex.Source;
                    istisna.Mesaj = ex.GetBaseException().Message;
                    istisna.YiginIzleme = ex.StackTrace;
                    istisna.Yazdir(istisna);
                }
            }


            return donenDeger;
        }

        public virtual IQueryable<T> BulEslesen(Expression<Func<T, bool>> belirti)
        {
            IQueryable<T> donenDeger = null;

            bool IslemOnay = new bool();

            try
            {
                donenDeger = _kur.Where(belirti);

                IslemOnay = true;
            }
            catch (Exception ex)
            {
                IslemOnay = false;

                using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                {
                    istisna.TamYol = GetType().FullName;
                    istisna.Method = MethodBase.GetCurrentMethod().Name;
                    istisna.KisiId = 0;
                    istisna.Hata = ex.ToString();
                    istisna.TabanHata = ex.GetBaseException().ToString();
                    istisna.Sonuc = " public virtual IQueryable<T> BulEslesen(Expression<Func<T, bool>> belirti) ";
                    istisna.IslemOnay = IslemOnay;
                    istisna.Tarih = Tarih.GuncelTarihVer();
                    istisna.Veri = ex.Data;
                    istisna.Link = ex.HelpLink;
                    istisna.HSonuc = ex.HResult;
                    istisna.Kaynak = ex.Source;
                    istisna.Mesaj = ex.GetBaseException().Message;
                    istisna.YiginIzleme = ex.StackTrace;
                    istisna.Yazdir(istisna);
                }
            }


            return donenDeger;
        }

        public virtual async Task<ICollection<T>> BulEslesenAsyn(Expression<Func<T, bool>> belirti)
        {
            ICollection<T> donenDeger = null;

            bool IslemOnay = new bool();

            try
            {
                donenDeger = await _kur.Where(belirti).ToListAsync();

                IslemOnay = true;
            }
            catch (Exception ex)
            {
                IslemOnay = false;

                using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                {
                    istisna.TamYol = GetType().FullName;
                    istisna.Method = MethodBase.GetCurrentMethod().Name;
                    istisna.KisiId = 0;
                    istisna.Hata = ex.ToString();
                    istisna.TabanHata = ex.GetBaseException().ToString();
                    istisna.Sonuc = " public virtual async Task<ICollection<T>> BulEslesenAsyn(Expression<Func<T, bool>> belirti) ";
                    istisna.IslemOnay = IslemOnay;
                    istisna.Tarih = Tarih.GuncelTarihVer();
                    istisna.Veri = ex.Data;
                    istisna.Link = ex.HelpLink;
                    istisna.HSonuc = ex.HResult;
                    istisna.Kaynak = ex.Source;
                    istisna.Mesaj = ex.GetBaseException().Message;
                    istisna.YiginIzleme = ex.StackTrace;
                    istisna.Yazdir(istisna);
                }
            }


            return donenDeger;
        }

        public ICollection<T> BulKoleksiyon(Expression<Func<T, bool>> eslesen)
        {
            ICollection<T> donenDeger = null;

            bool IslemOnay = new bool();


            try
            {
                donenDeger = _kur.Where(eslesen).ToList();

                IslemOnay = true;
            }
            catch (Exception ex)
            {
                IslemOnay = false;

                using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                {
                    istisna.TamYol = GetType().FullName;
                    istisna.Method = MethodBase.GetCurrentMethod().Name;
                    istisna.KisiId = 0;
                    istisna.Hata = ex.ToString();
                    istisna.TabanHata = ex.GetBaseException().ToString();
                    istisna.Sonuc = " public ICollection<T> BulKoleksiyon(Expression<Func<T, bool>> eslesen) ";
                    istisna.IslemOnay = IslemOnay;
                    istisna.Tarih = Tarih.GuncelTarihVer();
                    istisna.Veri = ex.Data;
                    istisna.Link = ex.HelpLink;
                    istisna.HSonuc = ex.HResult;
                    istisna.Kaynak = ex.Source;
                    istisna.Mesaj = ex.GetBaseException().Message;
                    istisna.YiginIzleme = ex.StackTrace;
                    istisna.Yazdir(istisna);
                }
            }


            return donenDeger;
        }

        public async Task<ICollection<T>> BulKoleksiyonAsync(Expression<Func<T, bool>> eslesen)
        {
            ICollection<T> donenDeger = null;

            bool IslemOnay = new bool();


            try
            {
                donenDeger = await _kur.Where(eslesen).ToListAsync();

                IslemOnay = true;
            }
            catch (Exception ex)
            {
                IslemOnay = false;

                using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                {
                    istisna.TamYol = GetType().FullName;
                    istisna.Method = MethodBase.GetCurrentMethod().Name;
                    istisna.KisiId = 0;
                    istisna.Hata = ex.ToString();
                    istisna.TabanHata = ex.GetBaseException().ToString();
                    istisna.Sonuc = " public async Task<ICollection<T>> BulKoleksiyonAsync(Expression<Func<T, bool>> eslesen) ";
                    istisna.IslemOnay = IslemOnay;
                    istisna.Tarih = Tarih.GuncelTarihVer();
                    istisna.Veri = ex.Data;
                    istisna.Link = ex.HelpLink;
                    istisna.HSonuc = ex.HResult;
                    istisna.Kaynak = ex.Source;
                    istisna.Mesaj = ex.GetBaseException().Message;
                    istisna.YiginIzleme = ex.StackTrace;
                    istisna.Yazdir(istisna);
                }
            }


            return donenDeger;
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
            T donenDeger = null;

            bool IslemOnay = new bool();

            using (var transaction = _sebil.Database.BeginTransaction())
            {
                try
                {
                    _kur.Add(varlik);
                    _sebil.SaveChanges();
                    donenDeger = varlik;

                    IslemOnay = true;
                }
                catch (Exception ex)
                {
                    IslemOnay = false;

                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public virtual T Ekle(T varlik) ";
                        istisna.IslemOnay = IslemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }
                }
                finally
                {
                    if (IslemOnay) transaction.Commit();
                    else transaction.Rollback();
                }
            }

            return donenDeger;
        }

        public virtual async Task<T> EkleAsync(T varlik)
        {
            T donenDeger = null;

            bool IslemOnay = new bool();

           
                try
                {
                    _kur.Add(varlik);
                    await _sebil.SaveChangesAsync();
                    donenDeger = varlik;

                    IslemOnay = true;
                }
                catch (Exception ex)
                {
                    IslemOnay = false;

                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public virtual async Task<T> EkleAsync(T varlik) ";
                        istisna.IslemOnay = IslemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }
                }
               

            return donenDeger;
        }

        public T Getir(int id)
        {
            T donenDeger = null;

            bool IslemOnay = new bool();

           
                try
                {
                    donenDeger = _kur.Find(id);

                    IslemOnay = true;
                }
                catch (Exception ex)
                {
                    IslemOnay = false;

                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public T Getir(int id) ";
                        istisna.IslemOnay = IslemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }
                }
               

            return donenDeger;
        }

        public virtual async Task<T> GetirAsync(int id)
        {
            T donenDeger = null;

            bool IslemOnay = new bool();

                try
                {
                    donenDeger = await _kur.FindAsync(id);

                    IslemOnay = true;
                }
                catch (Exception ex)
                {
                    IslemOnay = false;

                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public virtual async Task<T> GetirAsync(int id) ";
                        istisna.IslemOnay = IslemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }
                }
               

            return donenDeger;
        }

        public IQueryable<T> GetirTumKoleksiyon(params Expression<Func<T, object>>[] dahilOzellikler)
        {
            IQueryable<T> donenDeger = null;

            bool IslemOnay = new bool();

            
                try
                {
                    IQueryable<T> sorgu = GetirTumKoleksiyon();

                    foreach (Expression<Func<T, object>> dahilOzellik in dahilOzellikler)
                    {
                        sorgu = sorgu.Include<T, object>(dahilOzellik);
                    }

                    donenDeger = sorgu;

                    IslemOnay = true;
                }
                catch (Exception ex)
                {
                    IslemOnay = false;

                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public IQueryable<T> GetirTumKoleksiyon(params Expression<Func<T, object>>[] dahilOzellikler) ";
                        istisna.IslemOnay = IslemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }
                }
              

            return donenDeger;
        }

        public IQueryable<T> GetirTumKoleksiyon()
        {
            IQueryable<T> donenDeger = null;

            bool IslemOnay = new bool();

           
                try
                {
                    donenDeger = _kur;

                    IslemOnay = true;
                }
                catch (Exception ex)
                {
                    IslemOnay = false;

                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public IQueryable<T> GetirTumKoleksiyon() ";
                        istisna.IslemOnay = IslemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }
                }
               

            return donenDeger;
        }

        public virtual async Task<ICollection<T>> GetirTumKoleksiyonAsyn()
        {
            ICollection<T> donenDeger = null;

            bool IslemOnay = new bool();

            
                try
                {
                    donenDeger = await _kur.ToListAsync();

                    IslemOnay = true;
                }
                catch (Exception ex)
                {
                    IslemOnay = false;

                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public virtual async Task<ICollection<T>> GetirTumKoleksiyonAsyn() ";
                        istisna.IslemOnay = IslemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }
                }
               

            return donenDeger;
        }

        public T Guncelle(T varlik, object anahtar)
        {
            T donenDeger = null;

            bool IslemOnay = new bool();

           
                try
                {
                    if (varlik == null) return null;
                    T varMi = _kur.Find(anahtar);
                    if (varMi != null)
                    {
                        _sebil.Entry(varMi).CurrentValues.SetValues(varlik);
                        _sebil.SaveChanges();
                    }

                    donenDeger = varMi;

                    IslemOnay = true;
                }
                catch (Exception ex)
                {
                    IslemOnay = false;

                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public T Guncelle(T varlik, object anahtar) ";
                        istisna.IslemOnay = IslemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }
                }
               

            return donenDeger;
        }

        public virtual async Task<T> GuncelleAsyn(T varlik, object anahtar)
        {
            T donenDeger = null;

            bool IslemOnay = new bool();

                try
                {
                    if (varlik == null) return null;
                    T varMi = await _kur.FindAsync(anahtar);
                    if (varMi != null)
                    {
                        _sebil.Entry(varMi).CurrentValues.SetValues(varlik);
                        await _sebil.SaveChangesAsync();
                    }
                    donenDeger = varMi;

                    IslemOnay = true;
                }
                catch (Exception ex)
                {
                    IslemOnay = false;

                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public virtual async Task<T> GuncelleAsyn(T varlik, object anahtar) ";
                        istisna.IslemOnay = IslemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }
                }
                

            return donenDeger;
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

        public async Task SilAsync(int id)
        {
            bool IslemOnay = new bool();

         
                try
                {
                    T SilinecekVarlik = _kur.Find(id);
                    _kur.Remove(SilinecekVarlik);
                    await _sebil.SaveChangesAsync();
                    IslemOnay = true;
                }
                catch (Exception ex)
                {
                    IslemOnay = false;

                    using (BirimIstisna istisna = BirimIstisna.YeniIstisna())
                    {
                        istisna.TamYol = GetType().FullName;
                        istisna.Method = MethodBase.GetCurrentMethod().Name;
                        istisna.KisiId = 0;
                        istisna.Hata = ex.ToString();
                        istisna.TabanHata = ex.GetBaseException().ToString();
                        istisna.Sonuc = " public async Task SilAsync(int id) ";
                        istisna.IslemOnay = IslemOnay;
                        istisna.Tarih = Tarih.GuncelTarihVer();
                        istisna.Veri = ex.Data;
                        istisna.Link = ex.HelpLink;
                        istisna.HSonuc = ex.HResult;
                        istisna.Kaynak = ex.Source;
                        istisna.Mesaj = ex.GetBaseException().Message;
                        istisna.YiginIzleme = ex.StackTrace;
                        istisna.Yazdir(istisna);
                    }
                }
                

            return;
        }

        public virtual async Task<int> SilAsync(T varlik)
        {
            _kur.Remove(varlik);
            return await _sebil.SaveChangesAsync();
        }
    }
}