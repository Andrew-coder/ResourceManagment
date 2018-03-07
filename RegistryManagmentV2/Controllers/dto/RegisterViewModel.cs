using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegistryManagmentV2.Controllers.dto
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Длина от 6 до 20 символов")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Длина от 6 до 20 символов")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; } 
    }
}