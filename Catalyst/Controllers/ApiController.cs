using Catalyst.Db;
using Catalyst.Models.View;
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


		// Post: Api/Search [ViewSearch]
		//todo: use custom Result so data format can be configured, e.g. JSON/XML
		[HttpPost]
		public JsonResult
		Search(
			ViewSearch search)
        {
			//disable circular references
			this.db.Configuration.LazyLoadingEnabled = false;
			this.db.Configuration.ProxyCreationEnabled = false;

			var repo = new ServicePerson(this.db);

			//todo: nonce xss check
			//todo: sanitize search.q
			if (search.q == null)
				search.q = "";

			//todo: add paging
			//search
			var data = repo.FindAllQueryByName(search.q)
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
