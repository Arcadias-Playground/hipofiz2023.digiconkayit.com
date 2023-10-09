using Newtonsoft.Json;
using System;
using ModelRelation;

namespace Model
{
	public partial class KatilimciTablosuModel : KatilimciTablosuModelRelation
	{

		public string HtmlContent
		{
			get
			{
				return $"<table><tr><td>Ad</td><td>{Ad}</td><tr><tr><td>Soyad</td><td>{Soyad}</td><tr><tr><td>TCNo</td><td>{TCNo}</td><tr><tr><td>ePosta</td><td>{ePosta}</td><tr><tr><td>Telefon</td><td>{Telefon}</td><tr><tr><td>SicilNo</td><td>{SicilNo}</td><tr><tr><td>Branþ</td><td>{Branþ}</td><tr><tr><td>Meslek</td><td>{Meslek}</td><tr><tr><td>Unvan</td><td>{Unvan}</td><tr><tr><td>Hastane</td><td>{Hastane}</td><tr><tr><td>Ýlçe</td><td>{Ýlçe}</td><tr><tr><td>Sehir</td><td>{Sehir}</td><tr><tr><td>KonusmaciDurum</td><td>{(KonusmaciDurum ? "Konuþamcý" : "Konuþmacý Deðil")}</td><tr><tr><td>DogumTarihi</td><td>{DogumTarihi.ToShortDateString()}</td><tr><tr><td>BildiriDurum</td><td>{(BildiriDurum ? "Var" : "Yok")}</td><tr><tr><td>KVKK</td><td>{(KVKKOnay ? "Onaylýyorum" : "Onaylamýyorum")}</td><tr></table>";
			}
		}

		public virtual string FullJsonModel()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}