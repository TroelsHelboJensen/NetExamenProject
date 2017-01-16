using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnitTestingMockUps.Models.Entity
{
    public class UserModel
    {
        public int UserModelId { get; set; }
        public String Name { get; set; }

        //public int ApplicationUserId { get; set; }
        //public virtual ApplicationUser MainUser { get; set; }
    }
}