using Microsoft.AspNetCore.Mvc;
using PrimeHolding.Entities;
using PrimeHolding.Migrations;
using PrimeHolding.Repository;
using PrimeHolding.ViewModel.TaskVM;
using Task = PrimeHolding.Entities.Task;


namespace PrimeHolding.Controllers
{
    public class TaskController : Controller
    {
		//display all the tasks 
        public IActionResult Index(IndexVM model)
        {
			TaskRepository taskRepository = new TaskRepository();
			model.Tasks = taskRepository.GetAll();
            return View(model);
        }
		

		[HttpGet]
		public IActionResult Create()
		{
			EmployeeRepo employeeRepo = new EmployeeRepo();
			CreateVM model = new CreateVM();
			model.Employees = employeeRepo.GetAll();
			return View(model);
		}

		[HttpPost]
		public IActionResult Create(CreateVM model)
		{
			EmployeeRepo employeeRepo = new EmployeeRepo();
			model.Employees = employeeRepo.GetAll();

			ModelState.Remove("Employees");
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			Task task = new Task();
			//Намира максималното id и добавя 1 за новото Id На новия user
			
			task.Title = model.Title;
			task.Description = model.Description;
			task.DueDate = model.DueDate;
			task.AssigneeId = model.AssigneeId;
			

			TaskRepository repo = new TaskRepository();

			repo.Save(task);
			return RedirectToAction("Index", "Task");
		}
		[HttpGet]
		public IActionResult Delete(int id)
		{
			TaskRepository repo = new TaskRepository();

			Task task = new Task();
			task.Id = id;

			repo.Delete(task);
			return RedirectToAction("Index", "Task");
		}

		[HttpGet]
		public IActionResult Edit(int id)
		{

			TaskRepository taskRepository = new TaskRepository();
			EmployeeRepo employeeRepo = new EmployeeRepo();
		

			Task task = taskRepository.FirstOrDefault(x => x.Id == id);

			if (task == null)
			{
				return RedirectToAction("Index", "Task");
			}

			EditVM model = new EditVM();
			model.TaskId = task.Id;
			model.Title = task.Title;
			model.Description = task.Description;
			model.DueDate = task.DueDate;
			model.AssigneeId = task.AssigneeId;
			model.Employees = employeeRepo.GetAll();

			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(EditVM model)
		{
			EmployeeRepo employeeRepo = new EmployeeRepo();
			model.Employees = employeeRepo.GetAll();
			
			ModelState.Remove("Employees");
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			Task task = new Task();
			//finds the maximum id and add 1 for a new employee
			task.Id = model.TaskId;
			task.Title = model.Title;
			task.Description = model.Description;
			task.AssigneeId = model.AssigneeId;
			task.DueDate = model.DueDate;
			
			TaskRepository repo = new TaskRepository();


			repo.Save(task);

			return RedirectToAction("Index", "Task");
		}
	}
}
