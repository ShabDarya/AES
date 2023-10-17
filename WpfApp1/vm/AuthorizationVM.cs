using Autofac;
using JetBrains.Annotations;
using ProgrammSystem.BLL.Autofac;
using ProgramSystem.Data.Repository.Factories;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.BLL.Autofac;
using WpfApp1.Commands;
using WpfApp1.DTO;
using WpfApp1.Interfaces;
using WpfApp1.Services;

namespace WpfApp1.vm
{
    public class AuthorizationVM : ViewModelBase
    {
        #region Fields
        private readonly IUserService _userService;
        private readonly IDb _dbService;
        private string? login;
        private SecureString? password;

        #endregion

        #region Properties
        public string? Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }
        public SecureString? Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        public RelayCommand AuthorizationCommand { get; set; }

        #endregion

        //IGenerationServices generationServices
        public AuthorizationVM(IUserService userService, IDb dbService)
        {
            _userService = userService;
            _dbService = dbService;
            _dbService.Connection();
            AuthorizationCommand = new RelayCommand(obj => Authorization(), obj => CanAuthorization());
        }


        #region Methods
        private void Authorization() //запускается при клике на кнопку
        {
            string s = _dbService.SelectUser(Login ?? "", new NetworkCredential("", Password).Password);


            var builderBase = new ContainerBuilder();

            builderBase.RegisterModule(new ContextFactoriesModule());
            builderBase.RegisterModule(new ServicesModule());

            var containerBase = builderBase.Build();

            if (s == "Преподаватель")
            {
                var viewmodelBase = new EditVM(containerBase.Resolve<IDb>());
                var viewBase = new EditWindow { DataContext = viewmodelBase };
                SettingsMovements.Login = Login;
                viewBase.Show();
            }
            else if (s == "Студент")
            {

                var viewmodelBase = new MainWindowViewModel(containerBase.Resolve<IProgramRobot> (), containerBase.Resolve<IDb>());
                var viewBase = new MainWindow { DataContext = viewmodelBase };
                SettingsMovements.Login = Login;
                List<RobotDTO> l = _dbService.GetAllRobots();
                if (l.Count > 0 && l is not null)
                SettingsMovements.SelectR = l[0];
                viewBase.Show();

            }
            else 
            {
                MessageBox.Show("Неверный логин или пароль");
            }

        }
       
        private bool CanAuthorization() => !string.IsNullOrEmpty(Login) && Password != null;

        #endregion
    }
}
