namespace AsignaturaAPI.Models
{
    public class SubjectProgram
    {
        #region Propiedades
        public Guid Id { get; set; }
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public string ClassroomId { get; set; }
        public virtual Classroom Classroom { get; set; }
        public string ScheduleId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public string TeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        #endregion
    }
}