using ProgramSystem.Bll.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WpfApp1.Interfaces
{
    public interface IDb
    {
        public void Connection();
        public string SelectUser(string l, string p);
        public List<TypeUsersDTO> GetAllTypeUsers();
        public List<UserDTO> GetAllUsers();
        public void AddUser(UserDTO u);
        public void DeleteUser(string login);
        public void EditUser(UserDTO u);
        public List<RobotDTO> GetAllRobots();
        public void AddRobot(RobotDTO r);
        public void DeleteRobot(int id); 
        public void EditRobot(RobotDTO r);
        public List<UprCommandDTO> GetAllUprCommand();
        public void AddUprCommand(UprCommandDTO U);
        public void DeleteUprCommand(int id);
        public void EditUprCommand(UprCommandDTO u);
        public int SelectLastCommand(UprCommandDTO u);
        public List<CodeDTO> GetAllCode();
        public void AddCode(CodeDTO o);
        public void DeleteCode(int id);
        public void EditCode(CodeDTO o);
        public List<string> GetCode(int id);
        public List<UprCommandDTO> SelectCommandLogin(string l, int r);
        public int CheckUser(string l);
        public List<TestDTO> GetAllTests();
        public List<AnswersDTO> GetAnswer(int id);
        public void AddTest(TestDTO t);
        public void AddAnswer(AnswersDTO a);
        public bool CheckTest(string t);
        public int CheckAnswers(int i);
        public void EditTest(TestDTO t);
        public void EditAnswer(AnswersDTO a);
        public void DeleteTest(int id);
        public void DeleteAnswer(int id);
        public void EditStat(bool b, string log);
        public List<StatisticsDTO> GetStatistic();
        public void AddStat(string l, int id);
        public List<TestUserDTO> GetTestForUser(string log);

        public List<PracticaDTO> GetAllPractica();
        public List<PracticaDTO> GetPracticaForUser(string l);
        public void AddPractica(PracticaDTO p);
        public void EditPractica(PracticaDTO p);
        public void DeletePractica(int id);

        public void AddProtocol(ProtocolDTO p);
        public List<ProtocolDTO> GetAllProtocol();
        public void EditPractica(ProtocolDTO p);
        public void ProtocolDTO(int id);

        public List<MODTO> GetAllMO();
        public void AddMO(MODTO p);
        public void EditMO(MODTO p);
        public void DeleteMO(int id);
    }
}
