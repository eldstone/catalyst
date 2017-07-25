using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Catalyst.Controllers;
using System.Web.Script.Serialization;
using Catalyst.Models.View;

namespace Catalyst.Tests.Controllers
{
    [TestClass]
    public class ApiControllerTest
    {
        [TestMethod]
        public void ApiController_Index()
        {
            var x = new ApiController();

            var result = x.Index() as JsonResult;
			string json = (result == null) ? "" : new JavaScriptSerializer().Serialize(result.Data);

			Assert.IsTrue(json.Length > 0);
			//todo: test for specific data
        }


        [TestMethod]
        public void ApiController_Search()
        {
			var x = new ApiController();

			var post = new ViewSearch { q = "ho" };
			var result = x.Search(post) as JsonResult;
			string json = (result == null) ? "" : new JavaScriptSerializer().Serialize(result.Data);

			Assert.IsTrue(json.Length > 0);
			//todo: test for specific data
		}
	}
}
