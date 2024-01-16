using DocenteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DocenteAPI
{
    public interface IColegioContext
    {
        #region Propiedades
        DbSet<Teacher> Teachers { get; set; }
        #endregion
        #region Metodos
        void SaveChanges();
        #endregion
    }
}