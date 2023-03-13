using System.ComponentModel.DataAnnotations;

namespace PrimeHolding.Entities
{
	public abstract class BaseEntity
	{
		//base enitity which will be inherited
		[Key]
		public int Id { get; set; }
	}
}
