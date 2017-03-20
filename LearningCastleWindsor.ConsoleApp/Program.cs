using Castle.MicroKernel;
using Castle.Windsor;
using LearningCastleWindsor.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCastleWindsor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WindsorContainer container = WindsorInit.GetContainer();
            ICharge charge = container.Resolve<ICharge>(new Arguments(new { }));
            charge.ClinicChcarge();
            Console.ReadKey();
        }
    }
}
