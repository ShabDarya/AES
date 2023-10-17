using Microsoft.Data.Sqlite;
using ProgramSystem.Bll.Services.DTO;
using ProgramSystem.Data.Repository.Factories;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WpfApp1.DTO;
using WpfApp1.Interfaces;

namespace WpfApp1.Services
{
    public class DbService :IDb
    {
        const string connection = "Data Source = Database.db";

        public void Connection()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
            }
            con.Close();

        }

        public string SelectUser(string l, string p)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"SELECT type_users FROM type_users WHERE id_type_users = (SELECT type_user FROM users WHERE login = '{l}' AND password= '{p}')";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            string? type="";
            while (reader.Read())
            {
                type = reader["type_users"].ToString();
            }
            con.Close();
            if (type != null)
                return type;
            else return "1";
        }

        public int CheckUser(string l)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"SELECT Count(*) as r from users where login='{l}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            int i = 0;
            while (reader.Read())
            {
                i = Int16.Parse(reader["r"].ToString());
            }
            con.Close();
                return i;
            ;
        }

        public List<TypeUsersDTO> GetAllTypeUsers()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = @"SELECT * From type_users";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<TypeUsersDTO> e = new List<TypeUsersDTO>();
            while (reader.Read())
            {
                e.Add(new TypeUsersDTO
                {
                    Id = Int16.Parse(reader["id_type_users"].ToString()),
                    Type = reader["type_users"].ToString(),

                });
            }
            con.Close();
            return e;
        }

        public List<UserDTO> GetAllUsers()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = @"SELECT login, password, type_users  FROM users INNER JOIN type_users ON users.type_user=type_users.id_type_users";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<UserDTO> e = new List<UserDTO>();
            while (reader.Read())
            {
                e.Add(new UserDTO
                {
                    Login = reader["login"].ToString(),
                    Password = reader["password"].ToString(),
                    Role = reader["type_users"].ToString()

                });
            }
            con.Close();
            return e;
        }

        public void AddUser(UserDTO u)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"INSERT INTO users (login, password, type_user) VALUES ('{u.Login}', '{u.Password}', (Select id_type_users from type_users where type_users='{u.Role}'))";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteUser(string login)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"DELETE FROM users WHERE login='{login}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EditUser(UserDTO u)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"UPDATE users SET password='{u.Password}', type_user=(Select id_type_users from type_users where type_users='{u.Role}') where login='{u.Login}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<RobotDTO> GetAllRobots()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = @"SELECT *  FROM robot";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<RobotDTO> e = new List<RobotDTO>();
            while (reader.Read())
            {
                e.Add(new RobotDTO
                {
                    Id = Int16.Parse(reader["id_robot"].ToString()),
                    G = Double.Parse(reader["g"].ToString()),
                    N = Int16.Parse(reader["n"].ToString()),
                    P = Double.Parse(reader["p"].ToString()),
                    Delta = Double.Parse(reader["delta"].ToString()),
                    W_s = Int16.Parse(reader["w_s"].ToString()),
                    W_m = Int16.Parse(reader["w_m"].ToString()),
                    R_c = Int16.Parse(reader["r_c"].ToString()),
                    R_s = Int16.Parse(reader["r_s"].ToString()),
                    R_p = Int16.Parse(reader["r_p"].ToString()),
                    L_v = Int16.Parse(reader["l_v"].ToString()),
                    L_h = Int16.Parse(reader["l_h"].ToString()),
                    Mechanism = reader["mechanism"].ToString(),
                    Name = reader["name"].ToString()
                }); 
            }
            con.Close();
            return e;
        }

        public void AddRobot(RobotDTO r)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"INSERT INTO robot (g,n,p,delta,w_s,w_m,r_c,r_s,r_p,l_v,l_h,mechanism, name) VALUES ('{r.G}','{r.N}','{r.P}','{r.Delta}','{r.W_s}','{r.W_m}','{r.R_c}','{r.R_s}','{r.R_p}','{r.L_v}','{r.L_h}','{r.Mechanism}', '{r.Name}')";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteRobot(int id)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"DELETE FROM ROBOT WHERE id_robot='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EditRobot(RobotDTO r)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"UPDATE robot SET g='{r.G}',n='{r.N}',p='{r.P}',delta='{r.Delta}',w_s='{r.W_s}',w_m='{r.W_m}',r_c='{r.R_c}',r_s='{r.R_s}',r_p='{r.R_p}',l_v='{r.L_v}',l_h='{r.L_h}',mechanism=='{r.Mechanism}', name='{r.Name}' where id_robot=='{r.Id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<UprCommandDTO> GetAllUprCommand()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = @"SELECT *  FROM program";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<UprCommandDTO> e = new List<UprCommandDTO>();
            while (reader.Read())
            {
                e.Add(new UprCommandDTO
                {
                    IdPr = Int16.Parse(reader["id_p"].ToString()),
                    IdR = Int16.Parse(reader["id_r"].ToString()),
                    Login = reader["log"].ToString()
                });
            }
            con.Close();
            return e;
        }

        public void AddUprCommand(UprCommandDTO U)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"INSERT INTO program (id_r, log) VALUES ('{U.IdR}','{U.Login}')";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteUprCommand(int id)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"DELETE FROM Code WHERE id_p='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();

            c = $"DELETE FROM program WHERE id_p='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EditUprCommand(UprCommandDTO u)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"UPDATE program SET id_r='{u.IdR}', log='{u.Login}' where id_p=='{u.IdPr}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public int SelectLastCommand(UprCommandDTO u)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"Select Max(id_p) as r  from program where log = '{u.Login}' and id_r='{u.IdR}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            int e = 0;
            while (reader.Read())
            {
                e = Int16.Parse(reader["r"].ToString());
            }
            con.Close();
            return e;
        }
        public List<UprCommandDTO> SelectCommandLogin(string l, int r)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"Select *  from program where log = '{l}' AND id_r='{r}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<UprCommandDTO> e = new List<UprCommandDTO>();
            while (reader.Read())
            {
                e.Add(new UprCommandDTO
                {
                    IdPr = Int16.Parse(reader["id_p"].ToString()),
                    IdR = Int16.Parse(reader["id_r"].ToString()),
                    Login = reader["log"].ToString()
                });
            }
            con.Close();
            return e;
        }

        public List<CodeDTO> GetAllCode()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = @"SELECT *  FROM Code";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<CodeDTO> e = new List<CodeDTO>();
            while (reader.Read())
            {
                e.Add(new CodeDTO
                {
                    IdPr = Int16.Parse(reader["id_p"].ToString()),
                    IdC = Int16.Parse(reader["id_com"].ToString()),
                    Command = reader["command"].ToString()
                });
            }
            con.Close();
            return e;
        }

        public void AddCode(CodeDTO o)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"INSERT INTO Code (id_p, command) VALUES ('{o.IdPr}','{o.Command}')";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteCode(int id)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"DELETE FROM Code WHERE id_p='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EditCode(CodeDTO o)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"UPDATE code SET id_p='{o.IdPr}', command='{o.Command}' where id_com=='{o.IdC}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<string> GetCode(int id)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"SELECT *  FROM Code WHERE id_p='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<string> e = new List<string>();
            while (reader.Read())
            {
                e.Add(reader["command"].ToString());
            }
            con.Close();
            return e;
        }

        public List<TestDTO> GetAllTests()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = @"SELECT * FROM test";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<TestDTO> e = new List<TestDTO>();
            while (reader.Read())
            {
                e.Add(new TestDTO
                {
                    Id = Int16.Parse(reader["id_t"].ToString()),
                    Name = reader["question"].ToString(),
                });
            }
            con.Close();
            return e;
        }

        public List<AnswersDTO> GetAnswer(int id)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"SELECT * FROM answers WHERE id_t='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<AnswersDTO> e = new List<AnswersDTO>();
            while (reader.Read())
            {
                bool f;
                if (Int16.Parse(reader["correct"].ToString()) == 1) f = true;
                else f = false;
                e.Add(new AnswersDTO
                {
                    Id = Int16.Parse(reader["id_a"].ToString()),
                    Name = reader["answer"].ToString(),
                    IsRight = f
                });
            }
            con.Close();
            return e;
        }

        public void AddTest(TestDTO t)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"INSERT INTO test (question) VALUES ('{t.Name}')";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AddAnswer(AnswersDTO a)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();
            SQLiteCommand cmd;
            int f=0;
            if (a.IsRight) f = 1;
            string c = $"INSERT INTO answers (answer, correct, id_t) VALUES ('{a.Name}', '{f}', '{a.IdT}')";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool CheckTest(string t)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"SELECT COUNT(*) as r FROM test WHERE question='{t}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            string a="";
            while (reader.Read())
            {
                a = reader["r"].ToString();
            }
            
            con.Close();
            if (Int16.Parse(a) > 0) return false;
            return true;
        }

        public int CheckAnswers(int i)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"SELECT COUNT(*) as r FROM answers WHERE correct='1' AND id_t='{i}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            string a = "";
            while (reader.Read())
            {
                a = reader["r"].ToString();
            }

            con.Close();
            return Int16.Parse(a);
        }

        public void EditTest(TestDTO t)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"UPDATE test SET question='{t.Name}' where id_t=='{t.Id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void EditAnswer(AnswersDTO a)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            int f = 0;
            if (a.IsRight) f = 1;
            string c = $"UPDATE answers SET answer='{a.Name}', correct='{f}' where id_a=='{a.Id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteTest(int id)
        {
            SQLiteConnection con;
            List<AnswersDTO> l = GetAnswer(id);
            for(int i=0; i < l.Count; i++)
            {
                DeleteAnswer(l[i].Id);
            }
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;          

            string c = $"DELETE FROM test WHERE id_t='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();

            con.Close();
        }
        public void DeleteAnswer(int id)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"DELETE FROM answers WHERE id_a='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void EditStat(bool b, string log)
        {
            if (b)
            {
                List < TestDTO > t = GetAllTests();
                List<int> s = GetStatistic(log);
                bool g = true;
                for(int i = 0; i < t.Count; i++)
                {
                    g = true;
                    for (int j = 0; j < s.Count; j++)
                    {
                        if (s[j] == t[i].Id)
                        {
                            g = false;
                            break;
                        }
                        if(g)
                            AddStat(log, t[i].Id);
                    }
                }
            }
            else
            {
                SQLiteConnection con;
                con = new SQLiteConnection(connection);
                con.Open();
                SQLiteCommand cmd;

                string c = $"DELETE FROM statistics WHERE login='{log}'";

                cmd = con.CreateCommand();
                cmd.CommandText = c;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }

        public List<StatisticsDTO> GetStatistic()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;

            int count=1;

            string c = @"SELECT Count(id_t) as r from test";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                count = Int16.Parse(reader["r"].ToString());

            }

             c = @"SELECT login, Count(id_t) as r from statistics Group by login";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            reader = cmd.ExecuteReader();
            List<StatisticsDTO> e = new List<StatisticsDTO>();
            while (reader.Read())
            {
                int r = Int16.Parse(reader["r"].ToString());
                e.Add(new StatisticsDTO
                {
                    Login = reader["login"].ToString(),
                    Percent = Math.Round(((double)r / count * 100), 2)
                }); ; ;
            }
            con.Close();
            return e;
        }
        public List<int> GetStatistic(string l)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;

            int count = 1;


            string c = $"SELECT id_t from statistics WHERE login='{l}";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<int> e = new List<int>();
            while (reader.Read())
            {
                e.Add(Int16.Parse(reader["r"].ToString())); 
            }
            con.Close();
            return e;
        }

        public bool GetStatistic(string l, int id)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;

            string c = $"SELECT Count(*) as r from statistics WHERE login='{l}' AND id_t={id}";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            int e = 0;
            while (reader.Read())
            {
                e = Int16.Parse(reader["r"].ToString());
            }
            con.Close();
            if (e == 1) return true;
            return false;
        }

        public void AddStat(string l, int id)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"INSERT INTO statistics (login, id_t) VALUES ('{l}', '{id}')";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public List<TestUserDTO> GetTestForUser(string log)
        {
            List<TestDTO> t = GetAllTests();
            List<TestUserDTO> tests = new List<TestUserDTO>();
            List<AnswersDTO> a = new List<AnswersDTO>();
            for(int i=0; i < t.Count; i++)
            {
                a = GetAnswer(t[i].Id);
                if (a is not null && a.Count > 0)
                {
                    if (!GetStatistic(log, t[i].Id))
                    {
                        tests.Add(new TestUserDTO { A = a, T = t[i] });
                    }
                }
            }

            
            return tests;
        }


        public List<PracticaDTO> GetAllPractica()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = @"SELECT * FROM practica"; //SELECT * FROM practica LEFT JOIN protocol ON practica.id_practica=protocol.id_practica Where protocol.id_practica is NULL
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<PracticaDTO> e = new List<PracticaDTO>();
            while (reader.Read())
            {
                e.Add(new PracticaDTO
                {
                    IdPr = Int16.Parse(reader["id_practica"].ToString()),
                    Name = reader["name"].ToString(),
                    Colba = reader["colba"].ToString(),
                    Conv = reader["conveyer"].ToString()
                });
            }
            con.Close();
            return e;
        }
        public List<PracticaDTO> GetPracticaForUser(string l)
        {          
            List<PracticaDTO> allPr = GetAllPractica();
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"SELECT * FROM protocol WHERE login='{l}' AND practica_ready=1";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<int> e = new List<int>();
            while (reader.Read())
            {
                string? r = reader["id_practica"].ToString();
                int t = Int16.Parse(r);
                e.Add(t);
            }
            con.Close();

            foreach(int exer in e)
            {
                for(int i=0; i<allPr.Count; i++)
                {
                    if (allPr[i].IdPr == exer)
                    {
                        allPr.RemoveAt(i);
                        break;
                    }
                }
            }

            return allPr;
        }
        public void AddPractica(PracticaDTO p)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"INSERT INTO practica (name, colba, conveyer) VALUES ('{p.Name}','{p.Colba}','{p.Conv}')";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void EditPractica(PracticaDTO p)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"UPDATE practica SET name='{p.Name}', colba= '{p.Colba}', conveyer='{p.Conv}' where id_practica=='{p.IdPr}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeletePractica(int id)
        {
            SQLiteConnection con;
            
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;

            string c = $"DELETE FROM practica WHERE id_practica='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public void AddProtocol(ProtocolDTO p)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            int t = 0;
            int pr = 0;
            if (p.ReadyTest) 
                t = 1;
            if (p.ReadyPr) 
                pr = 1;
            string c = $"INSERT INTO protocol (test_ready, practica_ready, id_practica, login) VALUES ('{t}','{pr}','{p.IdPractica}','{p.Login}')";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<ProtocolDTO> GetAllProtocol()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = @"SELECT * FROM protocol";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<ProtocolDTO> e = new List<ProtocolDTO>();
            bool t;
            bool pr;
            while (reader.Read())
            {
                t = false;
                pr = false;
                string t1 = reader["test_ready"].ToString();
                string t2 = reader["practica_ready"].ToString();
                if (Int16.Parse(t1) == 1) 
                    t = true;
                if (Int16.Parse(t2) == 1) 
                    pr = true;
                string? r = reader["id_practica"].ToString();
                if (r!="")
                {
                    e.Add(new ProtocolDTO
                    {
                        IdProtocol = Int16.Parse(reader["id_protocol"].ToString()),
                        IdPractica = Int16.Parse(reader["id_practica"].ToString()),
                        Login = reader["login"].ToString(),
                        ReadyPr = pr,
                        ReadyTest = t
                    }); 
                }
                else
                {
                    e.Add(new ProtocolDTO
                    {
                        IdProtocol = Int16.Parse(reader["id_protocol"].ToString()),
                        Login = reader["login"].ToString(),
                        ReadyPr = pr,
                        ReadyTest = t
                    });
                }

                
            }
            con.Close();
            return e;
        }
        public void EditPractica(ProtocolDTO p)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"UPDATE protocol SET login='{p.Login}', id_practica='{p.IdPractica}', test_ready='{p.ReadyTest}', practica_ready='{p.ReadyPr}' where id_protocol=='{p.IdProtocol}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ProtocolDTO(int id)
        {
            SQLiteConnection con;

            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;

            string c = $"DELETE FROM protocol WHERE id_protocol='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();

            con.Close();
        }

        public List<MODTO> GetAllMO()
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = @"SELECT * FROM methodichka"; //SELECT * FROM practica LEFT JOIN protocol ON practica.id_practica=protocol.id_practica Where protocol.id_practica is NULL
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            SQLiteDataReader reader = cmd.ExecuteReader();
            List<MODTO> e = new List<MODTO>();
            while (reader.Read())
            {
                e.Add(new MODTO
                {
                    Id = Int16.Parse(reader["id_m"].ToString()),
                    Name = reader["text"].ToString(),
                });
            }
            con.Close();
            return e;
        }       
        public void AddMO(MODTO p)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"INSERT INTO methodichka (text) VALUES ('{p.Name}')";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void EditMO(MODTO p)
        {
            SQLiteConnection con;
            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;
            string c = $"UPDATE methodichka SET text='{p.Name}' where id_m=='{p.Id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteMO(int id)
        {
            SQLiteConnection con;

            con = new SQLiteConnection(connection);
            con.Open();

            SQLiteCommand cmd;

            string c = $"DELETE FROM methodichka WHERE id_m='{id}'";
            cmd = con.CreateCommand();
            cmd.CommandText = c;
            cmd.ExecuteNonQuery();

            con.Close();
        }

    }
}
