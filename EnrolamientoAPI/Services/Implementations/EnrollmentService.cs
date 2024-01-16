using EnrolamientoAPI.Models;
using EnrolamientoAPI.Services.Interfaces;

namespace EnrolamientoAPI.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        #region Propiedades
        private readonly ILogger<EnrollmentService> _logger;
        private readonly IColegioContext _context;
        #endregion
        #region Constructores
        public EnrollmentService(ILogger<EnrollmentService> logger, IColegioContext context)
        {
            _logger = logger;
            _context = context;
        }
        #endregion
        #region Metodos
        public bool Create(Enrollment enrollment)
        {
            bool result = false;

            try
            {
                enrollment.Id = Guid.NewGuid();

                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creando data de enrolamiento {ex.Message.ToString()}");
            }

            return result;
        }
        public bool Delete(Guid id)
        {
            bool result = false;

            try
            {
                Enrollment enrollment = _context.Enrollments.FirstOrDefault(en => en.Id == id);

                if (enrollment != null)
                {
                    _context.Enrollments.Remove(enrollment);

                    _context.SaveChanges();

                    result = true;
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error eliminando data de enrolamiento {ex.Message.ToString()}");
            }

            return result;
        }
        #endregion
    }
}