using DataAnnotationsExtensions;
using HranitelPROWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace HranitelPROWeb.Models.User
{
    public class ProfileViewModel
    {
        public List<Zajavki>? Applications { get; set; }
        public Polzovateli? CurrentUser { get; set; }
        public List<Posetiteli>? Visitors { get; set; }
        public Zajavki? Appli { get; set; }

        //Поля для валидации EditProfile\\
        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле является обязательным")]
        [MaxLength(30)]
        public string? LastName { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле является обязательным")]
        [MaxLength(30)]
        public string? Name { get; set; }

        [Display(Name = "Отчество")]
        [MaxLength(30)]
        public string? Patronomic { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Поле является обязательным")]
        [MaxLength(50)]
        [Email]
        public string? Email { get; set; }
        public string? Error { get; set; }
        //Поля для валидации EditProfile\\
    }
}
