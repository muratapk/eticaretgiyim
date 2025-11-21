using System.ComponentModel.DataAnnotations;

namespace eticaretgiyim.Models
{
    public class UrunYildiz
    {
        [Key]
        public int YildizId { get; set; }
        public int ? UrunId { get; set; }
        public int ? YildizSayisi { get; set; }   
        public DateTime ? CreatedAt { get; set; }

    }
}
