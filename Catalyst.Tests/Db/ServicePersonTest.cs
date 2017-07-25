using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalyst.Db;
using Catalyst.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;

namespace Catalyst.Tests.Db
{
	[TestClass]
	public class ServicePersonTest
	{
		/// members

		protected DbContext db;
		protected List<Person> examples;
		protected ServicePerson repo;



		/// init

		[ClassInitialize]
		public static void 
		ClassSetup(
			TestContext context)
		{
			//define DataDirectory ... this could make a good base clase to inherit from
			AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(context.TestDeploymentDir, string.Empty));
		}


		[TestInitialize]
		public void
		Init()
		{
			this.examples = Initialize.ExamplePersons();
			this.db = new CatalystContext(); // or DI test-specific context
			this.db.Database.Initialize(true); // force db recreation
			this.repo = new ServicePerson(this.db);
		}



		/// test methods

		[TestMethod]
		public void
		ServicePerson_Read()
		{
			foreach (var ex in this.examples)
			{
				var y = this.repo.Read(ex.id);
				Assert.IsNotNull(y);
				Assert.AreEqual(ex.id, y.id);
				Assert.AreEqual(ex.firstName, y.firstName);
				Assert.AreEqual(ex.lastName, y.lastName);
				Assert.AreEqual(ex.interest, y.interest);
				Assert.AreEqual(ex.address, y.address);
				//Assert.AreEqual(ex.id, y.pictureId); //foreign key lookup doesn't get auto-populated by EF on store
			}
		}


		[TestMethod]
		public void
		ServicePerson_ReadAll()
		{
			var y = this.repo.ReadAll();
			Assert.IsNotNull(y);
			Assert.AreEqual(this.examples.Count, y.Count);

			Person z;
			foreach (var ex in this.examples)
			{
				//this could be mapped or linq'd, instead
				z = null;
				foreach (var i in y)
					if (i.id == ex.id)
						z = i;

				Assert.IsNotNull(z);
				Assert.AreEqual(ex.id, z.id);
				Assert.AreEqual(ex.firstName, z.firstName);
				Assert.AreEqual(ex.lastName, z.lastName);
				Assert.AreEqual(ex.interest, z.interest);
				Assert.AreEqual(ex.address, z.address);
			}
		}


		[TestMethod]
		public void
		ServicePerson_FindAll()
		{
			var y = this.repo.FindAll(p => p.lastName.ToUpper().Contains("HO")).ToList();
			Assert.IsNotNull(y);
			Assert.AreEqual(2, y.Count);

			var b = y.Where(p => p.lastName == "Thomsen");
			Assert.IsNotNull(b);

			var c = y.Where(p => p.lastName == "Horton");
			Assert.IsNotNull(c);

/*
			var y = this.repo.FindAll(p => p.lastName.ToUpper().Contains("AL"));
			Assert.IsNotNull(y);
			Assert.AreEqual(2, y.Count);

			var a = y.Where(p => p.lastName == "Alexander");
			Assert.IsNotNull(a);

			var b = y.Where(p => p.lastName == "Alonso");
			Assert.IsNotNull(b);
*/
	}


		// ..create, read, find, etc...
	}
}
