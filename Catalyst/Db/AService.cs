using Catalyst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace Catalyst.Db
{
	public abstract class AService<TModel>
		where TModel: class, IModel
	{
		/// members

		protected DbContext db;



		/// c/d'tors

		/// <summary>
		/// Construct a model's repository service
		/// </summary>
		/// <param name="id">Database context to use</param>
		public
		AService(
			DbContext context)
		{
			this.db = context;
		}



		/// public methods


		/// <summary>
		/// Get a count of models
		/// </summary>
		/// <returns>Number of AModel in store</returns>
		public long
		Count()
		{
			return this.db.Set<TModel>().LongCount();
		}


		/// <summary>
		/// Stores a new model
		/// </summary>
		/// <param name="id">Primary key</param>
		/// <param name="save">If true (default) changes are written to store, if false then queued to store</param>
		/// <returns>Stored AModel</returns>
		public TModel
		Create(
			TModel model,
			bool save = true)
		{
			if (model.created == 0)
				model.created = DateTimeOffset.Now.ToUnixTimeMilliseconds();

			if (model.modified == 0)
				model.modified = DateTimeOffset.Now.ToUnixTimeMilliseconds();

			this.db.Set<TModel>().Add(model);

			if (save)
				this.db.SaveChanges();

			return model;
		}


		/// <summary>
		/// Stores all models in an enumerable list
		/// </summary>
		/// <param name="list">Primary key</param>
		/// <param name="save">If true (default) changes are written to store, if false then queued to store</param>
		/// <returns>An enumerable list</returns>
		public IEnumerable<TModel>
		CreateAll(
			IEnumerable<TModel> list,
			bool save = true)
		{
			foreach (var model in list)
			{
				this.Create(model, false);
			}

			this.db.Set<TModel>().AddRange(list);

			if (save)
				this.db.SaveChanges();

			return list;
		}


		/// <summary>
		/// Delete the given model
		/// </summary>
		/// <param name="model">Model to delete</param>
		/// <param name="save">If true (default) changes are written to store, if false then queued to store</param>
		public void
		Delete(
			TModel model,
			bool save = true)
		{
			this.db.Set<TModel>().Remove(model);

			if (save)
				this.db.SaveChanges();
		}


		/// <summary>
		/// Delete all the model in the enumerable list
		/// </summary>
		/// <param name="list">Model collection to delete</param>
		/// <param name="save">If true (default) changes are written to store, if false then queued to store</param>
		public void
		DeleteAll(
			IEnumerable<TModel> list,
			bool save = true)
		{
			foreach (var model in list)
				this.Delete(model, false);

			if (save)
				this.db.SaveChanges();
		}


		/// <summary>
		/// Return a single model that matches the expression
		/// </summary>
		/// <param name="expression">Linq expression</param>
		/// <returns>Matching model</returns>
		public TModel
		Find(
			Expression<Func<TModel, bool>> expression)
		{
			return this.db.Set<TModel>().SingleOrDefault(expression);
		}


		/// <summary>
		/// Return all models that matches the expression
		/// </summary>
		/// <param name="where">Linq where expression</param>
		/// <returns>Collection of matching models</returns>
		public ICollection<TModel>
		FindAll(
			Expression<Func<TModel, bool>> where)
		{
			return this.db.Set<TModel>().Where(where).ToList();
		}


		/// <summary>
		/// Return all models that matches the expression
		/// </summary>
		/// <param name="where">Linq where expression</param>
		/// <returns>Queryable linq expression</returns>
		public IQueryable<TModel>
		FindAllQuery(
			Expression<Func<TModel, bool>> where)
		{
			return this.db.Set<TModel>().Where(where);
		}


		/// <summary>
		/// Retrieve an model by primary key
		/// </summary>
		/// <param name="id">Primary key</param>
		/// <returns>Matching model or null</returns>
		public TModel
		Read(
			long id)
		{
			return this.db.Set<TModel>().Find(id);
		}


		/// <summary>
		/// Retrieve collection of all models
		/// </summary>
		/// <returns>ICollection of all models</returns>
		public ICollection<TModel>
		ReadAll()
		{
			return this.db.Set<TModel>().ToList();
		}


		/// <summary>
		/// Update an model using its primary key
		/// </summary>
		/// <param name="model">Changes</param>
		/// <param name="save">If true (default) changes are written to store</param>
		/// <returns>Original object with changes</returns>
		public TModel
		Update(
			TModel model,
			bool save = true)
		{
			//assume an "empty" id is not valid
			if (model.id == 0)
				return null;

			var old = this.Read(model.id);
			if (old != null)
			{
				this.db.Entry(old).CurrentValues.SetValues(model);
				if (save)
					this.db.SaveChanges();
			}

			return old;
		}


		/// <summary>
		/// Update a list of models using the primary key of each model
		/// </summary>
		/// <param name="list"></param>
		/// <param name="save">If true (default) changes are written to store, if false then queued to store</param>
		/// <returns>Dictionary of original models keyed by primary key</returns>
		public Dictionary<long, TModel>
		UpdateAll(
			IEnumerable<TModel> list,
			bool save = true)
		{
			var ret = new Dictionary<long, TModel>();

			foreach(var model in list)
				ret[model.id] = this.Update(model, false);

			if (save)
				this.db.SaveChanges();

			return ret;
		}


		//todo, async methods
	}
}