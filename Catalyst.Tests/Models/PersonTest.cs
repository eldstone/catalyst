using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalyst.Models;


namespace Catalyst.Tests.Models
{
	[TestClass]
	public class PersonTest
	{
		/// members

		protected const long myId = 4;
		protected const string myfirstName = "William";
		protected const string myLastName = "Locksley";
		protected const string myAddress = "Nottingham";
		protected Person example;



		/// init

		[TestInitialize]
		public void
		Init()
		{
			this.example = new Person { id = myId, firstName = myfirstName, lastName = myLastName, address = myAddress }; //todo: more
		}



		/// test methods


		[TestMethod]
		public void 
		ModelPerson()
		{
			var ex = this.example;

			Assert.AreEqual(myId, ex.id);
			Assert.AreEqual(myfirstName, ex.firstName);
			Assert.AreEqual(myLastName, ex.lastName);
			Assert.AreEqual(myAddress, ex.address);
			//etc
		}


		[TestMethod]
		public void
		ModelPerson_ToDictionary()
		{
			var ex = this.example;
			var keyVal = example.ToDictionary();

			Assert.AreEqual(keyVal["id"], ex.id.ToString());
			Assert.AreEqual(keyVal["firstName"], ex.firstName);
			Assert.AreEqual(keyVal["lastName"], ex.lastName);
			Assert.AreEqual(keyVal["address"], ex.address);
			//etc
		}


		//[TestMethod]
		//public void
		//ModelPerson_Validate

		//..etc..
	}
}
