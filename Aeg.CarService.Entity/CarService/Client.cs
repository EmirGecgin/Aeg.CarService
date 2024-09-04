using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeg.CarService.Entity.CarService
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string NameSurname { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }

    }
}
