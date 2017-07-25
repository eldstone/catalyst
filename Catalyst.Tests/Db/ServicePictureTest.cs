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
	public class ServicePictureTest
	{
		/// members

		protected DbContext db;
		protected List<Picture> examples;
		protected ServicePicture repo;



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
			this.examples = Initialize.ExamplePictures();
			this.db = new CatalystContext(); // or DI test-specific context
			this.db.Database.Initialize(true); // force db recreation
			this.repo = new ServicePicture(this.db);
		}



		/// test methods

		[TestMethod]
		public void
		ServicePicture_Read()
		{
			foreach (var ex in this.examples)
			{
				var y = this.repo.Read(ex.id);
				Assert.IsNotNull(y);
				Assert.AreEqual(ex.id, y.id);
				Assert.AreEqual(ex.mimeType, y.mimeType);
				Assert.AreEqual(ex.size, y.size);
				Assert.AreEqual(ex.path, y.path);
				Assert.AreEqual(ex.personId, y.personId);
			}
		}


		// ..create, read, find, etc...
	}
}
