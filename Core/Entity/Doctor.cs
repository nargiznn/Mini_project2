﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Entitiy
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
