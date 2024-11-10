using Microsoft.AspNetCore.Mvc;
using testcsharp.DataAccess.Data;
using testcsharp.DataAccess.Repository.IRepository;
using testcsharp.Models;

namespace testcsharp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        // Dùng các phương thức đã xây dựng ở lớp interface "ICategoryRepository _categoryRepo"

        private readonly IUnitOfWork _unitOfWork; // không thể thay đổi sau khi gán
        public CategoriesController(IUnitOfWork db)
        {
            _unitOfWork = db; // gán ở contructor và không thể thay đổi
        }
        // => kết nối với cơ sở dữ liệu thông qua ApplicationDbContext khi được gọi controller

        // GET: CategoriesController
        public ActionResult Index()
        {
            List<Category> objCategories = _unitOfWork.CategoryRepository.GetAll().ToList();
            // lấy toàn bộ dữ liệu trong table_name 
            return View(objCategories);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category objCategories)
        {
            if (objCategories.Name == objCategories.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
                // Đối số đầu là thuộc tính thuôộc template tương ưứng
                // Doi so thu hai la message canh bao
            }

            if (ModelState.IsValid) // Template check 
            {
                _unitOfWork.CategoryRepository.Add(objCategories);
                _unitOfWork.Save();
                TempData["success"] = "Category created successfully!"; // Thong bao giong flash
                return RedirectToAction("Index");
                // Thêm vào xong chuyển hướng về razor Categories
            }
            // như bên sqlalchemy flask
            return View(objCategories);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? element = _unitOfWork.CategoryRepository.Get(u => u.Id == id); //Tìm
            // Category? element = _db.Categories.FirstOrDefault(u => u.Id == id); // Tim data dau tien
            if (element == null)
            {
                return NotFound();
            }
            return View(element);
        }
        [HttpPost]
        public ActionResult Edit(Category objCategories)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(objCategories);
                _unitOfWork.Save();
                TempData["success"] = "Category edited successfully!";
                return RedirectToAction("Index");
            }
            return View(objCategories);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            Category? element = _unitOfWork.CategoryRepository.Get(u => u.Id == id);
            if (element == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Delete(element);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
