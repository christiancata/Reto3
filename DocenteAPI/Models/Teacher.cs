using DocenteAPI.Enums;

namespace DocenteAPI.Models
{
    public class Teacher
    {
        #region Propiedades
        public Guid Id { get; set; }
        public DocumentTypeEnum DocumentType { get; set; }
        public int DocumentNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }
        #endregion
    }
}