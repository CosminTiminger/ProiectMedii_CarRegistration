using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CarLotModel
{
    public partial class CarLotEntitiesModel : DbContext
    {
        public CarLotEntitiesModel()
            : base("name=CarLotEntitiesModel")
        {
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Registration> Registration { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.Class)
                .IsFixedLength();

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Registration)
                .WithOptional(e => e.Car)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.Registration)
                .WithOptional(e => e.Permission)
                .WillCascadeOnDelete();
        }
    }
}
