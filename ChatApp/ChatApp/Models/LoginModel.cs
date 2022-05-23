using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ChatApp_Leano_Stewart.Models
{
    public class LoginModel
    {
        [Required, MaxLength(32), EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
