using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace eticaretgiyim.Models
{
    public class Kullanicilar
    {
        [Key]
        public int KullaniciID { get; set; }
        [Required(ErrorMessage = "Adı Boş Bırakamazsınız")]
        public string Ad { get; set; } = string.Empty;
        [Required(ErrorMessage = "Soyadı Boş Bırakamazsınız")]
        public string Soyad  { get; set; } = string.Empty;
        [Required(ErrorMessage = "E-Posta Boş Bırakamazsınız")]
        public string Eposta { get; set; } = string.Empty;
        [Required(ErrorMessage = "Şifreyi Boş Bırakamazsınız")]
        public string SifreHash { get; set; } = string.Empty;
        [Required(ErrorMessage = "Telefonu Boş Bırakamazsınız")]
        public string Telefon { get; set; } = string.Empty;
        public DateTime ? KayitTarihi { get; set; }
        public string Rol { get; set; } = string.Empty;


    }
}
