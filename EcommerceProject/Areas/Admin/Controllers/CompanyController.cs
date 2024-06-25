

using Bulky.Models;
using Bulky.Models.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using Bulky_Data_Access.Repository;
using Bulky_Data_Access.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EcommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           
        }


        public IActionResult Index()
        {
            var CompanyList = _unitOfWork.CompanyRepository.GetAll().ToList();
            
            return View(CompanyList);  
        }
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new Company());
            }
            else
            {
                Company companyObj = _unitOfWork.CompanyRepository.Get(u=>u.Id == id);
                return View(companyObj);
            }
          
        }
        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid)
            {
                if(CompanyObj.Id == 0)
                {
                    _unitOfWork.CompanyRepository.Add(CompanyObj);
                }
                else
                {
                    _unitOfWork.CompanyRepository.Update(CompanyObj);
                }
                
                _unitOfWork.Save();
                TempData["success"] = "company created succesfully";
                return RedirectToAction("Index");
            }
            else
            {
              
                return View(CompanyObj);
            }
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var CompanyList = _unitOfWork.CompanyRepository.GetAll().ToList();
            return Json(new { data = CompanyList });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var companyToBeDeleted = _unitOfWork.CompanyRepository.Get(u => u.Id == id);
            if(companyToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.CompanyRepository.Remove(companyToBeDeleted);
            _unitOfWork.Save();
            
            return Json(new { success = true,message = "Delete Successful"});
        }
        #endregion
    }
}
