using System.ComponentModel.DataAnnotations;

namespace MyCompany.Domain.Entities
{
    public class TextField : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }

        [Display(Name = "Назва сторінки (заголовок)")]
        public override string Title { get; set; } = "Информаційна сторінка";

        [Display(Name = "Cодержание страницы")]
        public override string Text { get; set; } = "Зміст заповнюється адміністратором";
    }
}
