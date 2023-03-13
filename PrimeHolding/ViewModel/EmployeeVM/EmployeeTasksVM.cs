using PrimeHolding.Entities;

namespace PrimeHolding.ViewModel.EmployeeVM
{
	public class EmployeeTasksVM
	{
		public int EmployeeId { get; set; }
		public int SkillId { get; set; }
		public List<EmployeeToSkill> EmployeeToSkill { get; set; }
	}
}
