namespace EnrolamientoAPI.Models
{
    public class Enrollment
    {
        #region Propiedades
        public Guid Id { get; set; }
        public int SubjectProgramId { get; set; }
        public virtual SubjectProgram SubjectProgram { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime DisenrollmentDate { get; set; }
        public string Status { get; set; }
        #endregion
    }
}