using DocenteAPI.Models;
using DocenteAPI.Services.Interfaces;

namespace DocenteAPI.Services.Implementations
{
    public class TeacherService: ITeacherService
    {
        #region Propiedades
        private readonly ILogger<TeacherService> _logger;
        private readonly IColegioContext _dbContext;
        #endregion
        #region Constructores
        public TeacherService(ILogger<TeacherService> logger, IColegioContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        #endregion
        #region Metodos
        public bool Create(Teacher teacher)
        {
            bool result = false;

            try
            {
                teacher.Id = Guid.NewGuid();

                _dbContext.Teachers.Add(teacher);
                _dbContext.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creando data de docente {ex.Message.ToString()}");
            }

            return result;
        }
        public Teacher GetByDocumentNumber(int documentNumber)
        {
            Teacher result = null;

            try
            {
                result = _dbContext.Teachers.
                    Where(x => x.DocumentNumber == documentNumber)
                    .FirstOrDefault();

                if (result == null)
                {
                    _logger.LogError($"Error obteniendo data de docente {documentNumber}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error obteniendo data de docente {ex.Message.ToString()}");
            }

            return result;
        }
        public List<Teacher> List()
        {
            List<Teacher> result = null;

            try
            {
                result = _dbContext.Teachers.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error obteniendo data de docentes {ex.Message}");
            }

            return result;
        }
        public bool MassCreation(List<Teacher> teachers)
        {
            bool result = false;

            try
            {
                foreach (Teacher teacher in teachers)
                {
                    teacher.Id = Guid.NewGuid();

                    _dbContext.Teachers.Add(teacher);
                }

                _dbContext.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creando data de docentes {ex.Message.ToString()}");
            }

            return result;
        }
        public bool Update(Teacher teacher)
        {
            bool result = false;

            try
            {
                var entity = _dbContext.Teachers.
                    Where(x => x.Id == teacher.Id)
                    .FirstOrDefault();

                if (entity != null)
                {
                    entity.DocumentType = teacher.DocumentType;
                    entity.DocumentNumber = teacher.DocumentNumber;
                    entity.Name = teacher.Name;
                    entity.Email = teacher.Email;
                    entity.Specialty = teacher.Specialty;

                    _dbContext.SaveChanges();
                }
                else
                {
                    _logger.LogError($"No sé encontró el docente {teacher.Id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error actualizando data de docente {ex.Message.ToString()}");
            }

            return result;
        }
        #endregion
    }
}