using System.ComponentModel.DataAnnotations;

namespace eticaretgiyim.Models
{
    public class Kategoriler
    {
        [Key]
        public int KategoriID { get; set; }
        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage ="Kategori Boş Bırakamazsınız")]
     
        public string KategoriAd { get; set; } = string.Empty;
        [Display(Name = "Açıklama")]
        [Required(ErrorMessage ="Açıklamayı Boş Bırakamazsınız")]
     
        public string Aciklama { get; set; } = string.Empty;
    }
}
