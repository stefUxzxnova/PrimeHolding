using Microsoft.AspNetCore.Mvc;
using PrimeHolding.Entities;
using PrimeHolding.Repository;
using PrimeHolding.ViewModel.SkillVM;

namespace PrimeHolding.Controllers
{
	public class SkillController : Controller
	{
		//dipslay all the skills
		public IActionResult Index(IndexVM model)
		{
			SkillRepo skillRepo = new SkillRepo();

			model.Skills = skillRepo.GetAll();
			return View(model);
		}

		//we can create more
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

			Skill skill = new Skill();
			//Намира максималното id и добавя 1 за новото Id На новия user
			skill.Title = model.Title;
			skill.Description = model.Description;

			SkillRepo repo = new SkillRepo();

			repo.Save(skill);
			return RedirectToAction("Index", "Skill");
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			SkillRepo repo = new SkillRepo();

			Skill skill = new Skill();
			skill.Id = id;

			repo.Delete(skill);
			return RedirectToAction("Index", "Skill");
		}

		
	}
}
