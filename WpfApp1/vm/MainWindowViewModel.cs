using System.Collections.Generic;
using System.Text;
using System.Windows;
//using Autofac;
using WpfApp1.DTO;
using WpfApp1.Interfaces;
using WpfApp1.Commands;
using System.IO;
using System;
using WpfApp1.Models;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Drawing;
using WpfApp1.Services;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic.Logging;
using Autofac;
using ProgrammSystem.BLL.Autofac;
using WpfApp1.BLL.Autofac;
using MessageBox = System.Windows.MessageBox;

namespace WpfApp1.vm
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields
        private readonly IProgramRobot _programRobot;
        private readonly IDb _db;

        private bool l0;
        private bool l1;
        private bool l2;
        private bool l3;
        private bool l4;
        private bool l5;
        private bool l6;
        private bool l7;
        private bool l8;
        private bool l9;
        private bool lA;
        private bool lB;
        private bool lC;
        private bool lD;
        private bool lE;
        private bool lF;
        private bool r0;
        private bool r1;
        private bool r2;
        private bool r3;
        private bool r4;
        private bool r5;
        private bool r6;
        private bool r7;
        private bool r8;
        private bool r9;
        private bool rA;
        private bool rB;
        private bool rC;
        private bool rD;
        private bool rE;
        private bool rF;

        private string? a1;
        private string? a2;
        private string? a3;
        private string? p1;
        private string? p2;
        private string? p3;
        private string? p4;
        private bool isCheckedP;
        private bool aR;
        private bool rR;
        private bool sR;
        private bool vPR;
        private bool pPR;
        private List<string> commands;
        private string? operand;
        private string? sensors;
        private int count;
        private bool isGoProgram;
        private bool isFirstCheck;
        private RobotRunModel _robotRunModel;
        private bool endProgram;
        private bool stopProgram=false;
        private bool isReady = false;
        private ProtocolDTO protocol;
        private bool canCont = false;
        private string? nextC;
        private bool endCommand = false;

        private bool mPD = false;
        private bool mPV = false;
        private bool mGP = false;
        private bool mR = false;
        private bool mZ = false;
        #endregion

        #region Properties

        public string? A1
        {
            get => a1;
            set
            {
                a1 = value;
                OnPropertyChanged();
            }
        }
        public string? A2
        {
            get => a2;
            set
            {
                a2 = value;
                OnPropertyChanged();
            }
        }
        public string? A3
        {
            get => a3;
            set
            {
                a3 = value;
                OnPropertyChanged();
            }
        }
        public string? P1
        {
            get => p1;
            set
            {
                p1 = value;
                OnPropertyChanged();
            }
        }
        public string? P2
        {
            get => p2;
            set
            {
                p2 = value;
                OnPropertyChanged();
            }
        }
        public string? P3
        {
            get => p3;
            set
            {
                p3 = value;
                OnPropertyChanged();
            }
        }
        public string? P4
        {
            get => p4;
            set
            {
                p4 = value;
                OnPropertyChanged();
            }
        }

        public string? NextC
        {
            get => nextC;
            set
            {
                nextC = value;
                OnPropertyChanged();
            }
        }
        public bool IsCheckedP
        {
            get => isCheckedP;
            set
            {
                isCheckedP = value;
                OnPropertyChanged();
            }
        }
        public bool AR
        {
            get => aR;
            set
            {
                aR = value;
                OnPropertyChanged();
            }
        }
        public bool RR
        {
            get => rR;
            set
            {
                rR = value;
                OnPropertyChanged();
            }
        }
        public bool SR
        {
            get => sR;
            set
            {
                sR = value;
                OnPropertyChanged();
            }
        }
        public bool VPR
        {
            get => vPR;
            set
            {
                vPR = value;
                OnPropertyChanged();
            }
        }
        public bool PPR
        {
            get => pPR;
            set
            {
                pPR = value;
                OnPropertyChanged();
            }
        }
        public bool EndProgram
        {
            get => endProgram;
            set
            {
                endProgram = value;
                OnPropertyChanged();
            }
        }
        public string? Operand
        {
            get => operand;
            set
            {
                operand = value;
                OnPropertyChanged();
            }
        }
        public string? Sensors
        {
            get => sensors;
            set
            {
                sensors = value;
                OnPropertyChanged();
            }
        }
        public List<string> Commands
        {
            get => commands;
            set
            {
                commands = value;
                OnPropertyChanged();
                
            }
        }
        public int Count
        {
            get => count;
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }
        public bool IsGoProgram 
        {
            get => isGoProgram;
            set
            {
                isGoProgram = value;
                OnPropertyChanged();
            }
        }
        public bool IsFirstCheck 
        {
            get => isFirstCheck;
            set
            {
                isFirstCheck = value;
                OnPropertyChanged();
            }
        }
        public bool StopProgram
        {
            get => stopProgram;
            set
            {
                stopProgram = value;
                OnPropertyChanged();
            }
        }
        public RobotRunModel _RobotRunModel
        {
            get => _robotRunModel;
            set
            {
                _robotRunModel = value;
                OnPropertyChanged();
            }
        }
        public bool L0
        {
            get => l0;
            set
            {
                l0 = value;
                OnPropertyChanged();
            }
        }
        public bool R0
        {
            get => r0;
            set
            {
                r0 = value;
                OnPropertyChanged();
            }
        }
        public bool L1
        {
            get => l1;
            set
            {
                l1 = value;
                OnPropertyChanged();
            }
        }
        public bool R1
        {
            get => r1;
            set
            {
                r1 = value;
                OnPropertyChanged();
            }
        }
        public bool L2
        {
            get => l2;
            set
            {
                l2 = value;
                OnPropertyChanged();
            }
        }
        public bool R2
        {
            get => r2;
            set
            {
                r2 = value;
                OnPropertyChanged();
            }
        }
        public bool L3
        {
            get => l3;
            set
            {
                l3 = value;
                OnPropertyChanged();
            }
        }
        public bool R3
        {
            get => r3;
            set
            {
                r3 = value;
                OnPropertyChanged();
            }
        }
        public bool L4
        {
            get => l4;
            set
            {
                l4 = value;
                OnPropertyChanged();
            }
        }
        public bool R4
        {
            get => r4;
            set
            {
                r4 = value;
                OnPropertyChanged();
            }
        }
        public bool L5
        {
            get => l5;
            set
            {
                l5 = value;
                OnPropertyChanged();
            }
        }
        public bool R5
        {
            get => r5;
            set
            {
                r5 = value;
                OnPropertyChanged();
            }
        }
        public bool L6
        {
            get => l6;
            set
            {
                l6 = value;
                OnPropertyChanged();
            }
        }
        public bool R6
        {
            get => r6;
            set
            {
                r6 = value;
                OnPropertyChanged();
            }
        }
        public bool L7
        {
            get => l7;
            set
            {
                l7 = value;
                OnPropertyChanged();
            }
        }
        public bool R7
        {
            get => r7;
            set
            {
                r7 = value;
                OnPropertyChanged();
            }
        }
        public bool L8
        {
            get => l8;
            set
            {
                l8 = value;
                OnPropertyChanged();
            }
        }
        public bool R8
        {
            get => r8;
            set
            {
                r8 = value;
                OnPropertyChanged();
            }
        }
        public bool L9
        {
            get => l9;
            set
            {
                l9 = value;
                OnPropertyChanged();
            }
        }
        public bool R9
        {
            get => r9;
            set
            {
                r9 = value;
                OnPropertyChanged();
            }
        }
        public bool LA
        {
            get => lA;
            set
            {
                lA = value;
                OnPropertyChanged();
            }
        }
        public bool RA
        {
            get => rA;
            set
            {
                rA = value;
                OnPropertyChanged();
            }
        }
        public bool LB
        {
            get => lB;
            set
            {
                lB = value;
                OnPropertyChanged();
            }
        }
        public bool RB
        {
            get => rB;
            set
            {
                rB = value;
                OnPropertyChanged();
            }
        }
        public bool LC
        {
            get => lC;
            set
            {
                lC = value;
                OnPropertyChanged();
            }
        }
        public bool RC
        {
            get => rC;
            set
            {
                rC = value;
                OnPropertyChanged();
            }
        }
        public bool LD
        {
            get => lD;
            set
            {
                lD = value;
                OnPropertyChanged();
            }
        }
        public bool RD
        {
            get => rD;
            set
            {
                rD = value;
                OnPropertyChanged();
            }
        }
        public bool LE
        {
            get => lE;
            set
            {
                lE = value;
                OnPropertyChanged();
            }
        }
        public bool RE
        {
            get => rE;
            set
            {
                rE = value;
                OnPropertyChanged();
            }
        }
        public bool LF
        {
            get => lF;
            set
            {
                lF = value;
                OnPropertyChanged();
            }
        }
        public bool RF
        {
            get => rF;
            set
            {
                rF = value;
                OnPropertyChanged();
            }
        }
        public bool IsReady
        {
            get => isReady;
            set
            {
                isReady = value;
                OnPropertyChanged();
            }
        }
        public bool CanCont
        {
            get => canCont;
            set
            {
                canCont = value;
                OnPropertyChanged();
            }
        }

        public bool EndCommand
        {
            get => endCommand;
            set
            {
                endCommand = value;
                OnPropertyChanged();
            }
        }

        public bool MPD
        {
            get => mPD;
            set
            {
                mPD = value;
                OnPropertyChanged();
            }
        }
        public bool MPV
        {
            get => mPV;
            set
            {
                mPV = value;
                OnPropertyChanged();
            }
        }
        public bool MGP
        {
            get => mGP;
            set
            {
                mGP = value;
                OnPropertyChanged();
            }
        }
        public bool MR
        {
            get => mR;
            set
            {
                mR = value;
                OnPropertyChanged();
            }
        }
        public bool MZ
        {
            get => mZ;
            set
            {
                mZ = value;
                OnPropertyChanged();
            }
        }


        public ProtocolDTO Protocol
        {
            get => protocol;
            set
            {
                protocol = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands
        public RelayCommand BPCommand { get; set; }
        public RelayCommand B0Command { get; set; }
        public RelayCommand B1Command { get; set; }
        public RelayCommand B2Command { get; set; }
        public RelayCommand B3Command { get; set; }
        public RelayCommand B4Command { get; set; }
        public RelayCommand B5Command { get; set; }
        public RelayCommand B6Command { get; set; }
        public RelayCommand B7Command { get; set; }
        public RelayCommand B8Command { get; set; }
        public RelayCommand B9Command { get; set; }
        public RelayCommand BACommand { get; set; }
        public RelayCommand BBCommand { get; set; }
        public RelayCommand BCCommand { get; set; }
        public RelayCommand BDCommand { get; set; }
        public RelayCommand BECommand { get; set; }
        public RelayCommand BFCommand { get; set; }
        public RelayCommand StopCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public RelayCommand RobotCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public AsyncCommand OpenCommand { get; set; }
        public RelayCommand TestCommand { get; set; }
        public RelayCommand StudyCommand { get; set; }
        public RelayCommand OpenSceneCommand { get; set; }
        public RelayCommand MaterialCommand { get; set; }

        #endregion

        //IGenerationServices generationServices
        public MainWindowViewModel(IProgramRobot programRobot, IDb db)
        {
            RR = true;
            //MessageBox.Show("МЗ уже размокнут!", "Ошибка!");
            //TextAdress(-1);
            //MethodsList = MethodsModels.methods;
            //_generationServices = generationServices;
            _programRobot= programRobot;
            _db= db;
            _RobotRunModel = new RobotRunModel();
            Protocol = new ProtocolDTO{Login=SettingsMovements.Login};
            //MainWindowExportCommand = new RelayCommand(obj => Export(), obj => !CanExport());
            B0Command = new RelayCommand(obj => B0(), obj => true);
            B1Command = new RelayCommand(obj => B1(), obj => true);
            B2Command = new RelayCommand(obj => B2(), obj => true);
            B3Command = new RelayCommand(obj => B3(), obj => true);
            B4Command = new RelayCommand(obj => B4(), obj => true);
            B5Command = new RelayCommand(obj => B5(), obj => true);
            B6Command = new RelayCommand(obj => B6(), obj => true);
            B7Command = new RelayCommand(obj => B7(), obj => true);
            B8Command = new RelayCommand(obj => B8(), obj => true);
            B9Command = new RelayCommand(obj => B9(), obj => true);
            BACommand = new RelayCommand(obj => BA(), obj => true);
            BBCommand = new RelayCommand(obj => BB(), obj => true);
            BCCommand = new RelayCommand(obj => BC(), obj => true);
            BDCommand = new RelayCommand(obj => BD(), obj => true);
            BECommand = new RelayCommand(obj => BE(), obj => true);
            BFCommand = new RelayCommand(obj => BF(), obj => true);
            BPCommand = new RelayCommand(obj => BP(), obj => true);
            ClearCommand = new RelayCommand(obj => Clear(), obj => true);
            StopCommand = new RelayCommand(obj => Stop(), obj => true);
            RobotCommand = new RelayCommand(obj => RobotC(), obj => true);
            SaveCommand = new RelayCommand(obj => Save(), obj => CanSave());
            OpenCommand = new AsyncCommand(Open, CanOpen);
            TestCommand = new RelayCommand(obj => Test(), obj => true);
            StudyCommand = new RelayCommand(obj => Study(), obj => true);
            OpenSceneCommand = new RelayCommand(obj => OpenScene(), obj => true);
            MaterialCommand = new RelayCommand(obj => OpenMaterial(), obj => true);

            Commands = new List<string> { "0500", "0200", "0101", "0502", "0204", "0105", "0600", "0201", "0101", "0602", "0205", "0104", "0800"};
            EndCommand = true;
            TextAdress(0);
            L1 = true;
            L3 = true;
            L5 = true;
        }


        #region Methods
        private bool CanSave() => Commands is not null && Commands.Count>0; //проверка
        private bool CanOpen() => true; //проверка
        //public bool CanExport() => TestList is null || TestList.Count==0 || (!SP && !SN);
        public void BP()
        {
            if(IsCheckedP) IsCheckedP = false;
            else IsCheckedP = true;
        }
        public void B0()
        {
            Input("0");
        }
        public void B1()
        {
            Input("1");
        }
        public void B2()
        {
            Input("2");
        }
        public void B3()
        {
            Input("3");
        }
        public void B4()
        {
            Input("4");
        }
        public void B5()
        {
            Input("5");
        }
        public void B6()
        {
            Input("6");
        }
        public void B7()
        {
            Input("7");
        }
        public void B8()
        {
            Input("8");
        }
        public void B9()
        {
            Input("9");
        }
        public void BA()
        {
            Input("A");
        }
        public void BB()
        {
            Input("B");
        }
        public void BC()
        {
            Input("C");
        }
        public void BD()
        {
            Input("D");
        }
        public void BE()
        {
            Input("E");
        }
        public void BF()
        {
            Input("F");
        }

        async public void Input(string s)
        {
            if (IsCheckedP)
            {
                if (s == "0" && !EndCommand && Commands.Count > 0)
                {
                    MessageBox.Show("Не записана команды останова!", "Ошибка!");
                    IsCheckedP = false;
                }
                else
                {                    
                     switch (s)
                    {
                        case "0":
                            count = 0;
                            IsCheckedP = false;
                            AR = true;
                            RR = false;
                            SR = false;
                            VPR = false;
                            PPR = false;
                            EndProgram = false;
                            StopProgram = false;
                            //доработать

                            TextAdress(0);
                            if (Commands is not null && Commands.Count > 0)
                                SeeCommand(Commands[0]);
                            else SeeCommand(null);

                            await LoopProgram();



                            break;
                        case "1":
                            count = 0;
                            IsCheckedP = false;
                            AR = false;
                            RR = true;
                            SR = false;
                            VPR = false;
                            PPR = false;
                            StopProgram = true;
                            TextAdress(0);
                            SeeCommand(null);

                            break;
                        case "2":
                            count = 0;
                            IsCheckedP = false;
                            AR = false;
                            RR = false;
                            SR = true;
                            VPR = false;
                            PPR = false;
                            StopProgram = true;
                            TextAdress(0);
                            if (Commands is not null && Commands.Count > 0)
                                SeeCommand(Commands[0]);
                            else SeeCommand(null);
                            break;
                        case "3":
                            if (!RR)
                            {
                                IsCheckedP = false;
                                AR = false;
                                RR = false;
                                SR = false;
                                VPR = true;
                                PPR = false;
                                StopProgram = true;
                                TextAdress(-1);
                                SeeCommand(null);
                            }
                            else
                            {
                                IsCheckedP = false;
                                AR = false;
                                RR = false;
                                SR = false;
                                VPR = true;
                                PPR = false;
                                TextAdress(count);
                                if (Commands is not null && Commands.Count > 0)
                                    SeeCommand(Commands[count]);
                                else SeeCommand(null);
                            }

                            break;
                        case "4":
                            IsCheckedP = false;
                            AR = false;
                            RR = false;
                            SR = false;
                            VPR = false;
                            PPR = true;
                            StopProgram = true;
                            TextAdress(0);
                            SeeCommand(Commands[0]);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                if (VPR)
                {
                    if (P1 is null)
                        P1 = s;
                    else if (P2 is null)
                        P2 = s;
                    else if (P3 is null)
                        P3 = s;
                    else if (P4 is null)
                    {
                        P4 = s;
                        if (Commands.Count < 256)
                        {
                            if (count >= Commands.Count)
                            {
                                if  (_programRobot.Checking(P1 + P2, P3 + P4))
                                {
                                    if (CheckingMechanism(P1 + P2 + P3 + P4))
                                    {
                                        if (!CheckingSencor(P1 + P2 + P3 + P4))
                                        {
                                            ShowMessageNextCommand(NextC);
                                        }
                                        else
                                        {
                                            Commands.Add(P1 + P2 + P3 + P4);
                                            count++;

                                        }
                                    }
                                }
                                else
                                {
                                    System.Windows.MessageBox.Show("Неправильная команда!", "ОШИБКА!");
                                }                                
                                    TextAdress(-1);
                                    P1 = null;
                                    P2 = null;
                                    P3 = null;
                                    P4 = null;
                            }
                            else
                            {
                                Commands[count] = P1 + P2 + P3 + P4;
                                TextAdress(-1);
                                P1 = null;
                                P2 = null;
                                P3 = null;
                                P4 = null;
                            }
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Память микроконтроллера заполнена!", "ОШИБКА!");
                        }
                    }
                    else
                    {
                        P1 = s;
                        P2 = null;
                        P3 = null;
                        P4 = null;
                    }
                } //готово
                else if(PPR)
                {
                    if (Commands is not null)
                    {
                        if (count < Commands.Count - 1)
                        {
                            count++;
                        }
                        else
                        {
                            count = 0;
                        }
                        TextAdress(count);
                        SeeCommand(Commands[count]);
                    }
                    else TextAdress(0);
                }
                else if (SR) 
                {
                    if (Commands is not null)
                    {
                        TextAdress(count);
                        SeeCommand(Commands[count]);
                        //выполнение программы
                        if (count < Commands.Count - 1)
                        {
                            RunCommand(P1 + P2, P3 + P4);
                            count++;
                        }
                        else
                        {
                            count = 0;
                            System.Windows.MessageBox.Show("Программа завершена", "Система!");
                            
                        }
                        TextAdress(count);
                        if (Commands is not null && Commands.Count > 0)
                            SeeCommand(Commands[count]);
                        else SeeCommand(null);
                    }
                    else TextAdress(0);
                } //готово
                else if (RR)
                {
                    if (P1 is null)
                        P1 = s;
                    else if (P2 is null)
                        P2 = s;
                    else if (P3 is null)
                        P3 = s;
                    else if (P4 is null)
                    {
                        P4 = s;                        
                    }
                    if (P4 is not null)
                    {                     
                        RunCommand(P1 + P2, P3 + P4);
                        P1 = null;
                        P2 = null;
                        P3 = null;
                        P4 = null;
                    }
                } //готово
                else if (AR)
                {
                    await LoopProgram();
                }
            }
        }

        async Task LoopProgram()
        {
            StopProgram = false;
            while (!EndProgram && Commands.Count > 0)
            {
                if (StopProgram) break;
                RunCommand(P1 + P2, P3 + P4);
                if ((P1 + P2) == "05" || (P1 + P2) == "06")
                    await TimeWait(4000);
                else
                    await TimeWait(1000);
                count++;
                if (count != Commands.Count)
                {
                    TextAdress(count);
                    SeeCommand(Commands[count]);
                }
                else
                {
                    if (count == Commands.Count && !EndProgram)
                    {
                        TextAdress(count + 1);
                        SeeCommand(null);
                        System.Windows.MessageBox.Show("Нет команды конца выполнения программы, но команды закончились!");
                        EndProgram = true;
                    }
                }

            }
        }
        public void TextAdress(int i)
        {
            string c="";
            if (i == -1)
            {
                c = Convert.ToString(Commands.Count, 16);
            }
            else
            {
                c = Convert.ToString(i, 16);
            }
            c.ToUpper();
            if (c.Length < 4)
            {
                while (c.Length != 3)
                {
                    c = "0" + c; 
                }
            }
            A1 = c[0].ToString();
            A2 = c[1].ToString();
            A3 = c[2].ToString();
        }

        public void Clear()
        {
            if (VPR)
            {
                EndCommand = false;
                NextC = null;
                Commands = new List<string>();
                TextAdress(0);
                SeeCommand(null);
                count = 0;
            }
            else
            {
                EndCommand = false;
                NextC = null;
                AR = false;
                RR = true;
                SR = false;
                VPR = false;
                PPR = false;
                TextAdress(0);
                SeeCommand(null);
            }
        }
        public void SeeCommand(string? s)
        {
            if (s is not null && s!="")
            {
                P1 = s[0].ToString();
                P2 = s[1].ToString();
                P3 = s[2].ToString();
                P4 = s[3].ToString();
            }
            else
            {
                P1 = null;
                P2 = null;
                P3 = null;
                P4 = null;
            }
        }

        public bool RunCommand(string o, string p){
            if (_programRobot.Checking(o, p))
            {

                    if ((o == "05" || (o == "06")))
                    {
                        if ((p == "00" || p == "01" || p == "02" || p == "03" || p == "04" || p == "05")&&!RR && !AR)
                        {
                            if (!IsGoProgram)
                            {
                                IsGoProgram = true;

                                _programRobot.RunProgramMovement(ref _robotRunModel, o, p, out int ending);
                            //, out int ending
                                Detectors(o, p);
                                MainMenuLoad(ending);
                            }
                            else
                            {
                                if (!AR)
                                {
                                    MessageBoxResult result = System.Windows.MessageBox.Show("Не были проверены датчики прошлой команды движения, вы точно уверены, что хотите продолжить движение без них?", "Вопрос", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Yes);
                                if (result == MessageBoxResult.Yes)
                                {
                                    IsGoProgram = true;

                                    _programRobot.RunProgramMovement(ref _robotRunModel, o, p, out int ending);
                                    Detectors(o, p);
                                    MainMenuLoad(ending);
                                }
                                }
                                
                            }
                        }
                        else
                        {
                            _programRobot.RunProgramMovement(ref _robotRunModel, o, p, out int ending);
                            Detectors(o, p);
                        MainMenuLoad(ending);
                    }
                    }

                    else if (o == "02")
                    {
                        if (IsGoProgram)
                        {
                            IsFirstCheck = true;
                        }
                        else
                        {
                        if (!AR)
                        {
                            System.Windows.MessageBox.Show("Проверка датчиков без команд выхода/входа в/из базового положения", "ОШИБКА!");
                            return false;
                        }
                        }
                    }

                    else if (o == "01")
                    {
                    if (IsGoProgram && IsFirstCheck)
                    {
                        IsFirstCheck = false;
                        IsGoProgram = false;
                    }
                    else
                    {
                        if (!AR)
                        {
                            System.Windows.MessageBox.Show("Проверка датчиков без команд выхода/входа в/из базового положения", "ОШИБКА!");
                            return false;
                        }
                    }
                }

                    else if (o == "07")
                    {
                    double r = Convert.ToInt32(p, 16) * 100;
                    r = Math.Round(r, 0);
                    TimeWait(Int32.Parse((r).ToString()));
                }

                    else if (o == "08"||(o == "11"))                        
                    {
                        IsFirstCheck = false;
                        IsGoProgram = false;
                    EndProgram = true;
                    System.Windows.MessageBox.Show("Выполнение команды закончено", "Конец");
                        count = 0;
                        if(Commands is not null)
                        {
                            TextAdress(count);
                            SeeCommand(Commands[count]);
                        }
                        else
                        {
                            P1 = null;
                            P2 = null;
                            P3 = null;
                            P4 = null;
                        }
                    }

                    else if (o == "09")
                    {
                        count = Convert.ToInt32(p, 16);
                        TextAdress(count);
                        if(count<=Commands.Count-1)
                            SeeCommand(Commands[count]);
                        else
                        {
                            P1 = null;
                            P2 = null;
                            P3 = null;
                            P4 = null;
                        }
                    }

                    else if (o == "14")
                    {
                        Commands = _programRobot.RunProgramIsert(p, Commands);
                    }
                    else
                    {
                        _programRobot.RunChecking(o, p, ref count);
                    }
                }
                //_programRobot.RunProgram();
            else
            {
                System.Windows.MessageBox.Show("Неправильная команда!", "ОШИБКА!");
                return false;
            }
            return true;
        }
        async Task TimeWait(int t)
        {
            await Task.Delay(t);
        }
        public void Stop()
        {
            StopProgram = true;
        }

        public void RobotC()
        {
            var builderBase = new ContainerBuilder();

            builderBase.RegisterModule(new ContextFactoriesModule());
            builderBase.RegisterModule(new ServicesModule());

            var containerBase = builderBase.Build();
            var viewmodelBase = new RobotVM(containerBase.Resolve<IDb>());
            var viewBase = new Robot { DataContext = viewmodelBase };
            
            viewBase.Show();
        }

        public void Save()
        {
            _db.AddUprCommand(new UprCommandDTO { IdR = SettingsMovements.SelectR.Id, Login = SettingsMovements.Login });
            int t = _db.SelectLastCommand(new UprCommandDTO { IdR = SettingsMovements.SelectR.Id, Login = SettingsMovements.Login });
            for(int i = 0; i < Commands.Count; i++)
            {
                _db.AddCode(new CodeDTO { IdPr = t, Command = Commands[i] });
            }
            System.Windows.MessageBox.Show("Сохранение прошло успешно!");
            
        }
        public async Task Open()
        {
            var builderBase = new ContainerBuilder();

            builderBase.RegisterModule(new ContextFactoriesModule());
            builderBase.RegisterModule(new ServicesModule());

            var containerBase = builderBase.Build();
            var viewmodelBase = new CommandsVM(containerBase.Resolve<IDb>());
            var viewBase = new OpenCommands { DataContext = viewmodelBase };

            viewBase.Show();
            while (!SettingsMovements.openCommand)
            {
                await TimeWait(1000);
            }
            SettingsMovements.openCommand = false;
            Commands = SettingsMovements.CommandsList;
            


        }

        public void Test()
        {
            List<TestUserDTO> tests = _db.GetTestForUser(SettingsMovements.Login);
            if(tests.Count == 0)
            {
                System.Windows.MessageBox.Show("Все тесты решены!");
                SettingsMovements.Pertcent = 100.0;
                Protocol.ReadyTest = true;
                CanCont = true;
            }
            else
            {
                Random rnd = new Random();
                List<TestUserDTO> testsUser = new List<TestUserDTO>();
                for (int i=0; i < 10; i++)
                {

                    if (tests.Count > 0)
                    {
                        int c = rnd.Next(tests.Count);
                        testsUser.Add(tests[c]);
                        tests.RemoveAt(c);
                    }
                    else
                        break;
                }
                TestWindow testWindow = new TestWindow(testsUser, _db);
                CanCont = false;
                testWindow.Show();
              
                testWindow.Closed += TestWindow_Closed;
                
            }
        }

        private void TestWindow_Closed(object? sender, EventArgs e)
        {
            CanCont = true;
        }

        async Task Detectors(string o, string p)
        {
            int one = 2000;
            int two = 1000;
            if (o == "05")
            {
                switch (p)
                {
                    case "00":
                        R0 = true;
                        await TimeWait(one);
                        L0 = true;
                        await TimeWait(two);
                        L1 = false;
                        break;
                    case "01":
                        R1 = true;
                        await TimeWait(one);
                        L2 = true;
                        await TimeWait(two);
                        L3 = false;
                        break;
                    case "02":
                        R2 = true;
                        await TimeWait(one);
                        L4 = true;
                        await TimeWait(two);
                        L5 = false;
                        break;
                    case "03":
                        R3 = true;
                        break;
                    case "04":
                        R3 = true;
                        break;
                    case "05":
                        R3 = true;
                        break;
                    default:
                        break;
                }
            }
            if (o == "06")
            {
                switch (p)
                {
                    case "00":
                        R0 = false;
                        await TimeWait(one);
                        L1 = true;
                        await TimeWait(two);
                        L0 = false;
                        break;
                    case "01":
                        R1 = false;
                        await TimeWait(one);
                        L3 = true;
                        await TimeWait(two);
                        L2 = false;
                        break;
                    case "02":
                        R2 = false;
                        await TimeWait(one);
                        L5 = true;
                        await TimeWait(two);
                        L4 = false;
                        break;
                    case "03":
                        R3 = false;
                        break;
                    case "04":
                        R4 = false;
                        break;
                    case "05":
                        R5 = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public async Task Study()
        {
            Protocol = new ProtocolDTO { Login = SettingsMovements.Login };
            Test();
            while (true)
            {
                if (CanCont)
                {
                    if (SettingsMovements.Pertcent > 60 || Protocol.ReadyTest)
                        Protocol.ReadyTest = true;
                    else Protocol.ReadyTest = false;
                    if (Protocol.ReadyTest)
                    {
                        var builderBase = new ContainerBuilder();

                        builderBase.RegisterModule(new ContextFactoriesModule());
                        builderBase.RegisterModule(new ServicesModule());

                        var containerBase = builderBase.Build();
                        var viewmodelBase = new PracticaVM(containerBase.Resolve<IDb>());
                        var viewBase = new Practica { DataContext = viewmodelBase };

                        viewBase.Show();
                        IsReady = true;
                        break;
                    }
                    else
                    {
                        Protocol.ReadyPr = false;
                        string resP = "Ваши результаты:" + Environment.NewLine + "Тестирование: " + SettingsMovements.Pertcent.ToString() + "%, ";
                        if (Protocol.ReadyTest) resP += "зачёт." + Environment.NewLine;
                        else resP += "не зачёт." + Environment.NewLine;
                        resP += "Практическое задание: ";
                        if (Protocol.ReadyPr) resP += "зачёт.";
                        else resP += "не зачёт.";
                        MessageBox.Show(resP, "Результаты");
                        _db.AddProtocol(Protocol);
                        break;
                    }
                }
                else
                {
                    await TimeWait(1000);
                }
            }
            
        }
        public void OpenScene()
        {
            _robotRunModel = new RobotRunModel();
            _robotRunModel.Scene = SettingsMovements.Scene;
            _programRobot.RunProgramMovement(ref _robotRunModel, "06", "00", out int ending);
            IsReady = false;
            Protocol.IdPractica = SettingsMovements.Scene;
        }

        public void MainMenuLoad(int e)
        {
            if (e > 0)
            {
                MessageBox.Show("Вы успешно выполнили!");
                Protocol.ReadyPr=true;
            }
            else if (e < 0)
            {
                MessageBox.Show("Попробуйте в следующий раз!");
                Protocol.ReadyPr = false;
            }
            if (e != 0)
            {
                string resP = "Ваши результаты:" + Environment.NewLine + "Тестирование: " + SettingsMovements.Pertcent.ToString() + "%, ";
                if (Protocol.ReadyTest) resP += "зачёт." + Environment.NewLine;
                else resP += "не зачёт." + Environment.NewLine  ;
                resP += "Практическое задание: ";
                if (Protocol.ReadyPr) resP += "зачёт.";
                else resP += "не зачёт.";
                MessageBox.Show(resP, "Результаты");
                _robotRunModel = new RobotRunModel();
                _robotRunModel.Scene = 0;
                _programRobot.RunProgramMovement(ref _robotRunModel, "06", "00", out int ending);
                _db.AddProtocol(Protocol);
            }
        }

        public void OpenMaterial()
        {
            var builderBase = new ContainerBuilder();

            builderBase.RegisterModule(new ContextFactoriesModule());
            builderBase.RegisterModule(new ServicesModule());

            var containerBase = builderBase.Build();
            var viewmodelBase = new MOVM(containerBase.Resolve<IDb>());
            var viewBase = new WindowTeacher { DataContext = viewmodelBase };

            viewBase.Show();
        }

        public bool CheckingSencor(string c)
        {
            
            if (c == "0800") 
                EndCommand = true;
            if (NextC is not null)
            {
                if (NextC == "07")
                {
                    string s1 = c[0].ToString() + c[1].ToString();
                    string s2 = c[2].ToString() + c[3].ToString();
                    if (s1 != "07" || Convert.ToInt32(s2, 16) < 5)
                    {
                        return false;
                    }
                }
                else
                {
                    if (NextC != c)
                        return false;
                }
            }
            NextCommandCreate(c);
            return true;
        }

        public void NextCommandCreate(string c)
        {
            switch (c)
            {
                case "0500":
                    NextC = "0200";
                    break;
                case "0501":
                    NextC = "0202";
                    break;
                case "0502":
                    NextC = "0204";
                    break;
                case "0503":
                    NextC = "07";
                    break;
                case "0504":
                    NextC = "07";
                    break;
                case "0600":
                    NextC = "0201";
                    break;
                case "0601":
                    NextC = "0203";
                    break;
                case "0602":
                    NextC = "0205";
                    break;
                case "0603":
                    NextC = "07";
                    break;
                case "0604":
                    NextC = "07";
                    break;
                case "0200":
                    NextC = "0101";
                    break;
                case "0201":
                    NextC = "0100";
                    break;
                case "0202":
                    NextC = "0103";
                    break;
                case "0203":
                    NextC = "0102";
                    break;
                case "0204":
                    NextC = "0105";
                    break;
                case "0205":
                    NextC = "0104";
                    break;
                default:
                    NextC = null;
                    break;
            }
        }

        public void ShowMessageNextCommand(string c)
        {
            string err = "";
            switch (c)
            {
                case "0100":
                    err = "Ожидается команда опроса датчиков ВП МПД!";
                    break;
                case "0101":
                    err = "Ожидается команда опроса датчиков НП МПД!";
                    break;
                case "0102":
                    err = "Ожидается команда опроса датчиков МПВ с адресом 02!";
                    break;
                case "0103":
                    err = "Ожидается команда опроса датчиков МПВ с адресом 03!";
                    break;
                case "0104":
                    err = "Ожидается команда опроса датчиков МГП с адресом 04!";
                    break;
                case "0105":
                    err = "Ожидается команда опроса датчиков МГП с адресом 05!";
                    break;
                case "07":
                    err = "Ожидается команда выдержки времени (больше 0.5 секунд)!";
                    break;
                case "0200":
                    err = "Ожидается команда опроса датчиков ВП МПД!";
                    break;
                case "0201":
                    err = "Ожидается команда опроса датчиков НП МПД!";
                    break;
                case "0202":
                    err = "Ожидается команда опроса датчиков МПВ с адресом 02!";
                    break;
                case "0203":
                    err = "Ожидается команда опроса датчиков МПВ с адресом 03!";
                    break;
                case "0204":
                    err = "Ожидается команда опроса датчиков МГП с адресом 04!";
                    break;
                case "0205":
                    err = "Ожидается команда опроса датчиков МГП с адресом 05!";
                    break;
                default:
                    err = "";
                    break;
            }
            MessageBox.Show(err, "Ошибка!");
        }

        public bool CheckingMechanism(string s)
        {
            switch (s){
                case "0500":
                    if (!MPD)
                    {
                        MPD = true;
                    }
                    else
                    {
                        MessageBox.Show("МПД уже находится в НП!", "ОШИБКА!");
                        return false;
                    }
                    break;
                case "0600":
                    if (MPD)
                    {
                        MPD = false;
                    }
                    else
                    {
                        MessageBox.Show("МПД уже находится в БП!", "ОШИБКА!");
                        return false;
                    }
                    break;
                case "0501":
                    if (!MPV)
                    {
                        MPV = true;
                    }
                    else
                    {
                        MessageBox.Show("МПВ уже находится в НП!", "ОШИБКА!");
                        return false;
                    }
                    break;
                case "0601":
                    if (MPV)
                    {
                        MPV = false;
                    }
                    else
                    {
                        MessageBox.Show("МПВ уже находится в БП!", "ОШИБКА!");
                        return false;
                    }
                    break;
                case "0502":
                    if (!MGP)
                    {
                        MGP = true;
                    }
                    else
                    {
                        MessageBox.Show("МГП уже находится в НП!", "ОШИБКА!");
                        return false;
                    }
                    break;
                case "0602":
                    if (MGP)
                    {
                        MGP = false;
                    }
                    else
                    {
                        MessageBox.Show("МГП уже находится в БП!", "ОШИБКА!");
                        return false;
                    }
                    break;
                case "0503":
                    if (!MR)
                    {
                        MR = true;
                    }
                    else
                    {
                        MessageBox.Show("МP/МСГ уже находится в НП!", "ОШИБКА!");
                        return false;
                    }
                    break;
                case "0603":
                    if (MR)
                    {
                        MR = false;
                    }
                    else
                    {
                        MessageBox.Show("МP/МСГ уже находится в БП!", "ОШИБКА!");
                        return false;
                    }
                    break;
                case "0504":
                    if (!MZ)
                    {
                        MZ = true;
                    }
                    else
                    {
                        MessageBox.Show("МЗ уже разомкнут!", "ОШИБКА!");
                        return false;
                    }
                    break;
                case "0604":
                    if (MZ)
                    {
                        MZ = false;
                    }
                    else
                    {
                        MessageBox.Show("МЗ уже замкнут!", "ОШИБКА!");
                        return false;
                    }
                    break;
                default:
                    break;
            }
            return true;
        }
        #endregion
    }
}


