using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Catalyst.Models
{
	public class Person 
		: AModel
	{
		/// members 

		//todo: set field lengths, required, etc
		public string firstName { get; set; } = "";
		public string lastName { get; set; } = "";
		public long birthDate { get; set; }
		public string interest { get; set; } = ""; //note: in a full db, this could be normalized to its own model & relation
		public string address { get; set; } = ""; //note: in a full db, this could be normalized to its own model & relation



		/// relations

		public virtual Picture picture { get; set; }
		public long pictureId { get; set; }



		/// interface (AModel)

		public override bool Validate()
		{
			throw new NotImplementedException();
		}

	}
}