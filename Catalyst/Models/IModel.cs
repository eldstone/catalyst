using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyst.Models
{
	public interface IModel
	{
		/// interface members 

		long id { get; set; }
		long created { get; set; }
		long modified { get; set; }



		/// interface methods (e.g. facade syntatic sugar, helper methods)

		//example
		bool Validate();

		//example
		Dictionary<string, string> ToDictionary();

		//etc...
	}
}
