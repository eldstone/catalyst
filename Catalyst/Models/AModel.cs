using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Catalyst.Models
{
	/// <summary>
	/// Default implementation of IModel
	/// </summary>
	public abstract class AModel
		: IModel
	{
		/// members 

		public long id { get; set; } //todo: consider leaving out id, as it must often be attributed in derived classes
		public long created { get; set; }
		public long modified { get; set; }



		/// c/d'tors

		public AModel()
		{
		}



		/// public methods (e.g. facade syntatic sugar)

		abstract public bool Validate();

		/// <summary>
		/// Get key/value pairs of data.  (Example of common model helper method)
		/// </summary>
		/// <returns>key/value Dictionary</returns>
		public Dictionary<string, string>
		ToDictionary()
		{
			var ret = new Dictionary<string, string>();
			var props = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

			foreach (var info in props)
			{
				var value = info.GetValue(this, null);
				ret.Add(info.Name, (value == null) ? null: value.ToString());
			}

			return ret;
		}

		//FromDictionary, etc...
	}
}