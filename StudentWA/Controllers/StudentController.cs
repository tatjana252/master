using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Data.DTO;
using Data.EF;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service;
using WA2.Models;

namespace WA2.Controllers
{
    public class StudentController : Controller
    {
        private readonly CityService _cityService;
        private readonly StudentService _studentService;

        public StudentController(CityService cityService, StudentService studentService)
        {
            _cityService = cityService;
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            StudentViewModel student = new StudentViewModel();
            List<CityViewModel> cities = new List<CityViewModel>();
            student.Cities = Mapper.Map<List<CityViewModel>>(_cityService.GetAll());

            return View(student);
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                var modelErrors = new List<string>();
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var modelError in modelState.Errors)
                    {
                        modelErrors.Add(modelError.ErrorMessage);
                    }
                }
                return BadRequest(ModelState);
            }
            _studentService.Insert(Mapper.Map<Student>(student));

            return Json("Success");
        }

        [HttpGet]
        [Route("AllStudents")]
        public IActionResult GetAll()
        {
            IEnumerable<StudentViewModel> students = Mapper.Map<IEnumerable<StudentViewModel>>(_studentService.GetAll());
            return View(students);
        }

        [HttpPost]
        public IActionResult Search([FromBody]string searchTerm)
        {
            IEnumerable<StudentViewModel> students = Mapper.Map<IEnumerable<StudentViewModel>>(_studentService.Search(s => s.Name == searchTerm));
            return PartialView("GetAll", students);
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
    }
}