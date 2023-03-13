using PrimeHolding.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PrimeHolding.ViewModel.TaskVM
{
	public class CreateVM
	{
		public int AssigneeId { get; set; }

		[DisplayName("Title: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public string Title { get; set; }

		[DisplayName("Description: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public string Description { get; set; }

		[DisplayName("Due Date: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public DateTime DueDate { get; set; }

		public List<Employee> Employees { get; set; }
	}
}
