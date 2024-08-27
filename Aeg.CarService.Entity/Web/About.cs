using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Aeg.CarService.Entity.Web
{
    public class About
    {
        public int Id { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string Content { get; set; }
        public string Image { get; set; }
        public string Motto { get; set; }

    }
}
