using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ModelBase
{
    [Table("KatilimciTablosu")]
    public class KatilimciTablosuModelBase
    {
        [Key]
        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(36, ErrorMessage = "UzunlukUyari")]
        [Column("KatilimciID")]
        public virtual int KatilimciID { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Ad")]
        public virtual string Ad { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Soyad")]
        public virtual string Soyad { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("TCNo")]
        public virtual string TCNo { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("ePosta")]
        public virtual string ePosta { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Telefon")]
        public virtual string Telefon { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("SicilNo")]
        public virtual string SicilNo { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Branþ")]
        public virtual string Branþ { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Meslek")]
        public virtual string Meslek { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Unvan")]
        public virtual string Unvan { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Hastane")]
        public virtual string Hastane { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Ilce")]
        public virtual string Ilce { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [MaxLength(255, ErrorMessage = "UzunlukUyari")]
        [Column("Sehir")]
        public virtual string Sehir { get; set; }


        [Required(ErrorMessage = "BosUyari")]
        [Column("KonusmaciDurum")]
        public virtual bool KonusmaciDurum { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [DataType(DataType.Date, ErrorMessage = "GecersizUyari")]
        [Column("DogumTarihi")]
        public virtual DateTime DogumTarihi { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [Column("BildiriDurum")]
        public virtual bool BildiriDurum { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [Column("BildiriNo")]
        public virtual string BildiriNo { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [DataType(DataType.DateTime, ErrorMessage = "GecersizUyari")]
        [Column("GuncellenmeTarihi")]
        public virtual DateTime GuncellenmeTarihi { get; set; }

        [Required(ErrorMessage = "BosUyari")]
        [DataType(DataType.DateTime, ErrorMessage = "GecersizUyari")]
        [Column("EklenmeTarihi")]
        public virtual DateTime EklenmeTarihi { get; set; }

        public static int OzellikSayisi { get { return typeof(KatilimciTablosuModelBase).GetProperties().Count(x => !x.GetAccessors()[0].IsStatic); } }

        public virtual string BaseJsonModel()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
