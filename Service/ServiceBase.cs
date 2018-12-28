using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Data.Repository;
using Service.AutoMapper;

namespace Service
{
	public abstract class ServiceBase<T>
	{
		protected DBManagerUOW DbManager { get; }

		public ServiceBase(DBManagerUOW dbManager)
		{
			DbManager = dbManager;

			
		}

		public abstract void Insert(T entity);

		public abstract void Delete(T entity);

		public abstract void Update(T entity);

		public abstract IEnumerable<T> GetAll();

		public abstract T GetById(int id);

        public virtual IEnumerable<T> Search(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

	}
}
