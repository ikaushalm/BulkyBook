using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {  

        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext dbContext)
        {
                this._context = dbContext;
        }
        public IActionResult Index()
        {
            IEnumerable<Catergory> catergories = _context.Categoreis.ToList();
            return View(catergories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost()]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Catergory obj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obj);
                _context.SaveChanges();
                TempData["success"] = "Recored Created SUccesfully";
                return RedirectToAction("Index");
            }
            return View();
        }

      
        //get
        public IActionResult Edit(int? id )
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }

            var catergoryObj=_context.Categoreis.Find(id);

            if (catergoryObj == null)
            {
                return NotFound();
            }

            return View(catergoryObj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Catergory obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                _context.Categoreis.Update(obj);
                _context.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var categoryFromDb = _context.Categoreis.Find(id);
			//var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
			//var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

			if (categoryFromDb == null)
			{
				return NotFound();
			}

			return View(categoryFromDb);
		}

		//POST
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? id)
		{
			var obj = _context.Categoreis.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_context.Categoreis.Remove(obj);
			_context.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");

		}

	}
}
