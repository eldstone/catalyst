using Catalyst.Db;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Catalyst.Controllers
{
	/// <summary>
	///   API actions.  This could be a facade for deeper API's, or else you could break this
	///   into a folder and create its own model-based RESTful API.
	/// </summary>
	[OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
	public class ApiController 
		: Controller
    {
		/// members

		protected DbContext db = new CatalystContext(); //or DI



		/// actions

		// GET: Api
		//todo: use custom Result so data format can be configured, e.g. JSON/XML
		public JsonResult
		Index()
        {
			//disable circular references
			this.db.Configuration.LazyLoadingEnabled = false;
			this.db.Configuration.ProxyCreationEnabled = false;

			var repo = new ServicePerson(this.db);

			//default is to get everything
			//todo: add paging
			var data = repo.ReadAll();

			//simulate db delay
			System.Threading.Thread.Sleep(5000);

			return this.Json(data, JsonRequestBehavior.AllowGet);
        }


		// GET: Api/Search?key=val
		//todo: use custom Result so data format can be configured, e.g. JSON/XML
		public JsonResult
		Search()
        {
			//disable circular references
			this.db.Configuration.LazyLoadingEnabled = false;
			this.db.Configuration.ProxyCreationEnabled = false;

			var repo = new ServicePerson(this.db);
			var q = Request.QueryString["q"].Trim(); //todo, taint check

			//todo: add paging
			//var min = 0;
			//var max = 20;
			//int.TryParse(Request.QueryString["min"], out min);
			//int.TryParse(Request.QueryString["max"], out max);

			//search
			/*
			var data = repo.FindAll(
				p => p.lastName.ToUpper().Contains(q)
					|| p.firstName.ToUpper().Contains(q))
				.OrderBy(p => p.lastName);
			*/
			var data = repo.FindAllQuery(
				p => p.lastName.ToUpper().Contains(q)
					|| p.firstName.ToUpper().Contains(q))
				.OrderBy(p => p.lastName)
			.Include(p => p.picture) //include pictures
			.ToList();

			//manual circular reference fix; todo: view models could fix this and protect re-serialization of EF models
			foreach (var p in data)
				if (p.picture != null)
					p.picture.person = null;

			//simulate db delay
			System.Threading.Thread.Sleep(4000);

			return this.Json(data, JsonRequestBehavior.AllowGet);
        }

    }
}
