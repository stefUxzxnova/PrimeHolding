using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PrimeHolding.Entities;
using System.Linq.Expressions;

namespace PrimeHolding.Repository
{
	//we use repository, because we don't want to initialize many times dbcontext in the controllers
	public class BaseRepo <T>
		where T : BaseEntity
	//T can be class that inherits BaseEntity 
	{
		private DbContext Context { get; set; }
		private DbSet<T> Items { get; set; }
		public BaseRepo()
		{
			Context = new PrimeHoldingProjectDbContext();
			Items = Context.Set<T>();
		}

		public T FirstOrDefault(Expression<Func<T, bool>> filter)
		{
			return Items.Where(filter)
				.FirstOrDefault();

		}

		public List<T> GetAll(Expression<Func<T, bool>> filter = null) 
		{
			//we have iqueryable because we want the filtering to be made by the data base 
			IQueryable<T> query = Items;

			if (filter != null)
			{
				query = Items.Where(filter);
			}

			//if (order == null)
			//{
			//	query = Items.OrderBy(i => i.Id);
			//}
			//else
			//{
			//	query = Items.OrderBy(order);
			//}


			return query.ToList();
		}

		public void Save(T item)
		{
			if (item.Id > 0)
			{
				Items.Update(item);
			}
			else
			{
				Items.Add(item);
			}

			Context.SaveChanges();
		}


		public int Count(Expression<Func<T, bool>> filter = null)
		{
			IQueryable<T> query = Items;

			if (filter != null)
			{
				query = query.Where(filter);
			}
			return query.Count();
		}

		public void Delete(T item)
		{
			Items.Remove(item);
			Context.SaveChanges();
		}
	}
}
