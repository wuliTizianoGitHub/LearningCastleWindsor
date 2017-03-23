using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCastleWindsor.ToBeSeen.Domain
{
    public class Event : EntityBase
    {
        public string Description { get; set; }

        public string Title { get; set; }

        public DateTime When { get; set; }

        public string Where { get; set; }
    }
}
