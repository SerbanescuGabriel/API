﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository.BusinessEntities
{
    public class UserDetailEntity
    {
        public long UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public string ProfilePicture { get; set; }
    }
}
