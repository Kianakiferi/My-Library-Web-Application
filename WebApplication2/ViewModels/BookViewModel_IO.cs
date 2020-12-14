using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2
{
	public class BookViewModel_IO
	{
		public virtual ICollection<Borrow> Borrow { get; set; }
		public BookViewModel_IO()
		{
			Borrow = new HashSet<Borrow>();
		}

		[Key]
		public uint BookId { get; set; }

		public string BookCode { get; set; }

		[Required]
		public string BookName { get; set; }

		public string BookNameSub { get; set; }

		public string BookIsbn { get; set; }

		public string BookClccode { get; set; }

		public ushort? BookStatusId { get; set; }

		public string BookAuthor { get; set; }

		public string BookPublisher { get; set; }

		[DataType(DataType.Date)]
		public DateTime? BookPressDate { get; set; }

		public ushort? BookLanguageId { get; set; }

		public uint? BookPages { get; set; }

		public decimal? BookPrice { get; set; }

		[Required]
		[DataType(DataType.Date)]
		public DateTime BookPurchaseDate { get; set; }

		public string BookBrief { get; set; }

		public string BookCover { get; set; }

		[ForeignKey(nameof(BookLanguageId))]
		[InverseProperty("Book")]
		public virtual BookLanguage BookLanguage { get; set; }
		[ForeignKey(nameof(BookStatusId))]
		[InverseProperty("Book")]
		public virtual BookStatus BookStatus { get; set; }

	}
}
