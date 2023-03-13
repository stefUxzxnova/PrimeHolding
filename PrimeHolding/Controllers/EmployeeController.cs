using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimeHolding.Entities;
using PrimeHolding.Repository;
using PrimeHolding.ViewModel.EmployeeVM;
using System.Linq.Expressions;
using Employee = PrimeHolding.Entities.Employee;

namespace PrimeHolding.Controllers
{
	public class EmployeeController : Controller
	{
		//display all the employees
		[HttpGet]
		public IActionResult Index(IndexVM model)
		{
			EmployeeRepo employeeRepo = new EmployeeRepo();

			model.Employees = employeeRepo.GetAll();
			return View(model);
		}

		//create employee
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(CreateVM model)
		{

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			Employee employee = new Employee();
			
			employee.FirstName = model.FirstName;
			employee.LastName = model.LastName;
			employee.Email = model.Email;
			employee.PhoneNumber = model.PhoneNumber;
			employee.BirthDate = (DateTime)model.BirthDate;
			employee.MonthlySalary = model.MonthlySalary;

			EmployeeRepo repo = new EmployeeRepo();

			repo.Save(employee);
			return RedirectToAction("Index", "Employee");
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			EmployeeRepo repo = new EmployeeRepo();

			Employee employee = new Employee();
			employee.Id = id;

			repo.Delete(employee);
			return RedirectToAction("Index", "Employee");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{

			EmployeeRepo repo = new EmployeeRepo();
			
			Employee employee = repo.FirstOrDefault(x => x.Id == id);

			if (employee == null)
			{
				return RedirectToAction("Index", "Employee");
			}
			EditVM model = new EditVM();
			model.Id = employee.Id;
			model.FirstName = employee.FirstName;
			model.LastName = employee.LastName;
			model.Email = employee.Email;
			model.PhoneNumber = employee.PhoneNumber;
			model.BirthDate = employee.BirthDate;
			model.MonthlySalary = employee.MonthlySalary;

			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(EditVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			Employee employee = new Employee();
			//finds the maximum id and add 1 for a new employee
			employee.Id = model.Id;
			employee.FirstName = model.FirstName;
			employee.LastName = model.LastName;
			employee.Email = model.Email;
			employee.PhoneNumber = model.PhoneNumber;
			employee.BirthDate = model.BirthDate;
			employee.MonthlySalary = model.MonthlySalary;
			
			EmployeeRepo repo = new EmployeeRepo();
			

			repo.Save(employee);

			return RedirectToAction("Index", "Employee");
		}

		//all employees can have different skills with different level
		[HttpGet]
		public IActionResult AddEmployeeSkill(int id)
		{
			EmployeeRepo employeeRepo = new EmployeeRepo();
			Employee employee = employeeRepo.FirstOrDefault(x => x.Id == id);
			if (employee == null)
			{
				return RedirectToAction("Index", "Employee");
			}

			AddEmployeeSkillVM model = new AddEmployeeSkillVM();
			SkillRepo skillrepo = new SkillRepo();
			model.EmployeeId = employee.Id;
			model.Skills = skillrepo.GetAll();

			return View(model);
		}

		[HttpPost]
		public IActionResult AddEmployeeSkill(AddEmployeeSkillVM model)
		{
			SkillRepo skillrepo = new SkillRepo();
			model.Skills = skillrepo.GetAll();
			ModelState.Remove("Skills");
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			EmployeeToSkill employeeToSkill = new EmployeeToSkill();
			EmployeeToSkillRepo employeeToSkillRepo = new EmployeeToSkillRepo();
			employeeToSkill.EmployeeId = model.EmployeeId;
			employeeToSkill.SkillId = model.SkillId;
			employeeToSkill.LastChange = DateTime.Now;
			employeeToSkill.EmployeeLevel = model.LevelEmployee;

			employeeToSkillRepo.Save(employeeToSkill);

			return RedirectToAction("Index", "Employee");
		}

		//display the skills of the employee with given id
		[HttpGet]
		public IActionResult EmployeeSkills(int id)
		{
			
			EmployeeToSkillRepo repo = new EmployeeToSkillRepo();
			EmployeeTasksVM model = new EmployeeTasksVM();

			model.EmployeeId = id;
            model.EmployeeToSkill =	repo.GetAll(i => i.EmployeeId == id);
			

			return View(model);

		}

	}
}
