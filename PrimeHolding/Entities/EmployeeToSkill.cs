using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeHolding.Entities
{
	public class EmployeeToSkill : BaseEntity
	{
		public enum Level
		{
			Begginer,
			Intermediate,
			Advanced
		}
		public int EmployeeId { get; set; }
		public int SkillId { get; set;}
		public DateTime LastChange { get; set; }
		public Level EmployeeLevel { get; set; }

		[ForeignKey("EmployeeId")]
		public virtual Employee Assignee { get; set; }


		[ForeignKey("SkillId")]
		public virtual Skill Skill { get; set; }

	}
}
