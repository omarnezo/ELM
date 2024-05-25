using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELM.Core.Entities
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [Required]
        [Column("BookId")]
        public long BookId { get; set; }

        [Column("BookInfo")]
        public string BookInfo { get; set; }

        [Column("LastModified")]
        public DateTime LastModified { get; set; }
    }
}
