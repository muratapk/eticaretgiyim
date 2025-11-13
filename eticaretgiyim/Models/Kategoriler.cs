using System.ComponentModel.DataAnnotations;

namespace eticaretgiyim.Models
{
    public class Kategoriler
    {
        [Key]
        public int KategoriID { get; set; }
        [Required(ErrorMessage ="Kategori Boş Bırakamazsınız")]
        public string KategoriAd { get; set; } = string.Empty;
        [Required(ErrorMessage ="Açıklamayı Boş Bırakamazsınız")]
        public string Aciklama { get; set; } = string.Empty;
    }
}
