using Model;
using System;
using System.Data.OleDb;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeritabaniIslemMerkezi;
using VeritabaniIslemMerkezi.Access;

namespace Hipofiz2023_Form
{
    public partial class Default : System.Web.UI.Page
    {
        StringBuilder Uyarilar = new StringBuilder();
        BilgiKontrolMerkezi Kontrol = new BilgiKontrolMerkezi();

        SurecBilgiModel SModel;

        KatilimciTablosuModel KModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem li = new ListItem { Value = string.Empty, Text = "Select" };

                ddl_BildiriDurum.DataBind();
                ddl_BildiriDurum.Items.Insert(0, li);

                ddl_KonusmaciDurum.DataBind();
                ddl_KonusmaciDurum.Items.Insert(0, li);

            }
        }

        protected void ddl_BildiriDurum_SelectedIndexChanged(object sender, EventArgs e)
        {
            tr_BildiriNo.Visible = string.IsNullOrEmpty(ddl_BildiriDurum.SelectedValue) ? false : Convert.ToBoolean(ddl_BildiriDurum.SelectedValue);
            Kontrol.Temizle(txtBildiriNo);
        }

        protected void lnkbtnKayitOl_Click(object sender, EventArgs e)
        {
            KModel = new KatilimciTablosuModel
            {
                Ad = Kontrol.KelimeKontrol(txtAd, "Adınız boş bırakılamaz.", ref Uyarilar),
                Soyad = Kontrol.KelimeKontrol(txtSoyad, "Soyadınız boş bırakılamaz.", ref Uyarilar),
                TCNo = Kontrol.KelimeKontrol(txtTCNo, "Tc No boş bırakılamaz.", ref Uyarilar),
                SicilNo = Kontrol.KelimeKontrol(txtSicilNo, "Sicil numaranız boş bırakılamaz.", ref Uyarilar),
                Branş = Kontrol.KelimeKontrol(txtBranş, "Branşınız boş bırakılamaz.", ref Uyarilar),
                Meslek = Kontrol.KelimeKontrol(txtMeslek, "Meslek boş bırakılamaz.", ref Uyarilar),
                Unvan = Kontrol.KelimeKontrol(txtUnvan, "Unvan boş bırakılamaz.", ref Uyarilar),
                Hastane = Kontrol.KelimeKontrol(txtHastane, "Hastane boş bırakılamaz.", ref Uyarilar),
                Sehir = Kontrol.KelimeKontrol(txtSehir, "İl boş bırakılamaz.", ref Uyarilar),
                Ilce = Kontrol.KelimeKontrol(txtIlce, "İlçe boş bırakılamaz.", ref Uyarilar),
                Telefon = Kontrol.KelimeKontrol(txtTelefon, "Telephone cannot be empty", ref Uyarilar),
                ePosta = Kontrol.ePostaKontrol(txtePosta, "E mail boş bırakılamaz", "Geçersiz e posta girildi.", ref Uyarilar),
                DogumTarihi = Kontrol.TariheKontrol(txtDogumTarihi, "Doğum tarihi boş bırakılamaz.", "Geçersiz tarih girdiniz.", ref Uyarilar),
                KonusmaciDurum = Kontrol.BoolKontrol(ddl_KonusmaciDurum.SelectedValue, "Konuşmacı olup olmadığınızı seçmediniz!", "", ref Uyarilar),
                BildiriDurum = Kontrol.BoolKontrol(ddl_BildiriDurum.SelectedValue, "Bildirinizin olup olmadığını seçmediniz!", ref Uyarilar),

                BildiriNo = string.Empty,
                GuncellenmeTarihi = Kontrol.Simdi(),
                EklenmeTarihi = Kontrol.Simdi(),

            };
            if (string.IsNullOrEmpty(ddl_BildiriDurum.SelectedValue))
                Uyarilar.Append("<p>Please select status of accepted paper</p>");
            else if (Convert.ToBoolean(ddl_BildiriDurum.SelectedValue))
                KModel.BildiriNo = Kontrol.KelimeKontrol(txtBildiriNo, "Paper number cannot be empty", ref Uyarilar);


            if (string.IsNullOrEmpty(Uyarilar.ToString()))
            {
                using (OleDbConnection cnn = ConnectionBuilder.DefaultConnection())
                {
                    ConnectionBuilder.OpenConnection(cnn);
                    using (OleDbTransaction trn = cnn.BeginTransaction())
                    {
                        SModel = new KatilimciTablosuIslemler(trn).YeniKayitEkle(KModel);

                        if (SModel.Sonuc.Equals(Sonuclar.Basarili))
                        {
                            KModel.KatilimciID = Convert.ToInt32(SModel.YeniKayitID);


                            if (SModel.Sonuc.Equals(Sonuclar.Basarili))
                            {
                                trn.Commit();
                            }
                            else
                            {
                                trn.Rollback();
                                BilgiKontrolMerkezi.UyariEkrani(this, $"UyariBilgilendirme('', '<p>There is an error occured while saving payment information</p><p>Error message : {SModel.HataBilgi.HataMesaji}</p>', false);", false);
                            }
                        }
                        else
                        {
                            trn.Rollback();
                            BilgiKontrolMerkezi.UyariEkrani(this, $"UyariBilgilendirme('', '<p>There is an error occured while saving personel information</p><p>Error message : {SModel.HataBilgi.HataMesaji}</p>', false);", false);
                        }
                    }
                    ConnectionBuilder.CloseConnection(cnn);
                }
            }
            else
            {
                BilgiKontrolMerkezi.UyariEkrani(this, $"UyariBilgilendirme('', '{Uyarilar}', false);", false);
            }

        }
    }
}