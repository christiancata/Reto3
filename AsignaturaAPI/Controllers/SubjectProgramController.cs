using AsignaturaAPI.Models;
using AsignaturaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsignaturaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectProgramController : ControllerBase
    {
        #region Propiedades
        private readonly ISubjectProgramService _service;
        #endregion
        #region Constructores
        public SubjectProgramController(ISubjectProgramService service)
        {
            _service = service;
        }
        #endregion
        #region Metodos
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(SubjectProgram subjectProgram)
        {
            return Ok(_service.Create(subjectProgram));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_service.Delete(id));
        }

        [HttpPut]
        public IActionResult Update(SubjectProgram subjectProgram)
        {
            return Ok(_service.Update(subjectProgram));
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateTeacher(Guid id, string teacherId)
        {
            return Ok(_service.UpdateTeacher(id, teacherId));
        }
        #endregion
    }
}