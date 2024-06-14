using HranitelPROWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace HranitelPROWeb.Models.RegApplications
{
    public class GroupStepOneViewModel
    {
        public List<Posetiteli>? Visitors { get; set; }



        //Поля для валидации формы\\
        [Required(ErrorMessage = "Укажите фамилию гостя")]
        [StringLength(30)]
        [Display(Name = "Фамилия")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Укажите имя")]
        [StringLength(30)]
        [Display(Name = "Имя")]
        public string? Name { get; set; }

        [Display(Name = "Отчество")]
        [StringLength(30)]
        public string? Patronomic { get; set; }

        [Required(ErrorMessage = "Укажите номер телефона гостя")]
        [Phone(ErrorMessage = "Только цифры")]
        [StringLength(16)]
        [Display(Name = "Номер телефона")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Укажите дату рождения гостя")]
        [Display(Name = "Дата рождения")]
        public DateTime DateBirthday { get; set; }

        [Required(ErrorMessage = "Укажите паспортные данные гостя")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Серия паспорта - 4 цифры")]
        [Phone(ErrorMessage = "Только цифры")]
        [Display(Name = "Паспорт: серия")]
        public string? PasSeries { get; set; }

        [Required(ErrorMessage = "Укажите паспортные данные гостя")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Номер паспорта - 6 цифр")]
        [Phone(ErrorMessage = "Только цифры")]
        [Display(Name = "Паспорт: серия")]
        public string? PasNumber { get; set; }


        public string? Error { get; set; }
        //Поля для валидации формы\\




    }
}
