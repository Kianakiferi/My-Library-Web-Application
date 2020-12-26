using System.ComponentModel.DataAnnotations;

namespace WebApplication3.ViewModels
{
	public class UserViewModel
	{
		[Display(Name = "User Id")]
		public string Id { get; set; }

		[Display(Name = "User Id")]
		public int UUID { get; set; }

		[Display(Name = "Username")]
		public string UserName { get; set; }

		[Display(Name = "Email")]
		public string Email { get; set; }

		[Display(Name = "Borrows")]
		public int BorrowQuantity { get; set; }
	}

	public class EditViewModel
	{
		[Display(Name = "User Id")]
		public int UUID { get; set; }

		[Display(Name = "Username")]
		public string UserName { get; set; }

		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}

	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Username")]
		public string UserName { get; set; }

		[Required]
		[StringLength(128, MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
	}

	public class RegisterViewModel
	{
		[Required]
		[Display(Name = "Username")]
		public string UserName { get; set; }

		[Required]
		[StringLength(128, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }

		[EmailAddress]
		[Display(Name = "Email")]
		public string Email { get; set; }
	}


}
