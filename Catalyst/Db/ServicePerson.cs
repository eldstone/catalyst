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

		/// <summary>
		/// Return a linq tree for persons with first or last name containing the expression
		/// </summary>
		/// <param name="search">case in-sensative string to find in first or last name</param>
		/// <returns>Queryable linq expression</returns>
		public IQueryable<Person>
		FindAllQueryByName(
			string search)
		{
			//search
			return this.FindAllQuery(
				p => p.lastName.ToUpper().Contains(search)
					|| p.firstName.ToUpper().Contains(search))
				.OrderBy(p => p.lastName);
		}


		//todo: as necessary
	}
}