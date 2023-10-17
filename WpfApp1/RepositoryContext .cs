﻿using Microsoft.EntityFrameworkCore;
using ProgramSystem.Data.Models;

namespace ProgramSystem.Data.Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<UserEntity> Users { get; set; } = null!;
        //public DbSet<CanalEntity> Canals { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity { Id = 1, Login="teacher", Password= "teacher", Role="1"});
            modelBuilder.Entity<UserEntity>().HasData(new UserEntity { Id = 2, Login = "stud", Password = "stud", Role = "2" });

            // Единицы измерения
            //var unitOfMeasMeter = new UnitOfMeasEntity() {Id = 1, Name = "м"};
            //var unitOfMeasKgMeter = new UnitOfMeasEntity() { Id = 2, Name = "кг/м^3" };
            //var unitOfMeasDgKgC = new UnitOfMeasEntity() { Id = 3, Name = "Дж/(кг·°С)" };
            //var unitOfMeasC = new UnitOfMeasEntity() { Id = 4, Name = "°С" };
            //var unitOfMeasMC = new UnitOfMeasEntity() { Id = 5, Name = "м/с" };
            //var unitOfMeasPaC = new UnitOfMeasEntity() { Id = 6, Name = "Па·с^n" };
            //var unitOfMeasOneOnC = new UnitOfMeasEntity() { Id = 7, Name = "1/°С" };
            //var unitOfMeasBtMC = new UnitOfMeasEntity() { Id = 8, Name = "Вт/(м2·°С)" };

            //modelBuilder.Entity<UnitOfMeasEntity>().HasData(unitOfMeasMeter, unitOfMeasKgMeter, unitOfMeasDgKgC, unitOfMeasC, 
            //    unitOfMeasMC, unitOfMeasPaC, unitOfMeasOneOnC, unitOfMeasBtMC, new UnitOfMeasEntity(){Id=9, Name = "-"});
            //modelBuilder.Entity<MaterialEntity>().HasData(new List<MaterialEntity>()
            //{
            //    new(){Id = 1, Name = "Полипропилен"}
            //});
            //modelBuilder.Entity<CanalEntity>().HasData(new List<CanalEntity>()
            //{
            //    new(){Id = 1, Name = "Канал1"}
            //});

            //modelBuilder.Entity<ParameterEntity>().HasData(
            //    new(){Id = 1, UnitOfMeasId = 1, Name = "Ширина, W", TypeParameter = "Геометрические параметры канала"},
            //    new(){Id = 2, UnitOfMeasId = 1, Name = "Длина, H", TypeParameter = "Геометрические параметры канала"}, 
            //    new(){Id = 3, UnitOfMeasId = 1, Name = "Глубина, L", TypeParameter = "Геометрические параметры канала"}, 
            //    new(){Id = 4, UnitOfMeasId = 2, Name = "Плотность, ρ", TypeParameter = "Параметры свойств материала"},
            //    new(){Id = 5, UnitOfMeasId = 3, Name = "Удельная теплоемкость, c", TypeParameter = "Параметры свойств материала"}, 
            //    new(){Id = 6, UnitOfMeasId = 4, Name = "Температура плавления, T0", TypeParameter = "Параметры свойств материала"}, 
            //    new(){Id = 7, UnitOfMeasId = 5, Name = "Скорость крышки, Vu", TypeParameter = "Режимные параметры процессаа"}, 
            //    new(){Id = 8, UnitOfMeasId = 4, Name = "Температура крышки, Tu", TypeParameter = "Режимные параметры процесса"}, 
            //    new(){Id = 9, UnitOfMeasId = 6, Name = "Коэффициент консистенции материала при температуре приведения, μ0", TypeParameter = "Эмпирические коэффициенты математической модели"}, 
            //    new(){Id = 10, UnitOfMeasId = 7, Name = "Температурный коэффициент вязкости материала, b", TypeParameter = "Эмпирические коэффициенты математической модели"}, 
            //    new(){Id = 11, UnitOfMeasId = 4, Name = "Температура приведения, Tr", TypeParameter = "Эмпирические коэффициенты математической модели"}, 
            //    new(){Id = 12, UnitOfMeasId = 9, Name = "Индекс течения материала, n", TypeParameter = "Эмпирические коэффициенты математической модели"}, 
            //    new(){Id = 13, UnitOfMeasId = 8, Name = "Коэффициент теплоотдачи от крышки канала к материалу, Tu", TypeParameter = "Эмпирические коэффициенты математической модели"});

            //modelBuilder.Entity<ParameterMaterialEntity>().HasData(
            //    new() { MaterialId = 1, ParameterId = 4, Value = 900f },
            //    new() { MaterialId = 1, ParameterId = 5, Value = 2230f },
            //    new() { MaterialId = 1, ParameterId = 6, Value = 172f }
            //);
            //modelBuilder.Entity<ParameterCanalEntity>().HasData(
            //    new() { CanalId = 1, ParameterId = 1, Value = 0.2f },
            //    new() { CanalId = 1, ParameterId = 2, Value = 0.003f },
            //    new() { CanalId = 1, ParameterId = 3, Value = 7.5f }
            //    );
            //modelBuilder.Entity<EmpiricalParameterMaterialEntity>().HasData(
            //    new() {  MaterialId = 1, ParameterId = 9, Value = 1500f },
            //    new() {  MaterialId = 1, ParameterId = 10, Value = 0.014f },
            //    new() {  MaterialId = 1, ParameterId = 11, Value = 185f },
            //    new() {  MaterialId = 1, ParameterId = 12, Value = 0.38f },
            //    new() {  MaterialId = 1, ParameterId = 13, Value = 1500f }

            //);
            //modelBuilder.Entity<VariableParameterMaterialCanalEntity>().HasData(
            //    new(){CanalId = 1, MaterialId = 1, ParameterId = 7, ValueLower = 1.5f}, 
            //    new(){CanalId = 1, MaterialId = 1, ParameterId = 8, ValueLower = 180f}
            //    );

            //// Ключи
            //modelBuilder.Entity<VariableParameterMaterialCanalEntity>()
            //    .HasKey(t => new { t.MaterialId, t.ParameterId, t.CanalId });

            //modelBuilder.Entity<VariableParameterMaterialCanalEntity>()
            //    .HasOne(pt => pt.Material)
            //    .WithMany(p => p.VariableParameterMaterialCanal)
            //    .HasForeignKey(pt => pt.MaterialId);

            //modelBuilder.Entity<VariableParameterMaterialCanalEntity>()
            //    .HasOne(pt => pt.Parameter)
            //    .WithMany(t => t.VariableParameterMaterialCanal)
            //    .HasForeignKey(pt => pt.ParameterId);

            //modelBuilder.Entity<VariableParameterMaterialCanalEntity>()
            //    .HasOne(pt => pt.Canal)
            //    .WithMany(t => t.VariableParameterMaterialCanal)
            //    .HasForeignKey(pt => pt.CanalId);

            //// Параметры материала
            //modelBuilder.Entity<ParameterMaterialEntity>()
            //    .HasKey(t => new { t.MaterialId, t.ParameterId });

            //modelBuilder.Entity<ParameterMaterialEntity>()
            //    .HasOne(pt => pt.Parameter)
            //    .WithMany(t => t.ParameterMaterial)
            //    .HasForeignKey(pt => pt.ParameterId);

            //modelBuilder.Entity<ParameterMaterialEntity>()
            //    .HasOne(pt => pt.Material)
            //    .WithMany(p => p.ParameterMaterial)
            //    .HasForeignKey(pt => pt.MaterialId);

            //// Эмпирические параметры материала
            //modelBuilder.Entity<EmpiricalParameterMaterialEntity>()
            //    .HasKey(t => new { t.MaterialId, t.ParameterId });

            //modelBuilder.Entity<EmpiricalParameterMaterialEntity>()
            //    .HasOne(pt => pt.Parameter)
            //    .WithMany(t => t.EmpiricalParameterMaterial)
            //    .HasForeignKey(pt => pt.ParameterId);

            //modelBuilder.Entity<EmpiricalParameterMaterialEntity>()
            //    .HasOne(pt => pt.Material)
            //    .WithMany(p => p.EmpiricalParameterMaterial)
            //    .HasForeignKey(pt => pt.MaterialId);

            ////  параметры канала
            //modelBuilder.Entity<ParameterCanalEntity>()
            //    .HasKey(t => new { t.CanalId, t.ParameterId });

            //modelBuilder.Entity<ParameterCanalEntity>()
            //    .HasOne(pt => pt.Parameter)
            //    .WithMany(t => t.ParameterCanal)
            //    .HasForeignKey(pt => pt.ParameterId);

            //modelBuilder.Entity<ParameterCanalEntity>()
            //    .HasOne(pt => pt.Canal)
            //    .WithMany(p => p.ParameterCanal)
            //    .HasForeignKey(pt => pt.CanalId);

            base.OnModelCreating(modelBuilder);
        }
    }
}