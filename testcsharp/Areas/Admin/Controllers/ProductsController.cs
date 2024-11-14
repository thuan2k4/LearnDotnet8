using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using testcsharp.DataAccess.Data;
using testcsharp.DataAccess.Repository.IRepository;
using testcsharp.Models;
using testcsharp.Models.ViewModels;

namespace testcsharp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork; 
        public ProductsController(IUnitOfWork db)
        {
            _unitOfWork = db;
        }

        public ActionResult Index()
        {
            List<Product> objProduct = _unitOfWork.ProductRepository.GetAll().ToList();
            return View(objProduct);
        }
        public ActionResult Create()
        {
            //ViewBag.CategoryList = CategoryList;
            //ViewData["CategoryList"] = CategoryList;

            // Cả 3 điều để truyền dữ liệu từ controller -> view
            // Tồn tại trong phạm vi request và sẽ bị xóa khi req kết thúc
            // Riêng TempData tồn tại được 2 lần req

            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.CategoryRepository.GetAll()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            return View(productVM);
        }
        [HttpPost]
        public ActionResult Create(Product obj)
        {

            if (ModelState.IsValid) 
            {
                _unitOfWork.ProductRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? element = _unitOfWork.ProductRepository.Get(u => u.Id == id);
            if (element == null)
            {
                return NotFound();
            }
            return View(element);
        }
        [HttpPost]
        public ActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ProductRepository.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product edited successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Product? element = _unitOfWork.ProductRepository.Get(u => u.Id == id);
            if (element == null)
            {
                return NotFound();
            }
            _unitOfWork.ProductRepository.Delete(element);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
