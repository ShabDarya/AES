using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.DTO;
using WpfApp1.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private Dictionary<string, string> _answers = new Dictionary<string, string>();
        private Dictionary<string, int> _count = new Dictionary<string, int>();
        private List<TestUserDTO> test;
        private IDb _db;
        public TestWindow(List<TestUserDTO> t, IDb db)
        {
            test = t;
            _db = db;
            InitializeComponent();
            StackPanel st = new StackPanel();         

            for(int i = 0; i < t.Count; i++)
            {
                Label l = new Label();
                l.Content = t[i].T.Name;
                st.Children.Add(l);

                for (int j = 0; j < t[i].A.Count; j++)
                {
                    CheckBox cb = new CheckBox();
                    cb.Content = t[i].A[j].Name;
                    cb.Name = "t"+t[i].T.Id.ToString()+"_"+j.ToString();
                    cb.Checked += CheckBox_Checked;
                    cb.Unchecked+=CheckBox_Unchecked;
                    st.Children.Add(cb);

                    //RadioButton rb = new RadioButton();
                    //rb.Content = t[i].A[j].Name;
                    //rb.GroupName = t[i].T.Id.ToString();
                    //rb.Checked += RadioButton_Checked;
                    //st.Children.Add(rb);

                }
                Label text = new Label();
                st.Children.Add(text);
            }

            Button btn = new Button();
            btn.Content = "Закончить тест";
            btn.Click += Button_Checked;
            btn.Height = 30;
            st.Children.Add(btn);

            rootWindow.Children.Add(st);
            

        }
        //private void RadioButton_Checked(object sender, RoutedEventArgs e)
        //{
        //    RadioButton pressed = (RadioButton)sender;
        //    bool c = _answers.TryGetValue(pressed.GroupName, out string a);
        //    if (c)
        //    {
        //        _answers[pressed.GroupName] = pressed.Content.ToString();
        //    }
        //    else
        //    {
        //        _answers.Add(pressed.GroupName.ToString(), pressed.Content.ToString());
        //    }
        //}

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox pressed = (CheckBox)sender;
            int ind = pressed.Name.IndexOf("_");
            string name = pressed.Name.Substring(1, ind-1);
            bool c = _answers.TryGetValue(name, out string a);
            string anw = pressed.Content.ToString().Replace(" ", "");
            if (c)
            {
                _answers[name] = a+" "+anw;
                _count[name] += 1;
            }
            else
            {
                _answers.Add(name, anw);
                _count.Add(name, 1);
            }
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox pressed = (CheckBox)sender;
            int ind = pressed.Name.IndexOf("_");
            string name = pressed.Name.Substring(1, ind - 1);
            bool c = _answers.TryGetValue(name, out string a);
            string anw = pressed.Content.ToString().Replace(" ", "");
            if (c)
            {
                _answers[name] = "";
                string[] parts = a.Split(' ');
                foreach (string v in parts)
                {
                    if (v != anw)
                        _answers[name] += v;
                }
                _count[name] -= 1;
            }
            else
            {
                MessageBox.Show("Ошибка!");
            }
        }

        private void Button_Checked(object sender, RoutedEventArgs e)
        {
            double count = 0;
            List<int> id_t = new List<int>();
            for(int i=0; i < test.Count; i++)
            {
                _answers.TryGetValue(test[i].T.Id.ToString(), out string? a);
                string rightA = "";
                List<string> answersRight = new List<string>();
                for(int j = 0; j < test[i].A.Count; j++)
                {
                    if (test[i].A[j].IsRight)
                    {
                        answersRight.Add(test[i].A[j].Name);
                    }
                }
                int coins=0;
                for (int j = 0; j < answersRight.Count; j++)
                {
                    
                    if (a is not null && a.Contains(answersRight[j].Replace(" ", "")))
                    {
                        coins++;
                    }
                }
                _count.TryGetValue(test[i].T.Id.ToString(), out int cont);
                if (cont> answersRight.Count)
                {
                    count += coins *1.0 / cont;
                    if (coins / cont * 100 > 50)
                    {
                        id_t.Add(test[i].T.Id);
                    }
                }
                else
                {
                    count += coins * 1.0 / answersRight.Count;
                    if (coins / answersRight.Count * 100 > 50)
                    {
                        id_t.Add(test[i].T.Id);
                    }
                }
               
                
                //if (a == rightA)
                //{
                //    count++;
                //    id_t.Add(test[i].T.Id);
                //    //_db.AddStat(SettingsMovements.Login, test[i].T.Id);                   
                //}
            }
            double percent = (count / test.Count * 100);
            if (percent >= 60.0)
            {
                for(int i = 0; i < id_t.Count; i++)
                {
                    _db.AddStat(SettingsMovements.Login, id_t[i]);
                }
                MessageBox.Show("Тест пройден. Вы набрали " + Math.Round(percent,2).ToString() + "%");
            }
            else
            {
                MessageBox.Show("Тест не пройден!" + Math.Round(percent,2).ToString() + " % ");
            }
            SettingsMovements.Pertcent = percent;
            Close();
        }
    }
}
