using EstudianteAPI.Models;
using EstudianteAPI.Services.Interfaces;

namespace EstudianteAPI.Services.Implementations
{
    public class StudentService: IStudentService
    {
        #region Propiedades
        private readonly ILogger<StudentService> _logger;
        private readonly IColegioContext _context;
        #endregion
        #region Constructores
        public StudentService(ILogger<StudentService> logger, IColegioContext context)
        {
            _logger = logger;
            _context = context;
        }
        #endregion
        #region Metodos
        public bool Create(Student student)
        {
            bool result = false;

            try
            {
                student.Id = Guid.NewGuid();

                _context.Students.Add(student);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creando data de estudiante {ex.Message.ToString()}");
            }

            return result;
        }
        public Student GetByDocumentNumber(int documentNumber)
        {
            Student result = null;

            try
            {
                result = _context.Students.
                    Where(x => x.DocumentNumber == documentNumber)
                    .FirstOrDefault();

                if (result == null)
                {
                    _logger.LogError($"Error obteniendo data de estudiante {documentNumber}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error obteniendo data de estudiante {ex.Message.ToString()}");
            }

            return result;
        }
        public List<Student> List()
        {
            List<Student> result = null;

            try
            {
                result = _context.Students.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error obteniendo data de estudiantes {ex.Message}");
            }

            return result;
        }
        public bool MassCreation(List<Student> students)
        {
            bool result = false;

            try
            {
                foreach (Student student in students)
                {
                    student.Id = Guid.NewGuid();

                    _context.Students.Add(student);
                }

                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creando data de estudiantes {ex.Message.ToString()}");
            }

            return result;
        }
        public bool Update(Student student)
        {
            bool result = false;

            try
            {
                var entity = _context.Students.
                    Where(x => x.Id == student.Id)
                    .FirstOrDefault();

                if (entity != null)
                {
                    entity.DocumentType = student.DocumentType;
                    entity.DocumentNumber = student.DocumentNumber;
                    entity.Name = student.Name;
                    entity.Email = student.Email;

                    _context.SaveChanges();
                }
                else
                {
                    _logger.LogError($"No sé encontró el estudiante {student.Id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error actualizando data de estudiante {ex.Message.ToString()}");
            }

            return result;
        }
        #endregion
    }
}