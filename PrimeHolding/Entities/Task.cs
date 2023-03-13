using System.ComponentModel.DataAnnotations.Schema;

namespace PrimeHolding.Entities
{
	public class Task : BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set;}
		public int AssigneeId { get; set; }


		[ForeignKey("AssigneeId")]
		public virtual Employee Assignee { get; set; }
	}
}
