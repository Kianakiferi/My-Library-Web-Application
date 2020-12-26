using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
	public class ApplicationUser : IdentityUser
	{
		public ApplicationUser()
		{
			Borrow = new HashSet<Borrow>();
		}

		[Column("user_id", TypeName = "int(8) unsigned zerofill")]
		public int UUID { get; set; }

		[Column("user_borrow_quantity")]
		public uint? UserBorrowQuantity { get; set; }

		[Column("user_gender_Id", TypeName = "smallint(4) unsigned zerofill")]
		public ushort? UserGenderId { get; set; }

		[Column("user_register_date", TypeName = "date")]
		public DateTime? UserRegisterDate { get; set; }

		[Column("user_photo", TypeName = "varchar(255)")]
		public string UserPhoto { get; set; }

		[InverseProperty("Reader")]
		public virtual ICollection<Borrow> Borrow { get; set; }
	}
}
