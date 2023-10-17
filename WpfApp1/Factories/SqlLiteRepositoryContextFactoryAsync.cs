﻿using Microsoft.EntityFrameworkCore;

namespace ProgramSystem.Data.Repository.Factories
{
    public class SqlLiteRepositoryContextFactoryAsync : ISqlLiteRepositoryContextFactory
    {
        private string _connectionString;

        public SqlLiteRepositoryContextFactoryAsync(string connectionString)
        {
            _connectionString = connectionString;
        }

        public RepositoryContext Create()
        {
            //string connectionString = "Data Source = rpkDB.db";

            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlite(_connectionString);
            //optionsBuilder.LogTo(Console.WriteLine);
            //optionsBuilder.EnableSensitiveDataLogging();

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
