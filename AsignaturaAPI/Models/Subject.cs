namespace AsignaturaAPI.Models
{
    public class Subject
    {
        #region Propiedades
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public virtual SubjectProgram SubjectProgram { get; set; }
        #endregion
    }
}