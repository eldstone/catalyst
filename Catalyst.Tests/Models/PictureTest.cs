using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalyst.Models;


namespace Catalyst.Tests.Models
{
	[TestClass]
	public class PictureTest
	{
		/// members

		protected const long myId = 5;
		protected const string myMimeType = "quark/strange";
		protected const long mySize = 14400;
		protected const long myPersonId = 1;
		protected Picture example;



		/// init

		[TestInitialize]
		public void
		Init()
		{
			this.example = new Picture { id = myId, mimeType = myMimeType, size = mySize, personId = myPersonId }; //todo: more
		}



		/// test methods


		[TestMethod]
		public void 
		ModelPicture()
		{
			var ex = this.example;

			Assert.AreEqual(myId, ex.id);
			Assert.AreEqual(myMimeType, ex.mimeType);
			Assert.AreEqual(mySize, ex.size);
			Assert.AreEqual(myPersonId, ex.personId);
			//etc
		}


		[TestMethod]
		public void
		ModelPicture_ToDictionary()
		{
			var ex = this.example;
			var keyVal = example.ToDictionary();

			Assert.AreEqual(keyVal["id"], ex.id.ToString());
			Assert.AreEqual(keyVal["mimeType"], ex.mimeType);
			Assert.AreEqual(keyVal["size"], ex.size.ToString());
			Assert.AreEqual(keyVal["personId"], ex.personId.ToString());
			//etc
		}


		//[TestMethod]
		//public void
		//ModelPerson_Validate

		//..etc..
	}
}
