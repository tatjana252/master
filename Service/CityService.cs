using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Data.DTO;
using Data.EF;
using Data.Repository;

namespace Service
{
	public class CityService : ServiceBase<CityDTO>
	{
		public CityService(DBManagerUOW dbManager) : base(dbManager)
		{
		}

		public override void Insert(CityDTO entity)
		{
			DbManager.CityRepository.Insert(Mapper.Map<City>(entity));
		}

		public override void Delete(CityDTO entity)
		{
			DbManager.CityRepository.Delete(Mapper.Map<City>(entity));
		}

		public override void Update(CityDTO entity)
		{
			DbManager.CityRepository.Update(Mapper.Map<City>(entity));
		}

		public override IEnumerable<CityDTO> GetAll()
		{
            IEnumerable<City> professors = DbManager.CityRepository.GetAll().ToList();
            return Mapper.Map<IEnumerable<CityDTO>>(professors);
		}

		public override CityDTO GetById(int id)
		{
			return Mapper.Map<CityDTO>(DbManager.CityRepository.GetById(id));
		}
	}
}
