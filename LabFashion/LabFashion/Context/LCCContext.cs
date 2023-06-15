﻿using LabFashion.Models;
using Microsoft.EntityFrameworkCore;

namespace LabFashion.Context
{
    public class LCCContext : DbContext
    {
        public LCCContext() { }

        public LCCContext(DbContextOptions<LCCContext> options) : base(options) { }

        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
                IdUser = 1,
                TypeUser = Enums.TypeUser.Administrador,
                SystemStatus = Enums.SystemStatus.Ativo,
                IdPerson = 1,
                NamePerson = "Renan",
                GenrePerson = "Masculino",
                BirthDatePerson = new DateTime(1989, 03, 01),
                DocumentPerson = "00321456987",
                PhoneNumberPerson = "12345678900"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                IdUser = 2,
                TypeUser = Enums.TypeUser.Administrador,
                SystemStatus = Enums.SystemStatus.Inativo,
                IdPerson = 2,
                NamePerson = "José Ricardo",
                GenrePerson = "Masculino",
                BirthDatePerson = new DateTime(1957, 09, 01),
                DocumentPerson = "7564745756",
                PhoneNumberPerson = "8679678986"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                IdUser = 3,
                TypeUser = Enums.TypeUser.Gerente,
                SystemStatus = Enums.SystemStatus.Ativo,
                IdPerson = 3,
                NamePerson = "Eric",
                GenrePerson = "Masculino",
                BirthDatePerson = new DateTime(1982, 09, 18),
                DocumentPerson = "11111111111",
                PhoneNumberPerson = "2121121212"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                IdUser = 4,
                TypeUser = Enums.TypeUser.Administrador,
                SystemStatus = Enums.SystemStatus.Inativo,
                IdPerson = 4,
                NamePerson = "Priscila",
                GenrePerson = "Feminino",
                BirthDatePerson = new DateTime(1991, 09, 17),
                DocumentPerson = "43124321432",
                PhoneNumberPerson = "52345432543"
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                IdUser = 5,
                TypeUser = Enums.TypeUser.Criador,
                SystemStatus = Enums.SystemStatus.Ativo,
                IdPerson = 5,
                NamePerson = "Sonia",
                GenrePerson = "Feminino",
                BirthDatePerson = new DateTime(1953, 12, 26),
                DocumentPerson = "86973535445",
                PhoneNumberPerson = "0978096463"
            });
        }
    }
}
