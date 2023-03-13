using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PrimeHolding.ViewModel.EmployeeVM
{
	public class CreateVM
	{
		[DisplayName("First Name: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public string FirstName { get; set; }

		[DisplayName("Last Name: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public string LastName { get; set; }

		[DisplayName("Email: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public string Email { get; set; }
		[DisplayName("Phone Number: ")]
		[RegularExpression("^[0-9]+$", ErrorMessage = "The MyNumberString field must contain only numbers.")]
		[Required(ErrorMessage = "This field is Required!")]

		public string PhoneNumber { get; set; }
		[DisplayName("Birth date: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public DateTime BirthDate { get; set; }

		[DisplayName("Monthly salary: ")]
		[RegularExpression("^[0-9]+$", ErrorMessage = "The MyNumberString field must contain only numbers.")]
		[Required(ErrorMessage = "This field is Required!")]
		public decimal MonthlySalary { get; set; }

	}
}
