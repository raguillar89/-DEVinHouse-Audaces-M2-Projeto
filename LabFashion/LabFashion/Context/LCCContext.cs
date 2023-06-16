using LabFashion.Models;
using Microsoft.EntityFrameworkCore;

namespace LabFashion.Context
{
    public class LCCContext : DbContext
    {
        public LCCContext() { }

        public LCCContext(DbContextOptions<LCCContext> options) : base(options) { }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ClothingCollection> Collections { get; set; }
        public virtual DbSet<ModelClothing> Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(new User
            {
                IdPerson = 1,
                Email = "renan@email.com",
                TypeUser = Enums.TypeUser.Administrador,
                SystemStatus = Enums.SystemStatus.Ativo,
                NamePerson = "Renan",
                GenrePerson = "Masculino",
                BirthDatePerson = new DateTime(1989, 03, 01),
                DocumentPerson = "00321456987",
                PhoneNumberPerson = "12345678900"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                IdPerson = 2,
                Email = "josericardo@email.com",
                TypeUser = Enums.TypeUser.Administrador,
                SystemStatus = Enums.SystemStatus.Inativo,
                NamePerson = "José Ricardo",
                GenrePerson = "Masculino",
                BirthDatePerson = new DateTime(1957, 09, 01),
                DocumentPerson = "7564745756",
                PhoneNumberPerson = "8679678986"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                IdPerson = 3,
                Email = "eric@email.com",
                TypeUser = Enums.TypeUser.Gerente,
                SystemStatus = Enums.SystemStatus.Ativo,
                NamePerson = "Eric",
                GenrePerson = "Masculino",
                BirthDatePerson = new DateTime(1982, 09, 18),
                DocumentPerson = "11111111111",
                PhoneNumberPerson = "2121121212"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                IdPerson = 4,
                Email = "priscila@email.com",
                TypeUser = Enums.TypeUser.Administrador,
                SystemStatus = Enums.SystemStatus.Inativo,
                NamePerson = "Priscila",
                GenrePerson = "Feminino",
                BirthDatePerson = new DateTime(1991, 09, 17),
                DocumentPerson = "43124321432",
                PhoneNumberPerson = "52345432543"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                IdPerson = 5,
                Email = "sonia@email.com",
                TypeUser = Enums.TypeUser.Criador,
                SystemStatus = Enums.SystemStatus.Ativo,
                NamePerson = "Sonia",
                GenrePerson = "Feminino",
                BirthDatePerson = new DateTime(1953, 12, 26),
                DocumentPerson = "86973535445",
                PhoneNumberPerson = "0978096463"
            });
        }
    }
}
