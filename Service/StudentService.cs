using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Repository;
using Data.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Service
{
    public class StudentService : ServiceBase<Student>
    {
        public StudentService(DBManagerUOW dbManager) : base(dbManager)
        {
        }

        public override void Insert(Student entity)
        {
            if (!string.IsNullOrWhiteSpace(entity.Name) && !string.IsNullOrWhiteSpace(entity.LastName))
            {
                DbManager.StudentRepository.Insert(entity);
                DbManager.Save();
            }
            else throw new ValidationException("Student cannot be saved!");
        }

        public override void Delete(Student entity)
        {
            DbManager.StudentRepository.Delete(entity);
        }

        public override void Update(Student entity)
        {
            DbManager.StudentRepository.Update(entity);
        }

        public override IEnumerable<Student> GetAll()
        {
            return DbManager.StudentRepository.GetAll();
        }

        public override Student GetById(int id)
        {
            return DbManager.StudentRepository.GetById(id);
        }

        public override IEnumerable<Student> Search(Expression<Func<Student, bool>> predicate)
        {
            return DbManager.StudentRepository.SearchFor(predicate).Include(s => s.City);
        }
    }
}
