using Catalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Catalyst.Db
{
	public class CatalystContext
		: DbContext
	{
		/// members

		const string DefaultConnect = "CataylstDb";

		public DbSet<Person> person { get; set; }
		public DbSet<Picture> picture { get; set; }



		/// c/d'tors

		///<summary>
		///		Default context constructor, using connection string in constant .DefaultConnect.
		///</summary>
		public CatalystContext()
			: base(DefaultConnect)
		{
			Debug.WriteLine(Database.Connection.ConnectionString);
			this.Database.Log = sql => Debug.WriteLine(sql);
		}



		/// private methods

		protected override void OnModelCreating(
			DbModelBuilder modelBuilder)
		{
			//disable plural table naming convention
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}