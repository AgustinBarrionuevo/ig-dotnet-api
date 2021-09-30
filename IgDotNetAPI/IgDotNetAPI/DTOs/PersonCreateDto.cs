using IgDotNetAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IgDotNetAPI.DTOs
{
    public class PersonCreateDto
    {
        [Required(ErrorMessage ="Email required")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="FullName required")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }
        [Required(ErrorMessage ="UserName required")]
        [DataType(DataType.Text)]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password required")]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} characters long", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Person GetPerson() {
            return new Person()
            {
                Email = this.Email,
                FullName = this.FullName,
                UserName = this.UserName
            };
        }
    }
}
