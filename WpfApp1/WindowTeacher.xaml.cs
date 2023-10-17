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
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WindowTeacher.xaml
    /// </summary>
    public partial class WindowTeacher : Window
    {
        public WindowTeacher()
        {
            InitializeComponent();


            //teacherWindow.ShowGridLines = true;
            //ColumnDefinition colDef1 = new ColumnDefinition();
            //ColumnDefinition colDef2 = new ColumnDefinition();
            //ColumnDefinition colDef3 = new ColumnDefinition();
            //teacherWindow.ColumnDefinitions.Add(colDef1);
            //teacherWindow.ColumnDefinitions.Add(colDef2);
            //teacherWindow.ColumnDefinitions.Add(colDef3);

            //// Define the Rows
            //RowDefinition rowDef1 = new RowDefinition();
            //RowDefinition rowDef2 = new RowDefinition();
            //RowDefinition rowDef3 = new RowDefinition();
            //RowDefinition rowDef4 = new RowDefinition();
            //RowDefinition rowDef5 = new RowDefinition();
            //RowDefinition rowDef6 = new RowDefinition();
            //RowDefinition rowDef7 = new RowDefinition();
            //RowDefinition rowDef8 = new RowDefinition();
            //RowDefinition rowDef9 = new RowDefinition();
            //RowDefinition rowDef10 = new RowDefinition();
            //RowDefinition rowDef11= new RowDefinition();
            //RowDefinition rowDef12 = new RowDefinition();
            //RowDefinition rowDef13 = new RowDefinition();
            //RowDefinition rowDef14 = new RowDefinition();
            //teacherWindow.RowDefinitions.Add(rowDef1);
            //teacherWindow.RowDefinitions.Add(rowDef2);
            //teacherWindow.RowDefinitions.Add(rowDef3);
            //teacherWindow.RowDefinitions.Add(rowDef4);
            //teacherWindow.RowDefinitions.Add(rowDef5);
            //teacherWindow.RowDefinitions.Add(rowDef6);
            //teacherWindow.RowDefinitions.Add(rowDef7);
            //teacherWindow.RowDefinitions.Add(rowDef8);
            //teacherWindow.RowDefinitions.Add(rowDef9);
            //teacherWindow.RowDefinitions.Add(rowDef10);
            //teacherWindow.RowDefinitions.Add(rowDef11);
            //teacherWindow.RowDefinitions.Add(rowDef12);
            //teacherWindow.RowDefinitions.Add(rowDef13);
            //teacherWindow.RowDefinitions.Add(rowDef14);

            //TextBlock txt0 = new TextBlock();
            //txt0.Text = "Формат";
            //txt0.HorizontalAlignment = HorizontalAlignment.Center;
            //Grid.SetColumn(txt0, 0);
            //Grid.SetRow(txt0, 0);

            //TextBlock txt1 = new TextBlock();
            //txt1.Text = "Команды";
            //txt1.HorizontalAlignment = HorizontalAlignment.Center;
            //Grid.SetColumn(txt1, 1);
            //Grid.SetRow(txt1, 0);

            //TextBlock txt2 = new TextBlock();
            //txt2.Text = "Комментарий";
            //txt2.VerticalAlignment = VerticalAlignment.Center;
            //Grid.SetColumn(txt2, 2);
            //Grid.SetRow(txt2, 0);

            //TextBlock txt3 = new TextBlock();
            //txt3.Text = "Код операции";
            //txt3.HorizontalAlignment = HorizontalAlignment.Center;
            //Grid.SetColumn(txt3, 0);
            //Grid.SetRow(txt3, 1);

            //TextBlock txt4 = new TextBlock();
            //txt4.Text = "Операнд";
            //txt4.HorizontalAlignment = HorizontalAlignment.Center;
            //Grid.SetColumn(txt4, 1);
            //Grid.SetRow(txt4, 1);

            //TextBlock txt5 = new TextBlock();
            //txt5.Text = "05";
            //Grid.SetColumn(txt5, 0);
            //Grid.SetRow(txt5, 2);

            //TextBlock txt6 = new TextBlock();
            //txt6.Text = "00";
            //Grid.SetColumn(txt6, 1);
            //Grid.SetRow(txt6, 2);

            //TextBlock txt7 = new TextBlock();
            //txt7.Text = "Включить электромагнитный клапан с адресом 00.\n Механизм подъема займет нижнее положение";
            //Grid.SetColumn(txt7, 2);
            //Grid.SetRow(txt7, 2);

            //TextBlock txt8 = new TextBlock();
            //txt8.Text = "06";
            //Grid.SetColumn(txt8, 0);
            //Grid.SetRow(txt8, 3);

            //TextBlock txt9 = new TextBlock();
            //txt9.Text = "00";
            //Grid.SetColumn(txt9, 1);
            //Grid.SetRow(txt9, 3);

            //TextBlock txt10 = new TextBlock();
            //txt10.Text = "Выключить электромагнитный клаппан с адресом 00.\n МПД займет верх-нее положение";
            //Grid.SetColumn(txt10, 2);
            //Grid.SetRow(txt10, 3);

            //TextBlock txt11 = new TextBlock();
            //txt11.Text = "05";
            //Grid.SetColumn(txt11, 0);
            //Grid.SetRow(txt11, 4);

            //TextBlock txt12 = new TextBlock();
            //txt12.Text = "01";
            //Grid.SetColumn(txt12, 1);
            //Grid.SetRow(txt12, 4);

            //TextBlock txt13 = new TextBlock();
            //txt13.Text = "Включить электромагнитный клапан с адресом 00. \n Механизм поворота повернется против часовой стрелки";
            //Grid.SetColumn(txt13, 2);
            //Grid.SetRow(txt13, 4);

            //TextBlock txt14 = new TextBlock();
            //txt14.Text = "06";
            //Grid.SetColumn(txt14, 0);
            //Grid.SetRow(txt14, 5);

            //TextBlock txt15 = new TextBlock();
            //txt15.Text = "01";
            //Grid.SetColumn(txt15, 1);
            //Grid.SetRow(txt15, 5);

            //TextBlock txt16 = new TextBlock();
            //txt16.Text = "Выключить электромагнитный клапан с адресом 01. \n МПВ повернется по часовой стрелке";
            //Grid.SetColumn(txt16, 2);
            //Grid.SetRow(txt16, 5);

            //TextBlock txt17 = new TextBlock();
            //txt17.Text = "05";
            //Grid.SetColumn(txt17, 0);
            //Grid.SetRow(txt17, 6);

            //TextBlock txt18 = new TextBlock();
            //txt18.Text = "02";
            //Grid.SetColumn(txt18, 1);
            //Grid.SetRow(txt18, 6);

            //TextBlock txt19 = new TextBlock();
            //txt19.Text = "Включить электромагнитный кла¬пан с адресом 02. \n Механизм горизон¬тальных перемещений выдвинется впере";
            //Grid.SetColumn(txt19, 2);
            //Grid.SetRow(txt19, 6);

            //TextBlock txt20 = new TextBlock();
            //txt20.Text = "06";
            //Grid.SetColumn(txt20, 0);
            //Grid.SetRow(txt20, 7);

            //TextBlock txt21 = new TextBlock();
            //txt21.Text = "02";
            //Grid.SetColumn(txt21, 1);
            //Grid.SetRow(txt21, 7);

            //TextBlock txt22 = new TextBlock();
            //txt22.Text = "Выключить электромагнитный клапан с адресом 02. \n МГП отведен назад";
            //Grid.SetColumn(txt22, 2);
            //Grid.SetRow(txt22, 7);

            //TextBlock txt23 = new TextBlock();
            //txt23.Text = "05";
            //Grid.SetColumn(txt23, 0);
            //Grid.SetRow(txt23, 8);

            //TextBlock txt24 = new TextBlock();
            //txt24.Text = "03";
            //Grid.SetColumn(txt24, 1);
            //Grid.SetRow(txt24, 8);

            //TextBlock txt25 = new TextBlock();
            //txt25.Text = "Включить электромагнитный клапан с адресом 03. \n Фланец механизма сгиба опустится и займет нижнее положение.\n Механизм ротации совершит поворот против часовой стрелки";
            //Grid.SetColumn(txt25, 2);
            //Grid.SetRow(txt25, 8);

            //TextBlock txt26 = new TextBlock();
            //txt26.Text = "06";
            //Grid.SetColumn(txt26, 0);
            //Grid.SetRow(txt26, 9);

            //TextBlock txt27 = new TextBlock();
            //txt27.Text = "03";
            //Grid.SetColumn(txt27, 1);
            //Grid.SetRow(txt27, 9);

            //TextBlock txt28 = new TextBlock();
            //txt28.Text = "Выключить электромагнитный клапан с адресом 03. Фланец МСГ поднят.\n MP повернется по, часовой 1 стрелке";
            //Grid.SetColumn(txt28, 2);
            //Grid.SetRow(txt28, 9);

            //TextBlock txt29 = new TextBlock();
            //txt29.Text = "05";
            //Grid.SetColumn(txt29, 0);
            //Grid.SetRow(txt29, 10);

            //teacherWindow.Children.Add(txt0);
            //teacherWindow.Children.Add(txt1);
            //teacherWindow.Children.Add(txt2);
            //teacherWindow.Children.Add(txt3);
            //teacherWindow.Children.Add(txt4);
            //teacherWindow.Children.Add(txt5);
            //teacherWindow.Children.Add(txt6);
            //teacherWindow.Children.Add(txt7);
            //teacherWindow.Children.Add(txt8);
            //teacherWindow.Children.Add(txt9);
            //teacherWindow.Children.Add(txt10);
            //teacherWindow.Children.Add(txt11);
            //teacherWindow.Children.Add(txt12);
            //teacherWindow.Children.Add(txt13);
            //teacherWindow.Children.Add(txt14);
            //teacherWindow.Children.Add(txt15);
            //teacherWindow.Children.Add(txt16);
            //teacherWindow.Children.Add(txt17);
            //teacherWindow.Children.Add(txt18);
            //teacherWindow.Children.Add(txt19);
            //teacherWindow.Children.Add(txt20);
            //teacherWindow.Children.Add(txt21);
            //teacherWindow.Children.Add(txt22);
            //teacherWindow.Children.Add(txt23);
            //teacherWindow.Children.Add(txt24);
            //teacherWindow.Children.Add(txt25);
            //teacherWindow.Children.Add(txt26);
            //teacherWindow.Children.Add(txt27);
            //teacherWindow.Children.Add(txt28);
            //teacherWindow.Children.Add(txt29);

            //TextBlock txt30 = new TextBlock();
            //txt30.Text = "04";
            //Grid.SetColumn(txt30, 1);
            //Grid.SetRow(txt30, 10);
            //teacherWindow.Children.Add(txt30);
            //TextBlock txt31 = new TextBlock();
            //txt31.Text = "Включить электромагнитный кла¬пан с адресом 04. \n Механический схват разожмется";
            //Grid.SetColumn(txt31, 2);
            //Grid.SetRow(txt31, 10);
            //teacherWindow.Children.Add(txt31);

            //TextBlock txt32 = new TextBlock();
            //txt32.Text = "06";
            //Grid.SetColumn(txt32, 0);
            //Grid.SetRow(txt32, 11);
            //teacherWindow.Children.Add(txt32);
            //TextBlock txt33 = new TextBlock();
            //txt33.Text = "04";
            //Grid.SetColumn(txt33, 1);
            //Grid.SetRow(txt33, 11);
            //teacherWindow.Children.Add(txt33);
            //TextBlock txt34 = new TextBlock();
            //txt34.Text = "Выключить электромагнитный клапан с адресом 04. \n Механический схват сожмется";
            //Grid.SetColumn(txt34, 2);
            //Grid.SetRow(txt34, 11);
            //teacherWindow.Children.Add(txt34);

            //TextBlock txt35 = new TextBlock();
            //txt35.Text = "12";
            //Grid.SetColumn(txt35, 0);
            //Grid.SetRow(txt35, 12);
            //teacherWindow.Children.Add(txt35);
            //TextBlock txt36 = new TextBlock();
            //txt36.Text = "01";
            //Grid.SetColumn(txt36, 1);
            //Grid.SetRow(txt36, 12);
            //teacherWindow.Children.Add(txt36);
            //TextBlock txt37 = new TextBlock();
            //txt37.Text = "Электромагнитный клапан с адресом 01 включить, если бит условия установлен в 1; \n в противном случае — выключить";
            //Grid.SetColumn(txt37, 2);
            //Grid.SetRow(txt37, 12);
            
            //teacherWindow.Children.Add(txt37);


            //TextBlock txt38 = new TextBlock();
            //txt38.Text = "13";
            //Grid.SetColumn(txt38, 0);
            //Grid.SetRow(txt38, 13);
            //teacherWindow.Children.Add(txt38);
            //TextBlock txt39 = new TextBlock();
            //txt39.Text = "03";
            //Grid.SetColumn(txt39, 1);
            //Grid.SetRow(txt39, 13);
            //teacherWindow.Children.Add(txt39);
            //TextBlock txt40 = new TextBlock();
            //txt40.Text = "Электромагнитный клапан с адресом 03 включить, если бит условия установлен в 0; \n в противном случае — выключить";
            //Grid.SetColumn(txt40, 2);
            //Grid.SetRow(txt40, 13);
            //teacherWindow.Children.Add(txt40);

        }
    }
}
