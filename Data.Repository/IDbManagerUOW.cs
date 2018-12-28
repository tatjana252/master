using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    interface IDbManagerUOW : IDisposable
    {

        ICityRepository CityRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        IStudentRepository StudentRepository { get; }
        ISubjectRepository SubjectRepository { get; }

        void Save();
    }
}
