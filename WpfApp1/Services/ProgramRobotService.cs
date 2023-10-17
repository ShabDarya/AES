using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Interfaces;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class ProgramRobotService : IProgramRobot
    {
        private Dictionary<int, int> counters = new Dictionary<int, int>();

        public bool checking = false;

        //проверка на правильность написания комманды
        public bool Checking(string p, string o)
        {
            if (p is null || p is null) return false;
            switch (p)
            {

                case "01": //ПРОВЕРКА ДАТЧИКОВ ОТКУДА УЕХАЛ
                    switch (o)
                    {
                        case "00":
                            return true;
                        case "01":
                            return true;
                        case "02":
                            return true;
                        case "03":
                            return true;
                        case "04":
                            return true;
                        case "05":
                            return true;
                        default:
                            return false;
                    }
                case "02": //ПРОВЕРКА ДАТЧИКОВ ЧТО ПРИЕХАЛ
                    switch (o)
                    {
                        case "00":
                            return true;
                        case "01":
                            return true;
                        case "02":
                            return true;
                        case "03":
                            return true;
                        case "04":
                            return true;
                        case "05":
                            return true;
                        default:
                            return false;
                    }
                case "05": //УХОД ИЗ БАЗЫ
                    switch (o)
                    {
                        case "00":
                            return true;
                        case "01":
                            return true;
                        case "02":
                            return true;
                        case "03":
                            return true;
                        case "04":
                            return true;
                        default:
                            return false;
                    }
                case "06": //ВОЗВРАТ В БАЗУ
                    switch (o)
                    {
                        case "00":
                            return true;
                        case "01":
                            return true;
                        case "02":
                            return true;
                        case "03":
                            return true;
                        case "04":
                            return true;
                        default:
                            return false;
                    }
                case "07": //ВЫДЕРЖКА ВРЕМЕНИ
                    return true;
                case "08": //СТОП                
                    switch (o)
                    {
                        case "00":
                            return true;
                        default:
                            return false;
                    }
                case "09": //БУ
                    return true;
                case "11": //ВОЗВРАТ ПРОГРАММЫ
                    switch (o)
                    {
                        case "00":
                            return true;
                        default:
                            return false;
                    }
                case "0B": //Переход к выполнению команды, содержащейся по указанному адресу, если в бите условия 0. 
                    return true;
                case "0C": //ИНКРЕМЕНТ СЧЕТЧИКА
                    return true;
                case "0D": //СБРОС СЧЕТЧИКА - number
                    return true;
                case "0E": //СРАВНЕНИЕ СЧЕТЧИКА
                    if (counters.ContainsKey(Convert.ToInt32(o[1].ToString(), 16)))
                        return true;
                    else
                        return false;
                case "14": //ВСТАВКА КОМАНДЫ
                    return true;
                default:
                    return false;                   
            };
            return true;
        }

        public void RunProgramMovement(ref RobotRunModel r, string p, string o, out int ending)
        {
            switch (p)
            {
                case "05":
                    switch (o)
                    {
                        case "00":
                            r.ArmUp = -5f; //0f;
                            break;
                        case "01":
                            r.ArmRound = -60f; //
                            break;
                        case "02":
                            r.ElbowForward = 5f; //
                            break;
                        case "03":
                            if (SettingsMovements.SelectR.Mechanism == "МР")
                            {
                                r.HandRound = 180f;
                                r.HandDownUp = 0f;
                            }
                            else if(SettingsMovements.SelectR.Mechanism == "МСГ")
                            {
                                r.HandRound = 0f;
                                r.HandDownUp = -90f;
                            }
                            break;
                        case "04":
                            r.FingerL = -7f;
                            r.FingerR = 7f;
                            break;
                    }
                    break;
                case "06":
                    switch (o)
                    {
                        case "00":
                            r.ArmUp = 0f; //0f;
                            break;
                        case "01":
                            r.ArmRound = 0f; //
                            break;
                        case "02":
                            r.ElbowForward = 0f; //
                            break;
                        case "03":
                            r.HandRound = 0f;
                            break;
                        case "04":
                            r.FingerL = 0f;
                            r.FingerR = 0f;
                            break;
                    }
                    break;
            }
            string json = JsonSerializer.Serialize(r);
            SendJson(json, out ending);
        }
        public void RunProgramTime(string o)
        {
            double r = Convert.ToInt32(o, 16) * 0.1;
            r = Math.Round(r, 0);
            Thread.Sleep(Int32.Parse((r).ToString()));
        }

        public void SendJson(string json, out int ending)
        {
            string? dataFromClient;
            //UpdateLogCallback updateLog = new UpdateLogCallback(UpdateLog);
            try
            {
                //Don't pass until a Connection has been established
                while (LVD_Steelplying_Embed_Unity_Exe_Winforms_Control.namedPipeServerStream.IsConnected == false)
                {
                    Thread.Sleep(100);
                }
                //Created stream for reading and writing
                StreamString serverStream = new StreamString(LVD_Steelplying_Embed_Unity_Exe_Winforms_Control.namedPipeServerStream);
                serverStream.WriteString(json);
                dataFromClient = serverStream.ReadString();
                //Invoke(updateLog, new object[] { "Received Data from Server: " + dataFromClient });
                //throw new Exception(dataFromClient);
                switch (dataFromClient){
                    case "GoodEnd":
                        ending = 1;
                        break;
                    case "BadEnd":
                        ending = -1;
                        break;
                    default:
                        ending = 0;
                        break;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //Invoke(updateLog, new object[] { ex.Message });
            }

        }

        public List<string> RunProgramIsert(string o, List<string> l)
        {
            List<string> list = new List<string>();
            int c = 0;
            int ct = 0;
            bool check = false;
            int insert = Convert.ToInt32(o, 16);
            while (true)
            {
                if (c == insert)
                {
                    list.Add("");
                    check = true;
                }
                else if(ct<= l.Count - 1)
                {
                    list.Add(l[ct]);
                    ct++;
                }
                else
                {
                    list.Add("");
                }

                if (ct == l.Count && check)
                    break;
                c++;
            }
            return list;

        }

        public void RunProgramCounter(string p, int c)
        {
            if (c == 0)
            {
                if (counters.TryGetValue(Convert.ToInt32(p, 16), out int n))
                {
                    counters[Convert.ToInt32(p, 16)] = 0;
                }
                else
                {
                    counters.TryAdd(Convert.ToInt32(p, 16), 0);
                }
            }
            else
            {
                if (counters.TryGetValue(Convert.ToInt32(p, 16), out int n))
                {
                    counters[Convert.ToInt32(p, 16)] ++;
                }
                else
                {
                    counters.TryAdd(Convert.ToInt32(p, 16), 0);
                }
            }
        }

        public void RunProgramChecking(string p)
        {
            int t = (int)p[1];
            int r = (int)p[0];
            if (counters[Convert.ToInt32(p[1].ToString(), 16)] != Convert.ToInt32(p[0].ToString(), 16)) 
                checking = false;
            else checking = true;
        }

        public void RunChecking(string p, string o, ref int count)
        {
            switch (p)
            {
                case "0B":
                    if (!checking)
                        count = Convert.ToInt32(o, 16) -1;
                        break;
                case "0C":
                    RunProgramCounter(o, 1);
                    break;
                case "0D":
                    RunProgramCounter(o, 0);
                    break;
                case "0E":
                    RunProgramChecking(o);
                    break;
                default:
                    break;
            }
        }
    }
}
