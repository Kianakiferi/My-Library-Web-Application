using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("book_language")]
    public partial class BookLanguage
    {
        public BookLanguage()
        {
            Book = new HashSet<Book>();
        }

        [Key]
        [Column("language_id", TypeName = "smallint(4) unsigned zerofill")]
        public ushort LanguageId { get; set; }
        [Required]
        [Column("language_name", TypeName = "varchar(16)")]
        public string LanguageName { get; set; }

        [InverseProperty("BookLanguage")]
        public virtual ICollection<Book> Book { get; set; }
    }
}
