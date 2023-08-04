﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.MemberShip
{
    public class UserRole
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }

        public Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
