using Bulky.DataAccess.Data;
using Bulky.Models;
using Bulky_Data_Access.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            var CategoryList = _unitOfWork.CatergoryRepository.GetAll().ToList();
            return View(CategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CatergoryRepository.Add(category);
                _unitOfWork.Save();
                TempData["success"] = "category created succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.CatergoryRepository.Get(u => u.Id == Id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CatergoryRepository.Update(category);
                _unitOfWork.Save();
                TempData["success"] = "category updated succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.CatergoryRepository.Get(u => u.Id == Id);

            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int Id)
        {
            var category = _unitOfWork.CatergoryRepository.Get(u => u.Id == Id);

            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.CatergoryRepository.Remove(category);
            _unitOfWork.Save();
            TempData["success"] = "category deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
