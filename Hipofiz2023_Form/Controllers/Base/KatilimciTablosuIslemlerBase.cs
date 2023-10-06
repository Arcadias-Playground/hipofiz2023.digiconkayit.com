using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using VeritabaniIslemSaglayici.Access;

namespace VeritabaniIslemMerkeziBase
{
    public abstract class KatilimciTablosuIslemlerBase
    {
        public VTOperatorleri VTIslem;

        public List<KatilimciTablosuModel> VeriListe;

        public SurecBilgiModel SModel;
        public SurecVeriModel<KatilimciTablosuModel> SDataModel;
        public SurecVeriModel<IList<KatilimciTablosuModel>> SDataListModel;

        public KatilimciTablosuIslemlerBase()
        {
            VTIslem = new VTOperatorleri();
        }

        public KatilimciTablosuIslemlerBase(OleDbTransaction Transcation)
        {
            VTIslem = new VTOperatorleri(Transcation);
        }

        public virtual SurecBilgiModel YeniKayitEkle(KatilimciTablosuModel YeniKayit)
        {
            VTIslem.SetCommandText("INSERT INTO KatilimciTablosu (Ad, Soyad, TCNo, ePosta, Telefon, SicilNo, Branş, Meslek, Unvan, Hastane, İlçe, Sehir, KonusmaciDurum, DogumTarihi , BildiriNo , BildiriDurum , GuncellenmeTarihi ,EklenmeTarihi ) VALUES (@Ad, @Soyad, @TCNo, @ePosta, @Telefon, @SicilNo, @Branş, @Meslek, @Unvan, @Hastane, @İlçe, @Sehir, @KonusmaciDurum, @DogumTarihi , @BildiriNo , @BildiriDurum , @GuncellenmeTarihi , @EklenmeTarihi )");
            VTIslem.AddWithValue("Ad", YeniKayit.Ad);
            VTIslem.AddWithValue("Soyad", YeniKayit.Soyad);
            VTIslem.AddWithValue("TCNo", YeniKayit.TCNo);
            VTIslem.AddWithValue("ePosta", YeniKayit.ePosta);
            VTIslem.AddWithValue("Telefon", YeniKayit.Telefon);
            VTIslem.AddWithValue("SicilNo", YeniKayit.SicilNo);
            VTIslem.AddWithValue("Branş", YeniKayit.Branş);
            VTIslem.AddWithValue("Meslek", YeniKayit.Meslek);
            VTIslem.AddWithValue("Unvan", YeniKayit.Unvan);
            VTIslem.AddWithValue("Hastane", YeniKayit.Hastane);
            VTIslem.AddWithValue("İlçe", YeniKayit.İlçe);
            VTIslem.AddWithValue("Sehir", YeniKayit.Sehir);
            VTIslem.AddWithValue("KonusmaciDurum", YeniKayit.KonusmaciDurum);
            VTIslem.AddWithValue("DogumTarihi", YeniKayit.DogumTarihi);
            VTIslem.AddWithValue("BildiriNo", YeniKayit.BildiriNo);
            VTIslem.AddWithValue("BildiriDurum", YeniKayit.BildiriDurum);
            VTIslem.AddWithValue("GuncellenmeTarihi", YeniKayit.GuncellenmeTarihi);
            VTIslem.AddWithValue("EklenmeTarihi", YeniKayit.EklenmeTarihi);
            return VTIslem.ExecuteNonQuery();
        }





    }
}

