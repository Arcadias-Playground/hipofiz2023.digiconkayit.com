using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ModelBase
{
	[Table("KatilimciTablosu")]
	public abstract class KatilimciTablosuModelBase
	{
		[Key]
		[Required(ErrorMessage = "BosUyari")]
		[Column("KatilimciID", Order = 0)]
		public virtual int KatilimciID { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("Ad", Order = 1)]
		public virtual string Ad { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("Soyad", Order = 2)]
		public virtual string Soyad { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("TCNo", Order = 3)]
		public virtual string TCNo { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[EmailAddress(ErrorMessage = "GecersizUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("ePosta", Order = 4)]
		public virtual string ePosta { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("Telefon", Order = 5)]
		public virtual string Telefon { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("SicilNo", Order = 6)]
		public virtual string SicilNo { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("Branş", Order = 7)]
		public virtual string Branş { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("Meslek", Order = 8)]
		public virtual string Meslek { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("Unvan", Order = 9)]
		public virtual string Unvan { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("Hastane", Order = 10)]
		public virtual string Hastane { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("İlçe", Order = 11)]
		public virtual string İlçe { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("Sehir", Order = 12)]
		public virtual string Sehir { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[Column("KonusmaciDurum", Order = 13)]
		public virtual bool KonusmaciDurum { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[DataType(DataType.DateTime, ErrorMessage = "GecersizUyari")]
		[Column("DogumTarihi", Order = 14)]
		public virtual DateTime DogumTarihi { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[MaxLength(255, ErrorMessage = "UzunlukUyari")]
		[Column("BildiriNo", Order = 15)]
		public virtual string BildiriNo { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[Column("BildiriDurum", Order = 16)]
		public virtual bool BildiriDurum { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[Column("KVKKOnay", Order = 17)]
		public virtual bool KVKKOnay { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[DataType(DataType.DateTime, ErrorMessage = "GecersizUyari")]
		[Column("GuncellenmeTarihi", Order = 18)]
		public virtual DateTime GuncellenmeTarihi { get; set; }

		[Required(ErrorMessage = "BosUyari")]
		[DataType(DataType.DateTime, ErrorMessage = "GecersizUyari")]
		[Column("EklenmeTarihi", Order = 19)]
		public virtual DateTime EklenmeTarihi { get; set; }


		public static int OzellikSayisi { get { return typeof(KatilimciTablosuModelBase).GetProperties().Count(x => !x.GetAccessors()[0].IsStatic); }}

		public static string SQLSutunSorgusu { get { return string.Join(", ", typeof(KatilimciTablosuModelBase).GetProperties().Where(x => !x.GetAccessors()[0].IsStatic).OrderBy(x => (x.GetCustomAttributes(typeof(ColumnAttribute), true).First() as ColumnAttribute).Order).Select(x => $"[KatilimciTablosu].[{x.Name}]")); }}

		public virtual string BaseJsonModel()
		{
			return JsonConvert.SerializeObject(this);
		}

	}
}