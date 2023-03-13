using PrimeHolding.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static PrimeHolding.Entities.EmployeeToSkill;

namespace PrimeHolding.ViewModel.EmployeeVM
{
	public class AddEmployeeSkillVM
	{
		public int EmployeeId { get; set; }

		[DisplayNameAttribute("Skill: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public int SkillId { get; set; }


		[DisplayName("Level: ")]
		[Required(ErrorMessage = "This field is Required!")]
		public Level LevelEmployee { get; set; }


		public List<Skill> Skills { get; set; }
	}
}
