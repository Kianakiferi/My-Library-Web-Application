using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication2.Models;

namespace WebApplication2.ViewModels
{
	public class ReaderViewModel_IO
	{
		[InverseProperty("Reader")]
		public virtual ICollection<Borrow> Borrow { get; set; }
		public ReaderViewModel_IO()
		{
			Borrow = new HashSet<Borrow>();
		}

		[Key]
		public uint ReaderId { get; set; }

		[Required]
		public string ReaderName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string ReaderPassword { get; set; }

		public ushort? ReaderTypeId { get; set; }
		public ushort ReaderRolesId { get; set; }
		public ushort? ReaderStatusId { get; set; }

		public uint? ReaderBorrowQuantity { get; set; }

		public ushort? ReaderGenderId { get; set; }

		[DataType(DataType.PhoneNumber)]
		public string ReaderPhonenumber { get; set; }

		[DataType(DataType.EmailAddress)]
		public string ReaderEmail { get; set; }

		public string ReaderDepartment { get; set; }
		
		[DataType(DataType.Date)]
		public DateTime? ReaderRegisterDate { get; set; }

		[DataType(DataType.ImageUrl)]
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

	}
}
