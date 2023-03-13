using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PrimeHolding.Entities;
using Task = PrimeHolding.Entities.Task;

namespace PrimeHolding.Repository
{
	public class PrimeHoldingProjectDbContext : DbContext	
	{
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<EmployeeToSkill> EmployeeToSkill { get; set; }

		public PrimeHoldingProjectDbContext()
		{
			this.Employees = this.Set<Employee>();
			this.Tasks = this.Set<Task>();
			this.Skills = this.Set<Skill>();
			this.EmployeeToSkill = this.Set<EmployeeToSkill>();

		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseSqlServer("Server = localhost; Database = PrimeHoldingProjectDB; Trusted_Connection = True;")
				.UseLazyLoadingProxies();
		}

		//To do:
		//public List<EmployeeViewModel> GetTopEmployeesLastMonth()
		//{
		//	var query = @"
  //      SELECT TOP 5 e.EmployeeName, COUNT(t.TaskID) AS CompletedTasks
  //      FROM Employee e
  //      INNER JOIN Tasks t ON e.EmployeeID = t.EmployeeID
  //      WHERE t.DueDate >= DATEADD(month, -1, GETDATE())
  //      GROUP BY e.EmployeeID, e.EmployeeName
  //      ORDER BY CompletedTasks DESC";

		//	var results = new List<EmployeeViewModel>();

		//	using (var connection = new SqlConnection(connectionString))
		//	{
		//		connection.Open();
		//		using (var command = new SqlCommand(query, connection))
		//		{
		//			using (var reader = command.ExecuteReader())
		//			{
		//				while (reader.Read())
		//				{
		//					var employeeName = reader.GetString(0);
		//					var completedTasks = reader.GetInt32(1);

		//					var viewModel = new EmployeeViewModel
		//					{
		//						EmployeeName = employeeName,
		//						CompletedTasks = completedTasks
		//					};

		//					results.Add(viewModel);
		//				}
		//			}
		//		}
		//	}

		//	return results;
		//}
	}
}
