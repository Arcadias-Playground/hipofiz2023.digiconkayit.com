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
			VTIslem.SetCommandText("INSERT INTO KatilimciTablosu (KatilimciID, Ad, Soyad, Unvan, TCNo, ePosta, Telefon, Kurum, Ulke, OdemeTipiID, FaturaUnvan, FaturaAdres, VergiDairesi, VergiNo, GuncellenmeTarihi, EklenmeTarihi) VALUES (@KatilimciID, @Ad, @Soyad, @Unvan, @TCNo, @ePosta, @Telefon, @Kurum, @Ulke, @OdemeTipiID, @FaturaUnvan, @FaturaAdres, @VergiDairesi, @VergiNo, @GuncellenmeTarihi, @EklenmeTarihi)");
			VTIslem.AddWithValue("KatilimciID", YeniKayit.KatilimciID);
			VTIslem.AddWithValue("Ad", YeniKayit.Ad);
			VTIslem.AddWithValue("Soyad", YeniKayit.Soyad);
			VTIslem.AddWithValue("Unvan", YeniKayit.Unvan);
			VTIslem.AddWithValue("TCNo", YeniKayit.TCNo);
			VTIslem.AddWithValue("ePosta", YeniKayit.ePosta);
			VTIslem.AddWithValue("Telefon", YeniKayit.Telefon);
			VTIslem.AddWithValue("GuncellenmeTarihi", YeniKayit.GuncellenmeTarihi);
			VTIslem.AddWithValue("EklenmeTarihi", YeniKayit.EklenmeTarihi);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecBilgiModel KayitGuncelle(KatilimciTablosuModel GuncelKayit)
		{
			VTIslem.SetCommandText("UPDATE KatilimciTablosu SET Ad=@Ad, Soyad=@Soyad, Unvan=@Unvan, TCNo=@TCNo, ePosta=@ePosta, Telefon=@Telefon, Kurum=@Kurum, Ulke=@Ulke, OdemeTipiID=@OdemeTipiID, FaturaUnvan=@FaturaUnvan, FaturaAdres=@FaturaAdres, VergiDairesi=@VergiDairesi, VergiNo=@VergiNo, GuncellenmeTarihi=@GuncellenmeTarihi, EklenmeTarihi=@EklenmeTarihi WHERE KatilimciID=@KatilimciID");
			VTIslem.AddWithValue("Ad", GuncelKayit.Ad);
			VTIslem.AddWithValue("Soyad", GuncelKayit.Soyad);
			VTIslem.AddWithValue("Unvan", GuncelKayit.Unvan);
			VTIslem.AddWithValue("TCNo", GuncelKayit.TCNo);
			VTIslem.AddWithValue("ePosta", GuncelKayit.ePosta);
			VTIslem.AddWithValue("Telefon", GuncelKayit.Telefon);
			VTIslem.AddWithValue("GuncellenmeTarihi", GuncelKayit.GuncellenmeTarihi);
			VTIslem.AddWithValue("EklenmeTarihi", GuncelKayit.EklenmeTarihi);
			VTIslem.AddWithValue("KatilimciID", GuncelKayit.KatilimciID);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecBilgiModel KayitSil(string KatilimciID)
		{
			VTIslem.SetCommandText("DELETE FROM KatilimciTablosu WHERE KatilimciID=@KatilimciID");
			VTIslem.AddWithValue("KatilimciID", KatilimciID);
			return VTIslem.ExecuteNonQuery();
		}

		public virtual SurecVeriModel<KatilimciTablosuModel> KayitBilgisi(string KatilimciID)
		{
			VTIslem.SetCommandText("SELECT * FROM KatilimciTablosu WHERE KatilimciID = @KatilimciID");
			VTIslem.AddWithValue("KatilimciID", KatilimciID);
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.SingleResult);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				while (SModel.Reader.Read())
				{
					KayitBilgisiAl();
				}
				if (SDataModel is null)
				{
					SDataModel = new SurecVeriModel<KatilimciTablosuModel>
					{
						Sonuc = Sonuclar.VeriBulunamadi,
						KullaniciMesaji = "Belirtilen kayıt bulunamamıştır",
						HataBilgi = new HataBilgileri
						{
							HataAlinanKayitID = 0,
							HataKodu = 0,
							HataMesaji = "Belirtilen kayıt bulunamamıştır"
						}
					};
				}
			}
			else
			{
				SDataModel = new SurecVeriModel<KatilimciTablosuModel>
				{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataModel;
		}

		public virtual SurecVeriModel<IList<KatilimciTablosuModel>> KayitBilgileri()
		{
			VTIslem.SetCommandText("SELECT * FROM KatilimciTablosu");
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.Default);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				VeriListe = new List<KatilimciTablosuModel>();
				while (SModel.Reader.Read())
				{
					if (KayitBilgisiAl().Sonuc.Equals(Sonuclar.Basarili))
					{
						VeriListe.Add(SDataModel.Veriler);
					}
					else
					{
						SDataListModel = new SurecVeriModel<IList<KatilimciTablosuModel>>{
							Sonuc = SDataModel.Sonuc,
							KullaniciMesaji = SDataModel.KullaniciMesaji,
							HataBilgi = SDataModel.HataBilgi
						};
						VTIslem.CloseConnection();
						return SDataListModel;
					}
				}
				SDataListModel = new SurecVeriModel<IList<KatilimciTablosuModel>>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri listesi başarıyla çekildi",
					Veriler = VeriListe
				};
			}
			else
			{
				SDataListModel = new SurecVeriModel<IList<KatilimciTablosuModel>>{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataListModel;
		}

		SurecVeriModel<KatilimciTablosuModel> KayitBilgisiAl()
		{
			try
			{
				SDataModel = new SurecVeriModel<KatilimciTablosuModel>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri bilgisi başarıyla çekilmiştir.",
					Veriler = new KatilimciTablosuModel
					{
						//KatilimciID = SModel.Reader.GetString(0),
						Ad = SModel.Reader.GetString(1),
						Soyad = SModel.Reader.GetString(2),
						Unvan = SModel.Reader.GetString(3),
						TCNo = SModel.Reader.GetString(4),
						ePosta = SModel.Reader.GetString(5),
						Telefon = SModel.Reader.GetString(6),
					
						GuncellenmeTarihi = SModel.Reader.GetDateTime(14),
						EklenmeTarihi = SModel.Reader.GetDateTime(15),
					}
				};

			}
			catch (InvalidCastException ex)
			{
				SDataModel = new SurecVeriModel<KatilimciTablosuModel>{
					Sonuc = Sonuclar.Basarisiz,
					KullaniciMesaji = "Veri bilgisi çekilirken hatalı atama yapılmaya çalışıldı",
					HataBilgi = new HataBilgileri{
						HataMesaji = string.Format(@"{0}", ex.Message.Replace("'", "ʼ")),
						HataKodu = ex.HResult,
						HataAlinanKayitID = SModel.Reader.GetValue(0)
					}
				};
			}
			catch (Exception ex)
			{
				SDataModel = new SurecVeriModel<KatilimciTablosuModel>{
					Sonuc = Sonuclar.Basarisiz,
					KullaniciMesaji = "Veri bilgisi çekilirken hatalı atama yapılmaya çalışıldı",
					HataBilgi = new HataBilgileri{
						HataMesaji = string.Format(@"{0}", ex.Message.Replace("'", "ʼ")),
						HataKodu = ex.HResult,
						HataAlinanKayitID = SModel.Reader.GetValue(0)
					}
				};
			}
			return SDataModel;
		}

		public virtual SurecVeriModel<KatilimciTablosuModel> KayitBilgisiAl(int Baslangic, DbDataReader Reader)
		{
			try
			{
				SDataModel = new SurecVeriModel<KatilimciTablosuModel>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri bilgisi başarıyla çekilmiştir.",
					Veriler = new KatilimciTablosuModel{
						//KatilimciID = Reader.GetString(Baslangic + 0),
						Ad = Reader.GetString(Baslangic + 1),
						Soyad = Reader.GetString(Baslangic + 2),
						Unvan = Reader.GetString(Baslangic + 3),
						TCNo = Reader.GetString(Baslangic + 4),
						ePosta = Reader.GetString(Baslangic + 5),
						Telefon = Reader.GetString(Baslangic + 6),
						GuncellenmeTarihi = Reader.GetDateTime(Baslangic + 14),
						EklenmeTarihi = Reader.GetDateTime(Baslangic + 15),
					}
				};
			}
			catch (InvalidCastException ex)
			{
				SDataModel = new SurecVeriModel<KatilimciTablosuModel>{
					Sonuc = Sonuclar.Basarisiz,
					KullaniciMesaji = "Veri bilgisi çekilirken hatalı atama yapılmaya çalışıldı",
					HataBilgi = new HataBilgileri{
						HataMesaji = string.Format(@"{0}", ex.Message.Replace("'", "ʼ")),
						HataKodu = ex.HResult,
						HataAlinanKayitID = Reader.GetValue(0)
					}
				};
			}
			catch (Exception ex)
			{
				SDataModel = new SurecVeriModel<KatilimciTablosuModel>{
					Sonuc = Sonuclar.Basarisiz,
					KullaniciMesaji = "Veri bilgisi çekilirken hatalı atama yapılmaya çalışıldı",
						HataBilgi = new HataBilgileri{
						HataMesaji = string.Format(@"{0}", ex.Message.Replace("'", "ʼ")),
						HataKodu = ex.HResult,
						HataAlinanKayitID = Reader.GetValue(0)
					}
				};
			}
			return SDataModel;
		}

		public virtual SurecVeriModel<IList<KatilimciTablosuModel>> OdemeTipiBilgileri(int OdemeTipiID)
		{
			VTIslem.SetCommandText("SELECT * FROM KatilimciTablosu WHERE OdemeTipiID=@OdemeTipiID");
			VTIslem.AddWithValue("OdemeTipiID", OdemeTipiID);
			VTIslem.OpenConnection();
			SModel = VTIslem.ExecuteReader(CommandBehavior.Default);
			if (SModel.Sonuc.Equals(Sonuclar.Basarili))
			{
				VeriListe = new List<KatilimciTablosuModel>();
				while (SModel.Reader.Read())
				{
					if (KayitBilgisiAl().Sonuc.Equals(Sonuclar.Basarili))
					{
						VeriListe.Add(SDataModel.Veriler);
					}
					else
					{
						SDataListModel = new SurecVeriModel<IList<KatilimciTablosuModel>>{
							Sonuc = SDataModel.Sonuc,
							KullaniciMesaji = SDataModel.KullaniciMesaji,
							HataBilgi = SDataModel.HataBilgi
						};
						VTIslem.CloseConnection();
						return SDataListModel;
					}
				}
				SDataListModel = new SurecVeriModel<IList<KatilimciTablosuModel>>{
					Sonuc = Sonuclar.Basarili,
					KullaniciMesaji = "Veri listesi başarıyla çekildi",
					Veriler = VeriListe
				};
			}
			else
			{
				SDataListModel = new SurecVeriModel<IList<KatilimciTablosuModel>>{
					Sonuc = SModel.Sonuc,
					KullaniciMesaji = SModel.KullaniciMesaji,
					HataBilgi = SModel.HataBilgi
				};
			}
			VTIslem.CloseConnection();
			return SDataListModel;
		}

	}
}