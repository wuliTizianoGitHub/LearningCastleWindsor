using Castle.Core.Internal;
using Castle.MicroKernel;
using Castle.Windsor;
using LearningCastleWindsor.ToBeSeen.Controllers;
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
            return GetHandlersFor(typeof(object), container);
        }

        private IHandler[] GetHandlersFor(Type type, IWindsorContainer container)
        {
            return container.Kernel.GetAssignableHandlers(type);
        }

        [Fact]
        public void All_Controllers_are_registered()
        {
            //IS<IType>是Castle.Core.Internal命名空间下的一个扩展帮助方法，用来判断是否是指定类型。
            //像是C#中的关键字is，不过它只是一个类型，并不是实例级。
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Is<IController>());

            //获取到所有注册到容器中的控制器
            var registeredControllers = GetImplementationTypesFor(typeof(IController), containerWithControllers);

            Assert.Equal(allControllers, registeredControllers);
        }

        private Type[] GetPublicClassesFromApplicationAssembly(Predicate<Type> where)
        {
            return typeof(HomeController).Assembly
                  .GetExportedTypes()
                  .Where(t => t.IsClass)
                  .Where(t => t.IsAbstract == false)
                  .Where(where.Invoke)
                  .OrderBy(t => t.Name)
                  .ToArray();
        }

        private Type[] GetImplementationTypesFor(Type type, IWindsorContainer container)
        {
            return GetHandlersFor(type, container)
                  .Select(h => h.ComponentModel.Implementation)
                  .OrderBy(t => t.Name)
                  .ToArray();
        }

        [Fact]
        public void All_and_only_controllers_have_Controllers_suffix()
        {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Name.EndsWith("Controller"));
            var registeredControllers = GetImplementationTypesFor(typeof(IController), containerWithControllers);
            Assert.Equal(allControllers, registeredControllers);
        }

        [Fact]
        public void All_and_only_controllers_live_in_Controllers_namespace()
        {
            var allControllers = GetPublicClassesFromApplicationAssembly(c => c.Namespace.EndsWith("Controllers"));
            var registeredControllers = GetImplementationTypesFor(typeof(IController), containerWithControllers);
            Assert.Equal(allControllers, registeredControllers);
        }

        [Fact]
        public void All_controllers_are_transient()
        {
            var nonTransientControllers = GetHandlersFor(typeof(IController), containerWithControllers)
                .Where(controller => controller.ComponentModel.LifestyleType != Castle.Core.LifestyleType.Transient)
                .ToArray();

            Assert.Empty(nonTransientControllers);
        }

        [Fact]
        public void All_controllers_expose_themselves_as_service()
        {
            var controllersWithWrongName = GetHandlersFor(typeof(IController), containerWithControllers)
                .Where(c => c.ComponentModel.Services.Single() != c.ComponentModel.Implementation)
                .ToArray();
            Assert.Empty(controllersWithWrongName);
        }
    }
}
