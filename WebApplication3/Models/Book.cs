using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
	[Table("book")]
	public partial class Book
	{
		public Book()
		{
			Borrow = new HashSet<Borrow>();
		}

		[Key]
		[Column("book_id", TypeName = "int(12) unsigned zerofill")]
		public uint BookId { get; set; }
		[Column("book_code", TypeName = "varchar(24)")]
		public string BookCode { get; set; }
		[Required]
		[Column("book_name", TypeName = "varchar(32)")]
		public string BookName { get; set; }
		[Column("book_name_sub", TypeName = "varchar(32)")]
		public string BookNameSub { get; set; }
		[Column("book_isbn", TypeName = "varchar(16)")]
		public string BookIsbn { get; set; }
		[Column("book_clccode", TypeName = "varchar(16)")]
		public string BookClccode { get; set; }
		[Column("book_status_id", TypeName = "smallint(4) unsigned zerofill")]
		public ushort? BookStatusId { get; set; }
		[Column("book_author", TypeName = "varchar(64)")]
		public string BookAuthor { get; set; }
		[Column("book_publisher", TypeName = "varchar(64)")]
		public string BookPublisher { get; set; }
		[Column("book_press_date", TypeName = "date")]
		public DateTime? BookPressDate { get; set; }
		[Column("book_language_id", TypeName = "smallint(4) unsigned zerofill")]
		public ushort? BookLanguageId { get; set; }
		[Column("book_pages")]
		public uint? BookPages { get; set; }
		[Column("book_price", TypeName = "decimal(8,2)")]
		public decimal? BookPrice { get; set; }
		[Column("book_purchase_date", TypeName = "date")]
		public DateTime BookPurchaseDate { get; set; }
		[Column("book_brief", TypeName = "text")]
		public string BookBrief { get; set; }
		[Column("book_cover", TypeName = "varchar(64)")]
		public string BookCover { get; set; }

		[ForeignKey(nameof(BookLanguageId))]
		[InverseProperty("Book")]
		public virtual BookLanguage BookLanguage { get; set; }
		[ForeignKey(nameof(BookStatusId))]
		[InverseProperty("Book")]
		public virtual BookStatus BookStatus { get; set; }
		[InverseProperty("Book")]
		public virtual ICollection<Borrow> Borrow { get; set; }
	}
}
