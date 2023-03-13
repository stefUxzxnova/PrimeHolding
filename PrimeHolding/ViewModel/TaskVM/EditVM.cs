using PrimeHolding.Entities;

namespace PrimeHolding.ViewModel.TaskVM
{
	public class EditVM
	{
		public int TaskId { get; set; }
		public int AssigneeId { get; set; }

		//[DisplayName("Title: ")]
		//[Required(ErrorMessage = "This field is Required!")]
		public string Title { get; set; }

		//[DisplayName("Description: ")]
		//[Required(ErrorMessage = "This field is Required!")]
		public string Description { get; set; }


		public DateTime DueDate { get; set; }
		public List<Employee> Employees { get; set; }
	}
}
