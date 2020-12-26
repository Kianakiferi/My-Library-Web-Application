using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
	[Table("reader_gender")]
	public partial class ReaderGender
	{
		[Key]
		[Column("gender_id", TypeName = "smallint(4) unsigned zerofill")]
		public ushort GenderId { get; set; }
		[Required]
		[Column("gender_name", TypeName = "varchar(32)")]
		public string GenderName { get; set; }
	}
}
