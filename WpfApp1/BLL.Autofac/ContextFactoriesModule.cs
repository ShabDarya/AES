﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ProgramSystem.Data.Repository.Factories;

namespace WpfApp1.BLL.Autofac
{
    public class ContextFactoriesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SqlLiteRepositoryContextFactory("Data Source = Database.db"))
                .As<ISqlLiteRepositoryContextFactory>();
        }
    }
}
