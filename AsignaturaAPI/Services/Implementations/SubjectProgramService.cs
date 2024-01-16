using AsignaturaAPI.Models;
using AsignaturaAPI.Services.Interfaces;

namespace AsignaturaAPI.Services.Implementations
{
    public class SubjectProgramService : ISubjectProgramService
    {
        #region Propiedades
        private readonly ILogger<SubjectProgramService> _logger;
        private readonly IColegioContext _context;
        #endregion
        #region Constructores
        public SubjectProgramService(ILogger<SubjectProgramService> logger, IColegioContext context)
        {
            _logger = logger;
            _context = context;
        }
        #endregion
        #region Metodos
        public bool Create(SubjectProgram subjectProgram)
        {
            bool result = false;

            try
            {
                subjectProgram.Id = Guid.NewGuid();

                _context.SubjectPrograms.Add(subjectProgram);
                _context.SaveChanges();

                result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creando data de asignatura {ex.Message.ToString()}");
            }

            return result;
        }
        public bool Delete(Guid id)
        {
            bool result = false;

            try
            {
                var entity = _context.SubjectPrograms.
                    Where(x => x.Id == id)
                    .FirstOrDefault();

                if (entity != null)
                {
                    entity.Status = "INACTIVE";

                    _context.SaveChanges();
                }
                else
                {
                    _logger.LogError($"No sé encontró la asignatura {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error eliminando data de asignatura {ex.Message.ToString()}");
            }

            return result;
        }
        public bool Update(SubjectProgram subjectProgram)
        {
            bool result = false;

            try
            {
                var entity = _context.SubjectPrograms.
                    Where(x => x.Id == subjectProgram.Id)
                    .FirstOrDefault();

                if (entity != null)
                {
                    entity.SubjectId = subjectProgram.SubjectId;
                    entity.ClassroomId = subjectProgram.ClassroomId;
                    entity.ScheduleId = subjectProgram.ScheduleId;
                    entity.StartDate = subjectProgram.StartDate;
                    entity.EndDate = subjectProgram.EndDate;
                    entity.Status = subjectProgram.Status;

                    _context.SaveChanges();
                }
                else
                {
                    _logger.LogError($"No sé encontró la asignatura {subjectProgram.Id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error actualizando data de asignatura {ex.Message.ToString()}");
            }

            return result;
        }
        public bool UpdateTeacher(Guid id, string teacherId)
        {
            bool result = false;

            try
            {
                var entity = _context.SubjectPrograms.
                    Where(x => x.Id == id)
                    .FirstOrDefault();

                if (entity != null)
                {
                    entity.TeacherId = teacherId;

                    _context.SaveChanges();
                }
                else
                {
                    _logger.LogError($"No sé encontró la asignatura {id}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error actualizando data de asignatura {ex.Message.ToString()}");
            }

            return result;
        }
        #endregion
    }
}