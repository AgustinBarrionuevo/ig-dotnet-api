using IgDotNetAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IgDotNetAPI.DTOs
{
    public class PersonUpdateDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Presentation { get; set; }
        public string TelNum { get; set; }
        public bool Gender { get; set; }
        public string PhotoURL { get; set; }

        public Person UpdatePerson(Person target) {
            target.FullName = this.FullName;
            target.UserName = this.UserName;
            target.Presentation = this.Presentation;
            target.TelNumber = this.TelNum;
            target.Gender = this.Gender;
            target.PhotoURL = this.PhotoURL;
            return target;
        }
    }

}
