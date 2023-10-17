//using Microsoft.VisualBasic.Logging;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.IO.Pipes;
//using System.Linq;
//using System.Runtime.InteropServices;
//using System.Text;
//using System.Text.Json;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace WpfApp1
//{
//    public partial class Form1 : Form
//    {
//        string u3dfile = Environment.CurrentDirectory + "\\RF202.exe";

//        [DllImport("User32.dll")]
//        static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

//        internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);
//        [DllImport("user32.dll")]
//        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

//        [DllImport("user32.dll")]
//        static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

//        private delegate void UpdateLogCallback(string text);
//        private Process process;
//        private IntPtr unityHWND = IntPtr.Zero;
//        private const int WM_ACTIVATE = 0x0006;
//        private readonly IntPtr WA_ACTIVE = new IntPtr(1);
//        private readonly IntPtr WA_INACTIVE = new IntPtr(0);
//        private BackgroundWorker backgroundWorker;
//        private NamedPipeServerStream namedPipeServerStream;

//        SQLiteConnection conn = new SQLiteConnection("Data Source=data.db;");

//        RobotData robotData = new RobotData();

//        private int lastCMD = 0;
//        private double lastTimer = 0;
//        private int cmdNum = 0;
//        private int doCMDNumber = 0;

//        public Form1()
//        {
//            InitializeComponent();
//            conn.Open();
//            edRobotType.SelectedIndex = 0;
//            edProg.SelectedIndex = 0;

//            try
//            {
//                Create Server Instance
//                namedPipeServerStream = new NamedPipeServerStream("NamedPipeExample", PipeDirection.InOut, 1);

//                Start Background Worker
//                backgroundWorker = new BackgroundWorker();
//                backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
//                backgroundWorker.WorkerReportsProgress = true;

//                backgroundWorker.RunWorkerAsync();

//                Start embedded Unity Application
//                process = new Process();
//                process.StartInfo.FileName = u3dfile;
//                process.StartInfo.Arguments = "-parentHWND " + pnl3D.Handle.ToInt32() + " " + Environment.CommandLine;
//                process.StartInfo.UseShellExecute = true;
//                process.StartInfo.CreateNoWindow = true;

//                process.Start();
//                process.WaitForInputIdle();

//                Embed Unity Application into this Application
//                EnumChildWindows(pnl3D.Handle, WindowEnum, IntPtr.Zero);

//                Wait for a Client to connect
//                namedPipeServerStream.WaitForConnection();
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            SelectRequest();
//        }

//        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
//        {
//            UpdateLogCallback updateLog = new UpdateLogCallback(UpdateLog);
//            string dataFromClient = null;
//            try
//            {
//                Don't pass until a Connection has been established
//                while (namedPipeServerStream.IsConnected == false)
//                {
//                    Thread.Sleep(100);
//                }

//                Created stream for reading and writing
//                StreamString serverStream = new StreamString(namedPipeServerStream);


//            }
//            catch (Exception ex)
//            {
//                Handle usual Communication Exceptions here - just logging here for demonstration and debugging Purposes
//                Invoke(updateLog, new object[] { ex.Message });
//            }


//        }

//        private void sendJson(string json)
//        {
//            string dataFromClient;
//            UpdateLogCallback updateLog = new UpdateLogCallback(UpdateLog);
//            try
//            {
//                Don't pass until a Connection has been established
//                while (namedPipeServerStream.IsConnected == false)
//                {
//                    Thread.Sleep(100);
//                }

//                Created stream for reading and writing
//                StreamString serverStream = new StreamString(namedPipeServerStream);
//                serverStream.WriteString(json);
//                dataFromClient = serverStream.ReadString();
//                Invoke(updateLog, new object[] { "Received Data from Server: " + dataFromClient });
//            }
//            catch (Exception ex)
//            {
//                Invoke(updateLog, new object[] { ex.Message });
//            }

//        }

//        public void UpdateLog(string text)
//        {
//            lock (edLog)
//            {
//                Console.WriteLine(text);
//                edLog.AppendText(Environment.NewLine + text);
//            }
//        }

//        private int WindowEnum(IntPtr hwnd, IntPtr lparam)
//        {
//            unityHWND = hwnd;
//            ActivateUnityWindow();
//            return 0;
//        }

//        private void ActivateUnityWindow()
//        {
//            SendMessage(unityHWND, WM_ACTIVATE, WA_ACTIVE, IntPtr.Zero);
//        }

//        private void DeactivateUnityWindow()
//        {
//            SendMessage(unityHWND, WM_ACTIVATE, WA_INACTIVE, IntPtr.Zero);
//        }



//        private void pnl3D_Paint(object sender, PaintEventArgs e)
//        {

//        }

//        private void pnl3D_Resize(object sender, EventArgs e)
//        {
//            MoveWindow(unityHWND, 0, 0, pnl3D.Width, pnl3D.Height, true);
//            ActivateUnityWindow();
//        }

//        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
//        {
//            try
//            {
//                Close Connection
//                namedPipeServerStream.Close();

//                Kill the Unity Application
//                process.CloseMainWindow();

//                Thread.Sleep(1000);

//                while (process.HasExited == false)
//                {
//                    process.Kill();
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


//        public void sendRobotData()
//        {
//            string json = JsonSerializer.Serialize(robotData);
//            sendJson(json);
//        }

//        private void buttons_Click(object sender, EventArgs e)
//        {
//            sendCMD(int.Parse((sender as Button).Tag.ToString()));
//        }
//    }
