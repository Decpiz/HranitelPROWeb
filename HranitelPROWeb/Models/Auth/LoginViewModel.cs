using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HranitelPROWeb.Models.Auth
{
    public class LoginViewModel
    {
        [Required]
        public string LoginUser { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
