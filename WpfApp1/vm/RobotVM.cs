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

namespace WpfApp1.vm
{
    public class RobotVM : ViewModelBase
    {
        private readonly IDb _db;
        private List<RobotDTO> robotList;
        private RobotDTO selectR;
        private string? nameR;

        public List<RobotDTO> RobotList
        {
            get => robotList;
            set
            {
                robotList = value;
                OnPropertyChanged();

            }
        }

        public RobotDTO SelectR
        {
            get => selectR;
            set
            {
                selectR = value;
                
                NameR = value.Name; 
                OnPropertyChanged();

            }
        }

        public string? NameR
        {
            get => nameR;
            set
            {
                nameR = value;
                OnPropertyChanged();

            }
        }

       public RelayCommand RobotCommand { get; set; }

        public RobotVM(IDb db)
        {
            _db = db;
            RobotList = _db.GetAllRobots();
            if(RobotList is not null && RobotList.Count>0)
                SelectR=RobotList[0];
            RobotCommand = new RelayCommand(obj => RobotC(), obj => true);
        }

        public void RobotC()
        {
            SettingsMovements.SelectR = SelectR;
            MessageBox.Show("Был выбран робот " + SettingsMovements.SelectR.Name);
        }
    }
    
}
