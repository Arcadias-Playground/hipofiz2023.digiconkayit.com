using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ModelBase;
using Model;

namespace ModelRelation
{
	public abstract class KatilimciTablosuModelRelation : KatilimciTablosuModelBase
	{
		public virtual string JsonModel()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}