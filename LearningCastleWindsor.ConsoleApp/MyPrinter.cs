using LearningCastleWindsor.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCastleWindsor.ConsoleApp
{
    public class MyPrinter : IPrinter
    {
        public void ClinicPrint(int chargeID)
        {
            Console.WriteLine("门诊打印 " + chargeID.ToString());
        }

        public void RegPrint(int regID)
        {
            Console.WriteLine("挂号打印 " + regID.ToString());
        }
    }
}
