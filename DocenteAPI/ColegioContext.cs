using DocenteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DocenteAPI
{
    public class ColegioContext : DbContext, IColegioContext
    {
        #region DbSets
        public DbSet<Teacher> Teachers { get; set; }
        #endregion
        #region Constructores
        public ColegioContext(DbContextOptions<ColegioContext> options) : base(options) { }
        #endregion
        #region Metodos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(teacher =>
            {
                teacher.ToTable("Teacher");
                teacher.HasKey(x => x.Id);
                teacher.Property(x => x.DocumentType).IsRequired();
                teacher.Property(x => x.DocumentNumber).IsRequired();
                teacher.Property(x => x.Name).IsRequired().HasMaxLength(50);
                teacher.Property(x => x.Email).IsRequired().HasMaxLength(100);
                teacher.Property(x => x.Specialty).IsRequired().HasMaxLength(100);
            });
        }
        void IColegioContext.SaveChanges()
        {
            base.SaveChanges();
        }
        #endregion
    }
}