using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
	[Table("borrow")]
	public partial class Borrow
	{
		[Key]
		[Column("id")]
		public uint Id { get; set; }
		[Required]
		[Column("book_id")]
		public uint BookId { get; set; }
		[Required]
		[Column("reader_id", TypeName = "varchar(255)")]
		public string ReaderId { get; set; }
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
		[InverseProperty(nameof(ApplicationUser.Borrow))]
		public virtual ApplicationUser Reader { get; set; }
	}
}
