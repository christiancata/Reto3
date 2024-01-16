using EnrolamientoAPI.Models;

namespace EnrolamientoAPI.Services.Interfaces
{
    public interface IEnrollmentService
    {
        #region Metodos
        bool Create(Enrollment enrollment);
        bool Delete(Guid id);
        #endregion
    }
}