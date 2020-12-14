using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("reader_type")]
    public partial class ReaderType
    {
        public ReaderType()
        {
            Reader = new HashSet<Reader>();
        }

        [Key]
        [Column("type_id", TypeName = "smallint(4) unsigned zerofill")]
        public ushort TypeId { get; set; }
        [Required]
        [Column("type_name", TypeName = "varchar(16)")]
        public string TypeName { get; set; }
        [Column("type_borrow_quantity")]
        public int? TypeBorrowQuantity { get; set; }
        [Column("type_borrow_days")]
        public int? TypeBorrowDays { get; set; }
        [Column("type_borrow_continue_times")]
        public int? TypeBorrowContinueTimes { get; set; }
        [Column("type_timeout_expense", TypeName = "decimal(8,2)")]
        public decimal? TypeTimeoutExpense { get; set; }
        [Column("type_expiration_date")]
        public short? TypeExpirationDate { get; set; }

        [InverseProperty("ReaderType")]
        public virtual ICollection<Reader> Reader { get; set; }
    }
}
