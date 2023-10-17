using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.vm
{
    public class UnityWindowViewModel
    {
        private static UnityWindowViewModel _instance;
        public static UnityWindowViewModel Instance => _instance ?? (_instance = new UnityWindowViewModel());

        public UserControl_WPF myUserControl;

        public UnityWindowViewModel()
        {
            myUserControl = new UserControl_WPF();

        }
    }
}
