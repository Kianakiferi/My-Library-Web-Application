using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication3.Models;

namespace WebApplication3.ViewModels
{
	public class BorrowDetailViewModel
	{
		public uint BorrowId { get; set; }

		public uint BookId { get; set; }

		public string BookName { get; set; }

		[Display(Name = "User Id")]
		public string UserId { get; set; }

		public string UserName { get; set; }

		public uint? BorrowContinueTimes { get; set; }

		public DateTime? LendDate { get; set; }

		public DateTime? ExpectReturnDate { get; set; }

		public int RemainingDays { get; set; }

		public int? DelayDays { get; set; }

		public decimal? DelayExpense { get; set; }

		public string BookCover { get; set; }
	}

	public class BorrowViewModel
	{
		[Required]
		public uint BookId { get; set; }

		public string BookName { get; set; }

		public string BookStatus { get; set; }

		public string BookCover { get; set; }

		[Display(Name = "User Id")]
		public string UserId { get; set; }

		public int UUID { get; set; }

		public string UserName { get; set; }
	}


	public class BookViewModel
	{

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
