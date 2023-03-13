using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PrimeHolding.ViewModel.SkillVM
{
	public class CreateVM
	{
		[DisplayName("Title: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public string Title { get; set; }

		[DisplayName("Description: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public string Description { get; set; }
	}
}
