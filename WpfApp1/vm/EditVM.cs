using ProgramSystem.Bll.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Commands;
using WpfApp1.DTO;
using WpfApp1.Interfaces;
using WpfApp1.Services;

namespace WpfApp1.vm
{
    public class EditVM : ViewModelBase
    {
        #region Fields
        private readonly IDb _db;

        private string? loginU;
        private string? passwordU;
        private List<TypeUsersDTO> typeUserList;
        private TypeUsersDTO currentType;
        private List<UserDTO> userList;
        private UserDTO selectUser;

        private List<string> typeMechanismList;
        private string? currentTypeM;
        private List<RobotDTO> robotList;
        private RobotDTO selectR;
        private string? nameR;
        private double gR;
        private int nR;
        private double pR;
        private double deltaR;
        private int w_sR;
        private int w_mR;
        private int r_cR;
        private int r_sR;
        private int r_pR;
        private int l_vR;
        private int l_vH;

        private List<StatisticsDTO> statisitcsList;
        private StatisticsDTO selectStat;
        private bool isRightS;

        private List<TestDTO> questionsList;
        private TestDTO selectQ;
        private List<AnswersDTO> answersList;
        private AnswersDTO selectA;
        private string? nameQ;
        private string? nameA;
        private bool isRightA;

        private string? namePractica;
        private string? colbaX;
        private string? convX;
        private List<PracticaDTO> practicaList;
        private PracticaDTO selectPractica;

        private List<ProtocolDTO> protocolList;

        private string? nameMO;
        private List<MODTO> mOList;
        private MODTO selectMO;

        #endregion
        #region PropertiesU
        public string? LoginU
        {
            get => loginU;
            set
            {
                loginU = value;
                OnPropertyChanged();
            }
        }
        public string? PasswordU
        {
            get => passwordU;
            set
            {
                passwordU = value;
                OnPropertyChanged();
            }
        }
        public List<TypeUsersDTO> TypeUserList
        {
            get => typeUserList;
            set
            {
                typeUserList = value;
                OnPropertyChanged();
            }
        }
        public List<UserDTO> UserList
        {
            get => userList;
            set
            {
                userList = value;
                OnPropertyChanged();
            }
        }
        public TypeUsersDTO CurrentType
        {
            get => currentType;
            set
            {
                currentType = value;
                OnPropertyChanged();
            }
        }
        public UserDTO SelectUser
        {
            get => selectUser;
            set
            {
                selectUser = value;
                if (value is not null)
                {
                    LoginU = value.Login;
                    PasswordU = value.Password;
                    for (int i = 0; i < TypeUserList.Count; i++)
                    {
                        if (TypeUserList[i].Type == value.Role)
                        {
                            CurrentType = TypeUserList[i];
                            break;
                        }
                    }
                }

                
                OnPropertyChanged();
            }
        }
        #endregion

