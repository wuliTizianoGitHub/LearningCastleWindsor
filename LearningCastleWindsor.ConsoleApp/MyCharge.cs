using LearningCastleWindsor.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCastleWindsor.ConsoleApp
{
    public class MyCharge : ICharge
    {
        public IPrinter printer { set; get; }

        public void ClinicChcarge()
        {
            Console.WriteLine("门诊收费");
            printer.ClinicPrint(100000);
        }
    }
}
