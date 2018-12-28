using System;
using System.Collections.Generic;
using System.Text;
using Data.Repository;
using Data.EF;

namespace Service
{
	public class SubjectService : ServiceBase<Subject>
	{
		public SubjectService(DBManagerUOW dbManager) : base(dbManager)
		{
		}

		public override void Insert(Subject entity)
		{
			DbManager.SubjectRepository.Insert(entity);
		}

		public override void Delete(Subject entity)
		{
			DbManager.SubjectRepository.Delete(entity);
		}

		public override void Update(Subject entity)
		{
			DbManager.SubjectRepository.Update(entity);
		}

		public override IEnumerable<Subject> GetAll()
		{
			return DbManager.SubjectRepository.GetAll();
		}

		public override Subject GetById(int id)
		{
			return DbManager.SubjectRepository.GetById(id);
		}
	}
}
