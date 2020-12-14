using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("reader_role")]
    public partial class ReaderRole
    {
        public ReaderRole()
        {
            Reader = new HashSet<Reader>();
        }

        [Key]
        [Column("role_id", TypeName = "smallint(4) unsigned zerofill")]
        public ushort RoleId { get; set; }
        [Required]
        [Column("role_name", TypeName = "varchar(16)")]
        public string RoleName { get; set; }

        [InverseProperty("ReaderRoles")]
        public virtual ICollection<Reader> Reader { get; set; }
    }
}
