using AsignaturaAPI.Models;

namespace AsignaturaAPI.Services.Interfaces
{
    public interface ISubjectProgramService
    {
        #region Metodos
        bool Create(SubjectProgram subjectProgram);
        bool Delete(Guid id);
        bool Update(SubjectProgram subjectProgram);
        bool UpdateTeacher(Guid id, string teacherId);
        #endregion
    }
}