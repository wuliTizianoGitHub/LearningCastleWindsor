using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCastleWindsor.ConsoleApp.Interfaces
{
    //打印接口
    public interface IPrinter
    {
        void RegPrint(int regID);
        void ClinicPrint(int chargeID);
    }
}
