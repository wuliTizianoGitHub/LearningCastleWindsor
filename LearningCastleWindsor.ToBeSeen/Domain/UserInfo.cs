using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningCastleWindsor.ToBeSeen.Domain
{
    public class UserInfo : EntityBase
    {
        public virtual string Email { get; set; }
        public virtual string Username { get; set; }
    }
}
