using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeg.CarService.Entity.Web
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(80)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        [MaxLength(500)]
        public string Image { get; set; }
    }
}
