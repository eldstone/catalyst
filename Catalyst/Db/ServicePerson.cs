using Catalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace Catalyst.Db
{
	public class ServicePerson
		: AService<Person>
	{
		/// c/d'tors

		public
		ServicePerson(
			DbContext context)
		: base(context)
		{

		}



		/// public methods

		//todo: as necessary
	}
}