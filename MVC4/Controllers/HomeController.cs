using MVC4.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC4.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			//Connect to the database
			SampleDb db = new SampleDb();
			//Retrieve departments, and build selectlist
			List<SelectListItem> selectListItems = new List<SelectListItem>();
			foreach (Department department in db.Departments)
			{
				SelectListItem selectListItem = new SelectListItem
				{
					Text = department.Name,
					Value = department.Id.ToString(),
					Selected = department.IsSelected.HasValue ? department.IsSelected.Value : false
				};
				selectListItems.Add(selectListItem);
			};
			ViewBag.Departments = selectListItems;
			return View();
		}

		public ActionResult Index1()
		{
			Company company = new Company("BeeBee");
			ViewBag.Departments = new SelectList(company.Departments, "Id", "Name");
			ViewBag.CompanyName = company.CompanyName;

			return View();
		}

		public ActionResult Index2()
		{
			Company company = new Company("BeeBee");

			return View(company);
		}
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}