using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IgDotNetAPI.Models
{
    public class Person : IdentityUser
    {
        public string FullName { get; set; }
        public string Presentation { get; set; }
        public string TelNumber { get; set; }
        public bool Gender { get; set; }
        public string PhotoURL { get; set; }
    }
}
