using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("reader_status")]
    public partial class ReaderStatus
    {
        public ReaderStatus()
        {
            Reader = new HashSet<Reader>();
        }

        [Key]
        [Column("status_id_r", TypeName = "smallint(4) unsigned zerofill")]
        public ushort StatusIdR { get; set; }
        [Required]
        [Column("status_name", TypeName = "varchar(16)")]
        public string StatusName { get; set; }

        [InverseProperty("ReaderStatus")]
        public virtual ICollection<Reader> Reader { get; set; }
    }
}
