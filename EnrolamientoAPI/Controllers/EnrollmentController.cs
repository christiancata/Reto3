using EnrolamientoAPI.Models;
using EnrolamientoAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EnrolamientoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        #region Propiedades
        private readonly IEnrollmentService _service;
        #endregion
        #region Constructores
        public EnrollmentController(IEnrollmentService service)
        {
            _service = service;
        }
        #endregion
        #region Metodos
        [HttpPost]
        public IActionResult Create(Enrollment enrollment)
        {
            return Ok(_service.Create(enrollment));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            return Ok(_service.Delete(id));
        }
        #endregion
    }
}