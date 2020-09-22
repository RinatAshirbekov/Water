using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivingWater.Data.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        [StringLength(10, MinimumLength = 2, ErrorMessage =
            "Длина имени должна быть от 2 до 10 символов")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string CustomerSurName { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string CustomerLastName { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        public string Address { get; set; }
        public Water Water { get; set; }
        public int WaterId { get; set; }
        [Required(ErrorMessage = "Поле должно быть установлено")]
        [Range(1, 20, ErrorMessage =
            "Максимальное количество бутылей за один заказ составляет 20 штук")]
        public int NumberOfBottles { get; set; }
        public DateTime Date { get; set; }
    }
}