        #region PropertiesR
        public List<RobotDTO> RobotList
        {
            get => robotList;
            set
            {
                robotList = value;
                OnPropertyChanged();
            }
        }
        public List<string> TypeMechanismList
        {
            get => typeMechanismList;
            set
            {
                typeMechanismList = value;
                OnPropertyChanged();
            }
        }
        public RobotDTO SelectR
        {
            get => selectR;
            set
            {
                selectR = value;
                if (value is not null)
                {
                    NameR= value.Name;
                    GR = value.G;
                    PR = value.P;
                    DeltaR = value.Delta;
                    NR = value.N;
                    W_sR = value.W_s;
                    W_mR = value.W_m;
                    R_cR = value.R_c;
                    R_pR = value.R_p;
                    R_sR = value.R_s;
                    L_vR = value.L_v;
                    L_hR = value.L_h;
                    for (int i = 0; i < TypeMechanismList.Count; i++)
                    {
                        if (TypeMechanismList[i] == value.Mechanism)
                        {
                            CurrentTypeM = TypeMechanismList[i];
                            break;
                        }
                    }
                }
                OnPropertyChanged();
            }
        }
        public string? CurrentTypeM
        {
            get => currentTypeM;
            set
            {
                currentTypeM = value;
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
        public double GR
        {
            get => gR;
            set
            {
                gR = value;
                OnPropertyChanged();
            }
        }
        public double PR
        {
            get => pR;
            set
            {
                pR = value;
                OnPropertyChanged();
            }
        }
        public double DeltaR
        {
            get => deltaR;
            set
            {
                deltaR = value;
                OnPropertyChanged();
            }
        }
        public int NR
        {
            get => nR;
            set
            {
                nR = value;
                OnPropertyChanged();
            }
        }
        public int W_sR
        {
            get => w_sR;
            set
            {
                w_sR = value;
                OnPropertyChanged();
            }
        }
        public int W_mR
        {
            get => w_mR;
            set
            {
                w_mR = value;
                OnPropertyChanged();
            }
        }
        public int R_cR
        {
            get => r_cR;
            set
            {
                r_cR = value;
                OnPropertyChanged();
            }
        }
        public int R_sR
        {
            get => r_sR;
            set
            {
                r_sR = value;
                OnPropertyChanged();
            }
        }
        public int R_pR
        {
            get => r_pR;
            set
            {
                r_pR = value;
                OnPropertyChanged();
            }
        }
        public int L_vR
        {
            get => l_vR;
            set
            {
                l_vR = value;
                OnPropertyChanged();
            }
        }
        public int L_hR
        {
            get => l_vH;
            set
            {
                l_vH = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region PropertiesSt
        public List<StatisticsDTO> StatisitcsList
        {
            get => statisitcsList;
            set
            {
                statisitcsList = value;
                OnPropertyChanged();
            }
        }
        public StatisticsDTO SelectStat
        {
            get => selectStat;
            set {

                selectStat = value;
                if (value is not null)
                {
                    if (value.Percent == 100)
                        IsRightS = true;
                }
                OnPropertyChanged();
            }
        }
        public bool IsRightS
        {
            get => isRightS;
            set
            {
                isRightS = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region PropertiesTA
        public List<TestDTO> QuestionsList
        {
            get => questionsList;
            set
            {
                questionsList = value;
                OnPropertyChanged();
            }
        }
        public TestDTO SelectQ
        {
            get => selectQ;
            set
            {

                selectQ = value;
                if (value is not null)
                {
                    NameQ = value.Name;
                    UpdateA();
                }
                OnPropertyChanged();
            }
        }
        public List<AnswersDTO> AnswersList
        {
            get => answersList;
            set
            {
                answersList = value;
                OnPropertyChanged();
            }
        }
        public AnswersDTO SelectA
        {
            get => selectA;
            set
            {

                selectA = value;
                if (value is not null)
                {
                    NameA= value.Name;
                    IsRightA = value.IsRight;
                }
                OnPropertyChanged();
            }
        }
        public bool IsRightA
        {
            get => isRightA;
            set
            {
                isRightA = value;
                OnPropertyChanged();
            }
        }
        public string? NameQ
        {
            get => nameQ;
            set
            {
                nameQ = value;
                OnPropertyChanged();
            }
        }
        public string? NameA
        {
            get => nameQ;
            set
            {
                nameQ = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region PropertiesPrac
        public string? NamePractica
        {
            get => namePractica;
            set
            {
                namePractica = value;
                OnPropertyChanged();
            }
        }
        public string? ColbaX
        {
            get => colbaX;
            set
            {
                colbaX = value;
                OnPropertyChanged();
            }
        }
        public string? ConvX
        {
            get => convX;
            set
            {
                convX = value;
                OnPropertyChanged();
            }
        }

        public List<PracticaDTO> PracticaList
        {
            get => practicaList;
            set
            {
                practicaList = value;
                OnPropertyChanged();
            }
        }
        public PracticaDTO SelectPractica
        {
            get => selectPractica;
            set
            {
                selectPractica = value;
                if (value is not null)
                {
                    NamePractica = value.Name;
                    ConvX = value.Conv;
                    ColbaX = value.Colba;
                }
                OnPropertyChanged();
            }
        }
        #endregion

        #region PropertiesProtocol
        public List<ProtocolDTO> ProtocolList
        {
            get => protocolList;
            set
            {
                protocolList = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region PropertiesMO
        public string? NameMO
        {
            get => nameMO;
            set
            {
                nameMO = value;
                OnPropertyChanged();
            }
        }

        public List<MODTO> MOList
        {
            get => mOList;
            set
            {
                mOList = value;
                OnPropertyChanged();
            }
        }
        public MODTO SelectMO
        {
            get => selectMO;
            set
            {
                selectMO = value;
                if (value is not null)
                {
                    NameMO = value.Name;
                }
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        public RelayCommand AddUserCommand { get; set; }
        public RelayCommand EditUserCommand { get; set; }
        public RelayCommand DeleteUserCommand { get; set; }

        public RelayCommand AddRobotCommand { get; set; }
        public RelayCommand EditRobotCommand { get; set; }
        public RelayCommand DeleteRobotCommand { get; set; }

        public RelayCommand EditStatCommand { get; set; }

        public RelayCommand AddQuestionCommand { get; set; }
        public RelayCommand EditQuestionCommand { get; set; }
        public RelayCommand DeleteQuestionCommand { get; set; }

        public RelayCommand AddAnswerCommand { get; set; }
        public RelayCommand EditAnswerCommand { get; set; }
        public RelayCommand DeleteAnswerCommand { get; set; }

        public RelayCommand AddPracticaCommand { get; set; }
        public RelayCommand EditPracticaCommand { get; set; }
        public RelayCommand DeletePracticaCommand { get; set; }

        public RelayCommand AddMOCommand { get; set; }
        public RelayCommand EditMOCommand { get; set; }
        public RelayCommand DeleteMOCommand { get; set; }
        //public RelayCommand MainWindowClearCommand { get; set; }
        #endregion

        public EditVM(IDb db)
        {
            _db= db;
            TypeUserList = _db.GetAllTypeUsers();
            UserList = _db.GetAllUsers();
            CurrentType = TypeUserList[0];

            RobotList = _db.GetAllRobots();
            TypeMechanismList = new List<string> { "МР", "МСГ" };
            CurrentTypeM = TypeMechanismList[0];

            StatisitcsList = _db.GetStatistic();
            SelectStat = StatisitcsList[0];

            PracticaList = _db.GetAllPractica();
            SelectPractica = PracticaList[0];

            ProtocolList = _db.GetAllProtocol();


            MOList = _db.GetAllMO();
            SelectMO = MOList[0];

            UpdateQ();
            UpdateA();

            AddUserCommand = new RelayCommand(obj => AddUser(), obj => CanAddU());
            EditUserCommand = new RelayCommand(obj => EditUser(), obj => CanEditU());
            DeleteUserCommand = new RelayCommand(obj => DeleteUser(), obj => !CanDeleteU());

            AddRobotCommand = new RelayCommand(obj => AddRobot(), obj => CanAddR());
            EditRobotCommand = new RelayCommand(obj => EditRobot(), obj => CanEditR());
            DeleteRobotCommand = new RelayCommand(obj => DeleteRobot(), obj => CanDeleteR());

            EditStatCommand = new RelayCommand(obj => EditStat(), obj => CanEditSt());

            AddQuestionCommand = new RelayCommand(obj => AddQ(), obj => CanAddQ());
            EditQuestionCommand = new RelayCommand(obj => EditQ(), obj => CanEditQ());
            DeleteQuestionCommand = new RelayCommand(obj => DeleteQ(), obj => CanDeleteQ());

            AddAnswerCommand = new RelayCommand(obj => AddA(), obj => CanAddA());
            EditAnswerCommand = new RelayCommand(obj => EditA(), obj => CanEditA());
            DeleteAnswerCommand = new RelayCommand(obj => DeleteA(), obj => CanDeleteA());

            AddPracticaCommand = new RelayCommand(obj => AddPractica(), obj => CanAddP());
            EditPracticaCommand = new RelayCommand(obj => EditPractica(), obj => CanEditP());
            DeletePracticaCommand = new RelayCommand(obj => DeletePractica(), obj => CanDeleteP());

            AddMOCommand = new RelayCommand(obj => AddMO(), obj => CanAddMO());
            EditMOCommand = new RelayCommand(obj => EditMO(), obj => CanEditMO());
            DeleteMOCommand = new RelayCommand(obj => DeleteMO(), obj => CanDeleteMO());
        }
        #region Can
        public bool CanDeleteU() => SelectUser is null;
        public bool CanAddU() => LoginU is not null && PasswordU is not null && CurrentType is not null;
        public bool CanEditU() => LoginU is not null && PasswordU is not null && CurrentType is not null;

        public bool CanDeleteR() => SelectR is not null;
        public bool CanAddR() => NameR is not null && CurrentTypeM is not null;
        public bool CanEditR() => NameR is not null && CurrentTypeM is not null;

        public bool CanEditSt() =>  SelectStat is not null;      

        public bool CanDeleteQ() => SelectQ is not null;
        public bool CanAddQ() => NameQ is not null;
        public bool CanEditQ() => NameQ is not null && SelectQ is not null;

        public bool CanDeleteA() => SelectA is not null;
        public bool CanAddA() => NameA is not null;
        public bool CanEditA() => NameA is not null && SelectA is not null;

        public bool CanDeleteP() => SelectPractica is not null;
        public bool CanAddP() => NamePractica is not null;
        public bool CanEditP() => NamePractica is not null && SelectPractica is not null;

        public bool CanDeleteMO() => SelectMO is not null;
        public bool CanAddMO() => NameMO is not null;
        public bool CanEditMO() => NameMO is not null && SelectMO is not null;
        #endregion
        public void AddUser()
        {
            if (_db.CheckUser(LoginU) == 1)
            {
                MessageBox.Show("Логин уже занят!");
                return;
            }
            else
            {
                _db.AddUser(new UserDTO { Login = LoginU, Password = PasswordU, Role = CurrentType.Type });
                UpdateUsers();
            }
        }
        public void EditUser()
        {

                _db.EditUser(new UserDTO { Login = SelectUser.Login, Password = PasswordU, Role = CurrentType.Type });
                UpdateUsers();
        }
        public void DeleteUser()
        {

                _db.DeleteUser(SelectUser.Login);
                UpdateUsers();
            
           
        }
        public void UpdateUsers()
        {
            UserList = _db.GetAllUsers();
        }

        public void UpdateRobot()
        {
            RobotList = _db.GetAllRobots();
        }
        public void AddRobot()
        {
            _db.AddRobot(new RobotDTO { Delta = DeltaR, G = GR, L_h = L_hR, L_v = L_vR, N = NR, Name = NameR, Mechanism = CurrentTypeM, P = PR, R_c = R_cR, R_p = R_pR, R_s = R_sR, W_m = W_mR, W_s = W_sR });
            UpdateRobot();
            
        }
        public void EditRobot()
        {
            _db.EditRobot(new RobotDTO { Delta = DeltaR, G = GR, L_h = L_hR, L_v = L_vR, N = NR, Name = NameR, Mechanism = CurrentTypeM, P = PR, R_c = R_cR, R_p = R_pR, R_s = R_sR, W_m = W_mR, W_s = W_sR, Id = SelectR.Id });
            UpdateRobot();
        }
        public void DeleteRobot()
        {

            _db.DeleteRobot(SelectR.Id);
            UpdateRobot();


        }

        public void EditStat()
        {
            _db.EditStat(IsRightS, SelectStat.Login);
            UpdateStat();
        }
        public void UpdateStat()
        {
            StatisitcsList = _db.GetStatistic();
        }

        public void UpdateQ()
        {
            QuestionsList = _db.GetAllTests();
        }
        public void AddQ()
        {
            _db.AddTest(new TestDTO { Name = NameQ,  });
            UpdateQ();
        }
        public void EditQ()
        {
            _db.EditTest(new TestDTO { Name=NameQ, Id=SelectQ.Id});
            UpdateQ();
        }
        public void DeleteQ()
        {
            _db.DeleteTest(SelectQ.Id);
            UpdateQ();
        }
        public void UpdateA()
        {
            if (SelectQ is not null)
                AnswersList = _db.GetAnswer(SelectQ.Id);
        }
        public void AddA()
        {
            if (IsRightA)
            {
                if (_db.CheckAnswers(SelectQ.Id) == 0)
                    _db.AddAnswer(new AnswersDTO { IsRight = IsRightA, Name = NameA, IdT = SelectQ.Id });
                else
                {
                    MessageBox.Show("Правильный ответ может быть только 1!");
                }
            }
            else
            {
                _db.AddAnswer(new AnswersDTO { IsRight = IsRightA, Name = NameA, IdT = SelectQ.Id });
            }
            UpdateA();

        }
        public void EditA()
        {

            _db.EditAnswer(new AnswersDTO { Id = SelectA.Id, Name = NameA, IsRight = IsRightA });
            UpdateA();
        }
        public void DeleteA()
        {
            _db.DeleteAnswer(SelectA.Id);
            UpdateA();
        }

        public void UpdatePractica()
        {
            PracticaList = _db.GetAllPractica();
        }
        public void AddPractica()
        {
            _db.AddPractica(new PracticaDTO { Name = NamePractica, Colba = ColbaX, Conv=ConvX });           
            UpdatePractica();

        }
        public void EditPractica()
        {
            _db.EditPractica(new PracticaDTO { IdPr = SelectPractica.IdPr, Name = NamePractica, Colba = ColbaX, Conv = ConvX });
            UpdatePractica();
        }
        public void DeletePractica()
        {
            _db.DeletePractica(SelectPractica.IdPr);
            UpdatePractica();
        }

        public void UpdateMO()
        {
            MOList = _db.GetAllMO();
        }
        public void AddMO()
        {
            _db.AddMO(new MODTO { Name = NameMO });
            UpdateMO();

        }
        public void EditMO()
        {
            _db.EditMO(new MODTO { Id = SelectMO.Id, Name = NameMO });
            UpdateMO();
        }
        public void DeleteMO()
        {
            _db.DeleteMO(SelectMO.Id);
            UpdateMO();
        }

    }
}
