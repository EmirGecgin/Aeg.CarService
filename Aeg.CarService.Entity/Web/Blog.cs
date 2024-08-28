using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Aeg.CarService.Entity.Web
{
    public class Blog
    {
        public int Id { get; set; }
        public string Header { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}
