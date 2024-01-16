using AsignaturaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AsignaturaAPI
{
    public interface IColegioContext
    {
        #region Propiedades
        DbSet<Subject> Subjects { get; set; }
        DbSet<Classroom> Classrooms { get; set; }
        DbSet<Schedule> Schedules { get; set; }
        DbSet<SubjectProgram> SubjectPrograms { get; set; }
        #endregion
        #region Metodos
        void SaveChanges();
        #endregion
    }
}