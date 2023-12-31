﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Services;
using WpfApp1.vm;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //int selectedItem;
        //IntPtr hwndListBox;
        //ControlHost listControl;
        //Application app;
        //Window myWindow;
        //int itemCount;

        //private void On_UIReady(object sender, EventArgs e)
        //{
        //    app = System.Windows.Application.Current;
        //    myWindow = app.MainWindow;
        //    myWindow.SizeToContent = SizeToContent.WidthAndHeight;
        //    listControl = new ControlHost(ControlHostElement.ActualHeight, ControlHostElement.ActualWidth);
        //    ControlHostElement.Child = listControl;
        //    listControl.MessageHook += new HwndSourceHook(ControlMsgFilter);
        //    hwndListBox = listControl.hwndListBox;
        //    for (int i = 0; i < 15; i++) //populate listbox
        //    {
        //        string itemText = "Item" + i.ToString();
        //        SendMessage(hwndListBox, LB_ADDSTRING, IntPtr.Zero, itemText);
        //    }
        //    itemCount = SendMessage(hwndListBox, LB_GETCOUNT, IntPtr.Zero, IntPtr.Zero);
        //}

        public MainWindow()
        {
            InitializeComponent();
            UnityFrame.Content = UnityWindowViewModel.Instance.myUserControl;
        }
        //private IntPtr ControlMsgFilter(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        //{
        //    int textLength;

        //    handled = false;
        //    if (msg == WM_COMMAND)
        //    {
        //        switch ((uint)wParam.ToInt32() >> 16 & 0xFFFF) //extract the HIWORD
        //        {
        //            case LBN_SELCHANGE: //Get the item text and display it
        //                selectedItem = SendMessage(listControl.hwndListBox, LB_GETCURSEL, IntPtr.Zero, IntPtr.Zero);
        //                textLength = SendMessage(listControl.hwndListBox, LB_GETTEXTLEN, IntPtr.Zero, IntPtr.Zero);
        //                StringBuilder itemText = new StringBuilder();
        //                SendMessage(hwndListBox, LB_GETTEXT, selectedItem, itemText);
        //                //selectedText.Text = itemText.ToString();
        //                handled = true;
        //                break;
        //        }
        //    }
        //    return IntPtr.Zero;
        //}
        //internal const int
        //  LBN_SELCHANGE = 0x00000001,
        //  WM_COMMAND = 0x00000111,
        //  LB_GETCURSEL = 0x00000188,
        //  LB_GETTEXTLEN = 0x0000018A,
        //  LB_ADDSTRING = 0x00000180,
        //  LB_GETTEXT = 0x00000189,
        //  LB_DELETESTRING = 0x00000182,
        //  LB_GETCOUNT = 0x0000018B;

        //[DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
        //internal static extern int SendMessage(IntPtr hwnd,
        //                                       int msg,
        //                                       IntPtr wParam,
        //                                       IntPtr lParam);

        //[DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
        //internal static extern int SendMessage(IntPtr hwnd,
        //                                       int msg,
        //                                       int wParam,
        //                                       [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lParam);

        //[DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
        //internal static extern IntPtr SendMessage(IntPtr hwnd,
        //                                          int msg,
        //                                          IntPtr wParam,
        //                                          String lParam);
    }
}
