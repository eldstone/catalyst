using Catalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Catalyst.Db
{
	public class ServicePicture
		: AService<Picture>
	{
		/// c/d'tors

		public
		ServicePicture(
			DbContext context)
		: base(context)
		{

		}



		/// public methods

		//todo: as necessary
	}
}