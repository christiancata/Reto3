using AsignaturaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AsignaturaAPI
{
    public class ColegioContext : DbContext, IColegioContext
    {
        #region DbSets
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SubjectProgram> SubjectPrograms { get; set; }
        #endregion
        #region Constructores
        public ColegioContext(DbContextOptions<ColegioContext> options) : base(options) { }
        #endregion
        #region Metodos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>(subject =>
            {
                subject.ToTable("Subject");
                subject.HasKey(x => x.Id);
                subject.Property(x => x.Name).IsRequired().HasMaxLength(100);
                subject.Property(x => x.Status).IsRequired().HasMaxLength(20);
            });

            modelBuilder.Entity<Classroom>(classroom =>
            {
                classroom.ToTable("Classroom");
                classroom.HasKey(x => x.Id);
                classroom.Property(x => x.Name).IsRequired().HasMaxLength(100);
                classroom.Property(x => x.Block).IsRequired().HasMaxLength(20);
                classroom.Property(x => x.Floor).IsRequired().HasMaxLength(20);
                classroom.Property(x => x.Status).IsRequired().HasMaxLength(20);
            });

            modelBuilder.Entity<Schedule>(schedule =>
            {
                schedule.ToTable("Schedule");
                schedule.HasKey(x => x.Id);
                schedule.Property(x => x.Name).IsRequired().HasMaxLength(100);
                schedule.Property(x => x.StartTime).IsRequired();
                schedule.Property(x => x.EndTime).IsRequired();
                schedule.Property(x => x.Status).IsRequired().HasMaxLength(20);
            });

            modelBuilder.Entity<SubjectProgram>(subjectProgram =>
            {
                subjectProgram.ToTable("SubjectProgram");
                subjectProgram.HasKey(x => x.Id);
                subjectProgram.Property(x => x.SubjectId).IsRequired();
                subjectProgram.Property(x => x.ClassroomId).IsRequired();
                subjectProgram.Property(x => x.ScheduleId).IsRequired();
                subjectProgram.Property(x => x.StartDate).IsRequired();
                subjectProgram.Property(x => x.EndDate).IsRequired();
                subjectProgram.Property(x => x.Status).IsRequired().HasMaxLength(20);
                subjectProgram.HasOne(x => x.Subject).WithOne(x => x.SubjectProgram).HasForeignKey<SubjectProgram>(x => x.Id);
                subjectProgram.HasOne(x => x.Classroom).WithOne(x => x.SubjectProgram).HasForeignKey<SubjectProgram>(x => x.Id);
                subjectProgram.HasOne(x => x.Schedule).WithOne(x => x.SubjectProgram).HasForeignKey<SubjectProgram>(x => x.Id);
            });
        }
        void IColegioContext.SaveChanges()
        {
            base.SaveChanges();
        }
        #endregion
    }
}