using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("reader_gender")]
    public partial class ReaderGender
    {
        public ReaderGender()
        {
            Reader = new HashSet<Reader>();
        }

        [Key]
        [Column("gender_id", TypeName = "smallint(4) unsigned zerofill")]
        public ushort GenderId { get; set; }
        [Required]
        [Column("gender_name", TypeName = "varchar(32)")]
        public string GenderName { get; set; }

        [InverseProperty("ReaderGender")]
        public virtual ICollection<Reader> Reader { get; set; }
    }
}
