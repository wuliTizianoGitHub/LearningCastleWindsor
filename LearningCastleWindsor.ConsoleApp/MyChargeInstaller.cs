using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace LearningCastleWindsor.ConsoleApp
{
    //IOC容器的相关配置,注册需要进行控制的接口以及实现
    public class MyChargeInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //将接口注册到容器中
            //注意，这里的InNamespace中的参数是实现类的命名空间而不是接口的命名空间
            container.Register(Classes.FromThisAssembly().InNamespace("LearningCastleWindsor.ConsoleApp").WithService.DefaultInterfaces());
        }
    }
}
