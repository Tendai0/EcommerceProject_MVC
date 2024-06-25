
using Bulky.Models;
using Bulky.Models.Models;
using Bulky_Data_Access.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace EcommerceProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
       
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var ProductList = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category").ToList();
            return View(ProductList);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            ShoppingCart cart = new ShoppingCart
            {
                Product = _unitOfWork.ProductRepository.Get(u => u.Id == id, includeProperties: "Category"),
                Count = 1,
                ProductId = id
            };
            return View(cart);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            shoppingCart.ApplicationUserId = userId;
            shoppingCart.Id = 0;

            ShoppingCart CartFromDb = _unitOfWork.ShoppingCartRepository.Get(u => u.ApplicationUserId ==  userId &&
            u.ProductId ==shoppingCart.ProductId);

            if(CartFromDb != null)
            {
                CartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCartRepository.Update(CartFromDb);
            }
            else
            {
                _unitOfWork.ShoppingCartRepository.Add(shoppingCart);
            }
            TempData["success"] = "Cart updated successfully";
            _unitOfWork.Save();

            // Redirect to avoid resubmission on page refresh
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
