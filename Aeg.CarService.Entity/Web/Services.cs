using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeg.CarService.Entity.Web
{
    public class Services
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Image { get; set; }
    }
}
