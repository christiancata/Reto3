using EnrolamientoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EnrolamientoAPI
{
    public class ColegioContext : DbContext, IColegioContext
    {
        #region DbSets
        public DbSet<Enrollment> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion
        #region Constructores
        public ColegioContext(DbContextOptions<ColegioContext> options) : base(options) { }
        #endregion
        #region Metodos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>(enrollment => {
                enrollment.ToTable("Enrollment");
                enrollment.HasKey(x => x.Id);
                enrollment.Property(x => x.SubjectProgramId).IsRequired();
                enrollment.Property(x => x.StudentId).IsRequired();
                enrollment.Property(x => x.EnrollmentDate).IsRequired();
                enrollment.Property(x => x.DisenrollmentDate).IsRequired();
                enrollment.Property(x => x.Status).IsRequired().HasMaxLength(20);
            });
        }
        void IColegioContext.SaveChanges()
        {
            base.SaveChanges();
        }
        #endregion
    }
}