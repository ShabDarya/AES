using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Commands;
using WpfApp1.DTO;
using WpfApp1.Interfaces;

namespace WpfApp1.vm
{
    public class PracticaVM : ViewModelBase
    {
        private readonly IDb _db;
        private List<PracticaDTO> practicaList;
        private PracticaDTO selectP;
        private string? nameP;

        public List<PracticaDTO> PrList
        {
            get => practicaList;
            set
            {
                practicaList = value;
                OnPropertyChanged();

            }
        }

        public PracticaDTO SelectP
        {
            get => selectP;
            set
            {
                selectP = value;

                NameP = value.Name;
                OnPropertyChanged();

            }
        }

        public string? NameP
        {
            get => nameP;
            set
            {
                nameP = value;
                OnPropertyChanged();

            }
        }

        public RelayCommand PrCommand { get; set; }

        public PracticaVM(IDb db)
        {
            _db = db;
            PrList = _db.GetPracticaForUser(SettingsMovements.Login);
            if (PrList is not null && PrList.Count > 0)
                SelectP = PrList[0];
            PrCommand = new RelayCommand(obj => PR(), obj => true);
        }

        public void PR()
        {
            SettingsMovements.Scene = SelectP.IdPr;
            MessageBox.Show("Выбрано задание: " + NameP + ". Можете закрывать окно выбора.");
        }
    }
}
