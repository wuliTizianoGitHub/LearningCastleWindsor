using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCastleWindsor.ToBeSeen.Domain
{
    public class Event : EntityBase
    {
        public virtual string Description { get; set; }

        public virtual string Title { get; set; }

        public virtual DateTime When { get; set; }

        public virtual string Where { get; set; }

        public virtual UserInfo GenerateBy { get; set; }
    }
}
