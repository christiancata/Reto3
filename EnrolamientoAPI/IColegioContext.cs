using EnrolamientoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EnrolamientoAPI
{
    public interface IColegioContext
    {
        #region Propiedades
        DbSet<Enrollment> Enrollments { get; set; }
        #endregion
        #region Metodos
        void SaveChanges();
        #endregion
    }
}