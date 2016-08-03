namespace MVCGrid.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class StudentCodeFirst : DbContext
    {
        // Your context has been configured to use a 'StudentCodeFirst' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'MVCGrid.Models.StudentCodeFirst' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'StudentCodeFirst' 
        // connection string in the application configuration file.
        public StudentCodeFirst()
            : base("name=StudentCodeFirst")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<StudentFirst> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentFirst>().HasKey(s => s.id);
            modelBuilder.Entity<StudentFirst>().Property(s => s.id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class StudentFirst
    {
        public int id { get; set; }
        [Required]
        public string Sname { get; set; }
        [Required]
        public string Course { get; set; }
        public int Duration { get; set; }
    }
}