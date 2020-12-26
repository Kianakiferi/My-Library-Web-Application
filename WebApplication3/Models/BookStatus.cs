using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
	[Table("book_status")]
	public partial class BookStatus
	{
		public BookStatus()
		{
			Book = new HashSet<Book>();
		}

		[Key]
		[Column("status_id", TypeName = "smallint(4) unsigned zerofill")]
		public ushort StatusId { get; set; }
		[Required]
		[Column("status_name", TypeName = "varchar(16)")]
		public string StatusName { get; set; }

		[InverseProperty("BookStatus")]
		public virtual ICollection<Book> Book { get; set; }
	}
}
