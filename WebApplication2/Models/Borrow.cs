using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("borrow")]
    public partial class Borrow
    {
        [Key]
        [Column("id")]
        public uint Id { get; set; }
        [Column("reader_id")]
        public uint ReaderId { get; set; }
        [Column("book_id")]
        public uint BookId { get; set; }
        [Column("borrow_continue_times")]
        public uint? BorrowContinueTimes { get; set; }
        [Column("lend_date", TypeName = "date")]
        public DateTime? LendDate { get; set; }
        [Column("expect_return_date", TypeName = "date")]
        public DateTime? ExpectReturnDate { get; set; }
        [Column("delay_days")]
        public int? DelayDays { get; set; }
        [Column("delay_expense", TypeName = "decimal(8,2)")]
        public decimal? DelayExpense { get; set; }
        [Column("fine_expense", TypeName = "decimal(16,2)")]
        public decimal? FineExpense { get; set; }
        [Column("lend_operator_id")]
        public uint? LendOperatorId { get; set; }
        [Column("return_operator_id")]
        public int? ReturnOperatorId { get; set; }

        [ForeignKey(nameof(BookId))]
        [InverseProperty("Borrow")]
        public virtual Book Book { get; set; }
        [ForeignKey(nameof(ReaderId))]
        [InverseProperty("Borrow")]
        public virtual Reader Reader { get; set; }
    }
}
