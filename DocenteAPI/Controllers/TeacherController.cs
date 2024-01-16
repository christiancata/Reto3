using DocenteAPI.Models;
using DocenteAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DocenteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        #region Propiedades
        private readonly ITeacherService _teacher;
        #endregion
        #region Constructores
        public TeacherController(ITeacherService teacher)
        {
            _teacher = teacher;
        }
        #endregion
        #region Metodos
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Teacher teacher)
        {
            return Ok(_teacher.Create(teacher));
        }

        [HttpPost]
        [Route("MassCreation")]
        public IActionResult MassCreation(List<Teacher> teachers)
        {
            return Ok(_teacher.MassCreation(teachers));
        }

        [HttpPut]
        public IActionResult Update(Teacher teacher)
        {
            return Ok(_teacher.Update(teacher));
        }
        #endregion
    }
}