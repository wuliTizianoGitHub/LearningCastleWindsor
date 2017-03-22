using Castle.MicroKernel;
using Castle.Windsor;
using LearningCastleWindsor.ToBeSeen.Installers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace LearningCastleWindsor.ToBeSeen.Tests
{
    public class ControllersInstallerTests
    {
        private IWindsorContainer containerWithControllers;

        public ControllersInstallerTests()
        {
            containerWithControllers = new WindsorContainer().Install(new ControllersInstaller());
        }

        [Fact]
        public void All_controllers_implement_IController()
        {
            var allHandlers = GetAllHandlers(containerWithControllers);

            var controllerHandlers = GetHandlersFor(typeof(IController), containerWithControllers);

            Assert.NotEmpty(allHandlers);

            Assert.Equal(allHandlers, controllerHandlers);
        }

        private IHandler[] GetAllHandlers(IWindsorContainer container)
        {
            return GetHandlersFor(typeof(object),container);
        }

        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }

        [Fact]
        public void All_Controllers_are_registered()
        {

        }
    }
}
