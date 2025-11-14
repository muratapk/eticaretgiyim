using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eticaretgiyim.Models
{
    public class Urunler
    {
        [Key]
        public int UrunID { get; set; }
        public  string UrunAd { get; set; }=string.Empty;
        public string  Aciklama { get; set; }=string.Empty;
        public  decimal ? Fiyat { get; set; }
        public int ? StokAdet { get; set; }

        [ForeignKey("Kategoriler")]
        public int ? KategoriID { get; set; }
        public Kategoriler ? Kategoriler { get; set; }
        public string ? Renk { get; set; }
        public string ? Beden { get; set; }
        public  string ? GorselUrl  { get; set; }
        public bool ? Aktif { get; set; }

    }
}
