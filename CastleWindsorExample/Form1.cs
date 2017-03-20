using Castle.Windsor;
using CastleWindsorExampleClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CastleWindsorExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //创建一个Windsor容器对象，并且注册接口以及它们的具体实现
            var container = new WindsorContainer();
            container.Register(Castle.MicroKernel.Registration.Component.For<Main>());
            container.Register(Castle.MicroKernel.Registration.Component.For<IDependency1>().ImplementedBy<Dependency1>());
            container.Register(Castle.MicroKernel.Registration.Component.For<IDependency2>().ImplementedBy<Dependency2>());

            //创建一个Main对象并且调用它的方法
            var mainTest = container.Resolve<Main>();
            mainTest.DoSomething();

        }
    }
}
