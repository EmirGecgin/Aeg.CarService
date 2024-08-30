using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Aeg.CarService.Entity.Web
{
    public class MapContact
    {
        [Key]
        public int Id { get; set; }
        public string Map { get; set; }
        [AllowHtml]
        [UIHint("tinymce_full_compressed")]
        public string Contact { get; set; }
    }
}
