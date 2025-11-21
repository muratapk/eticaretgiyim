using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eticaretgiyim.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("UrunId")]
        public int ? UrunId { get; set; }
        public Urunler urunler { get; set; }    
        public string UserName { get; set; }=string.Empty;
        public string Content { get; set; }=string.Empty;
        public DateTime ? CreatedAt { get; set; }
    }
}
