using ProgramSystem.Bll.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Commands;
using WpfApp1.DTO;
using WpfApp1.Interfaces;
using WpfApp1.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WpfApp1.vm
{
    public class CommandsVM : ViewModelBase
    {
        private readonly IDb _db;
        private List<UprCommandDTO> commandsList;
        private UprCommandDTO selectC;

        public List<UprCommandDTO> CommandsList
        {
            get => commandsList;
            set
            {
                commandsList = value;
                OnPropertyChanged();

            }
        }

        public UprCommandDTO SelectC
        {
            get => selectC;
            set
            {
                selectC = value;
                 
                OnPropertyChanged();

            }
        }

       public RelayCommand OpenCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        public CommandsVM(IDb db)
        {
            _db = db;
            CommandsList = _db.SelectCommandLogin(SettingsMovements.Login, SettingsMovements.SelectR.Id);
            if(CommandsList is not null && CommandsList.Count>0)
                SelectC= CommandsList[0];
            else
            {
                MessageBox.Show("Закройте это окно и попробуйте изменить модель робота. Для этой модели не найдено сохраненных программ.");
            }
            OpenCommand = new RelayCommand(obj => CommandC(), obj => true);
            DeleteCommand = new RelayCommand(obj => CommandDelete(), obj => SelectC is not null);
        }

        public void CommandC()
        {
            SettingsMovements.CommandsList=_db.GetCode(SelectC.IdPr);
            SettingsMovements.openCommand = true;
            MessageBox.Show("Команды открылись, закройте, пожалуйста, окно!");
            
        }
        public void CommandDelete()
        {
            _db.DeleteUprCommand(SelectC.IdPr);
            CommandsList = _db.SelectCommandLogin(SettingsMovements.Login, SettingsMovements.SelectR.Id);

        }
    }
    
}
