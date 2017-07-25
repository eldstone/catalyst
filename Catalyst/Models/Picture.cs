using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Catalyst.Models
{
	public class Picture : AModel
	{
		/// members 

		//todo: set field lengths, required, etc
		[Key]
		[ForeignKey("person")]
		public new long id {
			get { return base.id; }
			set { base.id = value; } }
		public string mimeType { get; set; } = "";
		public long size { get; set; }
		public string path { get; set; } = ""; //[string path] or [byte[] data], but not both
		//public Byte[] data { get; set; }



		/// relations

		public virtual Person person { get; set; }
		public long personId { get; set; }



		/// interface (AModel)

		public override bool Validate()
		{
			throw new NotImplementedException();
		}
	}
}