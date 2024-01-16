using DocenteAPI.Models;

namespace DocenteAPI.Services.Interfaces
{
    public interface ITeacherService
    {
        #region Metodos
        bool Create(Teacher teacher);
        Teacher GetByDocumentNumber(int documentNumber);
        List<Teacher> List();
        bool MassCreation(List<Teacher> teachers);
        bool Update(Teacher teacher);
        #endregion
    }
}