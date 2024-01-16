﻿using EstudianteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EstudianteAPI
{
    public class ColegioContext : DbContext, IColegioContext
    {
        #region DbSets
        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        #endregion
        #region Constructores
        public ColegioContext(DbContextOptions<ColegioContext> options) : base(options) { }
        #endregion
        #region Metodos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Grade> GradesInit = new()
            {
                new Grade(){ Id = Guid.NewGuid(), Name = "Primero", Number = 1},
                new Grade(){ Id = Guid.NewGuid(), Name = "Segundo", Number = 2},
                new Grade(){ Id = Guid.NewGuid(), Name = "Tercero", Number = 3},
                new Grade(){ Id = Guid.NewGuid(), Name = "Cuarto", Number = 4},
                new Grade(){ Id = Guid.NewGuid(), Name = "Quinto", Number = 5},
                new Grade(){ Id = Guid.NewGuid(), Name = "Sexto", Number = 6},
                new Grade(){ Id = Guid.NewGuid(), Name = "Septimo", Number = 7},
                new Grade(){ Id = Guid.NewGuid(), Name = "Octavo", Number = 8},
                new Grade(){ Id = Guid.NewGuid(), Name = "Noveno", Number = 9},
                new Grade(){ Id = Guid.NewGuid(), Name = "Decimo", Number = 10},
                new Grade(){ Id = Guid.NewGuid(), Name = "Once", Number = 11},
                new Grade(){ Id = Guid.NewGuid(), Name = "Doce", Number = 12},
            };

            modelBuilder.Entity<Grade>(grade =>
            {
                grade.ToTable("Grade");
                grade.HasKey(x => x.Id);
                grade.Property(x => x.Name).IsRequired().HasMaxLength(50);
                grade.Property(x => x.Number).IsRequired().HasMaxLength(20);
                grade.HasData(GradesInit);
            });

            modelBuilder.Entity<Student>(student =>
            {
                student.ToTable("Student");
                student.HasKey(x => x.Id);
                student.Property(x => x.DocumentType).IsRequired();
                student.Property(x => x.DocumentNumber).IsRequired();
                student.Property(x => x.Name).IsRequired().HasMaxLength(50);
                student.Property(x => x.Email).IsRequired().HasMaxLength(100);
                student.HasOne(x => x.Grade).WithOne(x => x.Student).HasForeignKey<Student>(x => x.Id);
            });
        }
        void IColegioContext.SaveChanges()
        {
            base.SaveChanges();
        }
        #endregion
    }
}