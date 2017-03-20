using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCastleWindsor.ConsoleApp
{
    public class WindsorInit
    {
        private static WindsorContainer _container;

        public static WindsorContainer GetContainer()
        {
            if (_container == null)
            {
                _container = new WindsorContainer();
                //注册自己
                _container.Install(FromAssembly.This());
            }
            return _container;
        }

        public void CloseContext()
        {
            _container.Dispose();
        }
    }
}
