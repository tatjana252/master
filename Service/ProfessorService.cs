using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Data.DTO;
using Data.Repository;
using Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class ProfessorService : ServiceBase<ProfessorDTO>
	{
		public ProfessorService(DBManagerUOW dbManager) : base(dbManager)
		{
		}

		public override void Insert(ProfessorDTO entity)
		{
			Professor prof = Mapper.Map<Professor>(entity);
			DbManager.ProfessorRepository.Insert(prof);
			DbManager.Save();
		}

		public override void Delete(ProfessorDTO entity)
		{
			Professor prof = Mapper.Map<Professor>(entity);
			DbManager.ProfessorRepository.Delete(prof);
			DbManager.Save();
		}

		public override void Update(ProfessorDTO entity)
		{
			Professor prof = Mapper.Map<Professor>(entity);
			DbManager.ProfessorRepository.Update(prof);
			DbManager.Save();
		}

		public override IEnumerable<ProfessorDTO> GetAll()
		{
			List<Professor> professors = DbManager.ProfessorRepository.GetAll().ToList();
			return Mapper.Map<IEnumerable<ProfessorDTO>>(professors);
		}

		public override ProfessorDTO GetById(int id)
		{
			Professor professor = DbManager.ProfessorRepository.GetById(id);
			return Mapper.Map<ProfessorDTO>(professor);
		}
	}
}
