using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DTO;
using WpfApp1.Interfaces;

namespace WpfApp1.vm
{
    public class MOVM : ViewModelBase
    {
        private readonly IDb _db;
        private List<MODTO> moList;


        public List<MODTO> MOList
        {
            get => moList;
            set
            {
                moList = value;
                OnPropertyChanged();

            }
        }

        public MOVM(IDb db)
        {
            _db = db;
            MOList = _db.GetAllMO();
        }

    }
}
