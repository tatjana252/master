using Data.DTO;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace WebService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfessorController : ControllerBase
	{
		public ProfessorService ProfessorService { get; }

		public ProfessorController(ProfessorService ps)
		{
			ProfessorService = ps;
		}

		// GET api/values
		[HttpGet("xml")]
		[Produces("application/xml")]
		public ActionResult<IEnumerable<ProfessorDTO>> GetXml()
		{
			return ProfessorService.GetAll().ToList();
		}

		[HttpGet("json")]
		[Produces("application/json")]
		public ActionResult<IEnumerable<ProfessorDTO>> GetJson()
		{
			return ProfessorService.GetAll().ToList();
		}

		[HttpGet("{id}")]
		public ActionResult<ProfessorDTO> Get(int id)
		{
			return ProfessorService.GetById(id);
		}

		[HttpPost]
		public void Post([FromBody] ProfessorDTO profDTO)
		{
			if (ModelState.IsValid)
			{
				ProfessorService.Insert(profDTO);
			}
			else
			{
				Response.StatusCode = 400;
			}
		}

		[HttpPut]
		public void Put([FromBody] ProfessorDTO value)
		{
			ProfessorService.Update(value);
		}

		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			ProfessorService.Delete(new ProfessorDTO(){Id = id});
		}
	}
}
