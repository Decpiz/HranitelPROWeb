using HranitelPROWeb.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace HranitelPROWeb.Models.RegApplications
{
    public class GroupStepTwoViewModel
    {

        public List<Podrazdelenium>? Divisions { get; set; }
        public List<Celi>? Targets { get; set; }
        public Zajavki? Application { get; set; }
        public List<Posetiteli>? Visitors { get; set; }


        //Поля для валидации формы\\
        [Required(ErrorMessage = "Укажите цель посещения")]
        [Display(Name = "Цель посещения")]
        public string? SelectTarget { get; set; }

        [Required(ErrorMessage = "Укажите подразделение")]
        [Display(Name = "Подразделение")]
        public string? SelectDivision { get; set; }

        [Required(ErrorMessage = "Укажите дату, на которую хотите оформить заявку")]
        [Display(Name = "Дата посещения")]
        public DateTime DateRegistration { get; set; }

        public string? CountError { get; set; }
        //Поля для валидации формы\\
    }
}
