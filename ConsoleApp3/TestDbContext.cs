using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleApp3
{
    [Serializable()]
    public class Employee : ISerializable
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int Salary { set; get; }
        public int DepartmentId { set; get; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Id", Id);
            info.AddValue("FirstName", FirstName);
            info.AddValue("LastName", LastName);
            info.AddValue("Salary", Salary);
            info.AddValue("DepartmentId", DepartmentId);
        }

        public Employee() { }
        public Employee(SerializationInfo info, StreamingContext context)
        {
            Id = (int)info.GetValue("Id", typeof(int));
            FirstName = (string)info.GetValue("FirstName", typeof(string)); 
            LastName = (string)info.GetValue("LastName", typeof(string));
            Salary = (int)info.GetValue("Salary", typeof(int));
            DepartmentId = (int)info.GetValue("DepartmentId", typeof(int));

        }

        public override string ToString()
        {
            return Id + " " + FirstName + " " + LastName + " " + Salary + " " + DepartmentId;
        }
    }

    public partial class TestDbContext : DbContext
    {
        public virtual DbSet<Employee> Employees { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user=root;database=ef");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees");

                //entity.HasIndex(e => e.DepartmentId);
                entity.Property(e => e.Id);
                entity.Property(e => e.DepartmentId);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.Salary);
            });
        }
    }
}
