using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для UserControl_WPF.xaml
    /// </summary>
    public partial class UserControl_WPF : UserControl
    {
        public UserControl_WPF()
        {
            InitializeComponent();
            Init();
        }

        private void On_Load(object sender, RoutedEventArgs e)
        {
            //Init();

        }
        private void Init()
        {
                // Create the interop host control.
                var host =
                    new WindowsFormsHost();

                // Embed the Winforms Control
                host.Child = new LVD_Steelplying_Embed_Unity_Exe_Winforms_Control();

                Grid.SetRow(host, 1);



                // Add the interop host control to the Grid
                // control's collection of child controls.
                Grid_To_Embed_Winforms_Control_In.Children.Add(host);
        }
    }
}
