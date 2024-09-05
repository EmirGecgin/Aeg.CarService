using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeg.CarService.Entity.CarService
{
    public class Model
    {
        [Key]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
