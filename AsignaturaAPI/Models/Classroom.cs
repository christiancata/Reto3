namespace AsignaturaAPI.Models
{
    public class Classroom
    {
        #region Propiedades
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Block { get; set; }
        public string Floor { get; set; }
        public string Status { get; set; }
        public virtual SubjectProgram SubjectProgram { get; set; }
        #endregion
    }
}