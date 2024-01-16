namespace AsignaturaAPI.Models
{
    public class Schedule
    {
        #region Propiedades
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public virtual SubjectProgram SubjectProgram { get; set; }
        #endregion
    }
}