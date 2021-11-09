﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        public virtual MembershipType MembershipType { get; set; }

        public DateTimeOffset? Birthday { get; set; }
    }
}