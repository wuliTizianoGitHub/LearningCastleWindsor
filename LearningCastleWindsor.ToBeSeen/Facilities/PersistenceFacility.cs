using Castle.MicroKernel.Facilities;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearningCastleWindsor.ToBeSeen.Facilities
{
    public class PersistenceFacility : AbstractFacility
    {
        protected override void Init()
        {
            //var config = BuildDataBaseConfiguration();
        }

        //private Configuration BuildDataBaseConfiguration()
        //{
        //    return Fluently
        //}
    }
}