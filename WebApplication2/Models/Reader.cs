using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("reader")]
    public partial class Reader
    {
        public Reader()
        {
            Borrow = new HashSet<Borrow>();
        }

        [Key]
        [Column("reader_id", TypeName = "int(8) unsigned zerofill")]
        public uint ReaderId { get; set; }
        [Required]
        [Column("reader_name", TypeName = "varchar(16)")]
        public string ReaderName { get; set; }
        [Required]
        [Column("reader_password", TypeName = "varchar(128)")]
        public string ReaderPassword { get; set; }
        [Column("reader_type_id", TypeName = "smallint(4) unsigned zerofill")]
        public ushort? ReaderTypeId { get; set; }
        [Column("reader_roles_id", TypeName = "smallint(4) unsigned zerofill")]
        public ushort ReaderRolesId { get; set; }
        [Column("reader_status_id", TypeName = "smallint(4) unsigned zerofill")]
        public ushort? ReaderStatusId { get; set; }
        [Column("reader_borrow_quantity")]
        public uint? ReaderBorrowQuantity { get; set; }
        [Column("reader_gender_id", TypeName = "smallint(4) unsigned zerofill")]
        public ushort? ReaderGenderId { get; set; }
        [Column("reader_phonenumber", TypeName = "varchar(16)")]
        public string ReaderPhonenumber { get; set; }
        [Column("reader_email", TypeName = "varchar(32)")]
        public string ReaderEmail { get; set; }
        [Column("reader_department", TypeName = "varchar(16)")]
        public string ReaderDepartment { get; set; }
        [Column("reader_register_date", TypeName = "date")]
        public DateTime? ReaderRegisterDate { get; set; }
        [Column("reader_photo", TypeName = "varchar(64)")]
        public string ReaderPhoto { get; set; }

        [ForeignKey(nameof(ReaderGenderId))]
        [InverseProperty("Reader")]
        public virtual ReaderGender ReaderGender { get; set; }
        [ForeignKey(nameof(ReaderRolesId))]
        [InverseProperty(nameof(ReaderRole.Reader))]
        public virtual ReaderRole ReaderRoles { get; set; }
        [ForeignKey(nameof(ReaderStatusId))]
        [InverseProperty("Reader")]
        public virtual ReaderStatus ReaderStatus { get; set; }
        [ForeignKey(nameof(ReaderTypeId))]
        [InverseProperty("Reader")]
        public virtual ReaderType ReaderType { get; set; }
        [InverseProperty("Reader")]
        public virtual ICollection<Borrow> Borrow { get; set; }
    }
}
