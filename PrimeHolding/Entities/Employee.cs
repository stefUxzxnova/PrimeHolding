namespace PrimeHolding.Entities
{
	public class Employee : BaseEntity
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public DateTime BirthDate { get; set; }
		public decimal MonthlySalary { get; set; }
	}
}
