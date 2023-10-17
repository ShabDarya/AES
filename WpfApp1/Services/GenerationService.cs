using System;
using System.Collections.Generic;
using WpfApp1.DTO;
using WpfApp1.Interfaces;

namespace WpfApp1.Services
{
    public class GenerationService : IGenerationServices
    {
        //public List<TestDTO> Generation(ParametersDTO p)
        //{
        //    List<TestDTO> res = new List<TestDTO>();
        //    if (p.IsPositive)
        //    {
        //        for (int j = 0; j < p.Count; j++)
        //        {
        //            TestDTO t = new TestDTO { LLimit=p.LLimit, RLimit= p.RLimit, Step =p.Step, IsPositive=p.IsPositive, Method=p.Method, Epsilon=p.Epsilon};
        //            t.Id = j + 1;
        //            if (t.Method == 1) t.MethodName = "Метод парабол";
        //            else if (t.Method == 2) t.MethodName = "Метод трапеции";
        //            else if (t.Method == 3) t.MethodName = "Метод Монте-Карло";
        //            if (!Int32.TryParse(p.S, out int sp)) sp = -1;
        //            if (sp == -1) sp = GenerationInt(LimitsModels.START_ID_OF_COUNT_CORR, LimitsModels.END_ID_OF_COUNT);

        //            t.Koef = new List<double>();
        //            for (int i = 0; i < sp; i++)
        //            {
        //                t.Koef.Add(GenerationDouble(-100, 100));
        //                t.Koefs += t.Koef[i].ToString();
        //                t.Koefs += " ";
        //            }
        //            res.Add(t);
        //        }
        //    }
        //    else
        //    {
        //        for (int j = 0; j < p.Count; j++)
        //        {
        //            TestDTO t = new TestDTO { LLimit = p.LLimit, RLimit = p.RLimit, Step = p.Step, IsPositive = p.IsPositive, Method = p.Method, Epsilon = p.Epsilon };
        //            t.Id = j + 1;
        //            if (t.Method == 1) t.MethodName = "Метод парабол";
        //            else if (t.Method == 2) t.MethodName = "Метод трапеции";
        //            else if (t.Method == 3) t.MethodName = "Метод Монте-Карло";
        //            if (!Int32.TryParse(p.S, out int sp)) sp = -1;
        //            if ( sp== -1) sp = GenerationInt(LimitsModels.START_ID_OF_COUNT_CORR, LimitsModels.END_ID_OF_COUNT);
        //            if (sp > 0) t.idIncorrect= GenerationInt(0, sp + 1);
        //            t.Koef = new List<double>();
        //            int count = 0;
        //            for (int i = 0; i < sp; i++)
        //            {
        //                if (i == t.idIncorrect)
        //                {
        //                    t.incorrect=GenerationDoubleIncorrect();
        //                    t.Koefs += t.incorrect;
        //                }
        //                else
        //                {
        //                    t.Koef.Add(GenerationDouble(-100, 100));
        //                    t.Koefs += t.Koef[count].ToString();
        //                    count++;
        //                }
        //                t.Koefs += " ";


        //            }
        //            res.Add(t);
        //        }
        //    }
        //    return res;
        //}

        //double GenerationDouble(double l, double r)
        //{
        //        Random random = new Random();
        //    int g = (-1) ^ (random.Next(3));
        //            return Math.Round(g*(random.NextDouble() * (r - l) + l), 2);          
        //}

        //string GenerationDoubleIncorrect()
        //{
        //    Random random = new Random();
        //    int v = random.Next(LimitsModels.COUNT_VARIANTS_OF_INCORRECT);
        //    string s="";
        //    switch (v)
        //    {
        //        case LimitsModels.VALUE_SMALLER_L_LIMIT:
        //            s= LimitsModels.INCORRECT_LEFT_LIMIT_OF_DOUBLE;
        //            break;
        //        case LimitsModels.VALUE_BIGGER_R_LIMIT:
        //            s=LimitsModels.INCORRECT_RIGHT_LIMIT_OF_DOUBLE;
        //            break;
        //        case LimitsModels.DOT_INSTEAD_OF_COMMA:
        //            s = GenerationDouble(LimitsModels.LEFT_LIMIT_OF_DOUBLE, LimitsModels.RIGHT_LIMIT_OF_DOUBLE).ToString();
        //            s.Replace(',', '.');
        //            break;
        //        case LimitsModels.LETTERS:
        //            s = "Буквы";
        //            break;
        //        default:
        //            break;
        //    }
        //    return s;
        //}

        //int GenerationInt(int l, int r)
        //{
        //    Random random = new Random();
        //    int id = 0;
        //    do
        //    {
        //        id = random.Next(r);
        //    } while (id < l);
        //    return id;
        //}

        //public List<TestDTO> GenerationExercise(ParametersDTO p)
        //{
        //    List<TestDTO> r = new List<TestDTO>();

        //    List<double>  t = new List<double>();
        //    for (int i = 0; i < 15; i++)
        //    {
        //        t.Add(GenerationDouble(-100, 100));
        //    }

        //    for(int i=0; i<15; i++)
        //    {
        //        List<double> k = new List<double>();
        //        for(int j=0; j<i+1; j++)
        //        {
        //            k.Add(t[j]);
        //        }

        //        for (int j = 1; j < 4; j++)
        //        {
        //            TestDTO test = new TestDTO { LLimit = p.LLimit, RLimit = p.RLimit, Step = p.Step, Method = j, Epsilon = p.Epsilon, Koef=k, IsPositive=true };
        //            r.Add(test);
        //        }

        //    }
        //    for(int i = 0; i < r.Count; i++)
        //    {
        //        r[i].Id = i + 1;
        //        if (r[i].Method == 1) r[i].MethodName = "Метод парабол";
        //        else if (r[i].Method == 2) r[i].MethodName = "Метод трапеции";
        //        else if (r[i].Method == 3) r[i].MethodName = "Метод Монте-Карло";
        //        for (int j = 0; j < r[i].Koef.Count; j++)
        //        {
        //            r[i].Koefs += r[i].Koef[j].ToString();
        //            r[i].Koefs += " ";
        //        }
        //    }

        //    return r;
        //}
    }
}
