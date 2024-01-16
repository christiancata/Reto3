using EstudianteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudianteAPI
{
    public interface IColegioContext
    {
        #region Propiedades
        DbSet<Student> Students { get; set; }
        DbSet<Grade> Grades { get; set; }
        #endregion
        #region Metodos
        void SaveChanges();
        #endregion
    }
}