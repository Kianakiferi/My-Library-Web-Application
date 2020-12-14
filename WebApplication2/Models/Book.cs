using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
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
        [Display(Name = "Code")]
        public string BookCode { get; set; }

        [Required]
        [Column("book_name", TypeName = "varchar(32)")]
        [Display(Name = "Name")]
        public string BookName { get; set; }

        [Column("book_name_sub", TypeName = "varchar(32)")]
        [Display(Name = "Subtitle")]
        public string BookNameSub { get; set; }

        [Column("book_isbn", TypeName = "varchar(16)")]
        [Display(Name = "ISBN")]
        public string BookIsbn { get; set; }

        [Column("book_clccode", TypeName = "varchar(16)")]
        [Display(Name = "CLC Code")]
        public string BookClccode { get; set; }

        [Column("book_status_id", TypeName = "smallint(4) unsigned zerofill")]
        [Display(Name = "Status")]
        public ushort? BookStatusId { get; set; }

        [Column("book_author", TypeName = "varchar(64)")]
        [Display(Name = "Author")]
        public string BookAuthor { get; set; }

        [Column("book_publisher", TypeName = "varchar(64)")]
        [Display(Name = "Publisher")]
        public string BookPublisher { get; set; }

        [Column("book_press_date", TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Press Time")]
        public DateTime? BookPressDate { get; set; }

        [Column("book_language_id", TypeName = "smallint(4) unsigned zerofill")]
        [Display(Name = "Language")]
        public ushort? BookLanguageId { get; set; }

        [Column("book_pages")]
        [Display(Name = "Pages")]
        public uint? BookPages { get; set; }

        [Column("book_price", TypeName = "decimal(8,2)")]
        [Display(Name = "Price")]
        public decimal? BookPrice { get; set; }

        [Column("book_purchase_date", TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Purchase Time")]
        public DateTime BookPurchaseDate { get; set; }

        [Column("book_brief", TypeName = "text")]
        [Display(Name = "Brief")]
        public string BookBrief { get; set; }

        [Column("book_cover", TypeName = "varchar(64)")]
        [Display(Name = "Cover")]
        public string BookCover { get; set; }

        [ForeignKey(nameof(BookLanguageId))]
        [InverseProperty("Book")]
        [Display(Name = "Language")]
        public virtual BookLanguage BookLanguage { get; set; }
        [ForeignKey(nameof(BookStatusId))]
        [InverseProperty("Book")]
        [Display(Name = "Status")]
        public virtual BookStatus BookStatus { get; set; }
        [InverseProperty("Book")]
        public virtual ICollection<Borrow> Borrow { get; set; }

        public static explicit operator Book(BookViewModel_IO BookVM)
        {
            return new Book
            {
                BookId = BookVM.BookId,
                BookCode = BookVM.BookCode,
                BookName = BookVM.BookName,
                BookNameSub = BookVM.BookNameSub,
                BookIsbn = BookVM.BookIsbn,
                BookClccode = BookVM.BookClccode,
                BookStatusId = BookVM.BookStatusId,
                BookAuthor = BookVM.BookAuthor,
                BookPublisher = BookVM.BookPublisher,
                BookPressDate = BookVM.BookPressDate,
                BookLanguageId = BookVM.BookLanguageId,
                BookPages = BookVM.BookPages,
                BookPrice = BookVM.BookPrice,
                BookPurchaseDate = BookVM.BookPurchaseDate,
                BookBrief = BookVM.BookBrief,
                BookCover = BookVM.BookCover
            };
        }
    }
}
