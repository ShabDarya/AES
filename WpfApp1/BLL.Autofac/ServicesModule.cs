using Autofac;
using ProgramSystem.Bll.Services.Services;
using ProgramSystem.Data.Repository.Factories;
using WpfApp1.Interfaces;
using WpfApp1.Services;
//using ProgramSystem.Bll.Services.Interfaces;
//using ProgramSystem.Bll.Services.Services;
//using ProgramSystem.Data.Repository.Factories;

namespace ProgrammSystem.BLL.Autofac
{
    public class ServicesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ProgramRobotService()).As<IProgramRobot>();
            builder.Register(c => new UserService(c.Resolve<ISqlLiteRepositoryContextFactory>())).As<IUserService>();
            builder.Register(c => new DbService()).As<IDb>();
            //builder.Register(c => new StarterServices()).As<IStarterServices>();
            //builder.Register(c => new ComparatorService()).As<IComparatorService>();

            builder.Register(c => new SqlLiteRepositoryContextFactory("Data Source = Database.db"));

        }
    }
}